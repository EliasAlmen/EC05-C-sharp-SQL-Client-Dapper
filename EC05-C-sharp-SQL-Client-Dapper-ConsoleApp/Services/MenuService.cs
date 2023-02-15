﻿using EC05_C_sharp_SQL_Client_Dapper_ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EC05_C_sharp_SQL_Client_Dapper_ConsoleApp.Services
{
    internal class MenuService
    {
        public void CreateNewContact()
        {
            var customer = new Customer();

            Console.WriteLine("Förnamn: ");
            customer.FirstName = Console.ReadLine() ?? "";

            Console.WriteLine("Efernamn: ");
            customer.LastName = Console.ReadLine() ?? "";

            Console.WriteLine("E-postadress: ");
            customer.Email = Console.ReadLine() ?? "";

            Console.WriteLine("Telefonnummer: ");
            customer.PhoneNumber = Console.ReadLine() ?? "";

            Console.WriteLine("Gatuadress: ");
            customer.Address.StreetName = Console.ReadLine() ?? "";

            Console.WriteLine("Postnummer: ");
            customer.Address.PostalCode = Console.ReadLine() ?? "";

            Console.WriteLine("Stad: ");
            customer.Address.City = Console.ReadLine() ?? "";

            //save customer to database
            var database = new DatabaseService();
            database.SaveCustomer(customer);

        }

        public void ListAllContacts()
        {
            //get all customers+address from database
            var database = new DatabaseService();
            var customers = database.GetCustomers();

            if (customers.Any())
            {
                foreach (Customer customer in customers)
                {
                    Console.WriteLine($"Kundnummer: {customer.ID}");
                    Console.WriteLine($"Name: {customer.FirstName} {customer.LastName}");
                    Console.WriteLine($"E-postadress: {customer.Email}");
                }
            }
        }

    }
}
