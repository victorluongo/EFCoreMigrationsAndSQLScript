using System;
using System.Linq;
using EFCoreMigrationsAndSQLScript.Data;
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
