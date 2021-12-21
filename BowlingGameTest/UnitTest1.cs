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

        [Fact]
        public void Roll_less_than_10_for_each_frame()
        {
            var game = new Game();
            var rolls = new int[20]
            {
                2, 5, 3, 2, 4, 3, 5, 3, 6, 2,
                3, 4, 2, 5, 3, 5, 4, 3, 5, 3
            };

            foreach (var roll in rolls)
            {
                game.Roll(roll);
            }

            Assert.Equal(72, game.Score());
        }

        [Fact]
        public void Roll_1_spare_before_frame_10()
        {
            var game = new Game();
            var rolls = new int[20]
            {
                4, 5, 1, 7, 9, 1, 5, 2, 5, 2,
                4, 5, 3, 2, 6, 3, 2, 5, 3, 5
            };

            foreach (var roll in rolls)
            {
                game.Roll(roll);
            }

            Assert.Equal(84, game.Score());
        }
    }
}