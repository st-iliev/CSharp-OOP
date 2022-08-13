using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Bunnies
{
    public class HappyBunny : Bunny
    {
        private int energy = 100;
        public HappyBunny(string name) : base(name, 100)
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
