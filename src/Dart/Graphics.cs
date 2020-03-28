using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Dart
{

    public class Graphics
    {
        private readonly GraphicsDeviceManager _manager;
        private readonly Game _game;
        private readonly GameWindow _gameWindow;
        private Action _onGraphicsDeviceCreated;
        private Action _onGraphicsDeviceReset;
        private Action _onClientSizeChanged;

        private int _viewPadding = 0;
        private bool _isResizing;

        public GraphicsDevice Device => _manager.GraphicsDevice;
        public Size Resolution { get; set; }
        public Size VirtualResolution { get; set; }
        public int ViewPadding
        {
            get => _viewPadding;
            set
            {
                if (_viewPadding == value) { return; }
                _viewPadding = value;
                UpdateView();
            }
        }
        public Viewport Viewport { get; private set; }
        public Matrix ScaleMatrix { get; private set; }

        public Color ClearColor { get; set; }

        public Graphics(Game game)
        {
            _game = game;
            _gameWindow = _game.Window;

            _manager = new GraphicsDeviceManager(_game);
            ClearColor = Color.Black;
        }

        public void Initialize(int width,
                               int height,
                               int virtualWidth,
                               int virtualHeight,
                               bool fullscreen,
                               Action onGraphicsDeviceCreated,
                               Action onGraphicsDeviceReset,
                               Action onClientSizeChanged)
        {
            Resolution = new Size(width, height);
            VirtualResolution = new Size(virtualWidth, virtualHeight);

            _onGraphicsDeviceCreated = onGraphicsDeviceCreated;
            _onGraphicsDeviceReset = onGraphicsDeviceReset;
            _onClientSizeChanged = onClientSizeChanged;

            _manager.DeviceCreated += OnGraphicsDeviceCreated;
            _manager.DeviceReset += OnGraphicsDeviceReset;

            _manager.SynchronizeWithVerticalRetrace = true;
            _manager.PreferMultiSampling = false;
            _manager.GraphicsProfile = GraphicsProfile.HiDef;
            _manager.PreferredBackBufferFormat = SurfaceFormat.Color;
            _manager.PreferredDepthStencilFormat = DepthFormat.Depth24Stencil8;

            _gameWindow.AllowUserResizing = true;
            _gameWindow.ClientSizeChanged += OnClientSizeChanged;

            if (fullscreen)
            {
                _manager.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
                _manager.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
                _manager.IsFullScreen = true;
            }
            else
            {
                _manager.PreferredBackBufferWidth = width;
                _manager.PreferredBackBufferHeight = height;
                _manager.IsFullScreen = false;
            }

            _manager.ApplyChanges();
        }

        private void OnGraphicsDeviceCreated(object sender, EventArgs e)
        {
            UpdateView();

            if (_onGraphicsDeviceCreated != null)
            {
                _onGraphicsDeviceCreated.Invoke();
            }
        }

        private void OnGraphicsDeviceReset(object sender, EventArgs e)
        {
            UpdateView();

            if (_onGraphicsDeviceReset != null)
            {
                _onGraphicsDeviceReset.Invoke();
            }
        }

        private void OnClientSizeChanged(object sender, EventArgs e)
        {
            if (_gameWindow.ClientBounds.Width > 0 && _gameWindow.ClientBounds.Height > 0)
            {
                _isResizing = true;

                _manager.PreferredBackBufferWidth = _gameWindow.ClientBounds.Width;
                _manager.PreferredBackBufferHeight = _gameWindow.ClientBounds.Height;

                UpdateView();

                _isResizing = false;
            }

            if (_onClientSizeChanged != null)
            {
                _onClientSizeChanged.Invoke();
            }
        }

        public void SetWindowed(int width, int height)
        {
            if (width > 0 && height > 0)
            {
                _isResizing = true;

                _manager.PreferredBackBufferWidth = width;
                _manager.PreferredBackBufferHeight = height;
                _manager.IsFullScreen = false;
                _manager.ApplyChanges();

                _isResizing = false;
            }
        }

        public void SetFullscren()
        {
            _isResizing = true;

            _manager.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            _manager.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            _manager.IsFullScreen = true;
            _manager.ApplyChanges();

            _isResizing = false;
        }

        private void UpdateView()
        {
            float screenWidth = Device.PresentationParameters.BackBufferWidth;
            float screenHeight = Device.PresentationParameters.BackBufferHeight;


            if (screenWidth / VirtualResolution.Width > screenHeight / VirtualResolution.Height)
            {
                ViewWidth = (int)(screenHeight / VirtualResolution.Height * VirtualResolution.Width);
                ViewHeight = (int)screenHeight;
            }
            else
            {
                ViewWidth = (int)screenWidth;
                ViewHeight = (int)(screenWidth / VirtualResolution.Width * VirtualResolution.Height);
            }

            var aspect = ViewWidth / (float)ViewHeight;
            ViewWidth -= ViewPadding * 2;
            ViewHeight -= (int)(aspect * ViewPadding * 2);

            ScaleMatrix = Matrix.CreateScale(ViewWidth / (float)VirtualResolution.Width);

            Viewport = new Viewport()
            {
                X = (int)(screenWidth / 2 - ViewWidth / 2),
                Y = (int)(screenHeight / 2 - ViewHeight / 2),
                Width = ViewWidth,
                Height = ViewHeight,
                MinDepth = 0,
                MaxDepth = 1
            };

        }

        public RenderTarget2D CreateRenderTarget2D(int width, int height)
        {
            return new RenderTarget2D(Device, width, height);
        }

        public void SetRenderTarget(RenderTarget2D target)
        {
            Device.SetRenderTarget(target);
        }

        public void Clear()
        {
            Clear(ClearColor);
        }

        public void Clear(Color color)
        {
            Device.Clear(color);
        }

        public int ViewWidth;
        public int ViewHeight;
    }



    //////////public class Graphics
    //////////{
    //////////    private bool _dirtyMatrix;
    //////////    private Matrix _scaleMatrix;

    //////////    //  The graphics device manager used to control the presentation of graphics.
    //////////    private GraphicsDeviceManager _manager;

    //////////    public GraphicsDeviceManager Manager
    //////////    {
    //////////        get { return _manager; }
    //////////    }

    //////////    //  The game window used to display the game.
    //////////    private GameWindow _window;

    //////////    // An action to execute when the graphics device is created.
    //////////    private Action _onDeviceCreated;

    //////////    //  An action to execute when the graphics device is reset.
    //////////    private Action _onDeviceReset;

    //////////    //  An action to execute after the client (window) size changes.
    //////////    private Action _onClientSizeChanged;

    //////////    //  A value indicating if the client (window) is currently resizing.
    //////////    private bool _isResizing;

    //////////    private Game _game;

    //////////    ////  The scale matrix value to use with the spritebatch when rendering a final 
    //////////    ////  render to the screen. Describes how to scale the render to accomodate the
    //////////    ////  virtual width and height with the backbuffer with and height.
    //////////    //private Matrix _scaleMatrix;

    //////////    ////  A value indicating if the scale matrix value is dirty and needs to be 
    //////////    ////  recalulated.
    //////////    //private bool _dirtyMatrix;

    //////////    /// <summary>
    //////////    ///     Gets the GraphicsDevice used to present graphics.
    //////////    /// </summary>
    //////////    public GraphicsDevice Device
    //////////    {
    //////////        get { return _manager.GraphicsDevice; }
    //////////    }

    //////////    /// <summary>
    //////////    ///     Gets the width in pixels of the backbuffer. This is also 1:1 with the
    //////////    ///     window width.
    //////////    /// </summary>
    //////////    public int BackBufferWidth { get; private set; }

    //////////    /// <summary>
    //////////    ///     Gets the height in pixels of the backbuffer.  This is also 1:1 with the
    //////////    ///     window height
    //////////    /// </summary>
    //////////    public int BackBufferHeight { get; private set; }

    //////////    /// <summary>
    //////////    ///     Gets the virtual width in pixels.  This is the width that everything shoudl
    //////////    ///     be rendered to and concered with in game logic before rendering to the screen.
    //////////    ///     When rendering to the screen, use the ScaleMatrix in the spritebatch.
    //////////    /// </summary>
    //////////    public int VirtualWidth { get; private set; }

    //////////    /// <summary>
    //////////    ///     Gets the virtual height in pixels.  This is the height that everything should
    //////////    ///     be rendrered to and concerned with in game logic before rendering to the screen.
    //////////    ///     When rendering to the screen, use the ScaleMatrix in the spritebatch.
    //////////    /// </summary>
    //////////    public int VirtualHeight { get; private set; }

    //////////    public float VirtualAspectRatio
    //////////    {
    //////////        get
    //////////        {
    //////////            return (float)VirtualWidth / (float)VirtualHeight;
    //////////        }
    //////////    }

    //////////    /// <summary>
    //////////    ///     Gets a value indicating if the graphics are currently rendering in fullscreen mode.
    //////////    /// </summary>
    //////////    public bool Fullscreen { get; private set; }

    //////////    /// <summary>
    //////////    ///     Gets the scale matrix to apply to the spritebatch when rendering to scale the virtual
    //////////    ///     render to the actual render resolution.
    //////////    /// </summary>
    //////////    public Matrix ScaleMatrix
    //////////    {
    //////////        get
    //////////        {
    //////////            if (_dirtyMatrix)
    //////////            {
    //////////                RecreateScaleMatrix();
    //////////            }

    //////////            return _scaleMatrix;
    //////////        }
    //////////    }

    //////////    public Color ClearColor { get; set; }

    //////////    internal Graphics(Game game)
    //////////    {
    //////////        _game = game;
    //////////        _window = game.Window;
    //////////        ClearColor = Color.Black;
    //////////    }

    //////////    internal void Initialize(int backbufferWidth,
    //////////                             int backbufferHeight,
    //////////                             int virtualWidth,
    //////////                             int virtualHeight,
    //////////                             Action onGraphicsCreated = null,
    //////////                             Action onGraphicsReset = null,
    //////////                             Action onCientSizeChanged = null)
    //////////    {

    //////////        BackBufferWidth = backbufferWidth > 0 ? backbufferWidth
    //////////           : throw new ArgumentOutOfRangeException("The backbuffer width must be greater than zero", nameof(backbufferWidth));

    //////////        BackBufferHeight = backbufferHeight > 0 ? backbufferHeight
    //////////            : throw new ArgumentOutOfRangeException("The backbuffer height must be greater than zero", nameof(backbufferHeight));

    //////////        VirtualWidth = virtualWidth > 0 ? virtualWidth
    //////////            : throw new ArgumentOutOfRangeException("The virtual width must be greater than zero", nameof(virtualWidth));

    //////////        VirtualHeight = virtualHeight > 0 ? virtualHeight
    //////////            : throw new ArgumentOutOfRangeException("The virtual height must be greater than zero", nameof(virtualHeight));

    //////////        _manager = new GraphicsDeviceManager(_game);

    //////////        _onDeviceCreated = onGraphicsCreated;
    //////////        _onDeviceReset = onGraphicsReset;

    //////////        _manager.DeviceCreated += DeviceCreated;
    //////////        _manager.DeviceReset += DeviceReset;
    //////////        _manager.SynchronizeWithVerticalRetrace = true;
    //////////        _manager.PreferMultiSampling = false;
    //////////        _manager.GraphicsProfile = GraphicsProfile.HiDef;
    //////////        _manager.PreferredBackBufferFormat = SurfaceFormat.Color;
    //////////        _manager.PreferredDepthStencilFormat = DepthFormat.Depth24Stencil8;

    //////////        _window.AllowUserResizing = false;
    //////////        _window.ClientSizeChanged += ClientSizeChanged;

    //////////        _dirtyMatrix = true;

    //////////        SetResolution(backbufferWidth, backbufferHeight, false);
    //////////        SetVirtualResolution(virtualWidth, virtualHeight);
    //////////    }

    //////////    private void DeviceCreated(object sender, EventArgs e)
    //////////    {

    //////////    }

    //////////    private void DeviceReset(object sender, EventArgs e)
    //////////    {

    //////////    }

    //////////    private void ClientSizeChanged(object sender, EventArgs e)
    //////////    {

    //////////    }



    //////////    public void SetResolution(int width, int height, bool fullScreen)
    //////////    {
    //////////        BackBufferWidth = width;
    //////////        BackBufferHeight = height;
    //////////        Fullscreen = fullScreen;
    //////////        ApplyResolutionSettings();
    //////////    }

    //////////    public void SetVirtualResolution(int width, int height)
    //////////    {
    //////////        VirtualWidth = width;
    //////////        VirtualHeight = height;
    //////////        _dirtyMatrix = true;
    //////////    }

    //////////    private void ApplyResolutionSettings()
    //////////    {
    //////////        //  If we aren't using fullscreen mode, the width and height of the window can be set
    //////////        //  to anything equal to or smaller than the actual screen size
    //////////        if (!Fullscreen)
    //////////        {
    //////////            if (BackBufferWidth <= GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width &&
    //////////               BackBufferHeight <= GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height)
    //////////            {
    //////////                _manager.PreferredBackBufferWidth = BackBufferWidth;
    //////////                _manager.PreferredBackBufferHeight = BackBufferHeight;
    //////////                _manager.IsFullScreen = Fullscreen;
    //////////                _manager.ApplyChanges();
    //////////            }
    //////////        }
    //////////        else
    //////////        {
    //////////            //  If we are using fullscreen mode, we should check to make sure that the display 
    //////////            //  adapter can handle the video mode we are trying to set.  To do this, we will
    //////////            //  iterate through the display modes supported by the adapter and check them
    //////////            //  against the mode we want to set
    //////////            foreach (DisplayMode mode in GraphicsAdapter.DefaultAdapter.SupportedDisplayModes)
    //////////            {
    //////////                //  Check the width and height of each mode against the backbuffer width and height
    //////////                if (mode.Width == BackBufferWidth && mode.Height == BackBufferHeight)
    //////////                {
    //////////                    //  The mode is supported, so set the buffer formats, apply changes, and return
    //////////                    _manager.PreferredBackBufferWidth = BackBufferWidth;
    //////////                    _manager.PreferredBackBufferHeight = BackBufferHeight;
    //////////                    _manager.IsFullScreen = Fullscreen;
    //////////                    _manager.ApplyChanges();
    //////////                }
    //////////            }
    //////////        }

    //////////        _dirtyMatrix = true;

    //////////        BackBufferWidth = _manager.PreferredBackBufferWidth;
    //////////        BackBufferHeight = _manager.PreferredBackBufferHeight;
    //////////    }

    //////////    private void RecreateScaleMatrix()
    //////////    {
    //////////        _dirtyMatrix = false;
    //////////        _scaleMatrix = Matrix.CreateScale(
    //////////            xScale: (float)_manager.GraphicsDevice.Viewport.Width / VirtualWidth,
    //////////            yScale: (float)_manager.GraphicsDevice.Viewport.Height / VirtualHeight,
    //////////            zScale: 1.0f);
    //////////    }

    //////////    public void FullViewport()
    //////////    {
    //////////        Viewport vp = new Viewport();
    //////////        vp.X = vp.Y = 0;
    //////////        vp.Width = VirtualWidth;
    //////////        vp.Height = VirtualWidth;
    //////////        _manager.GraphicsDevice.Viewport = vp;
    //////////    }

    //////////    public void ResetViewport()
    //////////    {
    //////////        float targetAspectRatio = VirtualAspectRatio;

    //////////        //  figure out the largest area that fits in this resolution at the desired aspect ratio
    //////////        int width = _manager.PreferredBackBufferWidth;
    //////////        int height = (int)(width / targetAspectRatio /*+ 0.5f*/);
    //////////        bool changed = false;

    //////////        if (height > _manager.PreferredBackBufferHeight)
    //////////        {
    //////////            height = _manager.PreferredBackBufferHeight;
    //////////            //  Pillerbox
    //////////            width = (int)(height * targetAspectRatio /*+ 0.5f*/);
    //////////            changed = true;
    //////////        }

    //////////        //  Setup the new viewport centered in the backbuffer
    //////////        Viewport viewport = new Viewport();

    //////////        viewport.X = (_manager.PreferredBackBufferWidth / 2) - (width / 2);
    //////////        viewport.Y = (_manager.PreferredBackBufferHeight / 2) - (height / 2);
    //////////        viewport.Width = width;
    //////////        viewport.Height = height;
    //////////        viewport.MinDepth = 0;
    //////////        viewport.MaxDepth = 0;

    //////////        if (changed)
    //////////        {
    //////////            _dirtyMatrix = true;
    //////////        }

    //////////        _manager.GraphicsDevice.Viewport = viewport;
    //////////    }

    //////////    public void SetRenderTarget(RenderTarget2D target)
    //////////    {
    //////////        Device.SetRenderTarget(target);
    //////////    }

    //////////    public void Clear()
    //////////    {
    //////////        Clear(ClearColor);
    //////////    }

    //////////    public void Clear(Color color)
    //////////    {
    //////////        Device.Clear(color);
    //////////    }
    //////////}
















    /////////// <summary>
    ///////////     Utility class used for manging and controlling the presentation of graphics.
    /////////// </summary>
    ////////public class Graphics
    ////////{
    ////////    // --------------------------------------------------------------------
    ////////    //  Game 

    ////////    //  Cached reference to the Game object.
    ////////    private Game _game;

    ////////    // --------------------------------//-----------------------------------


    ////////    // --------------------------------------------------------------------
    ////////    //  Game Window

    ////////    //  A value indicating if the game window is currently in the middle of a resize operation.
    ////////    private bool _isResizing;

    ////////    //  Cached reference to the game window.
    ////////    private GameWindow _window;

    ////////    // --------------------------------//-----------------------------------


    ////////    // --------------------------------------------------------------------
    ////////    //  Actions

    ////////    //  An action to invoke when the graphics device is created.
    ////////    private Action _onGraphicsDeviceCreated;

    ////////    //  An action to invoke when the graphics device is reset.
    ////////    private Action _onGraphicsDeviceReset;

    ////////    //  An action to invoke when the game window client size is changed.
    ////////    private Action _onClientSizeChanged;

    ////////    // --------------------------------//-----------------------------------


    ////////    // --------------------------------------------------------------------
    ////////    //  Scale Matrix 

    ////////    //  A value indicating that the scale matrix needs to be recalculated.
    ////////    private bool _dirtyMatrix;

    ////////    //  A matrix value representing the scale to use when rendering graphics to the screen.
    ////////    private Matrix _scaleMatrix;

    ////////    /// <summary>
    ////////    ///     Gets the scale matrix to apply to the spritebatch when rendering to scale the virtual render
    ////////    ///     to the actual render resolution.
    ////////    /// </summary>
    ////////    public Matrix ScaleMatrix
    ////////    {
    ////////        get
    ////////        {
    ////////            if (_dirtyMatrix)
    ////////            {
    ////////                RecreateScaleMatrix();
    ////////            }

    ////////            return _scaleMatrix;
    ////////        }
    ////////    }

    ////////    // --------------------------------//-----------------------------------

    ////////    // --------------------------------------------------------------------
    ////////    //  Graphics Device Manager

    ////////    /// <summary>
    ////////    ///     Gets the <see cref="GraphicsDeviceManager"/> instance used to control the
    ////////    ///     presentation of graphics.
    ////////    /// </summary>
    ////////    public GraphicsDeviceManager Manager { get; private set; }

    ////////    // --------------------------------//-----------------------------------

    ////////    // --------------------------------------------------------------------
    ////////    //  Graphics Device

    ////////    /// <summary>
    ////////    ///     Gets the <see cref="GraphicsDevice"/> used to present graphics.
    ////////    /// </summary>
    ////////    public GraphicsDevice Device => Manager.GraphicsDevice;

    ////////    // --------------------------------//-----------------------------------

    ////////    // --------------------------------------------------------------------
    ////////    //  Resolutions

    ////////    /// <summary>
    ////////    ///     Gets the <see cref="Size"/> component representing the width and height of
    ////////    ///     the backbuffer.
    ////////    /// </summary>
    ////////    public Size Resolution { get; private set; }

    ////////    /// <summary>
    ////////    ///     Gets the <see cref="Size"/> component representing the widht and height of
    ////////    ///     the virtual resolution.
    ////////    /// </summary>
    ////////    public Size VirtualResolution { get; private set; }

    ////////    /// <summary>
    ////////    ///     Gets a value representing the aspect ratio of the virtual resolution.
    ////////    /// </summary>
    ////////    public float VirtualAspectRatio => (float)VirtualResolution.Width / (float)VirtualResolution.Height;

    ////////    // --------------------------------//-----------------------------------


    ////////    // --------------------------------------------------------------------
    ////////    //  Presentation

    ////////    /// <summary>
    ////////    ///     Gets a value indicating if the graphics are currently rendering in fullscreen mode.
    ////////    /// </summary>
    ////////    public bool Fullscreen { get; private set; }

    ////////    /// <summary>
    ////////    ///     Gets or Sets the <see cref="Color"/> value to use when clearing the backbuffer.
    ////////    /// </summary>
    ////////    public Color ClearColor { get; set; }

    ////////    // --------------------------------//-----------------------------------


    ////////    /// <summary>
    ////////    ///     Creates a new <see cref="Graphics"/> instance.
    ////////    /// </summary>
    ////////    /// <param name="game">
    ////////    ///     The <see cref="Game"/> instance this is for.
    ////////    /// </param>
    ////////    internal Graphics(Game game)
    ////////    {
    ////////        _game = game;
    ////////        _window = game.Window;
    ////////        ClearColor = Color.Black;
    ////////    }

    ////////    /// <summary>
    ////////    ///     Initilzies the <see cref="Graphics"/>
    ////////    /// </summary>
    ////////    /// <param name="backBufferWidth">
    ////////    ///    A value representing the backbuffer width in pixels.
    ////////    /// </param>
    ////////    /// <param name="backBufferHeight">
    ////////    ///     A value representing the backbuffer height in pixels.
    ////////    /// </param>
    ////////    /// <param name="virtualWidth">
    ////////    ///     A value representing the virtual resolution width in pixels.
    ////////    /// </param>
    ////////    /// <param name="virtualHeight">
    ////////    ///     A value representing the virtual resolution height in pixels.
    ////////    /// </param>
    ////////    /// <param name="onGraphicsDeviceCreated">
    ////////    ///     A action to invoke when the graphics device is created.
    ////////    /// </param>
    ////////    /// <param name="onGraphicsDeviceReset">
    ////////    ///     A action to invoke when teh graphics device is reset.
    ////////    /// </param>
    ////////    /// <param name="onClientsizeChanged">
    ////////    ///     A action to invoke when the game client window size is changed.
    ////////    /// </param>
    ////////    /// <returns>
    ////////    ///     This <see cref="Graphics"/> instance.
    ////////    /// </returns>
    ////////    internal Graphics Initialize(int backBufferWidth,
    ////////                                 int backBufferHeight,
    ////////                                 int virtualWidth,
    ////////                                 int virtualHeight,
    ////////                                 Action onGraphicsDeviceCreated = null,
    ////////                                 Action onGraphicsDeviceReset = null,
    ////////                                 Action onClientsizeChanged = null)
    ////////    {
    ////////        if (backBufferWidth <= 0)
    ////////        {
    ////////            throw new ArgumentOutOfRangeException("backBufferWidth", "The backbuffer width must be greater than zero!");
    ////////        }

    ////////        if (backBufferHeight <= 0)
    ////////        {
    ////////            throw new ArgumentOutOfRangeException("backBufferHeight", "The backbuffer height must be greater than zero!");
    ////////        }

    ////////        if (virtualWidth <= 0)
    ////////        {
    ////////            throw new ArgumentOutOfRangeException("virtualWidth", "The virtual width must be greater than zero!");
    ////////        }

    ////////        if (virtualHeight <= 0)
    ////////        {
    ////////            throw new ArgumentOutOfRangeException("virtualHeight", "The virtual height must be greater than zero!");
    ////////        }

    ////////        Resolution = new Size(backBufferWidth, backBufferHeight);
    ////////        VirtualResolution = new Size(virtualWidth, virtualHeight);

    ////////        Manager = new GraphicsDeviceManager(_game);

    ////////        _onGraphicsDeviceCreated = onGraphicsDeviceCreated;
    ////////        _onGraphicsDeviceReset = onGraphicsDeviceReset;
    ////////        _onClientSizeChanged = onClientsizeChanged;

    ////////        Manager.DeviceCreated += OnDeviceCreated;
    ////////        Manager.DeviceReset += OnDeviceReset;
    ////////        Manager.SynchronizeWithVerticalRetrace = true;
    ////////        Manager.PreferMultiSampling = false;
    ////////        Manager.GraphicsProfile = GraphicsProfile.HiDef;
    ////////        Manager.PreferredBackBufferFormat = SurfaceFormat.Color;
    ////////        Manager.PreferredDepthStencilFormat = DepthFormat.Depth24Stencil8;


    ////////        _window.AllowUserResizing = false;
    ////////        _window.ClientSizeChanged += OnClientSizeChanged;

    ////////        _dirtyMatrix = true;

    ////////        SetResolution(backBufferWidth, backBufferHeight, false);
    ////////        SetVirtualResolution(virtualWidth, virtualHeight);

    ////////        return this;
    ////////    }

    ////////    /// <summary>
    ////////    ///     Called when the graphics device is created.
    ////////    /// </summary>
    ////////    private void OnDeviceCreated(object sender, EventArgs e)
    ////////    {
    ////////        if (_onGraphicsDeviceCreated != null)
    ////////        {
    ////////            _onGraphicsDeviceCreated();
    ////////        }
    ////////    }

    ////////    /// <summary>
    ////////    ///     Called when the graphics device is reset. When this occurs, all contents of  VRAM are wiped.
    ////////    /// </summary>
    ////////    private void OnDeviceReset(object sender, EventArgs e)
    ////////    {
    ////////        if (_onGraphicsDeviceReset != null)
    ////////        {
    ////////            _onGraphicsDeviceReset();
    ////////        }
    ////////    }

    ////////    /// <summary>
    ////////    ///     Called when the width and/or height of the game window are changed.
    ////////    /// </summary>
    ////////    private void OnClientSizeChanged(object sender, EventArgs e)
    ////////    {
    ////////        if (_onClientSizeChanged != null)
    ////////        {
    ////////            _onClientSizeChanged();
    ////////        }
    ////////    }

    ////////    /// <summary>
    ////////    ///     Given a width and height, sets the base resolution of the game.
    ////////    /// </summary>
    ////////    /// <param name="width">
    ////////    ///     A value representing the width of the base resolution.
    ////////    /// </param>
    ////////    /// <param name="height">
    ////////    ///     A value representing the height of the base resolution.
    ////////    /// </param>
    ////////    /// <param name="fullscreen">
    ////////    ///     Should the graphics be displayed in fullscreen mode.
    ////////    /// </param>
    ////////    public void SetResolution(int width, int height, bool fullscreen = false)
    ////////    {
    ////////        Resolution = new Size(width, height);
    ////////        Fullscreen = fullscreen;
    ////////        ApplyResolutionChanges();
    ////////    }

    ////////    /// <summary>
    ////////    ///     Given a width and height, sets the virtual resolution of the game.
    ////////    /// </summary>
    ////////    /// <param name="width">
    ////////    ///     A value represetning the width of the virtual resolution.
    ////////    /// </param>
    ////////    /// <param name="height">
    ////////    ///     A value representing the height of the virtual resolution.
    ////////    /// </param>
    ////////    public void SetVirtualResolution(int width, int height)
    ////////    {
    ////////        VirtualResolution = new Size(width, height);
    ////////        _dirtyMatrix = true;
    ////////    }

    ////////    /// <summary>
    ////////    ///     Applies any changes set for the resolution.
    ////////    /// </summary>
    ////////    private void ApplyResolutionChanges()
    ////////    {

    ////////        // If we aren't using a full screen mode, the height and width of the window can
    ////////        // be set to anything equal to or smaller than the actual screen size.
    ////////        if (Fullscreen == false)
    ////////        {
    ////////            if ((Resolution.Width <= GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width)
    ////////                && (Resolution.Height <= GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height))
    ////////            {
    ////////                Manager.PreferredBackBufferWidth = Resolution.Width;
    ////////                Manager.PreferredBackBufferHeight = Resolution.Height;
    ////////                Manager.IsFullScreen = Fullscreen;
    ////////                Manager.ApplyChanges();
    ////////            }
    ////////        }
    ////////        else
    ////////        {
    ////////            // If we are using full screen mode, we should check to make sure that the display
    ////////            // adapter can handle the video mode we are trying to set.  To do this, we will
    ////////            // iterate through the display modes supported by the adapter and check them against
    ////////            // the mode we want to set.
    ////////            foreach (DisplayMode dm in GraphicsAdapter.DefaultAdapter.SupportedDisplayModes)
    ////////            {
    ////////                // Check the width and height of each mode against the passed values
    ////////                if ((dm.Width == Resolution.Width) && (dm.Height == Resolution.Height))
    ////////                {
    ////////                    // The mode is supported, so set the buffer formats, apply changes and return
    ////////                    Manager.PreferredBackBufferWidth = Resolution.Width;
    ////////                    Manager.PreferredBackBufferHeight = Resolution.Height;
    ////////                    Manager.IsFullScreen = Fullscreen;
    ////////                    Manager.ApplyChanges();
    ////////                }
    ////////            }
    ////////        }

    ////////        _dirtyMatrix = true;

    ////////        Resolution = new Size()
    ////////        {
    ////////            Width = Manager.PreferredBackBufferWidth,
    ////////            Height = Manager.PreferredBackBufferHeight
    ////////        };
    ////////    }

    ////////    /// <summary>
    ////////    ///     Recalcualtes the matrix for scale.
    ////////    /// </summary>
    ////////    private void RecreateScaleMatrix()
    ////////    {
    ////////        _dirtyMatrix = false;
    ////////        _scaleMatrix = Matrix.CreateScale(
    ////////            xScale: (float)Manager.GraphicsDevice.Viewport.Width / VirtualResolution.Width,
    ////////            yScale: (float)Manager.GraphicsDevice.Viewport.Height / VirtualResolution.Height,
    ////////            zScale: 1.0f);
    ////////    }

    ////////    /// <summary>
    ////////    ///     Sets the <see cref="Viewport"/> of the <see cref="GraphicsDevice"/> to full
    ////////    ///     virtual resolution.
    ////////    /// </summary>
    ////////    public void FullViewport()
    ////////    {
    ////////        Viewport vp = new Viewport();
    ////////        vp.X = vp.Y = 0;
    ////////        vp.Width = VirtualResolution.Width;
    ////////        vp.Height = VirtualResolution.Height;
    ////////        Manager.GraphicsDevice.Viewport = vp;
    ////////    }

    ////////    /// <summary>
    ////////    ///     Resets the <see cref="Viewport"/> of the <see cref="GraphicsDevice"/>
    ////////    /// </summary>
    ////////    public void ResetViewport()
    ////////    {
    ////////        float targetAspectRatio = VirtualAspectRatio;

    ////////        // figure out the largest area that fits in this resolution at the desired aspect ratio
    ////////        int width = Manager.PreferredBackBufferWidth;
    ////////        int height = (int)(width / targetAspectRatio + .5f);
    ////////        bool changed = false;

    ////////        if (height > Manager.PreferredBackBufferHeight)
    ////////        {
    ////////            height = Manager.PreferredBackBufferHeight;
    ////////            // PillarBox
    ////////            width = (int)(height * targetAspectRatio + .5f);
    ////////            changed = true;
    ////////        }

    ////////        // set up the new viewport centered in the backbuffer
    ////////        Viewport viewport = new Viewport();

    ////////        viewport.X = (Manager.PreferredBackBufferWidth / 2) - (width / 2);
    ////////        viewport.Y = (Manager.PreferredBackBufferHeight / 2) - (height / 2);
    ////////        viewport.Width = width;
    ////////        viewport.Height = height;
    ////////        viewport.MinDepth = 0;
    ////////        viewport.MaxDepth = 1;

    ////////        if (changed)
    ////////        {
    ////////            _dirtyMatrix = true;
    ////////        }

    ////////        Manager.GraphicsDevice.Viewport = viewport;
    ////////    }

    ////////    /// <summary>
    ////////    ///     Given a <see cref="RenderTarget2D"/> instance, sets this as the render target
    ////////    ///     for the graphics device.
    ////////    /// </summary>
    ////////    /// <param name="target"></param>
    ////////    public void SetRenderTarget(RenderTarget2D target) => Device.SetRenderTarget(target);

    ////////    /// <summary>
    ////////    ///     Clears the backbuffer using the value of <see cref="Graphics.ClearColor"/>
    ////////    /// </summary>
    ////////    public void Clear() => Clear(ClearColor);

    ////////    /// <summary>
    ////////    ///     Given a color, clears the backbuffer.
    ////////    /// </summary>
    ////////    /// <param name="color">
    ////////    ///     The color value to apply when clearing the backbuffer.
    ////////    /// </param>
    ////////    public void Clear(Color color) => Device.Clear(color);
    ////////}
}
