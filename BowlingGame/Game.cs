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
        private readonly List<Frame> frames = new List<Frame>();

        public void Roll(int pins)
        {
            if (IsFirstRollInFrame())
            {
                var frame = new Frame(pins);
                if (WasPreviousRollSpare())
                    frames.Last().Slot.Add(pins);

                if (WasPreviousRollStrike())
                {
                    frames.Last().Slot.Add(pins);
                    frame.IsSecondRollAfterStrike = true;

                    if (IsSecondRollAfterStrike())
                        frames[^2].Slot.Add(pins);
                }

                frames.Add(frame);

                if (IsStrike())
                {
                    frame.Slot.Add(0);
                    frame.IsStrike = true;
                    return;
                }
                return;
            }

            if (IsSecondRollAfterStrike())
            {
                frames[^2].Slot.Add(pins);
                frames.Last().IsSecondRollAfterStrike = true;
            }

            frames.Last().Slot.Add(pins);

            if (IsSpare())
                frames.Last().IsSpare = true;
        }

        private bool IsSecondRollAfterStrike()
        {
            return frames.Any() ? 
                frames.Last().IsSecondRollAfterStrike : 
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
            CalculateScore();
            if (frames.Count > 10)
            {
                int newScore = score - frames.Last().Slot.Sum();
                if (frames.Count > 11)
                {
                    return newScore - frames[^2].Slot.Sum();
                }
                return newScore;
            }
            return score;
        }
    }
}
