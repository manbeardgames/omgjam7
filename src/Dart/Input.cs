using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

namespace Dart
{
    public static class Input
    {
        /// <summary>
        ///     Gets the data for the keyboard.
        /// </summary>
        public static KeyboardData Keyboard { get; private set; }
        
        /// <summary>
        ///     Gets the data for the mouse.
        /// </summary>
        public static MouseData Mouse { get; private set; }

        /// <summary>
        ///     Initializes the input system.
        /// </summary>
        internal static void Initialize()
        {
            Keyboard = new KeyboardData();
            Mouse = new MouseData();
        }

        /// <summary>
        ///     Updates the input system.
        /// </summary>
        internal static void Update()
        {
            Keyboard.Update();
            Mouse.Update();
        }

        public class KeyboardData
        {
            private KeyboardState _currentState;
            private KeyboardState _previousState;

            /// <summary>
            ///     Creates a new <see cref="KeyboardData"/> instance.
            /// </summary>
            public KeyboardData()
            {
                _currentState = new KeyboardState();
                _previousState = new KeyboardState();
            }

            /// <summary>
            ///     Updates the snapshot values of the keyboard data.
            /// </summary>
            public void Update()
            {
                //  Cache the previous state
                _previousState = _currentState;

                //  Update the current state
                _currentState = Microsoft.Xna.Framework.Input.Keyboard.GetState();
            }

            /// <summary>
            ///     Given a keyboard <see cref="Keys"/> value, checks to see if that keybaord
            ///     key is down on the current frame.
            /// </summary>
            /// <param name="key">
            ///     The keyboard <see cref="Keys"/> value to check.
            /// </param>
            /// <returns>
            ///     true if the key is down on the current frame; otherwise, false.
            /// </returns>
            public bool IsDown(Keys key) => _currentState.IsKeyDown(key);

            /// <summary>
            ///     Given two keyboard <see cref="Keys"/> values, checks to see if any of them
            ///     are down on the current frame.
            /// </summary>
            /// <param name="keyA">
            ///     The first keyboard <see cref="Keys"/> value to check.
            /// </param>
            /// <param name="keyB">
            ///     The second keyboard <see cref="Keys"/> value to check.
            /// </param>
            /// <returns>
            ///     true if either of the keys are down on the current frame; otherwise false.
            /// </returns>
            public bool AreAnyDown(Keys keyA, Keys keyB) => IsDown(keyA) || IsDown(keyB);

            /// <summary>
            ///     Given three keyboard <see cref="Keys"/> values, checks to see if any of them
            ///     are down on the current frame.
            /// </summary>
            /// <param name="keyA">
            ///     The first keyboard <see cref="Keys"/> value to check.
            /// </param>
            /// <param name="keyB">
            ///     The second keyboard <see cref="Keys"/> value to check.
            /// </param>>
            /// <param name="keyC">
            ///     The third keyboard <see cref="Keys"/> value to check.
            /// </param>
            /// <returns>
            ///     true if either of the keys are down on the current frame; otherwise false.
            /// </returns>
            public bool AreAnyDown(Keys keyA, Keys keyB, Keys keyC) => IsDown(keyA) || IsDown(keyB) || IsDown(keyC);


            /// <summary>
            ///     Given four keyboard <see cref="Keys"/> values, checks to see if any of them
            ///     are down on the current frame.
            /// </summary>
            /// <param name="keyA">
            ///     The first keyboard <see cref="Keys"/> value to check.
            /// </param>
            /// <param name="keyB">
            ///     The second keyboard <see cref="Keys"/> value to check.
            /// </param>>
            /// <param name="keyC">
            ///     The third keyboard <see cref="Keys"/> value to check.
            /// </param>
            /// <param name="keyD">
            ///     The fourth keyboard <see cref="Keys"/> value to check.
            /// </param>
            /// <returns>
            ///     true if either of the keys are down on the current frame; otherwise false.
            /// </returns>
            public bool AreAnyDown(Keys keyA, Keys keyB, Keys keyC, Keys keyD) => IsDown(keyA) || IsDown(keyB) || IsDown(keyC) || IsDown(keyD);

