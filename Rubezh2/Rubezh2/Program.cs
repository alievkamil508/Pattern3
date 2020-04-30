using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubezh2
{
    class EmployeePassport
    {
        public string Profession { get; set; }

        public string Gender { get; set; }

        public override int GetHashCode()
        {

            String str = Profession + "|" + Gender;
            return str.GetHashCode();
        }
    }

    class PassportFactory
    {
        private static PassportFactory _pfInstance;
        private PassportFactory() { }

        EmployeePassport bp = new EmployeePassport() { Profession = "", Gender = ""};

        HashSet<EmployeePassport> _passport = new HashSet<EmployeePassport>();
        public EmployeePassport GetPassport(string profession, string gender)
        {

            bp.Profession = profession;
            bp.Gender = gender;

            if (_passport.Contains(bp))
            {
                return _passport.First(p => p.GetHashCode() == bp.GetHashCode());
            }
            else
            {
                _passport.Add(bp);
                return bp;
            }
        }

        public static PassportFactory GetInstance()
        {
            if (_pfInstance == null)
                _pfInstance = new PassportFactory();
            return _pfInstance;
        }
    }


    class Employee
    {
        EmployeePassport Passport;

        public int Id { get; set; }

        public void PrintPassport()
        {
            Console.Write(Id + " ");
            Console.Write(Passport.Profession + " ");
            Console.WriteLine(Passport.Gender);
        }

        public Employee(PassportFactory pf, int id, string profession, string gender)
        {
            Id = id;
            Passport = pf.GetPassport(profession, gender);
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            PassportFactory pf = PassportFactory.GetInstance();
            Random random = new Random();

            for (int i = 0; i < 100000; i++)
            {

               
                if(i%3 == 0)
                {
                    Employee b1 = new Employee(pf, i+1, "Бухгалтер", "муж");
                    b1.PrintPassport();
                }
                else if(i% 3 == 1)
                {
                    Employee b1 = new Employee(pf, i+1, "Программист", "муж");
                    b1.PrintPassport();
                }
                else if (i%3 == 2)
                {
                    Employee b1 = new Employee(pf, i+1, "Менеджер", "жен");
                    b1.PrintPassport();
                }
                
            }

            
            
        }
    }
}
