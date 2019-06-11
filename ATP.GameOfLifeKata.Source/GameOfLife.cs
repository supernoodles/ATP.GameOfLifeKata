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
            if (_seed != null)
            {
                return false;
            }
            return true;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return Equals((GameOfLife)obj);
        }
    }
}