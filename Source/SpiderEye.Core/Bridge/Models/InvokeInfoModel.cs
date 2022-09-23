using System.Text.Json.Serialization;

namespace SpiderEye.Bridge.Models
{
    internal class InvokeInfoModel
    {
        public string? Type { get; set; }
        public string? Id { get; set; }
        public int? CallbackId { get; set; }

        [JsonConverter(typeof(SystemTextRawJsonConverter))]
        public string? Parameters { get; set; }
    }
}
