using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace kgalarzaS5.Models
{
    public class Person
    {
        [PrimaryKey, AutoIncrement]
        public int personId { get; set; }
        [MaxLength(50)]
        public string personName { get; set; }
        [MaxLength (50)]
        public string personLastName { get; set; }

        public Person(int personId, string personName, string personLastName)
        {
            this.personId = personId;
            this.personName = personName;
            this.personLastName = personLastName;
        }

        public Person(string personName, string personLastName)
        {
            this.personLastName = personLastName;
            this.personName = personName; 
        }

        public Person()
        {
        }

    }
}
