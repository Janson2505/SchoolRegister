using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolRegister.ViewModels.VM
{
    public class GradeVm
    {
        public int Id { get; set; }
        public double GradeValue { get; set; }
        public string Description { get; set; }
        public string SubjectName { get; set; }
        public string TeacherName { get; set; }
        public string StudentName { get; set; }
    }
}
