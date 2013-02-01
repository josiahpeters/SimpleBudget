﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleBudget
{
    public class Budget
    {
        public Guid Id { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public Frequency Frequency { get; set; }
    }
}

