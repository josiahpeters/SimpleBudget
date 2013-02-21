using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleBudget.Website
{
    public class NavigationItem
    {
        public string Text { get; set; }
        public string Url { get; set; }
        public bool Selected { get; set; }
    }
}