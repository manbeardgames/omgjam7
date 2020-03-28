using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dart
{
    public static class Maths
    {
        /// <summary>
        ///     Given two xy-coordinate positions, calcualtes and returns the angle
        ///     between them.
        /// </summary>
        /// <param name="from">
        ///     The starting xy-coordiate position.
        /// </param>
        /// <param name="to">
        ///     The ending xy-coordinate position.
        /// </param>
        /// <returns>
        ///     A value representing the angle between two points.
        /// </returns>
        public static float Angle(Vector2 from, Vector2 to)
        {
            return (float)Math.Atan2(to.Y - from.Y, to.X - from.X);
        }

        /// <summary>
        ///     Calculates the magnitude of a vector.
        /// </summary>
        /// <param name="vector">
        ///     The vector to calcualte the magnitude of
        /// </param>
        /// <returns>
        ///     The magnitude of the vector.
        /// </returns>
        public static float Magnitude(this Vector2 vector)
        {
            return (float)Math.Sqrt((vector.X * vector.X) + (vector.Y * vector.Y));
         
        }

        /// <summary>
        ///     Moves one Vector2 toward another Vector2.
        /// </summary>
        /// <param name="current">
        ///     The Vector2 to move.
        /// </param>
        /// <param name="target">
        ///     The target Vector2 coordinates.
        /// </param>
        /// <param name="delta">
        ///     The amount of movement.
        /// </param>
        /// <returns></returns>
        public static Vector2 MoveTowards(Vector2 current, Vector2 target, float delta)
        {
            Vector2 diff = target - current;
            float magnitude = diff.Magnitude();

            if(magnitude <= delta || magnitude == 0.0f)
            {
                return target;
            }

            return current + ((diff / magnitude) * delta);
        }

        public static int Mod(int value, int mod) => ((value % mod) + mod) % mod;
        
    }
}
