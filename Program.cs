using System;
using System.Data;
using ContactsBusinessLayer;


namespace ContactsConsoleApp_PresentationLayer
{
    internal class Program
    {

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
        static void Main(string[] args)
        {
            testFindContact(1);

            Console.ReadKey();
        }
    }
}
