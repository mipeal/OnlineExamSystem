using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EntityModels.ViewModel.ExamVM
{
    public class ExamResultVm
    {
        public ICollection<SelectListItem> OrganizationSelectListItems { get; set; }
        [Required]
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
        [Required]
        public int ParticipantId { get; set; }
        public virtual Participant Participant { get; set; }
    }
}
