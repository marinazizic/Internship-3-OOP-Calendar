using KalendarDUMP.Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Formats.Asn1;
using System.Numerics;
using System.Reflection;

namespace KalendarDUMP
{
    class Program
    {
        static void Main(string[] args)
        {



            var counterMenu = 0;
            var PeopleList = new List<Person>()
            {
                new Person("Mate", "Matić", "matematic@yahoo.com"),
                new Person("Ivo", "Ivic", "ivoivic@gmail.com"),
                new Person("Pero", "Perić", "pericp@gmail.com"),
                new Person("Ivana", "Ivanić", "ivanaivanic@yahoo.com"),
                new Person("Maro", "Marić", "mmaric@gmail.com"),
                new Person("Gabrijela", "Gabrijelić", "gabrijelag@gmail.com"),
                new Person("Zvone","Zvonić", "zvoniczvone@yahoo.com"),
                new Person("Duje","Dujić", "dujedujic@gmail.com"),
                new Person("Luce","Lučić", "lucelucic@yahoo.com"),
                new Person("Marin","Marinic", "marinicm@yahoo.com")
            };

            var AllEvents = new List<Event>()
            {
                new Event("Motivational speech", "Daltonist", DateTime.Now, DateTime.Now.AddDays(2), PeopleList),
                new Event("Debate", "Caffe Bar Domaćin", new DateTime(2022, 12, 6, 19, 30, 00), new DateTime(2022, 12, 6, 21, 00, 00), PeopleList),
                new Event("Gift exchange", "Calypso", new DateTime(2022, 12, 25, 20, 15, 00), new DateTime(2022, 12, 25, 23, 00, 00), PeopleList),
                new Event("Volunteering", "Marjan", new DateTime(2022, 10, 3, 15, 00, 00), new DateTime(2022, 10, 3, 18, 00, 00), PeopleList),
                new Event("Birthday party", "Ivana's home", new DateTime(2021, 7, 6, 18, 00, 00), new DateTime(2021, 7, 7, 00, 00, 00), PeopleList),
            };


            AllEvents[0].AddEmailParticipation(new List<Person>() { PeopleList[0], PeopleList[1] });
            AllEvents[1].AddEmailParticipation(new List<Person>() { PeopleList[2],
PeopleList[3] });
            AllEvents[2].AddEmailParticipation(new List<Person>() { PeopleList[4], PeopleList[5] });
            AllEvents[3].AddEmailParticipation(new List<Person>() { PeopleList[6], PeopleList[6] });
            AllEvents[4].AddEmailParticipation(new List<Person>() { PeopleList[8], PeopleList[9] });



            do
            {
                DoMenu();
                var menuChoice = int.Parse(Console.ReadLine());
                switch (menuChoice)
                {
                    case 1:
                        foreach (var events in AllEvents)
                            events.ActiveEvents(); //ispis aktivnih
                        Console.WriteLine("1 - Zabilježi neprisutnosti");
                        Console.WriteLine("2 - Povratak na glavni meni");
                        var activeMenu = int.Parse(Console.ReadLine());
                        switch (activeMenu)
                        {
                            case 1://nedovršeno
                                break;
                            case 2:
                                GoBackToMainMenu();
                                break;
                            default:
                                Console.WriteLine("Nepoznata radnja");
                                break;
                        }
                        break;
                    case 2:
                        foreach (var events in AllEvents)
                            events.FutureEvents(); //ispis nadolazecih
                        Console.WriteLine("1 - Izbriši event");
                        Console.WriteLine("2 - Ukloni osobe s eventa");
                        Console.WriteLine("3 - Povratak na glavni menu");
                        var upcomingMenu = int.Parse(Console.ReadLine());
                        switch (upcomingMenu)
                        {
                            case 1:
                                Console.WriteLine("Upiši id eventa kojeg želite izbrisati");
                                var deleteEvent = Console.ReadLine();
                                var newId = new Guid(deleteEvent);
                                DoDoubleChecking();
                                if (DoDoubleChecking() == true)
                                    DeleteEvent(newId);
                                else
                                    GoBackToMainMenu();
                                break;
                            case 2:
                                Console.WriteLine("Upiši email osobe koju želiđš izbrisati s eventa");
                                var deleteEmail = Console.ReadLine();
                                SearchAndDeletePerson(deleteEmail, PeopleList);
                                break;
                            case 3: //nedovršeno
                                GoBackToMainMenu();
                                break;
                            default: //nedovršeno
                                Console.WriteLine("Nepoznata radnja");
                                GoBackToMainMenu();
                                break;
                        }
                        break;
                    case 3:
                        foreach (var events in AllEvents)
                            events.PassedEvents(); //ispis koji su zavrsili
                        GoBackToMainMenu();
                        break;
                    case 4:
                        //MakeANewEvent(); !!!!! znam da mi je nesto u ovoj funkciji krivo, ne znam sto tocno zato jer je radila i onda sam slucajno undoala par stvari i nisam ih ikako mogla oporaviti tako da da. pardon :(


                        //unos naziva lokacije datuma emailova (buducnost, pocetak ne moze bit prije ocetka)
                        //ispisuje poruku za osobe koje su vec stavljene kao sudionik u jednom eventu da su zauzete
                        //svaka osoba ce bit prisutna pri unosu
                        GoBackToMainMenu();
                        break;
                    case 5: //Izlaz iz programa
                        counterMenu = 1;
                        break;
                    default:
                        Console.WriteLine("Nepoznata radnja");
                        GoBackToMainMenu();
                        break;


                }

            } while (counterMenu == 0);

            void DoMenu()
            {
                Console.WriteLine("1 - Aktivni eventi");
                Console.WriteLine("2 - Nadolazeći eventi");
                Console.WriteLine("3 - Završeni eventi");
                Console.WriteLine("4 - Kreiraj event");
                Console.WriteLine("5 - Izađi iz programa");
                counterMenu = 0;
            }

            void GoBackToMainMenu()
            {
                counterMenu = 1;
                Console.WriteLine("Vratiti se na pocetni izbornik? y/n");
                var counter = 1;
                do
                {
                    var yesOrNo = Console.ReadLine();
                    if (yesOrNo == "y")

                    {
                        counterMenu = 0;
                        counter = 0;
                    }
                    else if (yesOrNo == "n")
                    {
                        counterMenu = 1;
                        counter = 0;
                    }

                    else
                    {
                        Console.WriteLine("Nepoznata radnja");
                        Console.WriteLine("Vratiti se na pocetni izbornik? y/n");
                        counter = 1;

                    }

                } while (counter > 0);
            }

            bool DoDoubleChecking()
            {
                Console.WriteLine("Jeste li sigurni da želite trajno promjeniti ili izbrisati podatke? y/n");
                var doubleCheck = Console.ReadLine();
                var counter = 1;
                while (counter > 0)
                {
                    if (doubleCheck == "y")
                    {
                        counter = 0;
                        return true;
                    }
                    else if (doubleCheck == "n")
                    {
                        counter = 0;
                        return false;
                    }
                    else
                        counter = 1;
                };
                return false;
            }

            void ActiveEvents(List<Event> activeEvents)
            {
                var eventIdList = new List<string>();
                foreach (var eventId in activeEvents)
                {
                    eventIdList.Add(eventId.Id.ToString());
                }
            }

            void SearchAndDeletePerson(string searchEmail, List<Person> FindingPeople)
            {
                var found = 0;
                foreach (var person in FindingPeople)
                {
                    if (person.Email == searchEmail)
                        FindingPeople.Remove(person);
                    found = 1;
                }
                if (found == 0)
                    Console.WriteLine("Osoba ne postoji!");
            }

            void DeleteEvent(Guid NewId)
            {
                var counter = 1;
                while (counter > 0)
                {
                    for (int i = 0; i < AllEvents.Count; i++)
                    {
                        if (AllEvents[i].Id == (NewId))
                        {
                            foreach (var events in PeopleList)
                                events.AttendanceDict.Clear();
                            AllEvents.Remove(AllEvents[i]);
                            Console.WriteLine("Event izbrisan");
                            counter = 0;
                        }
                    }
                    Console.WriteLine("Event nemoguće pronaći");
                    counter = 0;
                }
            }
        }

