//using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Graphics;

//namespace Dart
//{
//    public static class SpriteBatchExtensions
//    {
//        //  A reusable rectangle instance.
//        private static Rectangle _rect = Microsoft.Xna.Framework.Rectangle.Empty;

//        //  A reusuable 1x1 white pixel
//        public static VirtualTexture2D Pixel { get; private set; }

//        /// <summary>
//        ///     Initialzies this for rendering.
//        /// </summary>
//        public static void Initialize()
//        {
//            Pixel = new VirtualTexture2D(1, 1, Color.White);
//        }

//        // --------------------------------------------------------------------
//        //  Draw Point

//        #region Draw Point

//        public static void Point(this SpriteBatch spriteBatch, Vector2 position)
//        {
//            spriteBatch.Draw(Pixel, position);
//        }

//        public static void Point(this SpriteBatch spriteBatch, Vector2 position, Color color)
//        {
//            spriteBatch.Draw(Pixel, position, color);
//        }

//        #endregion Draw Point

//        // -------------------------------//-----------------------------------

//        // --------------------------------------------------------------------
//        //  Draw Line

//        #region Draw Line

//        public static void Line(this SpriteBatch spriteBatch, Vector2 start, Vector2 end, Color color)
//        {
//            spriteBatch.LineAngle(start, Maths.Angle(start, end), Vector2.Distance(start, end), color);
//        }

//        public static void Line(this SpriteBatch spriteBatch, Vector2 start, Vector2 end, Color color, float thickness)
//        {
//            spriteBatch.LineAngle(start, Maths.Angle(start, end), Vector2.Distance(start, end), color, thickness);
//        }

//        public static void Line(this SpriteBatch spriteBatch, float x1, float y1, float x2, float y2, Color color)
//        {
//            spriteBatch.Line(new Vector2(x1, y1), new Vector2(x2, y2), color);
//        }

//        #endregion Draw Line

//        // -------------------------------//-----------------------------------

//        // --------------------------------------------------------------------
//        //  Draw Line Angle

//        #region Draw Line Angle

//        public static void LineAngle(this SpriteBatch spriteBatch, Vector2 start, float angle, float length, Color color)
//        {
//            spriteBatch.Draw(Pixel.Texture, start, Pixel.ClipRect, color, angle, Vector2.Zero, new Vector2(length, 1), SpriteEffects.None, 0);
//        }

//        public static void LineAngle(this SpriteBatch spriteBatch, Vector2 start, float angle, float length, Color color, float thickness)
//        {
//            spriteBatch.Draw(Pixel.Texture, start, Pixel.ClipRect, color, angle, new Vector2(0, .5f), new Vector2(length, thickness), SpriteEffects.None, 0);
//        }

//        public static void LineAngle(this SpriteBatch spriteBatch, float startX, float startY, float angle, float length, Color color)
//        {
//            spriteBatch.LineAngle(new Vector2(startX, startY), angle, length, color);
//        }

//        #endregion Draw Line Angle

//        // -------------------------------//-----------------------------------

//        // --------------------------------------------------------------------
//        //  Draw Rectangle

//        #region Draw Rectangle

//        public static void Rectangle(this SpriteBatch spriteBatch, float x, float y, float width, float height, Color color)
//        {
//            _rect.X = (int)x;
//            _rect.Y = (int)y;
//            _rect.Width = (int)width;
//            _rect.Height = (int)height;
//            spriteBatch.Draw(Pixel.Texture, _rect, Pixel.ClipRect, color);
//        }

//        public static void Rectangle(this SpriteBatch spriteBatch, Vector2 position, float width, float height, Color color)
//        {
//            spriteBatch.Rectangle(position.X, position.Y, width, height, color);
//        }

//        public static void Rectangle(this SpriteBatch spriteBatch,Rectangle rect, Color color)
//        {
//            _rect = rect;
//            spriteBatch.Draw(Pixel.Texture, rect, Pixel.ClipRect, color);
//        }

//        #endregion Draw Rectangle

//        // -------------------------------//-----------------------------------

