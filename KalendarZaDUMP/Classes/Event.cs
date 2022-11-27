using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace KalendarDUMP.Classes
{
    public class Event
    {


        public Guid Id { get; }
        public string NameOfEvent { get; set; }
        public string Location { get; set; }
        public DateTime DateOfBeginning { get; set; }
        public DateTime DateOfEnd { get; set; }
        public List<Person> PeopleList { get; private set; }

        public Event()
        {
            this.Id = Guid.NewGuid();
        }
        public Event(string nameOfEvent, string location, DateTime dateOfBeginning, DateTime dateOfEnd, List<Person> peopleList)
        {
            NameOfEvent = nameOfEvent;
            Location = location;
            DateOfBeginning = dateOfBeginning;
            DateOfEnd = dateOfEnd;
            PeopleList = peopleList;
            this.Id = new Guid();

        }



        public Event(string nameOfEvent, string location, DateTime dateOfBeginning, DateTime dateOfEnd)
        {
            this.NameOfEvent = nameOfEvent;
            this.Location = location;
            this.DateOfBeginning = dateOfBeginning;
            this.DateOfEnd = dateOfEnd;
        }
        public void AddEmailParticipation(List<Person> peopleList)
        {
            this.PeopleList = peopleList;

            for (int i = 0; i < this.PeopleList.Count; i++)
            {
                this.PeopleList[i].AttendanceDict = new Dictionary<Guid, bool>();
                this.PeopleList[i].AttendanceDict.Add(this.Id, true);
            }
        }
        public void ChangePresence(List<Person> peopleList)
        {
            var counter = 0;
            this.PeopleList = peopleList;
            Console.WriteLine("Unesi email neprisutne osobe:");
            var emailOfPerson = Console.ReadLine();
            for (int i = 0; i < this.PeopleList.Count; i++)
            {
                if (this.PeopleList[i].Equals(emailOfPerson))
                {
                    Console.WriteLine("Unesi id eventa:");
                    var idOfEvent = Console.ReadLine();
                    this.PeopleList[i].AttendanceDict.Add(this.Id, false);
                    counter = 1;
                }
            }
            if (counter == 0)
            {
                Console.WriteLine("Osoba ili event ne postoje!");
            }

        }
        public void ActiveEvents()
        {

            if (this.DateOfBeginning <= DateTime.Now && this.DateOfEnd >= DateTime.Now)
            {
                Console.WriteLine(
                    $"Id: {this.Id}\n" +
                    $"Name of event: {this.NameOfEvent}\n" +
                    $"Location: {this.Location}\n" +
                    $"Ends in: {this.DateOfEnd}\n");
                Console.WriteLine("Participants: ");
                foreach (var person in this.PeopleList)
                {
                    Console.WriteLine($"{person.Email}, ");
                }
                Console.WriteLine("---------------------");
            }

        }

        public void FutureEvents()
        {

            if (this.DateOfBeginning > DateTime.Now && this.DateOfEnd > DateTime.Now)
            {
                Console.WriteLine(
                    $"Id: {this.Id}\n" +
                    $"Name of event: {this.NameOfEvent}\n" +
                    $"Location: {this.Location}\n" +
                    $"Begins in: {this.DateOfBeginning}\n");
                Console.WriteLine("Participants: ");
                foreach (var person in this.PeopleList)
                {
                    Console.WriteLine($"{person.Email}, ");
                }
                Console.WriteLine("---------------------");
            }

        }
        public void PassedEvents()
        {

            if (this.DateOfBeginning < DateTime.Now && this.DateOfEnd < DateTime.Now)
            {
                Console.WriteLine(
                    $"Id: {this.Id}\n" +
                    $"Name of event: {this.NameOfEvent}\n" +
                    $"Location: {this.Location}\n" +
                    $"Begins in: {this.DateOfBeginning}\n");
                Console.WriteLine("Participants: ");
                foreach (var person in this.PeopleList)
                {
                    Console.WriteLine($"{person.Email}, ");
                }
                Console.WriteLine("---------------------");
            }

        }


    }
}
