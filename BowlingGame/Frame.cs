using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGame
{
    public class Frame
    {
        //Frames 1 throughout 9 has 2 slots each
        public bool IsSpare { get; set; } = false;
        public bool IsStrike { get; set; } = false;
        public bool WasPreviousRollStrike { get; set; } = false;
        public List<int> Slot { get; set; } = new List<int>();

        public Frame(int pins, bool previousRollStrike = false)
        {
            Slot.Add(pins);
            WasPreviousRollStrike = previousRollStrike;
        }
    }
}
