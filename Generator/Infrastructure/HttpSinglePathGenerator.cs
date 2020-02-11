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
        public static RootObject GetSinglePath(string query)
        {
            
            string url = query;
            RootObject root = new RootObject();
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = client.GetAsync(url).GetAwaiter().GetResult();
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content;
                    root = responseContent.ReadAsAsync<RootObject>().GetAwaiter().GetResult();
                   

                    return root;
                }
                else
                {
                    return root;
                }
            }
        }
    }
}