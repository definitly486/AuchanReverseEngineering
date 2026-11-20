using System.Text;

namespace DryIoc.ImTools;

internal sealed class HashConflictingEntry<K, V> : ImHashMap<K, V>.Entry
{
	public ImHashMapEntry<K, V>[] Conflicts;

	internal HashConflictingEntry(int hash, params ImHashMapEntry<K, V>[] conflicts)
		: base(hash)
	{
		Conflicts = conflicts;
	}

	public override int Count()
	{
		return Conflicts.Length;
	}

	public override ImHashMapEntry<K, V> GetEntryOrNull(int hash, K key)
	{
		ImHashMapEntry<K, V>[] conflicts = Conflicts;
		int num = conflicts.Length - 1;
		while (num != -1 && !key.Equals(conflicts[num].Key))
		{
			num--;
		}
		if (num == -1)
		{
			return null;
		}
		return conflicts[num];
	}

	public override Entry Update(ImHashMapEntry<K, V> newEntry)
	{
		K key = newEntry.Key;
		ImHashMapEntry<K, V>[] conflicts = Conflicts;
		int num = conflicts.Length - 1;
		while (num != -1 && !key.Equals(conflicts[num].Key))
		{
			num--;
		}
		return new HashConflictingEntry<K, V>(Hash, conflicts.AppendOrUpdate(newEntry, num));
	}

	public override Entry UpdateOrKeep<S>(S state, ImHashMapEntry<K, V> newEntry, UpdaterOrKeeper<S> updateOrKeep)
	{
		K key = newEntry.Key;
		ImHashMapEntry<K, V>[] conflicts = Conflicts;
		int num = conflicts.Length - 1;
		while (num != -1 && !key.Equals(conflicts[num].Key))
		{
			num--;
		}
		if (num == -1)
		{
			return new HashConflictingEntry<K, V>(Hash, conflicts.AppendToNonEmpty(newEntry));
		}
		ImHashMapEntry<K, V> imHashMapEntry = conflicts[num];
		if (updateOrKeep(state, imHashMapEntry, newEntry) != imHashMapEntry)
		{
			return new HashConflictingEntry<K, V>(Hash, conflicts.UpdateNonEmpty(newEntry, num));
		}
		return this;
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder("HashConflictingEntry: [");
		ImHashMapEntry<K, V>[] conflicts = Conflicts;
		foreach (ImHashMapEntry<K, V> imHashMapEntry in conflicts)
		{
			stringBuilder.Append(imHashMapEntry.ToString()).Append(", ");
		}
		return stringBuilder.Append("]").ToString();
	}
}
