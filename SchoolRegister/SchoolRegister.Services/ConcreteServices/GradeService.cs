using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using SchoolRegister.ViewModels.VM;
using SchoolRegister.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using SchoolRegister.Dal.EF;
using SchoolRegister.Model.DataModels;


namespace SchoolRegister.Services.ConcreteServices
{
    public class GradeService : BaseService, IGradeService
    {
        private readonly UserManager<User> _userManager;

        public GradeService(
            ApplicationDbContext dbContext,
            IMapper mapper,
            ILogger logger,
            UserManager<User> userManager
        ) : base(dbContext, mapper, logger)
        {
            _userManager = userManager;
        }

        public GradeVm AddGradeToStudent(AddGradeToStudentVm addGradeToStudentVm)
        {
            // Pobierz nauczyciela
            var teacher = DbContext.Users.OfType<Teacher>().FirstOrDefault(t => t.Id == addGradeToStudentVm.TeacherId);
            var student = DbContext.Users.OfType<Student>().FirstOrDefault(s => s.Id == addGradeToStudentVm.StudentId);
            var subject = DbContext.Subjects.FirstOrDefault(s => s.Id == addGradeToStudentVm.SubjectId);

            if (teacher == null || student == null || subject == null)
                throw new Exception("Nauczyciel, uczeń lub przedmiot nie istnieje.");

            var isTeacher = _userManager.IsInRoleAsync(teacher, "Teacher").Result;
            if (!isTeacher)
                throw new Exception("Brak uprawnień do wystawiania ocen.");

            var grade = new Grade
            {
                GradeValue = (GradeScale)addGradeToStudentVm.GradeValue,
                Description = addGradeToStudentVm.Description,
                Subject = subject,
                Student = student,
                Teacher = teacher,
                DateAdded = DateTime.Now
            };
            DbContext.Grades.Add(grade);
            DbContext.SaveChanges();

            return Mapper.Map<GradeVm>(grade);
        }

        public GradesReportVm GetGradesReportForStudent(GetGradesReportVm getGradesVm)
        {
            var student = DbContext.Users.OfType<Student>().FirstOrDefault(s => s.Id == getGradesVm.StudentId);
            if (student == null)
                throw new Exception("Uczeń nie został znaleziony.");

            var grades = DbContext.Grades
                .Where(g => g.Student.Id == getGradesVm.StudentId)
                .ToList();

            return new GradesReportVm
            {
                StudentId = student.Id,
                StudentName = $"{student.FirstName} {student.LastName}",
                Grades = Mapper.Map<System.Collections.Generic.IEnumerable<GradeVm>>(grades)
            };
        }
    }
}
