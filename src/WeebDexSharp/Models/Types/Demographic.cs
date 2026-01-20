namespace WeebDexSharp.Models.Types;

/// <summary>
/// The various demographics the mangas can have
/// </summary>
[JsonConverter(typeof(WeebDexEnumParser<Demographic>))]
public enum Demographic
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
	Shounen,
	Shoujo,
	Seinen,
	Josei,
	None
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
