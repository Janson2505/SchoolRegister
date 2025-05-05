using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SchoolRegister.Model.DataModels
{
    public class Student : User
    {
        public Group Group { get; set; }
        public int? GroupId { get; set; }
        public IList<Grade> Grades { get; set; }
        public Parent Parent { get; set; }
        public int? ParentId { get; set; }
        public double AverageGrade
        {
            get
            {
                if (Grades == null || Grades.Count == 0)
                    return 0;
                return Grades.Average(g => (int)g.GradeValue);
            }
        }
        public IDictionary<string, double> AverageGradePerSubject
        {
            get
            {
                if (Grades == null || Grades.Count == 0)
                    return null;
                return Grades.GroupBy(g => g.Subject)
                        .ToDictionary(g => g.Key.Name, g => g.Average(g => (int)g.GradeValue));

            }
        }
        
        public IDictionary<string, List<GradeScale>> GradesPerSubject
        {
            get
            {
                if (Grades == null || Grades.Count == 0)
                    return null;
                return Grades.GroupBy(g => g.Subject)
                             .ToDictionary(g => g.Key.Name, g => g.Select(g => g.GradeValue).ToList());
            }
        }

        public Student()
        {
            Grades = new List<Grade>();
        }
    }
}
