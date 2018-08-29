using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration; //пока хз как реализовать appSettings.config, получение из настроек

namespace CinemaAdviser
{
    class Program
    {

        static void Main(string[] args)
        {

            /*Программа поможет подобрать фильм, если ты уже не работаешь*/

            /*Коллекция Dictionary - словарь хранит объекты, которые представляют пару ключ-значение*/
            var genreDict = new List<Genre>() //нужно сделать эту переменную статической переменной класса
            {
                new Genre("Comedy", new string[] 
                             {"Furry Vengeance",
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
                             }),
                new Genre("Drama", new string[] 
                              {"Race",
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
                             }),
                new AdultGenre("Erotic", new string[] //тут создаём экземпляр производного класса "жанр для взрослых"
                             {"Emmanuelle",
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
                             })
            };

            

            var date = DateTime.Now; // настоящее время
            var endingHours = 8; // от этой переменной зависит просмотр фильма

            //String genre = "Comedy or Drama";

            Console.WriteLine("What is your name?");
            String name = Console.ReadLine(); // Поле ввода для твоего имени
            Console.WriteLine("Hello, {0}! Today is {1}, it's {2:HH:mm} now.", name, date.DayOfWeek, date);

            if (date.Hour >= endingHours)
            {
                Console.WriteLine("It's time to watch film!");
                TimeToWatch(name, genreDict); //основная реализация просмотрщика
            }
            else
            {
                Console.WriteLine("You still must work!");
                Console.WriteLine("Have a good day at work, {0}!", name);
                Console.ReadKey();
            }
        }

        /*Пора смотреть фильм!*/

        public static void TimeToWatch(String name, List<Genre> genreDict)
        {
            Console.WriteLine("What movie would you like to watch?");

            for (var i = 0; i < genreDict.Count; i++)
            {
                Console.WriteLine("{0}). {1}", i+1, genreDict[i].Name);
            }

            
            String choiceOfGenre = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("You could watch... Ehhh...");

            Genre chosen = genreDict.FirstOrDefault(x => x.Name == choiceOfGenre ); //лямбда-функция

            //Genre chosen = null;
            //for (int k = 0; k < genreDict.Count(); k++)
            //{
            //    if (choiceOfGenre == genreDict[k].Name)
            //    {
            //        chosen = genreDict[k];
            //    }

            //}
            if (chosen != null) //TryGetValue пытается получить доступ к ключам, которых нет в словаре
            {
                //Не зависимо от того какого типа выбранный, вызываем метод взаимодействия Interact
                //среда сама разберётся какой код нужно исполнять
                //В этом, в самом простом случае, заключается полиморфизм
                //Трактует объекты в связанной манере
                chosen.Interact();
            }
            else
            {
                Console.WriteLine("Wow! {0} - What is it? I don't know anything about it. sorry! i can't recommend anymore.", choiceOfGenre);
            }

            Console.WriteLine("Enjoy your movie, {0}!", name);
            Console.ReadKey();
        }


    }

    class Genre //базовый внутренний класс (полиморфный интерфейс)
    {
        public string[] Films { get; set; } //поле
        public string Name { get; private set; }//рекомендация на сайте Microsoft

        public Genre(string name, params string[] films)
        {
            Name = name;
            Films = films;
        }

        public void ShowFilms() //метод
        {
            foreach (string i in Films)
            {
                Console.WriteLine("* {0}", i);
            }
        }


        public void RandomFilm()
        {
            Console.WriteLine("I recommend - {0}", Films[new Random().Next(0, Films.Length)]);
        }

        public virtual void Interact() //для изменения объявлений методов, свойств, индексаторов и событий и разрешения их переопределения в производном классе
        {
            ShowFilms();
            RandomFilm();
        }
    }

    /*Наследование*/

    class AdultGenre : Genre
    {
        public AdultGenre(string name, string[] films)
            : base(name, films) //для доступа к членам базового из производного класса 
        { }

        /*Переопределение и полиморфизм*/

        public override void Interact() //модификатор переопределяет метод в классе-наследнике
                                        //для расширения или изменения абстрактной или виртуальной реализации унаследованного метода, свойства, индексатора или события
                                        //новая реализация члена, унаследованного от базового класса
        {
            Console.WriteLine("How old are you?");
            int years;
            var result = int.TryParse(Console.ReadLine(), out years); //если ввели не число
            if (!result)
            {
                Console.WriteLine("Please enter the number");
                Interact();
                return;
            }
            else
            {
                if (years < 18)
                {
                    Console.Clear();
                    Console.WriteLine("Unfortunately, it's only after the age of 18!");
                    Console.WriteLine("Come back in " + (18 - years) + " years."); //от этого зависит просмотр особого жанра)))
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("These are going to be so passionate films!");
                    base.Interact();
                }
            }         
        }
    }

}
