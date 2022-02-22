using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antra.Training.Data.Repository;
using Antra.Training.Data.Entity;

namespace Antra.Training.Data.Services
{
    public interface IPersonService
    {
        int InsertPerson(Person person);
        int UpdatePerson(Person person);
        Person GetPerson(int id);
        int DeletePerson(int id);
        IEnumerable<Person> GetAll();

    }
}
