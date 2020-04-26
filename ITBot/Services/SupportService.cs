using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using ITBot.Helpers;
using ITBot.Models;
using System;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Authorization;

namespace ITBot.Services
{
    public static class SupportService
    {
        [AllowAnonymous]
        public static async Task<SupportModel> GetEntityValue(string title)
        {


            var query = $"{Constants.ZendeskGuideAPIUrl}?query={title}";

            using (var client = new HttpClient())
            {
                var getWeather = await client.GetAsync(query);

                if (getWeather.IsSuccessStatusCode)
                {
                    try {


                        var json = await getWeather.Content.ReadAsStringAsync();
                        var article = JsonConvert.DeserializeObject<SupportModel>(json);
                        //article = article.Results.ToString;


                        //article = article.Page +1;
                        return article;
                    }

                    catch (Exception e)
                    {
                        Console.WriteLine (e);
                        Console.WriteLine(title);
                    }
                    
                }
            }
            return default;


        }
    }



   

}