//        // --------------------------------------------------------------------
//        //  Draw VirtualTexture2D

//        #region Draw VirtualTexture2D

//        public static void Draw(this SpriteBatch spriteBatch, VirtualTexture2D vTexture, Vector2 position)
//        {
//            spriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, Color.White, 0, -vTexture.DrawOffset, 1f, SpriteEffects.None, 0);
//        }

//        public static void Draw(this SpriteBatch spriteBatch, VirtualTexture2D vTexture, Vector2 position, Color color)
//        {
//            spriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, color, 0, -vTexture.DrawOffset, 1f, SpriteEffects.None, 0);
//        }

//        public static void Draw(this SpriteBatch spriteBatch, VirtualTexture2D vTexture, Vector2 position, Vector2 origin)
//        {
//            spriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, Color.White, 0, origin - vTexture.DrawOffset, 1f, SpriteEffects.None, 0);
//        }

//        public static void Draw(this SpriteBatch spriteBatch, VirtualTexture2D vTexture, Vector2 position, Vector2 origin, Color color)
//        {
//            spriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, color, 0, origin - vTexture.DrawOffset, 1f, SpriteEffects.None, 0);
//        }

//        public static void Draw(this SpriteBatch spriteBatch, VirtualTexture2D vTexture, Vector2 position, Vector2 origin, Color color, float scale)
//        {
//            spriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, color, 0, origin - vTexture.DrawOffset, scale, SpriteEffects.None, 0);
//        }

//        public static void Draw(this SpriteBatch spriteBatch, VirtualTexture2D vTexture, Vector2 position, Vector2 origin, Color color, float scale, float rotation)
//        {
//            spriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, color, rotation, origin - vTexture.DrawOffset, scale, SpriteEffects.None, 0);
//        }

//        public static void Draw(this SpriteBatch spriteBatch, VirtualTexture2D vTexture, Vector2 position, Vector2 origin, Color color, float scale, float rotation, SpriteEffects flip)
//        {
//            spriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, color, rotation, origin - vTexture.DrawOffset, scale, flip, 0);
//        }

//        public static void Draw(this SpriteBatch spriteBatch, VirtualTexture2D vTexture, Vector2 position, Vector2 origin, Color color, Vector2 scale)
//        {
//            spriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, color, 0, origin - vTexture.DrawOffset, scale, SpriteEffects.None, 0);
//        }

//        public static void Draw(this SpriteBatch spriteBatch, VirtualTexture2D vTexture, Vector2 position, Vector2 origin, Color color, Vector2 scale, float rotation)
//        {
//            spriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, color, rotation, origin - vTexture.DrawOffset, scale, SpriteEffects.None, 0);
//        }

//        public static void Draw(this SpriteBatch spriteBatch, VirtualTexture2D vTexture, Vector2 position, Vector2 origin, Color color, Vector2 scale, float rotation, SpriteEffects flip)
//        {
//            spriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, color, rotation, origin - vTexture.DrawOffset, scale, flip, 0);
//        }

//        public static void Draw(this SpriteBatch spriteBatch, VirtualTexture2D vTexture, Vector2 position, Vector2 origin, Color color, Vector2 scale, float rotation, Rectangle clip)
//        {
//            spriteBatch.Draw(vTexture.Texture, position, vTexture.GetRelativeRect(clip), color, rotation, origin - vTexture.DrawOffset, scale, SpriteEffects.None, 0);
//        }

//        #endregion Draw VirtualTexture2D

//        // -------------------------------//-----------------------------------

//        // --------------------------------------------------------------------
//        //  Draw VirtualTexture2D Centered

//        #region Draw VirtualTexture2D Centered

//        public static void DrawCentered(this SpriteBatch spriteBatch, VirtualTexture2D vTexture, Vector2 position)
//        {
//            spriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, Color.White, 0, vTexture.Center - vTexture.DrawOffset, 1f, SpriteEffects.None, 0);
//        }