            /// <summary>
            ///     Given a keyboard <see cref="Keys"/> value, returns if the key was just pressed
            ///     on the current frame.  For a key to be qualified as pressed, it must be down on the
            ///     current frame and up on the previous frame.
            /// </summary>
            /// <param name="key">
            ///     The keyboard <see cref="Keys"/> value to check.
            /// </param>
            /// <returns>
            ///     true if the key was pressed on the current frame; otherwise, false.
            /// </returns>
            public bool WasPressed(Keys key) => _currentState.IsKeyDown(key) && _previousState.IsKeyUp(key);

            /// <summary>
            ///     Given two keyboard <see cref="Keys"/> values, returns if either of them were just
            ///     pressed on the current frame.  For a key to be qualified as pressed, it must be down
            ///     on the current frame and up on the previous frame.
            /// </summary>
            /// <param name="keyA">
            ///     The first keyboard <see cref="Keys"/> value to check.
            /// </param>
            /// <param name="keyB">
            ///     The second keyboard <see cref="Keys"/> value to check.
            /// </param>>
            /// <returns>
            ///     true if either of the keys were pressed on the current frame; otherwise, false.
            /// </returns>
            public bool WereAnyPressed(Keys keyA, Keys keyB) => WasPressed(keyA) || WasPressed(keyB);

            /// <summary>
            ///     Given three keyboard <see cref="Keys"/> values, returns if either of them were just
            ///     pressed on the current frame.  FOr a key to be qualified as pressed, it must be down
            ///     on the current frame and up on the previous frame.
            /// </summary>
            /// <param name="keyA">
            ///     The first keyboard <see cref="Keys"/> value to check.
            /// </param>
            /// <param name="keyB">
            ///     The second keyboard <see cref="Keys"/> value to check.
            /// </param>>
            /// <param name="keyC">
            ///     The third keyboard <see cref="Keys"/> value to check.
            /// </param>
            /// <returns>
            ///     true if either of the keys were pressed on the current frame; otherwise, false.
            /// </returns>
            public bool WereAnyPressed(Keys keyA, Keys keyB, Keys keyC) => WasPressed(keyA) || WasPressed(keyB) || WasPressed(keyC);

            /// <summary>
            ///     Given four keyboard <see cref="Keys"/> values, returns if either of them were just
            ///     pressed on the current frame.  For a key to be qualified as pressed, it must be down
            ///     on the current frame and up on the previous frame.
            /// </summary>
            /// <param name="keyA">
            ///     The first keyboard <see cref="Keys"/> value to check.
            /// </param>
            /// <param name="keyB">
            ///     The second keyboard <see cref="Keys"/> value to check.
            /// </param>>
            /// <param name="keyC">
            ///     The third keyboard <see cref="Keys"/> value to check.
            /// </param>
            /// <param name="keyD">
            ///     The fourth keyboard <see cref="Keys"/> value to check.
            /// </param>
            /// <returns>
            ///     true if either of the keys were pressed on the current frame; otherwise, false.
            /// </returns>
            public bool WereAnyPressed(Keys keyA, Keys keyB, Keys keyC, Keys keyD) => WasPressed(keyA) || WasPressed(keyB) || WasPressed(keyC) || WasPressed(keyD);

            /// <summary>
            ///     Given a keyboard <see cref="Keys"/> value, returns if the key was just released
            ///     on the current frame.  For a key to be qualified as released, it must be up on
            ///     the current frame and down on the previous frame.
            /// </summary>
            /// <param name="key">
            ///     The keyboard <see cref="Keys"/> value to check.
            /// </param>
            /// <returns>
            ///     true if the key was just released on the current frame; otherwise, false.
            /// </returns>
            public bool WasReleased(Keys key) => _currentState.IsKeyUp(key) && _previousState.IsKeyDown(key);

            /// <summary>
            ///     Given two keyboard <see cref="Keys"/> values, returns if either of the keyws were
            ///     just released on the current frame.  FOr a key to be qualifie das released, it must be up
            ///     on the current frame and down on the previous frame.
            /// </summary>
            /// <param name="keyA">
            ///     The first keyboard <see cref="Keys"/> value to check.
            /// </param>
            /// <param name="keyB">
            ///     The second keyboard <see cref="Keys"/> value to check.
            /// </param>
            /// <returns>
            ///     true if either of the keys were just released on the current frame; otherwise, false.
            /// </returns>
            public bool WereAnyRelease(Keys keyA, Keys keyB) => WasReleased(keyA) || WasReleased(keyB);

