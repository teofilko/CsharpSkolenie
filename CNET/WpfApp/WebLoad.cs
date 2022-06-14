using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp
{
    internal class WebLoad
    {
        public static int LoadUrl(string url)
        {
            HttpClient httpCient = new HttpClient();
            var content = httpCient.GetStringAsync(url).Result;
            return content.Length;
        }
    }
}
