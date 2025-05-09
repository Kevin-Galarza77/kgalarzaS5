using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kgalarzaS5.Models;
using SQLite;

namespace kgalarzaS5.Repositories
{
    public class PersonRepository
    {
        String dbPath;
        private SQLiteConnection conn;
        public string statusMessage { get; set; }

        public PersonRepository(String dbPath)
        {
            this.dbPath = dbPath;
        }

        private void Init()
        {
            if (conn is not null)
            {
                return;
            }

            conn = new(dbPath);
            conn.CreateTable<Person>();

        }

        public Boolean AddNewPerson(Person person)
        {
            try
            {

                Init();

                if (String.IsNullOrEmpty(person.personName) || String.IsNullOrEmpty(person.personLastName))
                {
                    return false;
                }

                conn.Insert(person);

                return true;
            }
            catch (Exception ex)
            {
                statusMessage = string.Format("ERROR >> " + ex);
                return false;
            }
        }

        public Boolean UpdatePerson(Person person)
        {
            try
            {

                Init();

                if (String.IsNullOrEmpty(person.personName) || String.IsNullOrEmpty(person.personLastName))
                {
                    return false;
                }

                conn.Update(person);

                return true;
            }
            catch (Exception ex)
            {
                statusMessage = string.Format("ERROR >> " + ex);
                return false;
            }
        }

        public Boolean DeletePerson(Person person)
        {
            try
            {

                Init();

                conn.Delete(person);

                return true;
            }
            catch (Exception ex)
            {
                statusMessage = string.Format("ERROR >> " + ex);
                return false;
            }
        }

        public List<Person> ListAllPersons()
        {
            try
            {
                
                Init();
             
                return conn.Table<Person>().ToList();
            }
            catch (Exception ex)
            {
                statusMessage = string.Format("ERROR >> " + ex);
                return new List<Person>();
            }
        }

    }
}
