//////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////
//Name: Micah Wright//////////////////////////////////////////
//Datw: 9/14/2023/////////////////////////////////////////////
//Project Name: 2910 Lab 2////////////////////////////////////
//Class: 2910 Server Side Web/////////////////////////////////
//////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using _2910_Lab_1;
using System.Xml.Linq;
using System.Runtime.CompilerServices;

namespace _2910_Lab_1
{
    public class Program
    {
        static void Main(string[] args)
        {
            string folder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.ToString();
            string filepath = folder + Path.DirectorySeparatorChar + "videogames.csv";

            List<VideoGame> games = new List<VideoGame>();

            using(var sr = new StreamReader(filepath))
            {
                while (!sr.EndOfStream) 
                {

                    string? line = sr.ReadLine();

                   
                    string[] lineElements = line.Split(',');

                    VideoGame v = new VideoGame()
                    {
                        Name = lineElements[0].Trim(),
                        Platform = lineElements[1].Trim(),
                        Year = lineElements[2],
                        Genre = lineElements[3].Trim(),
                        Publisher = lineElements[4].Trim(),
                        NA_Sales = lineElements[5].Trim(),
                        EU_Sales = lineElements[6].Trim(),
                        JP_Sales = lineElements[7].Trim(),
                        Other_Sales = lineElements[8].Trim(),
                        Global_Sales = lineElements[9].Trim()
                    };
                    games.Add(v);
                }
                
            }



            games.Sort();
            VideoGame videogame = new VideoGame();


            //Lab 2

            Console.Write("What year is the game you are looking for?");     //user input
            int yearInInt = Convert.ToInt32(videogame.Year);
            yearInInt = Convert.ToInt32(Console.ReadLine());

            if (yearInInt < 1980)
            {
                Console.WriteLine("Invalid input");
            }
            else if (yearInInt > 1980 && yearInInt < 2000)
            {
                yearInInt = 1980;
            }
            else if (yearInInt >2001)
            {
                yearInInt = 2001;
            }   

            //dictionary with a int key and a string value
            Dictionary<int, string> pubDict = new Dictionary<int, string>();
            
           

            pubDict[1980] = "old Generation";
            pubDict[2001] = "new Generation";

            //outputting dictionary value
            Console.WriteLine($"This game is {pubDict[yearInInt]}");
            Console.WriteLine("Press enter to see other games of the same generation");
            Console.ReadLine();
            Console.WriteLine($"Other games in {pubDict[yearInInt]}:");

            var DictDisplay = games.Where(D => yearInInt <= 2000); // linq

            foreach (var d in DictDisplay) //display 
            {
                Console.WriteLine(d);
                Console.WriteLine("---------------------------");
            }
            Console.ReadLine();
            Console.Clear();

            Stack<VideoGame> numberStack = new Stack<VideoGame>();   //Stack 

            var stackName = games.Where(v => v.Name == "Overwatch"); //Linq for stack


            Console.WriteLine("Overwatch Content:"); 
            foreach (var game in stackName) //display stack
            {
                Console.WriteLine(game);
                numberStack.Push(game);  // add in the stack
                Console.WriteLine("-----------------------");
            }
            Console.WriteLine("Press enter to see the top of the stack");
            Console.ReadLine();

            Console.Clear();

            VideoGame topItem = numberStack.Peek();  //top of the stack
            Console.WriteLine("Top item on the stack: \n" + topItem);
            Console.WriteLine("------------------------------------------");

            Console.WriteLine("Press enter to remove the top of the stack");
            Console.ReadLine();

            Console.Clear();

            VideoGame poppedItem = numberStack.Pop();    // remove from stack
            Console.WriteLine("Popped item from the stack: \n" + poppedItem);
            Console.WriteLine("------------------------------------------");
            Console.ReadLine();
            Console.Clear();

            topItem = numberStack.Peek();
            Console.WriteLine("Top item on the stack after popping: \n" + topItem);
            Console.WriteLine("------------------------------------------");
            Console.ReadLine();
            Console.Clear();

            bool isEmpty = numberStack.Count == 0;

            Console.WriteLine("Stack contents:");    //display after edits
            foreach (var item in numberStack)
            {
                Console.WriteLine(item);
                Console.WriteLine("------------------------------------------");
            }

            Console.ReadLine();

            Queue<VideoGame> queue = new Queue<VideoGame>();   // queue

                var queuePub = games.Where(v => v.Publisher == "Level 5");  //linq


            Console.WriteLine("Content:");
            foreach (var game in queuePub)
            {
                Console.WriteLine(game);
                queue.Enqueue(game);  // add to queue
                Console.WriteLine("-----------------------");
            }
            Console.WriteLine("All games have been enqueued Press enter to see the top of the queue");
            Console.ReadLine();

            Console.Clear();
            
            VideoGame top = queue.Peek();   // top of queue
            Console.WriteLine("Top item on the queue: \n" + top);
            Console.WriteLine("------------------------------------------");

            Console.WriteLine("Press enter to remove the top of the queue");
            Console.ReadLine();

            Console.Clear();

            VideoGame remove = queue.Dequeue();   //removing queue

            for (int i = 0; i < 30; i++)
            {
                Console.WriteLine("Remove item from the queue: \n" + remove); //remove multiple from queue
                Console.WriteLine("------------------------------------------");
            }

            
            Console.ReadLine();
            Console.Clear();

            top = queue.Peek();
            Console.WriteLine("Top item on the queue after removing: \n" + top);
            Console.WriteLine("------------------------------------------");

            Console.Clear();

            Console.WriteLine("Queue contents:");
            foreach (var item in queuePub) // display finsl product of queue
            {
                Console.WriteLine(item);
                Console.WriteLine("------------------------------------------");
            }

             
             
             
             
             
             
             
             







            // Lab 1
            foreach (var v in games)
            {
                Console.WriteLine(v);
                Console.WriteLine("-------------------------------\n");
            }
           
            
            var specPub = games.Where(v => v.Publisher == "Ubisoft");
            Console.WriteLine("\n\n\n\n\n\nAll games from Ubisoft");
            foreach (var v in specPub)
            {
                Console.WriteLine(v);
                Console.WriteLine("--------------------------------\n");
            }
            
            double numpub = specPub.Count();
            double p = numpub / games.Count() * 100;

            Console.WriteLine($"Out of {games.Count} games, there are {numpub} Ubisoft Games. Which is {p:0.##}%\n");

            var specGenre = games.Where(v => v.Genre == "Role-Playing");
            Console.WriteLine("\n\n\n\n\n\nAll Role-Playing Games");
            foreach (var v in specGenre)
            {
                Console.WriteLine(v);
                Console.WriteLine("--------------------------------\n");
            }
            
            double numGen = specGenre.Count();
            double Gp = numGen / games.Count() * 100;

            Console.WriteLine($"Out of {games.Count} games, there are {numGen} Ubisoft Games. Which is {Gp:0.##}%\n");

            Console.Write("Enter the Genre of Game you'd like to search for: ");
            Console.WriteLine("(Action, Adventure, Fighting, Misc, Racing, Role-Playing, Shooter, Simulation, Strategy, Sports)");
            string Genretype = Console.ReadLine().Trim();

            Console.WriteLine($"Now searching for {Genretype} games...\n");

            GenreData(games, Genretype);
            
            Console.Write("Enter the Game Publisher you'd like to search for: ");
            Console.WriteLine("Ubisoft, Sega, Level 5");
            string Pubtype = Console.ReadLine().Trim();

            Console.WriteLine($"Now searching for {Pubtype}'s games...\n");

            PubData(games, Pubtype);

            static void GenreData(List<VideoGame> games, string type)
            {
                float numGames = games.Count;

                var specTypes = new List<VideoGame>();

                foreach (var v in games)
                {
                    if (v.Genre == type) specTypes.Add(v);
                }

                float numType = specTypes.Count;

                var pct = numType / numGames * 100;
                Console.WriteLine(pct);

                Console.WriteLine($"There are {numType} {type} games out of {numGames} which is {pct:0.##}%");
            }

            static void PubData(List<VideoGame> games, string type)
            {
                float numGames = games.Count;

                var specTypes = new List<VideoGame>();

                
                foreach (var v in games)
                {
                    if (v.Publisher == type) specTypes.Add(v);
                }

                float numType = specTypes.Count;

                var pct = numType / numGames * 100;
                Console.WriteLine(pct);

                Console.WriteLine($"There are {numType} {type} games out of {numGames} which is {pct:0.##}%");
            }
            
        }
    }

}



