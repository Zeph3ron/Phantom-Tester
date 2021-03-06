﻿using System;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Worker.Commands;

namespace Worker.Converters
{
    internal class CommandConverter : JsonCreationConverter<WorkerCommand>
    {
        protected override WorkerCommand Create(Type objectType, JObject jObject)
        {
            if (FieldExists("Cmd", jObject))
            {
                var value = jObject["Cmd"].Value<string>();
                var parameters = jObject["Parameters"].Values<string>().ToArray();
                switch (value)
                {
                    case "Login":
                        return new Login(parameters);
                    case "GoToUrl":
                        return new GoToUrl(parameters);
                    case "ClickElement":
                        return new ClickElement(parameters);
                    case "ElementExists":
                        return new ElementExists(parameters);
                    case "GiveInput":
                        return new GiveInput(parameters);
                }
            }
            return null;
        }

        private bool FieldExists(string fieldName, JObject jObject)
        {
            return jObject[fieldName] != null;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
}
