using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using ITBot.Helpers;
using ITBot.Models;
using System;
using Newtonsoft.Json.Linq;

namespace ITBot.Services
{
    public static class SupportService
    {
        public static async Task<SupportModel> GetEntityValue(string title)
        {
       
                var query = $"{Constants.ZendeskGuideAPIUrl}?query={title}&appid={Constants.ZendeskGuideAPIKey}";

                using (var client = new HttpClient())
                {
                    var getTitle = await client.GetAsync(query);

                    if (getTitle.IsSuccessStatusCode)
                    {
                        var json = await getTitle.Content.ReadAsStringAsync();

                        JArray jsonArray = JArray.Parse(json);
                        dynamic data = JObject.Parse(jsonArray[0].ToString());
                      
                        var url = JsonConvert.DeserializeObject<SupportModel>(json);


                        return url;
                    }
          
             
            }
            

        }
    }

}

