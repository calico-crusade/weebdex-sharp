namespace WeebDexSharp.Models;

/// <summary>
/// Represents a thread reference in weebdex
/// </summary>
public class WdThread
{
	/// <summary>
	/// The ID of the thread
	/// </summary>
	[JsonPropertyName("id")]
	public string Id { get; set; } = string.Empty;

	/// <summary>
	/// Whether or not comments are locked on the thread
	/// </summary>
	[JsonPropertyName("locked")]
	public bool Locked { get; set; }
}
