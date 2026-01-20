namespace WeebDexSharp.Models;

/// <summary>
/// Represents a page in a chapter
/// </summary>
public class WdImage : WdImageBase
{
	/// <summary>
	/// The file name of the image
	/// </summary>
	[JsonPropertyName("name")]
	public string Name { get; set; } = string.Empty;
}

/// <summary>
/// The base data for images
/// </summary>
public abstract class WdImageBase
{
	/// <summary>
	/// The dimensions of the image
	/// </summary>
	[JsonPropertyName("dimensions")]
	public int[] Dimensions { get; set; } = [];

	/// <summary>
	/// The width of the image
	/// </summary>
	[JsonIgnore]
	public int Width => Dimensions.Length > 0 ? Dimensions[0] : 0;

	/// <summary>
	/// The height of the image
	/// </summary>
	[JsonIgnore]
	public int Height => Dimensions.Length > 1 ? Dimensions[1] : 0;
}