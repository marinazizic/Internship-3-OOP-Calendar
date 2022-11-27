using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace KalendarDUMP.Classes
{
    public class Person
    {
        public string Name { get; }
        public string LastName { get; }
        public string Email { get; }
        public Dictionary<Guid, bool> AttendanceDict { get; set; }
        public Person(string name, string lastName, string email)
        {
            this.Name = name;
            this.LastName = lastName;
            this.Email = email;
        }
    }

}