//        public static void DrawCentered(this SpriteBatch spriteBatch, VirtualTexture2D vTexture, Vector2 position, Color color)
//        {
//            spriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, color, 0, vTexture.Center - vTexture.DrawOffset, 1f, SpriteEffects.None, 0);
//        }

//        public static void DrawCentered(this SpriteBatch spriteBatch, VirtualTexture2D vTexture, Vector2 position, Color color, float scale)
//        {
//            spriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, color, 0, vTexture.Center - vTexture.DrawOffset, scale, SpriteEffects.None, 0);
//        }

//        public static void DrawCentered(this SpriteBatch spriteBatch, VirtualTexture2D vTexture, Vector2 position, Color color, float scale, float rotation)
//        {
//            spriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, color, rotation, vTexture.Center - vTexture.DrawOffset, scale, SpriteEffects.None, 0);
//        }

//        public static void DrawCentered(this SpriteBatch spriteBatch, VirtualTexture2D vTexture, Vector2 position, Color color, float scale, float rotation, SpriteEffects flip)
//        {
//            spriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, color, rotation, vTexture.Center - vTexture.DrawOffset, scale, flip, 0);
//        }

//        public static void DrawCentered(this SpriteBatch spriteBatch, VirtualTexture2D vTexture, Vector2 position, Color color, Vector2 scale)
//        {
//            spriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, color, 0, vTexture.Center - vTexture.DrawOffset, scale, SpriteEffects.None, 0);
//        }

//        public static void DrawCentered(this SpriteBatch spriteBatch, VirtualTexture2D vTexture, Vector2 position, Color color, Vector2 scale, float rotation)
//        {
//            spriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, color, rotation, vTexture.Center - vTexture.DrawOffset, scale, SpriteEffects.None, 0);
//        }

//        public static void DrawCentered(this SpriteBatch spriteBatch, VirtualTexture2D vTexture, Vector2 position, Color color, Vector2 scale, float rotation, SpriteEffects flip)
//        {
//            spriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, color, rotation, vTexture.Center - vTexture.DrawOffset, scale, flip, 0);
//        }

//        #endregion Draw VirtualTexture2D Centered

//        // -------------------------------//-----------------------------------


//        // --------------------------------------------------------------------
//        //  Draw VirtualTexture2D Justified

//        #region Draw VirtualTexture2D Justified

//        public static void DrawJustified(this SpriteBatch spriteBatch, VirtualTexture2D vTexture, Vector2 position, Vector2 justify)
//        {
//            spriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, Color.White, 0, new Vector2(vTexture.Width * justify.X, vTexture.Height * justify.Y) - vTexture.DrawOffset, 1f, SpriteEffects.None, 0);
//        }

//        public static void DrawJustified(this SpriteBatch spriteBatch, VirtualTexture2D vTexture, Vector2 position, Vector2 justify, Color color)
//        {
//            spriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, color, 0, new Vector2(vTexture.Width * justify.X, vTexture.Height * justify.Y) - vTexture.DrawOffset, 1f, SpriteEffects.None, 0);
//        }

//        public static void DrawJustified(this SpriteBatch spriteBatch, VirtualTexture2D vTexture, Vector2 position, Vector2 justify, Color color, float scale)
//        {
//            spriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, color, 0, new Vector2(vTexture.Width * justify.X, vTexture.Height * justify.Y) - vTexture.DrawOffset, scale, SpriteEffects.None, 0);
//        }

//        public static void DrawJustified(this SpriteBatch spriteBatch, VirtualTexture2D vTexture, Vector2 position, Vector2 justify, Color color, float scale, float rotation)
//        {
//            spriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, color, rotation, new Vector2(vTexture.Width * justify.X, vTexture.Height * justify.Y) - vTexture.DrawOffset, scale, SpriteEffects.None, 0);
//        }

//        public static void DrawJustified(this SpriteBatch spriteBatch, VirtualTexture2D vTexture, Vector2 position, Vector2 justify, Color color, float scale, float rotation, SpriteEffects flip)
//        {
//            spriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, color, rotation, new Vector2(vTexture.Width * justify.X, vTexture.Height * justify.Y) - vTexture.DrawOffset, scale, flip, 0);
//        }

