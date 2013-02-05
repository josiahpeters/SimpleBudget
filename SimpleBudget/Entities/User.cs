using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleBudget
{
    public class User : IIdentifiable
    {
        public Guid Id { get; set; }

        public string DisplayName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }
    }
}
