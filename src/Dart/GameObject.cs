using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Dart
{
    public class GameObject
    {
        //  A value indicating if this GameObject is enabled.
        private bool _enabled = true;

        //  A value indicating if this GameObject is visible.
        private bool _visible = true;

        /// <summary>
        ///     Gets the internal Name of this GameObject.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        ///     Gets or Sets a value indicating if this GameObject is enabled.  If a GameObject
        ///     is not enabled, then it is not updated.
        /// </summary>
        public bool Enabled
        {
            get => _enabled;
            set
            {
                if (_enabled.Equals(value)) { return; }
                _enabled = value;
            }

        }

        /// <summary>
        ///     Gets or Sets a value indicating if this GameObject is visiel.  If a GameObject
        ///     is not visible, then it is not rendered.
        /// </summary>
        public bool Visible
        {
            get => _visible;
            set
            {
                if (_visible.Equals(value)) { return;  }
                _visible = value;
            }
        }

        /// <summary>
        ///     Gets the collection of components that have been added to this GameObject.
        /// </summary>
        public ComponentCollection Components { get; private set; }

        /// <summary>
        ///     Gets or Sets the transform component of this entity that describes the 
        ///     position, rotation, and scale.
        /// </summary>
        public RectTransform2DComponent Transform { get; set; }

        /// <summary>
        ///     Creates a ne GameObject instance.
        /// </summary>
        public GameObject() : this(Guid.NewGuid().ToString(), Vector2.Zero) { }

        /// <summary>
        ///     Creates a new GameObject instance.
        /// </summary>
        /// <param name="name"></param>
        public GameObject(string name) : this(name, Vector2.Zero) { }

        /// <summary>
        ///     Creates a new GameObject instance.
        /// </summary>
        /// <param name="name">
        ///     The name of the GameObject.
        /// </param>
        /// <param name="position">
        ///     The xy-coordinate position of the game object.
        /// </param>
        public GameObject(string name, Vector2 position)
        {
            Name = name;
            Components = new ComponentCollection(this);
            Transform = AddComponent<RectTransform2DComponent>();
            Transform.Position = position;
        }

        /// <summary>
        ///     Updates this GameObject.  When overriding, ensuer that you call base.Update() in order
        ///     to update the components, otherwise you'll need to manuall update the the components.
        /// </summary>
        public virtual void Update()
        {
            if (Enabled)
            {
                //  Update components
                Components.Update();
            }
        }

        /// <summary>
        ///     Renders this GameObject.  When overriding, ensure that you call base.Render() in order
        ///     to render the components, otherwise you'll need to manually render the components.
        /// </summary>
        public virtual void Render()
        {
            if (Visible)
            {
                //  Render Components
                Components.Render();
            }
        }

        /// <summary>
        ///     Renders this GameObject in a debug state.  When overriding, ensure that you call base.DebugRender()
        ///     in order to render the components in a debug state, otherwise you'll need to manuall render the
        ///     components.
        /// </summary>
        public virtual void DebugRender()
        {
            Components.DebugRender();
        }

        /// <summary>
        ///     Given a Component type, adds a new instance of that component using its
        ///     default constructor to thsi GameObject and returns the component back.
        /// </summary>
        /// <typeparam name="TComponent">
        ///     The type of Component to add.
        /// </typeparam>
        /// <returns>
        ///     The component that was added.
        /// </returns>
        public TComponent AddComponent<TComponent>() where TComponent : IComponent, new()
        {
            return AddComponent<TComponent>(new TComponent());
        }

        /// <summary>
        ///     Given a Component, adds it to this GameObject and returns the component back.
        /// </summary>
        /// <typeparam name="TComponent">
        ///     The type of Component to add.
        /// </typeparam>
        /// <param name="component">
        ///     The Component to add.
        /// </param>
        /// <returns>
        ///     The Component that was added.
        /// </returns>
        public TComponent AddComponent<TComponent>(TComponent component) where TComponent : IComponent
        {
            //  Ensure component is given
            if (component == null)
            {
                throw new ArgumentNullException("component", "The component being added cannot be null!");
            }

            Components.Add(component);

            return component;
        }

        /// <summary>
        ///     Given a component, removes it from this GameObject then returns it back.
        /// </summary>
        /// <typeparam name="TComponent">
        ///     The type of Component.
        /// </typeparam>
        /// <param name="component">
        ///     The Component to remove.
        /// </param>
        /// <returns>
        ///     The Component that was removed.
        /// </returns>
        public TComponent RemoveComponent<TComponent>(TComponent component) where TComponent : IComponent
        {
            //  Ensure the component is given
            if (component == null)
            {
                throw new ArgumentNullException("component", "The component being removed cannot be null");
            }

            Components.Remove(component);
            return component;
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
            return Components.Get<TComponent>(name);
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
            return Components.GetFirst<TComponent>();
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
            return Components.GetAll<TComponent>();
        }
    }
}
