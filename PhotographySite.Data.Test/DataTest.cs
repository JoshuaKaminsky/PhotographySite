using Microsoft.VisualStudio.TestTools.UnitTesting;
using Photography.Data.Bolts;
using Photography.Data.Core;

namespace PhotographySite.Data.Test
{
    [TestClass]
    public class DataTest
    {
        [TestMethod]
        public void UserProcessCreateShouldCreateUser()
        {
            var userProcess = new UserProcess(new BaseUnitOfWork(new RepositoryProvider(new RepositoryFactories())));
            
            var user = userProcess.CreateUser("Josh Kaminsky", "JoshKaminsky@gmail.com", 0, "p");

            user.Discount = 95;

            userProcess.UpdateUser(user);
        }
    }
}
