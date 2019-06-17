namespace ATP.GameOfLifeKata.Source
{
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

            return GamesAreEqual(other);
        }

        private bool GamesAreEqual(GameOfLife other)
        {
            var gamesAreEqual = true;

            for (var i = 0; i < _seed.GetUpperBound(1); i++)
            {
                var row = new Row(_seed, i);
                var otherRow = new Row(other._seed, i);

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