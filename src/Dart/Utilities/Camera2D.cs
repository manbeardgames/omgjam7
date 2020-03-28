using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dart
{
    public class Camera2D
    {
        //  The matrix that describes the tranformation of our camera.
        private Matrix _transformationMatrix = Matrix.Identity;

        //  The inverse of our transformation matrix.
        private Matrix _inverseMatrix = Matrix.Identity;

        //  The top-left xy-coordinate position of our camera.
        private Vector2 _position = Vector2.Zero;

        //  The rotation of the camera along the z-axis.
        private float _rotation = 0.0f;

        //  The x and y zoom level of the camera.
        private float _zoom = 0.1f;

        //  The xy-coordinate origin point of the camera.
        private Vector2 _origin = Vector2.Zero;

        //  A value indicating if the position, rotation, zoom, and/or origin of the camera has changed.
        private bool _changed;

        /// <summary>
        ///     The <see cref="Microsoft.Xna.Framework.Graphics.Viewport"/> reference of the camera.
        /// </summary>
        public Viewport Viewport;

        /// <summary>
        ///     Gets the camera's transformation matrix.
        /// </summary>
        public Matrix TransformationMatrix
        {
            get
            {
                if (_changed)
                {
                    UpdateMatrices();
                }

                return _transformationMatrix;
            }
        }

        /// <summary>
        ///     Gets the inverse of the camer's tranformation matrix.
        /// </summary>
        public Matrix InverseMatrix
        {
            get
            {
                if (_changed)
                {
                    UpdateMatrices();
                }

                return _inverseMatrix;
            }
        }

        /// <summary>
        ///     Gets or Sets the top-left xy-coordinate position of the camera.
        /// </summary>
        public Vector2 Position
        {
            get { return _position; }
            set
            {
                //  If the value hasn't actually changed, just return back
                if (_position == value) { return; }

                //  Update the position.
                _position = value;

                //  Mark that there has been a change.
                _changed = true;
            }
        }

        /// <summary>
        ///     Gets or Sets the left x-coordinate position of the camera.
        /// </summary>
        public float X
        {
            get { return _position.X; }
            set
            {
                //  If the value hasn't changed, just return back
                if (_position.X == value) { return; }

                //  Update the x position value
                _position.X = value;

                //  Mark that there has been a change
                _changed = true;
            }
        }

        /// <summary>
        ///     Gets or Sets the top y-coordinate position of the camera.
        /// </summary>
        public float Y
        {
            get { return _position.Y; }
            set
            {
                //  If the value hasn't changed, just return back
                if (_position.Y == value) { return; }

                //  Update the y position of the camera
                _position.Y = value;

                //  Mark that there is a change
                _changed = true;
            }
        }

        /// <summary>
        ///     Gets or Sets the rotation of the camera along the z-axis.
        /// </summary>
        public float Rotation
        {
            get { return _rotation; }
            set
            {
                //  If the value hasn't changed, just return back
                if (_rotation == value) { return; }

                //  Update the rotation value
                _rotation = value;

                //  Mark that there has been a change
                _changed = true;

            }
        }

        /// <summary>
        ///     Gets or Sets the x and y zoom level for the camera.
        /// </summary>
        public float Zoom
        {
            get { return _zoom; }
            set
            {
                //  If the value hasn't changed, just return back
                if (_zoom == value) { return; }

                //  Update the zoom value
                _zoom = value;

                //  Mark that there has been a change.
                _changed = true;
            }
        }

        /// <summary>
        ///     Gets or Sets the xy-coordiante origin of the camera.
        /// </summary>
        public Vector2 Origin
        {
            get { return _origin; }
            set
            {
                //  If the value hasn't changed, just return back.
                if (_origin == value) { return; }

                //  Update the origin value
                _origin = value;

                //  Mark that there has been a change
                _changed = true;

            }
        }



        /// <summary>
        ///     Creates a new <see cref="Camera2D"/> instance.
        /// </summary>
        /// <param name="viewPort">
        ///     The <see cref="Viewport"/> refrence for the camera.
        /// </param>
        public Camera2D(Viewport viewPort)
        {
            Viewport = viewPort;
        }

        /// <summary>
        ///     Creates a new <see cref="Camera2D"/> instance.
        /// </summary>
        /// <param name="size">
        ///     The size of the camera's viewport, in pixels.
        /// </param>
        public Camera2D(Size size) : this(size.Width, size.Height) { }

        /// <summary>
        ///     Creates a new <see cref="Camera2D"/> instance.
        /// </summary>
        /// <param name="width">
        ///     The width of the camera's viewport, in pixels.
        /// </param>
        /// <param name="height">
        ///     The height of the camera's viewport, in pixels.
        /// </param>
        public Camera2D(int width, int height)
        {
            Viewport = new Viewport(0, 0, width, height);
        }

        /// <summary>
        ///     Updates the values for the transofmration matrix and inverse matrix
        /// </summary>
        private void UpdateMatrices()
        {
            //  Create the translation matrix based on the position of the camera
            var positionTranslationMatrix = Matrix.CreateTranslation(new Vector3()
            {
                X = -(int)Math.Floor(_position.X),
                Y = -(int)Math.Floor(_position.Y),
                Z = 0.0f
            });

            //  Create the rotation matrix around the z-axis
            Matrix rotationMatrix = Matrix.CreateRotationZ(_rotation);

            //  Create the scale matrix based on the zoom level
            Matrix scaleMatrix = Matrix.CreateScale(new Vector3()
            {
                X = _zoom,
                Y = _zoom,
                Z = 1.0f
            });

            //  Create a translation matrix based on the origin position of the camera
            Matrix originTranslationMatrix = Matrix.CreateTranslation(new Vector3()
            {
                X = (int)Math.Floor(_origin.X),
                Y = (int)Math.Floor(_origin.Y),
                Z = 0.0f
            });

            //  Perform matrix multiplcation using the matrices we've created to get the final tranformation matrix.
            //  The order of operation here is important. It must be in order of position * rotation * scale * origin
            _transformationMatrix = positionTranslationMatrix * rotationMatrix * scaleMatrix * originTranslationMatrix;

            //  Get the inverse of the transformation matrix
            _inverseMatrix = Matrix.Invert(_transformationMatrix);

            //  Since the matrices have been updated, mark that there is no longer a change
            _changed = false;
        }

        /// <summary>
        ///     Given a screen space xy-coordiante position, translates it to world space coordiantes
        ///     and returns it back.
        /// </summary>
        /// <param name="position">
        ///     The xy-coordinate position in screen space.
        /// </param>
        /// <returns>
        ///     The equivilant xy-coordinate position in world space.
        /// </returns>
        public Vector2 ScreenToWorld(Vector2 position) => Vector2.Transform(position, InverseMatrix);

        /// <summary>
        ///     Given a world space xy-coordiante position, translates it to screen space coordinates
        ///     and returns it back.
        /// </summary>
        /// <param name="position">
        ///     The xy-coordinate position in world space.
        /// </param>
        /// <returns>
        ///     The equivilant xy-coordinate position in screen space.
        /// </returns>
        public Vector2 WorldToScreen(Vector2 position) => Vector2.Transform(position, TransformationMatrix);
    }
}
