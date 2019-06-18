namespace ATP.GameOfLifeKata.Source
{
    public sealed class GameOfLife
    {
        private sealed class Position
        {
            public Position(int row, int column)
            {
                Row = row;
                Column = column;
            }

            public int Row { get;}
            public int Column { get;}
        }

        private int CountLiveNeighbours(Position cell)
        {
            int count = 0;

            if (cell.Row - 1 >= 0 
                && cell.Column - 1 >= 0 
                && _seed[cell.Row - 1, cell.Column - 1])
            {
                count++;
            }

            if (cell.Row - 1 >= 0
                && _seed[cell.Row - 1, cell.Column])
            {
                count++;
            }

            if (cell.Row - 1 >= 0
                && cell.Column + 1 <= _seed.GetUpperBound(0) 
                && _seed[cell.Row - 1, cell.Column + 1])
            {
                count++;
            }


            if (cell.Column - 1 <= 0
                && _seed[cell.Row - 1, cell.Column + 1])
            {
                count++;
            }






            return count;


        }


        private  bool[,] _seed;

        public GameOfLife(bool[,] seed = null)
        {
            _seed = seed;
        }

        public void Tick()
        {
            if (_seed == null)
            {
                return;
            }

            if (_seed[0, 0] && _seed[1, 0] && _seed[0, 1] && _seed[1, 1] ||
                _seed[1, 1] && _seed[2, 1] && _seed[2, 2] && _seed[1, 2] ||
                _seed[0, 1] && _seed[0, 2] && _seed[1, 1] && _seed[1, 2])
            {
                return;
            }

            var dimension = _seed.GetUpperBound(0);
            _seed = new bool[dimension + 1, dimension + 1];
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
