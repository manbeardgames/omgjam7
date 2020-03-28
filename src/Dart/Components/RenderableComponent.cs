using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Dart
{
    public class RenderableComponent : Component, IRenderableComponent
    {
        //  A value indicating if this component is visible.
        private bool _visibe;

        //  The xy-coordinate position of the render realitve to the position of the gameobject
        //  it is attached too.
        private Vector2 _position = Vector2.Zero;

        //  The xy-coordinate origin point of the render.
        private Vector2 _origin = Vector2.Zero;

        //  The x and y scale values for the render.
        private Vector2 _scale = Vector2.One;

        //  The rotation value.
        private float _rotation = 0.0f;

        //  The alpha transparency value.
        private float _alpha = 1.0f;

        //  The color maske value ot use when rendering.
        private Color _color = Color.White;

        //  The SpriteEffects to use when rendering.
        private SpriteEffects _spriteEffects = SpriteEffects.None;

        //  A value that indicates the order in which this component shoudl be rendered
        //  compared with other components.  The smaller the value, the earlier this component
        //  is rendered.
        private int _drawOrder;

        /// <summary>
        ///     Gets or Sets a value indicating if this component is visible.
        /// </summary>
        public bool Visible
        {
            get => _visibe;
            set
            {
                if (_visibe == value) { return; }
                _visibe = value;
                VisibleChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        /// <summary>
        ///     Gets or Sets a value indicating the order in which this component should be 
        ///     rendered compared with other components.  The smaller the value, the earlier this
        ///     component is rendered.
        /// </summary>
        public int DrawOrder
        {
            get => _drawOrder;
            set
            {
                if (_drawOrder == value) { return; }
                _drawOrder = value;
                DrawOrderChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        /// <summary>
        ///     Gets or Sets the xy-coordinate position of the render relative to the xy-coordinate
        ///     position of the GameObject this component is attached too.
        /// </summary>
        public Vector2 Position
        {
            get => _position;
            set => _position = value;
        }

        /// <summary>
        ///     Gets or Sets the x-coordinate position of the render realtive to the x-coordinate
        ///     position of the GameObject this component is attached too.
        /// </summary>
        public float X
        {
            get => _position.X;
            set
            {
                if (_position.X == value) { return; }
                _position.X = value;
            }
        }

        /// <summary>
        ///     Gets or Sets the y-coordinate position of the rneder relative to the y-coordinate
        ///     position of the GameObject this component is attached too.
        /// </summary>
        public float Y
        {
            get => _position.Y;
            set
            {
                if (_position.Y == value) { return; }
                _position.Y = value;
            }
        }

        /// <summary>
        ///     Gets or Sets the xy-coordinate origin point of the render.
        /// </summary>
        public Vector2 Origin
        {
            get => _origin;
            set
            {
                if (_origin.Equals(value)) { return; }
                _origin = value;
            }
        }

        /// <summary>
        ///     Gets or Sets the x-coordinate origin positin.
        /// </summary>
        public float OriginX
        {
            get { return _origin.X; }
            set
            {
                if (_origin.X.Equals(value)) { return; }
                _origin.X = value;
            }
        }

        /// <summary>
        ///     Gets or Sets the y-coordinate origin position.
        /// </summary>
        public float OriginY
        {
            get { return _origin.Y; }
            set
            {
                if (_origin.Y.Equals(value)) { return; }
                _origin.Y = value;
            }
        }

        /// <summary>
        ///     Gets or Sets the x and y scale values;s
        /// </summary>
        public Vector2 Scale
        {
            get => _scale;
            set
            {
                if (_scale.Equals(value)) { return; }
                _scale = value;
            }
        }

        /// <summary>
        ///     Gets or Sets the x scale value.
        /// </summary>
        public float ScaleX
        {
            get => _scale.X;
            set
            {
                if (_scale.X.Equals(value)) { return; }
                _scale.X = value;
            }
        }

        /// <summary>
        ///     Gets or Sets the y scale value.
        /// </summary>
        public float ScaleY
        {
            get => _scale.Y;
            set
            {
                if (_scale.Y.Equals(value)) { return; }
                _scale.Y = value;
            }
        }

        /// <summary>
        ///     Gets or Sets the rotation value.
        /// </summary>
        public float Rotation
        {
            get => _rotation;
            set
            {
                if (_rotation.Equals(value)) { return; }
                _rotation = value;
            }
        }

        /// <summary>
        ///     Gets or Sets the color mask value.
        /// </summary>
        public Color Color
        {
            get => _color;
            set
            {
                if (_color.Equals(value)) { return; }
                _color = value;
            }
        }

        /// <summary>
        ///     Gets or Sets the alpha transparency value.
        /// </summary>
        public float Alpha
        {
            get => _alpha;
            set
            {
                if (_alpha.Equals(value)) { return; }
                _alpha = value;
                if (_alpha < 0.0f) { _alpha = 0.0f; }
                else if (_alpha > 1.0f) { _alpha = 1.0f; }
            }
        }

        /// <summary>
        ///     Gets or Sets the SpriteEffect to use when rendering
        /// </summary>
        public SpriteEffects SpriteEffects
        {
            get => _spriteEffects;
            set
            {
                if (_spriteEffects.Equals(value)) { return; }
                _spriteEffects = value;
            }
        }

        /// <summary>
        ///     Gets or Sets if the render should be flipped on the Horizontal Axis.
        /// </summary>
        public bool FlipHorizontally
        {
            get { return (_spriteEffects & SpriteEffects.FlipHorizontally) == SpriteEffects.FlipHorizontally; }
            set { _spriteEffects = value ? (_spriteEffects | SpriteEffects.FlipHorizontally) : (_spriteEffects & ~SpriteEffects.FlipHorizontally); }
        }

        /// <summary>
        ///     Gets or Sets if the render should be flipped on the Vertical Axis.
        /// </summary>
        public bool FlipVertically
        {
            get { return (_spriteEffects & SpriteEffects.FlipVertically) == SpriteEffects.FlipVertically; }
            set { _spriteEffects = value ? (_spriteEffects | SpriteEffects.FlipVertically) : (_spriteEffects & ~SpriteEffects.FlipVertically); }
        }

        /// <summary>
        ///     Gets or Sets the xy-coordinate position to render at.  
        /// </summary>
        public Vector2 RenderPosition
        {
            get
            {
                if (GameObject == null) { return Position; }
                else { return GameObject.Transform.Position + Position; }
            }
            set
            {
                if (GameObject == null) { Position = value; }
                else { Position = value - GameObject.Transform.Position; }
            }
        }


        /// <summary>
        ///     Invoked when the Visible property has changed.
        /// </summary>
        public event EventHandler<EventArgs> VisibleChanged;

        /// <summary>
        ///     Invoked when the DrawOrder proeprty has changed.
        /// </summary>
        public event EventHandler<EventArgs> DrawOrderChanged;

        /// <summary>
        ///     Creates a new RenderableComponent.
        /// </summary>
        /// <param name="gameObject">
        ///     The GameObject this RenderableComponent is attached to.
        /// </param>
        public RenderableComponent() : base() { }

        /// <summary>
        ///     Renders this component.
        /// </summary>
        public virtual void Render() { }

        /// <summary>
        ///     Renders this component in a debug state.
        /// </summary>
        public virtual void DebugRender() { }

        public virtual void Refresh() { }
    }
}
