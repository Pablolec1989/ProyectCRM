using System.Threading;
using System.Threading.Tasks;

public interface ICacheCleaner
{
    Task CleanCacheByTagAsync(string cacheTag, CancellationToken cancellationToken = default);
}