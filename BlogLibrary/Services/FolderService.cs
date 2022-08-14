using System.Collections.Generic;
using BlogApp.Data;
using BlogApp.Entities;
using BlogApp.Enums;

namespace BlogApp.Services
{
    /// <summary>
    /// Сервис по работе с папками
    /// </summary>
    public class FolderService
    {
        /// <summary>
        /// Получить количество папок
        /// </summary>
        /// <returns>Количество папок</returns>
        public int GetCount() => DbContext.GetFolders().Count;
        
        /// <summary>
        /// Получить папку
        /// </summary>
        /// <returns>Папка</returns>
        public Folder GetFolder(long id) => DbContext.GetFolder(id);
        
        /// <summary>
        /// Получить папки
        /// </summary>
        /// <returns>Список папок</returns>
        public List<Folder> GetFolders() => DbContext.GetFolders();
        
        /// <summary>
        /// Добавление папки
        /// </summary>
        /// <param name="name">Наименование</param>
        /// <returns>Истино, если все корректно сохранилось</returns>
        public bool Add(string name)
        {
            if (DbContext.AddFolder(new Folder() { Name = name }) == 1)
            {
                return true;
            }
            
            LoggerService.WriteLog("При сохранении папки произошла ошибка", LogType.Error);
            return false;
        }
        
        /// <summary>
        /// Удаление папки
        /// </summary>
        /// <param name="id">Идентификатор папки</param>
        /// <returns>Истино, если все корректно удалилось</returns>
        public bool Remove(long id)
        {
            Folder folder = DbContext.GetFolder(id);

            if (folder == null)
            {
                LoggerService.WriteLog($"Не нашлась папка с идентификатором {id}", LogType.Error);
                return false;
            }
            
            if (DbContext.RemoveFolder(folder) == 1)
            {
                return true;
            }
            
            LoggerService.WriteLog("При сохранении папки произошла ошибка", LogType.Error);
            return false;
        }
    }
}