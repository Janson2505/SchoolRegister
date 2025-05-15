using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolRegister.ViewModels.VM
{
    public class AddGradeToStudentVm
    {
        public int TeacherId { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public double GradeValue { get; set; }
        public string Description { get; set; }
    }
}
