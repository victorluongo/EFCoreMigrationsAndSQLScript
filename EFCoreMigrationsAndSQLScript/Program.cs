using System;
using System.Linq;
using EFCoreMigrationsAndSQLScript.Data;
using EFCoreMigrationsAndSQLScript.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreMigrationsAndSQLScript
{
    class Program
    {
        static void Main(string[] args)
        {

            using var _context = new ApplicationContext();

            Console.WriteLine("\n\n- - - - - - - - - - - - -");
            Console.WriteLine("Choose an option:");
            Console.WriteLine("- - - - - - - - - - - - -");
            Console.WriteLine("[1] HealthCheck");
            Console.WriteLine("[2] Create Database");
            Console.WriteLine("[3] Add Random Records");
            Console.WriteLine("[4] Script Database");
            Console.WriteLine("[5] Migrations List");
            Console.WriteLine("[6] Pending Migrations");
            Console.WriteLine("[7] Execute Migrations");
            Console.WriteLine("[8] Delete Database");
            Console.WriteLine("[9] Exit");
            Console.WriteLine("- - - - - - - - - - - - -\n");

            var key = Console.ReadKey();
            switch (key.KeyChar)
            {
                case '1':
                    if (!HealthCheck(_context)) {
                        
                        ConsoleTextBox("Database not found!");

                    } else {
                        
                        ConsoleTextBox("Connection successful.");

                    }
                    break;
                
                case '2':
                    CreateDatabase(_context);
                    break;

                case '3':
                    AddRandomRecords(_context);
                    break;

                case '4':
                    ScriptDatabase(_context);
                    break;

                case '5':
                    MigrationsList(_context);
                    break;

                case '6':
                    PendingMigrations(_context);
                    break;

                case '7':
                    ExecuteMigrations(_context);
                    break;

                case '8':
                    DeleteDatabase(_context);
                    break;
                
                case '9':
                    Environment.Exit(0);
                    break;                       
            }

            Main(args);
        }

        static bool HealthCheck(ApplicationContext _context)
        {
            bool healthCheck = _context.Database.CanConnect();
            
            return healthCheck;

        }

        static void CreateDatabase(ApplicationContext _context) 
        {
            if (!HealthCheck(_context)) {
                
                _context.Database.EnsureCreated();

                ConsoleTextBox("Database created.");
    
            } else {

                ConsoleTextBox("Database already exists!");

            }
        }

        static void DeleteDatabase(ApplicationContext _context) 
        {
            if (!HealthCheck(_context)) {
                
                ConsoleTextBox("Database not found!");

            } else {

                _context.Database.EnsureDeleted();

                ConsoleTextBox("Database deleted.");

            }
        }

        static void ScriptDatabase(ApplicationContext _context)
        {
            var scriptDatabase = _context.Database.GenerateCreateScript();
            
            ConsoleTextBox("Database Sript: \n");
            Console.WriteLine(scriptDatabase);

        }

        static void AddRandomRecords(ApplicationContext _context)
        {

            var random = new Random().Next().ToString(); 

            var customer = new Customer
            {
                Name = $"Customer #{random}",
                Email = $"customer{random}@companyname.com",
            };

            _context.Set<Customer>().Add(customer);            
            _context.SaveChanges();    
    
        }

        static void MigrationsList(ApplicationContext _context)
        {
            
            var migrationsList = _context.Database.GetMigrations();

            if(migrationsList.Count()==0){

                ConsoleTextBox("No migrations found!");

            } else {

                ConsoleTextBox("Migrations List:");

                foreach(var migration in migrationsList)
                {
                    
                    Console.Write($"\n - {migration}");

                }
            }

        }

        static void PendingMigrations(ApplicationContext _context)
        {
                    
            var pendingMigrations = _context.Database.GetPendingMigrations();

            if(pendingMigrations.Count()==0){

                ConsoleTextBox("No pending migrations found!");

            } else {

                ConsoleTextBox("Pending migrations:");

                foreach(var migration in pendingMigrations)
                {
                    
                    Console.Write($"\n * {migration}");

                }
            }

        }    

        static void ExecuteMigrations(ApplicationContext _context)
        {
        
            _context.Database.Migrate();

        }           

        static void ConsoleTextBox(string _text)      
        {
       
            var _consoleTextBox  = "\n";
                _consoleTextBox += "\n- - - - - - - - - - - - -\n";
                _consoleTextBox += _text;
                _consoleTextBox += "\n- - - - - - - - - - - - -";
            
            Console.WriteLine (_consoleTextBox);
        }

    }
}
