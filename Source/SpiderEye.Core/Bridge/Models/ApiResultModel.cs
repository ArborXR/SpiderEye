using System;
using System.Text.Json.Serialization;

namespace SpiderEye.Bridge.Models
{
    internal class ApiResultModel
    {
        [JsonConverter(typeof(SystemTextRawJsonConverter))]
        public string? Value { get; set; }

        public bool Success { get; set; }
        public Exception? Error { get; set; }

        public static ApiResultModel FromError(Exception exception)
        {
            return new ApiResultModel
            {
                Value = null,
                Success = false,
                Error = exception,
            };
        }
    }
}
