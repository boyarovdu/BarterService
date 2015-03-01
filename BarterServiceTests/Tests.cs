﻿using BarterService.Common;
using BarterService.DataAccess.Common;
using BasrterService.Model.Objects;
using Initialization.Common;
using Microsoft.Practices.ServiceLocation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Practices.Unity;

namespace BarterServiceTests
{
    [TestClass]
    public class Tests
    {
        public IUnityContainer Container { get; set; }

        public Tests()
        {
            AppContainer.InitServices(new InitializationContainerExtension());
            Container = ServiceLocator.Current.GetInstance<IUnityContainer>();
        }

        [TestMethod]
        public void Test1()
        {
            var dbContext = Container.Resolve<IContext>();
            var entitySet = dbContext.Set<Deal>();

            Assert.IsNotNull(dbContext);
            Assert.IsNotNull(entitySet);
        }

        [TestMethod]
        public void Test2()
        {
            var unitOfWork = Container.Resolve<IUnitOfWork>();
            var repo = Container.Resolve<IEntityRepository<Deal>>();

            Assert.IsNotNull(unitOfWork);
            Assert.IsNotNull(repo);
        }

        [TestMethod]
        public void Test3()
        {
            var repo = Container.Resolve<IEntityRepository<Deal>>();

            repo.Insert(new Deal());
        }

        [TestMethod]
        public void Test4()
        {
            var context = Container.Resolve<IContext>();

            
        }
    }
}
