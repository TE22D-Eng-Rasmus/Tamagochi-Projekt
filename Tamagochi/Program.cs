using System;

public class Program
{
    public static void Main(string[] args)
    {
        // Fråga användaren om Tamagotchi-namn
        Console.Write("Skriv namnet på din Tamagotchi: ");
        string name = Console.ReadLine();
        
        // Skapa en instans av Tamagotchi-klassen
        Tamagotchi myTamagotchi = new Tamagotchi(name);

        // Spelloop
        while (myTamagotchi.GetAlive())
        {
            // Visa statistik
            myTamagotchi.PrintStats();
            
            // Ge användaren valmöjligheter
            Console.WriteLine("Välj en handling: ");
            Console.WriteLine("1. Mata Tamagotchi");
            Console.WriteLine("2. Hälsa på Tamagotchi");
            Console.WriteLine("3. Lär Tamagotchi ett nytt ord");
            Console.WriteLine("4. Gör ingenting");
            Console.Write("Ditt val: ");
            string choice = Console.ReadLine();

            
            switch (choice)
            {
                case "1":
                    myTamagotchi.Feed();
                    break;
                case "2":
                    myTamagotchi.Hi();
                    break;
                case "3":
                    Console.Write("Skriv in ett ord för att lära Tamagotchi: ");
                    string word = Console.ReadLine();
                    myTamagotchi.Teach(word);
                    break;
                case "4":
                    Console.WriteLine("Du valde att göra ingenting.");
                    break;
                default:
                    Console.WriteLine("Ogiltigt val. Försök igen.");
                    break;
            }

            // Varje gång en handling görs, kör Tick för att uppdatera hunger och boredom
            myTamagotchi.Tick();

            // Kontrollera om Tamagotchi lever, om inte, avslutas spelet
            if (!myTamagotchi.GetAlive())
            {
                Console.WriteLine($"{name} dog.");
            }
        }

        // Meddelande när spelet är slut
        Console.WriteLine($"Spelet är över. {name} är död.");
    }
}
