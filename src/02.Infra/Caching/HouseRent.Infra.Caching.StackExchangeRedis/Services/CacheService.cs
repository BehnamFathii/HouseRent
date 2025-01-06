using HouseRent.Core.ApplicationServices.Contracts;
using HouseRent.Infra.Caching.StackExchangeRedis.Options;
using Microsoft.Extensions.Caching.Distributed;
using System.Buffers;
using System.Text.Json;

namespace HouseRent.Infra.Caching.StackExchangeRedis.Services;
public class CacheService : ICacheService
{
    private readonly IDistributedCache _cache;

    public CacheService(IDistributedCache cache)
    {
        _cache = cache;
    }
    public async Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken = default)
    {
        byte[]? bytes = await _cache.GetAsync(key, cancellationToken);
        return bytes is null ? default : Deserialize<T>(bytes);
    }

    public async Task RemoveAsync(string key, CancellationToken cancellationToken = default)
        => await _cache.RemoveAsync(key);

    public Task SetAsync<T>(string key, T value, TimeSpan? expiration = null, CancellationToken cancellationToken = default)
    {
        var bytes = Serialize<T>(value);
        return _cache.SetAsync(key, bytes, CacheOptions.Create(expiration), cancellationToken);
    }

    private byte[] Serialize<T>(T value)
    {
        var buffer = new ArrayBufferWriter<byte>();

        using var writer = new Utf8JsonWriter(buffer);

        JsonSerializer.Serialize(writer, value);

        return buffer.WrittenSpan.ToArray();
    }

    private T Deserialize<T>(byte[] bytes)
        => JsonSerializer.Deserialize<T>(bytes)!;
}
