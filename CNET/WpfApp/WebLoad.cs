using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp
{
    internal class WebLoad
    {
        public static (int? Length, string Url, bool success) LoadUrl(string url, IProgress<string>? progress = null)
        {
            System.Diagnostics.Stopwatch sw = System.Diagnostics.Stopwatch.StartNew();
            try
            {
                HttpClient httpCient = new HttpClient();
                var content = httpCient.GetStringAsync(url).Result;
                sw.Stop();
                progress?.Report($"\n{url} {content.Length} {sw.ElapsedMilliseconds} ms");
                return (content.Length, url, true);
            }
            catch (Exception ex)
            {
                File.AppendAllText("errors.txt", $"LoadUrl: {DateTime.Now} {ex.Message}\n");
                sw.Stop();
                progress?.Report($"\nerror {url} {sw.ElapsedMilliseconds} ms");
                return (null, url, false);
            }
        }
    }
}
