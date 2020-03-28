using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.IO;
using System.Reflection;
using System.Runtime;

namespace Dart
{
    public class Engine : Game
    {
        //  The path to the directory that the calling assembly is running in.
        private static string _assemblyDirectory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

        /// <summary>
        ///     Gets the current running instance of the game <see cref="Engine"/>.
        /// </summary>
        public static Engine Instance { get; private set; }

        public static string DebugMessage { get; set; }



        /// <summary>
        ///     Gets the <see cref="Graphics"/> component used to manage the presenation of graphics.
        /// </summary>
        public static Graphics Graphics { get; private set; }

        /// <summary>
        ///     Gets or Sets the <see cref="Time"/> component used to manage the timing values between frames.
        /// </summary>
        public static Time Time { get; set; }

        /// <summary>
        ///     Gets the absolute path to the root directory for the content manager.
        /// </summary>
        public static string ContentDirectory => Path.Combine(_assemblyDirectory, Instance.Content.RootDirectory);

        /// <summary>
        ///     Gets or Sets a string value containing the title of this game. This is displayed in the game window's
        ///     title bar area.
        /// </summary>
        public static string Title { get; set; }

        /// <summary>
        ///     Gets or Sets a value indicating if the game should exit when the user presses the Escape keyboard key.
        /// </summary>
        public static bool ExitOnEscapeKeypress { get; set; }

        private FpsCounter _fpsCounter;
        private float _highestMemoryUsage = 0.0f;

        protected Scene _scene;
        protected Scene _nextScene;
        protected SpriteBatch _spriteBatch;

        /// <summary>
        ///     Creates a new game <see cref="Engine"/> instance.
        /// </summary>
        /// <param name="name">
        ///     A string represeting the name of the game. This will be displayed in the game window's title bar area.
        /// </param>
        /// <param name="width">
        ///     The width, in pixels, of the screen resolution.
        /// </param>
        /// <param name="height">
        ///     The height, in pixels, of the screen resolution.
        /// </param>
        /// <param name="virtualWidth">
        ///     The width, in pixels, of the virtual rendering resolution.
        /// </param>
        /// <param name="virtualHeight">
        ///     The height, in pixels, of the virtual rendering resolution.
        /// </param>
        /// <param name="fullscreen">
        ///     A value indicating if the graphics should render in fullscreen mode.
        /// </param>
        public Engine(string name, int width, int height, int virtualWidth, int virtualHeight, bool fullscreen)
        {
            if (width <= 0)
            {
                throw new ArgumentOutOfRangeException("width", "The width of the screen resolution must be greater than zero!");
            }

            if (height <= 0)
            {
                throw new ArgumentOutOfRangeException("height", "The height of the screen resolution must be greater than zero!");
            }

            if (virtualWidth <= 0)
            {
                throw new ArgumentOutOfRangeException("virtualWidth", "The width of the virtual rendering resolution must be greater than zero!");
            }

            if (virtualHeight <= 0)
            {
                throw new ArgumentOutOfRangeException("virtualHeight", "The height of the virtual rendering resolution must be greater than zero!");
            }

            Instance = this;
            Content.RootDirectory = "Content";
            Title = Window.Title = name;
            Time = new Time();
            _fpsCounter = new FpsCounter();

                     

            Graphics = new Graphics(this);
            Graphics.Initialize(width, height, virtualWidth, virtualHeight, false, HandleGraphicsDeviceCreated, HandleGraphicsDeviceReset, HandleClientSizeChanged);

            IsMouseVisible = true;
            IsFixedTimeStep = false;
            ExitOnEscapeKeypress = true;


            GCSettings.LatencyMode = GCLatencyMode.SustainedLowLatency;

        }

        /// <summary>
        ///     Called when the graphics device is created.
        /// </summary>
        public virtual void HandleGraphicsDeviceCreated()
        {

        }

        /// <summary>
        ///     Called when the graphics device is reset.  When this happens all contents of VRAM are wiped, so things
        ///     such as RenderTarget2Ds will need to be recreated.
        /// </summary>
        public virtual void HandleGraphicsDeviceReset()
        {

        }

        /// <summary>
        ///     Called when the game client window size has been changed.
        /// </summary>
        public virtual void HandleClientSizeChanged()
        {

        }

        protected override void Initialize()
        {
            base.Initialize();

            Input.Initialize();
            Dart.Draw.Initialize(Graphics.Device);
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            _spriteBatch = new SpriteBatch(Graphics.Device);
        }

        protected override void Update(GameTime gameTime)
        {
            //  Timing snapshots should always be updated first
            Time.Update(gameTime);

            //  Input states should be updated second
            Input.Update();

            //  Check if the game should exit
            if (ExitOnEscapeKeypress && Input.Keyboard.WasPressed(Keys.Escape))
            {
                Exit();
            }

            if (_scene != null)
            {
                _scene.BeforeUpdate();
                _scene.Update();
                _scene.AfterUpdate();
            }

            base.Update(gameTime);
        }

        /// <summary>
        ///    <para>WARNING:</para> 
        ///    <para>WARNING:</para> 
        ///    <para>WARNING:</para> 
        ///     <para>
        ///         This should not be overriden in the implementing game, which is what you would typically
        ///         do in a MonoGame project. Instead override the <see cref="RenderCore"/> method instead 
        ///         to control the rendering workflow.
        ///     </para>
        /// </summary>
        /// <param name="gameTime">
        ///     Provides snapshot timeing values.
        /// </param>
        protected override void Draw(GameTime gameTime)
        {
            RenderCore();
            base.Draw(gameTime);

#if DEBUG
            if (!string.IsNullOrEmpty(DebugMessage))
            {
                Window.Title = DebugMessage;
            }
            else
            {
                if (_fpsCounter.Update(gameTime))
                {
                    float memUsage = GC.GetTotalMemory(false) / 1048576.0f;
                    _highestMemoryUsage = Math.Max(memUsage, _highestMemoryUsage);
                    Window.Title = $"{Title} {_fpsCounter} - Mem Usage: {memUsage:F} MB -- Highest Mem Usage: {_highestMemoryUsage:F} MB";

                }
            }
#endif


        }

        /// <summary>
        ///     Override this method to control how the game renders.
        /// </summary>
        protected virtual void RenderCore()
        {

            if (_scene != null)
            {
                _scene.BeforeRender();
                _scene.Render();
                _scene.AfterRender();
            }
        }
    }
}
