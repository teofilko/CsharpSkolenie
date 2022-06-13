namespace Data
{
    public static class FreqAnalysis
    {
        public static Dictionary<string, int> FreqAnalysisFromString(string input)
        {
            //var result = new Dictionary<string,int>();
            throw new NotImplementedException();
        }
        public static async Task<Dictionary<string, int>> FreqAnalysisFromUrl(string url)
        {
            HttpClient httpClient = new ();
            var content = await httpClient.GetStringAsync(url);
            return FreqAnalysisFromString(content);
        }
        public static Dictionary<string, int> FreqAnalysisFromFile(string file)
        {
            string content = File.ReadAllText(file);
            return FreqAnalysisFromString(content);
        }
    }
}