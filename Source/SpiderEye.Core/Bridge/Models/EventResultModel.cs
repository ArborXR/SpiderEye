using System.Text.Json.Serialization;

namespace SpiderEye.Bridge.Models
{
    internal class EventResultModel
    {
        [JsonConverter(typeof(SystemTextRawJsonConverter))]
        public string? Result { get; set; }

        public bool HasResult { get; set; }
        public JsErrorModel? Error { get; set; }
        public bool Success { get; set; }
        public bool NoSubscriber { get; set; }
    }
}
