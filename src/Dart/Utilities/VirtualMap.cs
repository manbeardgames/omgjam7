using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dart.Utilities
{
    public class VirtualMap<T>
    {
        public const int SEGMENT_SIZE = 50;

        private T[,][,] _segments;

        public int Columns { get; }
        public int Rows { get; }
        public int SegmentColumns { get; }
        public int SegmentRows { get; }
        public readonly T EmptyValue;

        public T this[int x, int y]
        {
            get
            {
                int cx = x / SEGMENT_SIZE;
                int cy = y / SEGMENT_SIZE;

                var seg = _segments[cx, cy];
                if (seg == null) { return EmptyValue; }

                return seg[x - cx * SEGMENT_SIZE, y - cy * SEGMENT_SIZE];
            }

            set
            {
                int cx = x / SEGMENT_SIZE;
                int cy = y / SEGMENT_SIZE;

                if(_segments[cx, cy] == null)
                {
                    _segments[cx, cy] = new T[SEGMENT_SIZE, SEGMENT_SIZE];

                    //  Fill with custom empty value data
                    if(EmptyValue != null && !EmptyValue.Equals(default(T)))
                    {
                        for(int tx = 0; tx < SEGMENT_SIZE; tx++)
                        {
                            for(int ty = 0; ty < SEGMENT_SIZE; ty++)
                            {
                                _segments[cx, cy][tx, ty] = EmptyValue;
                            }
                        }
                    }
                }

                _segments[cx, cy][x - cx * SEGMENT_SIZE, y - cy * SEGMENT_SIZE] = value;
            }
        }

        public VirtualMap(int columns, int rows, T emptyValue = default(T))
        {
            Columns = columns;
            Rows = rows;
            SegmentColumns = (columns / SEGMENT_SIZE) + 1;
            SegmentRows = (rows / SEGMENT_SIZE) + 1;
            _segments = new T[SegmentColumns, SegmentRows][,];
            EmptyValue = emptyValue;
        }

        public VirtualMap(T[,] map, T emptyValue = default(T)) : this(map.GetLength(0), map.GetLength(1), emptyValue)
        {
            for (int x = 0; x < Columns; x++)
            {
                for (int y = 0; y < Rows; y++)
                {
                    this[x, y] = map[x, y];
                }
            }
        }

        public bool AnyInSegmentAtTile(int x, int y)
        {
            int cx = x / SEGMENT_SIZE;
            int cy = y / SEGMENT_SIZE;

            return _segments[cx, cy] != null;
        }

        public bool AnyInSegment(int segmentX, int segmentY)
        {
            return _segments[segmentX, segmentY] != null;
        }

        /// <summary>
        ///     Returns the value in segment 
        /// </summary>
        /// <param name="segmentX"></param>
        /// <param name="segmentY"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public T InSegment(int segmentX, int segmentY, int x, int y)
        {
            return _segments[segmentX, segmentY][x, y];
        }

        /// <summary>
        ///     Gets the Segment at x and y
        /// </summary>
        /// <param name="segmentX"></param>
        /// <param name="segmentY"></param>
        /// <returns></returns>
        public T[,] GetSegment(int segmentX, int segmentY)
        {
            return _segments[segmentX, segmentY];
        }

        /// <summary>
        ///     Safely gets the value of this virtual map at x and y.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public T SafeCheck(int x, int y)
        {
            if (x >= 0 && y >= 0 && x < Columns && y < Rows)
            {
                return this[x, y];
            }
            return EmptyValue;
        }

        /// <summary>
        ///     Converts this VirtualMap to a T[,] array.
        /// </summary>
        /// <returns></returns>
        public T[,] ToArray()
        {
            var array = new T[Columns, Rows];
            for(int x = 0; x < Columns; x++)
            {
                for(int y = 0; y < Rows; y++)
                {
                    array[x, y] = this[x, y];
                }
            }
            return array;
        }

        /// <summary>
        ///     Performs a deep clone of this virtual map and returns it.
        /// </summary>
        /// <returns>
        ///     The clone of this VirtualMap instance.
        /// </returns>
        public VirtualMap<T> Clone()
        {
            var clone = new VirtualMap<T>(Columns, Rows, EmptyValue);
            for(int x = 0; x < Columns; x++)
            {
                for (int y = 0; y < Rows; y++)
                {
                    clone[x, y] = this[x, y];
                }
            }
            return clone;
        }

    }
}
