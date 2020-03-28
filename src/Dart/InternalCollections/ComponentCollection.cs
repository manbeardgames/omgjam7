using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Dart
{
    public class ComponentCollection
    {
        //  A value indicating that the collection is dirty and needs to be updated.
        private bool _dirty;

        //  A value indicating that the order of updateable components has changed and needs
        //  to have the updateable collection sorted.
        private bool _updateOrderChanged;

        //  A value indicating that hte order of the drawable components has changed and needs
        //  to have the drawable collection sorted.
        private bool _drawOrderChanged;

        //  Collection of all components that have been added to this collection.
        private List<IComponent> _components;

        //  Collection of all updatable components that have been added to this collection.
        private List<IUpdatableComponent> _updateableCompoennts;

        //  Collection of all renderable components that have been added to this collection.
        private List<IRenderableComponent> _renderableComponents;

        //  Collection of all components that are waiting to be added to this collection.
        private List<IComponent> _toAdd;

        //  Collection of all components that are waiting to be removed from this collection.
        private List<IComponent> _toRemove;

        //  A hashset of all components that have been added to this collection. This is used to
        //  quickly verify if a component is already added.
        private HashSet<IComponent> _componentHash;

        //  A hashset of all components that are waiting to be added to this collection.  This is
        //  used to quickly verify if the component is already waiting.
        private HashSet<IComponent> _toAddHash;

        //  A hashset of all components that are waiting ot be removed from thsi collection. This
        //  is used to quickly verify if hte component is already waiting.
        private HashSet<IComponent> _toRemoveHash;

        //  Lookup dictionary of all compoennts that have been added to this collection, stored
        //  by unique component name.
        private Dictionary<string, IComponent> _byName;

        //  A reusable collection to store components that need to have their Start() method called.
        private List<IComponent> _toStart;

        //  A reusable collection to store compoennts that need to have their End() method called.
        private List<IComponent> _toEnd;

        /// <summary>
        ///     Gets the GameObject this ComponentCollection is for.
        /// </summary>
        public GameObject GameObject { get; }

        /// <summary>
        ///     Creates a new ComponentCollection instance.
        /// </summary>
        /// <param name="gameObject">
        ///     The GameObject this collection is for.
        /// </param>
        public ComponentCollection(GameObject gameObject)
        {
            if (gameObject == null)
            {
                throw new ArgumentNullException("gameObject", "The GameObject this component collection is for cannot be null");
            }

            GameObject = gameObject;

            _components = new List<IComponent>();
            _byName = new Dictionary<string, IComponent>();
            _updateableCompoennts = new List<IUpdatableComponent>();
            _renderableComponents = new List<IRenderableComponent>();
            _toAdd = new List<IComponent>();
            _toRemove = new List<IComponent>();
            _toStart = new List<IComponent>();
            _toEnd = new List<IComponent>();

            _componentHash = new HashSet<IComponent>();
            _toAddHash = new HashSet<IComponent>();
            _toRemoveHash = new HashSet<IComponent>();
        }

        /// <summary>
        ///     Updates this collection.
        /// </summary>
        public void Update()
        {
            //  Updating the collection can be costly, so we only call the UpdateCollection method if the
            //  collection is actually dirty and needs to be updated
            if (_dirty)
            {
                UpdateCollection();
            }

            //  Regardless of if the collection had to be updated above or not, the collection is now at this
            //  point considered clean.  Howver, actions below during the _toStart iteration could cause the
            //  collection to become dirty again. This is why we mark it clean here first.
            _dirty = false;

            //  Process any components that are waiting to be started
            if (_toStart.Count > 0)
            {
                for (int i = 0; i < _toStart.Count; i++)
                {
                    _toStart[i].Start();
                }

                _toStart.Clear();
            }

            //  Update all updatable components
            for (int i = 0; i < _updateableCompoennts.Count; i++)
            {
                if (_updateableCompoennts[i].Enabled)
                {
                    _updateableCompoennts[i].Update();
                }
            }
        }

        /// <summary>
        ///     Updates this colleciton by processing all components that are waiting to be added
        ///     or removed from this collection.
        /// </summary>
        private void UpdateCollection()
        {
            //  If there are compoennts to be added to the collection, we add them here.  Each component
            //  is added to the main colleciton and then further sorted into the updateable and renderable
            //  collections.  immediately after being added to the colleciton, the Initialize() method of the
            //  component is called and it is then added to the _toStart collection, where it will be started
            //  during the Update() frame.
            if (_toAdd.Count > 0)
            {
                for (int i = 0; i < _toAdd.Count; i++)
                {
                    //  Add the component to the collection
                    _components.Add(_toAdd[i]);
                    _componentHash.Add(_toAdd[i]);
                    _byName.Add(_toAdd[i].Name, _toAdd[i]);

                    //  If the component is an updateable component, add it to the updateable collection
                    if (_toAdd[i] is IUpdatableComponent updateable)
                    {
                        _updateableCompoennts.Add(updateable);
                        _updateOrderChanged = true;
                        updateable.UpdateOrderChanged += OnUpdateOrderChanged;
                    }

                    //  If the component is a renderable component, add it to the rendereable collection
                    if (_toAdd[i] is IRenderableComponent renderable)
                    {
                        _renderableComponents.Add(renderable);
                        _drawOrderChanged = true;
                        renderable.DrawOrderChanged += OnDrawOrderChanged;
                    }

                    //  Now that the component has been added, tell it to initialize
                    _toAdd[i].Initialize(GameObject);

                    //  Add it to the collection of components that need to be started. We'll start them later after
                    //  the collection has finished processing adds and removes.
                    _toStart.Add(_toAdd[i]);
                }
            }

            _toAdd.Clear();
            _toAddHash.Clear();

            //  If there are components to be fremoved form the collection, we remove them here.  Each component
            //  is removed from the main colleciton and then furthe removed form the the individual updateable and
            //  renderable collections if they were added there previously.  Immediately after being removed
            //  from the collection, the End() method of the component is called.
            if (_toRemove.Count > 0)
            {
                for (int i = 0; i < _toRemove.Count; i++)
                {
                    //  Remove the component from the collection.
                    _components.Remove(_toRemove[i]);
                    _componentHash.Remove(_toRemove[i]);
                    _byName.Remove(_toRemove[i].Name);

                    //  If the component was an updateable component, remove it from that collection
                    if (_toRemove[i] is IUpdatableComponent updateable)
                    {
                        _updateableCompoennts.Remove(updateable);
                        updateable.UpdateOrderChanged -= OnUpdateOrderChanged;
                    }

                    //  If the component was a renderable component, removeit from that collection
                    if (_toRemove[i] is IRenderableComponent renderable)
                    {
                        _renderableComponents.Remove(renderable);
                        renderable.DrawOrderChanged -= OnDrawOrderChanged;
                    }

                    //  Now that the compoennt has been removed, tell it so
                    _toRemove[i].Removed(GameObject);

                }
            }

            _toRemove.Clear();
            _toRemoveHash.Clear();

            //  If there was a changed in the colleciton, we need to resort the collections.
            if (_updateOrderChanged) { SortUpdatable(); }
            if (_drawOrderChanged) { SortRenderable(); }

        }

        /// <summary>
        ///     Sorts the updateable components in this collection based on their UpdateOrder property.
        /// </summary>
        private void SortUpdatable()
        {
            _updateableCompoennts.Sort((a, b) => a.UpdateOrder.CompareTo(b.UpdateOrder));
            _updateOrderChanged = false;
        }

        /// <summary>
        ///     Sorts the renderable components in this collection based on their DrawOrder property.
        /// </summary>
        private void SortRenderable()
        {
            _renderableComponents.Sort((a, b) => a.DrawOrder.CompareTo(b.DrawOrder));
            _drawOrderChanged = false;
        }

        /// <summary>
        ///     Renders the renderable components within this collection.
        /// </summary>
        public void Render()
        {
            for (int i = 0; i < _renderableComponents.Count; i++)
            {
                _renderableComponents[i].Render();
            }
        }

        /// <summary>
        ///     Renders the renderable compoennts within this collection in a debug state.
        /// </summary>
        public void DebugRender()
        {
            for (int i = 0; i < _renderableComponents.Count; i++)
            {
                _renderableComponents[i].DebugRender();
            }
        }

        /// <summary>
        ///     Given a component, adds it to this collection.
        /// </summary>
        /// <param name="component">
        ///     The component to add.
        /// </param>
        public void Add(IComponent component)
        {
            //  Check if the given component instance has already been added to the collection.  If it
            //  has, just return back.
            if (_componentHash.Contains(component)) { return; }

            //  Check if the given component instance has already been put in queue to be added to the 
            //  collection.  If it has, just return back
            if (_toAddHash.Contains(component)) { return; }

            //  We're good to add the component. Add it to the _toAdd collections
            _toAdd.Add(component);
            _toAddHash.Add(component);

            //  Collection is now dirty
            _dirty = true;
        }

        /// <summary>
        ///     Given a component, removes it from this collection.
        /// </summary>
        /// <param name="component">
        ///     The component to remove.
        /// </param>
        public void Remove(IComponent component)
        {
            //  Check to see if this component is waiting to be added to our collection.  
            if (_toAddHash.Contains(component))
            {
                //  Since it actually hasn't been added yet, we can just remove it from
                //  the queue and return back
                _toAdd.Remove(component);
                _toAddHash.Remove(component);
                return;
            }


            //  Check if the given component is actually apart of this collection.  If it isn't, just
            //  return back.
            if (!_componentHash.Contains(component)) { return; }

            //  Check if the given component has already been added to the queue to be remvoed. If it has
            //  just return back
            if (_toRemoveHash.Contains(component)) { return; }

            //  If this is reached, we can safely now add the component to be removed.
            _toRemove.Add(component);
            _toRemoveHash.Add(component);

            //  Collection is now dirty
            _dirty = true;
        }

        /// <summary>
        ///     Given the name of a component, locates and returns that component if it
        ///     is contained within this collection.  If a component with the given name
        ///     cannot be found, null is returned instead.
        /// </summary>
        /// <typeparam name="TComponent">
        ///     The component type to find.
        /// </typeparam>
        /// <param name="name">
        ///     The name of the component.
        /// </param>
        /// <returns>
        ///     The component if found; othewise, null.
        /// </returns>
        public TComponent Get<TComponent>(string name) where TComponent : class, IComponent
        {
            if (_byName.TryGetValue(name, out IComponent found))
            {
                return found as TComponent;
            }
            else
            {
                return null;
            }


        }

        /// <summary>
        ///     Given a component type, returns the first instance of that component within
        ///     this collection.  If a component with the given type cannot be found, null is
        ///     returned instead.
        /// </summary>
        /// <typeparam name="TComponent">
        ///     The type of component to find.
        /// </typeparam>
        /// <returns>
        ///     The first occurance of the given compoennt type within this collection. If no compoennt
        ///     with the given type can be found, null is returned instead.
        /// </returns>
        public TComponent GetFirst<TComponent>() where TComponent : class, IComponent
        {
            for (int i = 0; i < _components.Count; i++)
            {
                if (_components[i] is TComponent result)
                {
                    return result;
                }
            }

            return null;
        }

        /// <summary>
        ///     Given a component type, returns a collection of each instance of that
        ///     within this collection.
        /// </summary>
        /// <typeparam name="TComponent">
        ///     The type of component.
        /// </typeparam>
        /// <returns>
        ///     A collection containing all instances of the given component type found
        ///     within this collection.  If no instances are found, an empty collection 
        ///     is returned.
        /// </returns>
        public List<TComponent> GetAll<TComponent>() where TComponent : IComponent
        {
            List<TComponent> result = new List<TComponent>();
            for (int i = 0; i < _components.Count; i++)
            {
                if (_components[i] is TComponent found)
                {
                    result.Add(found);
                }
            }

            return result;
        }

        private void OnUpdateOrderChanged(object sender, EventArgs e)
        {
            _updateOrderChanged = true;
        }

        private void OnDrawOrderChanged(object sender, EventArgs e)
        {
            _drawOrderChanged = true;
        }
    }
}
