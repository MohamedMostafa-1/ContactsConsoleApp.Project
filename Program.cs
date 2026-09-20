using ContactsBusinessLayer;
using System;
using System.Data;
using System.Diagnostics.Contracts;


namespace ContactsConsoleApp_PresentationLayer
{
    internal class Program
    {
        private static void _ReadNewContact( ref clsContact Contact1)
        {
            Console.Write("Enter FirstName: ");
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

            Console.Write("Enter Country: ");
            Contact1.CountryID = int.Parse(Console.ReadLine());

            Contact1.DateOfBirth = DateTime.Now;
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
            Console.WriteLine("Add New Contact:- \n");
            clsContact Contact1 = new clsContact();
            _ReadNewContact(ref Contact1);

            if (Contact1.Save())
            {
                Console.WriteLine("Contact Added Successfully with id=" + Contact1.ID);
            }
            else
            {
                Console.WriteLine("Contact Added Failed with id=" + Contact1.ID);

            }


        }
        static void Main(string[] args)
        {
            //testFindContact(2);

            testAddNewContact();
            Console.ReadKey();
        }
    }
}
