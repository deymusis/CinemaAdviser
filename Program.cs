using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaAdviser
{
    class Program
    {
        static void Main(string[] args)
        {
                /*Программа поможет подобрать фильм, если ты уже не работаешь*/

                var date = DateTime.Now; // настоящее время
                var endingHours = 19; // от этой переменной зависит просмотр фильма

                String genre = "Comedy or Drama";

            Console.WriteLine( "What is your name?" );
                String name = Console.ReadLine(); // Поле ввода для твоего имени
            Console.WriteLine( "Hello, {0}! Today is {1}, it's {2:HH:mm} now.", name, date.DayOfWeek, date );

            if (date.Hour >= endingHours)
            {
                Console.WriteLine("It's time to watch film!"); 
                TimeToWatch(genre, name);
            }
            else
            {
                Console.WriteLine("You still must work!");
                Console.WriteLine("Have a good day at work, {0}!", name);
                Console.ReadLine();
            }
        }

        /*Пора смотреть фильм!*/

        private static void TimeToWatch(String genre, String name)
        {
            Console.WriteLine("What movie would you like to watch? \n{0}", genre);
            String choiceOfGenre = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("You could watch... Ehhh...");

            if (choiceOfGenre == "Comedy")
            {
                Comedy();
            }
            else if (choiceOfGenre == "Drama")
            {
                Drama();
            }
            else if (choiceOfGenre == "Erotic")
            {
                Console.WriteLine("How old are you?");
                String yearString = Console.ReadLine();
                int years = Int32.Parse(yearString);
                if (years < 18)
                {
                    Console.Clear();
                    Console.WriteLine("Unfortunately, it's only after the age of 18!");
                    Console.WriteLine("Come back in " + (18 - years) + " years.");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("These are going to be so passionate films!");
                    Erotic();
                }
            }
            else
            {
                Console.WriteLine("Wow! {0} - what is it? I don't know anything about it. Sorry! I can't recommend anymore.", choiceOfGenre);
            }

            Console.WriteLine("Enjoy your movie, {0}!", name);
            Console.ReadLine();
        }

        /*Если выбрал Erotic*/

        private static void Erotic()
        {
            Console.WriteLine("* Emmanuelle");
            Console.WriteLine("* Fifty Shades of Grey");
        }

        /*Если выбрал Drama*/

        private static void Drama()
        {
            Console.WriteLine("* Race");
            Console.WriteLine("* Pelé: Birth of a Legend");
            Console.WriteLine("* Snowden");
        }

        /*Если выбрал Comedy*/

        private static void Comedy()
        {
            Console.WriteLine("* Furry Vengeance");
            Console.WriteLine("* Oz the Great and Powerful");
            Console.WriteLine("* Beethoven");
        }
    }
}
