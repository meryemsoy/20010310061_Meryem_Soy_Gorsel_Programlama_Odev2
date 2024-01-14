using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.ServiceModel.Syndication;
using System.Xml;
using System.Reflection.PortableExecutable;


namespace MauiApp1.Models
{
    internal class Servisler
    {
        public static async Task<string> HaberlerGetir(Kategori ctg)
        {
            try
            {
                HttpClient client = new HttpClient();
                string url = $"htps://api.rss2json.com/v1/api.json?rss_url{ctg.Link}";

                using HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string jsondata = await response.Content.ReadAsStringAsync();
                return jsondata;
            }
            catch 
            {
                return null;
            }
        }

    }

}
