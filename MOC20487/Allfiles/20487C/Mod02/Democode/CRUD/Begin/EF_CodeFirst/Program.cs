using System;
using System.Data.Entity;
using System.Linq;
using EF_CodeFirst.Infra;
using System.Data.SqlClient;
using EF_CodeFirst.Model;
using System.Collections.Generic;

namespace EF_CodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initializing the database and populating seed data using DropCreateDatabaseIfModelChanges initializer
            (new DropCreateDBOnModelChanged()).InitializeDatabase(new SchoolContext2());

            using (var context = new SchoolContext2())
            {
                var wcfCourse = (from c in context.Courses
                                 where c.Name == "WCF"
                                 select c).Single();

                var firstStudent = new Student()
                {
                    Name = "Thomas Anderson"
                };
                var secondStudent = new Student()
                {
                    Name = "Terry Adams"
                };

                wcfCourse.Students.Add(firstStudent);
                wcfCourse.Students.Add(secondStudent);

                wcfCourse.CourseTeacher.Salary += 1000;

                var studentToDelete = wcfCourse.Students
                    .Where(s => s.Name == "Student_1")
                    .FirstOrDefault();
                wcfCourse.Students.Remove(studentToDelete);

                context.SaveChanges();
                Console.WriteLine(wcfCourse);
                Console.ReadLine();

            }

        }
    }
}
