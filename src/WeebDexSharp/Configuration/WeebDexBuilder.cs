using Microsoft.Extensions.DependencyInjection.Extensions;

namespace WeebDexSharp.Configuration;

/// <summary>
/// A service for building the WeebDex API client configuration
/// </summary>
public interface IWeebDexBuilder
{
	#region Api Config
	/// <summary>
	/// Uses the given api configuration for the WeebDex API client
	/// </summary>
	/// <typeparam name="T">The instance of the api configuration</typeparam>
	/// <param name="transient">Whether or not to register the service as a transient or singleton</param>
	/// <returns>The current builder for fluent method chaining</returns>
	IWeebDexBuilder WithApiConfig<T>(bool transient = true) where T : class, IApiConfigurationService;

	/// <summary>
	/// Uses the given api configuration for the WeebDex API client
	/// </summary>
	/// <param name="config">The configuration to use</param>
	/// <returns>The current builder for fluent method chaining</returns>
	IWeebDexBuilder WithApiConfig(IApiConfigurationService config);

	/// <summary>
	/// Uses the given configuration for the WeebDex API client
	/// </summary>
	/// <param name="apiUrl">The URL for the WeebDex API</param>
	/// <param name="userAgent">The User-Agent header to send with requests</param>
	/// <param name="throwOnError">Whether or not to throw an exception if the API returns an error</param>
	/// <returns>The current builder for fluent method chaining</returns>
	IWeebDexBuilder WithApiConfig(string? apiUrl = null, string? userAgent = null, bool throwOnError = false);

	/// <summary>
	/// Uses the given configuration for the WeebDex API client
	/// </summary>
	/// <param name="config">The configuration</param>
	/// <returns>The current builder for fluent method chaining</returns>
	IWeebDexBuilder WithApiConfig(Action<ApiConfigurationBuilder> config);
	#endregion

	#region Credentials config
	/// <summary>
	/// Uses the given credentials service for the WeebDex API client
	/// </summary>
	/// <typeparam name="T">The instance of the credentials</typeparam>
	/// <param name="transient">Whether or not to register the service as a transient or singleton</param>
	/// <returns>The current builder for fluent method chaining</returns>
	IWeebDexBuilder WithCredentials<T>(bool transient = true) where T : class, ICredentialsService;

	/// <summary>
	/// Uses the given credentials service for the WeebDex API client
	/// </summary>
	/// <param name="credentials">The credentials to use</param>
	/// <returns></returns>
	IWeebDexBuilder WithCredentials(ICredentialsService credentials);

	/// <summary>
	/// Uses the given credentials service for the WeebDex API client
	/// </summary>
	/// <param name="config"></param>
	/// <returns>The current builder for fluent method chaining</returns>
	IWeebDexBuilder WithCredentials(Func<IServiceProvider, ICredentialsService> config);

	/// <summary>
	/// Uses the given credentials service for the WeebDex API client
	/// </summary>
	/// <param name="cookie">The cookie to use</param>
	/// <returns>The current builder for fluent method chaining</returns>
	IWeebDexBuilder WithCredentialsCookie(string cookie);

	/// <summary>
	/// Uses the given credentials service for the WeebDex API client
	/// </summary>
	/// <param name="id">The client ID to use</param>
	/// <param name="secret">The client secret to use</param>
	/// <returns>The current builder for fluent method chaining</returns>
	IWeebDexBuilder WithCredentialsApiKey(string id, string secret);
	#endregion

	/// <summary>
	/// Adds an event watcher to the WeebDex API client
	/// </summary>
	/// <typeparam name="T">The type of event watcher</typeparam>
	/// <param name="transient">Whether or not to register the service as a transient or singleton</param>
	/// <returns>The current builder for fluent method chaining</returns>
	/// <remarks>
	/// You can create and inject multiple of these and they will be run in the order they're added.
	/// </remarks>
	IWeebDexBuilder WithEvents<T>(bool transient = true) where T : class, IWdEventService; 
}

internal class WeebDexBuilder(
	IServiceCollection _services) : IWeebDexBuilder
{
	#region Api Config
	public IWeebDexBuilder WithApiConfig(IApiConfigurationService config)
	{
		_services.AddSingleton(config);
		return this;
	}

	public IWeebDexBuilder WithApiConfig(string? apiUrl = null, string? userAgent = null, bool throwOnError = false)
	{
		return WithApiConfig(c =>
		{
			c.WithApiUrl(apiUrl)
			 .WithUserAgent(userAgent);
			if (throwOnError)
				c.ThrowExceptionOnError();
			else
				c.FailGracefully();
		});
	}

	public IWeebDexBuilder WithApiConfig(Action<ApiConfigurationBuilder> config)
	{
		var bob = new ApiConfigurationBuilder();
		config(bob);
		return WithApiConfig(bob.Build());
	}

	IWeebDexBuilder IWeebDexBuilder.WithApiConfig<T>(bool transient)
	{
		if (transient)
			_services.AddTransient<IApiConfigurationService, T>();
		else
			_services.AddSingleton<IApiConfigurationService, T>();
		return this;
	}
	#endregion

	#region Credentials config
	public IWeebDexBuilder WithCredentials(ICredentialsService credentials)
	{
		return WithCredentials(_ => credentials);
	}

	public IWeebDexBuilder WithCredentials(Func<IServiceProvider, ICredentialsService> config)
	{
		_services.AddSingleton(config);
		return this;
	}

	public IWeebDexBuilder WithCredentialsApiKey(string id, string secret)
	{
		return WithCredentials(new HardCodedCredService(id, secret, null));
	}

	public IWeebDexBuilder WithCredentialsCookie(string cookie)
	{
		return WithCredentials(new HardCodedCredService(null, null, cookie));
	}

	IWeebDexBuilder IWeebDexBuilder.WithCredentials<T>(bool transient)
	{
		if (transient)
			_services.AddTransient<ICredentialsService, T>();
		else
			_services.AddSingleton<ICredentialsService, T>();
		return this;
	}
	#endregion

	IWeebDexBuilder IWeebDexBuilder.WithEvents<T>(bool transient)
	{
		if (transient)
			_services.AddTransient<IWdEventService, T>();
		else
			_services.AddSingleton<IWdEventService, T>();
		return this;
	}

	public void AddDefaults()
	{
		_services.AddHttpClient();
		_services.TryAddTransient<IWeebDex, WeebDex>();

		_services.TryAddTransient<IWdApiAuthorService, WdApiAuthorService>();
		_services.TryAddTransient<IWdApiChapterService, WdApiChapterService>();
		_services.TryAddTransient<IWdApiMangaService, WdApiMangaService>();

		_services.TryAddTransient<IWdApiService, WdApiService>();
		_services.TryAddTransient<IWdJsonService, WdJsonService>();
		_services.TryAddTransient<IWdCacheService, WdCacheService>();
		_services.TryAddTransient<WdEventsService>();

		_services.TryAddSingleton(sp =>
		{
			var config = sp.GetService<IConfiguration>();
			return config is null
				? ApiConfigurationService.FromHardCoded()
				: ApiConfigurationService.FromConfiguration(config);
		});

	}
}
