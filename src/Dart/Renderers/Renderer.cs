using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Dart.Renderers
{
    public class Renderer
    {
        public Camera2D Camera { get; set; }

        /// <summary>
        ///     Creates a new Renderer whos camera's viewport has the given dimensions.
        /// </summary>
        /// <param name="x">
        ///     The x-coordinate position of the viewport of the renderer's camera.
        /// </param>
        /// <param name="y">
        ///     THe y-coordinate position of the viewport of the renderer's camera.
        /// </param>
        /// <param name="width">
        ///     The width of the viewport of the renderer's camera.
        /// </param>
        /// <param name="height">
        ///     The height of the viewport of the renderer's camera.
        /// </param>
        /// <param name="minDepth">
        ///     The minimum depth of the viewport of the renderer's camera.
        /// </param>
        /// <param name="maxdepth">
        ///     The maximum depth of the viewport of the renderer's camer.
        /// </param>
        public Renderer(int x, int y, int width, int height, int minDepth, int maxDepth)
        : this(new Viewport(x, y, width, height, minDepth, maxDepth)) { }

        /// <summary>
        ///     Creates a new Renderer whos camera's viewport has the given dimensions, a 
        ///     minimum depth of 0.0, and a maximum depth of 1.0.
        /// </summary>
        /// <param name="x">
        ///     The x-coordinate position of the viewport of the renderer's camera.
        /// </param>
        /// <param name="y">
        ///     THe y-coordinate position of the viewport of the renderer's camera.
        /// </param>
        /// <param name="width">
        ///     The width of the viewport of the renderer's camera.
        /// </param>
        /// <param name="height">
        ///     The height of the viewport of the renderer's camera.
        /// </param>
        public Renderer(int x, int y, int width, int height)
            : this(new Viewport(x, y, width, height, 0.0f, 1.0f)) { }

        /// <summary>
        ///     Creates a new Renderer whos camera's viewport has the given dimensions.
        /// </summary>
        /// <param name="location">
        ///     The top-left xy-coordinate position of the viewport of the renderer's camera.
        /// </param>
        /// <param name="size">
        ///     The width and height of the viewport of the renderer's camera.
        /// </param>
        /// <param name="minDepth">
        ///     The minimum depth of the viewport of the renderer's camera.
        /// </param>
        /// <param name="maxDepth">
        ///     The maximum depth of the viewport of the renderer's camear.
        /// </param>
        public Renderer(Point location, Size size, float minDepth, float maxDepth)
            : this(new Viewport(location.X, location.Y, size.Width, size.Height, minDepth, maxDepth)) { }

        /// <summary>
        ///     Creates a new Renderer whos camera's viewport has the given dimensions, a 
        ///     minimum depth of 0.0, and a maximum depth of 1.0.
        /// </summary>
        /// <param name="location">
        ///     The top-left xy-coordinate position of the viewport of the renderer's camera.
        /// </param>
        /// <param name="size">
        ///     The width and height of the viewport of the renderer's camera.
        /// </param>
        public Renderer(Point location, Size size)
            : this(new Viewport(location.X, location.Y, size.Width, size.Height, 0.0f, 1.0f)) { }

        /// <summary>
        ///     Creates a new Renderer whos camera's viewport has the given dimensions.
        /// </summary>
        /// <param name="viewport">
        ///     The viewport to use for the renderer's camera.
        /// </param>
        public Renderer(Viewport viewport)
        {
            Camera = new Camera2D(viewport);
        }

        /// <summary>
        ///     Creates a new Renderer whos camera's viewport has the given dimensions.
        /// </summary>
        /// <param name="boundry">
        ///     A rectangular boundry that describes the viewport's top-left xy-coordinate location
        ///     and widht and height.
        /// </param>
        /// <param name="minDepth">
        ///     THe minimum depth of the viewport of the renderer's camera.
        /// </param>
        /// <param name="maxDepth">
        ///     THe maximum depth of the viewport of the renderer's camera.
        /// </param>
        public Renderer(Rectangle boundry, float minDepth, float maxDepth)
        {
            Viewport viewPort = new Viewport(boundry);
            viewPort.MinDepth = minDepth;
            viewPort.MaxDepth = maxDepth;
            Camera = new Camera2D(viewPort);
        }

        /// <summary>
        ///     Creates a new Renderer whos camera's viewport has the given dimensions, a 
        ///     minimum depth of 0.0, and a maximum depth of 1.0.
        /// </summary>
        /// <param name="boundry">
        ///     A rectangular boundry that describes the viewport's top-left xy-coordinate location
        ///     and widht and height.
        /// </param>
        public Renderer(Rectangle boundry) : this(boundry, 0.0f, 1.0f) { }


        public void Render(SpriteBatch spriteBatch)
        {

        }





    }
}