        void MakeANewEvent()
        {
            Console.WriteLine("Unesi ime:");
            var nameOfEvent = Console.ReadLine();
            Console.WriteLine("Unesi lokaciju:");
            var location = Console.ReadLine();
            Console.WriteLine("Unesi početak eventa: year/month/day");
            var dateOfBeginning = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Unesi kraj eventa: year/month/day");
            var dateOfEnd = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Koliko sudionika unosis?");
            var numOfParticipants = int.Parse(Console.ReadLine());
            if (dateOfEnd > dateOfBeginning)
                Console.WriteLine("Nemoguće napraviti event");
            var newEvent = new Event(nameOfEvent, location, dateOfBeginning, dateOfEnd);
            var listPeople = new List<Person>();
            while (numOfParticipants > 0)
            {
                var i = 1;
                while (i > 0)
                {
                    Console.WriteLine("Unesi email osobe");
                    var newEmail = Console.ReadLine();
                    if (newEmail.Contains(".com"))
                    {
                        Console.WriteLine("Unesi ime");
                        var name = (Console.ReadLine());
                        Console.WriteLine("Unesi prezime");
                        var lastName = (Console.ReadLine());
                        var person = new Person(name, lastName, newEmail);
                        i = 0;
                        listPeople.Add(person);
                    }
                    else
                        Console.WriteLine("Krivo unešen mail");
                    i = 1;
                }
            }

        }


    }
}
