using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.Bot.Builder;
using System.Linq;

namespace ITBot.Helpers
{
    public static class LuisParser
    {
        public static JsonConverter[] Settings { get; }

        public static string GetEntityValue(RecognizerResult result)
        {
            foreach (var entity in result.Entities)
            {
                JArray jsonArray = JArray.Parse(entity.Value.ToString());
                var jsonObjects = jsonArray.OfType<JObject>().ToList();

                dynamic password = JObject.Parse(jsonArray[0].ToString())[Constants.PasswordLabel];
               //var password = JObject.Parse(entity.Value.ToString())[Constants.PasswordLabel];
                //var password = JObject.Parse(entity.Value.ToString())[Constants.PasswordLabel];

                dynamic passwordPattern = JObject.Parse(jsonArray[0].ToString())[Constants.PasswordPatternLabel];

                if (password != null || passwordPattern != null)
                {
                    dynamic value = JsonConvert.DeserializeObject<dynamic>(entity.Value.ToString());

                    if (password != null)
                        return value.Location[0].text;

                    if (passwordPattern != null)
                        return value.Location_PatternAny[0].text;
                }
            }

            return string.Empty;
        }
    }
}