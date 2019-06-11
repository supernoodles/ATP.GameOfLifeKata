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

            if (_seed[1, 1] && other._seed[1, 1])
            {
                return true;
            }

            return Equals(_seed, other._seed);
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