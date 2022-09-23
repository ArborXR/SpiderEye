using System;
using System.Text.Json;

namespace SpiderEye.Bridge
{
    internal class SystemTextJsonConverter : IJsonConverter
    {
        private static JsonSerializerOptions Options { get; set; } = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        };

        public T? Deserialize<T>(string json)
        {
            return JsonSerializer.Deserialize<T>(json, Options);
        }

        public object? Deserialize(string json, Type type)
        {
            return JsonSerializer.Deserialize(json, type, Options);
        }

        public string Serialize(object? value)
        {
            return JsonSerializer.Serialize(value, Options);
        }
    }
}
