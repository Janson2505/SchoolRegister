﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using SchoolRegister.Model.DataModels;

namespace SchoolRegister.ViewModels.VM
{
    public class StudentVm
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string ParentName { get; set; } = null!;
        public int ParentId { get; set; }
        public string GroupName { get; set; } = null!;
        public double AverageGrade { get; set; }
        public string UserName { get; set; } = null!;
        public IDictionary<string, double> AverageGradePerSubject { get; set; } = null!;
        public IDictionary<string, List<GradeScale>> GradesPerSubject { get; set; } = null!;
    }
}
