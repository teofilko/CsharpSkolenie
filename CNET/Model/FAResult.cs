namespace Model
{
    public enum SourceType
    {
        URL,
        FILE
    }
    /// <summary>
    /// Vysledok frekvencnej analyzy pre jeden zdroj ( subor ci Url)
    /// </summary>
    public class FAResult
    {
        public  FAResult(string source, SourceType sourceType)
        {
            Source = source;
            SourceType = sourceType;
            Words = new Dictionary<string, int>();
        }

        /// <summary>
        /// Zdroj textu
        /// </summary>
        public string Source { get; set; }
        public SourceType SourceType { get; set; }

        /// <summary>
        /// Vysledna frekvencna analyza slov
        /// </summary>
        public Dictionary<string,int> Words { get; set; }

        public override string ToString() =>  $"{Source} {Words?.Count}";
        
    }
}