using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var nationality = new Nationality { Id = 2, Name = "Azerbaijanian" };
            var dbEntity = new AzeriPersonDb
            {
                Id = 1,
                Name = "Farid",
                Surname = "Zeynalli",
                Age = 36,
                Nationality = nationality,
                Email = "admin@admin.com"
            };

            var model = dbEntity.getModel<AzeriPersonDb, AzeriPersonViewModel>();

            // breakpoint qoymadan methodun islediyinden emin olmaq ucun bunu yazdiriram 
            var resultString = $"{model.Name} {model.Surname} is {model.Age} years old. " +
                               $"He is {model.Nationality.Name}. ";

            Console.WriteLine(resultString);

            Console.ReadLine();

        }
        
    }

    public class EmployeeDb
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public Department Department { get; set; }

    }
    public class Department
    {

        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public Department Department { get; set; }
    }

    public class PersonDB
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public Nationality Nationality { get; set; }
    }
    public class AzeriPersonDb : PersonDB
    {
        public string Surname { get; set; }
    }
    public class Nationality
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class AzeriPersonViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public Nationality Nationality { get; set; }
    }
}
