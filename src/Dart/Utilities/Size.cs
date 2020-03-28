using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Dart
{
    [DataContract(Name = "Size")]
    public struct Size : IEquatable<Size>
    {

        /// <summary>
        ///     Gets a new <see cref="Size"/> component with a Width and Height of (0, 0)
        /// </summary>
        public static Size Zero
        {
            get
            {
                return new Size(0, 0);
            }
        }

        /// <summary>
        ///     Gets a new <see cref="Size"/> component with a Width and Height of (1, 1)
        /// </summary>
        public static Size One
        {
            get
            {
                return new Size(1, 1);
            }
        }

        /// <summary>
        ///     A value representing the Width part of this <see cref="Size"/> component.
        /// </summary>
        [DataMember(Name = "Width")]
        public int Width;

        /// <summary>
        ///     A value representing the Height part of this <see cref="Size"/> component.
        /// </summary>
        [DataMember(Name = "Height")]
        public int Height;

        /// <summary>
        ///     Creates a new <see cref="Size"/> component instance with a Width and Height
        ///     of the specified value.
        /// </summary>
        /// <param name="value">
        ///     The value to specifiy for the Width and Height.
        /// </param>
        public Size(int value) : this(value, value) { }

        /// <summary>
        ///     Creates a new <see cref="Size"/> component instance with a Width and Height
        ///     of the specified values.
        /// </summary>
        /// <param name="width">
        ///     The value to specifiy for the Width.
        /// </param>
        /// <param name="height">
        ///     The value to specify for the Height.
        /// </param>
        public Size(int width, int height)
        {
            Width = width;
            Height = height;
        }

        /// <summary>
        ///     Deconstructs this <see cref="Size"/> component into its individual
        ///     Width and Height parts.
        /// </summary>
        /// <param name="width">
        ///     When this method returns, contains the value of the Width part of this
        ///     <see cref="Size"/> component.
        /// </param>
        /// <param name="height">
        ///     When this method returns, contains the value of the Height part of this
        ///     <see cref="Size"/> compoennt.
        /// </param>
        public void Deconstruct(out int width, out int height)
        {
            width = Width;
            height = Height;
        }

        /// <summary>
        ///     Gets a <see cref="Point"/> representation of this <see cref="Size"/> component.
        /// </summary>
        /// <returns>
        ///     A new <see cref="Point"/> component where the X and y parts are equal to the
        ///     Width and Height parts of this <see cref="Size"/> component respectivly.
        /// </returns>
        public Point ToPoint()
        {
            return new Point(this.Width, this.Height);
        }

        /// <summary>
        ///     Gets a <see cref="Vector2"/> representation of this <see cref="Size"/> component.
        /// </summary>
        /// <returns>
        ///     A new <see cref="Vector2"/> component where the X and Y parts are equal to the
        ///     Width and Height parts of this <see cref="Size"/> component respectivly.
        /// </returns>
        public Vector2 ToVector2()
        {
            return new Vector2(this.Width, this.Height);
        }


        /// <summary>
        ///     Compares whether the current <see cref="Size"/> component is equal to the
        ///     specified <see cref="Object"/>
        /// </summary>
        /// <param name="obj">
        ///     The <see cref="Object"/> to compare.
        /// </param>
        /// <returns>
        ///     True if the <see cref="Object"/> given is a <see cref="Size"/> component and if
        ///     the Width and Height parts of it and this are equal; otherwise, false.
        /// </returns>
        public override bool Equals(object obj)
        {
            return (obj is Size size) && Equals(size);
        }

        /// <summary>
        ///     Compares whether the current <see cref="Size"/> component is equal to the
        ///     specified <see cref="Size"/> component.
        /// </summary>
        /// <param name="other">
        ///     The <see cref="Size"/> component to compare.
        /// </param>
        /// <returns>
        ///     True if the specified <see cref="Size"/> compoennt's Width and Height parts
        ///     are equal to the parts of this <see cref="Size"/> component; otherwise, false.
        /// </returns>
        public bool Equals(Size other)
        {
            return this.Width == other.Width && 
                   this.Height == other.Height;
        }

        /// <summary>
        ///     Gets the hash code of this <see cref="Size"/> component;
        /// </summary>
        /// <returns>
        ///     The hash code of this <see cref="Size"/> component.
        /// </returns>
        public override int GetHashCode()
        {
            int hash = 13;
            hash = (hash * 7) + this.Width.GetHashCode();
            hash = (hash * 7) + this.Height.GetHashCode();
            return hash;
        }

        public override string ToString()
        {
            return $"Width: {this.Width}, Height: {this.Height}";
        }

        /// <summary>
        ///     Given two <see cref="Size"/> components, returns the sum of their
        ///     parts.
        /// </summary>
        /// <param name="value1">
        ///     The first <see cref="Size"/> component on the left of the addition sign
        /// </param>
        /// <param name="value2">
        ///     The second <see cref="Size"/> component on the right of the addition sign.
        /// </param>
        /// <returns>
        ///     A <see cref="Size"/> component which is the result of the addition of the two
        ///     sizes given.
        /// </returns>
        public static Size Add(Size value1, Size value2)
        {
            Size result;
            result.Width = value1.Width + value2.Width;
            result.Height = value1.Height + value2.Height;
            return result;
        }

        /// <summary>
        ///     Given two <see cref="Size"/> components, returns the difference of their
        ///     parts.
        /// </summary>
        /// <param name="value1">
        ///     The first <see cref="Size"/> component on the left of the subtraction sign.
        /// </param>
        /// <param name="value2">
        ///     The second <see cref="Size"/> comnponent on the right of the subtraction sign.
        /// </param>
        /// <returns>
        ///     A <see cref="Size"/> component which is the result of the difference of the two
        ///     sizes given.
        /// </returns>
        public static Size Subtract(Size value1, Size value2)
        {
            Size result;
            result.Width = value1.Width - value2.Width;
            result.Height = value1.Height - value2.Height;
            return result;
        }

        /// <summary>
        ///     Given two <see cref="Size"/> components, returns the multiplication of their parts.
        /// </summary>
        /// <param name="value1">
        ///     The first <see cref="Size"/> component on the left of the multiplcation sign.
        /// </param>
        /// <param name="value2">
        ///     The second <see cref="Size"/> component on the right of the multiplcation sign.
        /// </param>
        /// <returns>
        ///     A <see cref="Size"/> component whcih is the result of multipling the parts of
        ///     the two sizes given.
        /// </returns>
        public static Size Multiply(Size value1, Size value2)
        {
            Size result;
            result.Width = value1.Width * value2.Width;
            result.Height = value2.Height * value2.Height;
            return result;
        }

        /// <summary>
        ///     Given two <see cref="Size"/> components, returns the division of their parts.
        /// </summary>
        /// <param name="value1">
        ///     The first <see cref="Size"/> component on the left of the division sign.
        /// </param>
        /// <param name="value2">
        ///     The second <see cref="Size"/> component on the right of the division sign.
        /// </param>
        /// <returns>
        ///     A <see cref="Size"/> component whcih is the result of dividing the parts of
        ///     the two sizes given.
        /// </returns>
        public static Size Divide(Size value1, Size value2)
        {
            Size result;
            result.Width = value1.Width / value2.Width;
            result.Height = value1.Height / value2.Height;
            return result;
        }

        /// <summary>
        ///     Given a <see cref="Size"/> component and a power, returns the power its parts.
        /// </summary>
        /// <param name="size">
        ///     The <see cref="Size"/> component
        /// </param>
        /// <param name="pow">
        ///     The value to raise the componetns to.
        /// </param>
        /// <returns>
        ///     A <see cref="Size"/> compoennt raised to the power given.
        /// </returns>
        public static Size Pow(Size size, int pow)
        {
            Size result;
            result.Width = Convert.ToInt32(Math.Pow(size.Width, pow));
            result.Height = Convert.ToInt32(Math.Pow(size.Height, pow));
            return result;
        }

        /// <summary>
        ///     Adds the parts of the <see cref="Size"/> component on the left by the
        ///     parts of the <see cref="Size"/> component on the right.
        /// </summary>
        /// <param name="value1">
        ///     THe <see cref="Size"/> component on the left of the addition symbol.
        /// </param>
        /// <param name="value2">
        ///     The <see cref="Size"/> component on the right of the addition symbol.
        /// </param>
        /// <returns>
        ///     A <see cref="Size"/> component whos parts are the result of adding the parts
        ///     of the two sizes.
        /// </returns>
        public static Size operator +(Size value1, Size value2)
        {
            return Add(value1, value2);
        }

        /// <summary>
        ///     Subtracts the parts of the <see cref="Size"/> component on the left by the
        ///     parts of the <see cref="Size"/> component on the right.
        /// </summary>
        /// <param name="value1">
        ///     THe <see cref="Size"/> component on the left of the subtraction symbol.
        /// </param>
        /// <param name="value2">
        ///     The <see cref="Size"/> component on the right of the subtraction symbol.
        /// </param>
        /// <returns>
        ///     A <see cref="Size"/> component whos parts are the result of subtracting the parts
        ///     of the two sizes.
        /// </returns>
        public static Size operator -(Size value1, Size value2)
        {
            return Subtract(value1, value2);
        }

        /// <summary>
        ///     Multiples the parts of the <see cref="Size"/> component on the left by the
        ///     parts of the <see cref="Size"/> component on the right.
        /// </summary>
        /// <param name="value1">
        ///     The <see cref="Size"/> component on the left of the multiplaction symbol.
        /// </param>
        /// <param name="value2">
        ///     The <see cref="Size"/> component on the right of the multiplcation symbol.
        /// </param>
        /// <returns>
        ///     A <see cref="Size"/> component whos parts are the result of multiplying the parts
        ///     of the two sizes.
        /// </returns>
        public static Size operator *(Size value1, Size value2)
        {
            return Multiply(value1, value2);
        }

        /// <summary>
        ///     Divides the parts of the <see cref="Size"/> component on the left by the 
        ///     parts of the <see cref="Size"/> component on the right
        /// </summary>
        /// <param name="value1">
        ///     The <see cref="Size"/> component on the left of the division symbol.
        /// </param>
        /// <param name="value2">
        ///     The <see cref="Size"/> component on the right of the division symbol.
        /// </param>
        /// <returns>
        ///     A <see cref="Size"/> component whos parts are the result of dividing the parts
        ///     of the two sizes.
        /// </returns>
        public static Size operator /(Size value1, Size value2)
        {
            return Divide(value1, value2);
        }

        /// <summary>
        ///     Raises the parts of the <see cref="Size"/> component to the power specified.
        /// </summary>
        /// <param name="size">
        ///     The <see cref="Size"/> component.
        /// </param>
        /// <param name="pow">
        ///     The power to raise it to.
        /// </param>
        /// <returns>
        ///     The <see cref="Size"/> component raised to the power specified.
        /// </returns>
        public static Size operator ^(Size size, int pow)
        {
            return Pow(size, pow);
        }

        /// <summary>
        ///     Compares the two <see cref="Size"/> components and returns if they are
        ///     equal.
        /// </summary>
        /// <param name="value1">
        ///     The first <see cref="Size"/> component.
        /// </param>
        /// <param name="value2">
        ///     The second <see cref="Size"/> component.
        /// </param>
        /// <returns>
        ///     True if the width and height parts of each <see cref="Size"/> component are
        ///     equal; otherwise, false.
        /// </returns>
        public static bool operator ==(Size value1, Size value2)
        {
            return value1.Equals(value2);
        }

        /// <summary>
        ///     Compares the two <see cref="Size"/> components and returns if they
        ///     do no equal each other.
        /// </summary>
        /// <param name="value1">
        ///     The first <see cref="Size"/> component.
        /// </param>
        /// <param name="value2">
        ///     The second <see cref="Size"/> component.
        /// </param>
        /// <returns>
        ///     True if the width or height parts of each <see cref="Size"/> compoent are
        ///     not equal; otherwise, false.
        /// </returns>
        public static bool operator !=(Size value1, Size value2)
        {
            return !value1.Equals(value2);
        }

        /// <summary>
        ///     Performs an implicit conversion of a <see cref="Point"/> component to a
        ///     <see cref="Size"/> component.
        /// </summary>
        /// <param name="point">
        ///     The <see cref="Point"/> component to convert.
        /// </param>
        public static implicit operator Size(Point point)
        {
            return new Size(point.X, point.Y);
        }

        /// <summary>
        ///     Performs an implicit conversion of a <see cref="Size"/> compoennt to a
        ///     <see cref="Point"/> component.
        /// </summary>
        /// <param name="size">
        ///     The <see cref="Size"/> component to convert.
        /// </param>
        public static implicit operator Point(Size size)
        {
            return new Point(size.Width, size.Height);
        }

        /// <summary>
        ///     Performs an implicit conversion of a <see cref="Vector2"/> component to 
        ///     a <see cref="Size"/> component.
        /// </summary>
        /// <param name="vector2">
        ///     The <see cref="Vector2"/> component to convert.
        /// </param>
        public static implicit operator Size(Vector2 vector2)
        {
            return new Size((int)Math.Floor(vector2.X), (int)Math.Floor(vector2.Y));
        }

        /// <summary>
        ///     Performs an implicit conversion of a <see cref="Size"/> component to 
        ///     a <see cref="Vector2"/> component.
        /// </summary>
        /// <param name="size">
        ///     The <see cref="Size"/> component to convert.
        /// </param>
        public static implicit operator Vector2(Size size)
        {
            return new Vector2(size.Width, size.Height);
        }
    }
}
