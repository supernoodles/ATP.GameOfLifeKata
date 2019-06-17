namespace ATP.GameOfLifeKata.Source
{
    public class Row
    {
        protected bool Equals(Row other)
        {
            var rowsAreEqual = true;

            for (var i = 0; i < _row.Length; i++)
            {
                rowsAreEqual &= _row[i] == other._row[i];
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
            return (_row != null ? _row.GetHashCode() : 0);
        }

        private bool[] _row;

        public Row(bool[,]source, int columnIndex)
        {
            _row = new bool[source.GetUpperBound(0)];

            for (int i = 0; i < source.GetUpperBound(0); i++)
            {
                _row[i] = source[i, columnIndex];
            }
        }
    }
}