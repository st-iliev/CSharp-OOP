using Easter.Models.Bunnies.Contracts;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Models.Workshops
{
    public class Workshop : IWorkshop
    {
        public void Color(IEgg egg, IBunny bunny)
        {
            if (bunny.Energy > 0 && bunny.Dyes.All(s => !s.IsFinished()))
            {
                while (egg.IsDone() && bunny.Energy > 0 && bunny.Dyes.Any(s=>!s.IsFinished()))
                {
                    bunny.Work();
                    egg.GetColored();            
                }
            }
                
        }
    }
}
