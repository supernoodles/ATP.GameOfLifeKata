
namespace ATP.GameOfLifeKata.Tests
{
    using FluentAssertions;
    using NUnit.Framework;

    [TestFixture]
    public class GameOfLifeShould
    {
        [Test]
        public void ShouldReturnDeadGrid_GivenDeadGrid()
        {
            var deadGame = new GameOfLife();
            var game = new GameOfLife();

            game.Tick();

            game.Should().Be(deadGame);
        }
    }

    public class GameOfLife
    {
        public void Tick()
        {
        }

        protected bool Equals(GameOfLife other)
        {
            return true;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((GameOfLife) obj);
        }

    }
}
