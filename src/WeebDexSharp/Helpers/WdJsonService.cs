using CardboardBox.Json;

namespace WeebDexSharp.Helpers;

/// <summary>
/// Exposes common Json serialization and deserialization methods tailored to MangaDex
/// </summary>
public interface IWdJsonService : IJsonService
{
	/// <summary>
	/// Serializes the given data into an indented JSON string
	/// </summary>
	/// <typeparam name="T">The type of data to serialize</typeparam>
	/// <param name="data">The data to serialize</param>
	/// <returns>The pretty print version of the JSON</returns>
	string? Pretty<T>(T data);

	/// <summary>
	/// Deserializes the given JSON string into an object of the given type
	/// </summary>
	/// <param name="json">The JSON data</param>
	/// <param name="type">The type to deserialize</param>
	/// <returns>The returned deserialized data</returns>
	object? Deserialize(string json, Type type);
}

/// <inheritdoc cref="IWdJsonService" />
public class WdJsonService : SystemTextJsonService, IWdJsonService
{
	/// <summary>
	/// The default JSON Serialization options for the MangaDex API
	/// </summary>
	public static JsonSerializerOptions? DEFAULT_OPTIONS = null;

	/// <summary>
	/// The concrete implementation for the <see cref="IWdJsonService"/>
	/// </summary>
	public WdJsonService() : base(DEFAULT_OPTIONS ??= new JsonSerializerOptions
	{
		DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
	}) { }

	/// <inheritdoc />
	public string? Pretty<T>(T data)
	{
		var options = new JsonSerializerOptions
		{
			WriteIndented = true,
			DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
		};
		return JsonSerializer.Serialize(data, options);
	}

	/// <inheritdoc />
	public object? Deserialize(string json, Type type)
	{
		return JsonSerializer.Deserialize(json, type, DEFAULT_OPTIONS);
	}
}
