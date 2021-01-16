/* 
Kod skriven av: Malin Svensson 
Program: Webbutveckling, Mittuniversitetet
Kurs: Programmering i C#.NET 
Skapad: 2021-01-15
*/


// Start of the application
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// Name of application
namespace csprojekt
{
    // To create new birthdays 
    public class create
    {
        public string name { get; set; }
        public string birthday { get; set; }
        public void CreateABirthday(out string Name, out string Birthday)
        {
            do
            {
                // Clear existing text in console
                Console.Clear();
                // Ask about name of the person
                Console.Write("Ange namn: ");
                // Save input in "Name"
                Name = Console.ReadLine();
            }

            // Check if empty
            while (string.IsNullOrEmpty(Name.Trim()));
            do
            {
                // Ask about birthday
                Console.Write("Ange födeledag (MM/DD/YYYY): ");

                // Save value in "Birthday"
                Birthday = Console.ReadLine();
            } while (string.IsNullOrEmpty(Birthday.Trim())); 

        } 
        } 
        
    // Show saved birthdays
    public class savedBirthdays { 
        public void savedBirthday (){ 

            string doAgain = "Y";
            while (doAgain == "Y" || doAgain == "y")
            {               
                // Choose to go back or exit
                Console.WriteLine(""); 
                Console.WriteLine("Vill du gå tillbaka? (ja eller nej)");
                doAgain = Console.ReadLine();
                if (doAgain == "Nej" || doAgain == "nej")
                {
                    Console.Clear();
                    System.Environment.Exit(1);
                }
            }

        }
    }



    // To delete saved birthday
    public class DeletePosts
    {
        public void DeletePost()
        {
    
            // Set to true 
            var delete = true;
            do{ 
            // Ask about which birthday
            Console.Write("Födelsedag som ska raderas (ID): ");
            
            // JSON
            string jsonPath = @"posts.json";
            var jsonData = System.IO.File.ReadAllText(jsonPath);
            
            // Convert/deserlialize 
            var posts = JsonConvert.DeserializeObject<List<create>>(jsonData)
            ?? new List<create>();

            try
            {
                // Convert and use intreger for index
                int delIndex = Convert.ToInt32(Console.ReadLine()) - 1;

                // Dereralize
                posts = JsonConvert.DeserializeObject<List<create>>(jsonData)
                ?? new List<create>();

                posts.RemoveAt(delIndex);

                // Serialize 
                jsonData = JsonConvert.SerializeObject(posts);
                File.WriteAllText(jsonPath, jsonData);

                // Change to false when done
                delete = false;
            }

            // For error message when user does not enter a correct number
            catch (FormatException)
            {   
                // Empty console
                Console.Clear();
                // Write out the error-message
                Console.WriteLine("Ange siffra i formatet '1'");
                delete = true;
            }
            // Error-message but for when the number is none-existing
             catch (ArgumentOutOfRangeException)
                {
                    Console.Clear();
                    Console.WriteLine("Ange ett värde som finns lagrat");
                    delete = true;
                }
            }while(delete);
     
        }
    }



