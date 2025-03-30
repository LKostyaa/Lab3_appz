using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB2_APPZ
{
    public static class ErrorLogger
    {
        // Подія для помилок
        public static event Action<string>? OnErrorLogged;

        // Метод для виклику події
        public static void LogError(string errorMessage)
        {
            OnErrorLogged?.Invoke($"Error: {errorMessage}");
        }
    }
}
