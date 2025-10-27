using Microsoft.AspNetCore.OutputCaching;
using System.Threading;
using System.Threading.Tasks;

public class CacheCleaner : ICacheCleaner
{
    private readonly IOutputCacheStore _outputCacheStore;

    public CacheCleaner(IOutputCacheStore outputCacheStore)
    {
        _outputCacheStore = outputCacheStore;
    }

    public async Task CleanCacheByTagAsync(string cacheTag, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(cacheTag)) return;
        await _outputCacheStore.EvictByTagAsync(cacheTag, cancellationToken);
    }
}