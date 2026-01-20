using System.Reflection;

namespace WeebDexSharp.Cli.Verbs;

[Verb("test", HelpText = "Run various tests.")]
public class TestOptions
{
	[Value(0, MetaName = "methods", HelpText = "The methods to run (leave empty to display a list of methods)")]
	public IEnumerable<string> Methods { get; set; } = [];
}

public class TestVerb(
	IWeebDex _api,
	IWdJsonService _json,
	ILogger<TestVerb> logger) : BooleanVerb<TestOptions>(logger)
{
	public async Task<bool> Authors(CancellationToken token)
	{
		var authors = await _api.Authors.List(token: token);
		_logger.LogInformation("Authors: {Data}", _json.Pretty(authors));

		var author = await _api.Authors.Get("uy8g7c4oh1", token);
		_logger.LogInformation("Author: {Data}", _json.Pretty(author));

		return true;
	}

	public async Task<bool> Chapters(CancellationToken token)
	{
		var filter = new WdChapterFilter
		{
			Authors = ["dzzri33r3v"],
		};
		var chapters = await _api.Chapters.Search(filter, token);
		_logger.LogInformation("Chapters: {Data}", _json.Pretty(chapters));
		var chapter = await _api.Chapters.Get("9v6c0zerlu", token);
		_logger.LogInformation("Chapter: {Data}", _json.Pretty(chapter));
		return true;
	}

	public async Task<bool> Manga(CancellationToken token)
	{
		const string ID = "2mkslp3v5e";
		var manga = await _api.Manga.Get(ID, token);
		_logger.LogInformation("Manga: {Data}", _json.Pretty(manga));
		var recommendations = await _api.Manga.Recommendations(ID, token);
		_logger.LogInformation("Recommendations: {Data}", _json.Pretty(recommendations));
		var aggregate = await _api.Manga.Aggregate(ID, token: token);
		_logger.LogInformation("Aggregate: {Data}", _json.Pretty(aggregate));
		var filter = new WdMangaFilter
		{
			Title = "Nana Aino's Plan: The Gals in My Class Treat Me Like Air"
		};
		var mangaList = await _api.Manga.Search(filter, token);
		_logger.LogInformation("Manga List: {Data}", _json.Pretty(mangaList));
		return true;
	}

	public async Task<bool> Stats(CancellationToken token)
	{
		var chapter = await _api.Statistics.Chapter("l3nm5fbler");
		_logger.LogInformation("Chapter Stats: {Data}", _json.Pretty(chapter));

		var manga = await _api.Statistics.Manga("2mkslp3v5e");
		_logger.LogInformation("Manga Stats: {Data}", _json.Pretty(manga));

		var group = await _api.Statistics.Group("blebj9twem");
		_logger.LogInformation("Group Stats: {Data}", _json.Pretty(group));

		var user = await _api.Statistics.User("qlo3v9w4ek");
		_logger.LogInformation("User Stats: {Data}", _json.Pretty(user));
		return true;
	}

	#region Internal methods
	public IEnumerable<MethodInfo> Methods()
	{
		return GetType()
			.GetMethods()
			.Where(t => t.ReturnType == typeof(Task<bool>) && 
				t.GetParameters().Length == 1 && 
				t.GetParameters()[0].ParameterType == typeof(CancellationToken));
	}

	public void DisplayMethods()
	{
		_logger.LogInformation("Available methods:");
		foreach (var method in Methods())
		{
			_logger.LogInformation("\t- {Method}", method.Name);
		}
		_logger.LogInformation("Specify 'all' to run all methods.");
	}

	public override async Task<bool> Execute(TestOptions options, CancellationToken token)
	{
		if (!options.Methods.Any())
		{
			DisplayMethods();
			return true;
		}

		var all = options.Methods.Count() == 1 && options.Methods.First().Equals("all", StringComparison.OrdinalIgnoreCase);
		var methods = Methods().Where(m => all || options.Methods.Contains(m.Name, StringComparer.OrdinalIgnoreCase));
		var run = false;
		foreach (var method in methods)
		{
			run = true;
			_logger.LogInformation("Running method: {Method}", method.Name);
			try
			{
				var result = await (Task<bool>)method.Invoke(this, [ token ])!;
				_logger.LogInformation("Method {Method} completed with result: {Result}", method.Name, result);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error running method: {Method}", method.Name);
			}
		}

		if (run)
		{
			_logger.LogInformation("Completed running specified methods.");
			return true;
		}

		_logger.LogWarning("No matching methods found for the specified names.");
		return false;
	}
	#endregion
}
