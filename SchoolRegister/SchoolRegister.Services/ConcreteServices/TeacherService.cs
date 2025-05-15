using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using AutoMapper;
using SchoolRegister.ViewModels;
using SchoolRegister.Services.Interfaces;

namespace SchoolRegister.Services.ConcreteServices
{
    public class TeacherService : BaseService, ITeacherService
    {
        private readonly UserManager<User> _userManager;

        public TeacherService(
            ApplicationDbContext dbContext,
            IMapper mapper,
            ILogger logger,
            UserManager<User> userManager) : base(dbContext, mapper, logger)
        {
            _userManager = userManager;
        }

        public TeacherVm GetTeacher(Expression<Func<Teacher, bool>> filterPredicate)
        {
            var teacher = _dbContext.Teachers.FirstOrDefault(filterPredicate);
            return _mapper.Map<TeacherVm>(teacher);
        }

        public IEnumerable<TeacherVm> GetTeachers(Expression<Func<Teacher, bool>> filterPredicate = null)
        {
            var teachersQuery = _dbContext.Teachers.AsQueryable();
            if (filterPredicate != null)
                teachersQuery = teachersQuery.Where(filterPredicate);

            var teachers = teachersQuery.ToList();
            return _mapper.Map<IEnumerable<TeacherVm>>(teachers);
        }

        public IEnumerable<GroupVm> GetTeachersGroups(TeachersGroupsVm getTeachersGroups)
        {
            var groups = _dbContext.Groups
                .Where(g => g.Teachers.Any(t => t.Id == getTeachersGroups.TeacherId))
                .ToList();

            return _mapper.Map<IEnumerable<GroupVm>>(groups);
        }
    }
}