//        public static void DrawJustified(this SpriteBatch spriteBatch, VirtualTexture2D vTexture, Vector2 position, Vector2 justify, Color color, Vector2 scale)
//        {
//            spriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, color, 0, new Vector2(vTexture.Width * justify.X, vTexture.Height * justify.Y) - vTexture.DrawOffset, scale, SpriteEffects.None, 0);
//        }

//        public static void DrawJustified(this SpriteBatch spriteBatch, VirtualTexture2D vTexture, Vector2 position, Vector2 justify, Color color, Vector2 scale, float rotation)
//        {
//            spriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, color, rotation, new Vector2(vTexture.Width * justify.X, vTexture.Height * justify.Y) - vTexture.DrawOffset, scale, SpriteEffects.None, 0);
//        }

//        public static void DrawJustified(this SpriteBatch spriteBatch, VirtualTexture2D vTexture, Vector2 position, Vector2 justify, Color color, Vector2 scale, float rotation, SpriteEffects flip)
//        {
//            spriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, color, rotation, new Vector2(vTexture.Width * justify.X, vTexture.Height * justify.Y) - vTexture.DrawOffset, scale, flip, 0);
//        }

//        #endregion Draw VirtualTexture2D Justified

//        // -------------------------------//-----------------------------------


//        // --------------------------------------------------------------------
//        //  Draw VirtualTexture2D Outlined

//        #region Draw VirtualTexture2D Outlined

//        public static void DrawOutline(this SpriteBatch spriteBatch, VirtualTexture2D vTexture, Vector2 position)
//        {
//            for (var i = -1; i <= 1; i++)
//                for (var j = -1; j <= 1; j++)
//                    if (i != 0 || j != 0)
//                        spriteBatch.Draw(vTexture.Texture, position + new Vector2(i, j), vTexture.ClipRect, Color.Black, 0, -vTexture.DrawOffset, 1f, SpriteEffects.None, 0);

//            spriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, Color.White, 0, -vTexture.DrawOffset, 1f, SpriteEffects.None, 0);
//        }

//        public static void DrawOutline(this SpriteBatch spriteBatch, VirtualTexture2D vTexture, Vector2 position, Vector2 origin)
//        {
//            for (var i = -1; i <= 1; i++)
//                for (var j = -1; j <= 1; j++)
//                    if (i != 0 || j != 0)
//                        spriteBatch.Draw(vTexture.Texture, position + new Vector2(i, j), vTexture.ClipRect, Color.Black, 0, origin - vTexture.DrawOffset, 1f, SpriteEffects.None, 0);

//            spriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, Color.White, 0, origin - vTexture.DrawOffset, 1f, SpriteEffects.None, 0);
//        }

//        public static void DrawOutline(this SpriteBatch spriteBatch, VirtualTexture2D vTexture, Vector2 position, Vector2 origin, Color color)
//        {
//            for (var i = -1; i <= 1; i++)
//                for (var j = -1; j <= 1; j++)
//                    if (i != 0 || j != 0)
//                        spriteBatch.Draw(vTexture.Texture, position + new Vector2(i, j), vTexture.ClipRect, Color.Black, 0, origin - vTexture.DrawOffset, 1f, SpriteEffects.None, 0);

//            spriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, color, 0, origin - vTexture.DrawOffset, 1f, SpriteEffects.None, 0);
//        }

//        public static void DrawOutline(this SpriteBatch spriteBatch, VirtualTexture2D vTexture, Vector2 position, Vector2 origin, Color color, float scale)
//        {
//            for (var i = -1; i <= 1; i++)
//                for (var j = -1; j <= 1; j++)
//                    if (i != 0 || j != 0)
//                        spriteBatch.Draw(vTexture.Texture, position + new Vector2(i, j), vTexture.ClipRect, Color.Black, 0, origin - vTexture.DrawOffset, scale, SpriteEffects.None, 0);

//            spriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, color, 0, origin - vTexture.DrawOffset, scale, SpriteEffects.None, 0);
//        }

