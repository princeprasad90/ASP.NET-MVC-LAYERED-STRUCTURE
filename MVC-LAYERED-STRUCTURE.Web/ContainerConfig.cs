using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using MVC_LAYERED_STRUCTURE.Service;
using MVC_LAYERED_STRUCTURE.Web.Controllers;

namespace MVC_LAYERED_STRUCTURE.Web
{
    public class ContainerConfig
    {
        public static void RegisterContainer()
       {
            //https://weblogs.asp.net/bsimser/convention-over-configuration-with-mvc-and-autofac
            var builder = new ContainerBuilder(); 
           builder.RegisterControllers(Assembly.GetExecutingAssembly()); 
           builder.RegisterType<EmployeeRepository>().As<IEmployeeRepository>();
            var container = builder.Build();
            builder.RegisterType<EmployeesController>();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container)); 
       }
}
}