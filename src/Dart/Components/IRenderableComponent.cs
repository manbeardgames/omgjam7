using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Dart
{
    public interface IRenderableComponent
    {
        /// <summary>
        ///     Gets a value indicating if this component is renderable.
        /// </summary>
        bool Visible { get; }

        /// <summary>
        ///     Gets a value indicating the order in which this component should be 
        ///     rendered compared with other componets attached to the entity. The smaller
        ///     the value, the early it is rendered.
        /// </summary>
        int DrawOrder { get; }

        /// <summary>
        ///     Invoked when the Visible property changes.
        /// </summary>
        event EventHandler<EventArgs> VisibleChanged;

        /// <summary>
        ///     Invoked when the DrawOrder property changes.
        /// </summary>
        event EventHandler<EventArgs> DrawOrderChanged;

        void Refresh();

        /// <summary>
        ///     Renders the component.
        /// </summary>
        void Render();

        /// <summary>
        ///     Renders the component in a debug state.
        /// </summary>
        void DebugRender();
    }
}