//        public static void DrawOutline(this SpriteBatch spriteBatch, VirtualTexture2D vTexture, Vector2 position, Vector2 origin, Color color, float scale, float rotation)
//        {
//            for (var i = -1; i <= 1; i++)
//                for (var j = -1; j <= 1; j++)
//                    if (i != 0 || j != 0)
//                        spriteBatch.Draw(vTexture.Texture, position + new Vector2(i, j), vTexture.ClipRect, Color.Black, rotation, origin - vTexture.DrawOffset, scale, SpriteEffects.None, 0);

//            spriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, color, rotation, origin - vTexture.DrawOffset, scale, SpriteEffects.None, 0);
//        }

//        public static void DrawOutline(this SpriteBatch spriteBatch, VirtualTexture2D vTexture, Vector2 position, Vector2 origin, Color color, float scale, float rotation, SpriteEffects flip)
//        {
//            for (var i = -1; i <= 1; i++)
//                for (var j = -1; j <= 1; j++)
//                    if (i != 0 || j != 0)
//                        spriteBatch.Draw(vTexture.Texture, position + new Vector2(i, j), vTexture.ClipRect, Color.Black, rotation, origin - vTexture.DrawOffset, scale, flip, 0);

//            spriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, color, rotation, origin - vTexture.DrawOffset, scale, flip, 0);
//        }

//        public static void DrawOutline(this SpriteBatch spriteBatch, VirtualTexture2D vTexture, Vector2 position, Vector2 origin, Color color, Vector2 scale)
//        {
//            for (var i = -1; i <= 1; i++)
//                for (var j = -1; j <= 1; j++)
//                    if (i != 0 || j != 0)
//                        spriteBatch.Draw(vTexture.Texture, position + new Vector2(i, j), vTexture.ClipRect, Color.Black, 0, origin - vTexture.DrawOffset, scale, SpriteEffects.None, 0);

//            spriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, color, 0, origin - vTexture.DrawOffset, scale, SpriteEffects.None, 0);
//        }

//        public static void DrawOutline(this SpriteBatch spriteBatch, VirtualTexture2D vTexture, Vector2 position, Vector2 origin, Color color, Vector2 scale, float rotation)
//        {
//            for (var i = -1; i <= 1; i++)
//                for (var j = -1; j <= 1; j++)
//                    if (i != 0 || j != 0)
//                        spriteBatch.Draw(vTexture.Texture, position + new Vector2(i, j), vTexture.ClipRect, Color.Black, rotation, origin - vTexture.DrawOffset, scale, SpriteEffects.None, 0);

//            spriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, color, rotation, origin - vTexture.DrawOffset, scale, SpriteEffects.None, 0);
//        }

//        public static void DrawOutline(this SpriteBatch spriteBatch, VirtualTexture2D vTexture, Vector2 position, Vector2 origin, Color color, Vector2 scale, float rotation, SpriteEffects flip)
//        {
//            for (var i = -1; i <= 1; i++)
//                for (var j = -1; j <= 1; j++)
//                    if (i != 0 || j != 0)
//                        spriteBatch.Draw(vTexture.Texture, position + new Vector2(i, j), vTexture.ClipRect, Color.Black, rotation, origin - vTexture.DrawOffset, scale, flip, 0);

//            spriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, color, rotation, origin - vTexture.DrawOffset, scale, flip, 0);
//        }

//        #endregion Draw VirtualTexture2D Outlined

//        // -------------------------------//-----------------------------------


//        // --------------------------------------------------------------------
//        //  Draw VirtualTexture2D Outlined Centered

//        #region Draw VirtualTexture2D Outlined Centered

//        public static void DrawOutlineCentered(this SpriteBatch spriteBatch, VirtualTexture2D vTexture, Vector2 position)
//        {
//            for (var i = -1; i <= 1; i++)
//                for (var j = -1; j <= 1; j++)
//                    if (i != 0 || j != 0)
//                        spriteBatch.Draw(vTexture.Texture, position + new Vector2(i, j), vTexture.ClipRect, Color.Black, 0, vTexture.Center - vTexture.DrawOffset, 1f, SpriteEffects.None, 0);

