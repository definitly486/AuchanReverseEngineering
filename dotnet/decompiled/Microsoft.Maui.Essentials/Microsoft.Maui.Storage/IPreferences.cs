namespace Microsoft.Maui.Storage;

public interface IPreferences
{
	void Remove(string key, string? sharedName = null);

	void Clear(string? sharedName = null);

	void Set<T>(string key, T value, string? sharedName = null);

	T Get<T>(string key, T defaultValue, string? sharedName = null);
}
