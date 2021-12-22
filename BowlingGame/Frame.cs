using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGame
{
    public class Frame
    {
        //Frames 1 throughout 9 have 2 slots each
        public bool IsSpare { get; set; }
        public bool IsStrike { get; set; }
        public bool IsSecondRollAfterStrike { get; set; }
        public List<int> Slot { get; set; } = new List<int>();

        public Frame(int pins)
        {
            Slot.Add(pins);
        }
    }
}
