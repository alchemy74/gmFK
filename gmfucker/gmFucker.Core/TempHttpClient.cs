using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace gmFucker.Core
{
    public class TempHttpClient
    {


        /// <summary>
        /// 連線至BackendAPI DER方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="routeUrl"></param>
        /// <param name="httpMethod"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        private async Task<T> backendAPIConnect<T>(string routeUrl,HttpMethod method,object request)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(ConfigurationManager.AppSettings["BackendWebAPIUrl"]);
            httpClient.DefaultRequestHeaders.Accept.Clear(); 
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpRequestMessage httpRequest = new HttpRequestMessage(method, routeUrl);
            httpRequest.Content= new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(httpRequest);    
            httpResponseMessage.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<T>(await httpResponseMessage.Content.ReadAsStringAsync());
        }  
    }
}
