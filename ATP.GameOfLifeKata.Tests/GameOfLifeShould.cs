
namespace ATP.GameOfLifeKata.Tests
{
    using FluentAssertions;
    using NUnit.Framework;
    using Source;

    [TestFixture]
    public class GameOfLifeShould
    {
        [Test]
        public void ShouldReturnNullGame_GivenNullGame()
        {
            var nullGame = new GameOfLife();
            var game = new GameOfLife();

            game.Tick();

            game.Should().Be(nullGame);
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
        public void SeededGame11_ShouldEqualSameSeededGame11()
        {
            var seed1 = new bool[3, 3];
            seed1[1, 1] = true;

            var seed2 = new bool[3, 3];
            seed2[1, 1] = true;
            
            var game1 = new GameOfLife(seed1);
            var game2 = new GameOfLife(seed2);

            game2.Should().Be(game1);
        }

        [Test]
        public void SeededGame1112_ShouldEqualSameSeededGame1112()
        {
            var seed1 = new bool[3, 3];
            seed1[1, 1] = true;
            seed1[1, 2] = true;

            var seed2 = new bool[3, 3];
            seed2[1, 1] = true;
            seed2[1, 2] = true;

            var game1 = new GameOfLife(seed1);
            var game2 = new GameOfLife(seed2);

            game2.Should().Be(game1);
        }

        [Test]
        public void SeededGame00_ShouldEqualSameSeededGame00()
        {
            var seed1 = new bool[3, 3];
            seed1[0, 0] = true;

            var seed2 = new bool[3, 3];
            seed2[0, 0] = true;

            var game1 = new GameOfLife(seed1);
            var game2 = new GameOfLife(seed2);

            game2.Should().Be(game1);
        }

        [Test]
        public void SeededGame11_ShouldNotEqualDifferentSeededGame01()
        {
            var seed1 = new bool[3, 3];
            seed1[1, 1] = true;

            var seed2 = new bool[3, 3];
            seed2[0, 1] = true;

            var game1 = new GameOfLife(seed1);
            var game2 = new GameOfLife(seed2);

            game2.Should().NotBe(game1);
        }

        [Test]
        public void SeededGame11_ShouldNotEqualDifferentSeededGame12()
        {
            var seed1 = new bool[3, 3];
            seed1[1, 1] = true;

            var seed2 = new bool[3, 3];
            seed2[1, 2] = true;

            var game1 = new GameOfLife(seed1);
            var game2 = new GameOfLife(seed2);

            game2.Should().NotBe(game1);
        }

        [Test]
        public void SeededGame1Live_ShouldEqualDeadGameAfterTick()
        {
            var seed = new bool[3, 3];
            seed[1, 1] = true;

            var deadGame = new GameOfLife(new bool[3, 3]);

            var game = new GameOfLife(seed);
            game.Tick();

            game.Should().Be(deadGame);
        }

        [Test]
        public void SeedGame4Square_ShouldEqualGame4SquareAfterTick()
        {
            var seed = new bool[3, 3];
            seed[0, 0] = true;
            seed[1, 0] = true;
            seed[0, 1] = true;
            seed[1, 1] = true;

            var compareGame = new GameOfLife(seed);
            var game = new GameOfLife(seed);
            game.Tick();

            game.Should().Be(compareGame);
        }

        [Test]
        public void SeededGameWith4CellsInSquare_ShouldBeSameAfterTick()
        {
            var expectedSeed = new bool[3, 3];
            expectedSeed[1, 1] = true;
            expectedSeed[2, 1] = true;
            expectedSeed[2, 2] = true;
            expectedSeed[1, 2] = true;

            var seed = new bool[3, 3];
            seed[1, 1] = true;
            seed[2, 1] = true;
            seed[2, 2] = true;
            seed[1, 2] = true;

            var game = new GameOfLife(seed);
            var finalState = new GameOfLife(expectedSeed);

            game.Tick();

            game.Should().Be(finalState);
        }
    }
}
