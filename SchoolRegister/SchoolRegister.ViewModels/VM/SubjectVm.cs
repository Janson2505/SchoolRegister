using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SchoolRegister.ViewModels.VM
{
    class SubjectVm
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public IList<GroupVm> Groups { get; set; }

        public string TeacherName { get; set; }
        public int? TeacherId { get; set; }
    }
}
