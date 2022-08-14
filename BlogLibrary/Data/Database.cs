using System.Collections.Generic;
using BlogApp.Entities;

namespace BlogApp.Data
{
    /// <summary>
    /// Фейковая БД
    /// </summary>
    internal static class Database
    {
        /// <summary>
        /// Статьи
        /// </summary>
        internal static List<Article> Articles { get; set; }
        
        /// <summary>
        /// Папки
        /// </summary>
        internal static List<Folder> Folders { get; set; }

        
        /// <summary>
        /// Инициализация "таблиц"
        /// </summary>
        static Database()
        {
            Articles = new List<Article>();
            Folders = new List<Folder>();
        }
    }
}