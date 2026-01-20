namespace WeebDexSharp.Models.Types;

/// <summary>
/// The time frame for which to retrieve data
/// </summary>
/// <remarks>This cannot be serialized directly</remarks>
public enum TimeFrame
{
	/// <summary>
	/// Represents a time interval of 24 hours.
	/// </summary>
	TwentyFourHours,
	/// <summary>
	/// Represents a time span of seven days.
	/// </summary>
	SevenDays,
	/// <summary>
	/// Represents a period of thirty days.
	/// </summary>
	ThirtyDays,
}
