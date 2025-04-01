using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LAB2_APPZ.Games;
using Lab3_appz.Events;

namespace LAB2_APPZ
{
    class AppManager : IObserver
    {
        private List<Game> games = new List<Game>();
        public int cpu { get; private set; }
        public int ram { get; private set; }
        public int vram { get; private set; }
        public int hdd { get; private set; }

        public AppManager()
        {
            games.Add(new OnlineAdventures("OnlineAdventures", "Console", 4, 8, 2, 0, new string[] { "Admin", "1234" }));
            games.Add(new Shooter("Shooter", "Desktop", 4, 8, 2, 10, new string[] { "Admin", "1234" }));
            games.Add(new Simulator("Simulator", "Mobile", 4, 8, 2, 10, new string[] { "Admin", "1234" }));

            GameEventManager.Instance.Attach(this);
}
        public void Update(string message)
        {
            Printer.Print(message);
        }
        public void Client()
        {
            while (true)
            {
                Printer.Print("Enter your characteristics before starting");
                Console.WriteLine("Enter how many cores has your device: ");
                cpu = GetValidatedInput.GetValidatedInt("CPU cores", 2, 24);
                Console.WriteLine("Enter how gigabytes of RAM cores has your device: ");
                ram = GetValidatedInput.GetValidatedInt("RAM", 1, 256);
                Console.WriteLine("Enter how many gigabytes of VRAM has your device: ");
                vram = GetValidatedInput.GetValidatedInt("VRAM", 1, 80);
                Console.WriteLine("Enter how many gigabytes of memory(HDD) has your device: ");
                hdd = GetValidatedInput.GetValidatedInt("HDD", 1, 10000);
                break;
            }


            while (true)
            {
                Console.Clear();
                Console.WriteLine("        Menu     \n" +
                                  "1. Choose a game from library\n" +
                                  "2. Add game\n" +
                                  "0. Exit");
                var choice = Console.ReadKey().KeyChar;
                switch (choice)
                {
                    case '1':
                        ShowLibrary();
                        break;
                    case '2':
                        CreateGame();
                        break;
                    case '0':
                        Printer.Print("Exiting...");
                        return;
                }
            }

        }
       

        public void CreateGame()
        {
            string name;
            string genre;
            string platform;
            int cpu_requirement;
            int ram_requirement;
            int vram_requirement;
            int hdd_requirement;
            string login;
            string password;
            //string name, string genre, string platform, int cpu_requirement,int ram_requirement, int vram_requirement, int hdd_requirememnt, string[] logindata
            name = GetValidatedInput.GetValidatedString("name");
            genre = GetValidatedInput.GetValidatedString("genre");
            platform = GetValidatedInput.GetValidatedPlatform();
            cpu_requirement = GetValidatedInput.GetValidatedInt("CPU Requirement", 2, 24);
            ram_requirement = GetValidatedInput.GetValidatedInt("RAM Requirement", 1, 256);
            vram_requirement = GetValidatedInput.GetValidatedInt("VRAM Requirement", 1, 60);
            hdd_requirement = GetValidatedInput.GetValidatedInt("HDD Requirement", 0, 1000);
            login = GetValidatedInput.GetValidatedString("login");
            password = GetValidatedInput.GetValidatedString("password");

            games.Add(new AnotherGenreGame(name, genre, platform, cpu_requirement, ram_requirement, vram_requirement, hdd_requirement, new string[] { login, password }));
            Printer.Print($"Game {name} was successfully added to the library!");


        }
        public void ShowLibrary()
        {
            while (true)
            {
                Console.Clear();
                int n = 0;
                foreach (var game in games)
                {
                    n++;
                    Console.WriteLine(n + "." + game.ToString());
                }


                Console.WriteLine("Choose a game: ");
                var choice = Console.ReadKey().KeyChar;
                int choice_int = choice - '0';
                if (choice_int <= n && choice_int > 0)
                {
                    GameMenu(games[choice_int - 1]);
                    break;
                }
                else
                {
                    Printer.Print("Error! Try to choose game again!");
                    continue;
                }
            }

        }
        public void GameMenu(Game game)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("===GameMenu===\n" +
                                  "1. Launch game\n" +
                                  "2. Install Game\n" +
                                  "3. Sign in\n" +
                                  "4. Connect gamepad\n" +
                                  "5. Start Translation\n" +
                                  "6. Stop Translation\n" +
                                  "7. Save game\n" +
                                  "8. Load saving\n" +
                                  "9. Rating\n" +
                                  "0. Exit");
                var choice = Console.ReadKey().KeyChar;
                switch (choice)
                {
                    case '1':
                        game.CheckRequirements(cpu, ram, vram);
                        break;
                    case '2':
                        game.InstallGame(hdd);
                        break;
                    case '3':
                        if (!game.is_logged_in)
                        {
                            string login, password;
                            while (true)
                            {
                                Console.Clear();
                                Console.WriteLine("Enter your login: ");
                                login = Console.ReadLine();
                                if (String.IsNullOrEmpty(login)) continue;
                                Console.WriteLine("Enter your password: ");
                                password = Console.ReadLine();
                                if (String.IsNullOrEmpty(password)) continue;
                                break;
                            }
                            game.Login(login, password);
                        }
                        else
                        {
                            Printer.Print("You are already logged in.");
                        }
                        break;
                    case '4':
                        game.ConnectGamepad();
                        break;
                    case '5':
                        game.StartTranslation();
                        break;
                    case '6':
                        game.StopTranslation();
                        break;
                    case '7':
                        if (game.is_running)
                        {
                            string savename;
                            while (true)
                            {
                                Console.Clear();
                                Console.WriteLine("Enter the name of save: ");
                                savename = Console.ReadLine();
                                if (String.IsNullOrEmpty(savename)) { Console.WriteLine("Error! The name can't be null, try again"); continue; }
                                break;
                            }
                            game.SaveGame(savename);
                        }
                        else
                        {
                            Printer.Print("Error: Launch the game first");
                        }
                        break;
                    case '8':
                        game.ShowSaves();
                        break;
                    case '9':
                        bool stop_cycle = true;
                        while (stop_cycle)
                        {
                            Console.Clear();
                            Console.WriteLine("1. Rate the game\n" +
                                              "2. Show game rating\n" +
                                              "3. Come back");
                            var result = Console.ReadKey().KeyChar;
                            switch (result)
                            {
                                case '1':
                                    Console.Clear();
                                    Console.WriteLine("Enter the rating (1-10)");
                                    int rating = GetValidatedInput.GetValidatedInt("Rating", 1, 10);


                                    game.RateGame(rating);
                                    break;
                                case '2':
                                    game.ShowRating();
                                    break;
                                case '3':
                                    stop_cycle = false;
                                    break;
                            }
                        }
                        break;
                    case '0':
                        if (game.is_running)
                        {
                            game.CloseGame();
                        }
                        return;
                }
            }
        }
    }
}
