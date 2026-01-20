namespace WeebDexSharp.Helpers.Utilities;

internal class WeebDexExceptionParser : JsonConverter<Exception>
{
	public override Exception? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		var value = reader.GetString();
		return new Exception(value);
	}

	public override void Write(Utf8JsonWriter writer, Exception value, JsonSerializerOptions options)
	{
		JsonSerializer.Serialize(writer, value.ToString(), typeof(string), options);
	}
}
