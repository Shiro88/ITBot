using System;
using System.Collections.Generic;
using Microsoft.Bot.Builder.AI.Luis;
using Microsoft.Bot.Configuration;

namespace ITBot.Services
{
    public class BotService
    {
#pragma warning disable CS0618 // Type or member is obsolete
        [Obsolete]
        public BotService(BotConfiguration configuration)
#pragma warning restore CS0618 // Type or member is obsolete
        {
            foreach (var s in configuration.Services)
            {
                switch (s.Type)
                {
                    case ServiceTypes.Luis:
                        {
                            var luis = (LuisService)s;

                            if (luis == null)
                                throw new InvalidOperationException("The LUIS service is not configured correctly in your '.bot' file.");

                            var app = new LuisApplication(luis.AppId, luis.AuthoringKey, luis.GetEndpoint());
                            var recognizer = new LuisRecognizer(app);
                            this.LuisServices.Add(luis.Name, recognizer);
                            break;
                        }
                }
            }
        }

        public Dictionary<string, LuisRecognizer> LuisServices { get; } = new Dictionary<string, LuisRecognizer>();
    }
}
