namespace WeebDexSharp.Helpers;

/// <summary>
/// Exposes the underlying caching mechanism for Cardboard HTTP tailed to WeebDex
/// </summary>
public interface IWdCacheService : ICacheService { }

internal class WdCacheService(IWdJsonService json) : DiskCacheService(json), IWdCacheService { }
