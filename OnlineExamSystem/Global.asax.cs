using System.Web.Mvc;
using System.Web.Routing;
using AutoMapper;
using EntityModels;
using EntityModels.ViewModel.BatchVM;
using EntityModels.ViewModel.CourseVM;
using EntityModels.ViewModel.ExamVM;
using EntityModels.ViewModel.OrganizationVM;
using EntityModels.ViewModel.ParticipantVM;
using EntityModels.ViewModel.TrainerVM;

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
                conf.CreateMap<OrganizationCreateVm, Organization>();
                conf.CreateMap<Organization, OrganizationCreateVm>();
                conf.CreateMap<OrganizationInfoVm, Organization>();
                conf.CreateMap<Organization, OrganizationInfoVm>();

            });
        }
    }
}
