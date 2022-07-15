using Raiding.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public abstract class BaseHero : IBaseHero
    {
            public BaseHero(string name)
            {
                Name = name;
            }

            public string Name { get; private set; }
            public virtual int Power { get; private set; }
            public abstract string CastAbility();
    }
}
