
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Rij62;

public class JsonStringFlagsEnumConverter : JsonConverterFactory
{
    public override bool CanConvert(Type typeToConvert)
    {
        return typeToConvert.IsEnum;
    }

    public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        JsonConverter converter = (JsonConverter)Activator.CreateInstance(
            typeof(JsonStringFlagsEnumConverterInner<>).MakeGenericType(
                [typeToConvert]),
            BindingFlags.Instance | BindingFlags.Public,
            binder: null,
            args: [options],
            culture: null)!;

        return converter;
    }

    public class JsonStringFlagsEnumConverterInner<TEnum> : JsonConverter<TEnum> where TEnum : struct, Enum
    {
        public JsonStringFlagsEnumConverterInner(JsonSerializerOptions options)
        {

        }

        public override TEnum Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartArray)
                throw new JsonException("Expected start of array.");

            long value = 0;

            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndArray)
                    break;

                if (reader.TokenType != JsonTokenType.String)
                    throw new JsonException("Expected string.");

                string enumText = reader.GetString()!;

                if (!Enum.TryParse<TEnum>(enumText, ignoreCase: true, out var parsed))
                    throw new JsonException($"Invalid value '{enumText}' for enum {typeof(TEnum)}");

                value |= Convert.ToInt64(parsed);
            }

            return (TEnum)Enum.ToObject(typeof(TEnum), value);
        }

        public override void Write(Utf8JsonWriter writer, TEnum value, JsonSerializerOptions options)
        {
            writer.WriteStartArray();
            foreach (var enumValue in Enum.GetValues<TEnum>())
            {
                long longValue = Convert.ToInt64(enumValue);
                long currentValue = Convert.ToInt64(value);

                if (longValue != 0 && (currentValue & longValue) == longValue)
                {
                    writer.WriteStringValue(enumValue.ToString());
                }
            }
            writer.WriteEndArray();
        }
    }
}
