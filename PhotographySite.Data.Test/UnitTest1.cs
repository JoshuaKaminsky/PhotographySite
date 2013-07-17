using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Photography.Data;
using Photography.Data.Bolts;

namespace PhotographySite.Data.Test
{
    [TestClass]
    public class DataTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var userProcess = new UserProcess(new BaseUnitOfWork(new RepositoryProvider(new RepositoryFactories())));
            var user = userProcess.CreateUser("Josh Kaminsky", "JoshKaminsky@gmail.com", "p");
        }
    }
}
