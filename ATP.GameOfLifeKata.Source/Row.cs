namespace ATP.GameOfLifeKata.Source
{
    using System;

    public class Row
    {
        protected bool Equals(Row other)
        {
            var rowsAreEqual = true;

            for (var i = 0; i < _row.Length; i++)
            {
                rowsAreEqual &= _row[i] == other._row[i];

                if (_row[i] != other._row[i])
                {
                    Console.WriteLine($"Diff at {i}");
                }
            }

            return rowsAreEqual;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Row) obj);
        }

        public override int GetHashCode()
        {
            return _row != null ? _row.GetHashCode() : 0;
        }

        private readonly bool[] _row;

        public Row(bool[,]source, int rowIndex)
        {
            _row = new bool[source.GetUpperBound(0)];

            for (var columnIndex = 0; columnIndex < source.GetUpperBound(1); columnIndex++)
            {
                _row[columnIndex] = source[rowIndex, columnIndex];
            }
        }
    }
}