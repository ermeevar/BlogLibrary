using System;

namespace BlogApp.Entities
{
    /// <summary>
    /// Статья
    /// </summary>
    public class Article
    {
        /// <summary>
        /// Уникальный идентификатор
        /// </summary>
        public long Id { get; set; }
        
        /// <summary>
        /// Заголовок
        /// </summary>
        public string Header { get; set; }
        
        /// <summary>
        /// Текст статьи
        /// </summary>
        public string Body { get; set; }
        
        /// <summary>
        /// Папка, в которой может находиться статья
        /// </summary>
        public Folder Folder { get; set; }
        
        /// <summary>
        /// Дата создания статьи
        /// </summary>
        public DateTime CreatedDate { get; set; }
        
        /// <summary>
        /// Признак актуальности
        /// </summary>
        public bool IsActual { get; set; }

        public override string ToString()
        {
            return $"[{Id}] {CreatedDate} {Header}";
        }
    }
}