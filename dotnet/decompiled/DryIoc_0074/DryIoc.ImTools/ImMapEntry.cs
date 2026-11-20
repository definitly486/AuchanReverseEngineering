namespace DryIoc.ImTools;

public class ImMapEntry<V> : ImMap<V>
{
	public readonly int Hash;

	public V Value;

	public int Key => Hash;

	public ImMapEntry(int hash)
	{
		Hash = hash;
	}

	public ImMapEntry(int hash, V value)
	{
		Hash = hash;
		Value = value;
	}

	public override string ToString()
	{
		string[] obj = new string[5]
		{
			"{H:",
			Hash.ToString(),
			",V:",
			null,
			null
		};
		V value = Value;
		obj[3] = value?.ToString();
		obj[4] = "}";
		return string.Concat(obj);
	}

	public sealed override int Count()
	{
		return 1;
	}

	internal sealed override ImMapEntry<V> GetMaxHashEntryOrDefault()
	{
		return this;
	}

	internal sealed override ImMapEntry<V> GetMinHashEntryOrDefault()
	{
		return this;
	}

	internal sealed override ImMapEntry<V> GetEntryOrNull(int hash)
	{
		if (hash != Hash)
		{
			return null;
		}
		return this;
	}

	internal sealed override ImMap<V> AddOrGetEntry(int hash, ImMapEntry<V> entry)
	{
		if (hash <= Hash)
		{
			if (hash >= Hash)
			{
				return this;
			}
			return new Leaf2(entry, this);
		}
		return new Leaf2(this, entry);
	}

	internal sealed override ImMap<V> ReplaceEntry(int hash, ImMapEntry<V> oldEntry, ImMapEntry<V> newEntry)
	{
		return newEntry;
	}

	internal sealed override ImMap<V> RemoveEntry(ImMapEntry<V> removedEntry)
	{
		return ImMap<V>.Empty;
	}
}
