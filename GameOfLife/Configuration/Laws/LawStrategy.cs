﻿using GameOfLife.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Configuration.Laws
{
    interface LawStrategy
    {
        Grid Update(Grid g);
    }
}
