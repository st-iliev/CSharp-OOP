﻿using Easter.Models.Dyes.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Dyes
{
    public class Dye : IDye
    {
        private int power;

        public Dye(int power)
        {
            this.Power = power;
        }

        public int Power
        {
            get => power;
            private set
            {
                if (power + value < 0)
                {
                    power = 0;
                }
                this.power += value;
            }
        }
        public bool IsFinished() => this.Power == 0;
        

        public void Use()
        {
            this.Power -= 10;
        }
    }
}
