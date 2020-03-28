using Microsoft.Xna.Framework;

namespace Dart
{
    /// <summary>
    ///     A component used to describe the position, scale, and rotation of a GameObject.
    /// </summary>
    public class RectTransform2DComponent : Component
    {
        //  The xy-coordinate position
        private Vector2 _position;

        //  The x and y scale
        private Vector2 _scale;

        /// <summary>
        ///     Gets or Sets the xy-coordinate position.
        /// </summary>
        public Vector2 Position
        {
            get => _position;
            set => _position = value;
        }

        /// <summary>
        ///     Gets or Sets the x-coordinate position.
        /// </summary>
        public float X
        {
            get => _position.X;
            set => _position.X = value;
        }

        /// <summary>
        ///     Gets or Sets the y-coordinate position
        /// </summary>
        public float Y
        {
            get => _position.Y;
            set => _position.Y = value;
        }

        /// <summary>
        ///     Gets or Sets the x and y scale values.
        /// </summary>
        public Vector2 Scale
        {
            get => _scale;
            set => _scale = value;
        }

        /// <summary>
        ///     Gets or Sets the x scale value.
        /// </summary>
        public float ScaleX
        {
            get => _scale.X;
            set => _scale.X = value;
        }

        /// <summary>
        ///     Gets or Sets the y scale value.
        /// </summary>
        public float ScaleY
        {
            get => _scale.Y;
            set => _scale.Y = value;
        }

        /// <summary>
        ///     Gets or Sets the rotation along the z-axis.
        /// </summary>
        public float Rotation { get; set; }

        /// <summary>
        ///     Creates a new RectTransform2DComponent instance.
        /// </summary>
        public RectTransform2DComponent() : this(Vector2.Zero, Vector2.One, 0.0f) { }

        /// <summary>
        ///     Creates a new RectTransform2DComponent instance.
        /// </summary>
        /// <param name="position">
        ///     The xy-coordinate position value.
        /// </param>
        public RectTransform2DComponent(Vector2 position) : this(position, Vector2.One, 0.0f) { }

        /// <summary>
        ///     Creates a new RectTransform2DComponent instance.
        /// </summary>
        /// <param name="position">
        ///     The xy-coordinate position value.
        /// </param>
        /// <param name="scale">
        ///     The x and y scale value.
        /// </param>
        public RectTransform2DComponent(Vector2 position, Vector2 scale) : this(position, scale, 0.0f) { }

        /// <summary>
        ///     Creates a new RectTransform2DComponent instnace.
        /// </summary>
        /// <param name="position">
        ///     The xy-coordinate position value.
        /// </param>
        /// <param name="scale">
        ///     The x and y scale value.
        /// </param>
        /// <param name="rotation">
        ///     The rotation value.
        /// </param>
        public RectTransform2DComponent(Vector2 position, Vector2 scale, float rotation)
        {
            Position = position;
            Scale = scale;
            Rotation = rotation;
        }
    }
}
