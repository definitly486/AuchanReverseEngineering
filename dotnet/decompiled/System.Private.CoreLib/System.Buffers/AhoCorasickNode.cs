using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace System.Buffers;

internal struct AhoCorasickNode
{
	public int SuffixLink;

	public int MatchLength;

	private int _firstChildChar;

	private int _firstChildIndex;

	private object _children;

	private static object EmptyChildrenSentinel => Array.Empty<int>();

	public AhoCorasickNode()
	{
		SuffixLink = 0;
		MatchLength = 0;
		_firstChildIndex = 0;
		_firstChildChar = -1;
		_children = EmptyChildrenSentinel;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool TryGetChild(char c, out int index)
	{
		if (_firstChildChar == c)
		{
			index = _firstChildIndex;
			return true;
		}
		object children = _children;
		if (children.GetType() == typeof(int[]))
		{
			int[] array = (int[])children;
			if ((uint)c < (uint)array.Length)
			{
				index = array[(uint)c];
				if (index >= 0)
				{
					return true;
				}
			}
			index = 0;
			return false;
		}
		return Unsafe.As<Dictionary<char, int>>(children).TryGetValue(c, out index);
	}

	public void AddChild(char c, int index)
	{
		if (_firstChildChar < 0)
		{
			_firstChildChar = c;
			_firstChildIndex = index;
			return;
		}
		if (_children == EmptyChildrenSentinel)
		{
			_children = new Dictionary<char, int>();
		}
		((Dictionary<char, int>)_children).Add(c, index);
	}

	public readonly void AddChildrenToQueue(Queue<(char Char, int Index)> queue)
	{
		if (_firstChildChar < 0)
		{
			return;
		}
		queue.Enqueue(((char)_firstChildChar, _firstChildIndex));
		if (!(_children is Dictionary<char, int> dictionary))
		{
			return;
		}
		foreach (var (item, item2) in dictionary)
		{
			queue.Enqueue((item, item2));
		}
	}

	public void OptimizeChildren()
	{
		if (!(_children is Dictionary<char, int> dictionary))
		{
			return;
		}
		dictionary.Add((char)_firstChildChar, _firstChildIndex);
		float num = -2f;
		foreach (KeyValuePair<char, int> item in dictionary)
		{
			item.Deconstruct(out var key, out var value);
			char c = key;
			int firstChildIndex = value;
			float num2 = (char.IsAscii(c) ? CharacterFrequencyHelper.AsciiFrequency[c] : (-1f));
			if (num2 > num)
			{
				num = num2;
				_firstChildChar = c;
				_firstChildIndex = firstChildIndex;
			}
		}
		dictionary.Remove((char)_firstChildChar);
		if (TryCreateJumpTable(dictionary, out var table))
		{
			_children = table;
		}
		static int DictionaryMemoryFootprintBytesEstimate(int childCount)
		{
			if (childCount < 8)
			{
				if (childCount < 4)
				{
					return 192;
				}
				return 272;
			}
			if (childCount < 12)
			{
				return 352;
			}
			return childCount * 25;
		}
		static int TableMemoryFootprintBytesEstimate(int maxValue)
		{
			return 32 + maxValue * 4;
		}
		static bool TryCreateJumpTable(Dictionary<char, int> children, [NotNullWhen(true)] out int[] reference)
		{
			int num3 = -1;
			char key2;
			int value2;
			foreach (KeyValuePair<char, int> child in children)
			{
				child.Deconstruct(out key2, out value2);
				char val = key2;
				num3 = Math.Max(num3, val);
			}
			int num4 = TableMemoryFootprintBytesEstimate(num3);
			int num5 = DictionaryMemoryFootprintBytesEstimate(children.Count);
			if (num4 > num5 * 2)
			{
				reference = null;
				return false;
			}
			reference = new int[num3 + 1];
			Array.Fill(reference, -1);
			foreach (KeyValuePair<char, int> child2 in children)
			{
				child2.Deconstruct(out key2, out value2);
				char c2 = key2;
				int num6 = value2;
				reference[(uint)c2] = num6;
			}
			return true;
		}
	}
}
