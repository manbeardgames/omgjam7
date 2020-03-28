namespace Dart
{
    public class Grid<T>
    {
        /// <summary>
        ///     Gets an [,] array contianing the values of the cells within
        ///     this grid.
        /// </summary>
        public T[,] Cells { get; private set; }

        /// <summary>
        ///     Gets a value representing the total number of rows in this grid.
        /// </summary>
        public int Rows { get; }

        /// <summary>
        ///     Gets a value representing the total number of columns in this grid.
        /// </summary>
        public int Columns { get; }

        /// <summary>
        ///     Gets a value that indicates an empty cell value.
        /// </summary>
        public T EmptyValue { get; }

        /// <summary>
        ///     Give a column and row, gets the value of that cell in this grid.
        /// </summary>
        /// <param name="column">
        ///     The column of the cell.
        /// </param>
        /// <param name="row">
        ///     The row of the cell.
        /// </param>
        /// <returns>
        ///     The value of the cell at the given column and row.
        /// </returns>
        public T this[int column, int row]
        {
            get
            {
                return Cells[column, row];
            }
            set
            {
                Cells[column, row] = value;
            }
        }

        public T this[int gid]
        {
            get
            {
                int column = gid % Columns;
                int row = gid / Columns;
                return this[column, row];
            }

            set
            {
                int column = gid % Columns;
                int row = gid / Columns;
                this[column, row] = value;
            }
        }

        /// <summary>
        ///     Creates a new GridComponent instance.
        /// </summary>
        /// <param name="columns">
        ///     The total number of columns in this grid.
        /// </param>
        /// <param name="rows">
        ///     The total number of rows in this grid.
        /// </param>
        /// <param name="emptyValue">
        ///     A value to use when a cell in this grid is empty.
        /// </param>
        public Grid(int columns, int rows, T emptyValue = default(T))
        {
            Columns = columns;
            Rows = rows;
            EmptyValue = emptyValue;

            Cells = new T[columns, rows];
            for (int c = 0; c < columns; c++)
            {
                for (int r = 0; r < rows; r++)
                {
                    Cells[c, r] = emptyValue;
                }
            }
        }

        /// <summary>
        ///     Given the column and row of a cell, returns the value of the
        ///     cell within this grid.  If the given column and/or row does not
        ///     exist, returns the EmptyValue.
        /// </summary>
        /// <param name="column">
        ///     The column of the cell.
        /// </param>
        /// <param name="row">
        ///     The row of the cell.
        /// </param>
        /// <returns>
        ///     The value of the cell at the given column and row, if it exists; 
        ///     otherwise the EmptyValue property is returned.
        /// </returns>
        public T SafeCellValue(int column, int row)
        {
            if (column > 0 && column < Columns && row > 0 && row < Rows)
            {
                return this[column, row];
            }

            return EmptyValue;
        }

        public int GetGID(int column, int row) => (row * Columns) + column;

        public int GetRow(int gid) => gid / Columns;
        public int GetColumn(int gid) => gid % Columns;


    }
}
