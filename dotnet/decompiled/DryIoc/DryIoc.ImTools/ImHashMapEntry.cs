namespace DryIoc.ImTools;

public class ImHashMapEntry<K, V> : ImHashMap<K, V>.Entry
{
	public readonly K Key;

	public V Value;

	public ImHashMapEntry(int hash, K key)
		: base(hash)
	{
		Key = key;
	}

	public ImHashMapEntry(int hash, K key, V value)
		: base(hash)
	{
		Key = key;
		Value = value;
	}

	public sealed override int Count()
	{
		return 1;
	}

	public sealed override ImHashMapEntry<K, V> GetEntryOrNull(int hash, K key)
	{
		if (Hash != hash || !Key.Equals(key))
		{
			return null;
		}
		return this;
	}

	public sealed override Entry Update(ImHashMapEntry<K, V> newEntry)
	{
		if (!Key.Equals(newEntry.Key))
		{
			return this.WithConflicting(newEntry);
		}
		return newEntry;
	}

	public sealed override Entry UpdateOrKeep<S>(S state, ImHashMapEntry<K, V> newEntry, UpdaterOrKeeper<S> updateOrKeep)
	{
		if (!Key.Equals(newEntry.Key))
		{
			return this.WithConflicting(newEntry);
		}
		if (updateOrKeep(state, this, newEntry) == this)
		{
			return this;
		}
		return newEntry;
	}

	public override string ToString()
	{
		string[] obj = new string[7]
		{
			"{H: ",
			Hash.ToString(),
			", K: ",
			Key?.ToString(),
			", V: ",
			null,
			null
		};
		V value = Value;
		obj[5] = value?.ToString();
		obj[6] = "}";
		return string.Concat(obj);
	}
}
