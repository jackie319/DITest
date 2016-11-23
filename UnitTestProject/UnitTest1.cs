using System;
using BLL;
using Dao.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        public string dbConnection { set; get; }
        [TestInitialize]
        public void Init()
        {
            dbConnection = System.Web.Configuration.WebConfigurationManager.
                ConnectionStrings["AccountEntities"].ConnectionString;
        }
        [TestMethod]
        public void TestMethod1()
        {
            //IAccountService service=new AccountServiceImpl(dbConnection);
            //UserAccount account=new UserAccount();
            //account.BindingCode = "1123";
            //account.Email = "jackie319@vip.qq.com";
            //account.Guid=Guid.NewGuid();
            //account.CountVisited = 12;
            //account.IPv4LastVisited = "sadd";
            //account.IsDeleted = false;
            //account.IsEmailValidated = false;
            //account.IsMobilePhoneValidated = false;
            //account.MobilePhone = "12345678908";
            //account.OwnerId = "sdadfadfafsdf";
            //account.OwnerType = "adfaf";
            //account.PasswordHash = "adsfadfaf";
            //account.Status = "adfaf";
            //account.TimeCreated=DateTime.Now;
            //account.UserName = "jackiebbbbbbb";
            //account.TimeLastVisited=DateTime.MaxValue;
            //account.IsDeleted = false;
            //service.Add(account);
            Assert.IsTrue(true);
        }
    }
}
