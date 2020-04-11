using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.Bot.Builder;

namespace ITBot.Helpers
{
    public static class LuisParser
    {
        public static string GetEntityValue(RecognizerResult result)
        {
            foreach (var entity in result.Entities)
            {
                var password = JObject.Parse(entity.Value.ToString())[Constants.PasswordLabel];
                var passwordPattern = JObject.Parse(entity.Value.ToString())[Constants.PasswordPatternLabel];

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