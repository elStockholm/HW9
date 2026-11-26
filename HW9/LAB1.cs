using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW9
{
    //●	Написать программу, содержащую решение следующих задач: Большие гонки.
    //На шоу Большие гонки собираются 4 команды из разных стран.В команде по 15 человек.
    //Всего за одну игру команда проходит по 6 испытаний (6 разных игр). Будет неинтересно, если каждый раз игры будут одинаковыми, поэтому каждый раз игры разные.
    //Главный организатор, Оливье Ганьян, добавляет новые игры.Необходимо правильно организовать классы, чтобы класс передачи «Большие Гонки» не изменял свой функционал,
    //а добавлял новый.В консоли необходимо создать 4 команды: Россия, Франция, Китай и Казахстан, и чтобы они сыграли в 6 игр.
    //Какие игры создать:
    //1.	Пляж
    //2.	Мышеловка
    //3.	Море
    //4.	Рыбалка
    //5.	Почтальоны
    //6.	Горка
    //Также вам необходимо создать свою игру, но не изменяя класс, а расширяя функционал класса. Подумайте, какой паттерн нужно использовать.
    interface IGame
    {
        void Play(Team team);
    }

    class Team
    {
        public string country;
        public int members;

        public Team(string country, int members)
        {
            this.country = country;
            this.members = members;
        }
    }

    class Beach : IGame
    {
        public void Play(Team team)
        {
            Console.WriteLine($"Команда {team.country} ({team.members} чел.) проходит испытание Пляж");
        }
    }

    class Mousetrap : IGame
    {
        public void Play(Team team)
        {
            Console.WriteLine($"Команда {team.country} ({team.members} чел.) проходит испытание Мышеловка");
        }
    }

    class Sea : IGame
    {
        public void Play(Team team)
        {
            Console.WriteLine($"Команда {team.country} ({team.members} чел.) проходит испытание Море");
        }
    }

    class Fishing : IGame
    {
        public void Play(Team team)
        {
            Console.WriteLine($"Команда {team.country} ({team.members} чел.) проходит испытание Рыбалка");
        }
    }

    class Postmen : IGame
    {
        public void Play(Team team)
        {
            Console.WriteLine($"Команда {team.country} ({team.members} чел.) проходит испытание Почтальоны");
        }
    }

    class Slide : IGame
    {
        public void Play(Team team)
        {
            Console.WriteLine($"Команда {team.country} ({team.members} чел.) проходит испытание Горка");
        }
    }

    class Bulls : IGame
    {
        public void Play(Team team)
        {
            Console.WriteLine($"Команда {team.country} ({team.members} чел.) проходит испытание Битва с быками");
        }
    }

    class BigRaces
    {
        private List<Team> teams = new List<Team>();
        private List<IGame> allGames = new List<IGame>();
        private Random random = new Random();

        public void AddTeam(Team team)
        {
            teams.Add(team);
        }

        public void AddGame(IGame game)
        {
            allGames.Add(game);
        }

        public void Start()
        {
            List<IGame> availableGames = new List<IGame>(allGames);

            for (int i = 0; i < 6; i++)
            {
                int index = random.Next(availableGames.Count);
                IGame currentGame = availableGames[index];
                availableGames.RemoveAt(index);

                Console.WriteLine($"-Игра {i + 1}-");
                foreach (Team team in teams)
                {
                    currentGame.Play(team);
                }
                Console.WriteLine();
            }
        }
    }

    class Program
    {
        static void Main()
        {
            BigRaces show = new BigRaces();

            show.AddTeam(new Team("Россия", 15));
            show.AddTeam(new Team("Франция", 15));
            show.AddTeam(new Team("Китай", 15));
            show.AddTeam(new Team("Казахстан", 15));

            show.AddGame(new Beach());
            show.AddGame(new Mousetrap());
            show.AddGame(new Sea());
            show.AddGame(new Fishing());
            show.AddGame(new Postmen());
            show.AddGame(new Slide());
            show.AddGame(new Bulls());

            show.Start();
        }
    }
}
