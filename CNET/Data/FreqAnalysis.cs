using Model;
using System.Text.RegularExpressions;
namespace Data
{
    public static class FreqAnalysis
    {
        private static Dictionary<string, int> FreqAnalysisFromString(string input)
        {
            Dictionary<string, int> d = new Dictionary<string, int>();
            Regex regex = new Regex(@"\w(?<!\d)[\w'-]*");
            MatchCollection allWords =  regex.Matches(input);


            //string[] words = input.Split(" ,\n,\r".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            foreach (Match word in allWords)
            {
                /*if (word.Value == " ")
                    continue;
                else*/ if (d.ContainsKey(word.Value))
                    d[word.Value]++;
                else
                    d[word.Value] = 1;
            }
            return d;
        }
        public static async Task<FAResult> FreqAnalysisFromUrl(string url)
        {
            HttpClient httpClient = new();
            var content = await httpClient.GetStringAsync(url);
            var dic= FreqAnalysisFromString(content);
            return new FAResult() { Source = url, SourceType = SourceType.URL, Words = dic };
        }
        public static Dictionary<string, int> FreqAnalysisFromFile(string file)
        {
            string content = File.ReadAllText(file);
            return FreqAnalysisFromString(content);
        }
    }

}