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

    public sealed class GameOfLife
    {
        private readonly bool[,] _seed;

        public GameOfLife(bool[,] seed = null)
        {
            _seed = seed;
        }

        public void Tick()
        {
        }

        private bool Equals(GameOfLife other)
        {
            if (_seed == null && other._seed == null)
            {
                return true;
            }

            if (_seed == null || other._seed == null)
            {
                return false;
            }

            var gamesAreEqual = true;

            for (var i = 0; i < _seed.GetUpperBound(1); i++)
            {
                var row = new Row(_seed, i);
                var otherRow = new Row(other._seed,i);

                gamesAreEqual &= row.Equals(otherRow);
            }

            return gamesAreEqual;
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || obj is GameOfLife other && Equals(other);
        }

        public override int GetHashCode()
        {
            return (_seed != null 
                ? _seed.GetHashCode() 
                : 0);
        }
    }
}