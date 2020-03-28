using Microsoft.Xna.Framework.Graphics;

namespace Dart
{
    public abstract class Scene
    {
        /// <summary>
        ///     Called only once, on the same frame that the scene becomes the active scene, before any
        ///     update or rendering is called.
        /// </summary>
        public virtual void Begin() { }

        /// <summary>
        ///     Called immediately before the Update method is called.
        /// </summary>
        public virtual void BeforeUpdate() { }

        /// <summary>
        ///     Updates this scene.
        /// </summary>
        public virtual void Update() { }

        /// <summary>
        ///     Called immediately after the Update method is called.
        /// </summary>
        public virtual void AfterUpdate() { }

        /// <summary>
        ///     Called immediately before the Render method is called.
        /// </summary>
        public virtual void BeforeRender() { }

        /// <summary>
        ///     Renders this scene.
        /// </summary>
        public virtual void Render() { }

        /// <summary>
        ///     Called immediately after the Render method is called.
        /// </summary>
        public virtual void AfterRender() { }
    }
}
