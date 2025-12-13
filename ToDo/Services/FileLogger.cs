using System;
using System.IO;

namespace ToDo.Services
{
    public static class FileLogger
    {
        private static readonly string _logFilePath;

        static FileLogger()
        {
            // Chemin du fichier logs
            _logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs.txt");

            // Créer le fichier si n'existe pas
            if (!File.Exists(_logFilePath))
            {
                File.Create(_logFilePath).Close();
            }
        }

        public static void Log(string username, string action)
        {
            string line = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | User: {username} | Action: {action}";

            lock (_logFilePath) // Éviter les collisions d'écriture
            {
                using (StreamWriter writer = new StreamWriter(_logFilePath, true))
                {
                    writer.WriteLine(line);
                }
            }
        }
    }
}
