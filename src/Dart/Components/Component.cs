using System;

namespace Dart
{
    public class Component : IComponent, IUpdatableComponent
    {
        //  A value indicating if this component is enabled.
        private bool _enabled = true;

        //  A value indicating the order in which this component should be updated 
        //  compared to when other components are updated.  The smaller the value
        //  the earlier this component is updated.
        private int _updateOrder;

        /// <summary>
        ///     Gets the name of this component.
        /// </summary>
        public string Name { get; protected set; }

        /// <summary>
        ///     Gets or Sets a value indicating if this component is enabled.
        /// </summary>
        public bool Enabled
        {
            get => _enabled;
            set
            {
                if (_enabled == value) { return; }
                _enabled = value;
                EnabledChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        /// <summary>
        ///     Gets or Sets a value indicating the order in which this component should
        ///     be updated compared to when other components are updated.   The smaller the
        ///     value, the earlier this component is updated.
        /// </summary>
        public int UpdateOrder
        {
            get => _updateOrder;
            set
            {
                if (_updateOrder == value) { return; }
                _updateOrder = value;
                UpdateOrderChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        /// <summary>
        ///     Gets the GameObject this component is attached to.
        /// </summary>
        public GameObject GameObject { get; private set; }

        /// <summary>
        ///     Invoked when the Enabled property of this component has changed.
        /// </summary>
        public event EventHandler<EventArgs> EnabledChanged;

        /// <summary>
        ///     Invoked when the UpdateOrder property of this component has changed.
        /// </summary>
        public event EventHandler<EventArgs> UpdateOrderChanged;

        /// <summary>
        ///     Creates a new Component instance.
        /// </summary>
        /// <param name="gameObject">
        ///     The GameObject this Component is attached to.
        /// </param>
        public Component() { Name = Guid.NewGuid().ToString(); }

        /// <summary>
        ///     Called when this component is added to a GameObject.
        /// </summary>
        public virtual void Initialize(GameObject gameObject)
        {
            GameObject = gameObject;
        }

        public virtual void Removed(GameObject gameObject)
        {
            GameObject = null;
        }

        /// <summary>
        ///     Called after Initialize.  Use this method to get references to any other components
        ///     that are attached to the GameOBject.
        /// </summary>
        public virtual void Start() { }

        /// <summary>
        ///     Updates this Component.
        /// </summary>
        public virtual void Update() { }

        /// <summary>
        ///     Called when the Enabled property is changed.
        /// </summary>
        protected virtual void OnEnabledChanged(object sender, EventArgs e) { }

        /// <summary>
        ///     Called when the UpdateOrder property is changed.
        /// </summary>
        protected virtual void OnUpdateOrderChanged(object sender, EventArgs e) { }



    }
}
