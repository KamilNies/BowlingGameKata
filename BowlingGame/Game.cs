using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGame
{
    public class Game
    {
        private int score;
        private int currentRoll;
        private int lastPinCount;
        private bool isSpare;
        public void Roll(int pins)
        {
            if (isSpare)
            {
                score += pins;
                isSpare = false;
            }

            currentRoll++;
            if (currentRoll % 2 == 0)
            {
                if (pins + lastPinCount == 10)
                {
                    isSpare = true;
                }
            }

            lastPinCount = pins;
            score += pins;
        }

        public int Score()
        {
            return score;
        }
    }
}
