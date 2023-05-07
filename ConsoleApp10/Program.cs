using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace ConsoleApp10
{
    class Program
    {

        static void Main(string[] args)
        {
            using (var db = new StudentsContext())
            {
                // Create and save a new student
                Console.Write("Enter a name for a new Student: ");
                var studentfname = Console.ReadLine();
               
                var student = new Student { StudentFName = studentfname };
                db.Students.Add(student);
                db.SaveChanges();

                // Display all students from the database
                var query = from b in db.Students
                            orderby b.StudentFName
                            select b;

                Console.WriteLine("All students in the database:");
                foreach (var item in query)
                {
                    Console.WriteLine(item.StudentFName);
                }

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
            Console.ReadLine();
        }
        
    }
    public class Student
        {
        [Key]
        public int StudentId { get; set; }
         public string StudentFName { get; set; }
         public string StudentLName { get; set; }

        public virtual List<Grade> Grades { get; set; }
        }
    public class Grade
    {
        [Key]
        public int GPA { get; set; }
        public string Class { get; set; }
        public string Teacher { get; set; }

        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
    }
    public class StudentsContext : DbContext
        {
        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }
        }
}