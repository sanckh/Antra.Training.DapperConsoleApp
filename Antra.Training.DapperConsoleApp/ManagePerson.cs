using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antra.Training.Data.Services;
using Antra.Training.Data.Entity;

namespace Antra.Training.DapperConsoleApp
{
    class ManagePerson
    {
        IPersonService personService;
        public ManagePerson()
        {
            personService = new PersonService();
        }
        void PrintAllPerson()
        {
            var collection = personService.GetAll();
            if(collection != null)
            {
                foreach(var item in collection)
                {
                    Console.WriteLine($"{item.Id} \t {item.FirstName+ " " + item.LastName} \t {item.Department.Name}");
                }   
            }
        }
        void InsertPerson()
        {
            Person person = new Person() { LastName ="Sutton", FirstName="Corey", HireDate=null, EnrollmentDate=DateTime.Now, Discriminator="Student" };
            if (personService.InsertPerson(person) > 0)
            {
                Console.WriteLine("Person Added Successfully");
            }
            else
            {
                Console.WriteLine("Some error has occured");
            }
        }
        void UpdatePerson()
        {
            Person person = new Person() { Id=1001, LastName = "Sutton", FirstName = "Corey", HireDate = null, EnrollmentDate = DateTime.Now, Discriminator = "Student" };
            if (personService.UpdatePerson(person) > 0)
            {
                Console.WriteLine("Person Added Successfully");
            }
            else
            {
                Console.WriteLine("Some error has occured");
            }
        }
        void DeletePerson()
        {
            if (personService.DeletePerson(1001) > 0)
            {
                Console.WriteLine("Person deleted successfully");
            }
            else
            {
                Console.WriteLine("Some error has occured");
            }
        }
        public void Run()
        {
            PrintAllPerson();
        }
    }
}
