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
        private List<Frame> frames = new List<Frame>();

        public void Roll(int pins)
        {
            if (IsFirstRollInFrame())
            {
                if (WasPreviousRollSpare())
                    frames.Last().Slot.Add(pins);

                if (WasPreviousRollStrike())
                    frames.Last().Slot.Add(pins);

                frames.Add(new Frame(pins, WasPreviousRollStrike()));

                if (IsStrike())
                {
                    frames.Last().Slot.Add(0);
                    frames.Last().IsStrike = true;
                    return;
                }
                CalculateScore();
                return;
            }

            if (WasSecondLastRollStrike())
                frames.Last(frame => frame.IsStrike).Slot.Add(pins);

            frames.Last().Slot.Add(pins);

            if (IsSpare())
            {
                frames.Last().IsSpare = true;
                return;
            }

            CalculateScore();
        }

        private bool WasSecondLastRollStrike()
        {
            return frames.Any() ? 
                frames.Last().WasPreviousRollStrike : 
                false;
        }

        private bool WasPreviousRollStrike()
        {
            return frames.Any() ? 
                frames.Last().IsStrike : 
                false;
        }

        private bool IsStrike()
        {
            return frames.Last().Slot.First() == 10;
        }

        private bool WasPreviousRollSpare()
        {
            return frames.Any() ? frames.Last().IsSpare : false;
        }

        private bool IsSpare()
        {
            return frames.Last().Slot.Sum() == 10;
        }

        private void CalculateScore()
        {
            score = frames.Sum(frame => frame.Slot.Sum());
        }

        private bool IsFirstRollInFrame()
        {
            if (!frames.Any())
            {
                return true;
            }
            return frames.Last().Slot.Count > 1;
        }

        public int Score()
        {
            return score;
        }
    }
}
