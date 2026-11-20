using System;
using System.Threading.Tasks;
using Auchan.Common.Cache;
using Auchan.Common.PersonalCabinet.DomainModels;

namespace Auchan.Common.PersonalCabinet.Interactors;

public class AuthorizationCacheInteractor
{
	private readonly ICache _cache;

	private readonly TimeSpan _cacheLifeTime;

	public AuthorizationCacheInteractor(ICache cache)
	{
		_cache = cache;
		_cacheLifeTime = TimeSpan.FromDays(7);
	}

	public async Task<string> GetPhone()
	{
		return (await _cache.TryGet<string>("CachedPhone")) ?? string.Empty;
	}

	public async Task<string> GetEmail()
	{
		return (await _cache.TryGet<string>("CachedEmail")) ?? string.Empty;
	}

	public Task<SignUpCachedData?> GetSignUpCache()
	{
		return _cache.TryGet<SignUpCachedData>("CachedSignUpData");
	}

	public Task SavePhone(string phone)
	{
		return _cache.Save("CachedPhone", phone, _cacheLifeTime);
	}

	public Task SaveEmail(string email)
	{
		return _cache.Save("CachedEmail", email, _cacheLifeTime);
	}

	public Task SaveSignUpCache(SignUpCachedData data)
	{
		return _cache.Save("CachedSignUpData", data, _cacheLifeTime);
	}

	public Task ClearPhone()
	{
		return _cache.Save("CachedPhone", string.Empty, _cacheLifeTime);
	}
}
