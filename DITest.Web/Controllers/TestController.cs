using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Dao.Model;

namespace DITest.Controllers
{
    public class TestController : Controller
    {
        private IAccountService AccouAccountService;
        public TestController(IAccountService accountService)
        {
            AccouAccountService = accountService;
        }

        public ActionResult Test()
        {
            UserAccount account = new UserAccount();
            account.BindingCode = "1123";
            account.Email = "jackie319@vip.qq.com";
            account.Guid = Guid.NewGuid();
            account.CountVisited = 12;
            account.IPv4LastVisited = "sadd";
            account.IsDeleted = false;
            account.IsEmailValidated = false;
            account.IsMobilePhoneValidated = false;
            account.MobilePhone = "12345678908";
            account.OwnerId = "sdadfadfafsdf";
            account.OwnerType = "adfaf";
            account.PasswordHash = "adsfadfaf";
            account.Status = "adfaf";
            account.TimeCreated = DateTime.Now;
            account.UserName = "jackiedddddddd";
            account.TimeLastVisited = DateTime.MaxValue;
            account.IsDeleted = false;
            AccouAccountService.Add(account);
            return View();
        }
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }
    }
}