using ContactsBusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Contracts;
using System.Threading;


namespace ContactsConsoleApp_PresentationLayer
{
    internal class Program
    {
        private static clsContact _ReadNewContact(ref clsContact Contact1)
        {
            
            Console.Write("\n\nEnter FirstName: ");
            Contact1.FirstName = Console.ReadLine();

            Console.Write("Enter LastName: ");
            Contact1.LastName = Console.ReadLine();

            Console.Write("Enter Email: ");
            Contact1.Email = Console.ReadLine();

            Console.Write("Enter Phone: ");
            Contact1.Phone = Console.ReadLine();

            Console.Write("Enter Address: ");
            Contact1.Address = Console.ReadLine();

            Console.Write("Enter ImagePath: ");
            Contact1.ImagePath = Console.ReadLine();

            Console.Write("Enter CountryID: ");
            Contact1.CountryID = int.Parse(Console.ReadLine());

            Contact1.DateOfBirth = DateTime.Now;

            return Contact1;
        }
        static void testFindContact(int ID)
        {
            clsContact contact = clsContact.Find(ID);

            if(contact != null)
            {
                Console.WriteLine("ID: " + contact.ID);
                Console.WriteLine("FirstName: " + contact.FirstName);
                Console.WriteLine("LastName: " + contact.LastName);
                Console.WriteLine("Email: " + contact.Email);
                Console.WriteLine("Phone: " + contact.Phone);
                Console.WriteLine("Address: " + contact.Address);
                Console.WriteLine("ImagePathe: " + contact.ImagePath);
                Console.WriteLine("CountryID: " + contact.CountryID);
                Console.WriteLine("DateOfBirth: " + contact.DateOfBirth);
            }
            else
            {
                Console.WriteLine("Contact [" + ID + "] Not Found");   
            }
        }
        static void testAddNewContact()
        {
            Console.WriteLine("\n -- Add New Contact -- ");

            clsContact Contact1 = new clsContact();
            Contact1 =  _ReadNewContact(ref Contact1);

            if (Contact1.Save())
            {
                Console.WriteLine("Contact Added Successfully with id = " + Contact1.ID);
            }
            else
            {
                Console.WriteLine("Contact Added Failed with id = " + Contact1.ID);
            }


        }
        static void PrintContactByID(int ID) {
            clsContact Contact1 = clsContact.Find(ID);
            if(Contact1 != null)
            {
                Console.WriteLine("\n--- Contact Information ---");

                Console.WriteLine("ID: " + Contact1.ID);
                Console.WriteLine("FirstName: " + Contact1.FirstName);
                Console.WriteLine("LastName: " + Contact1.LastName);
                Console.WriteLine("Email: " + Contact1.Email);
                Console.WriteLine("Phone: " + Contact1.Phone);
                Console.WriteLine("Address: " + Contact1.Address);
                Console.WriteLine("DateOfBirth: " + Contact1.DateOfBirth);
                Console.WriteLine("CountryID: " + Contact1.CountryID);
                Console.WriteLine("ImagePath: " + Contact1.ImagePath);
            }
            else
            {
                Console.WriteLine("Not Found That Contact ~_~");
            }
        }
        static void testUpdateContact(int ID)
        {
            clsContact Contact1 = clsContact.Find(ID);


            if(Contact1 != null)
            {
                PrintContactByID(ID);

                Contact1 = _ReadNewContact(ref Contact1);
                Contact1.ID = ID;

                if (Contact1.Save())
                  Console.WriteLine("Contact Update Successfully ^_^");
                else
                  Console.WriteLine("Contact Update Failed >_<");  
            }
            else
            {
                Console.WriteLine("Not Found That Contact");
            }

        }
        static void testDeleteContact(int ID)
        {
            if (clsContact.DelectContact(ID))
                Console.WriteLine("Contact Delete Successfully ^_^");
            else
                Console.WriteLine("Contact Delete Failed >_<");

        }
        static void ListContacts()
        {
            DataTable dataTable = clsContact.ListContacts();

            Console.WriteLine("\n -- List Contacts -- \n");

            foreach (DataRow row in dataTable.Rows)
            {
                Console.WriteLine($"ID: {row["ContactID"]}     FirstName: {row["FirstName"]}     LastName: {row["LastName"]}    ");
            }



        }


        //Countries
        static void testFindCountryByID(int ID)
        {
            clsCountries Country = clsCountries.Find(ID);

            if(Country != null)
            {
                Console.WriteLine("ID: " + Country.ID);
                Console.WriteLine("Country Name: " + Country.Name);
            }
            else
            {
                Console.WriteLine("Not Found Country ID = " + ID.ToString());
            }

        }
        static void testFindCountryByName(string CountryName)
        {
            clsCountries Country = clsCountries.Find(CountryName);

            if(Country != null)
            {
                Console.WriteLine("ID: " + Country.ID);
                Console.WriteLine("Country Name: " + Country.Name);
            }
            else
            {
                Console.WriteLine("Not Found Country Name = " + CountryName);
            }
        }

        static void Main(string[] args)
        {

            //// --Contacts
            //testFindContact(2);
            //testAddNewContact();
            //testUpdateContact(16);
            //testDeleteContact(17);
            //ListContacts();


            // Countries
            //testFindCountryByID(1);
            testFindCountryByName("United States");




            //testIsCountryExistByID(1);
            //testIsCountryExistByName(1);


            //testAddNewCountry();
            //testUpdateCountry(6);
            //testDeleteCountry(6);
            //ListCountries();


            Console.ReadKey();
        }
    }
}
