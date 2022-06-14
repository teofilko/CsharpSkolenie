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
        public Dictionary<string, int> Words { get; set; } = new Dictionary<string, int>();

        public Dictionary<string, int> GetTopTen() => (Dictionary<string, int>)Words.OrderByDescending(kv => kv.Value).Take(10);

        public override string ToString() => $"{Source} {Words?.Count}";

    }
}