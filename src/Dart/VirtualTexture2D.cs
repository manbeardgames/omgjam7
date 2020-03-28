using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dart
{
    public class VirtualTexture2D
    {
        /// <summary>
        ///     Gets the <see cref="Texture2D"/> represented by this virtual texture.
        /// </summary>
        public Texture2D Texture { get; private set; }

        /// <summary>
        ///     Gets the rectangluare boundry area within the texture that this virtual texture
        ///     represents.
        /// </summary>
        public Rectangle ClipRect { get; private set; }

        /// <summary>
        ///     TODO: Document.
        /// </summary>
        public Vector2 DrawOffset { get; private set; }

        /// <summary>
        ///     Gets the width of this virtual texture, in pixels.
        /// </summary>
        public int Width { get; private set; }

        /// <summary>
        ///     Gets the height of this virtual texture, in pixels.
        /// </summary>
        public int Height { get; private set; }

        /// <summary>
        ///     Gets the xy-coordinate center of this texture.
        /// </summary>
        public Vector2 Center { get; private set; }

        /// <summary>
        ///     Gets the left UV coordinate of this virtual texture.
        /// </summary>
        public float LeftUV { get; private set; }

        /// <summary>
        ///     Gets the right UV coordinate of this virtual texture.
        /// </summary>
        public float RightUV { get; private set; }

        /// <summary>
        ///     Gets the top UV coordinate of this virtual texture.
        /// </summary>
        public float TopUV { get; private set; }

        /// <summary>
        ///     Gets the bottom UV coordinate of this virtual texture.
        /// </summary>
        public float BottomUV { get; private set; }

        /// <summary>
        ///     Gets the total number of pixels contained in this virtual texture.
        /// </summary>
        public int TotalPixels => Width * Height;



        /// <summary>
        ///     Creates a new <see cref="VirtualTexture2D"/> instance.
        /// </summary>
        public VirtualTexture2D() { }

        /// <summary>
        ///     Creates a new <see cref="VirtualTexture2D"/> instance.
        /// </summary>
        /// <param name="texture">
        ///     The <see cref="Texture2D"/> this represents.
        /// </param>
        public VirtualTexture2D(Texture2D texture)
        {
            Texture = texture;
            ClipRect = new Rectangle(0, 0, texture.Width, texture.Height);
            DrawOffset = Vector2.Zero;
            Width = ClipRect.Width;
            Height = ClipRect.Height;
            SetUtil();
        }

        /// <summary>
        ///     Given an existing <see cref="VirtualTexture2D"/> instance, creates a new
        ///     <see cref="VirtualTexture2D"/> from the parent based on the rectanglur boundry
        ///     given.
        /// </summary>
        /// <param name="instance">
        ///     The existing <see cref="VirtualTexture2D"/> to based this one on.
        /// </param>
        /// <param name="x">
        ///     The top-left x-coordinate of the boundry within the existing. <see cref="VirtualTexture2D"/>
        ///     to create this one from.
        /// </param>
        /// <param name="y">
        ///     The top-left y-coordinate of the boundry within the existing <see cref="VirtualTexture2D"/>
        ///     to create this one from.
        /// </param>
        /// <param name="width">
        ///     The width of the boundry within the existing <see cref="VirtualTexture2D"/> to create
        ///     this one from.
        /// </param>
        /// <param name="height">
        ///     The height of the boundry within the existing <see cref="VirtualTexture2D"/> to create
        ///     this one from.
        /// </param>
        public VirtualTexture2D(VirtualTexture2D instance, int x, int y, int width, int height)
        {
            Texture = instance.Texture;
            ClipRect = instance.GetRelativeRect(x, y, width, height);
            DrawOffset = new Vector2(-Math.Min(x - instance.DrawOffset.X, 0), -Math.Min(y - instance.DrawOffset.Y, 0));
            Width = width;
            Height = height;
            SetUtil();
        }

        /// <summary>
        ///     Given an exisitng <see cref="VirtualTexture2D"/> instance, create a new one based on
        ///     a rectangluar boundry within the existing one.
        /// </summary>
        /// <param name="instance">
        ///     The existing <see cref="VirtualTexture2D"/> instance to create this one from.
        /// </param>
        /// <param name="clipRect">
        ///     The rectangluar boundry within the existing instance to create this one from.
        /// </param>
        public VirtualTexture2D(VirtualTexture2D instance, Rectangle clipRect)
            : this(instance, clipRect.X, clipRect.Y, clipRect.Width, clipRect.Height) { }

        /// <summary>
        ///     Given a pixel width, height, and color, create a new <see cref="VirtualTexture2D"/>
        /// </summary>
        /// <param name="width">
        ///     The width of the generated texture in pixles.
        /// </param>
        /// <param name="height">
        ///     The height of the generated texutre in pixels.
        /// </param>
        /// <param name="color">
        ///     The color value to set for each pixel.
        /// </param>
        public VirtualTexture2D(int width, int height, Color color)
        {
            Texture = new Texture2D(Engine.Graphics.Device, width, height);
            Color[] colors = new Color[width * height];
            for (int i = 0; i < colors.Length;i++)
            {
                colors[i] = color;
            }
            Texture.SetData<Color>(colors);

            ClipRect = new Rectangle(0, 0, width, height);
            DrawOffset = Vector2.Zero;
            Width = width;
            Height = height;
            SetUtil();
        }

        /// <summary>
        ///     Sets the utility properties for this <see cref="VirtualTexture2D"/> instance.
        /// </summary>
        private void SetUtil()
        {
            Center = new Vector2(Width, Height) * 0.5f;
            LeftUV = ClipRect.Left / (float)Texture.Width;
            RightUV = ClipRect.Right / (float)Texture.Width;
            TopUV = ClipRect.Top / (float)Texture.Height;
            BottomUV = ClipRect.Bottom / (float)Texture.Height;
        }

        /// <summary>
        ///     Unloads the resources managed by this <see cref="VirtualTexture2D"/> instance.
        /// </summary>
        public void Unload()
        {
            if(Texture != null && !Texture.IsDisposed)
            {
                Texture.Dispose();
                Texture = null;
            }
        }

        /// <summary>
        ///     Disposes of the texture resource that is managed by this instance.
        /// </summary>
        public void Dispose()
        {
            if(Texture != null && !Texture.IsDisposed)
            {
                Texture.Dispose();
            }
        }

        /// <summary>
        ///     Given the top-left xy-coordinate and the width and height of a rectanglur boundry within this
        ///     <see cref="VirtualTexture2D"/>, creates and returns a new <see cref="VirtualTexture2D"/>
        ///     instance based on the boudnry area.
        /// </summary>
        /// <param name="x">
        ///     The top-left x-coordinate of the boundry area withn this <see cref="VirtualTexture2D"/>.
        /// </param>
        /// <param name="y">
        ///     The top-left y-coordinate of the boundry area within this <see cref="VirtualTexture2D"/>.
        /// </param>
        /// <param name="width">
        ///     The width of the boundry area within this <see cref="VirtualTexture2D"/>.
        /// </param>
        /// <param name="height">
        ///     The height of the boundry area within this <see cref="VirtualTexture2Dl"/>.
        /// </param>
        /// <param name="applyTo">
        ///     If provided, the new <see cref="VirtualTexture2D"/> instance that is created is instead
        ///     applied to this exisitng instance; otherwise a new instance is created.
        /// </param>
        /// <returns>
        ///     The <see cref="VirtualTexture2D"/> instance that represents the subtexture region of this
        ///     instance within the boundry given.
        /// </returns>
        public VirtualTexture2D GetSubTexture(int x, int y, int width, int height, VirtualTexture2D applyTo = null)
        {
            if(applyTo == null)
            {
                return new VirtualTexture2D(this, x, y, width, height);
            }

            applyTo.Texture = Texture;
            applyTo.ClipRect = GetRelativeRect(x, y, width, height);
            applyTo.DrawOffset = new Vector2(-Math.Min(x - DrawOffset.X, 0), -Math.Min(y - DrawOffset.Y, 0));
            applyTo.Width = width;
            applyTo.Height = height;

            return applyTo;
        }

        /// <summary>
        ///     Given the top-left xy-coordinate location, and the size of a rectanglur boundry within this
        ///     <see cref="VirtualTexture2D"/>, creates a nd returns a new <see cref="VirtualTexture2D"/>
        ///     instances based on the boundry area.
        /// </summary>
        /// <param name="location">
        ///     The top-left xy-coordinate location of the boundry within this <see cref="VirtualTexture2D"/>.
        /// </param>
        /// <param name="size">
        ///     The width and height of the boundry within this <see cref="VirtualTexture2D"/>.
        /// </param>
        /// <param name="applyTo">
        ///     If provieded, the new <see cref="VirtualTexture2D"/> instance that is created is instead
        ///     applied to this existing instance; otherwise a new instance is created.
        /// </param>
        /// <returns>
        ///     The <see cref="VirtualTexture2D"/> instance that represents the subtexture region of this
        ///     instance within the boundry given.
        /// </returns>
        public VirtualTexture2D GetSubTexture(Point location, Size size, VirtualTexture2D applyTo = null)
        {
            return GetSubTexture(location.X, location.Y, size.Width, size.Height, applyTo);
        }

        /// <summary>
        ///     Given the rectangluar boundry within this <see cref="VirtualTexture2D"/>, creates and returns a 
        ///     new <see cref="VirtualTexture2D"/> instance based on the boundry area.
        /// </summary>
        /// <param name="boundry">
        ///     The rectangluar boundy within this <see cref="VirtualTexture2D"/>.
        /// </param>
        /// <param name="applyTo">
        ///     If provided, the new <see cref="VirtualTexture2D"/> instance that is created is instead
        ///     applied to this existing instance; otherwise a new instance is created.
        /// </param>
        /// <returns>
        ///     The <see cref="VirtualTexture2D"/> instance that represents the subtexture region of this
        ///     instance within the boundry given.
        /// </returns>
        public VirtualTexture2D GetSubTexture(Rectangle boundry, VirtualTexture2D applyTo = null)
        {
            return GetSubTexture(boundry.X, boundry.Y, boundry.Width, boundry.Height, applyTo);
        }

        public Rectangle GetRelativeRect(Rectangle rect)
        {
            return GetRelativeRect(rect.X, rect.Y, rect.Width, rect.Height);
        }

        public Rectangle GetRelativeRect(Point location, Size size)
        {
            return GetRelativeRect(location.X, location.Y, size.Width, size.Height);
        }

        public Rectangle GetRelativeRect(int x, int y, int width, int height)
        {
            int atX = (int)(ClipRect.X - DrawOffset.X + x);
            int atY = (int)(ClipRect.Y - DrawOffset.Y + y);

            int rX = (int)MathHelper.Clamp(atX, ClipRect.Left, ClipRect.Right);
            int rY = (int)MathHelper.Clamp(atY, ClipRect.Top, ClipRect.Bottom);
            int rW = Math.Max(0, Math.Min(atX + width, ClipRect.Right) - rX);
            int rH = Math.Max(0, Math.Min(atY + height, ClipRect.Bottom) - rY);

            return new Rectangle(rX, rY, rW, rH);
        }

        public static VirtualTexture2D FromContent(string contentPath)
        {
            return new VirtualTexture2D(Engine.Instance.Content.Load<Texture2D>(contentPath));
        }

        public static implicit operator bool(VirtualTexture2D obj)
        {
            return obj != null;
        }



    }
}
