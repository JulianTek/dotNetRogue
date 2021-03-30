using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace dotNetRogue.Data
{
    public static class APICaller
    {
        // private readonly IHttpClientFactory factory;
        public static HttpClient ApiClient { get; set; }

        /*public APICaller(IHttpClientFactory factory)
        {
            this.factory = factory;
        }
        */

        public static void InitializeClient()
        {
            ApiClient = new HttpClient();
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
