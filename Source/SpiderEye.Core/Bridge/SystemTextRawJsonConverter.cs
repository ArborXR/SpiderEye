﻿using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SpiderEye.Bridge
{
    internal class SystemTextRawJsonConverter : JsonConverter<string>
    {
        public override string Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using var doc = JsonDocument.ParseValue(ref reader);
            return doc.RootElement.GetRawText();
        }

        public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options)
        {
            writer.WriteRawValue(value, skipInputValidation: true);
        }
    }
}
