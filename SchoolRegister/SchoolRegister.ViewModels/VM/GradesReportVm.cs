using SchoolRegister.Model.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SchoolRegister.ViewModels.VM
{
    public class GradesReportVm
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public IEnumerable<GradeVm> Grades { get; set; }
    }
}
