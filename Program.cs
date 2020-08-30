using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RhythmsGonnaGetYou
{
    class Band
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CountryOfOrigin { get; set; }
        public int NumberOfMembers { get; set; }
        public string Website { get; set; }
        public string Style { get; set; }
        public bool IsSigned { get; set; }
        public string ContactName { get; set; }
        public string ContactPhoneNumber { get; set; }
    }
    class RhythmsGonnaGetYouContext : DbContext
    {

        public DbSet<Band> Bands { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("server=localhost;database=RhythmsGonnaGetYou");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var context = new RhythmsGonnaGetYouContext();
            var theBands = context.Bands;

            var hasQuitTheApplication = false;
            while (hasQuitTheApplication is false)
            {
                Console.WriteLine("What would you Like to do?");
                Console.WriteLine("ADD - Add a New Band");
                Console.WriteLine("VIEW - View all the Bands");
                Console.WriteLine("ADD ALBUM -  Add a new album");
                Console.WriteLine("LET A BAND GO - Release Band From Contract");
                Console.WriteLine("RESIGN - Resign Band");
                Console.WriteLine("SIGNED - View Signed Bands");
                Console.WriteLine("UNSIGNED - View Unsigned Bands");
                Console.WriteLine("QUIT - Quit the Program");
                Console.WriteLine();
                Console.WriteLine("CHOICE:");
                var choice = Console.ReadLine().ToUpper();

                if (choice == "VIEW")
                {
                    foreach (var band in theBands)
                    {
                        Console.WriteLine($"There is a band named {band.Name}");
                    }
                }
                if (choice == "QUIT")
                {
                    hasQuitTheApplication = true;
                }

                Console.WriteLine("---GOODBYE---");
            }
        }
    }
