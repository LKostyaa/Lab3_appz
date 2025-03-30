using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB2_APPZ
{
    public delegate void GameEventHandler(string message);
    static class GameEvents
    {
        public static event GameEventHandler OnGameInstalled;

        public static event GameEventHandler OnGameLaunched;
        public static event GameEventHandler OnGameClosed;

        public static event GameEventHandler OnGameRated;

        public static event GameEventHandler OnTranslationStarted;
        public static event GameEventHandler OnTranslationStopped;

        public static event GameEventHandler OnSaveLoaded;
        public static event GameEventHandler OnSavingMade;

        public static event GameEventHandler OnGamePadConnected;

        public static event GameEventHandler OnUserLoggedIn;
        public static void GameInstalled(string name)
        {
            OnGameInstalled?.Invoke($"[EVENT] Game {name} was successfully INSTALLED");
        }
        public static void GameLaunched(string name)
        {
            OnGameLaunched?.Invoke($"[EVENT] Game {name} was successfully LAUNCHED");

        }
        //=================================
        public static void GameClosed(string name)
        {
            OnGameClosed?.Invoke($"[EVENT] Game {name} was successfully CLOSED");
        }
        public static void GameRated(string name, double rating)
        {
            OnGameRated?.Invoke($"[EVENT] Game {name} was successfully RATED: {rating}");
        }
        //================================
        public static void TranslationStarted(string name)
        {
            OnTranslationStarted?.Invoke($"[EVENT] Translation of {name} was successfully STARTED");
        }
        public static void TranslationStopped(string name)
        {
            OnTranslationStopped?.Invoke($"[EVENT] Translation of {name} was successfully STOPPED");
        }
        //=============================
        public static void SaveLoaded(string name)
        {
            OnSaveLoaded?.Invoke($"[EVENT] Save {name} was LOADED successfully ");
        }
        public static void SaveMade(string name)
        {
            OnSavingMade?.Invoke($"[EVENT] Saving {name} was SAVED successfully");
        }
        //===============================
        public static void GamepadConnected()
        {
            OnGamePadConnected?.Invoke($"[EVENT] Gamepad was connected!");
        }
        //=====================================
        public static void UserLoggedIn(string name)
        {
            OnUserLoggedIn?.Invoke($"[EVENT] user {name} logged in!");
        }

    }
}
