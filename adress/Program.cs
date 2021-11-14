using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace adress
{
    class Program
    {
        public static List<Person> People = new List<Person>();
        static void Main()
        {
            string command = "";
            while (command != "exit")
            {
                Console.Clear();
                Console.WriteLine("Please enter a command: ");
                command = Console.ReadLine().ToLower();

                switch (command)
                {
                    case "add":
                        AddPerson();
                        break;
                    case "remove":
                        RemovePerson();
                        break;
                    case "list":
                        ListPeople();
                        break;
                    case "update":
                        UpdatePerson();
                        break;
                    case "search":
                        SearchPerson();
                        break;
                    default:
                        if (command != "exit")
                        {
                            DisplayHelp();
                        }
                        break;
                }
            }
        }

        private static void DisplayHelp()
        {
            Console.Clear();
            Console.WriteLine("Commands:");
            Console.WriteLine("add\tAdds a person to address book");
            Console.WriteLine("update\tUpdate a person from address book");
            Console.WriteLine("remove\tRemoves a person from address book");
            Console.WriteLine("list\tLists out all people in the address book");
            Console.WriteLine("search\tSearches for a person in the address book by first name");
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
        }


        private static void UpdatePerson()
        {
            Console.Clear();


            try
            {
                Console.Write("ID : ");
                int id = int.Parse(Console.ReadLine());
                Person thisPerson = People.Where(x => x.thisID == id).First();
                Console.Write("New name : ");

                string firstName = Console.ReadLine();

                Console.Write("Last Name : ");

                string lastName = Console.ReadLine();

                Console.Write("Phone Number : ");

                string phoneNumber = Console.ReadLine();


                string[] adresses = new string[2];

                Console.Write("Adress 1 : ");

                adresses[0] = Console.ReadLine();

                Console.Write("Adress 2  : ");

                adresses[1] = Console.ReadLine();


                thisPerson.firstName = firstName;
                thisPerson.lastName = lastName;
                thisPerson.phoneNumber = phoneNumber;
                thisPerson.addresses = adresses;


                Console.ReadLine();
            }


            catch
            {
                Console.WriteLine("This ID not found");
                Console.ReadLine();
            }




        }



        private static void AddPerson()
        {
            Console.Clear();

            Person person = new Person();

            Console.Write("Enter First Name: ");
            person.firstName = Console.ReadLine();

            Console.Write("Enter Last Name: ");
            person.lastName = Console.ReadLine();

            Console.Write("Enter Phone Number: ");
            person.phoneNumber = Console.ReadLine();

            Console.Write("Enter Address 1: ");
            string[] addresses = new string[2];
            addresses[0] = Console.ReadLine();
            Console.Write("Enter Address 2 (Optional): ");
            addresses[1] = Console.ReadLine();
            person.addresses = addresses;

            People.Add(person);
        }

        private static void RemovePerson()
        {
            List<Person> people = FindPeopleByFirstName();

            Console.Clear();

            if (people.Count == 0)
            {
                Console.WriteLine("That person could not be found. Press any key to continue");
                Console.ReadKey();
                return;
            }

            if (people.Count == 1)
            {
                RemovePersonFromList(people[0]);
                return;
            }

            Console.WriteLine("Enter the number of the person you want to remove");
            for (int i = 0; i < people.Count; i++)
            {
                Console.WriteLine(i);
                PrintPerson(people.ElementAt(i));
            }
            int removePersonNumber = Convert.ToInt32(Console.ReadLine());
            if (removePersonNumber > people.Count - 1 || removePersonNumber < 0)
            {
                Console.WriteLine("That number is invalid. Press any key to continue.");
                Console.ReadKey();
                return;
            }
            RemovePersonFromList(people.ElementAt(removePersonNumber));
        }

        private static void RemovePersonFromList(Person person)
        {
            Console.Clear();
            Console.WriteLine("Are you sure you want to remove this person from your address book? (Y/N)");
            PrintPerson(person);

            if (Console.ReadLine() == "y" | Console.ReadLine() == "Y")
            {
                People.Remove(person);
                Console.Clear();
                Console.WriteLine("Person removed. Press any key to continue.");
                Console.ReadKey();
            }
        }

        private static void SearchPerson()
        {
            List<Person> people = FindPeopleByFirstName();
            Console.Clear();
            if (people.Count == 0)
            {
                Console.WriteLine("That person could not be found. Press any key to continue");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Here are the current people in your address book matching that search:\n");
            foreach (var person in people)
            {
                PrintPerson(person);
            }
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
        }

        private static List<Person> FindPeopleByFirstName()
        {
            Console.Clear();
            Console.WriteLine("Enter the first name of the person you would like to find.");
            string firstName = Console.ReadLine();
            return People.Where(x => x.firstName.ToLower() == firstName.ToLower()).ToList();
        }

        private static void ListPeople()
        {
            Console.Clear();
            if (People.Count == 0)
            {
                Console.WriteLine("Your address book is empty. Press any key to continue.");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("Here are the current people in your address book:\n");
            foreach (var person in People)
            {
                PrintPerson(person);
            }
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
        }

        private static void PrintPerson(Person person)
        {
            Console.WriteLine("First Name: " + person.firstName);
            Console.WriteLine("Last Name: " + person.lastName);
            Console.WriteLine("Phone Number: " + person.phoneNumber);
            Console.WriteLine("Address 1: " + person.addresses[0]);
            Console.WriteLine("Address 2: " + person.addresses[1]);
            Console.WriteLine("-------------------------------------------");
        }
    }

    public class Person
    {
        public Person()
        {
            thisID = id++;
            Console.WriteLine("ID : " + thisID);
        }
        public static int id { get; set; }
        public int thisID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string phoneNumber { get; set; }
        public string[] addresses { get; set; }
    }
}
