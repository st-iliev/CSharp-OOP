using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Bunnies
{
    public class SleepyBunny : Bunny
    {
        private int energy = 50;
        public SleepyBunny(string name) : base(name, 50)
        {
            this.Energy = energy;
        }

        public override void Work()
        {
           if (this.Energy - 15 < 0)
            {
                this.Energy = 0;
            }
            else
            {
                this.Energy -= 15;
            }
        }
    }
}
