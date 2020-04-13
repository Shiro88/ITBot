// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
//
// Generated with Bot Builder V4 SDK Template for Visual Studio EchoBot v4.6.2

using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using System.Linq;
using ITBot.Helpers;
using ITBot.Services;

namespace ITBot.Bots
{
    public class EchoBot : IBot
    {
        public static readonly string LuisKey = "ITBot";
        private readonly BotService _services;

        public EchoBot(BotService services)
        {
            _services = services ?? throw new System.ArgumentNullException(nameof(services));

            if (!_services.LuisServices.ContainsKey(LuisKey))
                throw new System.ArgumentException($"Invalid configuration....");
        }

#pragma warning disable CS0114 // Member hides inherited member; missing override keyword
        public async Task OnTurnAsync(ITurnContext turnContext, CancellationToken cancellationToken = default)
#pragma warning restore CS0114 // Member hides inherited member; missing override keyword
        {
            if (turnContext.Activity.Type == ActivityTypes.Message)
            {
                var recognizer = await _services.LuisServices[LuisKey].RecognizeAsync(turnContext, cancellationToken);
                var topIntent = recognizer?.GetTopScoringIntent();

                if (topIntent != null && topIntent.HasValue && topIntent.Value.intent != "None")
                {
                    var article = LuisParser.GetEntityValue(recognizer);

                    if (article.ToString() != string.Empty)
                    {
                        var ro = await SupportService.GetEntityValue(article);
                        //var weather = $"{ro..First().main} ({ro.main.temp.ToString("N2")} °C)";
                        var title = $"{ro.Results.First().HtmlUrl}";
                        var typing = Activity.CreateTypingActivity();
                        var delay = new Activity { Type = "delay", Value = 5000 };

                        var activities = new IActivity[] {
                            typing,
                            delay,
                            MessageFactory.Text($"Maybe this {title} could help you"),
                            MessageFactory.Text("Thanks for using our service!")
                        };

                        await turnContext.SendActivitiesAsync(activities);
                    }
                    else
                        await turnContext.SendActivityAsync($"==>Can't understand you, sorry!");
                }
                else
                {
                    var msg = @"No LUIS intents were found.
                    This sample is about identifying a city and an intent:
                    'Find the current weather in a city'
                    Try typing 'What's the weather in Prague'";

                    await turnContext.SendActivityAsync(msg);
                }
            }
            else if (turnContext.Activity.Type == ActivityTypes.ConversationUpdate)
                await SendWelcomeMessageAsync(turnContext, cancellationToken);
            else
                await turnContext.SendActivityAsync($"{turnContext.Activity.Type} event detected", cancellationToken: cancellationToken);
        }

        private static async Task SendWelcomeMessageAsync(ITurnContext turnContext, CancellationToken cancellationToken)
        {
            foreach (var member in turnContext.Activity.MembersAdded)
            {
                if (member.Id != turnContext.Activity.Recipient.Id)
                {
                    await turnContext.SendActivityAsync(
                        $"Hi i am ITBot how can i help you? {member.Name}!",
                        cancellationToken: cancellationToken);
                }
            }
        }
    }
}
