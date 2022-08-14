namespace BlogApp.Entities
{
    /// <summary>
    /// Папка
    /// </summary>
    public class Folder
    {
        /// <summary>
        /// Уникальный идентификатор
        /// </summary>
        public long Id { get; set; }
        
        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }
        
        public override string ToString()
        {
            return $"[{Id}] {Name}";
        }
    }
}