            /// <summary>
            ///     Given three keyboard <see cref="Keys"/> values, returns if either of the keyws were
            ///     just released on the current frame.  FOr a key to be qualifie das released, it must be up
            ///     on the current frame and down on the previous frame.
            /// </summary>
            /// <param name="keyA">
            ///     The first keyboard <see cref="Keys"/> value to check.
            /// </param>
            /// <param name="keyB">
            ///     The second keyboard <see cref="Keys"/> value to check.
            /// </param>
            /// <param name="keyC">
            ///     The third keyboard <see cref="Keys"/> value to check.
            /// </param>
            /// <returns>
            ///     true if either of the keys were just released on the current frame; otherwise, false.
            /// </returns
            public bool WereAnyRelease(Keys keyA, Keys keyB, Keys keyC) => WasReleased(keyA) || WasReleased(keyB) || WasReleased(keyC);

            /// <summary>
            ///     Given three keyboard <see cref="Keys"/> values, returns if either of the keyws were
            ///     just released on the current frame.  FOr a key to be qualifie das released, it must be up
            ///     on the current frame and down on the previous frame.
            /// </summary>
            /// <param name="keyA">
            ///     The first keyboard <see cref="Keys"/> value to check.
            /// </param>
            /// <param name="keyB">
            ///     The second keyboard <see cref="Keys"/> value to check.
            /// </param>
            /// <param name="keyC">
            ///     The third keyboard <see cref="Keys"/> value to check.
            /// </param>
            /// <param name="keyD">
            ///     The third keyboard <see cref="Keys"/> value to check.
            /// </param>
            /// <returns>
            ///     true if either of the keys were just released on the current frame; otherwise, false.
            /// </returns
            public bool WereAnyRelease(Keys keyA, Keys keyB, Keys keyC, Keys keyD) => WasReleased(keyA) || WasReleased(keyB) || WasReleased(keyC) || WasReleased(keyD);


        }

        public class MouseData
        {
            private MouseState _currentState;
            private MouseState _previousState;

            public int ScrollWheel => _currentState.ScrollWheelValue;
            public int ScrollWheelDelta => _currentState.ScrollWheelValue - _previousState.ScrollWheelValue;

            public bool WasMoved => _currentState.X != _previousState.X || _currentState.Y != _previousState.Y;
            public float X
            {
                get => Position.X;
                set => Position = new Vector2(value, Position.Y);
            }
            public float Y
            {
                get => Position.Y;
                set => Position = new Vector2(Position.X, value);
            }
            public Vector2 Position
            {
                get => Vector2.Transform(new Vector2(_currentState.X, _currentState.Y), Matrix.Invert(Engine.Graphics.ScaleMatrix));
                set
                {
                    var vector = Vector2.Transform(value, Engine.Graphics.ScaleMatrix);
                    Microsoft.Xna.Framework.Input.Mouse.SetPosition((int)Math.Round(vector.X), (int)Math.Round(vector.Y));
                }
            }


            public MouseData()
            {
                _currentState = new MouseState();
                _previousState = new MouseState();
            }

            public void Update()
            {
                _previousState = _currentState;
                _currentState = Microsoft.Xna.Framework.Input.Mouse.GetState();
            }

            public bool IsLeftButtonDown => _currentState.LeftButton == ButtonState.Pressed;
            public bool WasLeftButtonPressed => _currentState.LeftButton == ButtonState.Pressed && _previousState.LeftButton == ButtonState.Released;
            public bool WasLeftButtonReleased => _currentState.LeftButton == ButtonState.Released && _previousState.LeftButton == ButtonState.Pressed;

            public bool IsRightButtonDown => _currentState.RightButton == ButtonState.Pressed;
            public bool WasRightButtonPressed => _currentState.RightButton == ButtonState.Pressed && _previousState.RightButton == ButtonState.Released;
            public bool WasRightButtonRelased => _currentState.RightButton == ButtonState.Released && _previousState.RightButton == ButtonState.Pressed;

            public bool IsMiddleButtonDown => _currentState.MiddleButton == ButtonState.Pressed;
            public bool WasMiddleButtonPressed => _currentState.MiddleButton == ButtonState.Pressed && _previousState.MiddleButton == ButtonState.Released;
            public bool WasMiddleButtonReleased => _currentState.MiddleButton == ButtonState.Released && _previousState.MiddleButton == ButtonState.Pressed;
        }
    }
}
