using System;
using BarterService.Common;
using BarterService.DataAccess.Common;
using BasrterService.Model.Objects;
using Initialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Practices.Unity;

namespace BarterServiceTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var containerInitializaer = new InitializationContainerExtension();
            containerInitializaer.InitializeContainer();

            var dbContext = AppContainer.Current.Resolve<IContext>();
            var newDeal = new Deal {Ammount = 100};
            dbContext.Set<Deal>().Add(newDeal);
            dbContext.Save();
        }

        public void TestMethod2()
        {

            //IContext ctx = new BarterServiceContext();
            //var deals = ctx.Set<Deal>().ToList();
        }
    }
}
