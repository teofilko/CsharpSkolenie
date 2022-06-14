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
        public static (int Length, string Url, bool success) LoadUrl(string url)
        {
            try
            {
                HttpClient httpCient = new HttpClient();
                var content = httpCient.GetStringAsync(url).Result;
                return (content.Length, url, true);
            }
            catch (Exception ex)
            {
                File.AppendAllText("errors.txt", $"LoadUrl: {DateTime.Now} {ex.Message}\n");
                return (-1, url, false);
            }
        }
    }
}