//            spriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, Color.White, 0, vTexture.Center - vTexture.DrawOffset, 1f, SpriteEffects.None, 0);
//        }

//        public static void DrawOutlineCentered(this SpriteBatch spriteBatch, VirtualTexture2D vTexture, Vector2 position, Color color)
//        {
//            for (var i = -1; i <= 1; i++)
//                for (var j = -1; j <= 1; j++)
//                    if (i != 0 || j != 0)
//                        spriteBatch.Draw(vTexture.Texture, position + new Vector2(i, j), vTexture.ClipRect, Color.Black, 0, vTexture.Center - vTexture.DrawOffset, 1f, SpriteEffects.None, 0);

//            spriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, color, 0, vTexture.Center - vTexture.DrawOffset, 1f, SpriteEffects.None, 0);
//        }

//        public static void DrawOutlineCentered(this SpriteBatch spriteBatch, VirtualTexture2D vTexture, Vector2 position, Color color, float scale)
//        {
//            for (var i = -1; i <= 1; i++)
//                for (var j = -1; j <= 1; j++)
//                    if (i != 0 || j != 0)
//                        spriteBatch.Draw(vTexture.Texture, position + new Vector2(i, j), vTexture.ClipRect, Color.Black, 0, vTexture.Center - vTexture.DrawOffset, scale, SpriteEffects.None, 0);

//            spriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, color, 0, vTexture.Center - vTexture.DrawOffset, scale, SpriteEffects.None, 0);
//        }

//        public static void DrawOutlineCentered(this SpriteBatch spriteBatch, VirtualTexture2D vTexture, Vector2 position, Color color, float scale, float rotation)
//        {
//            for (var i = -1; i <= 1; i++)
//                for (var j = -1; j <= 1; j++)
//                    if (i != 0 || j != 0)
//                        spriteBatch.Draw(vTexture.Texture, position + new Vector2(i, j), vTexture.ClipRect, Color.Black, rotation, vTexture.Center - vTexture.DrawOffset, scale, SpriteEffects.None, 0);

//            spriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, color, rotation, vTexture.Center - vTexture.DrawOffset, scale, SpriteEffects.None, 0);
//        }

//        public static void DrawOutlineCentered(this SpriteBatch spriteBatch, VirtualTexture2D vTexture, Vector2 position, Color color, float scale, float rotation, SpriteEffects flip)
//        {
//            for (var i = -1; i <= 1; i++)
//                for (var j = -1; j <= 1; j++)
//                    if (i != 0 || j != 0)
//                        spriteBatch.Draw(vTexture.Texture, position + new Vector2(i, j), vTexture.ClipRect, Color.Black, rotation, vTexture.Center - vTexture.DrawOffset, scale, flip, 0);

//            spriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, color, rotation, vTexture.Center - vTexture.DrawOffset, scale, flip, 0);
//        }

//        public static void DrawOutlineCentered(this SpriteBatch spriteBatch, VirtualTexture2D vTexture, Vector2 position, Color color, Vector2 scale)
//        {
//            for (var i = -1; i <= 1; i++)
//                for (var j = -1; j <= 1; j++)
//                    if (i != 0 || j != 0)
//                        spriteBatch.Draw(vTexture.Texture, position + new Vector2(i, j), vTexture.ClipRect, Color.Black, 0, vTexture.Center - vTexture.DrawOffset, scale, SpriteEffects.None, 0);

//            spriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, color, 0, vTexture.Center - vTexture.DrawOffset, scale, SpriteEffects.None, 0);
//        }

//        public static void DrawOutlineCentered(this SpriteBatch spriteBatch, VirtualTexture2D vTexture, Vector2 position, Color color, Vector2 scale, float rotation)
//        {
//            for (var i = -1; i <= 1; i++)
//                for (var j = -1; j <= 1; j++)
//                    if (i != 0 || j != 0)
//                        spriteBatch.Draw(vTexture.Texture, position + new Vector2(i, j), vTexture.ClipRect, Color.Black, rotation, vTexture.Center - vTexture.DrawOffset, scale, SpriteEffects.None, 0);

