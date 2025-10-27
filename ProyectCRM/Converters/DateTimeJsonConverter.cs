using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProyectCRM.Converters
{
    public class DateTimeJsonCoverter : JsonConverter<DateTime>
    {
        private const string Format = "dd-MM-yyyy HH:mm";

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.String)
                throw new JsonException("Expected string token for DateTime.");

            var s = reader.GetString();
            if (string.IsNullOrWhiteSpace(s))
                throw new JsonException("Null or empty value for DateTime.");

            if (DateTime.TryParseExact(s, Format, CultureInfo.InvariantCulture, DateTimeStyles.None, out var date))
                return date;

            // Fallback: intentar parsear formatos comunes (opcional)
            if (DateTime.TryParse(s, CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal, out date))
                return date;

            throw new JsonException($"Invalid DateTime format. Expected format: {Format}.");
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(Format, CultureInfo.InvariantCulture));
        }
    }
}
