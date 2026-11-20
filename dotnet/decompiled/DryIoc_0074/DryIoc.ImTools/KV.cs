using System;
using System.Text;

namespace DryIoc.ImTools;

public class KV<K, V> : IPrintable
{
	public readonly K Key;

	public readonly V Value;

	public KV(K key, V value)
	{
		Key = key;
		Value = value;
	}

	public StringBuilder Print(StringBuilder s, Func<StringBuilder, object, StringBuilder> printer)
	{
		return s.Append("(").To((StringBuilder b) => (Key != null) ? printer(b, Key) : b).Append(", ")
			.To((StringBuilder b) => (Value != null) ? printer(b, Value) : b)
			.Append(')');
	}

	public override string ToString()
	{
		return Print(new StringBuilder(), (StringBuilder s, object x) => s.Append(x)).ToString();
	}

	public override bool Equals(object obj)
	{
		if (obj is KV<K, V> kV && ((object)kV.Key == (object)Key || object.Equals(kV.Key, Key)))
		{
			if ((object)kV.Value != (object)Value)
			{
				return object.Equals(kV.Value, Value);
			}
			return true;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return Hasher.Combine(Key, Value);
	}
}
public static class KV
{
	public static KV<K, V> Of<K, V>(K key, V value)
	{
		return new KV<K, V>(key, value);
	}

	public static KV<K, V> WithValue<K, V>(this KV<K, V> kv, V value)
	{
		return new KV<K, V>(kv.Key, value);
	}
}
