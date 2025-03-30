using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;
using LAB2_APPZ;

namespace LAB2_APPZ.Games
{
    abstract class Game
    {
        private List<int> ratings = new List<int>();
        public double averagerating => ratings.Count > 0 ? Math.Round(ratings.Average(), 2) : 0.0;
        public string name { get; private set; }
        public string genre { get; private set; }
        public string platform { get; private set; }

        public int cpu_requirement { get; private set; }
        public int ram_requirement { get; private set; }
        public int vram_requirement { get; private set; }
        public int hdd_requirement { get; private set; }
        public bool gamepad_requirement { get; private set; } = false;

        public bool is_installed { get; private set; } = false;
        public bool is_running { get; private set; } = false;
        public bool hassavefile { get; private set; } = false;

        public bool is_online { get; protected set; } = false;

        public bool is_logged_in { get; private set; } = false;

        public bool is_gamepad_connected { get; private set; } = false;

        public bool is_translated;

        private string[] logindata = new string[2];
        private List<string> saves = new List<string>();

        public Game(string name, string genre, string platform, int cpu_requirement, int ram_requirement, int vram_requirement, int hdd_requirememnt, string[] logindata)
        {
            this.name = name;
            this.genre = genre;
            this.platform = platform.ToLower();
            this.cpu_requirement = cpu_requirement;
            this.ram_requirement = ram_requirement;
            this.vram_requirement = vram_requirement;
            hdd_requirement = hdd_requirememnt;
            this.logindata = logindata;



            if (platform.ToLower() == "console")
            {
                gamepad_requirement = true;
            }
        }
        public void SetOnline()
        {
            is_online = true;
        }

        public void InstallGame(int avaiblehdd)
        {
            if (is_installed)
            {
                ErrorLogger.LogError("The game is alredy installed");
                return;
            }
            if (is_online)
            {
                ErrorLogger.LogError("The game is online and doesn't need to be installed");
                return;
            }
            if (avaiblehdd < hdd_requirement)
            {
                ErrorLogger.LogError($"not enough space for installing {name}");
                return;
            }
            is_installed = true;
            avaiblehdd -= hdd_requirement;

            //================================EVENT============================
            GameEvents.GameInstalled(name);
        }
        public void Login(string username, string password)
        {
            if (is_logged_in)
            {
                ErrorLogger.LogError("You're already logged in!");
                return;
            }
            if (logindata[0] == username && logindata[1] == password)
            {
                is_logged_in = true;
                //=======================================EVENT================
                GameEvents.UserLoggedIn(username);
                return;
            }
            ErrorLogger.LogError("your password or login doesn't match");
        }
        public void CheckRequirements(int cpu, int ram, int vram)
        {
            if (cpu >= cpu_requirement && ram >= ram_requirement && vram >= vram_requirement)
            {
                LaunchGame();
            }
            else
            {
                ErrorLogger.LogError("Your computer's too weak for this game :(");
                return;
            }
        }
        public void ConnectGamepad()
        {
            if (!is_gamepad_connected && gamepad_requirement)
            {
                is_gamepad_connected = true;
                //==========================EVENT=======================
                GameEvents.GamepadConnected();
                return;
            }
            if (is_gamepad_connected)
            {
                ErrorLogger.LogError("Gamepad was already connected!");
                return;
            }
            ErrorLogger.LogError("You don't need to connect gamepad!");
        }
        public void LaunchGame()
        {
            if (is_running)
            {
                ErrorLogger.LogError("The game is already launched!!!");
                return;
            }
            if (gamepad_requirement && !is_gamepad_connected)
            {
                ErrorLogger.LogError("connect the gamepad!!!");
                return;
            }
            if (!is_installed && !is_online)
            {
                ErrorLogger.LogError($" the game {name} is not installed");
                return;
            }
            if (!is_logged_in)
            {
                ErrorLogger.LogError($" you'd login before opening {name}");
                return;
            }
            if (is_online)
            {
                Printer.Print("Opening the browser...");
            }
            is_running = true;

            //=============================EVENT=========================
            GameEvents.GameLaunched(name);
        }
        public void CloseGame()
        {
            if (is_running)
            {
                is_running = false;
                is_logged_in = false;
                //==============================EVENT=============================
                GameEvents.GameClosed(name);
                return;
            }
            ErrorLogger.LogError(" The game isn't launched!");
        }
        public void StartTranslation()
        {
            if (!is_running)
            {
                ErrorLogger.LogError(" You'd launch the game first.");
                return;
            }
            if (!is_translated && platform == "mobile" || platform == "console")
            {
                is_translated = true;
                //======================Event===========================
                GameEvents.TranslationStarted(name);
                return;
            }
            if (is_translated)
            {
                ErrorLogger.LogError(" The translation is already started!");
                return;
            }
            ErrorLogger.LogError(" You can't start translation.");
        }
        public void StopTranslation()
        {
            if (is_translated)
            {
                is_translated = false;
                //=============================EVENT============================
                GameEvents.TranslationStopped(name);
                return;
            }
            if (!is_translated)
            {
                ErrorLogger.LogError(" Start the translation first!");
            }
        }
        public void SaveGame(string name)
        {
            saves.Add(name);
            //=====================EVENT============================
            GameEvents.SaveMade(name);
        }
        public void ShowSaves()
        {
            if (saves.Count > 0)
            {
                Console.Clear();
                Console.WriteLine("Saves:");
                int n = 1;
                foreach (string name in saves)
                {
                    Console.Write($"{n}. {name} / ");
                    n++;
                }
                Console.WriteLine("\nEnter the number: ");
                int k = int.Parse(Console.ReadLine());
                if (k > 0 && k < n)
                {
                    //==========================EVENT=============================
                    GameEvents.SaveLoaded(saves[k - 1]);
                }
                else
                {
                    ErrorLogger.LogError(" enter the correct num and try again");
                }


            }
            else
            {
                ErrorLogger.LogError(" Make a saving first");
            }
        }
        public void RateGame(int rating)
        {
            ratings.Add(rating);

            //=============================EVENTS=======================
            GameEvents.GameRated(name, averagerating);
        }
        public void ShowRating()
        {
            Printer.Print($"Game: {name} | Avg rating: {averagerating}");
        }
        public override string ToString()
        {
            return name;
        }
    }

}