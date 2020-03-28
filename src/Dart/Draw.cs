using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Dart
{
    public static class Draw
    {
        //  A reusuable rectangle instance.
        private static Microsoft.Xna.Framework.Rectangle _rect = Microsoft.Xna.Framework.Rectangle.Empty;

        //  The spritebatch instnace used for rendering
        public static SpriteBatch SpriteBatch { get; private set; }

        /// <summary>
        ///     A reusuabled 1x1 white pixel texture.
        /// </summary>
        public static VirtualTexture2D Pixel { get; private set; }

        /// <summary>
        ///     Initializes this.
        /// </summary>
        /// <param name="graphicsDevice">
        ///     The Graphics device, which will be used for sprite rendering.
        /// </param>
        public static void Initialize(GraphicsDevice graphicsDevice)
        {
            SpriteBatch = new SpriteBatch(graphicsDevice);
            Pixel = new VirtualTexture2D(1, 1, Color.White);
        }


        #region Point

        /// <summary>
        ///     Draws a single pixel.
        /// </summary>
        /// <param name="x">
        ///     The x-coordinate location of the pixel.
        /// </param>
        /// <param name="y">
        ///     The y-coordinate location of the pixel.
        /// </param>
        public static void Point(float x, float y) => Point(new Vector2(x, y), Color.White);


        /// <summary>
        ///     Draws a single pixel.
        /// </summary>
        /// <param name="x">
        ///     The x-coordinate location of the pixel.
        /// </param>
        /// <param name="y">
        ///     The y-coordinate location of the pixel.
        /// </param>
        /// <param name="color">
        ///     The color of the pixel.
        /// </param>
        public static void Point(float x, float y, Color color) => Point(new Vector2(x, y), color);


        /// <summary>
        ///     Draws a single pixel.
        /// </summary>
        /// <param name="position">
        ///     The xy-coordinate location of the pixel.
        /// </param>
        public static void Point(Vector2 position) => Point(position, Color.White);


        /// <summary>
        ///     Draws a single pixel.
        /// </summary>
        /// <param name="position">
        ///     The xy-coordinate location of the pixel.
        /// </param>
        /// <param name="color">
        ///     The color of the pixel.
        /// </param>
        public static void Point(Vector2 position, Color color) =>
            SpriteBatch.Draw(Pixel.Texture, position, color);

        #endregion Point

        #region Connected Points

        /// <summary>
        ///     Draws a series of connected points.
        /// </summary>
        /// <param name="points">
        ///     The points to connect.
        /// </param>
        public static void ConnectedPoints(Vector2[] points) =>
            ConnectedPoints(points, Color.White, 1.0f);

        /// <summary>
        ///     Draws a series of connected points.
        /// </summary>
        /// <param name="points">
        ///     The points to connect.
        /// </param>
        /// <param name="color">
        ///     The color value to use when rendering.
        /// </param>
        public static void ConnectedPoints(Vector2[] points, Color color) =>
            ConnectedPoints(points, color, 1.0f);


        /// <summary>
        ///     Draws a series of connected points.
        /// </summary>
        /// <param name="points">
        ///     The points to connect.
        /// </param>
        /// <param name="color">
        ///     The color value to use when rendering.
        /// </param>
        /// <param name="thickness">
        ///     The thickness of the lines connecting the points.
        /// </param>
        public static void ConnectedPoints(Vector2[] points, Color color, float thickness)
        {
            if (points == null || points.Length < 2) { return; }

            for (int i = 1; i < points.Length; i++)
            {
                Line(points[i - 1], points[i], color, thickness);
            }
        }

        /// <summary>
        ///     Draws a series of connected points.
        /// </summary>
        /// <param name="points">
        ///     The points to connect.
        /// </param>
        public static void ConnectedPoints(List<Vector2> points) =>
           ConnectedPoints(points, Color.White, 1.0f);

        /// <summary>
        ///     Draws a series of connected points.
        /// </summary>
        /// <param name="points">
        ///     The points to connect.
        /// </param>
        /// <param name="color">
        ///     The color value to use when rendering.
        /// </param>
        public static void ConnectedPoints(List<Vector2> points, Color color) =>
            ConnectedPoints(points, color, 1.0f);


        /// <summary>
        ///     Draws a series of connected points.
        /// </summary>
        /// <param name="points">
        ///     The points to connect.
        /// </param>
        /// <param name="color">
        ///     The color value to use when rendering.
        /// </param>
        /// <param name="thickness">
        ///     The thickness of the lines connecting the points.
        /// </param>
        public static void ConnectedPoints(List<Vector2> points, Color color, float thickness)
        {
            if (points == null || points.Count < 2) { return; }

            for (int i = 1; i < points.Count; i++)
            {
                Line(points[i - 1], points[i], color, thickness);
            }
        }

        #endregion Connected Points

        #region Line

        /// <summary>
        ///     Draws a line.
        /// </summary>
        /// <param name="x1">
        ///     The starting x-coordinate point of the line.
        /// </param>
        /// <param name="y1">
        ///     The starting y-coordinate point of the line.
        /// </param>
        /// <param name="x2">
        ///     The ending x-coordiante point of the line.
        /// </param>
        /// <param name="y2">
        ///     The ending y-coordinate point of the line.
        /// </param>
        public static void Line(float x1, float y1, float x2, float y2)
        {
            Line(new Vector2(x1, y1), new Vector2(x2, y2), Color.White, 1.0f);
        }

        /// <summary>
        ///     Draws a line.
        /// </summary>
        /// <param name="x1">
        ///     The starting x-coordinate point of the line.
        /// </param>
        /// <param name="y1">
        ///     The starting y-coordinate point of the line.
        /// </param>
        /// <param name="x2">
        ///     The ending x-coordiante point of the line.
        /// </param>
        /// <param name="y2">
        ///     The ending y-coordinate point of the line.
        /// </param>
        /// <param name="color">
        ///     The color value to use when rendring the line.
        /// </param>
        public static void Line(float x1, float y1, float x2, float y2, Color color)
        {
            Line(new Vector2(x1, y1), new Vector2(x2, y2), color, 1.0f);
        }

        /// <summary>
        ///     Draws a line.
        /// </summary>
        /// <param name="x1">
        ///     The starting x-coordinate point of the line.
        /// </param>
        /// <param name="y1">
        ///     The starting y-coordinate point of the line.
        /// </param>
        /// <param name="x2">
        ///     The ending x-coordiante point of the line.
        /// </param>
        /// <param name="y2">
        ///     The ending y-coordinate point of the line.
        /// </param>
        /// <param name="color">
        ///     The color value to use when rendring the line.
        /// </param>
        /// <param name="thickness">
        ///     The thickness of the line.
        /// </param>
        public static void Line(float x1, float y1, float x2, float y2, Color color, float thickness)
        {
            Line(new Vector2(x1, y1), new Vector2(x2, y2), color, thickness);
        }

        /// <summary>
        ///     Draws a line.
        /// </summary>
        /// <param name="pointA">
        ///     The starting xy-coordinate point of the line.
        /// </param>
        /// <param name="pointB">
        ///     The ending xy-coordinate point of the line.
        /// </param>
        public static void Line(Vector2 pointA, Vector2 pointB)
        {
            Line(pointA, pointB, Color.White, 1.0f);
        }

        /// <summary>
        ///     Draws a line.
        /// </summary>
        /// <param name="pointA">
        ///     The starting xy-coordinate point of the line.
        /// </param>
        /// <param name="pointB">
        ///     The ending xy-coordinate point of the line.
        /// </param>
        /// <param name="color">
        ///     The color value to use when rendering the line.
        /// </param>
        public static void Line(Vector2 pointA, Vector2 pointB, Color color)
        {
            Line(pointA, pointB, color, 1.0f);
        }

        /// <summary>
        ///     Draws a line.
        /// </summary>
        /// <param name="pointA">
        ///     The starting xy-coordinate point of the line.
        /// </param>
        /// <param name="pointB">
        ///     The ending xy-coordinate point of the line.
        /// </param>
        /// <param name="color">
        ///     The color value to use when rendering the line.
        /// </param>
        /// <param name="thickness">
        ///     The thickness of the line.
        /// </param>
        public static void Line(Vector2 pointA, Vector2 pointB, Color color, float thickness)
        {
            //  Calculate the distance between the two vectors
            float distance = Vector2.Distance(pointA, pointB);

            // Calculate the angle between the two vectors
            float angle = (float)Math.Atan2(pointB.Y - pointA.Y, pointB.X - pointA.X);

            Line(pointA, distance, angle, color, thickness);
        }

        /// <summary>
        ///     Draws a line.
        /// </summary>
        /// <param name="point">
        ///     The starting xy-coordinate point of the line
        /// </param>
        /// <param name="length">
        ///     The length of the line in pixels.
        /// </param>
        /// <param name="angle">
        ///     The angle of the line.
        /// </param>
        /// <param name="color">
        ///     The color value to render the line at.
        /// </param>
        public static void Line(Vector2 point, float length, float angle, Color color)
        {
            Line(point, length, angle, color, 1.0f);
        }

        /// <summary>
        ///     Draws a line.
        /// </summary>
        /// <param name="point">
        ///     The starting xy-coordinate point of the line
        /// </param>
        /// <param name="length">
        ///     The length of the line in pixels.
        /// </param>
        /// <param name="angle">
        ///     The angle of the line.
        /// </param>
        /// <param name="color">
        ///     The color value to render the line at.
        /// </param>
        /// <param name="thickness">
        ///     The thickness of the line, in pixels.
        /// </param>
        public static void Line(Vector2 point, float length, float angle, Color color, float thickness)
        {
            SpriteBatch.Draw(texture: Pixel.Texture,
                              position: point,
                              sourceRectangle: null,
                              color: color,
                              rotation: angle,
                              origin: Vector2.Zero,
                              scale: new Vector2(length, thickness),
                              effects: SpriteEffects.None,
                              layerDepth: 0.0f);
        }

        #endregion Line

        #region Rectangle

        /// <summary>
        ///     Draws a rectangle.
        /// </summary>
        /// <param name="x">
        ///     The x-coordinate point of the top-left of the rectangle.
        /// </param>
        /// <param name="y">
        ///     The y-coordinate point of the top-left of the rectangle.
        /// </param>
        /// <param name="width">
        ///     The widht of the rectangle.
        /// </param>
        /// <param name="height">
        ///     The height of the rectangle.
        /// </param>
        /// <param name="color">
        ///     The color value to use when rendering.
        /// </param>    
        public static void Rectangle(int x, int y, int width, int height)
        {
            _rect.X = x;
            _rect.Y = y;
            _rect.Width = width;
            _rect.Height = height;

            Rectangle(_rect, Color.White, 1.0f);
        }

        /// <summary>
        ///     Draws a rectangle.
        /// </summary>
        /// <param name="x">
        ///     The x-coordinate point of the top-left of the rectangle.
        /// </param>
        /// <param name="y">
        ///     The y-coordinate point of the top-left of the rectangle.
        /// </param>
        /// <param name="width">
        ///     The widht of the rectangle.
        /// </param>
        /// <param name="height">
        ///     The height of the rectangle.
        /// </param>
        /// <param name="color">
        ///     The color value to use when rendering.
        /// </param>    
        public static void Rectangle(int x, int y, int width, int height, Color color)
        {
            _rect.X = x;
            _rect.Y = y;
            _rect.Width = width;
            _rect.Height = height;

            Rectangle(_rect, color, 1.0f);
        }

        /// <summary>
        ///     Draws a rectangle.
        /// </summary>
        /// <param name="x">
        ///     The x-coordinate point of the top-left of the rectangle.
        /// </param>
        /// <param name="y">
        ///     The y-coordinate point of the top-left of the rectangle.
        /// </param>
        /// <param name="width">
        ///     The widht of the rectangle.
        /// </param>
        /// <param name="height">
        ///     The height of the rectangle.
        /// </param>
        /// <param name="color">
        ///     The color value to use when rendering.
        /// </param>
        /// <param name="thickness">
        ///     The thickness of the rectangle.
        /// </param>
        public static void Rectangle(int x, int y, int width, int height, Color color, float thickness)
        {
            _rect.X = x;
            _rect.Y = y;
            _rect.Width = width;
            _rect.Height = height;

            Rectangle(_rect, color, thickness);
        }

        /// <summary>
        ///     Draws a rectangle.
        /// </summary>
        /// <param name="location">
        ///     The xy-coordinate point of the top-left of the rectangle.
        /// </param>
        /// <param name="size">
        ///     The size of the rectangle.
        /// </param>
        /// <param name="color">
        ///     The color value to use when rendering.
        /// </param>       
        public static void Rectangle(Microsoft.Xna.Framework.Point location, Size size)
        {
            Rectangle(location, size, Color.White, 1.0f);
        }

        /// <summary>
        ///     Draws a rectangle.
        /// </summary>
        /// <param name="location">
        ///     The xy-coordinate point of the top-left of the rectangle.
        /// </param>
        /// <param name="size">
        ///     The size of the rectangle.
        /// </param>
        /// <param name="color">
        ///     The color value to use when rendering.
        /// </param>       
        public static void Rectangle(Microsoft.Xna.Framework.Point location, Size size, Color color)
        {
            Rectangle(location, size, color, 1.0f);
        }

        /// <summary>
        ///     Draws a rectangle.
        /// </summary>
        /// <param name="location">
        ///     The xy-coordinate point of the top-left of the rectangle.
        /// </param>
        /// <param name="size">
        ///     The size of the rectangle.
        /// </param>
        /// <param name="color">
        ///     The color value to use when rendering.
        /// </param>
        /// <param name="thickness">
        ///     The thickness of the rectangle.
        /// </param>
        public static void Rectangle(Microsoft.Xna.Framework.Point location, Size size, Color color, float thickness)
        {
            _rect.X = location.X;
            _rect.Y = location.Y;
            _rect.Width = size.Width;
            _rect.Height = size.Height;

            Rectangle(_rect, color, thickness);
        }

        /// <summary>
        ///     Draws a rectangle.
        /// </summary>
        /// <param name="location">
        ///     The xy-coordinate point of the top-left of the rectangle.
        /// </param>
        /// <param name="size">
        ///     The size of the rectangle.
        /// </param>
        /// <param name="color">
        ///     The color value to use when rendering.
        /// </param>       
        public static void Rectangle(Vector2 location, Size size)
        {
            Rectangle(location, size, Color.White, 1.0f);
        }

        /// <summary>
        ///     Draws a rectangle.
        /// </summary>
        /// <param name="location">
        ///     The xy-coordinate point of the top-left of the rectangle.
        /// </param>
        /// <param name="size">
        ///     The size of the rectangle.
        /// </param>
        /// <param name="color">
        ///     The color value to use when rendering.
        /// </param>       
        public static void Rectangle(Vector2 location, Size size, Color color)
        {
            Rectangle(location, size, color, 1.0f);
        }

        /// <summary>
        ///     Draws a rectangle.
        /// </summary>
        /// <param name="location">
        ///     The xy-coordinate point of the top-left of the rectangle.
        /// </param>
        /// <param name="size">
        ///     The size of the rectangle.
        /// </param>
        /// <param name="color">
        ///     The color value to use when rendering.
        /// </param>
        /// <param name="thickness">
        ///     The thickness of the rectangle.
        /// </param>
        public static void Rectangle(Vector2 location, Size size, Color color, float thickness)
        {
            _rect.X = (int)location.X;
            _rect.Y = (int)location.Y;
            _rect.Width = size.Width;
            _rect.Height = size.Height;

            Rectangle(_rect, color, thickness);
        }

        /// <summary>
        ///     Draws a rectangle.
        /// </summary>
        /// <param name="rectangle">
        ///     A Rectangle intance that describes the boundry of the rectangle to render.
        /// </param>
        /// <param name="color">
        ///     The color value to use when rendering.
        /// </param>
        public static void Rectangle(Microsoft.Xna.Framework.Rectangle rectangle)
        {
            Rectangle(rectangle, Color.White, 1.0f);
        }

        /// <summary>
        ///     Draws a rectangle.
        /// </summary>
        /// <param name="rectangle">
        ///     A Rectangle intance that describes the boundry of the rectangle to render.
        /// </param>
        /// <param name="color">
        ///     The color value to use when rendering.
        /// </param>
        public static void Rectangle(Microsoft.Xna.Framework.Rectangle rectangle, Color color)
        {
            Rectangle(rectangle, color, 1.0f);
        }

        /// <summary>
        ///     Draws a rectangle.
        /// </summary>
        /// <param name="rectangle">
        ///     A Rectangle intance that describes the boundry of the rectangle to render.
        /// </param>
        /// <param name="color">
        ///     The color value to use when rendering.
        /// </param>
        /// <param name="thickness">
        ///     The thickness of the rectangle.
        /// </param>
        public static void Rectangle(Microsoft.Xna.Framework.Rectangle rectangle, Color color, float thickness)
        {
            //  Top
            Line(new Vector2(rectangle.X, rectangle.Y), new Vector2(rectangle.Right, rectangle.Y), color, thickness);

            //  Left
            Line(new Vector2(rectangle.X + 1f, rectangle.Y), new Vector2(rectangle.X + 1f, rectangle.Bottom + thickness), color, thickness);

            //  Bottom
            Line(new Vector2(rectangle.X, rectangle.Bottom), new Vector2(rectangle.Right, rectangle.Bottom), color, thickness);

            //  Right
            Line(new Vector2(rectangle.Right + 1f, rectangle.Y), new Vector2(rectangle.Right + 1f, rectangle.Bottom + thickness), color, thickness);
        }




        #endregion Rectangle

        #region FilledRectangle

        /// <summary>
        ///     Draws a filled rectangle.
        /// </summary>
        /// <param name="x">
        ///     The x-coordinate location of the top-left of the rectangle.
        /// </param>
        /// <param name="y">
        ///     The y-coordinate location of the top-left of the rectangle.
        /// </param>
        /// <param name="width">
        ///     The width of the rectangle.
        /// </param>
        /// <param name="height">
        ///     The height of the rectangle.
        /// </param>
        public static void FilledRectangle(int x, int y, int width, int height)
        {
            FilledRectangle(x, y, width, height, Color.White);
        }

        /// <summary>
        ///     Draws a filled rectangle.
        /// </summary>
        /// <param name="x">
        ///     The x-coordinate location of the top-left of the rectangle.
        /// </param>
        /// <param name="y">
        ///     The y-coordinate location of the top-left of the rectangle.
        /// </param>
        /// <param name="width">
        ///     The width of the rectangle.
        /// </param>
        /// <param name="height">
        ///     The height of the rectangle.
        /// </param>
        /// <param name="color">
        ///     The color value to use when rendering.
        /// </param>
        public static void FilledRectangle(int x, int y, int width, int height, Color color)
        {
            _rect.X = x;
            _rect.Y = y;
            _rect.Width = width;
            _rect.Height = height;

            FilledRectangle(_rect, color);
        }

        /// <summary>
        ///     Draws a filled rectangle.
        /// </summary>
        /// <param name="location">
        ///     The xy-coordiante location fo the top-left of the rectangle.
        /// </param>
        /// <param name="size">
        ///     The size of the rectangle.
        /// </param>
        public static void FilledRectangle(Microsoft.Xna.Framework.Point location, Size size)
        {

            FilledRectangle(location, size, Color.White);
        }

        /// <summary>
        ///     Draws a filled rectangle.
        /// </summary>
        /// <param name="location">
        ///     The xy-coordiante location fo the top-left of the rectangle.
        /// </param>
        /// <param name="size">
        ///     The size of the rectangle.
        /// </param>
        /// <param name="color">
        ///     The color value to use when rendering.
        /// </param>
        public static void FilledRectangle(Microsoft.Xna.Framework.Point location, Size size, Color color)
        {
            _rect.X = location.X;
            _rect.Y = location.Y;
            _rect.Width = size.Width;
            _rect.Height = size.Height;

            FilledRectangle(_rect, color);
        }

        /// <summary>
        ///     Draws a filled rectangle.
        /// </summary>
        /// <param name="location">
        ///     The xy-coordiante location fo the top-left of the rectangle.
        /// </param>
        /// <param name="size">
        ///     The size of the rectangle.
        /// </param>
        public static void FilledRectangle(Vector2 location, Size size)
        {

            FilledRectangle(location, size, Color.White);
        }

        /// <summary>
        ///     Draws a filled rectangle.
        /// </summary>
        /// <param name="location">
        ///     The xy-coordiante location fo the top-left of the rectangle.
        /// </param>
        /// <param name="size">
        ///     The size of the rectangle.
        /// </param>
        /// <param name="color">
        ///     The color value to use when rendering.
        /// </param>
        public static void FilledRectangle(Vector2 location, Size size, Color color)
        {
            _rect.X = (int)location.X;
            _rect.Y = (int)location.Y;
            _rect.Width = size.Width;
            _rect.Height = size.Height;

            FilledRectangle(_rect, color);
        }

        /// <summary>
        ///     Draws a filled rectanle.
        /// </summary>
        /// <param name="rectangle">
        ///     A Rectangle instance whos boundry describes the rectangle to render.
        /// </param>
        public static void FilledRectangle(Microsoft.Xna.Framework.Rectangle rectangle)
        {
            SpriteBatch.Draw(Pixel.Texture, _rect, Pixel.ClipRect, Color.White);
        }

        /// <summary>
        ///     Draws a filled rectanle.
        /// </summary>
        /// <param name="rectangle">
        ///     A Rectangle instance whos boundry describes the rectangle to render.
        /// </param>
        /// <param name="color">
        ///     The color value to use when rendering.s
        /// </param>
        public static void FilledRectangle(Microsoft.Xna.Framework.Rectangle rectangle, Color color)
        {
            SpriteBatch.Draw(Pixel.Texture, _rect, Pixel.ClipRect, color);
        }

        #endregion FilledRectangle

        #region VirtualTexture2D

        public static void VirtualTexture2D(VirtualTexture2D vTexture, Vector2 position)
        {
            SpriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, Color.White, 0, -vTexture.DrawOffset, 1f, SpriteEffects.None, 0);
        }

        public static void VirtualTexture2D(VirtualTexture2D vTexture, Vector2 position, Color color)
        {
            SpriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, color, 0, -vTexture.DrawOffset, 1f, SpriteEffects.None, 0);
        }

        public static void VirtualTexture2D(VirtualTexture2D vTexture, Vector2 position, Vector2 origin)
        {
            SpriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, Color.White, 0, origin - vTexture.DrawOffset, 1f, SpriteEffects.None, 0);
        }

        public static void VirtualTexture2D(VirtualTexture2D vTexture, Vector2 position, Vector2 origin, Color color)
        {
            SpriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, color, 0, origin - vTexture.DrawOffset, 1f, SpriteEffects.None, 0);
        }

        public static void VirtualTexture2D(VirtualTexture2D vTexture, Vector2 position, Vector2 origin, Color color, float scale)
        {
            SpriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, color, 0, origin - vTexture.DrawOffset, scale, SpriteEffects.None, 0);
        }

        public static void VirtualTexture2D(VirtualTexture2D vTexture, Vector2 position, Vector2 origin, Color color, float scale, float rotation)
        {
            SpriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, color, rotation, origin - vTexture.DrawOffset, scale, SpriteEffects.None, 0);
        }

        public static void VirtualTexture2D(VirtualTexture2D vTexture, Vector2 position, Vector2 origin, Color color, float scale, float rotation, SpriteEffects flip)
        {
            SpriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, color, rotation, origin - vTexture.DrawOffset, scale, flip, 0);
        }

        public static void VirtualTexture2D(VirtualTexture2D vTexture, Vector2 position, Vector2 origin, Color color, Vector2 scale)
        {
            SpriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, color, 0, origin - vTexture.DrawOffset, scale, SpriteEffects.None, 0);
        }

        public static void VirtualTexture2D(VirtualTexture2D vTexture, Vector2 position, Vector2 origin, Color color, Vector2 scale, float rotation)
        {
            SpriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, color, rotation, origin - vTexture.DrawOffset, scale, SpriteEffects.None, 0);
        }

        public static void VirtualTexture2D(VirtualTexture2D vTexture, Vector2 position, Vector2 origin, Color color, Vector2 scale, float rotation, SpriteEffects flip)
        {
            SpriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, color, rotation, origin - vTexture.DrawOffset, scale, flip, 0);
        }

        public static void VirtualTexture2D(VirtualTexture2D vTexture, Vector2 position, Vector2 origin, Color color, Vector2 scale, float rotation, Microsoft.Xna.Framework.Rectangle clip)
        {
            SpriteBatch.Draw(vTexture.Texture, position, vTexture.GetRelativeRect(clip), color, rotation, origin - vTexture.DrawOffset, scale, SpriteEffects.None, 0);
        }

        #endregion VirtualTexture2D

        #region VirtualTexture2D Centered

        public static void VirtualTexture2DCentered(VirtualTexture2D vTexture, Vector2 position)
        {
            SpriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, Color.White, 0, vTexture.Center - vTexture.DrawOffset, 1f, SpriteEffects.None, 0);
        }

        public static void VirtualTexture2DCentered(VirtualTexture2D vTexture, Vector2 position, Color color)
        {
            SpriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, color, 0, vTexture.Center - vTexture.DrawOffset, 1f, SpriteEffects.None, 0);
        }

        public static void VirtualTexture2DCentered(VirtualTexture2D vTexture, Vector2 position, Color color, float scale)
        {
            SpriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, color, 0, vTexture.Center - vTexture.DrawOffset, scale, SpriteEffects.None, 0);
        }

        public static void VirtualTexture2DCentered(VirtualTexture2D vTexture, Vector2 position, Color color, float scale, float rotation)
        {
            SpriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, color, rotation, vTexture.Center - vTexture.DrawOffset, scale, SpriteEffects.None, 0);
        }

        public static void VirtualTexture2DCentered(VirtualTexture2D vTexture, Vector2 position, Color color, float scale, float rotation, SpriteEffects flip)
        {
            SpriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, color, rotation, vTexture.Center - vTexture.DrawOffset, scale, flip, 0);
        }

        public static void VirtualTexture2DCentered(VirtualTexture2D vTexture, Vector2 position, Color color, Vector2 scale)
        {
            SpriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, color, 0, vTexture.Center - vTexture.DrawOffset, scale, SpriteEffects.None, 0);
        }

        public static void VirtualTexture2DCentered(VirtualTexture2D vTexture, Vector2 position, Color color, Vector2 scale, float rotation)
        {
            SpriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, color, rotation, vTexture.Center - vTexture.DrawOffset, scale, SpriteEffects.None, 0);
        }

        public static void VirtualTexture2DCentered(VirtualTexture2D vTexture, Vector2 position, Color color, Vector2 scale, float rotation, SpriteEffects flip)
        {
            SpriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, color, rotation, vTexture.Center - vTexture.DrawOffset, scale, flip, 0);
        }

        #endregion VirtualTexture2D Centered

        #region VirtualTexture2D Justified

        public static void VirtualTexture2DJustified(VirtualTexture2D vTexture, Vector2 position, Vector2 justify)
        {
            SpriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, Color.White, 0, new Vector2(vTexture.Width * justify.X, vTexture.Height * justify.Y) - vTexture.DrawOffset, 1f, SpriteEffects.None, 0);
        }

        public static void VirtualTexture2DJustified(VirtualTexture2D vTexture, Vector2 position, Vector2 justify, Color color)
        {
            SpriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, color, 0, new Vector2(vTexture.Width * justify.X, vTexture.Height * justify.Y) - vTexture.DrawOffset, 1f, SpriteEffects.None, 0);
        }

        public static void VirtualTexture2DJustified(VirtualTexture2D vTexture, Vector2 position, Vector2 justify, Color color, float scale)
        {
            SpriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, color, 0, new Vector2(vTexture.Width * justify.X, vTexture.Height * justify.Y) - vTexture.DrawOffset, scale, SpriteEffects.None, 0);
        }

        public static void VirtualTexture2DJustified(VirtualTexture2D vTexture, Vector2 position, Vector2 justify, Color color, float scale, float rotation)
        {
            SpriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, color, rotation, new Vector2(vTexture.Width * justify.X, vTexture.Height * justify.Y) - vTexture.DrawOffset, scale, SpriteEffects.None, 0);
        }

        public static void VirtualTexture2DJustified(VirtualTexture2D vTexture, Vector2 position, Vector2 justify, Color color, float scale, float rotation, SpriteEffects flip)
        {
            SpriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, color, rotation, new Vector2(vTexture.Width * justify.X, vTexture.Height * justify.Y) - vTexture.DrawOffset, scale, flip, 0);
        }

        public static void VirtualTexture2DJustified(VirtualTexture2D vTexture, Vector2 position, Vector2 justify, Color color, Vector2 scale)
        {
            SpriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, color, 0, new Vector2(vTexture.Width * justify.X, vTexture.Height * justify.Y) - vTexture.DrawOffset, scale, SpriteEffects.None, 0);
        }

        public static void VirtualTexture2DJustified(VirtualTexture2D vTexture, Vector2 position, Vector2 justify, Color color, Vector2 scale, float rotation)
        {
            SpriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, color, rotation, new Vector2(vTexture.Width * justify.X, vTexture.Height * justify.Y) - vTexture.DrawOffset, scale, SpriteEffects.None, 0);
        }

        public static void VirtualTexture2DJustified(VirtualTexture2D vTexture, Vector2 position, Vector2 justify, Color color, Vector2 scale, float rotation, SpriteEffects flip)
        {
            SpriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, color, rotation, new Vector2(vTexture.Width * justify.X, vTexture.Height * justify.Y) - vTexture.DrawOffset, scale, flip, 0);
        }

        #endregion VirtualTexture2D Justified

        #region VirtualTexture2D Outlined

        public static void VirtualTexture2DOutlined(VirtualTexture2D vTexture, Vector2 position)
        {
            for (var i = -1; i <= 1; i++)
                for (var j = -1; j <= 1; j++)
                    if (i != 0 || j != 0)
                        SpriteBatch.Draw(vTexture.Texture, position + new Vector2(i, j), vTexture.ClipRect, Color.Black, 0, -vTexture.DrawOffset, 1f, SpriteEffects.None, 0);

            SpriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, Color.White, 0, -vTexture.DrawOffset, 1f, SpriteEffects.None, 0);
        }

        public static void VirtualTexture2DOutlined(VirtualTexture2D vTexture, Vector2 position, Vector2 origin)
        {
            for (var i = -1; i <= 1; i++)
                for (var j = -1; j <= 1; j++)
                    if (i != 0 || j != 0)
                        SpriteBatch.Draw(vTexture.Texture, position + new Vector2(i, j), vTexture.ClipRect, Color.Black, 0, origin - vTexture.DrawOffset, 1f, SpriteEffects.None, 0);

            SpriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, Color.White, 0, origin - vTexture.DrawOffset, 1f, SpriteEffects.None, 0);
        }

        public static void VirtualTexture2DOutlined(VirtualTexture2D vTexture, Vector2 position, Vector2 origin, Color color)
        {
            for (var i = -1; i <= 1; i++)
                for (var j = -1; j <= 1; j++)
                    if (i != 0 || j != 0)
                        SpriteBatch.Draw(vTexture.Texture, position + new Vector2(i, j), vTexture.ClipRect, Color.Black, 0, origin - vTexture.DrawOffset, 1f, SpriteEffects.None, 0);

            SpriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, color, 0, origin - vTexture.DrawOffset, 1f, SpriteEffects.None, 0);
        }

        public static void VirtualTexture2DOutlined(VirtualTexture2D vTexture, Vector2 position, Vector2 origin, Color color, float scale)
        {
            for (var i = -1; i <= 1; i++)
                for (var j = -1; j <= 1; j++)
                    if (i != 0 || j != 0)
                        SpriteBatch.Draw(vTexture.Texture, position + new Vector2(i, j), vTexture.ClipRect, Color.Black, 0, origin - vTexture.DrawOffset, scale, SpriteEffects.None, 0);

            SpriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, color, 0, origin - vTexture.DrawOffset, scale, SpriteEffects.None, 0);
        }

        public static void VirtualTexture2DOutlined(VirtualTexture2D vTexture, Vector2 position, Vector2 origin, Color color, float scale, float rotation)
        {
            for (var i = -1; i <= 1; i++)
                for (var j = -1; j <= 1; j++)
                    if (i != 0 || j != 0)
                        SpriteBatch.Draw(vTexture.Texture, position + new Vector2(i, j), vTexture.ClipRect, Color.Black, rotation, origin - vTexture.DrawOffset, scale, SpriteEffects.None, 0);

            SpriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, color, rotation, origin - vTexture.DrawOffset, scale, SpriteEffects.None, 0);
        }

        public static void VirtualTexture2DOutlined(VirtualTexture2D vTexture, Vector2 position, Vector2 origin, Color color, float scale, float rotation, SpriteEffects flip)
        {
            for (var i = -1; i <= 1; i++)
                for (var j = -1; j <= 1; j++)
                    if (i != 0 || j != 0)
                        SpriteBatch.Draw(vTexture.Texture, position + new Vector2(i, j), vTexture.ClipRect, Color.Black, rotation, origin - vTexture.DrawOffset, scale, flip, 0);

            SpriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, color, rotation, origin - vTexture.DrawOffset, scale, flip, 0);
        }

        public static void VirtualTexture2DOutlined(VirtualTexture2D vTexture, Vector2 position, Vector2 origin, Color color, Vector2 scale)
        {
            for (var i = -1; i <= 1; i++)
                for (var j = -1; j <= 1; j++)
                    if (i != 0 || j != 0)
                        SpriteBatch.Draw(vTexture.Texture, position + new Vector2(i, j), vTexture.ClipRect, Color.Black, 0, origin - vTexture.DrawOffset, scale, SpriteEffects.None, 0);

            SpriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, color, 0, origin - vTexture.DrawOffset, scale, SpriteEffects.None, 0);
        }

        public static void VirtualTexture2DOutlined(VirtualTexture2D vTexture, Vector2 position, Vector2 origin, Color color, Vector2 scale, float rotation)
        {
            for (var i = -1; i <= 1; i++)
                for (var j = -1; j <= 1; j++)
                    if (i != 0 || j != 0)
                        SpriteBatch.Draw(vTexture.Texture, position + new Vector2(i, j), vTexture.ClipRect, Color.Black, rotation, origin - vTexture.DrawOffset, scale, SpriteEffects.None, 0);

            SpriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, color, rotation, origin - vTexture.DrawOffset, scale, SpriteEffects.None, 0);
        }

        public static void VirtualTexture2DOutlined(VirtualTexture2D vTexture, Vector2 position, Vector2 origin, Color color, Vector2 scale, float rotation, SpriteEffects flip)
        {
            for (var i = -1; i <= 1; i++)
                for (var j = -1; j <= 1; j++)
                    if (i != 0 || j != 0)
                        SpriteBatch.Draw(vTexture.Texture, position + new Vector2(i, j), vTexture.ClipRect, Color.Black, rotation, origin - vTexture.DrawOffset, scale, flip, 0);

            SpriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, color, rotation, origin - vTexture.DrawOffset, scale, flip, 0);
        }

        #endregion VirtualTexture2D Outlined

        #region VirtualTexture2D Outlined Centered

        public static void VirtualTexture2DOutlinedCentered(VirtualTexture2D vTexture, Vector2 position)
        {
            for (var i = -1; i <= 1; i++)
                for (var j = -1; j <= 1; j++)
                    if (i != 0 || j != 0)
                        SpriteBatch.Draw(vTexture.Texture, position + new Vector2(i, j), vTexture.ClipRect, Color.Black, 0, vTexture.Center - vTexture.DrawOffset, 1f, SpriteEffects.None, 0);

            SpriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, Color.White, 0, vTexture.Center - vTexture.DrawOffset, 1f, SpriteEffects.None, 0);
        }

        public static void VirtualTexture2DOutlinedCentered(VirtualTexture2D vTexture, Vector2 position, Color color)
        {
            for (var i = -1; i <= 1; i++)
                for (var j = -1; j <= 1; j++)
                    if (i != 0 || j != 0)
                        SpriteBatch.Draw(vTexture.Texture, position + new Vector2(i, j), vTexture.ClipRect, Color.Black, 0, vTexture.Center - vTexture.DrawOffset, 1f, SpriteEffects.None, 0);

            SpriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, color, 0, vTexture.Center - vTexture.DrawOffset, 1f, SpriteEffects.None, 0);
        }

        public static void VirtualTexture2DOutlinedCentered(VirtualTexture2D vTexture, Vector2 position, Color color, float scale)
        {
            for (var i = -1; i <= 1; i++)
                for (var j = -1; j <= 1; j++)
                    if (i != 0 || j != 0)
                        SpriteBatch.Draw(vTexture.Texture, position + new Vector2(i, j), vTexture.ClipRect, Color.Black, 0, vTexture.Center - vTexture.DrawOffset, scale, SpriteEffects.None, 0);

            SpriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, color, 0, vTexture.Center - vTexture.DrawOffset, scale, SpriteEffects.None, 0);
        }

        public static void VirtualTexture2DOutlinedCentered(VirtualTexture2D vTexture, Vector2 position, Color color, float scale, float rotation)
        {
            for (var i = -1; i <= 1; i++)
                for (var j = -1; j <= 1; j++)
                    if (i != 0 || j != 0)
                        SpriteBatch.Draw(vTexture.Texture, position + new Vector2(i, j), vTexture.ClipRect, Color.Black, rotation, vTexture.Center - vTexture.DrawOffset, scale, SpriteEffects.None, 0);

            SpriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, color, rotation, vTexture.Center - vTexture.DrawOffset, scale, SpriteEffects.None, 0);
        }

        public static void VirtualTexture2DOutlinedCentered(VirtualTexture2D vTexture, Vector2 position, Color color, float scale, float rotation, SpriteEffects flip)
        {
            for (var i = -1; i <= 1; i++)
                for (var j = -1; j <= 1; j++)
                    if (i != 0 || j != 0)
                        SpriteBatch.Draw(vTexture.Texture, position + new Vector2(i, j), vTexture.ClipRect, Color.Black, rotation, vTexture.Center - vTexture.DrawOffset, scale, flip, 0);

            SpriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, color, rotation, vTexture.Center - vTexture.DrawOffset, scale, flip, 0);
        }

        public static void VirtualTexture2DOutlinedCentered(VirtualTexture2D vTexture, Vector2 position, Color color, Vector2 scale)
        {
            for (var i = -1; i <= 1; i++)
                for (var j = -1; j <= 1; j++)
                    if (i != 0 || j != 0)
                        SpriteBatch.Draw(vTexture.Texture, position + new Vector2(i, j), vTexture.ClipRect, Color.Black, 0, vTexture.Center - vTexture.DrawOffset, scale, SpriteEffects.None, 0);

            SpriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, color, 0, vTexture.Center - vTexture.DrawOffset, scale, SpriteEffects.None, 0);
        }

        public static void VirtualTexture2DOutlinedCentered(VirtualTexture2D vTexture, Vector2 position, Color color, Vector2 scale, float rotation)
        {
            for (var i = -1; i <= 1; i++)
                for (var j = -1; j <= 1; j++)
                    if (i != 0 || j != 0)
                        SpriteBatch.Draw(vTexture.Texture, position + new Vector2(i, j), vTexture.ClipRect, Color.Black, rotation, vTexture.Center - vTexture.DrawOffset, scale, SpriteEffects.None, 0);

            SpriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, color, rotation, vTexture.Center - vTexture.DrawOffset, scale, SpriteEffects.None, 0);
        }

        public static void VirtualTexture2DOutlinedCentered(VirtualTexture2D vTexture, Vector2 position, Color color, Vector2 scale, float rotation, SpriteEffects flip)
        {
            for (var i = -1; i <= 1; i++)
                for (var j = -1; j <= 1; j++)
                    if (i != 0 || j != 0)
                        SpriteBatch.Draw(vTexture.Texture, position + new Vector2(i, j), vTexture.ClipRect, Color.Black, rotation, vTexture.Center - vTexture.DrawOffset, scale, flip, 0);

            SpriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, color, rotation, vTexture.Center - vTexture.DrawOffset, scale, flip, 0);
        }

        #endregion VirtualTexture2D Outlined Centered

        #region VirtualTexture2D Outlined Justified

        public static void VirtualTexture2DOutlinedJustified(VirtualTexture2D vTexture, Vector2 position, Vector2 justify)
        {
            for (var i = -1; i <= 1; i++)
                for (var j = -1; j <= 1; j++)
                    if (i != 0 || j != 0)
                        SpriteBatch.Draw(vTexture.Texture, position + new Vector2(i, j), vTexture.ClipRect, Color.Black, 0, new Vector2(vTexture.Width * justify.X, vTexture.Height * justify.Y) - vTexture.DrawOffset, 1f, SpriteEffects.None, 0);

            SpriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, Color.White, 0, new Vector2(vTexture.Width * justify.X, vTexture.Height * justify.Y) - vTexture.DrawOffset, 1f, SpriteEffects.None, 0);
        }

        public static void VirtualTexture2DOutlinedJustified(VirtualTexture2D vTexture, Vector2 position, Vector2 justify, Color color)
        {
            for (var i = -1; i <= 1; i++)
                for (var j = -1; j <= 1; j++)
                    if (i != 0 || j != 0)
                        SpriteBatch.Draw(vTexture.Texture, position + new Vector2(i, j), vTexture.ClipRect, Color.Black, 0, new Vector2(vTexture.Width * justify.X, vTexture.Height * justify.Y) - vTexture.DrawOffset, 1f, SpriteEffects.None, 0);

            SpriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, color, 0, new Vector2(vTexture.Width * justify.X, vTexture.Height * justify.Y) - vTexture.DrawOffset, 1f, SpriteEffects.None, 0);
        }

        public static void VirtualTexture2DOutlinedJustified(VirtualTexture2D vTexture, Vector2 position, Vector2 justify, Color color, float scale)
        {
            for (var i = -1; i <= 1; i++)
                for (var j = -1; j <= 1; j++)
                    if (i != 0 || j != 0)
                        SpriteBatch.Draw(vTexture.Texture, position + new Vector2(i, j), vTexture.ClipRect, Color.Black, 0, new Vector2(vTexture.Width * justify.X, vTexture.Height * justify.Y) - vTexture.DrawOffset, scale, SpriteEffects.None, 0);

            SpriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, color, 0, new Vector2(vTexture.Width * justify.X, vTexture.Height * justify.Y) - vTexture.DrawOffset, scale, SpriteEffects.None, 0);
        }

        public static void VirtualTexture2DOutlinedJustified(VirtualTexture2D vTexture, Vector2 position, Vector2 justify, Color color, float scale, float rotation)
        {
            for (var i = -1; i <= 1; i++)
                for (var j = -1; j <= 1; j++)
                    if (i != 0 || j != 0)
                        SpriteBatch.Draw(vTexture.Texture, position + new Vector2(i, j), vTexture.ClipRect, Color.Black, rotation, new Vector2(vTexture.Width * justify.X, vTexture.Height * justify.Y) - vTexture.DrawOffset, scale, SpriteEffects.None, 0);

            SpriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, color, rotation, new Vector2(vTexture.Width * justify.X, vTexture.Height * justify.Y) - vTexture.DrawOffset, scale, SpriteEffects.None, 0);
        }

        public static void VirtualTexture2DOutlinedJustified(VirtualTexture2D vTexture, Vector2 position, Vector2 justify, Color color, float scale, float rotation, SpriteEffects flip)
        {
            for (var i = -1; i <= 1; i++)
                for (var j = -1; j <= 1; j++)
                    if (i != 0 || j != 0)
                        SpriteBatch.Draw(vTexture.Texture, position + new Vector2(i, j), vTexture.ClipRect, Color.Black, rotation, new Vector2(vTexture.Width * justify.X, vTexture.Height * justify.Y) - vTexture.DrawOffset, scale, flip, 0);

            SpriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, color, rotation, new Vector2(vTexture.Width * justify.X, vTexture.Height * justify.Y) - vTexture.DrawOffset, scale, flip, 0);
        }

        public static void VirtualTexture2DOutlinedJustified(VirtualTexture2D vTexture, Vector2 position, Vector2 justify, Color color, Vector2 scale)
        {
            for (var i = -1; i <= 1; i++)
                for (var j = -1; j <= 1; j++)
                    if (i != 0 || j != 0)
                        SpriteBatch.Draw(vTexture.Texture, position + new Vector2(i, j), vTexture.ClipRect, Color.Black, 0, new Vector2(vTexture.Width * justify.X, vTexture.Height * justify.Y) - vTexture.DrawOffset, scale, SpriteEffects.None, 0);

            SpriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, color, 0, new Vector2(vTexture.Width * justify.X, vTexture.Height * justify.Y) - vTexture.DrawOffset, scale, SpriteEffects.None, 0);
        }

        public static void VirtualTexture2DOutlinedJustified(VirtualTexture2D vTexture, Vector2 position, Vector2 justify, Color color, Vector2 scale, float rotation)
        {
            for (var i = -1; i <= 1; i++)
                for (var j = -1; j <= 1; j++)
                    if (i != 0 || j != 0)
                        SpriteBatch.Draw(vTexture.Texture, position + new Vector2(i, j), vTexture.ClipRect, Color.Black, rotation, new Vector2(vTexture.Width * justify.X, vTexture.Height * justify.Y) - vTexture.DrawOffset, scale, SpriteEffects.None, 0);

            SpriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, color, rotation, new Vector2(vTexture.Width * justify.X, vTexture.Height * justify.Y) - vTexture.DrawOffset, scale, SpriteEffects.None, 0);
        }

        public static void VirtualTexture2DOutlinedJustified(VirtualTexture2D vTexture, Vector2 position, Vector2 justify, Color color, Vector2 scale, float rotation, SpriteEffects flip)
        {
            for (var i = -1; i <= 1; i++)
                for (var j = -1; j <= 1; j++)
                    if (i != 0 || j != 0)
                        SpriteBatch.Draw(vTexture.Texture, position + new Vector2(i, j), vTexture.ClipRect, Color.Black, rotation, new Vector2(vTexture.Width * justify.X, vTexture.Height * justify.Y) - vTexture.DrawOffset, scale, flip, 0);

            SpriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, color, rotation, new Vector2(vTexture.Width * justify.X, vTexture.Height * justify.Y) - vTexture.DrawOffset, scale, flip, 0);
        }

        #endregion VirtualTexture2D Outlined Justified

    }
}
