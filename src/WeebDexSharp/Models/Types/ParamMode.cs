namespace WeebDexSharp.Models.Types;

/// <summary>
/// The mode for parameter combination
/// </summary>
[JsonConverter(typeof(WeebDexEnumParser<ParamMode>))]
public enum ParamMode
{
	/// <summary>
	/// Ensure all parameters are present
	/// </summary>
	And,
	/// <summary>
	/// Ensure at least one parameter is present
	/// </summary>
	Or,
}
