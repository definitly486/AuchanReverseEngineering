using System.Collections.Generic;

namespace NanoXLSX.LowLevel;

public class SortedMap
{
	private int count;

	private readonly List<string> keyEntries;

	private readonly List<string> valueEntries;

	private readonly Dictionary<string, int> index;

	public int Count => count;

	public List<string> Keys => keyEntries;

	public SortedMap()
	{
		keyEntries = new List<string>();
		valueEntries = new List<string>();
		index = new Dictionary<string, int>();
		count = 0;
	}

	public string Add(string key, string value)
	{
		if (index.ContainsKey(key))
		{
			return valueEntries[index[key]];
		}
		index.Add(key, count);
		count++;
		keyEntries.Add(key);
		valueEntries.Add(value);
		return value;
	}
}
