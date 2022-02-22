using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using Antra.Training.Data.Entity;
using Dapper;
using System.Data.SqlClient;

namespace Antra.Training.Data.Repository
{
    public class PersonRepository : IRepository<Person>
    {
        IDbConnection dbConnection;
        public PersonRepository()
        {
            dbConnection = new SqlConnection("Data Source=DESKTOP-EJSHKKP;Initial Catalog=University;Integrated Security=True");
        }
        public int Delete(int id)
        {
            return dbConnection.Execute("Delete from Person where Id = @pid", new {pid=id});

        }

        public Person Get(int id)
        {
            return dbConnection.QueryFirstOrDefault<Person>("Select Id, LastName, FirstName, HireDate, EnrollmentDate, Discriminator from Person Where Id= @pid", new {pid = id});
        }

        public IEnumerable<Person> GetAll()
        {
            return dbConnection.Query<Person, Department, Person>(@"Select p.Id, p.LastName, p.FirstName, p.EnrollmentDate, p.HireDate, p.Discriminator, d.DepartmentID, 
                                                d.Budget, d.InstructorID, d.Name, d.RowVersion, d.StartDate from Person p 
                                                inner join Department d on p.ID = d.InstructorID", (p, d) => { p.Department = d; return p; }, splitOn: "InstructorID");

            //return dbConnection.Query<Person>("Select Id, LastName, FirstName, HireDate, EnrollmentDate, Discriminator from Person");
        }

        public int Insert(Person entity)
        {
            return dbConnection.Execute("Insert into Person values (@LastName, @FirstName, @HireDate, @EnrollmentDate, @Discriminator)", entity);
        }

        public int Update(Person entity)
        {
            return dbConnection.Execute("Update Person set LastName = @LastName, FirstName = @FirstName, HireDate = @HireDate, EnrollmentDate = @EnrollmentDate, @Discriminator = Discriminator) where Id = @Id", entity);

        }
    }
}
