using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_appz.Events
{
    public class GameEventManager : ISubject
    {
        private List<IObserver> observers = new List<IObserver>();
        private static GameEventManager instance;

        public static GameEventManager Instance
        { get {
                if (instance == null) {
                    instance = new GameEventManager();
                }
                return instance;
            }
        }

        public void Attach(IObserver observer) { 
            observers.Add(observer);
        }
        public void Detach(IObserver observer) {
            observers.Remove(observer); }
        public void Notify(string message)
        {
            foreach (var observer in observers)
            {
                observer.Update(message);
            }
        }

        //=======================================

        public void GameInstalled(string name)
        {
            Notify($"[EVENT] Game {name} was successfully INSTALLED");
        }

        public void GameLaunched(string name)
        {
            Notify($"[EVENT] Game {name} was successfully LAUNCHED");
        }

        public void GameClosed(string name)
        {
            Notify($"[EVENT] Game {name} was successfully CLOSED");
        }

        public void GameRated(string name, double rating)
        {
            Notify($"[EVENT] Game {name} was successfully RATED: {rating}");
        }

        public void TranslationStarted(string name)
        {
            Notify($"[EVENT] Translation of {name} was successfully STARTED");
        }

        public void TranslationStopped(string name)
        {
            Notify($"[EVENT] Translation of {name} was successfully STOPPED");
        }

        public void SaveLoaded(string name)
        {
            Notify($"[EVENT] Save {name} was LOADED successfully");
        }

        public void SaveMade(string name)
        {
            Notify($"[EVENT] Saving {name} was SAVED successfully");
        }

        public void GamepadConnected()
        {
            Notify($"[EVENT] Gamepad was connected!");
        }

        public void UserLoggedIn(string name)
        {
            Notify($"[EVENT] user {name} logged in!");
        }

        public void LogError(string errorMessage)
        {
            Notify($"Error: {errorMessage}");
        }

    }
}
