using System.Diagnostics;

namespace System.Collections.Generic;

internal sealed class IDictionaryDebugView<TKey, TValue>
{
	private readonly IDictionary<TKey, TValue> _dict;

	[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
	public System.Collections.Generic.DebugViewDictionaryItem<TKey, TValue>[] Items
	{
		get
		{
			KeyValuePair<TKey, TValue>[] array = new KeyValuePair<TKey, TValue>[_dict.Count];
			_dict.CopyTo(array, 0);
			System.Collections.Generic.DebugViewDictionaryItem<TKey, TValue>[] array2 = new System.Collections.Generic.DebugViewDictionaryItem<TKey, TValue>[array.Length];
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i] = new System.Collections.Generic.DebugViewDictionaryItem<TKey, TValue>(array[i]);
			}
			return array2;
		}
	}

	public IDictionaryDebugView(IDictionary<TKey, TValue> dictionary)
	{
		_dict = dictionary ?? throw new ArgumentNullException("dictionary");
	}
}
