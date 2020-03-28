using Microsoft.Xna.Framework;

namespace Dart
{
    /// <summary>
    ///     Utility class to update and provide snapshot values of the game timing
    ///     state for each frame.
    /// </summary>
    public class Time
    {
        /// <summary>
        ///     Gets the snapshot of the game timing state at the beginning of the
        ///     current update frame.
        /// </summary>
        public GameTime CurrentGameTime { get; private set; }

        /// <summary>
        ///     Gets the snapshot of the game timing state at the beginnign of the
        ///     previous update frame.
        /// </summary>
        public GameTime PreviousGameTime { get; private set; }

        /// <summary>
        ///     Gets the delta time in seconds between the beginning of the current
        ///     update frame, and the beginning of the previous update frame. This value
        ///     is affected by <see cref="Time.TimeRate"/>
        /// </summary>
        public float DeltaTime { get; private set; }

        /// <summary>
        ///     Gets the absolute delta time in seconds between the beginning of the 
        ///     current update fame and the beginning of the previousupdate frame.
        /// </summary>
        public float RawDeltaTime { get; private set; }

        /// <summary>
        ///     Gets or Sets a value that affects the rate of time for calculating the
        ///     <see cref="Time.DeltaTime"/>
        /// </summary>
        public float TimeRate { get; set; }

        /// <summary>
        ///     Creats a new <see cref="Time"/> instance.
        /// </summary>
        public Time()
        {
            TimeRate = 1.0f;
        }

        /// <summary>
        ///     Given the <see cref="Microsoft.Xna.Framework.GameTime"/> instance
        ///     at the beginning of the current update frame, updates the snapshot values
        ///     for this instance.
        /// </summary>
        /// <param name="gameTime">
        ///     The <see cref="Microsoft.Xna.Framework.GameTime"/> instance at the beginning
        ///     of the current update frame.
        /// </param>
        public void Update(GameTime gameTime)
        {
            //  Cache the previous gametime snapshot
            PreviousGameTime = CurrentGameTime;

            //  Set the current gametime snapshot
            CurrentGameTime = gameTime;

            //  Calculate the raw delta time
            RawDeltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            //  Calcualt the delta time
            DeltaTime = RawDeltaTime * TimeRate;
        }
    }
}
