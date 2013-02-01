using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleBudget
{
    public class Category : IIdentifiable
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Frequency Frequency { get; set; }
    }
}
