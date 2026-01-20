namespace WeebDexSharp;

/// <summary>
/// A bunch of useful extensions for WD related tasks
/// </summary>
public static class Extensions
{
	/// <summary>
	/// Adds the WeebDex API to the given service collection
	/// </summary>
	/// <param name="services">The service collection to inject into</param>
	/// <param name="config">The optional configuration builder for the services</param>
	/// <returns>The service collection for chaining</returns>
	/// <remarks>You should only call this once for the service collection</remarks>
	public static IServiceCollection AddWeebDex(this IServiceCollection services, Action<IWeebDexBuilder>? config = null)
	{
		var builder = new WeebDexBuilder(services);
		config?.Invoke(builder);
		builder.AddDefaults();
		return services;
	}
}
