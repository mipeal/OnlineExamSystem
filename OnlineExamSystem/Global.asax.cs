using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using AutoMapper;
using Models;
using OnlineExamSystem.Models.CourseVM;

namespace OnlineExamSystem
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            Mapper.Initialize(conf =>
            {
                conf.CreateMap<CourseCreateVm, Course>();
                conf.CreateMap<CourseUpdateVm, Course>();
                conf.CreateMap<Course, CourseUpdateVm>();
                conf.CreateMap<Course, CourseInformationVm>();
            });
        }
    }
}
