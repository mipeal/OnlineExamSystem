using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Models.ViewModel.CourseVM
{
    public class CourseSearchVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Duration { get; set; }
        public double Fees { get; set; }
        public int Participants { get; set; }
        public string Trainers { get; set; }
        public int Batches { get; set; }
        public int OrganizationId { get; set; }
        public ICollection<SelectListItem> OrganizationSLI { get; set; }
    }
}
