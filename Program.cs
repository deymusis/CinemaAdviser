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

                string [] names = {"Comedy", "Drama", "Erotic"};

                
            

            Console.WriteLine( Resources.Name );
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
                    Console.ReadKey();
                }
        }

        /*Пора смотреть фильм!*/

        public static void TimeToWatch(String genre, String name)
        {
            Console.WriteLine("What movie would you like to watch? \n{0}", genre);
            String choiceOfGenre = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("You could watch... Ehhh...");

                switch (choiceOfGenre) {
                    case "Comedy":
                        Comedy();
                        break;
                    case "Drama":
                        Drama();
                        break;
                    case "Erotic":
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
                          break;
                          default:
                        Console.WriteLine("Wow! {0} - What is it? I don't know anything about it. sorry! i can't recommend anymore.", choiceOfGenre);
                        break;
                }

            Console.WriteLine("Enjoy your movie, {0}!", name);
            Console.ReadKey();
        }

        /*Если выбрал Comedy*/



        private static void Comedy()
        {
            string[] films = {"Furry Vengeance",
                              "Oz the Great and Powerful",
                              "Beethoven",
                              "Best in Show,",
                              "In the Loop",
                              "Bridesmaids",
                              "The Layover",
                              "L’embarras du choix",
                              "Magic in the Moonlight",
                              "Life as We Know It",
                              "Bridget Jones’s Baby",
                              "Populaire",
                              "Pitch Perfect",
                              "Spy",
                              "Les émotifs anonymes",
                              "L’arnacoeur",
                              "Love & Friendship",
                              "Leap Year"
                             };

            foreach (string i in films)
            {
                Console.WriteLine("* {0}", i);
            }
            RandomFilm(films);
        }

        /*Если выбрал Drama*/

            
            
        private static void Drama()
        {
            string[] films = {"Race",
                              "Pelé: Birth of a Legend",
                              "Snowden",
                              "Babel",
                              "Dancer in the Dark",
                              "Rain man",
                              "М",
                              "Schindler’s List",
                              "Captain Fantastic",
                              "We Need to Talk About Kevin",
                              "The Believer",
                              "La vita è bella",
                              "A Time to Kill"
                             };

            foreach (string i in films)
            {
                Console.WriteLine("* {0}", i);
            }
            RandomFilm(films);
        }

        /*Если выбрал Erotic*/

        public static void Erotic()
        {
            
            string[] films = {"Emmanuelle",
                              "Fifty shades of grey",
                              "Newness",
                              "Kiki",
                              "Swinger",
                              "Nymphomaniac",
                              "No strings attached",
                              "My awkward sexual adventure",
                              "3d rou pu tuan zhi ji le bao jian",
                              "Nuit",
                              "The rules of attraction",
                              "Caligola",
                              "Trasgredire",
                              "La vie d'adèle",
                              "Les valseuses",
                              "Turks fruit",
                              "Salò o le 120 giornate di sodoma",
                              "Lucía y el sexo"
                             };

            foreach (string i in films)
            {
                Console.WriteLine("* {0}", i);
            }
            RandomFilm(films);
        }

        

        /*Выбирает случайный фильм*/

        private static void RandomFilm(string[] names)
        {
            Console.WriteLine("I recommend - {0}", names[new Random().Next(0, names.Length)]);
        }
  
    }

        class Genre {
            public string[] Names { get; set; }
            public string[] Films { get; set; }

            public Genre(string[] names, string[] films) {
                Names = names;
                Films = films;
            }



            /*Никак не могу применить этот метод для каждого жанра*/

            public void ShowFilms()
            {
                foreach (string i in Films)
                {
                    Console.WriteLine("* {0}", i);
                }
                RandomFilm();
            }

            private void RandomFilm()
            {
                Console.WriteLine("I recommend - {0}", Films[new Random().Next(0, Films.Length)]);
            }
        }

}
