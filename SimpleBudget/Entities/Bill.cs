using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleBudget
{
    public class Bill : IIdentifiable
    {
        public Guid Id { get; set; }

        public string BillerName { get; set; }

        public string Nickname { get; set; }

        public Frequency Frequency { get; set; }
    }
}
