using System;
using System.Collections.Generic;
using Lab3_appz.Events;
using Lab3_appz.Models;
using Lab3_appz.Factories;

namespace Lab3_appz
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
            games.Add(new OnlineAdventuresFactory().CreateGame("Online Adventures", "Console", 4, 8, 2, 0, new string[] { "Admin", "1234" }));
            games.Add(new ShooterFactory().CreateGame("Shooter", "Desktop", 4, 8, 2, 10, new string[] { "Admin", "1234" }));
            games.Add(new SimulatorFactory().CreateGame("Simulator", "Mobile", 4, 8, 2, 10, new string[] { "Admin", "1234" }));

            GameEventManager.Instance.Attach(this);
        }

        public void Update(string message)
        {
            Printer.Print(message);
        }

        public void Client()
        {
            Console.WriteLine("Enter how many CPU cores your device has: ");
            cpu = GetValidatedInput.GetValidatedInt("CPU cores", 2, 24);
            Console.WriteLine("Enter how many gigabytes of RAM your device has: ");
            ram = GetValidatedInput.GetValidatedInt("RAM", 1, 256);
            Console.WriteLine("Enter how many gigabytes of VRAM your device has: ");
            vram = GetValidatedInput.GetValidatedInt("VRAM", 1, 80);
            Console.WriteLine("Enter how many gigabytes of HDD your device has: ");
            hdd = GetValidatedInput.GetValidatedInt("HDD", 1, 10000);

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
            string name = GetValidatedInput.GetValidatedString("name");
            string genre = GetValidatedInput.GetValidatedString("genre");
            string platform = GetValidatedInput.GetValidatedPlatform();
            int cpu_requirement = GetValidatedInput.GetValidatedInt("CPU Requirement", 2, 24);
            int ram_requirement = GetValidatedInput.GetValidatedInt("RAM Requirement", 1, 256);
            int vram_requirement = GetValidatedInput.GetValidatedInt("VRAM Requirement", 1, 60);
            int hdd_requirement = GetValidatedInput.GetValidatedInt("HDD Requirement", 0, 1000);
            string login = GetValidatedInput.GetValidatedString("login");
            string password = GetValidatedInput.GetValidatedString("password");

            games.Add(new AnotherGenreFactory(genre).CreateGame(name, platform, cpu_requirement, ram_requirement, vram_requirement, hdd_requirement, new string[] { login, password }));
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
                    Console.WriteLine(n + ". " + game.ToString());
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
                        Console.WriteLine("Enter your login: ");
                        string login = Console.ReadLine();
                        Console.WriteLine("Enter your password: ");
                        string password = Console.ReadLine();
                        game.Login(login, password);
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
                        Console.WriteLine("Enter the name of save: ");
                        string savename = Console.ReadLine();
                        game.SaveGame(savename);
                        break;
                    case '8':
                        game.ShowSaves();
                        break;
                    case '9':
                        Console.WriteLine("Enter the rating (1-10): ");
                        int rating = GetValidatedInput.GetValidatedInt("Rating", 1, 10);
                        game.RateGame(rating);
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