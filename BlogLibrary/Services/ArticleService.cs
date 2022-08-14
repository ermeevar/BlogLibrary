using System;
using System.Collections.Generic;
using System.Linq;
using BlogApp.Data;
using BlogApp.Entities;
using BlogApp.Enums;

namespace BlogApp.Services
{
    /// <summary>
    /// Сервис по работе со статьями
    /// </summary>
    public class ArticleService
    {
        /// <summary>
        /// Получить количество статей
        /// </summary>
        /// <returns>Количество статей</returns>
        public int GetCount() => DbContext.GetArticles().Count;
        
        /// <summary>
        /// Получить статьи
        /// </summary>
        /// <returns>Список статей</returns>
        public List<Article> GetArticles() => DbContext.GetArticles();

        /// <summary>
        /// Получить статьи в папке
        /// </summary>
        /// <param name="folderId">Идентификатор папки</param>
        /// <returns>Статьи в папке</returns>
        public List<Article> GetArticlesByFolder(long folderId) =>
            DbContext.GetArticles().Any() 
                ? DbContext.GetArticles().Where(x => x.Folder.Id == folderId).ToList() 
                : null;
        
        /// <summary>
        /// Получить статью по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор статьи</param>
        /// <returns>Статья</returns>
        public Article Get(long id) => DbContext.GetArticle(id);
        
        /// <summary>
        /// Добавить статью в папку
        /// </summary>
        /// <param name="articleId">Идентификатор статьи</param>
        /// <param name="folderId">Идентификатор папки</param>
        /// <returns>Успешное добавление</returns>
        public bool AddArticleToFolder(long articleId, long folderId)
        { 
            Folder folder = DbContext.GetFolder(folderId);
            if (folder == null)
            {
                LoggerService.WriteLog($"Не найдена папка с идентификатором {folderId}", LogType.Error);
                return false;
            }
            
            Article article = DbContext.GetArticle(articleId);
            if (article == null)
            {
                LoggerService.WriteLog($"Не найдена статья с идентификатором {articleId}", LogType.Error);
                return false;
            }

            article.Folder = folder;
            return true;
        }
        
        /// <summary>
        /// Добавление статьи
        /// </summary>
        /// <param name="header">Заголовок</param>
        /// <param name="body">Текст</param>
        /// <param name="folderId">Идентификатор существующей папки</param>
        /// <param name="folderName">Наименование новой папки</param>
        /// <returns>Истино, если все корректно сохранилось</returns>
        public bool Add(string header, string body, long folderId = 0, string folderName = null)
        {
            Article article = new Article()
            {
                Header = header,
                Body = body,
                IsActual = true,
                CreatedDate = DateTime.Now
            };

            if (folderId != 0)
            {
                Folder folder = DbContext.GetFolder(folderId);
                if (folder != null)
                {
                    article.Folder = folder;
                }
                else
                {
                    LoggerService.WriteLog($"Не найдена папка с идентификатором {folderId}", LogType.Error);
                    return false;
                }
            }
            else if (!string.IsNullOrEmpty(folderName))
            {
                article.Folder = new Folder() { Name = folderName };
            }

            if (DbContext.AddArticle(article) == 1)
            {
                return true;
            }
            
            LoggerService.WriteLog("При сохранении статьи произошла ошибка", LogType.Error);
            return false;
        }
    }
}