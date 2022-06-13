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
        /// <summary>
        /// Zdroj textu
        /// </summary>
        public string Source { get; set; }
        public SourceType SourceType { get; set; }

        /// <summary>
        /// Vysledna frekvencna analyza slov
        /// </summary>
        public Dictionary<string,int> Words { get; set; }= new Dictionary<string, int>();

        public override string ToString() =>  $"{Source} {Words?.Count}";
        
    }
}