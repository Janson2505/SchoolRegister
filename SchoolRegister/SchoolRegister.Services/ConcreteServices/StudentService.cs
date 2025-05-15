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
using Microsoft.Extensions.Logging;
using SchoolRegister.ViewModels;
using SchoolRegister.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using SchoolRegister.Dal.EF;
using SchoolRegister.Model.DataModels;

namespace SchoolRegister.Services.ConcreteServices
{
    public class StudentService : BaseService, IStudentService
    {
        public StudentService(ApplicationDbContext dbContext, IMapper mapper, ILogger logger)
            : base(dbContext, mapper, logger)
        {
        }

        public StudentVm GetStudent(Expression<Func<Student, bool>> filterPredicate)
        {
            var student = _dbContext.Users.OfType<Student>().FirstOrDefault(filterPredicate);
            return _mapper.Map<StudentVm>(student);
        }

        public IEnumerable<StudentVm> GetStudents(Expression<Func<Student, bool>> filterPredicate = null)
        {
            var studentsQuery = _dbContext.Users.OfType<Student>().AsQueryable();
            if (filterPredicate != null)
                studentsQuery = studentsQuery.Where(filterPredicate);
            var students = studentsQuery.ToList();
            return _mapper.Map<IEnumerable<StudentVm>>(students);
        }
    }
}
