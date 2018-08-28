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

            /*Коллекция Dictionary - словарь хранит объекты, которые представляют пару ключ-значение*/
            var genreDict = new Dictionary<string, Genre>(StringComparer.InvariantCultureIgnoreCase) //свойство InvariantCultureIgnoreCase сравнивает строки по словам без учёта регистра
            {
                { "Comedy", new Genre("Comedy", new string[] 
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
                             }) },
                { "Drama", new Genre("Drama", new string[] 
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
                             }) },

                { "Erotic", new AdultGenre("Erotic", new string[] //тут создаём экземпляр производного класса "жанр для врослых"
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
                             }) },
            };

            var date = DateTime.Now; // настоящее время
            var endingHours = 13; // от этой переменной зависит просмотр фильма

            String genre = "Comedy or Drama";

            Console.WriteLine("What is your name?");
            String name = Console.ReadLine(); // Поле ввода для твоего имени
            Console.WriteLine("Hello, {0}! Today is {1}, it's {2:HH:mm} now.", name, date.DayOfWeek, date);

            if (date.Hour >= endingHours)
            {
                Console.WriteLine("It's time to watch film!");
                TimeToWatch(genre, name, genreDict); //основная реализация просмотрщика
            }
            else
            {
                Console.WriteLine("You still must work!");
                Console.WriteLine("Have a good day at work, {0}!", name);
                Console.ReadKey();
            }
        }

        /*Пора смотреть фильм!*/

        public static void TimeToWatch(String genre, String name, Dictionary<string, Genre> genreDict)
        {
            Console.WriteLine("What movie would you like to watch? \n{0}", genre);
            String choiceOfGenre = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("You could watch... Ehhh...");

            Genre chosen = null;

            if (genreDict.TryGetValue(choiceOfGenre, out chosen)) //TryGetValue пытается получить доступ к ключам, которых нет в словаре
            {
                //Не зависимо от того какого типа выбранный, вызываем метод взаимодействия Interact
                //среда сама разберётся какой код нужно исполнять
                //В этом, в самом простом случае, заключается полиморфизм
                //Трактует объекты в связанной манере
                chosen.Interact();
            }
            else
                Console.WriteLine("Wow! {0} - What is it? I don't know anything about it. sorry! i can't recommend anymore.", choiceOfGenre);

            Console.WriteLine("Enjoy your movie, {0}!", name);
            Console.ReadKey();
        }

        /*Жанры фильмов*/

        private static string[] GengeOfFilm()
        {
            string[] names = { "Comedy", "Drama", "Erotic" };
            return names;
        }
    }

    class Genre //базовый внутренний класс (полиморфный интерфейс)
    {
        public string[] Films { get; set; } //поле
        public string Name { get; private set; }//рекомендация на сайте Microsoft

        public Genre(string name, string[] films)
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
            String yearString = Console.ReadLine();
            int years = Int32.Parse(yearString);
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
