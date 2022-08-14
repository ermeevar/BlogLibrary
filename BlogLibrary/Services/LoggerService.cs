using System;
using System.IO;
using System.Text;
using BlogApp.Enums;

namespace BlogApp.Services
{
    /// <summary>
    /// Сервис по работе с логированием
    /// </summary>
    public static class LoggerService
    {
        /// <summary>
        /// Записать лог
        /// </summary>
        /// <param name="message">Сообщение для лога</param>
        /// <param name="logType">Тип лога</param>
        public static void WriteLog(string message, LogType logType)
        {
            using (StreamWriter stream = new StreamWriter("logs.txt", true, Encoding.UTF8))
            {
                stream.WriteLine($"[{DateTime.Now}] [{Enum.GetName(typeof(LogType), logType)}] [{message}]");
            }
        }
    }
}