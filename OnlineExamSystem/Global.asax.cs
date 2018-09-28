using System.Web.Mvc;
using System.Web.Routing;
using AutoMapper;
using Models;
using Models.ViewModel.BatchVM;
using Models.ViewModel.CourseVM;
using Models.ViewModel.ExamVM;
using Models.ViewModel.TrainerVM;
using Models.ViewModel.ParticipantVM;

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
                conf.CreateMap<Course, CourseEditVm>();
                conf.CreateMap<CourseEditVm, Course>();
                conf.CreateMap<Course, CourseInformationVm>();
                conf.CreateMap<BatchCreateVm, Batch>();
                conf.CreateMap<ParticipantCreateVm, Participant>();
                conf.CreateMap<Participant, ParticipantCreateVm>();
                conf.CreateMap<Batch, BatchEditVm>();
                conf.CreateMap<BatchEditVm,Batch>();
                conf.CreateMap<Batch, BatchInformationVm>();
                conf.CreateMap<TrainerCreateVm, Trainer>();
                conf.CreateMap<Exam, ExamCreateVm>();
                conf.CreateMap<ExamCreateVm, Exam>();

            });
        }
    }
}
