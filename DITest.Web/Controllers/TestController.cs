using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Dao.Model;
using DITest.App_Start;
using log4net;
using log4net.Config;

namespace DITest.Controllers
{
    public class TestController : Controller
    {
        private IAccountService AccouAccountService;
        public TestController(IAccountService accountService)
        {
            AccouAccountService = accountService;
        }

        // GET: Test
        public ActionResult Index()
        {
            return View();
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

        //数据缓存
        public ActionResult Find()
        {
            string uid = "7E668467-AF64-45BE-9938-F5E1BAC9120D";
            Guid guid = Guid.Parse(uid);
            var account = AccouAccountService.Find(guid);
            return View(account);
        }

        //页面缓存
        [OutputCache(Duration = 60, NoStore = false)]
        public ActionResult FindN()
        {
            string uid = "7E668467-AF64-45BE-9938-F5E1BAC9120D";
            Guid guid = Guid.Parse(uid);
            var account = AccouAccountService.FindNoCache(guid);
            return View("Find",account);
        }

        public ActionResult Log()
        {
            string uid = "7E668467-AF64-45BE-9938-F5E1BAC9120D";
            Guid guid = Guid.Parse(uid);
            var account = AccouAccountService.FindNoCache(guid);

            

            var logger = LogManager.GetLogger(typeof(TestController));

            logger.Info("消息");
            logger.Warn("警告");
            logger.Error("异常");
            logger.Fatal("错误");
            return View("Find",account);
        }

        public ActionResult GetConfig()
        {
            var db = JKConfigHandler.GetValue("test1");
            UserAccount account = new UserAccount();
            account.UserName = db;
            return View("Find", account);
        } 
  

      
    }
}