using BowlingGame;
using Xunit;

namespace BowlingGameTest
{
    public class UnitTest1
    {
        [Fact]
        public void TestGutterGame()
        {
            var game = new Game();
            for (int i = 0; i < 20; i++)
            {
                game.Roll(0);
            }

            Assert.Equal(0, game.Score());
        }
    }
}