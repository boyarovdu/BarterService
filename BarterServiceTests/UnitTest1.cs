using System;
using System.Linq;
using BarterService.DataAccess.Common;
using BasrterService.Model.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BarterServiceTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            IContext ctx = new BarterServiceContext();
            var deals = ctx.Set<Deal>().ToList();
        }
    }
}
