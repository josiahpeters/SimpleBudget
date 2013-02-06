using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleBudget.Tests
{
    public class TestBase
    {
        protected AutofacTestSetup testSetup;

        [TestInitialize]
        public virtual void Init()
        {
            testSetup = new AutofacTestSetup();

            Initialize();
        }
        protected virtual void Initialize()
        {

        }
    }
}
