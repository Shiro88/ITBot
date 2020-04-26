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
            string resultado = string.Empty;

            if (result.Intents.First().Key == "Configurar_Aplicacion")
            {
                var disp = Constants.Ninguno;
                var app = Constants.Ninguno;
                if (result.Entities.ContainsKey(Constants.Aplicacion)) app = result.Entities[Constants.Aplicacion].First().ToString();

                if (result.Entities.ContainsKey(Constants.Dispositivo)) disp = result.Entities[Constants.Dispositivo].First().First().ToString();

                resultado = $"{disp},{app}";

                /*

                foreach (var entity in result.Entities)
                {
                    JArray jsonArray = JArray.Parse(entity.Value.ToString());
                    var jsonObjects = jsonArray.OfType<JObject>().ToList();

                    dynamic aplicacion = JObject.Parse(jsonArray[0].ToString())[Constants.Aplicacion];
                    //var password = JObject.Parse(entity.Value.ToString())[Constants.PasswordLabel];
                    //var password = JObject.Parse(entity.Value.ToString())[Constants.PasswordLabel];

                    dynamic dispositivo = JObject.Parse(jsonArray[0].ToString())[Constants.Dispositivo];
                    
                    if (aplicacion != null || dispositivo != null)
                    {
                        
                        dynamic value = JsonConvert.DeserializeObject<dynamic>(entity.Value.ToString());

                        if (aplicacion != null)
                            resultado = aplicacion;
                        else resultado = Constants.Ninguno;

                        if (dispositivo != null)
                            //resultado += "_" + dispositivo;
                            resultado += $",{dispositivo}";
                        else resultado = Constants.Ninguno;
                    }
                    return resultado; 
                } */
             

            }

            return resultado;
    
        }
    }
}