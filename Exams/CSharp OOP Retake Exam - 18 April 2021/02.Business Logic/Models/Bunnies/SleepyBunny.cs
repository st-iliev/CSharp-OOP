﻿using System;
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
            this.Energy -= 5;
            base.Work();
        }
    }
}
