﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_appz.Events
{
    public interface IObserver
    {
        void Update(string message);
    }
}
