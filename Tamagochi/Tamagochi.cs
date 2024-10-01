using System;
using System.Collections.Generic;

public class Tamagotchi
{
    // Private fields
    private int hunger;
    private int boredom;
    private List<string> words;
    private bool isAlive;

  
    public string Name { get; set; }

    
    public Tamagotchi(string name)
    {
        Name = name;
        hunger = 0;
        boredom = 0;
        words = new List<string>();
        isAlive = true;
    }

   
    public void Feed()
    {
        hunger = Math.Max(0, hunger - 1); 
        Console.WriteLine($"{Name} har blivit matad.");
    }

   
    public void Hi()
    {
        if (words.Count > 0)
        {
            Random rand = new Random();
            int index = rand.Next(words.Count);
            Console.WriteLine($"{Name} säger: {words[index]}");
            ReduceBoredom();
        }
        else
        {
            Console.WriteLine($"{Name} har inget att säga!");
        }
    }

    
    public void Teach(string word)
    {
        words.Add(word);
        ReduceBoredom();
        Console.WriteLine($"{Name} lärde sig ett nytt ord: {word}");
    }

   
    public void Tick()
    {
        hunger++;
        boredom++;
        if (hunger > 10 || boredom > 10)
        {
            isAlive = false; 
            Console.WriteLine($"{Name} dog.");
        }
        else
        {
            isAlive = true; 
        }
    }


    public void PrintStats()
    {
        Console.WriteLine($"Name: {Name}, Hunger: {hunger}, Boredom: {boredom}, Alive: {isAlive}");
    }

   
    public bool GetAlive()
    {
        return isAlive;
    }

    
    private void ReduceBoredom()
    {
        boredom = Math.Max(0, boredom - 1); // Decrease boredom but not below 0
        Console.WriteLine($"{Name}'s tråkighet har sjunkit.");
    }
}
