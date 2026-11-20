using System;
using System.Threading.Tasks;
using Auchan.Common.Extensions;
using Microsoft.Maui.Storage;

namespace Auchan.Common.Cache;

public class UserPersistence : IUserPersistence
{
	public const string USER_PREFERENCES_SHARED_KEY = "USER_PREFERENCES_SHARED_KEY";

	private readonly Lazy<IPersistence> _persistence;

	public UserPersistence(Lazy<IPersistence> persistence)
	{
		_persistence = persistence;
	}

	public Task Save<T>(string key, T obj)
	{
		PreferencesEx.Set(key, obj);
		return Task.CompletedTask;
	}

	public Task Save<T>(string key, T obj, TimeSpan lifeTime)
	{
		PreferencesEx.Set(key, obj, lifeTime);
		return Task.CompletedTask;
	}

	public async Task<T?> TryGet<T>(string key) where T : class
	{
		T val = PreferencesEx.Get<T>(key);
		if (val != null)
		{
			return val;
		}
		try
		{
			T objTOld = await _persistence.Value.TryGet<T>(key);
			if (objTOld != null)
			{
				await Save(key, objTOld);
				await _persistence.Value.Remove(key);
				return objTOld;
			}
			return null;
		}
		catch (Exception)
		{
			return null;
		}
	}

	public async Task<T?> TryGetStruct<T>(string key) where T : struct
	{
		T? val = PreferencesEx.GetStruct<T>(key);
		if (val.HasValue)
		{
			return val.GetValueOrDefault();
		}
		try
		{
			val = await _persistence.Value.TryGetStruct<T>(key);
			if (val.HasValue)
			{
				T objTOld = val.GetValueOrDefault();
				await Save(key, objTOld);
				await _persistence.Value.Remove(key);
				return objTOld;
			}
			return null;
		}
		catch
		{
			return null;
		}
	}

	public Task Remove(string key)
	{
		Preferences.Remove(key);
		return Task.CompletedTask;
	}

	public Task Remove(params string[] keys)
	{
		keys.ForEach(Preferences.Remove);
		return Task.CompletedTask;
	}

	public Task RemoveAll()
	{
		Preferences.Clear("USER_PREFERENCES_SHARED_KEY");
		return Task.CompletedTask;
	}
}
