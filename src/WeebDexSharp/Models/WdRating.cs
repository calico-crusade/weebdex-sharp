namespace WeebDexSharp.Models;

/// <summary>
/// Represents a rating on an entity
/// </summary>
public class WdRating
{
	/// <summary>
	/// The average rating for the entity
	/// </summary>
	[JsonPropertyName("average")]
	public double Average { get; set; }

	/// <summary>
	/// The Bayesian average for the entity
	/// </summary>
	[JsonPropertyName("bayesian")]
	public double Bayesian { get; set; }

	/// <summary>
	/// The distribution of ratings for the entity
	/// </summary>
	[JsonPropertyName("distribution")]
	public double[] Distribution { get; set; } = [];
}
