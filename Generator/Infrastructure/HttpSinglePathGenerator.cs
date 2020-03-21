using Generator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Web;

namespace Generator.Infrastructure
{
    public class HttpSinglePathGenerator
    {
        public static Route GetSinglePath(string query)
        {           
            string url = query;
            Root root = new Root();
            Route route = new Route();
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync(url).GetAwaiter().GetResult();
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content;
                    root= responseContent.ReadAsAsync<Root>().GetAwaiter().GetResult();
                    route = root.routes.First();
                    return route;
                }
                else
                {
                    return route;
                }
            }
        }
    }
}