//            spriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, color, rotation, vTexture.Center - vTexture.DrawOffset, scale, SpriteEffects.None, 0);
//        }

//        public static void DrawOutlineCentered(this SpriteBatch spriteBatch, VirtualTexture2D vTexture, Vector2 position, Color color, Vector2 scale, float rotation, SpriteEffects flip)
//        {
//            for (var i = -1; i <= 1; i++)
//                for (var j = -1; j <= 1; j++)
//                    if (i != 0 || j != 0)
//                        spriteBatch.Draw(vTexture.Texture, position + new Vector2(i, j), vTexture.ClipRect, Color.Black, rotation, vTexture.Center - vTexture.DrawOffset, scale, flip, 0);

//            spriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, color, rotation, vTexture.Center - vTexture.DrawOffset, scale, flip, 0);
//        }

//        #endregion Draw VirtualTexture2D Outlined Centered

//        // -------------------------------//-----------------------------------


//        // --------------------------------------------------------------------
//        //  Draw VirtualTexture2D Outlined Justified

//        #region Draw VirtualTexture2D Outlined Justified

//        public static void DrawOutlineJustified(this SpriteBatch spriteBatch, VirtualTexture2D vTexture, Vector2 position, Vector2 justify)
//        {
//            for (var i = -1; i <= 1; i++)
//                for (var j = -1; j <= 1; j++)
//                    if (i != 0 || j != 0)
//                        spriteBatch.Draw(vTexture.Texture, position + new Vector2(i, j), vTexture.ClipRect, Color.Black, 0, new Vector2(vTexture.Width * justify.X, vTexture.Height * justify.Y) - vTexture.DrawOffset, 1f, SpriteEffects.None, 0);

//            spriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, Color.White, 0, new Vector2(vTexture.Width * justify.X, vTexture.Height * justify.Y) - vTexture.DrawOffset, 1f, SpriteEffects.None, 0);
//        }

//        public static void DrawOutlineJustified(this SpriteBatch spriteBatch, VirtualTexture2D vTexture, Vector2 position, Vector2 justify, Color color)
//        {
//            for (var i = -1; i <= 1; i++)
//                for (var j = -1; j <= 1; j++)
//                    if (i != 0 || j != 0)
//                        spriteBatch.Draw(vTexture.Texture, position + new Vector2(i, j), vTexture.ClipRect, Color.Black, 0, new Vector2(vTexture.Width * justify.X, vTexture.Height * justify.Y) - vTexture.DrawOffset, 1f, SpriteEffects.None, 0);

//            spriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, color, 0, new Vector2(vTexture.Width * justify.X, vTexture.Height * justify.Y) - vTexture.DrawOffset, 1f, SpriteEffects.None, 0);
//        }

//        public static void DrawOutlineJustified(this SpriteBatch spriteBatch, VirtualTexture2D vTexture, Vector2 position, Vector2 justify, Color color, float scale)
//        {
//            for (var i = -1; i <= 1; i++)
//                for (var j = -1; j <= 1; j++)
//                    if (i != 0 || j != 0)
//                        spriteBatch.Draw(vTexture.Texture, position + new Vector2(i, j), vTexture.ClipRect, Color.Black, 0, new Vector2(vTexture.Width * justify.X, vTexture.Height * justify.Y) - vTexture.DrawOffset, scale, SpriteEffects.None, 0);

//            spriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, color, 0, new Vector2(vTexture.Width * justify.X, vTexture.Height * justify.Y) - vTexture.DrawOffset, scale, SpriteEffects.None, 0);
//        }

//        public static void DrawOutlineJustified(this SpriteBatch spriteBatch, VirtualTexture2D vTexture, Vector2 position, Vector2 justify, Color color, float scale, float rotation)
//        {
//            for (var i = -1; i <= 1; i++)
//                for (var j = -1; j <= 1; j++)
//                    if (i != 0 || j != 0)
//                        spriteBatch.Draw(vTexture.Texture, position + new Vector2(i, j), vTexture.ClipRect, Color.Black, rotation, new Vector2(vTexture.Width * justify.X, vTexture.Height * justify.Y) - vTexture.DrawOffset, scale, SpriteEffects.None, 0);

