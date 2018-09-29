using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModel.QuestionBankVM
{
    public class QuestionGridListVm
    {
        public int Order { get; set; }
        public string Question { get; set; }
        public string Type { get; set; }
        public int Options { get; set; }
    }
}
