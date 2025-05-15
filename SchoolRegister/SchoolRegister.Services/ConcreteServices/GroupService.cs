using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using SchoolRegister.ViewModels.VM;
using SchoolRegister.Services.Interfaces;

namespace SchoolRegister.Services.ConcreteServices
{
    public class GroupService : BaseService, IGroupService
    {
        private readonly UserManager<User> _userManager;

        public GroupService(
            ApplicationDbContext dbContext,
            IMapper mapper,
            ILogger logger,
            UserManager<User> userManager
        ) : base(dbContext, mapper, logger)
        {
            _userManager = userManager;
        }

        public GroupVm AddOrUpdateGroup(AddOrUpdateGroupVm addOrUpdateGroupVm)
        {
            Group group;
            if (addOrUpdateGroupVm.Id.HasValue)
            {
                group = _dbContext.Groups.FirstOrDefault(g => g.Id == addOrUpdateGroupVm.Id.Value);
                if (group == null) throw new Exception("Grupa nie istnieje.");
                group.Name = addOrUpdateGroupVm.Name;
            }
            else
            {
                group = new Group { Name = addOrUpdateGroupVm.Name };
                _dbContext.Groups.Add(group);
            }
            DbContext.SaveChanges();
            return Mapper.Map<GroupVm>(group);
        }

        public StudentVm AttachStudentToGroup(AttachDetachStudentToGroupVm attachStudentToGroupVm)
        {
            var group = DbContext.Groups.FirstOrDefault(g => g.Id == attachStudentToGroupVm.GroupId);
            var student = DbContext.Users.OfType<Student>().FirstOrDefault(s => s.Id == attachStudentToGroupVm.StudentId);
            if (group == null || student == null) throw new Exception("Grupa lub uczeń nie istnieje.");
            if (!group.Students.Contains(student))
            {
                group.Students.Add(student);
                DbContext.SaveChanges();
            }
            return Mapper.Map<StudentVm>(student);
        }

        public GroupVm AttachSubjectToGroup(AttachDetachSubjectGroupVm attachSubjectGroupVm)
        {
            var group = DbContext.Groups.FirstOrDefault(g => g.Id == attachSubjectGroupVm.GroupId);
            var subject = DbContext.Subjects.FirstOrDefault(s => s.Id == attachSubjectGroupVm.SubjectId);
            if (group == null || subject == null) throw new Exception("Grupa lub przedmiot nie istnieje.");
            if (!group.Subjects.Contains(subject))
            {
                group.Subjects.Add(subject);
                DbContext.SaveChanges();
            }
            return Mapper.Map<GroupVm>(group);
        }

        public SubjectVm AttachTeacherToSubject(AttachDetachSubjectToTeacherVm attachDetachSubjectToTeacherVm)
        {
            var subject = DbContext.Subjects.FirstOrDefault(s => s.Id == attachDetachSubjectToTeacherVm.SubjectId);
            var teacher = DbContext.Users.OfType<Teacher>().FirstOrDefault(t => t.Id == attachDetachSubjectToTeacherVm.TeacherId);
            if (subject == null || teacher == null) throw new Exception("Przedmiot lub nauczyciel nie istnieje.");
            if (!subject.Teachers.Contains(teacher))
            {
                subject.Teachers.Add(teacher);
                DbContext.SaveChanges();
            }
            return Mapper.Map<SubjectVm>(subject);
        }

        public StudentVm DetachStudentFromGroup(AttachDetachStudentToGroupVm detachStudentToGroupVm)
        {
            var group = DbContext.Groups.FirstOrDefault(g => g.Id == detachStudentToGroupVm.GroupId);
            var student = DbContext.Users.OfType<Student>().FirstOrDefault(s => s.Id == detachStudentToGroupVm.StudentId);
            if (group == null || student == null) throw new Exception("Grupa lub uczeń nie istnieje.");
            if (group.Students.Contains(student))
            {
                group.Students.Remove(student);
                DbContext.SaveChanges();
            }
            return Mapper.Map<StudentVm>(student);
        }

        public GroupVm DetachSubjectFromGroup(AttachDetachSubjectGroupVm detachSubjectGroupVm)
        {
            var group = DbContext.Groups.FirstOrDefault(g => g.Id == detachSubjectGroupVm.GroupId);
            var subject = DbContext.Subjects.FirstOrDefault(s => s.Id == detachSubjectGroupVm.SubjectId);
            if (group == null || subject == null) throw new Exception("Grupa lub przedmiot nie istnieje.");
            if (group.Subjects.Contains(subject))
            {
                group.Subjects.Remove(subject);
                DbContext.SaveChanges();
            }
            return Mapper.Map<GroupVm>(group);
        }

        public SubjectVm DetachTeacherFromSubject(AttachDetachSubjectToTeacherVm attachDetachSubjectToTeacherVm)
        {
            var subject = DbContext.Subjects.FirstOrDefault(s => s.Id == attachDetachSubjectToTeacherVm.SubjectId);
            var teacher = DbContext.Users.OfType<Teacher>().FirstOrDefault(t => t.Id == attachDetachSubjectToTeacherVm.TeacherId);
            if (subject == null || teacher == null) throw new Exception("Przedmiot lub nauczyciel nie istnieje.");
            if (subject.Teachers.Contains(teacher))
            {
                subject.Teachers.Remove(teacher);
                DbContext.SaveChanges();
            }
            return Mapper.Map<SubjectVm>(subject);
        }

        public GroupVm GetGroup(Expression<Func<Group, bool>> filterPredicate)
        {
            var group = DbContext.Groups.FirstOrDefault(filterPredicate);
            return Mapper.Map<GroupVm>(group);
        }

        public IEnumerable<GroupVm> GetGroups(Expression<Func<Group, bool>> filterPredicate = null)
        {
            var query = DbContext.Groups.AsQueryable();
            if (filterPredicate != null)
                query = query.Where(filterPredicate);
            var groups = query.ToList();
            return Mapper.Map<IEnumerable<GroupVm>>(groups);
        }
    }
}
