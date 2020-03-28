using System;

namespace Dart
{
    public interface IUpdatableComponent
    {
        /// <summary>
        ///     Gets a value that indicates if this component is enabled.
        /// </summary>
        bool Enabled { get; }

        /// <summary>
        ///     Gets the order in which this component should be updated. The smaller the
        ///     value, the earlier it is updated.
        /// </summary>
        int UpdateOrder { get; }

        /// <summary>
        ///     Invoked when the Enable property changes.
        /// </summary>
        event EventHandler<EventArgs> EnabledChanged;

        /// <summary>
        ///     Invoked when the UpdateOrder property changes.
        /// </summary>
        event EventHandler<EventArgs> UpdateOrderChanged;

        /// <summary>
        ///     Updates the component.
        /// </summary>
        void Update();
    }
}
