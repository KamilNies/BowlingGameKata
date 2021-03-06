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

        [Fact]
        public void Roll_1_strike_before_frame_10()
        {
            var game = new Game();
            var rolls = new int[19]
            {
                2, 3, 3, 4, 6, 1, 10, 3, 4,
                5, 2, 5, 2, 1, 4, 6, 2, 3, 1
            };

            foreach (var roll in rolls)
            {
                game.Roll(roll);
            }

            Assert.Equal(74, game.Score());
        }

        [Fact]
        public void Roll_2_strikes_in_a_row_before_frame_10()
        {
            var game = new Game();
            var rolls = new int[18]
            {
                2, 6, 10, 10, 5, 3, 5, 2, 4,
                3, 1, 1, 4, 1, 6, 0, 3, 2
            };

            foreach (var roll in rolls)
            {
                game.Roll(roll);
            }

            Assert.Equal(91, game.Score());
        }

        [Fact]
        public void Start_game_with_3_strikes_in_a_row()
        {
            var game = new Game();
            var rolls = new int[17]
            {
                10, 10, 10, 2, 3, 2, 4, 1,
                5, 0, 3, 4, 2, 2, 5, 3, 2
            };

            foreach (var roll in rolls)
            {
                game.Roll(roll);
            }

            Assert.Equal(105, game.Score());
        }

        [Fact]
        public void From_roll_1_every_other_frame_is_a_strike()
        {
            var game = new Game();
            var rolls = new int[15]
            {
                10, 2, 7, 10, 3, 1, 10,
                1, 2, 10, 4, 2, 10, 3, 4
            };

            foreach (var roll in rolls)
            {
                game.Roll(roll);
            }

            Assert.Equal(108, game.Score());
        }

        [Fact]
        public void From_frame_2_every_other_frame_is_a_strike()
        {
            var game = new Game();
            var rolls = new int[17]
            {
                2, 1, 10, 4, 5, 10, 4, 2, 10,
                3, 4, 10, 6, 3, 10, 5, 2
            };

            foreach (var roll in rolls)
            {
                game.Roll(roll);
            }

            Assert.Equal(122, game.Score());
        }

        [Fact]
        public void Start_game_with_3_spares_in_a_row()
        {
            var game = new Game();
            var rolls = new int[20]
            {
                2, 8, 5, 5, 3, 7, 4, 2, 4, 5,
                2, 5, 3, 2, 6, 2, 3, 5, 2, 3
            };

            foreach (var roll in rolls)
            {
                game.Roll(roll);
            }

            Assert.Equal(90, game.Score());
        }

        [Fact]
        public void From_roll_1_every_other_frame_is_a_spare()
        {
            var game = new Game();
            var rolls = new int[20]
            {
                5, 5, 3, 4, 7, 3, 4, 1, 6, 4,
                2, 3, 8, 2, 4, 2, 8, 2, 2, 3
            };

            foreach (var roll in rolls)
            {
                game.Roll(roll);
            }

            Assert.Equal(93, game.Score());
        }

        [Fact]
        public void From_frame_2_every_other_frame_is_a_spare()
        {
            var game = new Game();
            var rolls = new int[21]
            {
                4, 2, 8, 2, 1, 2, 0, 10, 3, 6,
                1, 9, 7, 1, 5, 5, 3, 4, 9, 1, 7
            };

            foreach (var roll in rolls)
            {
                game.Roll(roll);
            }

            Assert.Equal(104, game.Score());
        }

        [Fact]
        public void A_game_with_strikes_and_spares_in_no_particular_order()
        {
            var game = new Game();
            var rolls = new int[18]
            {
                5, 3, 7, 3, 10, 3, 5, 9, 1,
                10, 5, 4, 10, 5, 2, 10, 8, 1
            };

            foreach (var roll in rolls)
            {
                game.Roll(roll);
            }

            Assert.Equal(145, game.Score());
        }

        [Fact]
        public void A_game_with_3_strikes_at_frame_10()
        {
            var game = new Game();
            var rolls = new int[21]
            {
                3, 2, 3, 4, 3, 2, 4, 4, 3, 4, 3,
                2, 2, 3, 2, 3, 4, 3, 10, 10, 10
            };

            foreach (var roll in rolls)
            {
                game.Roll(roll);
            }

            Assert.Equal(84, game.Score());
        }

        [Fact]
        public void A_game_with_1_spare_and_1_strike_at_frame_10()
        {
            var game = new Game();
            var rolls = new int[21]
            {
                4, 6, 3, 6, 4, 2, 8, 1, 0, 2, 2,
                0, 2, 3, 0, 3, 4, 3, 5, 5, 10
            };

            foreach (var roll in rolls)
            {
                game.Roll(roll);
            }

            Assert.Equal(76, game.Score());
        }

        [Fact]
        public void A_game_with_1_strike_and_2_spares_at_frame_10()
        {
            var game = new Game();
            var rolls = new int[21]
            {
                3, 5, 2, 8, 4, 2, 6, 4, 3, 4,
                2, 6, 5, 3, 2, 5, 3, 4, 10, 6, 4
            };

            foreach (var roll in rolls)
            {
                game.Roll(roll);
            }

            Assert.Equal(98, game.Score());
        }

        [Fact]
        public void A_game_with_only_spares()
        {
            var game = new Game();
            var rolls = new int[21]
            {
                5, 5, 3, 7, 5, 5, 8, 2, 6, 4,
                9, 1, 9, 1, 7, 3, 2, 8, 3, 7, 4
            };

            foreach (var roll in rolls)
            {
                game.Roll(roll);
            }

            Assert.Equal(156, game.Score());
        }

        [Fact]
        public void A_perfect_game()
        {
            var game = new Game();
            var rolls = new int[12]
            {
                10, 10, 10, 10, 10, 10, 
                10, 10, 10, 10, 10, 10
            };

            foreach (var roll in rolls)
            {
                game.Roll(roll);
            }

            Assert.Equal(300, game.Score());
        }
    }
}