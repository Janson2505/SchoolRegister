﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SchoolRegister.ViewModels.VM
{
    public class GroupVm
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        public IList<StudentVm>? Students { get; set; }

        public IList<SubjectVm>? Subjects { get; set; }
    }
}