//            spriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, color, rotation, new Vector2(vTexture.Width * justify.X, vTexture.Height * justify.Y) - vTexture.DrawOffset, scale, SpriteEffects.None, 0);
//        }

//        public static void DrawOutlineJustified(this SpriteBatch spriteBatch, VirtualTexture2D vTexture, Vector2 position, Vector2 justify, Color color, float scale, float rotation, SpriteEffects flip)
//        {
//            for (var i = -1; i <= 1; i++)
//                for (var j = -1; j <= 1; j++)
//                    if (i != 0 || j != 0)
//                        spriteBatch.Draw(vTexture.Texture, position + new Vector2(i, j), vTexture.ClipRect, Color.Black, rotation, new Vector2(vTexture.Width * justify.X, vTexture.Height * justify.Y) - vTexture.DrawOffset, scale, flip, 0);

//            spriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, color, rotation, new Vector2(vTexture.Width * justify.X, vTexture.Height * justify.Y) - vTexture.DrawOffset, scale, flip, 0);
//        }

//        public static void DrawOutlineJustified(this SpriteBatch spriteBatch, VirtualTexture2D vTexture, Vector2 position, Vector2 justify, Color color, Vector2 scale)
//        {
//            for (var i = -1; i <= 1; i++)
//                for (var j = -1; j <= 1; j++)
//                    if (i != 0 || j != 0)
//                        spriteBatch.Draw(vTexture.Texture, position + new Vector2(i, j), vTexture.ClipRect, Color.Black, 0, new Vector2(vTexture.Width * justify.X, vTexture.Height * justify.Y) - vTexture.DrawOffset, scale, SpriteEffects.None, 0);

//            spriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, color, 0, new Vector2(vTexture.Width * justify.X, vTexture.Height * justify.Y) - vTexture.DrawOffset, scale, SpriteEffects.None, 0);
//        }

//        public static void DrawOutlineJustified(this SpriteBatch spriteBatch, VirtualTexture2D vTexture, Vector2 position, Vector2 justify, Color color, Vector2 scale, float rotation)
//        {
//            for (var i = -1; i <= 1; i++)
//                for (var j = -1; j <= 1; j++)
//                    if (i != 0 || j != 0)
//                        spriteBatch.Draw(vTexture.Texture, position + new Vector2(i, j), vTexture.ClipRect, Color.Black, rotation, new Vector2(vTexture.Width * justify.X, vTexture.Height * justify.Y) - vTexture.DrawOffset, scale, SpriteEffects.None, 0);

//            spriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, color, rotation, new Vector2(vTexture.Width * justify.X, vTexture.Height * justify.Y) - vTexture.DrawOffset, scale, SpriteEffects.None, 0);
//        }

//        public static void DrawOutlineJustified(this SpriteBatch spriteBatch, VirtualTexture2D vTexture, Vector2 position, Vector2 justify, Color color, Vector2 scale, float rotation, SpriteEffects flip)
//        {
//            for (var i = -1; i <= 1; i++)
//                for (var j = -1; j <= 1; j++)
//                    if (i != 0 || j != 0)
//                        spriteBatch.Draw(vTexture.Texture, position + new Vector2(i, j), vTexture.ClipRect, Color.Black, rotation, new Vector2(vTexture.Width * justify.X, vTexture.Height * justify.Y) - vTexture.DrawOffset, scale, flip, 0);

//            spriteBatch.Draw(vTexture.Texture, position, vTexture.ClipRect, color, rotation, new Vector2(vTexture.Width * justify.X, vTexture.Height * justify.Y) - vTexture.DrawOffset, scale, flip, 0);
//        }

//        #endregion Draw VirtualTexture2D Outlined Justified

//        // -------------------------------//-----------------------------------

//    }
//}
