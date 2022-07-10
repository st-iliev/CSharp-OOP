﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models.Interfaces
{
    public interface ILieutenantGeneral : IPrivate
    {
        public Dictionary<int, IPrivate> Private { get;}
    }
}