     // Code for zodiac 
    public class whatZodiacs { 
        public void whatZodiac () { 

            string doAgain = "Y";
            while (doAgain == "Y" || doAgain == "y")
            {   
                // String for input
                string theBirthday;
                DateTime date = new DateTime();

                // Ask about birthday in MM/DD/YYYY
                Console.WriteLine("Skriv in födelsedagen (MM/DD/YYYY): ");
                theBirthday = Console.ReadLine();
                Console.Clear();

                // Convert to DateTime
                try
                {
                    date = Convert.ToDateTime(theBirthday);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Fel: " + e.Message);
                    Console.WriteLine("Programmet avslutas"); 
                    Console.WriteLine(" "); 
                    System.Environment.Exit(1);
                }

                // Switch to pick the right zodiac depending on what birthday that has been written 
                switch (date.Month)
                {
                    case 1: if (date.Day <= 20)
                        { Console.WriteLine("Stjärntecknet för födeledagen är stenbock ♑︎.");
                        Console.WriteLine("Stenbocken, eller Capricorn på latin och engelska, är ett stjärntecken vars styrkor är ansvarstagande, disciplin, ambition och sinne för humor. "); }
                        else
                        { Console.WriteLine("Stjärntecknet för födeledagen är vattumannen.");
                        Console.WriteLine("Vattumannen, eller Aquarius på latin och engelska, är ett stjärntecken vars styrkor är progressivitet, oberoende och humanism.");}
                        break;
                    case 2: if (date.Day <= 19)
                        { Console.WriteLine("Stjärntecknet för födeledagen är vattumannen.");
                        Console.WriteLine("Vattumannen, eller Aquarius på latin och engelska, är ett stjärntecken vars styrkor är progressivitet, oberoende och humanism.");  }
                        else
                        { Console.WriteLine("Stjärntecknet för födeledagen är fiskarna"); 
                        Console.WriteLine("Fiskarna, eller Pisces på latin och engelska, är ett stjärntecken vars styrkor är medkänsla, konstnärlighet, intuition, klokhet och musikalitet.");}
                        break;
                    case 3: if (date.Day <= 20)
                        { Console.WriteLine("Stjärntecknet för födeledagen är fiskarna.");
                          Console.WriteLine("Fiskarna, eller Pisces på latin och engelska, är ett stjärntecken vars styrkor är medkänsla, konstnärlighet, intuition, klokhet och musikalitet.");}

                        else
                        { Console.WriteLine("Stjärntecknet för födeledagen är väduren."); 
                        Console.WriteLine("Väduren, eller Aries på latin och engelska, är ett stjärntecken vars styrkor är mod, beslutsamhet, entusiasm, optimism, ärlighet och passion.");}
                        break;
                    case 4: if (date.Day <= 20)
                        { Console.WriteLine("Stjärntecknet för födeledagen är väduren.");  
                          Console.WriteLine("Väduren, eller Aries på latin och engelska, är ett stjärntecken vars styrkor är mod, beslutsamhet, entusiasm, optimism, ärlighet och passion.");}
                        else
                        { Console.WriteLine("Stjärntecknet för födeledagen är oxen.");
                        Console.WriteLine("Oxen, eller Taurus som det heter på latin och engelska är ett stjärntecken med som är pålitligt, tålmodigt, praktiskt, hängivet, ansvarstagande och stabilt.");  }
                        break;
                    case 5: if (date.Day <= 21)
                        { Console.WriteLine("Stjärntecknet för födeledagen är oxen."); 
                        Console.WriteLine("Oxen, eller Taurus som det heter på latin och engelska är ett stjärntecken med som är pålitligt, tålmodigt, praktiskt, hängivet, ansvarstagande och stabilt."); }
                        else
                        { Console.WriteLine("Stjärntecknet för födeledagen är tvillingarna."); 
                        Console.WriteLine("Tvillingarna (21/5-21/6) Tvillingarna, eller Gemini på latin och engelska, är ett stjärntecken vars styrkor är vältalighet, nyfikenhet, charmighet och lätt att lära."); }
                        break;
                    case 6: if (date.Day <= 22)
                        { Console.WriteLine("Stjärntecknet för födeledagen är tvillingarna."); 
                        Console.WriteLine("Tvillingarna (21/5-21/6) Tvillingarna, eller Gemini på latin och engelska, är ett stjärntecken vars styrkor är vältalighet, nyfikenhet, charmighet och lätt att lära."); }
                        else
                        { Console.WriteLine("Stjärntecknet för födeledagen är kräftan.");
                        Console.WriteLine("Kräftan, eller Cancer på latin och engelska, är ett stjärntecken vars styrkor är envishet, fantasi, lojalitet och känslosamhet.");}
                        break;
                    case 7: if (date.Day <= 22)
                        { Console.WriteLine("Stjärntecknet för födeledagen är kräftan.");
                          Console.WriteLine("Kräftan, eller Cancer på latin och engelska, är ett stjärntecken vars styrkor är envishet, fantasi, lojalitet och känslosamhet.");}
                        else
                        { Console.WriteLine("Stjärntecknet för födeledagen är lejon."); 
                        Console.WriteLine("Lejonet, eller Leo på latin och engelska, är ett stjärntecken vars styrkor är kreativitet, beskyddarinstinkt, generositet, varmt hjärta, gladlynthet och humor."); }
                        break;
                    case 8: if (date.Day <= 23)
                        { Console.WriteLine("Stjärntecknet för födeledagen är lejon.");
                        Console.WriteLine("Lejonet, eller Leo på latin och engelska, är ett stjärntecken vars styrkor är kreativitet, beskyddarinstinkt, generositet, varmt hjärta, gladlynthet och humor.");  }
                        else
                        { Console.WriteLine("Stjärntecknet för födeledagen är jungfrun.");
                        Console.WriteLine("Jungfrun, eller Virgo på latin och engelska, är ett stjärntecken som är lojalt, analytiskt, hårt arbetande och praktiskt lagt. ");  }
                        break;
                    case 9: if (date.Day <= 23)
                        { Console.WriteLine("Stjärntecknet för födeledagen är jungfrun.");  
                        Console.WriteLine("Jungfrun, eller Virgo på latin och engelska, är ett stjärntecken som är lojalt, analytiskt, hårt arbetande och praktiskt lagt. ");}
                        else
                        { Console.WriteLine("Stjärntecknet för födeledagen är vågen.");  
                        Console.WriteLine("Vågen, eller Libra som det heter i engelsktalande länder, är ett stjärntecken vars styrkor är samarbetsvillighet, diplomati, älskvärdhet, rättvisa och social förmåga.");}
                        break;
                    case 10: if (date.Day <= 23)
                        { Console.WriteLine("Stjärntecknet för födeledagen är vågen."); 
                        Console.WriteLine("Vågen, eller Libra som det heter i engelsktalande länder, är ett stjärntecken vars styrkor är samarbetsvillighet, diplomati, älskvärdhet, rättvisa och social förmåga."); }
                        else
                        { Console.WriteLine("Stjärntecknet för födeledagen är skorpionen.");
                        Console.WriteLine("Skorpionen, eller Scorpio på latin och engelska, är ett stjärntecken vars styrkor är rådighet, mod, passion och envishet.");  }
                        break;
                    case 11: if (date.Day <= 22)
                        { Console.WriteLine("Stjärntecknet för födeledagen är skorpionen.");
                        Console.WriteLine("Skorpionen, eller Scorpio på latin och engelska, är ett stjärntecken vars styrkor är rådighet, mod, passion och envishet.");  }
                        else
                        { Console.WriteLine("Stjärntecknet för födeledagen är skytten.");  
                        Console.WriteLine("Skytten, eller Sagittarius på latin och engelska, är ett stjärntecken vars styrkor är storsinthet, generositet, idealism och humor. ");}
                        break;
                    case 12: if (date.Day <= 21)
                        { Console.WriteLine("Stjärntecknet för födeledagen är skytten.");
                        Console.WriteLine("Skytten, eller Sagittarius på latin och engelska, är ett stjärntecken vars styrkor är storsinthet, generositet, idealism och humor. ");  }
                        else
                        { Console.WriteLine("Stjärntecknet för födeledagen är stenbock ♑︎."); 
                        Console.WriteLine("Stenbocken, eller Capricorn på latin och engelska, är ett stjärntecken vars styrkor är ansvarstagande, disciplin, ambition och sinne för humor. "); }
                        break;
                    default:
                        Console.WriteLine("Stjärntecknet kunde inte hittas, försök igen!");
                        break;
                }
                
                // Ask about exit or continue 
                Console.WriteLine(""); 
                Console.WriteLine("Vill du gå tillbaka? (ja eller nej)");
                doAgain = Console.ReadLine();
                if (doAgain == "Nej" || doAgain == "nej")
                {
                    Console.Clear();
                    System.Environment.Exit(1);
                }
            }
        }
    

    } 




// To count how many years the person is
public class countDays{ 

public void countDay()
        {
string doAgain = "Y";

            Console.WriteLine("Skriv in födelsedatumet (mm/dd/yyyy): ");
            string dateBirthday = Console.ReadLine(); // Save input in string "dateBirthday"
            DateTime dt = DateTime.Parse(dateBirthday);

            // If date is bigger then one year
            if (howManyYears(dt) >= 1)
                Console.WriteLine("Personen är "+ howManyYears(dt) + " år."); 
            else
            // If date is less then one year
                Console.WriteLine("Personen är ett barn som är yngre än ett år. Barnet är "+ howManyDays(dt) + " dagar.");

            // Chose to go back or quit 
                Console.WriteLine(""); 
                Console.WriteLine("Vill du gå tillbaka? (ja eller nej)");
                doAgain = Console.ReadLine();
                if (doAgain == "Nej" || doAgain == "nej")
                {
                    Console.Clear();
                    System.Environment.Exit(1);
                }

        }
        
        // For days
        public static int howManyDays(DateTime dateBirthday)
        {
            DateTime dt = new DateTime(dateBirthday.Year, dateBirthday.Month, dateBirthday.Day);
            return DateTime.Now.Subtract(dt).Days;
        }

        // Formula for years
        public static int howManyYears(DateTime dateBirthday)
        {
            return ((DateTime.Now.Year - dateBirthday.Year) * 372 + (DateTime.Now.Month - dateBirthday.Month) * 31 + (DateTime.Now.Day - dateBirthday.Day)) / 372;
        }
}       
        
        } 