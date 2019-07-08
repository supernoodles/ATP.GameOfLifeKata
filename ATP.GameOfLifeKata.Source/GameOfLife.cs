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

            public int Row { get; }
            public int Column { get; }
        }

        private Position GetNeighbouringCell(Position cell, int rowOffset, int columnOffset)
        {
            if ((rowOffset != 0 || columnOffset != 0) &&
                RowIndexValid(cell.Row + rowOffset) &&
                ColumnIndexValid(cell.Column + columnOffset))
            {
                return new Position(cell.Row + rowOffset, cell.Column + columnOffset);
            }

            return null;
        }

        private int CountLiveNeighbours(Position cell) =>
            CountLiveCellsInRelativeRow(cell, -1)
            + CountLiveCellsInRelativeRow(cell, 0)
            + CountLiveCellsInRelativeRow(cell, 1);

        private int CountLiveCellsInRelativeRow(Position cell, int rowOffset)
        {
            var count = 0;

            for (var columnOffset = -1; columnOffset <= 1; columnOffset++)
            {
                var neighbour = GetNeighbouringCell(cell, rowOffset, columnOffset);

                if (neighbour != null && _seed[neighbour.Row, neighbour.Column])
                {
                    count++;
                }
            }

            return count;
        }

        private bool RowIndexValid(int rowIndex) =>
            rowIndex >= 0 && rowIndex <= _seed.GetUpperBound(0);

        private bool ColumnIndexValid(int columnIndex) =>
            columnIndex >= 0 && columnIndex <= _seed.GetUpperBound(1);

        private bool[,] _seed;

        public GameOfLife(bool[,] seed = null) =>
            _seed = seed;

        public void Tick()
        {
            if (_seed == null)
            {
                return;
            }

            var newState = new bool[_seed.GetUpperBound(0) + 1, _seed.GetUpperBound(1) + 1];

            for (var row = 0; row <= _seed.GetUpperBound(0); ++row)
            {
                EvolveRow(row, newState);
            }

            _seed = newState;
        }

        private void EvolveRow(int row, bool[,] newState)
        {
            for (var column = 0; column <= _seed.GetUpperBound(1); ++column)
            {
                var position = new Position(row, column);

                var liveNeighbours = CountLiveNeighbours(position);

                newState[row, column] =
                    _seed[row, column] && liveNeighbours == 2 ||
                        liveNeighbours == 3;
            }
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

            for (var rowIndex = 0; rowIndex < _seed.GetUpperBound(0); rowIndex++)
            {
                var row = new Row(_seed, rowIndex);
                var otherRow = new Row(other._seed, rowIndex);

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
            return _seed != null
                ? _seed.GetHashCode()
                : 0;
        }
    }
}
