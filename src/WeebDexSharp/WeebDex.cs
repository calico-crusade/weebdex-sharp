namespace WeebDexSharp;

/// <summary>
/// Represents an instance of the WeebDex API.
/// </summary>
public interface IWeebDex
{
	/// <inheritdoc cref="IWdApiAuthorService" />
	IWdApiAuthorService Authors { get; }

	/// <inheritdoc cref="IWdApiChapterService" />
	IWdApiChapterService Chapters { get; }

	/// <inheritdoc cref="IWdApiMangaService" />
	IWdApiMangaService Manga { get; }

	/// <inheritdoc cref="IWdApiStatisticsService" />
	IWdApiStatisticsService Statistics { get; }

	/// <inheritdoc cref="IWdApiApiClientService" />
	IWdApiApiClientService ApiClients { get; }

	/// <inheritdoc cref="IWdApiCoverService" />
	IWdApiCoverService Covers { get; }

	/// <inheritdoc cref="IWdApiGroupService" />
	IWdApiGroupService Groups { get; }
}

/// <inheritdoc cref="IWeebDex" />
public class WeebDex(
	IWdApiAuthorService _author,
	IWdApiChapterService _chapter,
	IWdApiMangaService _manga,
	IWdApiStatisticsService _stats,
	IWdApiApiClientService _apiClients,
	IWdApiCoverService _covers,
	IWdApiGroupService _groups) : IWeebDex
{
	/// <inheritdoc />
	public IWdApiAuthorService Authors { get; } = _author;

	/// <inheritdoc />
	public IWdApiChapterService Chapters { get; } = _chapter;

	/// <inheritdoc />
	public IWdApiMangaService Manga { get; } = _manga;

	/// <inheritdoc />
	public IWdApiStatisticsService Statistics { get; } = _stats;
	
	/// <inheritdoc />
	public IWdApiApiClientService ApiClients { get; } = _apiClients;

	/// <inheritdoc />
	public IWdApiCoverService Covers { get; } = _covers;

	/// <inheritdoc />
	public IWdApiGroupService Groups { get; } = _groups;

	/// <summary>
	/// Creates an isolated instance of the WeebDex API 
	/// </summary>
	/// <param name="config">The optional configuration action</param>
	/// <param name="services">The optional service collection to use</param>
	/// <returns>The instance of the WeebDex API</returns>
	public static IWeebDex Create(
		Action<IWeebDexBuilder>? config = null,
		IServiceCollection? services = null)
	{
		return (services ?? new ServiceCollection())
			.AddWeebDex(config)
			.BuildServiceProvider()
			.GetRequiredService<IWeebDex>();
	}
}
