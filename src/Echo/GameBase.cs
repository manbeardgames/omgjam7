using Dart;
using Dart.Ogmo;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.IO;

namespace Echo
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class GameBase : Engine
    {
        OgmoProject _ogmoProject;

        OgmoLevel _level;

        public GameBase():base("Echo", 1280, 720, 1280, 720, false)
        {
            
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            base.LoadContent();

            _ogmoProject = Content.Load<OgmoProject>(@"ogmo\testproject");
            _level = _ogmoProject.GetLevel("testlevel");

        }

        protected override void Draw(GameTime gameTime)
        {


            Dart.Draw.SpriteBatch.Begin();
            OgmoTileLayer tileLayer = _level.GetLayer<OgmoTileLayer>("tile_layer");
            tileLayer.Render();
            Dart.Draw.SpriteBatch.End();
        }


    }
}
