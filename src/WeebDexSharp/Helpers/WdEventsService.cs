namespace WeebDexSharp.Helpers;

internal class WdEventsService(
	IEnumerable<IWdEventService> _events)
{
	public void RunHandlers(Action<IWdEventService> action)
	{
		foreach (var handler in _events)
			action(handler);
	}

	public void OnRateLimitDataReceived(string url, RateLimit limits)
	{
		RunHandlers(t => t.OnRateLimitDataReceived(url, limits));
	}

	public void OnRateLimitExceeded(string url, RateLimit limits)
	{
		RunHandlers(t => t.OnRateLimitExceeded(url, limits));
	}

	public void OnRequestError(string url, Exception error)
	{
		RunHandlers(t => t.OnRequestError(url, error));
	}

	public void OnRequestFinished(string url, Exception? error)
	{
		RunHandlers(t => t.OnRequestFinished(url, error));
	}

	public void OnRequestStarting(string url)
	{
		RunHandlers(t => t.OnRequestStarting(url));
	}

	public void OnResponseParsed(string url, HttpResponseMessage response, object? data)
	{
		RunHandlers(t => t.OnResponseParsed(url, response, data));
	}

	public void OnResponseReceived(string url, HttpResponseMessage response, HttpRequestMessage request)
	{
		RunHandlers(t => t.OnResponseReceived(url, response, request));
	}

	public void OnResponse(WeebDexResponse response)
	{
		RunHandlers(t => t.OnResponse(response));
	}
}
