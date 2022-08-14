using System;
using System.Collections.Generic;
using System.Linq;
using BlogApp.Entities;

namespace BlogApp.Data
{
    /// <summary>
    /// Работа с БД
    /// </summary>
    internal static class DbContext
    {
        #region Работа со статьями

        /// <summary>
        /// Добавить статью
        /// </summary>
        /// <param name="article">Статья</param>
        /// <returns>Количество измененных строк</returns>
        internal static int AddArticle(Article article)
        {
            try
            {
                // Генерируем уникальный айдишник
                article.Id = Database.Articles.Count > 0 
                    ? Database.Articles.Max(x => x.Id) + 1 
                    : 1;

                Database.Articles.Add(article);

                if (article.Folder != null && Database.Folders.Count > 0 &&
                    Database.Folders.All(x => x.Id != article.Folder.Id))
                {
                    Database.Folders.Add(article.Folder);
                }

                return 1;
            }
            catch
            {
                return 0;
            }
        }
        
        /// <summary>
        /// Удалить статью
        /// </summary>
        /// <param name="article">Статья</param>
        /// <returns>Количество измененных строк</returns>
        internal static int RemoveArticle(Article article)
        {
            try
            {
                Database.Articles.Remove(article);

                if (article.Folder != null && Database.Folders.Count > 0 && Database.Folders.Any(x => x.Id == article.Folder.Id))
                {
                    Database.Folders.Remove(article.Folder);
                }

                return 1;
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Найти статью по идентификатору
        /// </summary>
        /// <param name="id">Уникальный идентификатор</param>
        /// <returns>Найденная статья</returns>
        internal static Article GetArticle(long id) => 
            Database.Articles.Count > 0 ? Database.Articles.First(x => x.Id == id) : null;
        
        /// <summary>
        /// Найти все статьи
        /// </summary>
        /// <returns>Найденные статьи</returns>
        internal static List<Article> GetArticles() => Database.Articles;

        #endregion

        #region Работа с папками

        /// <summary>
        /// Добавить папку
        /// </summary>
        /// <param name="folder">Папка</param>
        /// <returns>Количество измененных строк</returns>
        internal static int AddFolder(Folder folder)
        {
            try
            {
                // Генерируем уникальный айдишник
                folder.Id = Database.Folders.Count > 0 ? Database.Folders.Max(x => x.Id) + 1 : 1;
                
                Database.Folders.Add(folder);
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        
        /// <summary>
        /// Удаленить папку
        /// </summary>
        /// <param name="folder">Папка</param>
        /// <returns>Количество измененных строк</returns>
        internal static int RemoveFolder(Folder folder)
        {
            try
            {
                Database.Folders.Remove(folder);
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        
        /// <summary>
        /// Найти папку по идентификатору
        /// </summary>
        /// <param name="id">Уникальный идентификатор</param>
        /// <returns>Найденная папкак</returns>
        internal static Folder GetFolder(long id) => 
            Database.Folders.Count > 0 ? Database.Folders.First(x => x.Id == id) : null;
        
        /// <summary>
        /// Найти все папки
        /// </summary>
        /// <returns>Найденные папки</returns>
        internal static List<Folder> GetFolders() => Database.Folders;

        #endregion
    }
}