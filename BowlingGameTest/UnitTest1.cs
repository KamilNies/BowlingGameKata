using BowlingGame;
using Xunit;

namespace BowlingGameTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test_gutter_game()
        {
            var game = new Game();
            for (int i = 0; i < 20; i++)
            {
                game.Roll(0);
            }

            Assert.Equal(0, game.Score());
        }

        [Fact]
        public void Roll_1_on_every_thow()
        {
            var game = new Game();
            for (int i = 0; i < 20; i++)
            {
                game.Roll(1);
            }

            Assert.Equal(20, game.Score());
        }
    }
}