using Microsoft.Xna.Framework.Graphics;

namespace Dart
{
    public class SpriteComponent : RenderableComponent
    {
        /// <summary>
        ///     Gets or Sets the VirtualTexture to use when rendering.
        /// </summary>
        public VirtualTexture2D VirtualTexture { get; set; }

        /// <summary>
        ///     Gets the width of the render, in pixles.
        /// </summary>
        public virtual int Width => VirtualTexture.Width;

        /// <summary>
        ///     Gets the height of the rneder, in pixels.
        /// </summary>
        public virtual int Height => VirtualTexture.Height;

        /// <summary>
        ///     Creates a new SpriteComponnt instnace.
        /// </summary>
        public SpriteComponent():base() { }

        /// <summary>
        ///     Creates a new SpriteComponent instnace.
        /// </summary>
        /// <param name="virtualTexture">
        ///     The VirtualTexture to use when rendering.
        /// </param>
        public SpriteComponent(VirtualTexture2D virtualTexture) : base()
        {
            VirtualTexture = virtualTexture;
        }

        /// <summary>
        ///     Renders this component.
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Render()
        {
            if (VirtualTexture)
            {
                Draw.VirtualTexture2D(VirtualTexture, RenderPosition, Origin, Color, Scale, Rotation, SpriteEffects);
            }
        }

        /// <summary>
        ///     Sets the xy-coordiante origin of the render to the center of the texture.
        /// </summary>
        /// <returns></returns>
        public virtual SpriteComponent CenterOrigin()
        {
            OriginX = Width * 0.5f;
            OriginY = Height * 0.5f;
            return this;
        }

        /// <summary>
        ///     Given a VirtualTexture2D, sets it as the texture for this component and
        ///     returns the component back.
        /// </summary>
        /// <param name="virtualTexture">
        ///     The VirtualTexture2D to set.
        /// </param>
        /// <returns>
        ///     This component instance.
        /// </returns>
        public virtual SpriteComponent SetTexture(VirtualTexture2D virtualTexture)
        {
            VirtualTexture = virtualTexture;
            return this;
        }

        /// <summary>
        ///     Given the content relative path to a Texture2D asset, loads the asset
        ///     and sets the VirtualTexture2D property of this component, then returns
        ///     thsi componennt.
        /// </summary>
        /// <param name="contentPath">
        ///     The path to the Texture2D asset to load relative to the Content root directory.
        /// </param>
        /// <returns>
        ///     This component instance.
        /// </returns>
        public virtual SpriteComponent SetTexture(string contentPath)
        {
            VirtualTexture = VirtualTexture2D.FromContent(contentPath);
            return this;
        }
    }
}
