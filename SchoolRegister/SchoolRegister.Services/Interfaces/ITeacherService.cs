using SchoolRegister.Model.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SchoolRegister.ViewModels.VM;

namespace SchoolRegister.Services.Interfaces
{
    public interface ITeacherService
    {
        TeacherVm GetTeacher(Expression<Func<Teacher, bool>> filterPredicate);
        IEnumerable<TeacherVm> GetTeachers(Expression<Func<Teacher, bool>> filterPredicate = null!);
        IEnumerable<GroupVm> GetTeachersGroups(TeachersGroupsVm getTeachersGroups);
        Task<bool> SendEmailToParentAsync(SendEmailToParentVm sendEmailToParentVm);
    }
}
