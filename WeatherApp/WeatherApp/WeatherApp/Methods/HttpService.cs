using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;

namespace WeatherApp;

public class HttpService
{
   public JObject? QueryResponse(string url)
   {
      using var client = new HttpClient();
      client.DefaultRequestHeaders.Accept.Add(
         new MediaTypeWithQualityHeaderValue("application/json"));
      url += "&appid=c82d2d03d734d8de33c345f0d5ddd378";
      try
      {
         var result = client.GetStringAsync(url);
         var content = result.Result;
         JObject? json = JObject.Parse(content);
         return json;
      }
      catch (Exception e)
      {
         JObject? js = null;
         return js;
      }
   }
}