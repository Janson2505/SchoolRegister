using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolRegister.Model.DataModels
{
    public class Grade
    {
        public DateTime DateOfIssue { get; set; }
        public GradeScale GradeValue { get; set; }

        public int GradeId { get; set; }
        public virtual Subject? Subject { get; set; }
        [ForeignKey("Subject")]
        public int? SubjectId { get; set; }

        [ForeignKey("Student")]
        public int? StudentId { get; set; }

        public virtual Student? Student { get; set; }

        public Grade() { }
    }
}
