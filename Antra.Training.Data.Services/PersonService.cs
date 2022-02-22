using Antra.Training.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antra.Training.Data.Repository;

namespace Antra.Training.Data.Services
{
    public class PersonService : IPersonService
    {
        IRepository<Person> _repository;
        public PersonService()
        {
            _repository = new PersonRepository();
        }
        public int DeletePerson(int id)
        {
            return _repository.Delete(id);
        }

        public IEnumerable<Person> GetAll()
        {
            return _repository.GetAll();
        }

        public Person GetPerson(int id)
        {
            return _repository.Get(id);
        }

        public int InsertPerson(Person person)
        {
            return _repository.Insert(person);
        }

        public int UpdatePerson(Person person)
        {
            return _repository.Update(person);
        }
    }
}
