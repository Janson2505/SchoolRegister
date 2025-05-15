using SchoolRegister.Model.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using SchoolRegister.ViewModels;

namespace SchoolRegister.Services.Interfaces
{
    public interface IGroupService
    {
        GroupVm AddOrUpdateGroup(AddOrUpdateGroupVm addOrUpdateGroupVm);
        StudentVm AttachStudentToGroup(AttachDetachStudentToGroupVm attachStudentToGroupVm);
        GroupVm AttachSubjectToGroup(AttachDetachSubjectGroupVm attachSubjectGroupVm);
        SubjectVm AttachTeacherToSubject(AttachDetachSubjectToTeacherVm attachDetachSubjectToTeacherVm);
        StudentVm DetachStudentFromGroup(AttachDetachStudentToGroupVm detachStudentToGroupVm);
        GroupVm DetachSubjectFromGroup(AttachDetachSubjectGroupVm detachSubjectGroupVm);
        SubjectVm DetachTeacherFromSubject(AttachDetachSubjectToTeacherVm attachDetachSubjectToTeacherVm);
        GroupVm GetGroup(Expression<Func<Group, bool>> filterPredicate);
        IEnumerable<GroupVm> GetGroups(Expression<Func<Group, bool>> filterPredicate = null);
    }
}
