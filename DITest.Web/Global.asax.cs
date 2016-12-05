using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using BLL;
using JK.Framework.Core.Data;
using JK.Framework.Data;
using log4net.Config;

namespace DITest
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            RegisterAutofac();
            InitLog4Net();
            InitJKConfig();
        }

        public static void RegisterAutofac()
        {
            string connectionStr = System.Web.Configuration.WebConfigurationManager.
                ConnectionStrings["AccountEntities"].ConnectionString; 
            string authorityStr= System.Web.Configuration.WebConfigurationManager.
                ConnectionStrings["AuthorityEntities"].ConnectionString;

            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            #region IOC注册区域
            //倘若需要默认注册所有的，请这样写（主要参数需要修改）
            //builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
            //   .AsImplementedInterfaces();

            //JKFramework
            RegisterAutofacForJK.RegisterAutofacForJKFramework(builder,connectionStr);
            builder.RegisterType<AccountServiceImpl>().As<IAccountService>().InstancePerHttpRequest(); //mvc


            #endregion
            // then
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }

        private static void InitLog4Net()
        {
            var logCfg = new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "log4net.config");
            XmlConfigurator.ConfigureAndWatch(logCfg);
        }

        public static void InitJKConfig()
        {
         var configurationSection = ConfigurationManager.GetSection("JKConfig");
        }


    }
}
