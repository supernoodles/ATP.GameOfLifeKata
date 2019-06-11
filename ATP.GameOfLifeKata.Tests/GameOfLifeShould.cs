
namespace ATP.GameOfLifeKata.Tests
{
    using FluentAssertions;
    using NUnit.Framework;
    using Source;

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

        [Test]
        public void SeededGame_ShouldNotEqualDeadGame()
        {
            var deadGame = new GameOfLife();

            var seed = new bool[3, 3];
            seed[1, 1] = true;

            var seededGame = new GameOfLife(seed);

            seededGame.Should().NotBe(deadGame);
        }

        [Test]
        public void SeededGame_ShouldEqualSameSeededGame()
        {
            var seed = new bool[3, 3];
            seed[1, 1] = true;

            var game1 = new GameOfLife(seed);
            var game2 = new GameOfLife(seed);

            game2.Should().Be(game1);
        }
    }
}
