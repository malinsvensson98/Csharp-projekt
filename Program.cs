/* 
Kod skriven av: Malin Svensson 
Program: Webbutveckling, Mittuniversitetet
Kurs: Programmering i C#.NET 
Skapad: 2020-12-15
*/


// Början av C#-fil
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;


// Name of the application
namespace csprojekt
{
    class Program
    {
        // Main-method
        static void Main(string[] args)
        {
           // Boolean that is set to true
            bool showNav = true;

            // While-loop for the comming mainnav
            while (showNav)
            {
                showNav = MainNav();
            }       
             }

             
        private static bool MainNav()
        {
        
            // Write to user
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("🎂  F Ö D E L S E D A G S K O L L E N 🎂");
            Console.ResetColor();
            Console.WriteLine(" ");
            Console.WriteLine("1. Visa sparade födelsedagar 🎈");
            Console.WriteLine(" ");
            Console.WriteLine("2. Spara ny födelsedag 🎉");
            Console.WriteLine(" ");
            Console.WriteLine("3. Radera födelsedag ❌");
            Console.WriteLine(" ");
            Console.WriteLine("4. Ta reda på stjärntecken ⭐");
            Console.WriteLine(" ");
            Console.WriteLine("5. Räkna ut ålder 📅");
            Console.WriteLine(" ");
            Console.WriteLine("6. Avsluta 👋");

            // For JSON
            string jsonPath = @"posts.json";
            var jsonData = System.IO.File.ReadAllText(jsonPath);

            // Deserialize
            var posts = JsonConvert.DeserializeObject<List<create>>(jsonData)
            ?? new List<create>();
                Console.WriteLine("");



            // Switch for reading input 
            switch (Console.ReadLine())
            {
                // Alternative 1 - show data
                case "1":
                // Clear the console
                  Console.Clear();
                  // Check the saved JSON-data
                    if (File.Exists(jsonPath))
                    {
                        Console.WriteLine("Sparade födelsedagar:"); 

                        // Foreach loop to write out the data in the console
                        int startindex = 1;
                        foreach (var birthday in posts)
                        {
                            Console.WriteLine($"[{startindex}] {birthday.name}: {birthday.birthday}");
                            startindex++;
                        }
                        // Create space
                        Console.WriteLine("");
                    };
                    
                var theBirthdays = new savedBirthdays();
                theBirthdays.savedBirthday();
                    return true;




                // Create data 
                case "2":
                    // Add new birthdays
                    var newPost = new create(); 
                    // Save name and dob
                    newPost.CreateABirthday(out string Name, out string Birthday);
                 
                    // Create
                    posts.Add(new create()
                    {
                        name = Name,
                        birthday = Birthday,
                    });

                    // Convert (serialize)
                    jsonData = JsonConvert.SerializeObject(posts);
                    File.WriteAllText(jsonPath, jsonData);

                    // Check the JSON-data to read out
                    if (File.Exists(jsonPath))
                    {
                        Console.WriteLine("Sparade födelsedagar:"); 
                        // Same loop as earlier to write out the data
                        int startindex = 1;
                        foreach (var birthday in posts)
                        {
                            Console.WriteLine($"[{startindex}] {birthday.name}: {birthday.birthday}");
                            startindex++;
                        }
                        Console.WriteLine("");

                    };
                    return true;



                // Delete data
                case "3":
                   // Read data so that the user can pick a number
                  Console.Clear();
                    if (File.Exists(jsonPath))
                    {
                        Console.WriteLine("Sparade födelsedagar:"); 

                        int startindex = 1;
                        foreach (var birthday in posts)
                        {
                            Console.WriteLine($"[{startindex}] {birthday.name}: {birthday.birthday}");
                            startindex++;

                        }
                        Console.WriteLine("");
                    };
                var removepost = new DeletePosts();
                removepost.DeletePost();
                    return true;




                // What zodiac 
                case "4":
                   // Empry console and show saved birthdays
                  Console.Clear();
                    if (File.Exists(jsonPath))
                    {
                        Console.WriteLine("Sparade födelsedagar:"); 

                        int startindex = 1;
                        foreach (var birthday in posts)
                        {
                            Console.WriteLine($"[{startindex}] {birthday.name}: {birthday.birthday}");
                            startindex++;

                        }
                        Console.WriteLine("");
                    };
                    
                var myZodiac = new whatZodiacs();
                myZodiac.whatZodiac();
                    return true;





               // To display how old a person is (divided into days for childs and years for persons older than one)
                case "5":
                     // Displays saved data
                  Console.Clear();
                    if (File.Exists(jsonPath))
                    {
                        Console.WriteLine("Sparade födelsedagar:"); 

                        int startindex = 1;
                        foreach (var birthday in posts)
                        {
                            Console.WriteLine($"[{startindex}] {birthday.name}: {birthday.birthday}");
                            startindex++;

                        }
                        Console.WriteLine("");
                    };

                var countTheDays = new countDays(); 
                countTheDays.countDay(); 
                    return true;
                    break; 




                 // To quit  
                case "6":
                    Console.Clear();
                    return false;
                


                default:
                    return true;
        
        } 
        return true;
        } 

        


    }
}
