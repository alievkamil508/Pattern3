using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubezh2_Linq
{
    class School
    {
        public string Name { get; set; }
       
    }

    class Class
    {
        public string Name { get; set; }
        
    }
    class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Class { get; set; }
        public string School { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {

            List<Student> students = new List<Student>
            {
                new Student{Name = "Ерланов Темирлан", Age = 7, Class = "1A", School = "Школа 1"},
                new Student{Name = "Танашбаева Роза", Age = 8, Class = "1Б", School = "Школа 1" },
                new Student{Name = "Серикова Алина", Age = 7, Class = "1Б", School = "Школа 1" },
                new Student{Name = "Сабыржанов Даулет",Age = 7, Class = "1Б", School = "Школа 1" },
                new Student{Name = "Каришев Самат", Age = 8, Class = "1Б", School = "Школа 2" },
                new Student{Name = "Темников Александр", Age = 7, Class = "1A" , School = "Школа 1"},
                new Student{Name = "Теззекбай Самат", Age = 8, Class = "1Б", School = "Школа 1" },
                new Student{Name = "Седовласов Юри", Age = 7, Class = "1Б", School = "Школа 2" },
                new Student{Name = "Джумабаев Алмабек", Age = 7, Class = "1A", School = "Школа 2" },
                new Student{Name = "Жумабаева Инкар", Age = 8, Class = "1Б", School = "Школа 1" },
                new Student{Name = "Казиханов Ерасыл", Age = 7, Class = "1A" , School = "Школа 1"}

            };

            List<School> school = new List<School>
            {
                new School{Name = "Школа 1"},
                new School{Name = "Школа 1" },
            };

            List<Class> class1 = new List<Class>
            {
                new Class{Name = "1Б"},
                new Class{Name = "1А" },
            };


            var result1 = students.Select(s => s.Name)
                                  .OrderBy(n => n[1]);

            foreach (var item in result1)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("------------------------");

            var result2 = from student in students
                         group student by student.School into g
                         orderby g.Key
                         select new { Name_of_School = g.Key, Count = g.Count() };

            foreach (var item in result2)
            {
                Console.WriteLine("{0} - {1}", item.Name_of_School, item.Count);
            }
           
        }
    }
}
