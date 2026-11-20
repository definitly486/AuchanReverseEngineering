using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;

namespace System.Linq;

public static class Enumerable
{
	private abstract class AppendPrependIterator<TSource> : Iterator<TSource>
	{
		protected readonly IEnumerable<TSource> _source;

		protected IEnumerator<TSource> _enumerator;

		protected AppendPrependIterator(IEnumerable<TSource> source)
		{
			_source = source;
		}

		protected void GetSourceEnumerator()
		{
			_enumerator = _source.GetEnumerator();
		}

		public abstract AppendPrependIterator<TSource> Prepend(TSource item);

		protected bool LoadFromEnumerator()
		{
			if (_enumerator.MoveNext())
			{
				_current = _enumerator.Current;
				return true;
			}
			Dispose();
			return false;
		}

		public override void Dispose()
		{
			if (_enumerator != null)
			{
				_enumerator.Dispose();
				_enumerator = null;
			}
			base.Dispose();
		}
	}

	private sealed class AppendPrepend1Iterator<TSource> : AppendPrependIterator<TSource>
	{
		private readonly TSource _item;

		private readonly bool _appending;

		public AppendPrepend1Iterator(IEnumerable<TSource> source, TSource item, bool appending)
			: base(source)
		{
			_item = item;
			_appending = appending;
		}

		private protected override Iterator<TSource> Clone()
		{
			return new AppendPrepend1Iterator<TSource>(_source, _item, _appending);
		}

		public override bool MoveNext()
		{
			switch (_state)
			{
			case 1:
				_state = 2;
				if (!_appending)
				{
					_current = _item;
					return true;
				}
				goto case 2;
			case 2:
				GetSourceEnumerator();
				_state = 3;
				goto case 3;
			case 3:
				if (LoadFromEnumerator())
				{
					return true;
				}
				if (_appending)
				{
					_current = _item;
					return true;
				}
				break;
			}
			Dispose();
			return false;
		}

		public override AppendPrependIterator<TSource> Prepend(TSource item)
		{
			if (_appending)
			{
				return new AppendPrependN<TSource>(_source, new SingleLinkedNode<TSource>(item), new SingleLinkedNode<TSource>(_item), 1, 1);
			}
			return new AppendPrependN<TSource>(_source, new SingleLinkedNode<TSource>(_item).Add(item), null, 2, 0);
		}

		private TSource[] LazyToArray()
		{
			TSource[] array;
			if (_source is ICollection<TSource> collection)
			{
				array = new TSource[collection.Count + 1];
				if (_appending)
				{
					collection.CopyTo(array, 0);
					array[^1] = _item;
				}
				else
				{
					collection.CopyTo(array, 1);
					array[0] = _item;
				}
			}
			else
			{
				SegmentedArrayBuilder<TSource>.ScratchBuffer buffer = default(SegmentedArrayBuilder<TSource>.ScratchBuffer);
				SegmentedArrayBuilder<TSource> segmentedArrayBuilder = new SegmentedArrayBuilder<TSource>(global::_003CPrivateImplementationDetails_003E.InlineArrayAsSpan<SegmentedArrayBuilder<TSource>.ScratchBuffer, TSource>(ref buffer, 8));
				if (_appending)
				{
					segmentedArrayBuilder.AddNonICollectionRange(_source);
					segmentedArrayBuilder.Add(_item);
				}
				else
				{
					segmentedArrayBuilder.Add(_item);
					segmentedArrayBuilder.AddNonICollectionRange(_source);
				}
				array = segmentedArrayBuilder.ToArray();
				segmentedArrayBuilder.Dispose();
			}
			return array;
		}

		public override TSource[] ToArray()
		{
			int count = GetCount(onlyIfCheap: true);
			if (count == -1)
			{
				return LazyToArray();
			}
			TSource[] array = new TSource[count];
			int arrayIndex;
			if (_appending)
			{
				arrayIndex = 0;
			}
			else
			{
				array[0] = _item;
				arrayIndex = 1;
			}
			if (_source is ICollection<TSource> collection)
			{
				collection.CopyTo(array, arrayIndex);
			}
			else
			{
				foreach (TSource item in _source)
				{
					array[arrayIndex++] = item;
				}
			}
			if (_appending)
			{
				array[^1] = _item;
			}
			return array;
		}

		public override List<TSource> ToList()
		{
			int count = GetCount(onlyIfCheap: true);
			List<TSource> list;
			switch (count)
			{
			case 1:
				return new List<TSource>(1) { _item };
			default:
				list = new List<TSource>(count);
				break;
			case -1:
				list = new List<TSource>();
				break;
			}
			List<TSource> list2 = list;
			if (!_appending)
			{
				list2.Add(_item);
			}
			list2.AddRange(_source);
			if (_appending)
			{
				list2.Add(_item);
			}
			return list2;
		}

		public override int GetCount(bool onlyIfCheap)
		{
			if (_source is Iterator<TSource> iterator)
			{
				int count = iterator.GetCount(onlyIfCheap);
				if (count != -1)
				{
					return count + 1;
				}
				return -1;
			}
			if (onlyIfCheap && !(_source is ICollection<TSource>))
			{
				return -1;
			}
			return _source.Count() + 1;
		}

		public override TSource TryGetFirst(out bool found)
		{
			if (_appending)
			{
				TSource result = _source.TryGetFirst(out found);
				if (found)
				{
					return result;
				}
			}
			found = true;
			return _item;
		}

		public override TSource TryGetLast(out bool found)
		{
			if (!_appending)
			{
				TSource result = _source.TryGetLast(out found);
				if (found)
				{
					return result;
				}
			}
			found = true;
			return _item;
		}

		public override TSource TryGetElementAt(int index, out bool found)
		{
			if (!_appending)
			{
				if (index == 0)
				{
					found = true;
					return _item;
				}
				index--;
				return _source.TryGetElementAt(index, out found);
			}
			return base.TryGetElementAt(index, out found);
		}

		public override bool Contains(TSource value)
		{
			if (!EqualityComparer<TSource>.Default.Equals(_item, value))
			{
				return _source.Contains(value);
			}
			return true;
		}
	}

	private sealed class AppendPrependN<TSource> : AppendPrependIterator<TSource>
	{
		private readonly SingleLinkedNode<TSource> _prepended;

		private readonly SingleLinkedNode<TSource> _appended;

		private readonly int _prependCount;

		private readonly int _appendCount;

		private SingleLinkedNode<TSource> _node;

		public AppendPrependN(IEnumerable<TSource> source, SingleLinkedNode<TSource> prepended, SingleLinkedNode<TSource> appended, int prependCount, int appendCount)
			: base(source)
		{
			_prepended = prepended;
			_appended = appended;
			_prependCount = prependCount;
			_appendCount = appendCount;
		}

		private protected override Iterator<TSource> Clone()
		{
			return new AppendPrependN<TSource>(_source, _prepended, _appended, _prependCount, _appendCount);
		}

		public override bool MoveNext()
		{
			switch (_state)
			{
			case 1:
				_node = _prepended;
				_state = 2;
				goto case 2;
			case 2:
				if (_node != null)
				{
					_current = _node.Item;
					_node = _node.Linked;
					return true;
				}
				GetSourceEnumerator();
				_state = 3;
				goto case 3;
			case 3:
				if (LoadFromEnumerator())
				{
					return true;
				}
				if (_appended == null)
				{
					return false;
				}
				_enumerator = ((IEnumerable<TSource>)_appended.ToArray(_appendCount)).GetEnumerator();
				_state = 4;
				goto case 4;
			case 4:
				return LoadFromEnumerator();
			default:
				Dispose();
				return false;
			}
		}

		public override AppendPrependIterator<TSource> Prepend(TSource item)
		{
			SingleLinkedNode<TSource> prepended = ((_prepended != null) ? _prepended.Add(item) : new SingleLinkedNode<TSource>(item));
			return new AppendPrependN<TSource>(_source, prepended, _appended, _prependCount + 1, _appendCount);
		}

		private TSource[] LazyToArray()
		{
			if (_source is ICollection<TSource> collection)
			{
				TSource[] array = new TSource[checked(_prependCount + collection.Count + _appendCount)];
				_prepended?.Fill(array);
				collection.CopyTo(array, _prependCount);
				_appended?.FillReversed(array);
				return array;
			}
			SegmentedArrayBuilder<TSource>.ScratchBuffer buffer = default(SegmentedArrayBuilder<TSource>.ScratchBuffer);
			SegmentedArrayBuilder<TSource> segmentedArrayBuilder = new SegmentedArrayBuilder<TSource>(global::_003CPrivateImplementationDetails_003E.InlineArrayAsSpan<SegmentedArrayBuilder<TSource>.ScratchBuffer, TSource>(ref buffer, 8));
			for (SingleLinkedNode<TSource> singleLinkedNode = _prepended; singleLinkedNode != null; singleLinkedNode = singleLinkedNode.Linked)
			{
				segmentedArrayBuilder.Add(singleLinkedNode.Item);
			}
			segmentedArrayBuilder.AddNonICollectionRange(_source);
			TSource[] array2 = segmentedArrayBuilder.ToArray(_appendCount);
			segmentedArrayBuilder.Dispose();
			_appended?.FillReversed(array2);
			return array2;
		}

		public override TSource[] ToArray()
		{
			int count = GetCount(onlyIfCheap: true);
			if (count == -1)
			{
				return LazyToArray();
			}
			TSource[] array = new TSource[count];
			int num = 0;
			for (SingleLinkedNode<TSource> singleLinkedNode = _prepended; singleLinkedNode != null; singleLinkedNode = singleLinkedNode.Linked)
			{
				array[num] = singleLinkedNode.Item;
				num++;
			}
			if (_source is ICollection<TSource> collection)
			{
				collection.CopyTo(array, num);
			}
			else
			{
				foreach (TSource item in _source)
				{
					array[num] = item;
					num++;
				}
			}
			num = array.Length;
			for (SingleLinkedNode<TSource> singleLinkedNode2 = _appended; singleLinkedNode2 != null; singleLinkedNode2 = singleLinkedNode2.Linked)
			{
				num--;
				array[num] = singleLinkedNode2.Item;
			}
			return array;
		}

		public override List<TSource> ToList()
		{
			int count = GetCount(onlyIfCheap: true);
			List<TSource> list = ((count == -1) ? new List<TSource>() : new List<TSource>(count));
			_prepended?.Fill(SetCountAndGetSpan(list, _prependCount));
			list.AddRange(_source);
			_appended?.FillReversed(SetCountAndGetSpan(list, list.Count + _appendCount));
			return list;
		}

		public override int GetCount(bool onlyIfCheap)
		{
			if (_source is Iterator<TSource> iterator)
			{
				int count = iterator.GetCount(onlyIfCheap);
				if (count != -1)
				{
					return count + _appendCount + _prependCount;
				}
				return -1;
			}
			if (onlyIfCheap && !(_source is ICollection<TSource>))
			{
				return -1;
			}
			return _source.Count() + _appendCount + _prependCount;
		}

		public override bool Contains(TSource value)
		{
			global::_003C_003Ey__InlineArray2<SingleLinkedNode<TSource>> buffer = default(global::_003C_003Ey__InlineArray2<SingleLinkedNode<TSource>>);
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray2<SingleLinkedNode<TSource>>, SingleLinkedNode<TSource>>(ref buffer, 0) = _appended;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray2<SingleLinkedNode<TSource>>, SingleLinkedNode<TSource>>(ref buffer, 1) = _prepended;
			ReadOnlySpan<SingleLinkedNode<TSource>> readOnlySpan = global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<global::_003C_003Ey__InlineArray2<SingleLinkedNode<TSource>>, SingleLinkedNode<TSource>>(in buffer, 2);
			for (int i = 0; i < readOnlySpan.Length; i++)
			{
				for (SingleLinkedNode<TSource> singleLinkedNode = readOnlySpan[i]; singleLinkedNode != null; singleLinkedNode = singleLinkedNode.Linked)
				{
					if (EqualityComparer<TSource>.Default.Equals(singleLinkedNode.Item, value))
					{
						return true;
					}
				}
			}
			return _source.Contains(value);
		}
	}

	[DebuggerDisplay("Count = {Count}")]
	private sealed class CastICollectionIterator<TResult>(ICollection source) : Iterator<TResult>()
	{
		private readonly ICollection _source = source;

		private IEnumerator _enumerator;

		private protected override Iterator<TResult> Clone()
		{
			return new CastICollectionIterator<TResult>(_source);
		}

		public override bool MoveNext()
		{
			int state = _state;
			if (state != 1)
			{
				if (state != 2)
				{
					goto IL_0054;
				}
			}
			else
			{
				_enumerator = _source.GetEnumerator();
				_state = 2;
			}
			if (_enumerator.MoveNext())
			{
				_current = (TResult)_enumerator.Current;
				return true;
			}
			Dispose();
			goto IL_0054;
			IL_0054:
			return false;
		}

		public override void Dispose()
		{
			(_enumerator as IDisposable)?.Dispose();
			_enumerator = null;
			base.Dispose();
		}

		public override int GetCount(bool onlyIfCheap)
		{
			return _source.Count;
		}

		public override TResult[] ToArray()
		{
			TResult[] array = new TResult[_source.Count];
			int num = 0;
			foreach (TResult item in _source)
			{
				array[num++] = item;
			}
			return array;
		}

		public override List<TResult> ToList()
		{
			List<TResult> list = new List<TResult>(_source.Count);
			foreach (TResult item in _source)
			{
				list.Add(item);
			}
			return list;
		}

		public override TResult TryGetElementAt(int index, out bool found)
		{
			if (index >= 0)
			{
				{
					IEnumerator enumerator = _source.GetEnumerator();
					try
					{
						while (enumerator.MoveNext())
						{
							if (index == 0)
							{
								found = true;
								return (TResult)enumerator.Current;
							}
							index--;
						}
					}
					finally
					{
						IDisposable disposable = enumerator as IDisposable;
						if (disposable != null)
						{
							disposable.Dispose();
						}
					}
				}
			}
			found = false;
			return default(TResult);
		}

		public override TResult TryGetFirst(out bool found)
		{
			IEnumerator enumerator = _source.GetEnumerator();
			try
			{
				if (enumerator.MoveNext())
				{
					found = true;
					return (TResult)enumerator.Current;
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
			found = false;
			return default(TResult);
		}

		public override TResult TryGetLast(out bool found)
		{
			IEnumerator enumerator = _source.GetEnumerator();
			try
			{
				if (enumerator.MoveNext())
				{
					TResult result = (TResult)enumerator.Current;
					while (enumerator.MoveNext())
					{
						result = (TResult)enumerator.Current;
					}
					found = true;
					return result;
				}
				found = false;
				return default(TResult);
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
		}

		public override bool Contains(TResult value)
		{
			foreach (TResult item in _source)
			{
				if (EqualityComparer<TResult>.Default.Equals(item, value))
				{
					return true;
				}
			}
			return false;
		}
	}

	private sealed class Concat2Iterator<TSource> : ConcatIterator<TSource>
	{
		internal readonly IEnumerable<TSource> _first;

		internal readonly IEnumerable<TSource> _second;

		internal Concat2Iterator(IEnumerable<TSource> first, IEnumerable<TSource> second)
		{
			_first = first;
			_second = second;
		}

		private protected override Iterator<TSource> Clone()
		{
			return new Concat2Iterator<TSource>(_first, _second);
		}

		internal override ConcatIterator<TSource> Concat(IEnumerable<TSource> next)
		{
			bool hasOnlyCollections = next is ICollection<TSource> && _first is ICollection<TSource> && _second is ICollection<TSource>;
			return new ConcatNIterator<TSource>(this, next, 2, hasOnlyCollections);
		}

		internal override IEnumerable<TSource> GetEnumerable(int index)
		{
			return index switch
			{
				0 => _first, 
				1 => _second, 
				_ => null, 
			};
		}

		public override int GetCount(bool onlyIfCheap)
		{
			if (!_first.TryGetNonEnumeratedCount(out var count))
			{
				if (onlyIfCheap)
				{
					return -1;
				}
				count = _first.Count();
			}
			if (!_second.TryGetNonEnumeratedCount(out var count2))
			{
				if (onlyIfCheap)
				{
					return -1;
				}
				count2 = _second.Count();
			}
			return checked(count + count2);
		}

		public override TSource[] ToArray()
		{
			ICollection<TSource> collection = _first as ICollection<TSource>;
			ICollection<TSource> collection2 = _second as ICollection<TSource>;
			checked
			{
				if (collection != null && collection2 != null)
				{
					int count = collection.Count;
					TSource[] array = new TSource[count + collection2.Count];
					collection.CopyTo(array, 0);
					collection2.CopyTo(array, count);
					return array;
				}
				SegmentedArrayBuilder<TSource>.ScratchBuffer buffer = default(SegmentedArrayBuilder<TSource>.ScratchBuffer);
				SegmentedArrayBuilder<TSource> segmentedArrayBuilder = new SegmentedArrayBuilder<TSource>(global::_003CPrivateImplementationDetails_003E.InlineArrayAsSpan<SegmentedArrayBuilder<TSource>.ScratchBuffer, TSource>(ref buffer, 8));
				TSource[] array2;
				if (collection != null)
				{
					int count2 = collection.Count;
					segmentedArrayBuilder.AddNonICollectionRange(_second);
					array2 = new TSource[count2 + segmentedArrayBuilder.Count];
					collection.CopyTo(array2, 0);
					segmentedArrayBuilder.ToSpan(array2.AsSpan(count2));
				}
				else if (collection2 != null)
				{
					int count3 = collection2.Count;
					segmentedArrayBuilder.AddNonICollectionRange(_first);
					array2 = new TSource[segmentedArrayBuilder.Count + count3];
					segmentedArrayBuilder.ToSpan(array2);
					collection2.CopyTo(array2, unchecked(array2.Length - count3));
				}
				else
				{
					segmentedArrayBuilder.AddNonICollectionRange(_first);
					segmentedArrayBuilder.AddNonICollectionRange(_second);
					array2 = segmentedArrayBuilder.ToArray();
				}
				segmentedArrayBuilder.Dispose();
				return array2;
			}
		}

		public override TSource TryGetElementAt(int index, out bool found)
		{
			if (index >= 0)
			{
				global::_003C_003Ey__InlineArray2<IEnumerable<TSource>> buffer = default(global::_003C_003Ey__InlineArray2<IEnumerable<TSource>>);
				global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray2<IEnumerable<TSource>>, IEnumerable<TSource>>(ref buffer, 0) = _first;
				global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray2<IEnumerable<TSource>>, IEnumerable<TSource>>(ref buffer, 1) = _second;
				ReadOnlySpan<IEnumerable<TSource>> readOnlySpan = global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<global::_003C_003Ey__InlineArray2<IEnumerable<TSource>>, IEnumerable<TSource>>(in buffer, 2);
				for (int i = 0; i < readOnlySpan.Length; i++)
				{
					IEnumerable<TSource> enumerable = readOnlySpan[i];
					if (enumerable.TryGetNonEnumeratedCount(out var count))
					{
						if (index < count)
						{
							found = true;
							return enumerable.ElementAt(index);
						}
						index -= count;
						continue;
					}
					using IEnumerator<TSource> enumerator = enumerable.GetEnumerator();
					while (enumerator.MoveNext())
					{
						if (index == 0)
						{
							found = true;
							return enumerator.Current;
						}
						index--;
					}
				}
			}
			found = false;
			return default(TSource);
		}

		public override TSource TryGetFirst(out bool found)
		{
			TSource result = _first.TryGetFirst(out found);
			if (!found)
			{
				result = _second.TryGetFirst(out found);
			}
			return result;
		}

		public override TSource TryGetLast(out bool found)
		{
			TSource result = _second.TryGetLast(out found);
			if (!found)
			{
				result = _first.TryGetLast(out found);
			}
			return result;
		}

		public override bool Contains(TSource value)
		{
			if (!_first.Contains(value))
			{
				return _second.Contains(value);
			}
			return true;
		}
	}

	private sealed class ConcatNIterator<TSource> : ConcatIterator<TSource>
	{
		private readonly ConcatIterator<TSource> _tail;

		private readonly IEnumerable<TSource> _head;

		private readonly int _headIndex;

		private readonly bool _hasOnlyCollections;

		private ConcatNIterator<TSource> PreviousN => _tail as ConcatNIterator<TSource>;

		internal ConcatNIterator(ConcatIterator<TSource> tail, IEnumerable<TSource> head, int headIndex, bool hasOnlyCollections)
		{
			_tail = tail;
			_head = head;
			_headIndex = headIndex;
			_hasOnlyCollections = hasOnlyCollections;
		}

		private protected override Iterator<TSource> Clone()
		{
			return new ConcatNIterator<TSource>(_tail, _head, _headIndex, _hasOnlyCollections);
		}

		internal override ConcatIterator<TSource> Concat(IEnumerable<TSource> next)
		{
			if (_headIndex == 2147483645)
			{
				return new Concat2Iterator<TSource>(this, next);
			}
			bool hasOnlyCollections = _hasOnlyCollections && next is ICollection<TSource>;
			return new ConcatNIterator<TSource>(this, next, _headIndex + 1, hasOnlyCollections);
		}

		internal override IEnumerable<TSource> GetEnumerable(int index)
		{
			if (index > _headIndex)
			{
				return null;
			}
			ConcatNIterator<TSource> concatNIterator = this;
			ConcatNIterator<TSource> concatNIterator2;
			do
			{
				concatNIterator2 = concatNIterator;
				if (index == concatNIterator2._headIndex)
				{
					return concatNIterator2._head;
				}
			}
			while ((concatNIterator = concatNIterator2.PreviousN) != null);
			return concatNIterator2._tail.GetEnumerable(index);
		}

		public override int GetCount(bool onlyIfCheap)
		{
			if (onlyIfCheap && !_hasOnlyCollections)
			{
				return -1;
			}
			int num = 0;
			ConcatNIterator<TSource> concatNIterator = this;
			checked
			{
				ConcatNIterator<TSource> concatNIterator2;
				do
				{
					concatNIterator2 = concatNIterator;
					IEnumerable<TSource> head = concatNIterator2._head;
					int num2 = (head as ICollection<TSource>)?.Count ?? head.Count();
					num += num2;
				}
				while ((concatNIterator = concatNIterator2.PreviousN) != null);
				return num + concatNIterator2._tail.GetCount(onlyIfCheap);
			}
		}

		public override TSource[] ToArray()
		{
			if (!_hasOnlyCollections)
			{
				return LazyToArray();
			}
			return PreallocatingToArray();
		}

		private TSource[] LazyToArray()
		{
			SegmentedArrayBuilder<TSource>.ScratchBuffer buffer = default(SegmentedArrayBuilder<TSource>.ScratchBuffer);
			SegmentedArrayBuilder<TSource> segmentedArrayBuilder = new SegmentedArrayBuilder<TSource>(global::_003CPrivateImplementationDetails_003E.InlineArrayAsSpan<SegmentedArrayBuilder<TSource>.ScratchBuffer, TSource>(ref buffer, 8));
			int num = 0;
			while (true)
			{
				IEnumerable<TSource> enumerable = GetEnumerable(num);
				if (enumerable == null)
				{
					break;
				}
				segmentedArrayBuilder.AddRange(enumerable);
				num++;
			}
			TSource[] result = segmentedArrayBuilder.ToArray();
			segmentedArrayBuilder.Dispose();
			return result;
		}

		private TSource[] PreallocatingToArray()
		{
			int count = GetCount(onlyIfCheap: true);
			if (count == 0)
			{
				return Array.Empty<TSource>();
			}
			TSource[] array = new TSource[count];
			int num = array.Length;
			ConcatNIterator<TSource> concatNIterator = this;
			checked
			{
				ConcatNIterator<TSource> concatNIterator2;
				do
				{
					concatNIterator2 = concatNIterator;
					ICollection<TSource> collection = (ICollection<TSource>)concatNIterator2._head;
					int count2 = collection.Count;
					if (count2 > 0)
					{
						num -= count2;
						collection.CopyTo(array, num);
					}
				}
				while ((concatNIterator = concatNIterator2.PreviousN) != null);
				Concat2Iterator<TSource> concat2Iterator = (Concat2Iterator<TSource>)concatNIterator2._tail;
				ICollection<TSource> collection2 = (ICollection<TSource>)concat2Iterator._second;
				int count3 = collection2.Count;
				if (count3 > 0)
				{
					collection2.CopyTo(array, num - count3);
				}
				if (num > count3)
				{
					((ICollection<TSource>)concat2Iterator._first).CopyTo(array, 0);
				}
				return array;
			}
		}

		public override TSource TryGetElementAt(int index, out bool found)
		{
			if (index >= 0)
			{
				int num = 0;
				IEnumerable<TSource> enumerable;
				while ((enumerable = GetEnumerable(num)) != null)
				{
					if (enumerable.TryGetNonEnumeratedCount(out var count))
					{
						if (index < count)
						{
							found = true;
							return enumerable.ElementAt(index);
						}
						index -= count;
					}
					else
					{
						using IEnumerator<TSource> enumerator = enumerable.GetEnumerator();
						while (enumerator.MoveNext())
						{
							if (index == 0)
							{
								found = true;
								return enumerator.Current;
							}
							index--;
						}
					}
					num++;
				}
			}
			found = false;
			return default(TSource);
		}

		public override TSource TryGetFirst(out bool found)
		{
			int num = 0;
			IEnumerable<TSource> enumerable;
			while ((enumerable = GetEnumerable(num)) != null)
			{
				TSource result = enumerable.TryGetFirst(out found);
				if (found)
				{
					return result;
				}
				num++;
			}
			found = false;
			return default(TSource);
		}

		public override TSource TryGetLast(out bool found)
		{
			ConcatNIterator<TSource> concatNIterator = this;
			ConcatNIterator<TSource> concatNIterator2;
			do
			{
				concatNIterator2 = concatNIterator;
				TSource result = concatNIterator2._head.TryGetLast(out found);
				if (found)
				{
					return result;
				}
			}
			while ((concatNIterator = concatNIterator2.PreviousN) != null);
			return concatNIterator2._tail.TryGetLast(out found);
		}

		public override bool Contains(TSource value)
		{
			ConcatNIterator<TSource> concatNIterator = this;
			ConcatNIterator<TSource> concatNIterator2;
			do
			{
				concatNIterator2 = concatNIterator;
				if (concatNIterator2._head.Contains(value))
				{
					return true;
				}
			}
			while ((concatNIterator = concatNIterator2.PreviousN) != null);
			return concatNIterator2._tail.Contains(value);
		}
	}

	private abstract class ConcatIterator<TSource> : Iterator<TSource>
	{
		private IEnumerator<TSource> _enumerator;

		public override void Dispose()
		{
			if (_enumerator != null)
			{
				_enumerator.Dispose();
				_enumerator = null;
			}
			base.Dispose();
		}

		internal abstract IEnumerable<TSource> GetEnumerable(int index);

		internal abstract ConcatIterator<TSource> Concat(IEnumerable<TSource> next);

		public override bool MoveNext()
		{
			if (_state == 1)
			{
				_enumerator = GetEnumerable(0).GetEnumerator();
				_state = 2;
			}
			if (_state > 1)
			{
				while (true)
				{
					if (_enumerator.MoveNext())
					{
						_current = _enumerator.Current;
						return true;
					}
					IEnumerable<TSource> enumerable = GetEnumerable(_state++ - 1);
					if (enumerable == null)
					{
						break;
					}
					_enumerator.Dispose();
					_enumerator = enumerable.GetEnumerator();
				}
				Dispose();
			}
			return false;
		}

		public override List<TSource> ToList()
		{
			int count = GetCount(onlyIfCheap: true);
			List<TSource> list = ((count != -1) ? new List<TSource>(count) : new List<TSource>());
			int num = 0;
			while (true)
			{
				IEnumerable<TSource> enumerable = GetEnumerable(num);
				if (enumerable == null)
				{
					break;
				}
				list.AddRange(enumerable);
				num++;
			}
			return list;
		}
	}

	private sealed class DefaultIfEmptyIterator<TSource> : Iterator<TSource>
	{
		private readonly IEnumerable<TSource> _source;

		private readonly TSource _default;

		private IEnumerator<TSource> _enumerator;

		public DefaultIfEmptyIterator(IEnumerable<TSource> source, TSource defaultValue)
		{
			_source = source;
			_default = defaultValue;
		}

		private protected override Iterator<TSource> Clone()
		{
			return new DefaultIfEmptyIterator<TSource>(_source, _default);
		}

		public override bool MoveNext()
		{
			switch (_state)
			{
			case 1:
				_enumerator = _source.GetEnumerator();
				if (_enumerator.MoveNext())
				{
					_current = _enumerator.Current;
					_state = 2;
				}
				else
				{
					_current = _default;
					_state = -1;
				}
				return true;
			case 2:
				if (_enumerator.MoveNext())
				{
					_current = _enumerator.Current;
					return true;
				}
				break;
			}
			Dispose();
			return false;
		}

		public override void Dispose()
		{
			if (_enumerator != null)
			{
				_enumerator.Dispose();
				_enumerator = null;
			}
			base.Dispose();
		}

		public override TSource[] ToArray()
		{
			TSource[] array = _source.ToArray();
			if (array.Length != 0)
			{
				return array;
			}
			return new TSource[1] { _default };
		}

		public override List<TSource> ToList()
		{
			List<TSource> list = _source.ToList();
			if (list.Count == 0)
			{
				list.Add(_default);
			}
			return list;
		}

		public override int GetCount(bool onlyIfCheap)
		{
			int num = ((onlyIfCheap && !(_source is ICollection<TSource>) && !(_source is ICollection)) ? ((_source is Iterator<TSource> iterator) ? iterator.GetCount(onlyIfCheap: true) : (-1)) : _source.Count());
			if (num != 0)
			{
				return num;
			}
			return 1;
		}

		public override TSource TryGetFirst(out bool found)
		{
			TSource result = _source.TryGetFirst(out found);
			if (found)
			{
				return result;
			}
			found = true;
			return _default;
		}

		public override TSource TryGetLast(out bool found)
		{
			TSource result = _source.TryGetLast(out found);
			if (found)
			{
				return result;
			}
			found = true;
			return _default;
		}

		public override TSource TryGetElementAt(int index, out bool found)
		{
			TSource result = _source.TryGetElementAt(index, out found);
			if (found)
			{
				return result;
			}
			if (index == 0)
			{
				found = true;
				return _default;
			}
			return default(TSource);
		}

		public override bool Contains(TSource value)
		{
			if (_source.TryGetNonEnumeratedCount(out var count))
			{
				if (count <= 0)
				{
					return EqualityComparer<TSource>.Default.Equals(value, _default);
				}
				return _source.Contains(value);
			}
			IEnumerator<TSource> enumerator = _source.GetEnumerator();
			try
			{
				if (!enumerator.MoveNext())
				{
					return EqualityComparer<TSource>.Default.Equals(value, _default);
				}
				do
				{
					if (EqualityComparer<TSource>.Default.Equals(enumerator.Current, value))
					{
						return true;
					}
				}
				while (enumerator.MoveNext());
				return false;
			}
			finally
			{
				enumerator.Dispose();
			}
		}
	}

	private sealed class DistinctIterator<TSource> : Iterator<TSource>
	{
		private readonly IEnumerable<TSource> _source;

		private readonly IEqualityComparer<TSource> _comparer;

		private HashSet<TSource> _set;

		private IEnumerator<TSource> _enumerator;

		public DistinctIterator(IEnumerable<TSource> source, IEqualityComparer<TSource> comparer)
		{
			_source = source;
			_comparer = comparer;
		}

		private protected override Iterator<TSource> Clone()
		{
			return new DistinctIterator<TSource>(_source, _comparer);
		}

		public override bool MoveNext()
		{
			int state = _state;
			TSource current;
			if (state != 1)
			{
				if (state == 2)
				{
					while (_enumerator.MoveNext())
					{
						current = _enumerator.Current;
						if (_set.Add(current))
						{
							_current = current;
							return true;
						}
					}
				}
				Dispose();
				return false;
			}
			_enumerator = _source.GetEnumerator();
			if (!_enumerator.MoveNext())
			{
				Dispose();
				return false;
			}
			current = _enumerator.Current;
			_set = new HashSet<TSource>(7, _comparer);
			_set.Add(current);
			_current = current;
			_state = 2;
			return true;
		}

		public override void Dispose()
		{
			if (_enumerator != null)
			{
				_enumerator.Dispose();
				_enumerator = null;
				_set = null;
			}
			base.Dispose();
		}

		public override TSource[] ToArray()
		{
			return ICollectionToArray(new HashSet<TSource>(_source, _comparer));
		}

		public override List<TSource> ToList()
		{
			return new List<TSource>(new HashSet<TSource>(_source, _comparer));
		}

		public override int GetCount(bool onlyIfCheap)
		{
			if (!onlyIfCheap)
			{
				return new HashSet<TSource>(_source, _comparer).Count;
			}
			return -1;
		}

		public override TSource TryGetFirst(out bool found)
		{
			return _source.TryGetFirst(out found);
		}

		public override bool Contains(TSource value)
		{
			if (_comparer != null)
			{
				return base.Contains(value);
			}
			return _source.Contains(value);
		}
	}

	private sealed class GroupByResultIterator<TSource, TKey, TResult> : Iterator<TResult>
	{
		private readonly IEnumerable<TSource> _source;

		private readonly Func<TSource, TKey> _keySelector;

		private readonly IEqualityComparer<TKey> _comparer;

		private readonly Func<TKey, IEnumerable<TSource>, TResult> _resultSelector;

		private Lookup<TKey, TSource> _lookup;

		private Grouping<TKey, TSource> _g;

		public GroupByResultIterator(IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TKey, IEnumerable<TSource>, TResult> resultSelector, IEqualityComparer<TKey> comparer)
		{
			_source = source;
			_keySelector = keySelector;
			_resultSelector = resultSelector;
			_comparer = comparer;
		}

		private protected override Iterator<TResult> Clone()
		{
			return new GroupByResultIterator<TSource, TKey, TResult>(_source, _keySelector, _resultSelector, _comparer);
		}

		public override bool MoveNext()
		{
			int state = _state;
			if (state != 1)
			{
				if (state != 2 || _g == _lookup._lastGrouping)
				{
					goto IL_0063;
				}
			}
			else
			{
				_lookup = Lookup<TKey, TSource>.Create(_source, _keySelector, _comparer);
				_g = _lookup._lastGrouping;
				if (_g == null)
				{
					goto IL_0063;
				}
				_state = 2;
			}
			_g = _g._next;
			_g.Trim();
			_current = _resultSelector(_g.Key, _g._elements);
			return true;
			IL_0063:
			Dispose();
			return false;
		}

		public override TResult[] ToArray()
		{
			return Lookup<TKey, TSource>.Create(_source, _keySelector, _comparer).ToArray(_resultSelector);
		}

		public override List<TResult> ToList()
		{
			return Lookup<TKey, TSource>.Create(_source, _keySelector, _comparer).ToList(_resultSelector);
		}

		public override int GetCount(bool onlyIfCheap)
		{
			if (!onlyIfCheap)
			{
				return Lookup<TKey, TSource>.Create(_source, _keySelector, _comparer).Count;
			}
			return -1;
		}
	}

	private sealed class GroupByIterator<TSource, TKey, TElement> : Iterator<IGrouping<TKey, TElement>>
	{
		private readonly IEnumerable<TSource> _source;

		private readonly Func<TSource, TKey> _keySelector;

		private readonly Func<TSource, TElement> _elementSelector;

		private readonly IEqualityComparer<TKey> _comparer;

		private Lookup<TKey, TElement> _lookup;

		private Grouping<TKey, TElement> _g;

		public GroupByIterator(IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer)
		{
			_source = source;
			_keySelector = keySelector;
			_elementSelector = elementSelector;
			_comparer = comparer;
		}

		private protected override Iterator<IGrouping<TKey, TElement>> Clone()
		{
			return new GroupByIterator<TSource, TKey, TElement>(_source, _keySelector, _elementSelector, _comparer);
		}

		public override bool MoveNext()
		{
			int state = _state;
			if (state != 1)
			{
				if (state != 2 || _g == _lookup._lastGrouping)
				{
					goto IL_0069;
				}
			}
			else
			{
				_lookup = Lookup<TKey, TElement>.Create(_source, _keySelector, _elementSelector, _comparer);
				_g = _lookup._lastGrouping;
				if (_g == null)
				{
					goto IL_0069;
				}
				_state = 2;
			}
			_g = _g._next;
			_current = _g;
			return true;
			IL_0069:
			Dispose();
			return false;
		}

		public override IGrouping<TKey, TElement>[] ToArray()
		{
			return ((IEnumerable<IGrouping<TKey, TElement>>)Lookup<TKey, TElement>.Create(_source, _keySelector, _elementSelector, _comparer)).ToArray();
		}

		public override List<IGrouping<TKey, TElement>> ToList()
		{
			return ((IEnumerable<IGrouping<TKey, TElement>>)Lookup<TKey, TElement>.Create(_source, _keySelector, _elementSelector, _comparer)).ToList();
		}

		public override int GetCount(bool onlyIfCheap)
		{
			if (!onlyIfCheap)
			{
				return Lookup<TKey, TElement>.Create(_source, _keySelector, _elementSelector, _comparer).Count;
			}
			return -1;
		}
	}

	private sealed class GroupByIterator<TSource, TKey> : Iterator<IGrouping<TKey, TSource>>
	{
		private readonly IEnumerable<TSource> _source;

		private readonly Func<TSource, TKey> _keySelector;

		private readonly IEqualityComparer<TKey> _comparer;

		private Lookup<TKey, TSource> _lookup;

		private Grouping<TKey, TSource> _g;

		public GroupByIterator(IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
		{
			_source = source;
			_keySelector = keySelector;
			_comparer = comparer;
		}

		private protected override Iterator<IGrouping<TKey, TSource>> Clone()
		{
			return new GroupByIterator<TSource, TKey>(_source, _keySelector, _comparer);
		}

		public override bool MoveNext()
		{
			int state = _state;
			if (state != 1)
			{
				if (state != 2 || _g == _lookup._lastGrouping)
				{
					goto IL_0063;
				}
			}
			else
			{
				_lookup = Lookup<TKey, TSource>.Create(_source, _keySelector, _comparer);
				_g = _lookup._lastGrouping;
				if (_g == null)
				{
					goto IL_0063;
				}
				_state = 2;
			}
			_g = _g._next;
			_current = _g;
			return true;
			IL_0063:
			Dispose();
			return false;
		}

		public override IGrouping<TKey, TSource>[] ToArray()
		{
			return ((IEnumerable<IGrouping<TKey, TSource>>)Lookup<TKey, TSource>.Create(_source, _keySelector, _comparer)).ToArray();
		}

		public override List<IGrouping<TKey, TSource>> ToList()
		{
			return ((IEnumerable<IGrouping<TKey, TSource>>)Lookup<TKey, TSource>.Create(_source, _keySelector, _comparer)).ToList();
		}

		public override int GetCount(bool onlyIfCheap)
		{
			if (!onlyIfCheap)
			{
				return Lookup<TKey, TSource>.Create(_source, _keySelector, _comparer).Count;
			}
			return -1;
		}
	}

	private abstract class Iterator<TSource> : IEnumerable<TSource>, IEnumerable, IEnumerator<TSource>, IEnumerator, IDisposable
	{
		private readonly int _threadId = Environment.CurrentManagedThreadId;

		private protected int _state;

		private protected TSource _current;

		public TSource Current => _current;

		object IEnumerator.Current => Current;

		private protected abstract Iterator<TSource> Clone();

		public virtual void Dispose()
		{
			_current = default(TSource);
			_state = -1;
		}

		public Iterator<TSource> GetEnumerator()
		{
			Iterator<TSource> obj = ((_state == 0 && _threadId == Environment.CurrentManagedThreadId) ? this : Clone());
			obj._state = 1;
			return obj;
		}

		public abstract bool MoveNext();

		public virtual IEnumerable<TResult> Select<TResult>(Func<TSource, TResult> selector)
		{
			_ = 1;
			return new IEnumerableSelectIterator<TSource, TResult>(this, selector);
		}

		public virtual IEnumerable<TSource> Where(Func<TSource, bool> predicate)
		{
			return new IEnumerableWhereIterator<TSource>(this, predicate);
		}

		IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator()
		{
			return GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		void IEnumerator.Reset()
		{
			ThrowHelper.ThrowNotSupportedException();
		}

		public abstract TSource[] ToArray();

		public abstract List<TSource> ToList();

		public abstract int GetCount(bool onlyIfCheap);

		public virtual Iterator<TSource> Skip(int count)
		{
			return new IEnumerableSkipTakeIterator<TSource>(this, count, -1);
		}

		public virtual Iterator<TSource> Take(int count)
		{
			return new IEnumerableSkipTakeIterator<TSource>(this, 0, count - 1);
		}

		public virtual TSource TryGetElementAt(int index, out bool found)
		{
			if (index != 0)
			{
				return TryGetElementAtNonIterator(this, index, out found);
			}
			return TryGetFirst(out found);
		}

		public virtual TSource TryGetFirst(out bool found)
		{
			return TryGetFirstNonIterator(this, out found);
		}

		public virtual TSource TryGetLast(out bool found)
		{
			return TryGetLastNonIterator(this, out found);
		}

		public virtual bool Contains(TSource value)
		{
			return ContainsIterate(this, value, null);
		}
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private readonly struct MaxCalc<T> : IMinMaxCalc<T> where T : struct, IBinaryInteger<T>
	{
		public static bool Compare(T left, T right)
		{
			return left > right;
		}

		public static Vector128<T> Compare(Vector128<T> left, Vector128<T> right)
		{
			return Vector128.Max(left, right);
		}
	}

	private interface IMinMaxCalc<T> where T : struct, IBinaryInteger<T>
	{
		static abstract bool Compare(T left, T right);

		static abstract Vector128<T> Compare(Vector128<T> left, Vector128<T> right);
	}

	private sealed class OfTypeIterator<TResult>(IEnumerable source) : Iterator<TResult>()
	{
		private readonly IEnumerable _source = source;

		private IEnumerator _enumerator;

		private protected override Iterator<TResult> Clone()
		{
			return new OfTypeIterator<TResult>(_source);
		}

		public override bool MoveNext()
		{
			int state = _state;
			if (state != 1)
			{
				if (state != 2)
				{
					goto IL_0062;
				}
			}
			else
			{
				_enumerator = _source.GetEnumerator();
				_state = 2;
			}
			while (_enumerator.MoveNext())
			{
				if (_enumerator.Current is TResult current)
				{
					_current = current;
					return true;
				}
			}
			Dispose();
			goto IL_0062;
			IL_0062:
			return false;
		}

		public override void Dispose()
		{
			(_enumerator as IDisposable)?.Dispose();
			_enumerator = null;
			base.Dispose();
		}

		public override int GetCount(bool onlyIfCheap)
		{
			if (onlyIfCheap)
			{
				return -1;
			}
			int num = 0;
			foreach (object item in _source)
			{
				if (item is TResult)
				{
					num = checked(num + 1);
				}
			}
			return num;
		}

		public override TResult[] ToArray()
		{
			SegmentedArrayBuilder<TResult>.ScratchBuffer buffer = default(SegmentedArrayBuilder<TResult>.ScratchBuffer);
			SegmentedArrayBuilder<TResult> segmentedArrayBuilder = new SegmentedArrayBuilder<TResult>(global::_003CPrivateImplementationDetails_003E.InlineArrayAsSpan<SegmentedArrayBuilder<TResult>.ScratchBuffer, TResult>(ref buffer, 8));
			foreach (object item2 in _source)
			{
				if (item2 is TResult item)
				{
					segmentedArrayBuilder.Add(item);
				}
			}
			TResult[] result = segmentedArrayBuilder.ToArray();
			segmentedArrayBuilder.Dispose();
			return result;
		}

		public override List<TResult> ToList()
		{
			SegmentedArrayBuilder<TResult>.ScratchBuffer buffer = default(SegmentedArrayBuilder<TResult>.ScratchBuffer);
			SegmentedArrayBuilder<TResult> segmentedArrayBuilder = new SegmentedArrayBuilder<TResult>(global::_003CPrivateImplementationDetails_003E.InlineArrayAsSpan<SegmentedArrayBuilder<TResult>.ScratchBuffer, TResult>(ref buffer, 8));
			foreach (object item2 in _source)
			{
				if (item2 is TResult item)
				{
					segmentedArrayBuilder.Add(item);
				}
			}
			List<TResult> result = segmentedArrayBuilder.ToList();
			segmentedArrayBuilder.Dispose();
			return result;
		}

		public override TResult TryGetFirst(out bool found)
		{
			foreach (object item in _source)
			{
				if (item is TResult result)
				{
					found = true;
					return result;
				}
			}
			found = false;
			return default(TResult);
		}

		public override TResult TryGetLast(out bool found)
		{
			IEnumerator enumerator = _source.GetEnumerator();
			try
			{
				if (enumerator.MoveNext())
				{
					do
					{
						if (!(enumerator.Current is TResult result))
						{
							continue;
						}
						found = true;
						while (enumerator.MoveNext())
						{
							if (enumerator.Current is TResult val)
							{
								result = val;
							}
						}
						return result;
					}
					while (enumerator.MoveNext());
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
			found = false;
			return default(TResult);
		}

		public override TResult TryGetElementAt(int index, out bool found)
		{
			if (index >= 0)
			{
				foreach (object item in _source)
				{
					if (item is TResult result)
					{
						if (index == 0)
						{
							found = true;
							return result;
						}
						index--;
					}
				}
			}
			found = false;
			return default(TResult);
		}

		public override IEnumerable<TResult2> Select<TResult2>(Func<TResult, TResult2> selector)
		{
			if (!typeof(TResult).IsValueType && _source is IEnumerable<object> source)
			{
				Func<object, TResult2> selector2 = Unsafe.As<Func<object, TResult2>>(selector);
				Func<object, bool> predicate = (object o) => o is TResult;
				if (1 == 0)
				{
				}
				return new IEnumerableWhereSelectIterator<object, TResult2>(source, predicate, selector2);
			}
			return base.Select(selector);
		}

		public override bool Contains(TResult value)
		{
			foreach (object item in _source)
			{
				if (item is TResult x && EqualityComparer<TResult>.Default.Equals(x, value))
				{
					return true;
				}
			}
			return false;
		}
	}

	private abstract class OrderedIterator<TElement> : Iterator<TElement>, IOrderedEnumerable<TElement>, IEnumerable<TElement>, IEnumerable
	{
		internal readonly IEnumerable<TElement> _source;

		protected OrderedIterator(IEnumerable<TElement> source)
		{
			_source = source;
		}

		private protected int[] SortedMap(TElement[] buffer)
		{
			return GetEnumerableSorter().Sort(buffer, buffer.Length);
		}

		internal int[] SortedMap(TElement[] buffer, int minIdx, int maxIdx)
		{
			return GetEnumerableSorter().Sort(buffer, buffer.Length, minIdx, maxIdx);
		}

		internal abstract EnumerableSorter<TElement> GetEnumerableSorter(EnumerableSorter<TElement> next = null);

		internal abstract CachingComparer<TElement> GetComparer(CachingComparer<TElement> childComparer = null);

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		IOrderedEnumerable<TElement> IOrderedEnumerable<TElement>.CreateOrderedEnumerable<TKey>(Func<TElement, TKey> keySelector, IComparer<TKey> comparer, bool descending)
		{
			return new OrderedIterator<TElement, TKey>(_source, keySelector, comparer, descending, this);
		}

		public TElement TryGetLast(Func<TElement, bool> predicate, out bool found)
		{
			CachingComparer<TElement> comparer = GetComparer();
			using IEnumerator<TElement> enumerator = _source.GetEnumerator();
			while (enumerator.MoveNext())
			{
				TElement val = enumerator.Current;
				if (!predicate(val))
				{
					continue;
				}
				comparer.SetElement(val);
				while (enumerator.MoveNext())
				{
					TElement current = enumerator.Current;
					if (predicate(current) && comparer.Compare(current, cacheLower: false) >= 0)
					{
						val = current;
					}
				}
				found = true;
				return val;
			}
			found = false;
			return default(TElement);
		}

		public override TElement[] ToArray()
		{
			TElement[] array = _source.ToArray();
			if (array.Length <= 1)
			{
				return array;
			}
			TElement[] array2 = new TElement[array.Length];
			Fill(array, array2);
			return array2;
		}

		public override List<TElement> ToList()
		{
			TElement[] array = _source.ToArray();
			List<TElement> list = new List<TElement>(array.Length);
			if (array.Length >= 2)
			{
				Fill(array, SetCountAndGetSpan(list, array.Length));
			}
			else if (array.Length == 1)
			{
				list.Add(array[0]);
			}
			return list;
		}

		private void Fill(TElement[] buffer, Span<TElement> destination)
		{
			int[] array = SortedMap(buffer);
			for (int i = 0; i < destination.Length; i++)
			{
				destination[i] = buffer[array[i]];
			}
		}

		public override int GetCount(bool onlyIfCheap)
		{
			if (_source is Iterator<TElement> iterator)
			{
				return iterator.GetCount(onlyIfCheap);
			}
			if (onlyIfCheap && !(_source is ICollection<TElement>) && !(_source is ICollection))
			{
				return -1;
			}
			return _source.Count();
		}

		internal TElement[] ToArray(int minIdx, int maxIdx)
		{
			TElement[] array = _source.ToArray();
			if (array.Length <= minIdx)
			{
				return Array.Empty<TElement>();
			}
			if (array.Length <= maxIdx)
			{
				maxIdx = array.Length - 1;
			}
			if (minIdx == maxIdx)
			{
				return new TElement[1] { GetEnumerableSorter().ElementAt(array, array.Length, minIdx) };
			}
			TElement[] array2 = new TElement[maxIdx - minIdx + 1];
			Fill(minIdx, maxIdx, array, array2);
			return array2;
		}

		internal List<TElement> ToList(int minIdx, int maxIdx)
		{
			TElement[] array = _source.ToArray();
			if (array.Length <= minIdx)
			{
				return new List<TElement>();
			}
			if (array.Length <= maxIdx)
			{
				maxIdx = array.Length - 1;
			}
			if (minIdx == maxIdx)
			{
				return new List<TElement>(1) { GetEnumerableSorter().ElementAt(array, array.Length, minIdx) };
			}
			List<TElement> list = new List<TElement>();
			Fill(minIdx, maxIdx, array, SetCountAndGetSpan(list, maxIdx - minIdx + 1));
			return list;
		}

		private void Fill(int minIdx, int maxIdx, TElement[] buffer, Span<TElement> destination)
		{
			int[] array = SortedMap(buffer, minIdx, maxIdx);
			int num = 0;
			while (minIdx <= maxIdx)
			{
				destination[num] = buffer[array[minIdx]];
				num++;
				minIdx++;
			}
		}

		internal int GetCount(int minIdx, int maxIdx, bool onlyIfCheap)
		{
			int count = GetCount(onlyIfCheap);
			if (count <= 0)
			{
				return count;
			}
			if (count <= minIdx)
			{
				return 0;
			}
			return ((count <= maxIdx) ? count : (maxIdx + 1)) - minIdx;
		}

		public override Iterator<TElement> Skip(int count)
		{
			return new SkipTakeOrderedIterator<TElement>(this, count, int.MaxValue);
		}

		public override Iterator<TElement> Take(int count)
		{
			return new SkipTakeOrderedIterator<TElement>(this, 0, count - 1);
		}

		public override TElement TryGetElementAt(int index, out bool found)
		{
			if (index == 0)
			{
				return TryGetFirst(out found);
			}
			if (index > 0)
			{
				TElement[] array = _source.ToArray();
				if (index < array.Length)
				{
					found = true;
					return GetEnumerableSorter().ElementAt(array, array.Length, index);
				}
			}
			found = false;
			return default(TElement);
		}

		public override TElement TryGetFirst(out bool found)
		{
			CachingComparer<TElement> comparer = GetComparer();
			using IEnumerator<TElement> enumerator = _source.GetEnumerator();
			if (!enumerator.MoveNext())
			{
				found = false;
				return default(TElement);
			}
			TElement val = enumerator.Current;
			comparer.SetElement(val);
			while (enumerator.MoveNext())
			{
				TElement current = enumerator.Current;
				if (comparer.Compare(current, cacheLower: true) < 0)
				{
					val = current;
				}
			}
			found = true;
			return val;
		}

		public override TElement TryGetLast(out bool found)
		{
			using IEnumerator<TElement> enumerator = _source.GetEnumerator();
			if (!enumerator.MoveNext())
			{
				found = false;
				return default(TElement);
			}
			CachingComparer<TElement> comparer = GetComparer();
			TElement val = enumerator.Current;
			comparer.SetElement(val);
			while (enumerator.MoveNext())
			{
				TElement current = enumerator.Current;
				if (comparer.Compare(current, cacheLower: false) >= 0)
				{
					val = current;
				}
			}
			found = true;
			return val;
		}

		public TElement TryGetLast(int minIdx, int maxIdx, out bool found)
		{
			TElement[] array = _source.ToArray();
			if (minIdx < array.Length)
			{
				found = true;
				if (maxIdx >= array.Length - 1)
				{
					return Last(array);
				}
				return GetEnumerableSorter().ElementAt(array, array.Length, maxIdx);
			}
			found = false;
			return default(TElement);
		}

		public override bool Contains(TElement value)
		{
			return _source.Contains(value);
		}

		private TElement Last(TElement[] items)
		{
			CachingComparer<TElement> comparer = GetComparer();
			TElement val = items[0];
			comparer.SetElement(val);
			for (int i = 1; i < items.Length; i++)
			{
				TElement val2 = items[i];
				if (comparer.Compare(val2, cacheLower: false) >= 0)
				{
					val = val2;
				}
			}
			return val;
		}
	}

	private sealed class OrderedIterator<TElement, TKey> : OrderedIterator<TElement>
	{
		private readonly OrderedIterator<TElement> _parent;

		private readonly Func<TElement, TKey> _keySelector;

		private readonly IComparer<TKey> _comparer;

		private readonly bool _descending;

		private TElement[] _buffer;

		private int[] _map;

		internal OrderedIterator(IEnumerable<TElement> source, Func<TElement, TKey> keySelector, IComparer<TKey> comparer, bool descending, OrderedIterator<TElement> parent)
			: base(source)
		{
			if (source == null)
			{
				ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
			}
			if (keySelector == null)
			{
				ThrowHelper.ThrowArgumentNullException(ExceptionArgument.keySelector);
			}
			_parent = parent;
			_keySelector = keySelector;
			_comparer = comparer ?? Comparer<TKey>.Default;
			_descending = descending;
		}

		private protected override Iterator<TElement> Clone()
		{
			return new OrderedIterator<TElement, TKey>(_source, _keySelector, _comparer, _descending, _parent);
		}

		internal override EnumerableSorter<TElement> GetEnumerableSorter(EnumerableSorter<TElement> next)
		{
			IComparer<TKey> comparer = _comparer;
			if (typeof(TKey) == typeof(string) && comparer == Comparer<string>.Default)
			{
				comparer = (IComparer<TKey>)StringComparer.CurrentCulture;
			}
			EnumerableSorter<TElement> enumerableSorter = new EnumerableSorter<TElement, TKey>(_keySelector, comparer, _descending, next);
			if (_parent != null)
			{
				enumerableSorter = _parent.GetEnumerableSorter(enumerableSorter);
			}
			return enumerableSorter;
		}

		internal override CachingComparer<TElement> GetComparer(CachingComparer<TElement> childComparer)
		{
			CachingComparer<TElement> cachingComparer = ((childComparer == null) ? new CachingComparer<TElement, TKey>(_keySelector, _comparer, _descending) : new CachingComparerWithChild<TElement, TKey>(_keySelector, _comparer, _descending, childComparer));
			if (_parent == null)
			{
				return cachingComparer;
			}
			return _parent.GetComparer(cachingComparer);
		}

		public override bool MoveNext()
		{
			int num = _state;
			while (true)
			{
				if (num > 1)
				{
					int[] map = _map;
					int num2 = num - 2;
					if ((uint)num2 >= (uint)map.Length)
					{
						break;
					}
					_current = _buffer[map[num2]];
					_state++;
					return true;
				}
				if (num != 1)
				{
					break;
				}
				TElement[] array = _source.ToArray();
				if (array.Length == 0)
				{
					break;
				}
				_map = SortedMap(array);
				_buffer = array;
				num = (_state = 2);
			}
			Dispose();
			return false;
		}

		public override void Dispose()
		{
			_buffer = null;
			_map = null;
			base.Dispose();
		}

		public override TElement TryGetFirst(out bool found)
		{
			if (_parent != null)
			{
				return base.TryGetFirst(out found);
			}
			using IEnumerator<TElement> enumerator = _source.GetEnumerator();
			if (enumerator.MoveNext())
			{
				IComparer<TKey> comparer = _comparer;
				Func<TElement, TKey> keySelector = _keySelector;
				TElement val = enumerator.Current;
				TKey y = keySelector(val);
				if (_descending)
				{
					while (enumerator.MoveNext())
					{
						TElement current = enumerator.Current;
						TKey val2 = keySelector(current);
						if (comparer.Compare(val2, y) > 0)
						{
							y = val2;
							val = current;
						}
					}
				}
				else
				{
					while (enumerator.MoveNext())
					{
						TElement current2 = enumerator.Current;
						TKey val3 = keySelector(current2);
						if (comparer.Compare(val3, y) < 0)
						{
							y = val3;
							val = current2;
						}
					}
				}
				found = true;
				return val;
			}
			found = false;
			return default(TElement);
		}

		public override TElement TryGetLast(out bool found)
		{
			if (_parent != null)
			{
				return base.TryGetLast(out found);
			}
			using IEnumerator<TElement> enumerator = _source.GetEnumerator();
			if (enumerator.MoveNext())
			{
				IComparer<TKey> comparer = _comparer;
				Func<TElement, TKey> keySelector = _keySelector;
				TElement val = enumerator.Current;
				TKey y = keySelector(val);
				if (_descending)
				{
					while (enumerator.MoveNext())
					{
						TElement current = enumerator.Current;
						TKey val2 = keySelector(current);
						if (comparer.Compare(val2, y) <= 0)
						{
							y = val2;
							val = current;
						}
					}
				}
				else
				{
					while (enumerator.MoveNext())
					{
						TElement current2 = enumerator.Current;
						TKey val3 = keySelector(current2);
						if (comparer.Compare(val3, y) >= 0)
						{
							y = val3;
							val = current2;
						}
					}
				}
				found = true;
				return val;
			}
			found = false;
			return default(TElement);
		}
	}

	private abstract class CachingComparer<TElement>
	{
		internal abstract int Compare(TElement element, bool cacheLower);

		internal abstract void SetElement(TElement element);
	}

	private class CachingComparer<TElement, TKey> : CachingComparer<TElement>
	{
		protected readonly Func<TElement, TKey> _keySelector;

		protected readonly IComparer<TKey> _comparer;

		protected readonly bool _descending;

		protected TKey _lastKey;

		public CachingComparer(Func<TElement, TKey> keySelector, IComparer<TKey> comparer, bool descending)
		{
			_keySelector = keySelector;
			_comparer = comparer;
			_descending = descending;
		}

		internal override int Compare(TElement element, bool cacheLower)
		{
			TKey val = _keySelector(element);
			int num = (_descending ? _comparer.Compare(_lastKey, val) : _comparer.Compare(val, _lastKey));
			if (cacheLower == num < 0)
			{
				_lastKey = val;
			}
			return num;
		}

		internal override void SetElement(TElement element)
		{
			_lastKey = _keySelector(element);
		}
	}

	private sealed class CachingComparerWithChild<TElement, TKey> : CachingComparer<TElement, TKey>
	{
		private readonly CachingComparer<TElement> _child;

		public CachingComparerWithChild(Func<TElement, TKey> keySelector, IComparer<TKey> comparer, bool descending, CachingComparer<TElement> child)
			: base(keySelector, comparer, descending)
		{
			_child = child;
		}

		internal override int Compare(TElement element, bool cacheLower)
		{
			TKey val = _keySelector(element);
			int num = (_descending ? _comparer.Compare(_lastKey, val) : _comparer.Compare(val, _lastKey));
			if (num == 0)
			{
				return _child.Compare(element, cacheLower);
			}
			if (cacheLower == num < 0)
			{
				_lastKey = val;
				_child.SetElement(element);
			}
			return num;
		}

		internal override void SetElement(TElement element)
		{
			base.SetElement(element);
			_child.SetElement(element);
		}
	}

	private abstract class EnumerableSorter<TElement>
	{
		internal static readonly Func<TElement, TElement> IdentityFunc = (TElement e) => e;

		internal abstract void ComputeKeys(TElement[] elements, int count);

		internal abstract int CompareAnyKeys(int index1, int index2);

		private int[] ComputeMap(TElement[] elements, int count)
		{
			ComputeKeys(elements, count);
			int[] array = new int[count];
			FillIncrementing(array, 0);
			return array;
		}

		internal int[] Sort(TElement[] elements, int count)
		{
			int[] array = ComputeMap(elements, count);
			QuickSort(array, 0, count - 1);
			return array;
		}

		internal int[] Sort(TElement[] elements, int count, int minIdx, int maxIdx)
		{
			int[] array = ComputeMap(elements, count);
			PartialQuickSort(array, 0, count - 1, minIdx, maxIdx);
			return array;
		}

		internal TElement ElementAt(TElement[] elements, int count, int idx)
		{
			int[] map = ComputeMap(elements, count);
			if (idx != 0)
			{
				return elements[QuickSelect(map, count - 1, idx)];
			}
			return elements[Min(map, count)];
		}

		protected abstract void QuickSort(int[] map, int left, int right);

		protected abstract void PartialQuickSort(int[] map, int left, int right, int minIdx, int maxIdx);

		protected abstract int QuickSelect(int[] map, int right, int idx);

		protected abstract int Min(int[] map, int count);
	}

	private sealed class EnumerableSorter<TElement, TKey> : EnumerableSorter<TElement>
	{
		private readonly Func<TElement, TKey> _keySelector;

		private readonly IComparer<TKey> _comparer;

		private readonly bool _descending;

		private readonly EnumerableSorter<TElement> _next;

		private TKey[] _keys;

		internal EnumerableSorter(Func<TElement, TKey> keySelector, IComparer<TKey> comparer, bool descending, EnumerableSorter<TElement> next)
		{
			_keySelector = keySelector;
			_comparer = comparer;
			_descending = descending;
			_next = next;
		}

		internal override void ComputeKeys(TElement[] elements, int count)
		{
			Func<TElement, TKey> keySelector = _keySelector;
			if ((object)keySelector != EnumerableSorter<TElement>.IdentityFunc)
			{
				TKey[] array = new TKey[count];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = keySelector(elements[i]);
				}
				_keys = array;
			}
			else
			{
				_keys = (TKey[])(object)elements;
			}
			_next?.ComputeKeys(elements, count);
		}

		internal override int CompareAnyKeys(int index1, int index2)
		{
			TKey[] keys = _keys;
			int num = _comparer.Compare(keys[index1], keys[index2]);
			if (num == 0)
			{
				if (_next == null)
				{
					return index1 - index2;
				}
				return _next.CompareAnyKeys(index1, index2);
			}
			if (_descending == num > 0)
			{
				return -1;
			}
			return 1;
		}

		private int CompareAnyKeys_DefaultComparer_NoNext_Ascending(int index1, int index2)
		{
			TKey[] keys = _keys;
			int num = Comparer<TKey>.Default.Compare(keys[index1], keys[index2]);
			if (num != 0)
			{
				return num;
			}
			return index1 - index2;
		}

		private int CompareAnyKeys_DefaultComparer_NoNext_Descending(int index1, int index2)
		{
			TKey[] keys = _keys;
			int num = Comparer<TKey>.Default.Compare(keys[index2], keys[index1]);
			if (num != 0)
			{
				return num;
			}
			return index1 - index2;
		}

		private int CompareKeys(int index1, int index2)
		{
			if (index1 != index2)
			{
				return CompareAnyKeys(index1, index2);
			}
			return 0;
		}

		protected override void QuickSort(int[] keys, int lo, int hi)
		{
			MemoryExtensions.Sort(comparison: (!typeof(TKey).IsValueType || _next != null || _comparer != Comparer<TKey>.Default) ? new Comparison<int>(CompareAnyKeys) : (_descending ? new Comparison<int>(CompareAnyKeys_DefaultComparer_NoNext_Descending) : new Comparison<int>(CompareAnyKeys_DefaultComparer_NoNext_Ascending)), span: new Span<int>(keys, lo, hi - lo + 1));
		}

		protected override void PartialQuickSort(int[] map, int left, int right, int minIdx, int maxIdx)
		{
			do
			{
				int num = left;
				int num2 = right;
				int index = map[num + (num2 - num >> 1)];
				while (true)
				{
					if (num < map.Length && CompareKeys(index, map[num]) > 0)
					{
						num++;
						continue;
					}
					while (num2 >= 0 && CompareKeys(index, map[num2]) < 0)
					{
						num2--;
					}
					if (num > num2)
					{
						break;
					}
					if (num < num2)
					{
						int num3 = map[num];
						map[num] = map[num2];
						map[num2] = num3;
					}
					num++;
					num2--;
					if (num > num2)
					{
						break;
					}
				}
				if (minIdx >= num)
				{
					left = num + 1;
				}
				else if (maxIdx <= num2)
				{
					right = num2 - 1;
				}
				if (num2 - left <= right - num)
				{
					if (left < num2)
					{
						PartialQuickSort(map, left, num2, minIdx, maxIdx);
					}
					left = num;
				}
				else
				{
					if (num < right)
					{
						PartialQuickSort(map, num, right, minIdx, maxIdx);
					}
					right = num2;
				}
			}
			while (left < right);
		}

		protected override int QuickSelect(int[] map, int right, int idx)
		{
			int num = 0;
			do
			{
				int num2 = num;
				int num3 = right;
				int index = map[num2 + (num3 - num2 >> 1)];
				while (true)
				{
					if (num2 < map.Length && CompareKeys(index, map[num2]) > 0)
					{
						num2++;
						continue;
					}
					while (num3 >= 0 && CompareKeys(index, map[num3]) < 0)
					{
						num3--;
					}
					if (num2 > num3)
					{
						break;
					}
					if (num2 < num3)
					{
						int num4 = map[num2];
						map[num2] = map[num3];
						map[num3] = num4;
					}
					num2++;
					num3--;
					if (num2 > num3)
					{
						break;
					}
				}
				if (num2 <= idx)
				{
					num = num2 + 1;
				}
				else
				{
					right = num3 - 1;
				}
				if (num3 - num <= right - num2)
				{
					if (num < num3)
					{
						right = num3;
					}
					num = num2;
				}
				else
				{
					if (num2 < right)
					{
						num = num2;
					}
					right = num3;
				}
			}
			while (num < right);
			return map[idx];
		}

		protected override int Min(int[] map, int count)
		{
			int num = 0;
			for (int i = 1; i < count; i++)
			{
				if (CompareKeys(map[i], map[num]) < 0)
				{
					num = i;
				}
			}
			return map[num];
		}
	}

	private sealed class SkipTakeOrderedIterator<TElement> : Iterator<TElement>
	{
		private readonly OrderedIterator<TElement> _source;

		private readonly int _minIndexInclusive;

		private readonly int _maxIndexInclusive;

		private TElement[] _buffer;

		private int[] _map;

		private int _maxIdx;

		public SkipTakeOrderedIterator(OrderedIterator<TElement> source, int minIdxInclusive, int maxIdxInclusive)
		{
			_source = source;
			_minIndexInclusive = minIdxInclusive;
			_maxIndexInclusive = maxIdxInclusive;
		}

		private protected override Iterator<TElement> Clone()
		{
			return new SkipTakeOrderedIterator<TElement>(_source, _minIndexInclusive, _maxIndexInclusive);
		}

		public override bool MoveNext()
		{
			int num = _state;
			while (true)
			{
				if (num > 1)
				{
					int[] map = _map;
					int num2 = num - 2 + _minIndexInclusive;
					if (num2 > _maxIdx)
					{
						break;
					}
					_current = _buffer[map[num2]];
					_state++;
					return true;
				}
				if (num != 1)
				{
					break;
				}
				TElement[] array = _source._source.ToArray();
				int num3 = array.Length;
				if (num3 <= _minIndexInclusive)
				{
					break;
				}
				_maxIdx = _maxIndexInclusive;
				if (num3 <= _maxIdx)
				{
					_maxIdx = num3 - 1;
				}
				if (_minIndexInclusive == _maxIdx)
				{
					_current = _source.GetEnumerableSorter().ElementAt(array, num3, _minIndexInclusive);
					_state = -1;
					return true;
				}
				_map = _source.SortedMap(array, _minIndexInclusive, _maxIdx);
				_buffer = array;
				num = (_state = 2);
			}
			Dispose();
			return false;
		}

		public override Iterator<TElement> Skip(int count)
		{
			int num = _minIndexInclusive + count;
			if ((uint)num <= (uint)_maxIndexInclusive)
			{
				return new SkipTakeOrderedIterator<TElement>(_source, num, _maxIndexInclusive);
			}
			return null;
		}

		public override Iterator<TElement> Take(int count)
		{
			int num = _minIndexInclusive + count - 1;
			if ((uint)num >= (uint)_maxIndexInclusive)
			{
				return this;
			}
			return new SkipTakeOrderedIterator<TElement>(_source, _minIndexInclusive, num);
		}

		public override TElement TryGetElementAt(int index, out bool found)
		{
			if ((uint)index <= (uint)(_maxIndexInclusive - _minIndexInclusive))
			{
				return _source.TryGetElementAt(index + _minIndexInclusive, out found);
			}
			found = false;
			return default(TElement);
		}

		public override TElement TryGetFirst(out bool found)
		{
			return _source.TryGetElementAt(_minIndexInclusive, out found);
		}

		public override TElement TryGetLast(out bool found)
		{
			return _source.TryGetLast(_minIndexInclusive, _maxIndexInclusive, out found);
		}

		public override TElement[] ToArray()
		{
			return _source.ToArray(_minIndexInclusive, _maxIndexInclusive);
		}

		public override List<TElement> ToList()
		{
			return _source.ToList(_minIndexInclusive, _maxIndexInclusive);
		}

		public override int GetCount(bool onlyIfCheap)
		{
			return _source.GetCount(_minIndexInclusive, _maxIndexInclusive, onlyIfCheap);
		}
	}

	[DebuggerDisplay("Count = {CountForDebugger}")]
	private sealed class RangeIterator<T> : Iterator<T>, IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable, IReadOnlyList<T>, IReadOnlyCollection<T> where T : INumber<T>
	{
		private readonly T _start;

		private readonly T _endExclusive;

		private int CountForDebugger => int.CreateTruncating(_endExclusive - _start);

		public int Count => int.CreateTruncating(_endExclusive - _start);

		public T this[int index]
		{
			get
			{
				if ((uint)index >= (uint)Count)
				{
					ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.index);
				}
				return _start + T.CreateTruncating(index);
			}
			set
			{
				ThrowHelper.ThrowNotSupportedException();
			}
		}

		public bool IsReadOnly => true;

		public RangeIterator(T start, T endExclusive)
		{
			_start = start;
			_endExclusive = endExclusive;
		}

		private protected override Iterator<T> Clone()
		{
			return new RangeIterator<T>(_start, _endExclusive);
		}

		public override bool MoveNext()
		{
			switch (_state)
			{
			case 1:
				_current = _start;
				_state = 2;
				return true;
			case 2:
				if (!(++_current == _endExclusive))
				{
					return true;
				}
				break;
			}
			_state = -1;
			return false;
		}

		public override void Dispose()
		{
			_state = -1;
		}

		public override IEnumerable<TResult> Select<TResult>(Func<T, TResult> selector)
		{
			return new RangeSelectIterator<T, TResult>(_start, _endExclusive, selector);
		}

		public override T[] ToArray()
		{
			T start = _start;
			T[] array = new T[Count];
			FillIncrementing(array, start);
			return array;
		}

		public override List<T> ToList()
		{
			T start = _start;
			T endExclusive = _endExclusive;
			T val = start;
			int num = int.CreateTruncating(endExclusive - val);
			List<T> list = new List<T>(num);
			FillIncrementing(SetCountAndGetSpan(list, num), val);
			return list;
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			FillIncrementing(array.AsSpan(arrayIndex, Count), _start);
		}

		public override int GetCount(bool onlyIfCheap)
		{
			return Count;
		}

		public override Iterator<T> Skip(int count)
		{
			if (count < Count)
			{
				return new RangeIterator<T>(_start + T.CreateTruncating(count), _endExclusive);
			}
			return null;
		}

		public override Iterator<T> Take(int count)
		{
			if (count < Count)
			{
				return new RangeIterator<T>(_start, _start + T.CreateTruncating(count));
			}
			return this;
		}

		public override T TryGetElementAt(int index, out bool found)
		{
			if ((uint)index < (uint)Count)
			{
				found = true;
				return _start + T.CreateTruncating(index);
			}
			found = false;
			return T.Zero;
		}

		public override T TryGetFirst(out bool found)
		{
			found = true;
			return _start;
		}

		public override T TryGetLast(out bool found)
		{
			found = true;
			return _endExclusive - T.One;
		}

		public override bool Contains(T item)
		{
			return uint.CreateTruncating(item - _start) < (uint)Count;
		}

		public int IndexOf(T item)
		{
			uint num = uint.CreateTruncating(item - _start);
			if (num < (uint)Count)
			{
				return (int)num;
			}
			return -1;
		}

		void ICollection<T>.Add(T item)
		{
			ThrowHelper.ThrowNotSupportedException();
		}

		void ICollection<T>.Clear()
		{
			ThrowHelper.ThrowNotSupportedException();
		}

		void IList<T>.Insert(int index, T item)
		{
			ThrowHelper.ThrowNotSupportedException();
		}

		bool ICollection<T>.Remove(T item)
		{
			return ThrowHelper.ThrowNotSupportedException_Boolean();
		}

		void IList<T>.RemoveAt(int index)
		{
			ThrowHelper.ThrowNotSupportedException();
		}
	}

	[DebuggerDisplay("Count = {_count}")]
	private sealed class RepeatIterator<TResult> : Iterator<TResult>, IList<TResult>, ICollection<TResult>, IEnumerable<TResult>, IEnumerable, IReadOnlyList<TResult>, IReadOnlyCollection<TResult>
	{
		private readonly int _count;

		public int Count => _count;

		public TResult this[int index]
		{
			get
			{
				if ((uint)index >= (uint)_count)
				{
					ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.index);
				}
				return _current;
			}
			set
			{
				ThrowHelper.ThrowNotSupportedException();
			}
		}

		public bool IsReadOnly => true;

		public RepeatIterator(TResult element, int count)
		{
			_current = element;
			_count = count;
		}

		private protected override Iterator<TResult> Clone()
		{
			return new RepeatIterator<TResult>(_current, _count);
		}

		public override void Dispose()
		{
			_state = -1;
		}

		public override bool MoveNext()
		{
			int num = _state - 1;
			if (num >= 0 && num != _count)
			{
				_state++;
				return true;
			}
			Dispose();
			return false;
		}

		public override TResult[] ToArray()
		{
			TResult[] array = new TResult[_count];
			if (_current != null)
			{
				Array.Fill(array, _current);
			}
			return array;
		}

		public override List<TResult> ToList()
		{
			List<TResult> list = new List<TResult>(_count);
			SetCountAndGetSpan(list, _count).Fill(_current);
			return list;
		}

		public override int GetCount(bool onlyIfCheap)
		{
			return _count;
		}

		public override Iterator<TResult> Skip(int count)
		{
			if (count >= _count)
			{
				return null;
			}
			return new RepeatIterator<TResult>(_current, _count - count);
		}

		public override Iterator<TResult> Take(int count)
		{
			if (count >= _count)
			{
				return this;
			}
			return new RepeatIterator<TResult>(_current, count);
		}

		public override TResult TryGetElementAt(int index, out bool found)
		{
			if ((uint)index < (uint)_count)
			{
				found = true;
				return _current;
			}
			found = false;
			return default(TResult);
		}

		public override TResult TryGetFirst(out bool found)
		{
			found = true;
			return _current;
		}

		public override TResult TryGetLast(out bool found)
		{
			found = true;
			return _current;
		}

		public override bool Contains(TResult item)
		{
			return EqualityComparer<TResult>.Default.Equals(_current, item);
		}

		public int IndexOf(TResult item)
		{
			if (!Contains(item))
			{
				return -1;
			}
			return 0;
		}

		public void CopyTo(TResult[] array, int arrayIndex)
		{
			array.AsSpan(arrayIndex, _count).Fill(_current);
		}

		void ICollection<TResult>.Add(TResult item)
		{
			ThrowHelper.ThrowNotSupportedException();
		}

		void ICollection<TResult>.Clear()
		{
			ThrowHelper.ThrowNotSupportedException();
		}

		void IList<TResult>.Insert(int index, TResult item)
		{
			ThrowHelper.ThrowNotSupportedException();
		}

		bool ICollection<TResult>.Remove(TResult item)
		{
			return ThrowHelper.ThrowNotSupportedException_Boolean();
		}

		void IList<TResult>.RemoveAt(int index)
		{
			ThrowHelper.ThrowNotSupportedException();
		}
	}

	private sealed class ReverseIterator<TSource> : Iterator<TSource>
	{
		private readonly IEnumerable<TSource> _source;

		private TSource[] _buffer;

		public ReverseIterator(IEnumerable<TSource> source)
		{
			_source = source;
		}

		private protected override Iterator<TSource> Clone()
		{
			return new ReverseIterator<TSource>(_source);
		}

		public override bool MoveNext()
		{
			if (_state - 2 <= -2)
			{
				Dispose();
				return false;
			}
			if (_state == 1)
			{
				_state = (_buffer = _source.ToArray()).Length + 2;
			}
			int num = _state - 3;
			if (num != -1)
			{
				_current = _buffer[num];
				_state--;
				return true;
			}
			Dispose();
			return false;
		}

		public override void Dispose()
		{
			_buffer = null;
			base.Dispose();
		}

		public override TSource[] ToArray()
		{
			TSource[] array = _source.ToArray();
			Array.Reverse(array);
			return array;
		}

		public override List<TSource> ToList()
		{
			List<TSource> list = _source.ToList();
			list.Reverse();
			return list;
		}

		public override int GetCount(bool onlyIfCheap)
		{
			if (onlyIfCheap)
			{
				if (!_source.TryGetNonEnumeratedCount(out var count))
				{
					return -1;
				}
				return count;
			}
			return _source.Count();
		}

		public override TSource TryGetElementAt(int index, out bool found)
		{
			if (_source is IList<TSource> { Count: var count } list)
			{
				if ((uint)index < (uint)count)
				{
					found = true;
					return list[count - index - 1];
				}
			}
			else if (index >= 0)
			{
				TSource[] array = _source.ToArray();
				if (index < array.Length)
				{
					found = true;
					return array[array.Length - index - 1];
				}
			}
			found = false;
			return default(TSource);
		}

		public override TSource TryGetFirst(out bool found)
		{
			if (_source is Iterator<TSource> iterator)
			{
				return iterator.TryGetLast(out found);
			}
			if (_source is IList<TSource> { Count: var count } list)
			{
				if (count > 0)
				{
					found = true;
					return list[count - 1];
				}
			}
			else
			{
				using IEnumerator<TSource> enumerator = _source.GetEnumerator();
				if (enumerator.MoveNext())
				{
					TSource current;
					do
					{
						current = enumerator.Current;
					}
					while (enumerator.MoveNext());
					found = true;
					return current;
				}
			}
			found = false;
			return default(TSource);
		}

		public override TSource TryGetLast(out bool found)
		{
			if (_source is Iterator<TSource> iterator)
			{
				return iterator.TryGetFirst(out found);
			}
			if (_source is IList<TSource> list)
			{
				if (list.Count > 0)
				{
					found = true;
					return list[0];
				}
			}
			else
			{
				using IEnumerator<TSource> enumerator = _source.GetEnumerator();
				if (enumerator.MoveNext())
				{
					found = true;
					return enumerator.Current;
				}
			}
			found = false;
			return default(TSource);
		}

		public override bool Contains(TSource value)
		{
			return _source.Contains(value);
		}
	}

	private sealed class IEnumerableSelectIterator<TSource, TResult> : Iterator<TResult>
	{
		private readonly IEnumerable<TSource> _source;

		private readonly Func<TSource, TResult> _selector;

		private IEnumerator<TSource> _enumerator;

		public IEnumerableSelectIterator(IEnumerable<TSource> source, Func<TSource, TResult> selector)
		{
			_source = source;
			_selector = selector;
		}

		private protected override Iterator<TResult> Clone()
		{
			return new IEnumerableSelectIterator<TSource, TResult>(_source, _selector);
		}

		public override void Dispose()
		{
			if (_enumerator != null)
			{
				_enumerator.Dispose();
				_enumerator = null;
			}
			base.Dispose();
		}

		public override bool MoveNext()
		{
			int state = _state;
			if (state != 1)
			{
				if (state != 2)
				{
					goto IL_005a;
				}
			}
			else
			{
				_enumerator = _source.GetEnumerator();
				_state = 2;
			}
			if (_enumerator.MoveNext())
			{
				_current = _selector(_enumerator.Current);
				return true;
			}
			Dispose();
			goto IL_005a;
			IL_005a:
			return false;
		}

		public override IEnumerable<TResult2> Select<TResult2>(Func<TResult, TResult2> selector)
		{
			return new IEnumerableSelectIterator<TSource, TResult2>(_source, Utilities.CombineSelectors(_selector, selector));
		}

		public override TResult[] ToArray()
		{
			SegmentedArrayBuilder<TResult>.ScratchBuffer buffer = default(SegmentedArrayBuilder<TResult>.ScratchBuffer);
			SegmentedArrayBuilder<TResult> segmentedArrayBuilder = new SegmentedArrayBuilder<TResult>(global::_003CPrivateImplementationDetails_003E.InlineArrayAsSpan<SegmentedArrayBuilder<TResult>.ScratchBuffer, TResult>(ref buffer, 8));
			Func<TSource, TResult> selector = _selector;
			foreach (TSource item in _source)
			{
				segmentedArrayBuilder.Add(selector(item));
			}
			TResult[] result = segmentedArrayBuilder.ToArray();
			segmentedArrayBuilder.Dispose();
			return result;
		}

		public override List<TResult> ToList()
		{
			SegmentedArrayBuilder<TResult>.ScratchBuffer buffer = default(SegmentedArrayBuilder<TResult>.ScratchBuffer);
			SegmentedArrayBuilder<TResult> segmentedArrayBuilder = new SegmentedArrayBuilder<TResult>(global::_003CPrivateImplementationDetails_003E.InlineArrayAsSpan<SegmentedArrayBuilder<TResult>.ScratchBuffer, TResult>(ref buffer, 8));
			Func<TSource, TResult> selector = _selector;
			foreach (TSource item in _source)
			{
				segmentedArrayBuilder.Add(selector(item));
			}
			List<TResult> result = segmentedArrayBuilder.ToList();
			segmentedArrayBuilder.Dispose();
			return result;
		}

		public override int GetCount(bool onlyIfCheap)
		{
			if (onlyIfCheap)
			{
				return -1;
			}
			int num = 0;
			foreach (TSource item in _source)
			{
				_selector(item);
				num = checked(num + 1);
			}
			return num;
		}

		public override TResult TryGetElementAt(int index, out bool found)
		{
			if (index >= 0)
			{
				using IEnumerator<TSource> enumerator = _source.GetEnumerator();
				while (enumerator.MoveNext())
				{
					if (index == 0)
					{
						found = true;
						return _selector(enumerator.Current);
					}
					index--;
				}
			}
			found = false;
			return default(TResult);
		}

		public override TResult TryGetFirst(out bool found)
		{
			using IEnumerator<TSource> enumerator = _source.GetEnumerator();
			if (enumerator.MoveNext())
			{
				found = true;
				return _selector(enumerator.Current);
			}
			found = false;
			return default(TResult);
		}

		public override TResult TryGetLast(out bool found)
		{
			using IEnumerator<TSource> enumerator = _source.GetEnumerator();
			if (enumerator.MoveNext())
			{
				found = true;
				TSource current = enumerator.Current;
				while (enumerator.MoveNext())
				{
					current = enumerator.Current;
				}
				return _selector(current);
			}
			found = false;
			return default(TResult);
		}
	}

	private sealed class SizeOptIListSelectIterator<TSource, TResult>(IList<TSource> _source, Func<TSource, TResult> _selector) : Iterator<TResult>()
	{
		private IEnumerator<TSource> _enumerator;

		public override int GetCount(bool onlyIfCheap)
		{
			if (onlyIfCheap)
			{
				return -1;
			}
			int num = 0;
			foreach (TSource item in _003C_source_003EP)
			{
				_003C_selector_003EP(item);
				num = checked(num + 1);
			}
			return num;
		}

		public override Iterator<TResult> Skip(int count)
		{
			return new IListSkipTakeSelectIterator<TSource, TResult>(_003C_source_003EP, _003C_selector_003EP, count, int.MaxValue);
		}

		public override Iterator<TResult> Take(int count)
		{
			return new IListSkipTakeSelectIterator<TSource, TResult>(_003C_source_003EP, _003C_selector_003EP, 0, count - 1);
		}

		public override bool MoveNext()
		{
			int state = _state;
			if (state != 1)
			{
				if (state != 2)
				{
					goto IL_005a;
				}
			}
			else
			{
				_enumerator = _003C_source_003EP.GetEnumerator();
				_state = 2;
			}
			if (_enumerator.MoveNext())
			{
				_current = _003C_selector_003EP(_enumerator.Current);
				return true;
			}
			Dispose();
			goto IL_005a;
			IL_005a:
			return false;
		}

		public override TResult[] ToArray()
		{
			TResult[] array = new TResult[_003C_source_003EP.Count];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = _003C_selector_003EP(_003C_source_003EP[i]);
			}
			return array;
		}

		public override List<TResult> ToList()
		{
			List<TResult> list = new List<TResult>(_003C_source_003EP.Count);
			for (int i = 0; i < list.Count; i++)
			{
				list.Add(_003C_selector_003EP(_003C_source_003EP[i]));
			}
			return list;
		}

		private protected override Iterator<TResult> Clone()
		{
			return new SizeOptIListSelectIterator<TSource, TResult>(_003C_source_003EP, _003C_selector_003EP);
		}
	}

	private sealed class RangeSelectIterator<T, TResult> : Iterator<TResult> where T : INumber<T>
	{
		private readonly T _start;

		private readonly T _end;

		private readonly Func<T, TResult> _selector;

		private int Count => int.CreateTruncating(_end - _start);

		public RangeSelectIterator(T start, T end, Func<T, TResult> selector)
		{
			_start = start;
			_end = end;
			_selector = selector;
		}

		private protected override Iterator<TResult> Clone()
		{
			return new RangeSelectIterator<T, TResult>(_start, _end, _selector);
		}

		public override bool MoveNext()
		{
			if (_state < 1 || _state == Count + 1)
			{
				Dispose();
				return false;
			}
			int value = _state++ - 1;
			_current = _selector(_start + T.CreateTruncating(value));
			return true;
		}

		public override IEnumerable<TResult2> Select<TResult2>(Func<TResult, TResult2> selector)
		{
			return new RangeSelectIterator<T, TResult2>(_start, _end, Utilities.CombineSelectors(_selector, selector));
		}

		public override TResult[] ToArray()
		{
			TResult[] array = new TResult[Count];
			Fill(array, _start, _selector);
			return array;
		}

		public override List<TResult> ToList()
		{
			int count = Count;
			List<TResult> list = new List<TResult>(count);
			Fill(SetCountAndGetSpan(list, count), _start, _selector);
			return list;
		}

		private static void Fill(Span<TResult> results, T start, Func<T, TResult> func)
		{
			int num = 0;
			while (num < results.Length)
			{
				results[num] = func(start);
				num++;
				++start;
			}
		}

		public override int GetCount(bool onlyIfCheap)
		{
			if (!onlyIfCheap)
			{
				for (T start = _start; start != _end; ++start)
				{
					_selector(start);
				}
			}
			return Count;
		}

		public override Iterator<TResult> Skip(int count)
		{
			if (count >= Count)
			{
				return null;
			}
			return new RangeSelectIterator<T, TResult>(_start + T.CreateTruncating(count), _end, _selector);
		}

		public override Iterator<TResult> Take(int count)
		{
			if (count >= Count)
			{
				return this;
			}
			return new RangeSelectIterator<T, TResult>(_start, _start + T.CreateTruncating(count), _selector);
		}

		public override TResult TryGetElementAt(int index, out bool found)
		{
			if ((uint)index < (uint)Count)
			{
				found = true;
				return _selector(_start + T.CreateTruncating(index));
			}
			found = false;
			return default(TResult);
		}

		public override TResult TryGetFirst(out bool found)
		{
			found = true;
			return _selector(_start);
		}

		public override TResult TryGetLast(out bool found)
		{
			found = true;
			return _selector(_end - T.One);
		}

		public override bool Contains(TResult value)
		{
			for (T start = _start; start != _end; ++start)
			{
				if (EqualityComparer<TResult>.Default.Equals(_selector(start), value))
				{
					return true;
				}
			}
			return false;
		}
	}

	[DebuggerDisplay("Count = {Count}")]
	private sealed class IListSkipTakeSelectIterator<TSource, TResult> : Iterator<TResult>
	{
		private readonly IList<TSource> _source;

		private readonly Func<TSource, TResult> _selector;

		private readonly int _minIndexInclusive;

		private readonly int _maxIndexInclusive;

		private int Count
		{
			get
			{
				int count = _source.Count;
				if (count <= _minIndexInclusive)
				{
					return 0;
				}
				return Math.Min(count - 1, _maxIndexInclusive) - _minIndexInclusive + 1;
			}
		}

		public IListSkipTakeSelectIterator(IList<TSource> source, Func<TSource, TResult> selector, int minIndexInclusive, int maxIndexInclusive)
		{
			_source = source;
			_selector = selector;
			_minIndexInclusive = minIndexInclusive;
			_maxIndexInclusive = maxIndexInclusive;
		}

		private protected override Iterator<TResult> Clone()
		{
			return new IListSkipTakeSelectIterator<TSource, TResult>(_source, _selector, _minIndexInclusive, _maxIndexInclusive);
		}

		public override bool MoveNext()
		{
			int num = _state - 1;
			if ((uint)num <= (uint)(_maxIndexInclusive - _minIndexInclusive) && num < _source.Count - _minIndexInclusive)
			{
				_current = _selector(_source[_minIndexInclusive + num]);
				_state++;
				return true;
			}
			Dispose();
			return false;
		}

		public override IEnumerable<TResult2> Select<TResult2>(Func<TResult, TResult2> selector)
		{
			return new IListSkipTakeSelectIterator<TSource, TResult2>(_source, Utilities.CombineSelectors(_selector, selector), _minIndexInclusive, _maxIndexInclusive);
		}

		public override Iterator<TResult> Skip(int count)
		{
			int num = _minIndexInclusive + count;
			if ((uint)num <= (uint)_maxIndexInclusive)
			{
				return new IListSkipTakeSelectIterator<TSource, TResult>(_source, _selector, num, _maxIndexInclusive);
			}
			return null;
		}

		public override Iterator<TResult> Take(int count)
		{
			int num = _minIndexInclusive + count - 1;
			if ((uint)num < (uint)_maxIndexInclusive)
			{
				return new IListSkipTakeSelectIterator<TSource, TResult>(_source, _selector, _minIndexInclusive, num);
			}
			return this;
		}

		public override TResult TryGetElementAt(int index, out bool found)
		{
			if ((uint)index <= (uint)(_maxIndexInclusive - _minIndexInclusive) && index < _source.Count - _minIndexInclusive)
			{
				found = true;
				return _selector(_source[_minIndexInclusive + index]);
			}
			found = false;
			return default(TResult);
		}

		public override TResult TryGetFirst(out bool found)
		{
			if (_source.Count > _minIndexInclusive)
			{
				found = true;
				return _selector(_source[_minIndexInclusive]);
			}
			found = false;
			return default(TResult);
		}

		public override TResult TryGetLast(out bool found)
		{
			int num = _source.Count - 1;
			if (num >= _minIndexInclusive)
			{
				found = true;
				return _selector(_source[Math.Min(num, _maxIndexInclusive)]);
			}
			found = false;
			return default(TResult);
		}

		public override TResult[] ToArray()
		{
			int count = Count;
			if (count == 0)
			{
				return Array.Empty<TResult>();
			}
			TResult[] array = new TResult[count];
			Fill(_source, array, _selector, _minIndexInclusive);
			return array;
		}

		public override List<TResult> ToList()
		{
			int count = Count;
			if (count == 0)
			{
				return new List<TResult>();
			}
			List<TResult> list = new List<TResult>(count);
			Fill(_source, SetCountAndGetSpan(list, count), _selector, _minIndexInclusive);
			return list;
		}

		private static void Fill(IList<TSource> source, Span<TResult> destination, Func<TSource, TResult> func, int sourceIndex)
		{
			int num = 0;
			while (num < destination.Length)
			{
				destination[num] = func(source[sourceIndex]);
				num++;
				sourceIndex++;
			}
		}

		public override int GetCount(bool onlyIfCheap)
		{
			int count = Count;
			if (!onlyIfCheap)
			{
				int num = _minIndexInclusive + count;
				for (int i = _minIndexInclusive; i != num; i++)
				{
					_selector(_source[i]);
				}
			}
			return count;
		}

		public override bool Contains(TResult value)
		{
			int count = Count;
			int num = _minIndexInclusive + count;
			for (int i = _minIndexInclusive; i != num; i++)
			{
				if (EqualityComparer<TResult>.Default.Equals(_selector(_source[i]), value))
				{
					return true;
				}
			}
			return false;
		}
	}

	private sealed class SelectManySingleSelectorIterator<TSource, TResult> : Iterator<TResult>
	{
		private readonly IEnumerable<TSource> _source;

		private readonly Func<TSource, IEnumerable<TResult>> _selector;

		private IEnumerator<TSource> _sourceEnumerator;

		private IEnumerator<TResult> _subEnumerator;

		internal SelectManySingleSelectorIterator(IEnumerable<TSource> source, Func<TSource, IEnumerable<TResult>> selector)
		{
			_source = source;
			_selector = selector;
		}

		private protected override Iterator<TResult> Clone()
		{
			return new SelectManySingleSelectorIterator<TSource, TResult>(_source, _selector);
		}

		public override void Dispose()
		{
			if (_subEnumerator != null)
			{
				_subEnumerator.Dispose();
				_subEnumerator = null;
			}
			if (_sourceEnumerator != null)
			{
				_sourceEnumerator.Dispose();
				_sourceEnumerator = null;
			}
			base.Dispose();
		}

		public override bool MoveNext()
		{
			switch (_state)
			{
			case 1:
				_sourceEnumerator = _source.GetEnumerator();
				_state = 2;
				goto case 2;
			case 2:
			{
				if (!_sourceEnumerator.MoveNext())
				{
					break;
				}
				TSource current = _sourceEnumerator.Current;
				_subEnumerator = _selector(current).GetEnumerator();
				_state = 3;
				goto case 3;
			}
			case 3:
				if (!_subEnumerator.MoveNext())
				{
					_subEnumerator.Dispose();
					_subEnumerator = null;
					_state = 2;
					goto case 2;
				}
				_current = _subEnumerator.Current;
				return true;
			}
			Dispose();
			return false;
		}

		public override int GetCount(bool onlyIfCheap)
		{
			if (onlyIfCheap)
			{
				return -1;
			}
			int num = 0;
			foreach (TSource item in _source)
			{
				num = checked(num + _selector(item).Count());
			}
			return num;
		}

		public override TResult[] ToArray()
		{
			SegmentedArrayBuilder<TResult>.ScratchBuffer buffer = default(SegmentedArrayBuilder<TResult>.ScratchBuffer);
			SegmentedArrayBuilder<TResult> segmentedArrayBuilder = new SegmentedArrayBuilder<TResult>(global::_003CPrivateImplementationDetails_003E.InlineArrayAsSpan<SegmentedArrayBuilder<TResult>.ScratchBuffer, TResult>(ref buffer, 8));
			Func<TSource, IEnumerable<TResult>> selector = _selector;
			foreach (TSource item in _source)
			{
				segmentedArrayBuilder.AddRange(selector(item));
			}
			TResult[] result = segmentedArrayBuilder.ToArray();
			segmentedArrayBuilder.Dispose();
			return result;
		}

		public override List<TResult> ToList()
		{
			SegmentedArrayBuilder<TResult>.ScratchBuffer buffer = default(SegmentedArrayBuilder<TResult>.ScratchBuffer);
			SegmentedArrayBuilder<TResult> segmentedArrayBuilder = new SegmentedArrayBuilder<TResult>(global::_003CPrivateImplementationDetails_003E.InlineArrayAsSpan<SegmentedArrayBuilder<TResult>.ScratchBuffer, TResult>(ref buffer, 8));
			Func<TSource, IEnumerable<TResult>> selector = _selector;
			foreach (TSource item in _source)
			{
				segmentedArrayBuilder.AddRange(selector(item));
			}
			List<TResult> result = segmentedArrayBuilder.ToList();
			segmentedArrayBuilder.Dispose();
			return result;
		}

		public override bool Contains(TResult value)
		{
			foreach (TSource item in _source)
			{
				if (_selector(item).Contains(value))
				{
					return true;
				}
			}
			return false;
		}
	}

	[DebuggerDisplay("Count = {Count}")]
	private sealed class IListSkipTakeIterator<TSource> : Iterator<TSource>, IList<TSource>, ICollection<TSource>, IEnumerable<TSource>, IEnumerable, IReadOnlyList<TSource>, IReadOnlyCollection<TSource>
	{
		private readonly IList<TSource> _source;

		private readonly int _minIndexInclusive;

		private readonly int _maxIndexInclusive;

		public int Count => GetAdjustedCount(_minIndexInclusive, _maxIndexInclusive, _source.Count);

		public TSource this[int index]
		{
			get
			{
				if ((uint)index >= (uint)Count)
				{
					ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.index);
				}
				return _source[_minIndexInclusive + index];
			}
			set
			{
				ThrowHelper.ThrowNotSupportedException();
			}
		}

		public bool IsReadOnly => true;

		public IListSkipTakeIterator(IList<TSource> source, int minIndexInclusive, int maxIndexInclusive)
		{
			_source = source;
			_minIndexInclusive = minIndexInclusive;
			_maxIndexInclusive = maxIndexInclusive;
		}

		private protected override Iterator<TSource> Clone()
		{
			return new IListSkipTakeIterator<TSource>(_source, _minIndexInclusive, _maxIndexInclusive);
		}

		public override bool MoveNext()
		{
			int num = _state - 1;
			if ((uint)num <= (uint)(_maxIndexInclusive - _minIndexInclusive) && num < _source.Count - _minIndexInclusive)
			{
				_current = _source[_minIndexInclusive + num];
				_state++;
				return true;
			}
			Dispose();
			return false;
		}

		public override IEnumerable<TResult> Select<TResult>(Func<TSource, TResult> selector)
		{
			return new IListSkipTakeSelectIterator<TSource, TResult>(_source, selector, _minIndexInclusive, _maxIndexInclusive);
		}

		public override Iterator<TSource> Skip(int count)
		{
			int num = _minIndexInclusive + count;
			if ((uint)num <= (uint)_maxIndexInclusive)
			{
				return new IListSkipTakeIterator<TSource>(_source, num, _maxIndexInclusive);
			}
			return null;
		}

		public override Iterator<TSource> Take(int count)
		{
			int num = _minIndexInclusive + count - 1;
			if ((uint)num < (uint)_maxIndexInclusive)
			{
				return new IListSkipTakeIterator<TSource>(_source, _minIndexInclusive, num);
			}
			return this;
		}

		public override TSource TryGetElementAt(int index, out bool found)
		{
			if ((uint)index <= (uint)(_maxIndexInclusive - _minIndexInclusive) && index < _source.Count - _minIndexInclusive)
			{
				found = true;
				return _source[_minIndexInclusive + index];
			}
			found = false;
			return default(TSource);
		}

		public override TSource TryGetFirst(out bool found)
		{
			if (_source.Count > _minIndexInclusive)
			{
				found = true;
				return _source[_minIndexInclusive];
			}
			found = false;
			return default(TSource);
		}

		public override TSource TryGetLast(out bool found)
		{
			int num = _source.Count - 1;
			if (num >= _minIndexInclusive)
			{
				found = true;
				return _source[Math.Min(num, _maxIndexInclusive)];
			}
			found = false;
			return default(TSource);
		}

		private static int GetAdjustedCount(int minIndexInclusive, int maxIndexInclusive, int sourceCount)
		{
			if (sourceCount <= minIndexInclusive)
			{
				return 0;
			}
			return Math.Min(sourceCount - 1, maxIndexInclusive) - minIndexInclusive + 1;
		}

		public override int GetCount(bool onlyIfCheap)
		{
			return Count;
		}

		public override TSource[] ToArray()
		{
			int count = Count;
			if (count == 0)
			{
				return Array.Empty<TSource>();
			}
			TSource[] array = new TSource[count];
			Fill(_source, array, _minIndexInclusive);
			return array;
		}

		public override List<TSource> ToList()
		{
			int count = Count;
			List<TSource> list = new List<TSource>();
			if (count != 0)
			{
				Fill(_source, SetCountAndGetSpan(list, count), _minIndexInclusive);
			}
			return list;
		}

		public void CopyTo(TSource[] array, int arrayIndex)
		{
			Fill(_source, array.AsSpan(arrayIndex, Count), _minIndexInclusive);
		}

		private static void Fill(IList<TSource> source, Span<TSource> destination, int sourceIndex)
		{
			if (source.TryGetSpan(out var span))
			{
				span.Slice(sourceIndex, destination.Length).CopyTo(destination);
				return;
			}
			int num = 0;
			while (num < destination.Length)
			{
				destination[num] = source[sourceIndex];
				num++;
				sourceIndex++;
			}
		}

		public override bool Contains(TSource item)
		{
			return IndexOf(item) >= 0;
		}

		public int IndexOf(TSource item)
		{
			IList<TSource> source = _source;
			if (source.TryGetSpan(out var span))
			{
				int minIndexInclusive = _minIndexInclusive;
				if (minIndexInclusive < span.Length)
				{
					return span.Slice(minIndexInclusive, GetAdjustedCount(minIndexInclusive, _maxIndexInclusive, span.Length)).IndexOf(item, null);
				}
			}
			else
			{
				int num = _minIndexInclusive + Count;
				for (int i = _minIndexInclusive; i < num; i++)
				{
					if (EqualityComparer<TSource>.Default.Equals(source[i], item))
					{
						return i - _minIndexInclusive;
					}
				}
			}
			return -1;
		}

		void ICollection<TSource>.Add(TSource item)
		{
			ThrowHelper.ThrowNotSupportedException();
		}

		void ICollection<TSource>.Clear()
		{
			ThrowHelper.ThrowNotSupportedException();
		}

		void IList<TSource>.Insert(int index, TSource item)
		{
			ThrowHelper.ThrowNotSupportedException();
		}

		bool ICollection<TSource>.Remove(TSource item)
		{
			return ThrowHelper.ThrowNotSupportedException_Boolean();
		}

		void IList<TSource>.RemoveAt(int index)
		{
			ThrowHelper.ThrowNotSupportedException();
		}
	}

	private sealed class IEnumerableSkipTakeIterator<TSource> : Iterator<TSource>
	{
		private readonly IEnumerable<TSource> _source;

		private readonly int _minIndexInclusive;

		private readonly int _maxIndexInclusive;

		private IEnumerator<TSource> _enumerator;

		private bool HasLimit => _maxIndexInclusive != -1;

		private int Limit => _maxIndexInclusive + 1 - _minIndexInclusive;

		internal IEnumerableSkipTakeIterator(IEnumerable<TSource> source, int minIndexInclusive, int maxIndexInclusive)
		{
			_source = source;
			_minIndexInclusive = minIndexInclusive;
			_maxIndexInclusive = maxIndexInclusive;
		}

		private protected override Iterator<TSource> Clone()
		{
			return new IEnumerableSkipTakeIterator<TSource>(_source, _minIndexInclusive, _maxIndexInclusive);
		}

		public override void Dispose()
		{
			if (_enumerator != null)
			{
				_enumerator.Dispose();
				_enumerator = null;
			}
			base.Dispose();
		}

		public override int GetCount(bool onlyIfCheap)
		{
			if (onlyIfCheap)
			{
				return -1;
			}
			if (!HasLimit)
			{
				return Math.Max(_source.Count() - _minIndexInclusive, 0);
			}
			using IEnumerator<TSource> en = _source.GetEnumerator();
			return Math.Max((int)SkipAndCount((uint)(_maxIndexInclusive + 1), en) - _minIndexInclusive, 0);
		}

		public override bool MoveNext()
		{
			int num = _state - 3;
			if (num < -2)
			{
				Dispose();
				return false;
			}
			int state = _state;
			if (state != 1)
			{
				if (state != 2)
				{
					goto IL_0054;
				}
			}
			else
			{
				_enumerator = _source.GetEnumerator();
				_state = 2;
			}
			if (SkipBeforeFirst(_enumerator))
			{
				_state = 3;
				goto IL_0054;
			}
			goto IL_009b;
			IL_009b:
			Dispose();
			return false;
			IL_0054:
			if ((!HasLimit || num < Limit) && _enumerator.MoveNext())
			{
				if (HasLimit)
				{
					_state++;
				}
				_current = _enumerator.Current;
				return true;
			}
			goto IL_009b;
		}

		public override Iterator<TSource> Skip(int count)
		{
			int num = _minIndexInclusive + count;
			if (!HasLimit)
			{
				if (num < 0)
				{
					return new IEnumerableSkipTakeIterator<TSource>(this, count, -1);
				}
			}
			else if ((uint)num > (uint)_maxIndexInclusive)
			{
				return null;
			}
			return new IEnumerableSkipTakeIterator<TSource>(_source, num, _maxIndexInclusive);
		}

		public override Iterator<TSource> Take(int count)
		{
			int num = _minIndexInclusive + count - 1;
			if (!HasLimit)
			{
				if (num < 0)
				{
					return new IEnumerableSkipTakeIterator<TSource>(this, 0, count - 1);
				}
			}
			else if ((uint)num >= (uint)_maxIndexInclusive)
			{
				return this;
			}
			return new IEnumerableSkipTakeIterator<TSource>(_source, _minIndexInclusive, num);
		}

		public override TSource TryGetElementAt(int index, out bool found)
		{
			if (index >= 0 && (!HasLimit || index < Limit))
			{
				if (_source is Iterator<TSource> iterator)
				{
					return iterator.TryGetElementAt(_minIndexInclusive + index, out found);
				}
				using IEnumerator<TSource> enumerator = _source.GetEnumerator();
				if (SkipBefore(_minIndexInclusive + index, enumerator) && enumerator.MoveNext())
				{
					found = true;
					return enumerator.Current;
				}
			}
			found = false;
			return default(TSource);
		}

		public override TSource TryGetFirst(out bool found)
		{
			if (_source is Iterator<TSource> iterator)
			{
				return iterator.TryGetElementAt(_minIndexInclusive, out found);
			}
			using (IEnumerator<TSource> enumerator = _source.GetEnumerator())
			{
				if (SkipBeforeFirst(enumerator) && enumerator.MoveNext())
				{
					found = true;
					return enumerator.Current;
				}
			}
			found = false;
			return default(TSource);
		}

		public override TSource TryGetLast(out bool found)
		{
			if (_source is Iterator<TSource> iterator)
			{
				int count = iterator.GetCount(onlyIfCheap: true);
				if (count > _minIndexInclusive)
				{
					if ((uint)count > (uint)_maxIndexInclusive)
					{
						return iterator.TryGetElementAt(_maxIndexInclusive, out found);
					}
					return iterator.TryGetLast(out found);
				}
			}
			using (IEnumerator<TSource> enumerator = _source.GetEnumerator())
			{
				if (SkipBeforeFirst(enumerator) && enumerator.MoveNext())
				{
					int num = Limit - 1;
					int num2 = ((!HasLimit) ? int.MinValue : 0);
					TSource current;
					do
					{
						num--;
						current = enumerator.Current;
					}
					while (num >= num2 && enumerator.MoveNext());
					found = true;
					return current;
				}
			}
			found = false;
			return default(TSource);
		}

		public override TSource[] ToArray()
		{
			using (IEnumerator<TSource> enumerator = _source.GetEnumerator())
			{
				if (SkipBeforeFirst(enumerator) && enumerator.MoveNext())
				{
					int num = Limit - 1;
					int num2 = ((!HasLimit) ? int.MinValue : 0);
					SegmentedArrayBuilder<TSource>.ScratchBuffer buffer = default(SegmentedArrayBuilder<TSource>.ScratchBuffer);
					SegmentedArrayBuilder<TSource> segmentedArrayBuilder = new SegmentedArrayBuilder<TSource>(global::_003CPrivateImplementationDetails_003E.InlineArrayAsSpan<SegmentedArrayBuilder<TSource>.ScratchBuffer, TSource>(ref buffer, 8));
					do
					{
						num--;
						segmentedArrayBuilder.Add(enumerator.Current);
					}
					while (num >= num2 && enumerator.MoveNext());
					TSource[] result = segmentedArrayBuilder.ToArray();
					segmentedArrayBuilder.Dispose();
					return result;
				}
			}
			return Array.Empty<TSource>();
		}

		public override List<TSource> ToList()
		{
			using (IEnumerator<TSource> enumerator = _source.GetEnumerator())
			{
				if (SkipBeforeFirst(enumerator) && enumerator.MoveNext())
				{
					int num = Limit - 1;
					int num2 = ((!HasLimit) ? int.MinValue : 0);
					SegmentedArrayBuilder<TSource>.ScratchBuffer buffer = default(SegmentedArrayBuilder<TSource>.ScratchBuffer);
					SegmentedArrayBuilder<TSource> segmentedArrayBuilder = new SegmentedArrayBuilder<TSource>(global::_003CPrivateImplementationDetails_003E.InlineArrayAsSpan<SegmentedArrayBuilder<TSource>.ScratchBuffer, TSource>(ref buffer, 8));
					do
					{
						num--;
						segmentedArrayBuilder.Add(enumerator.Current);
					}
					while (num >= num2 && enumerator.MoveNext());
					List<TSource> result = segmentedArrayBuilder.ToList();
					segmentedArrayBuilder.Dispose();
					return result;
				}
			}
			return new List<TSource>();
		}

		private bool SkipBeforeFirst(IEnumerator<TSource> en)
		{
			return SkipBefore(_minIndexInclusive, en);
		}

		private static bool SkipBefore(int index, IEnumerator<TSource> en)
		{
			return SkipAndCount(index, en) == index;
		}

		private static int SkipAndCount(int index, IEnumerator<TSource> en)
		{
			return (int)SkipAndCount((uint)index, en);
		}

		private static uint SkipAndCount(uint index, IEnumerator<TSource> en)
		{
			for (uint num = 0u; num < index; num++)
			{
				if (!en.MoveNext())
				{
					return num;
				}
			}
			return index;
		}
	}

	private abstract class UnionIterator<TSource> : Iterator<TSource>
	{
		internal readonly IEqualityComparer<TSource> _comparer;

		private IEnumerator<TSource> _enumerator;

		private HashSet<TSource> _set;

		protected UnionIterator(IEqualityComparer<TSource> comparer)
		{
			_comparer = comparer;
		}

		public sealed override void Dispose()
		{
			if (_enumerator != null)
			{
				_enumerator.Dispose();
				_enumerator = null;
				_set = null;
			}
			base.Dispose();
		}

		internal abstract IEnumerable<TSource> GetEnumerable(int index);

		internal abstract UnionIterator<TSource> Union(IEnumerable<TSource> next);

		private void SetEnumerator(IEnumerator<TSource> enumerator)
		{
			_enumerator?.Dispose();
			_enumerator = enumerator;
		}

		private void StoreFirst()
		{
			HashSet<TSource> hashSet = new HashSet<TSource>(7, _comparer);
			TSource current = _enumerator.Current;
			hashSet.Add(current);
			_current = current;
			_set = hashSet;
		}

		private bool GetNext()
		{
			HashSet<TSource> set = _set;
			while (_enumerator.MoveNext())
			{
				TSource current = _enumerator.Current;
				if (set.Add(current))
				{
					_current = current;
					return true;
				}
			}
			return false;
		}

		public sealed override bool MoveNext()
		{
			if (_state == 1)
			{
				for (IEnumerable<TSource> enumerable = GetEnumerable(0); enumerable != null; enumerable = GetEnumerable(_state - 1))
				{
					IEnumerator<TSource> enumerator = enumerable.GetEnumerator();
					SetEnumerator(enumerator);
					_state++;
					if (enumerator.MoveNext())
					{
						StoreFirst();
						return true;
					}
				}
			}
			else if (_state > 0)
			{
				while (true)
				{
					if (GetNext())
					{
						return true;
					}
					IEnumerable<TSource> enumerable2 = GetEnumerable(_state - 1);
					if (enumerable2 == null)
					{
						break;
					}
					SetEnumerator(enumerable2.GetEnumerator());
					_state++;
				}
			}
			Dispose();
			return false;
		}

		private HashSet<TSource> FillSet()
		{
			HashSet<TSource> hashSet = new HashSet<TSource>(_comparer);
			int num = 0;
			while (true)
			{
				IEnumerable<TSource> enumerable = GetEnumerable(num);
				if (enumerable == null)
				{
					break;
				}
				hashSet.UnionWith(enumerable);
				num++;
			}
			return hashSet;
		}

		public override TSource[] ToArray()
		{
			return ICollectionToArray(FillSet());
		}

		public override List<TSource> ToList()
		{
			return new List<TSource>(FillSet());
		}

		public override int GetCount(bool onlyIfCheap)
		{
			if (!onlyIfCheap)
			{
				return FillSet().Count;
			}
			return -1;
		}

		public override TSource TryGetFirst(out bool found)
		{
			int num = 0;
			IEnumerable<TSource> enumerable;
			while ((enumerable = GetEnumerable(num)) != null)
			{
				TSource result = enumerable.TryGetFirst(out found);
				if (found)
				{
					return result;
				}
				num++;
			}
			found = false;
			return default(TSource);
		}

		public override bool Contains(TSource value)
		{
			if (_comparer == null)
			{
				int num = 0;
				IEnumerable<TSource> enumerable;
				while ((enumerable = GetEnumerable(num)) != null)
				{
					if (enumerable.Contains(value))
					{
						return true;
					}
					num++;
				}
				return false;
			}
			return base.Contains(value);
		}
	}

	private sealed class UnionIterator2<TSource> : UnionIterator<TSource>
	{
		private readonly IEnumerable<TSource> _first;

		private readonly IEnumerable<TSource> _second;

		public UnionIterator2(IEnumerable<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource> comparer)
			: base(comparer)
		{
			_first = first;
			_second = second;
		}

		private protected override Iterator<TSource> Clone()
		{
			return new UnionIterator2<TSource>(_first, _second, _comparer);
		}

		internal override IEnumerable<TSource> GetEnumerable(int index)
		{
			return index switch
			{
				0 => _first, 
				1 => _second, 
				_ => null, 
			};
		}

		internal override UnionIterator<TSource> Union(IEnumerable<TSource> next)
		{
			return new UnionIteratorN<TSource>(new SingleLinkedNode<IEnumerable<TSource>>(_first).Add(_second).Add(next), 2, _comparer);
		}
	}

	private sealed class UnionIteratorN<TSource> : UnionIterator<TSource>
	{
		private readonly SingleLinkedNode<IEnumerable<TSource>> _sources;

		private readonly int _headIndex;

		public UnionIteratorN(SingleLinkedNode<IEnumerable<TSource>> sources, int headIndex, IEqualityComparer<TSource> comparer)
			: base(comparer)
		{
			_sources = sources;
			_headIndex = headIndex;
		}

		private protected override Iterator<TSource> Clone()
		{
			return new UnionIteratorN<TSource>(_sources, _headIndex, _comparer);
		}

		internal override IEnumerable<TSource> GetEnumerable(int index)
		{
			if (index <= _headIndex)
			{
				return _sources.GetNode(_headIndex - index).Item;
			}
			return null;
		}

		internal override UnionIterator<TSource> Union(IEnumerable<TSource> next)
		{
			if (_headIndex == 2147483645)
			{
				return new UnionIterator2<TSource>(this, next, _comparer);
			}
			return new UnionIteratorN<TSource>(_sources.Add(next), _headIndex + 1, _comparer);
		}
	}

	private sealed class IEnumerableWhereIterator<TSource> : Iterator<TSource>
	{
		private readonly IEnumerable<TSource> _source;

		private readonly Func<TSource, bool> _predicate;

		private IEnumerator<TSource> _enumerator;

		public IEnumerableWhereIterator(IEnumerable<TSource> source, Func<TSource, bool> predicate)
		{
			_source = source;
			_predicate = predicate;
		}

		private protected override Iterator<TSource> Clone()
		{
			return new IEnumerableWhereIterator<TSource>(_source, _predicate);
		}

		public override void Dispose()
		{
			if (_enumerator != null)
			{
				_enumerator.Dispose();
				_enumerator = null;
			}
			base.Dispose();
		}

		public override bool MoveNext()
		{
			int state = _state;
			if (state != 1)
			{
				if (state != 2)
				{
					goto IL_0061;
				}
			}
			else
			{
				_enumerator = _source.GetEnumerator();
				_state = 2;
			}
			while (_enumerator.MoveNext())
			{
				TSource current = _enumerator.Current;
				if (_predicate(current))
				{
					_current = current;
					return true;
				}
			}
			Dispose();
			goto IL_0061;
			IL_0061:
			return false;
		}

		public override IEnumerable<TResult> Select<TResult>(Func<TSource, TResult> selector)
		{
			return new IEnumerableWhereSelectIterator<TSource, TResult>(_source, _predicate, selector);
		}

		public override IEnumerable<TSource> Where(Func<TSource, bool> predicate)
		{
			return new IEnumerableWhereIterator<TSource>(_source, Utilities.CombinePredicates(_predicate, predicate));
		}

		public override int GetCount(bool onlyIfCheap)
		{
			if (onlyIfCheap)
			{
				return -1;
			}
			int num = 0;
			foreach (TSource item in _source)
			{
				if (_predicate(item))
				{
					num = checked(num + 1);
				}
			}
			return num;
		}

		public override TSource[] ToArray()
		{
			SegmentedArrayBuilder<TSource>.ScratchBuffer buffer = default(SegmentedArrayBuilder<TSource>.ScratchBuffer);
			SegmentedArrayBuilder<TSource> segmentedArrayBuilder = new SegmentedArrayBuilder<TSource>(global::_003CPrivateImplementationDetails_003E.InlineArrayAsSpan<SegmentedArrayBuilder<TSource>.ScratchBuffer, TSource>(ref buffer, 8));
			Func<TSource, bool> predicate = _predicate;
			foreach (TSource item in _source)
			{
				if (predicate(item))
				{
					segmentedArrayBuilder.Add(item);
				}
			}
			TSource[] result = segmentedArrayBuilder.ToArray();
			segmentedArrayBuilder.Dispose();
			return result;
		}

		public override List<TSource> ToList()
		{
			SegmentedArrayBuilder<TSource>.ScratchBuffer buffer = default(SegmentedArrayBuilder<TSource>.ScratchBuffer);
			SegmentedArrayBuilder<TSource> segmentedArrayBuilder = new SegmentedArrayBuilder<TSource>(global::_003CPrivateImplementationDetails_003E.InlineArrayAsSpan<SegmentedArrayBuilder<TSource>.ScratchBuffer, TSource>(ref buffer, 8));
			Func<TSource, bool> predicate = _predicate;
			foreach (TSource item in _source)
			{
				if (predicate(item))
				{
					segmentedArrayBuilder.Add(item);
				}
			}
			List<TSource> result = segmentedArrayBuilder.ToList();
			segmentedArrayBuilder.Dispose();
			return result;
		}

		public override TSource TryGetFirst(out bool found)
		{
			Func<TSource, bool> predicate = _predicate;
			foreach (TSource item in _source)
			{
				if (predicate(item))
				{
					found = true;
					return item;
				}
			}
			found = false;
			return default(TSource);
		}

		public override TSource TryGetLast(out bool found)
		{
			using IEnumerator<TSource> enumerator = _source.GetEnumerator();
			if (enumerator.MoveNext())
			{
				Func<TSource, bool> predicate = _predicate;
				TSource val = default(TSource);
				do
				{
					TSource current = enumerator.Current;
					if (!predicate(current))
					{
						continue;
					}
					val = current;
					found = true;
					while (enumerator.MoveNext())
					{
						current = enumerator.Current;
						if (predicate(current))
						{
							val = current;
						}
					}
					return val;
				}
				while (enumerator.MoveNext());
			}
			found = false;
			return default(TSource);
		}

		public override TSource TryGetElementAt(int index, out bool found)
		{
			if (index >= 0)
			{
				Func<TSource, bool> predicate = _predicate;
				foreach (TSource item in _source)
				{
					if (predicate(item))
					{
						if (index == 0)
						{
							found = true;
							return item;
						}
						index--;
					}
				}
			}
			found = false;
			return default(TSource);
		}

		public override bool Contains(TSource value)
		{
			Func<TSource, bool> predicate = _predicate;
			foreach (TSource item in _source)
			{
				if (predicate(item) && EqualityComparer<TSource>.Default.Equals(item, value))
				{
					return true;
				}
			}
			return false;
		}
	}

	private sealed class ArrayWhereIterator<TSource> : Iterator<TSource>
	{
		private readonly TSource[] _source;

		private readonly Func<TSource, bool> _predicate;

		public ArrayWhereIterator(TSource[] source, Func<TSource, bool> predicate)
		{
			_source = source;
			_predicate = predicate;
		}

		private protected override Iterator<TSource> Clone()
		{
			return new ArrayWhereIterator<TSource>(_source, _predicate);
		}

		public override bool MoveNext()
		{
			int num = _state - 1;
			TSource[] source = _source;
			while ((uint)num < (uint)source.Length)
			{
				TSource val = source[num];
				num = _state++;
				if (_predicate(val))
				{
					_current = val;
					return true;
				}
			}
			Dispose();
			return false;
		}

		public override IEnumerable<TResult> Select<TResult>(Func<TSource, TResult> selector)
		{
			return new ArrayWhereSelectIterator<TSource, TResult>(_source, _predicate, selector);
		}

		public override IEnumerable<TSource> Where(Func<TSource, bool> predicate)
		{
			return new ArrayWhereIterator<TSource>(_source, Utilities.CombinePredicates(_predicate, predicate));
		}

		public override int GetCount(bool onlyIfCheap)
		{
			return GetCount(onlyIfCheap, _source, _predicate);
		}

		public static int GetCount(bool onlyIfCheap, ReadOnlySpan<TSource> source, Func<TSource, bool> predicate)
		{
			if (onlyIfCheap)
			{
				return -1;
			}
			int num = 0;
			ReadOnlySpan<TSource> readOnlySpan = source;
			for (int i = 0; i < readOnlySpan.Length; i++)
			{
				TSource arg = readOnlySpan[i];
				if (predicate(arg))
				{
					num = checked(num + 1);
				}
			}
			return num;
		}

		public override TSource[] ToArray()
		{
			return ToArray(_source, _predicate);
		}

		public static TSource[] ToArray(ReadOnlySpan<TSource> source, Func<TSource, bool> predicate)
		{
			SegmentedArrayBuilder<TSource>.ScratchBuffer buffer = default(SegmentedArrayBuilder<TSource>.ScratchBuffer);
			SegmentedArrayBuilder<TSource> segmentedArrayBuilder = new SegmentedArrayBuilder<TSource>(global::_003CPrivateImplementationDetails_003E.InlineArrayAsSpan<SegmentedArrayBuilder<TSource>.ScratchBuffer, TSource>(ref buffer, 8));
			ReadOnlySpan<TSource> readOnlySpan = source;
			for (int i = 0; i < readOnlySpan.Length; i++)
			{
				TSource val = readOnlySpan[i];
				if (predicate(val))
				{
					segmentedArrayBuilder.Add(val);
				}
			}
			TSource[] result = segmentedArrayBuilder.ToArray();
			segmentedArrayBuilder.Dispose();
			return result;
		}

		public override List<TSource> ToList()
		{
			return ToList(_source, _predicate);
		}

		public static List<TSource> ToList(ReadOnlySpan<TSource> source, Func<TSource, bool> predicate)
		{
			SegmentedArrayBuilder<TSource>.ScratchBuffer buffer = default(SegmentedArrayBuilder<TSource>.ScratchBuffer);
			SegmentedArrayBuilder<TSource> segmentedArrayBuilder = new SegmentedArrayBuilder<TSource>(global::_003CPrivateImplementationDetails_003E.InlineArrayAsSpan<SegmentedArrayBuilder<TSource>.ScratchBuffer, TSource>(ref buffer, 8));
			ReadOnlySpan<TSource> readOnlySpan = source;
			for (int i = 0; i < readOnlySpan.Length; i++)
			{
				TSource val = readOnlySpan[i];
				if (predicate(val))
				{
					segmentedArrayBuilder.Add(val);
				}
			}
			List<TSource> result = segmentedArrayBuilder.ToList();
			segmentedArrayBuilder.Dispose();
			return result;
		}

		public override TSource TryGetFirst(out bool found)
		{
			Func<TSource, bool> predicate = _predicate;
			TSource[] source = _source;
			foreach (TSource val in source)
			{
				if (predicate(val))
				{
					found = true;
					return val;
				}
			}
			found = false;
			return default(TSource);
		}

		public override TSource TryGetLast(out bool found)
		{
			TSource[] source = _source;
			Func<TSource, bool> predicate = _predicate;
			for (int num = source.Length - 1; num >= 0; num--)
			{
				if (predicate(source[num]))
				{
					found = true;
					return source[num];
				}
			}
			found = false;
			return default(TSource);
		}

		public override TSource TryGetElementAt(int index, out bool found)
		{
			if (index >= 0)
			{
				Func<TSource, bool> predicate = _predicate;
				TSource[] source = _source;
				foreach (TSource val in source)
				{
					if (predicate(val))
					{
						if (index == 0)
						{
							found = true;
							return val;
						}
						index--;
					}
				}
			}
			found = false;
			return default(TSource);
		}

		public override bool Contains(TSource value)
		{
			Func<TSource, bool> predicate = _predicate;
			TSource[] source = _source;
			foreach (TSource val in source)
			{
				if (predicate(val) && EqualityComparer<TSource>.Default.Equals(val, value))
				{
					return true;
				}
			}
			return false;
		}
	}

	private sealed class ListWhereIterator<TSource> : Iterator<TSource>
	{
		private readonly List<TSource> _source;

		private readonly Func<TSource, bool> _predicate;

		private List<TSource>.Enumerator _enumerator;

		public ListWhereIterator(List<TSource> source, Func<TSource, bool> predicate)
		{
			_source = source;
			_predicate = predicate;
		}

		private protected override Iterator<TSource> Clone()
		{
			return new ListWhereIterator<TSource>(_source, _predicate);
		}

		public override bool MoveNext()
		{
			int state = _state;
			if (state != 1)
			{
				if (state != 2)
				{
					goto IL_0061;
				}
			}
			else
			{
				_enumerator = _source.GetEnumerator();
				_state = 2;
			}
			while (_enumerator.MoveNext())
			{
				TSource current = _enumerator.Current;
				if (_predicate(current))
				{
					_current = current;
					return true;
				}
			}
			Dispose();
			goto IL_0061;
			IL_0061:
			return false;
		}

		public override IEnumerable<TResult> Select<TResult>(Func<TSource, TResult> selector)
		{
			return new ListWhereSelectIterator<TSource, TResult>(_source, _predicate, selector);
		}

		public override IEnumerable<TSource> Where(Func<TSource, bool> predicate)
		{
			return new ListWhereIterator<TSource>(_source, Utilities.CombinePredicates(_predicate, predicate));
		}

		public override int GetCount(bool onlyIfCheap)
		{
			return ArrayWhereIterator<TSource>.GetCount(onlyIfCheap, CollectionsMarshal.AsSpan(_source), _predicate);
		}

		public override TSource[] ToArray()
		{
			return ArrayWhereIterator<TSource>.ToArray(CollectionsMarshal.AsSpan(_source), _predicate);
		}

		public override List<TSource> ToList()
		{
			return ArrayWhereIterator<TSource>.ToList(CollectionsMarshal.AsSpan(_source), _predicate);
		}

		public override TSource TryGetFirst(out bool found)
		{
			Func<TSource, bool> predicate = _predicate;
			Span<TSource> span = CollectionsMarshal.AsSpan(_source);
			for (int i = 0; i < span.Length; i++)
			{
				TSource val = span[i];
				if (predicate(val))
				{
					found = true;
					return val;
				}
			}
			found = false;
			return default(TSource);
		}

		public override TSource TryGetLast(out bool found)
		{
			ReadOnlySpan<TSource> readOnlySpan = CollectionsMarshal.AsSpan(_source);
			Func<TSource, bool> predicate = _predicate;
			for (int num = readOnlySpan.Length - 1; num >= 0; num--)
			{
				if (predicate(readOnlySpan[num]))
				{
					found = true;
					return readOnlySpan[num];
				}
			}
			found = false;
			return default(TSource);
		}

		public override TSource TryGetElementAt(int index, out bool found)
		{
			if (index >= 0)
			{
				Func<TSource, bool> predicate = _predicate;
				Span<TSource> span = CollectionsMarshal.AsSpan(_source);
				for (int i = 0; i < span.Length; i++)
				{
					TSource val = span[i];
					if (predicate(val))
					{
						if (index == 0)
						{
							found = true;
							return val;
						}
						index--;
					}
				}
			}
			found = false;
			return default(TSource);
		}

		public override bool Contains(TSource value)
		{
			Func<TSource, bool> predicate = _predicate;
			foreach (TSource item in _source)
			{
				if (predicate(item) && EqualityComparer<TSource>.Default.Equals(item, value))
				{
					return true;
				}
			}
			return false;
		}
	}

	private sealed class ArrayWhereSelectIterator<TSource, TResult> : Iterator<TResult>
	{
		private readonly TSource[] _source;

		private readonly Func<TSource, bool> _predicate;

		private readonly Func<TSource, TResult> _selector;

		public ArrayWhereSelectIterator(TSource[] source, Func<TSource, bool> predicate, Func<TSource, TResult> selector)
		{
			_source = source;
			_predicate = predicate;
			_selector = selector;
		}

		private protected override Iterator<TResult> Clone()
		{
			return new ArrayWhereSelectIterator<TSource, TResult>(_source, _predicate, _selector);
		}

		public override bool MoveNext()
		{
			int num = _state - 1;
			TSource[] source = _source;
			while ((uint)num < (uint)source.Length)
			{
				TSource arg = source[num];
				num = _state++;
				if (_predicate(arg))
				{
					_current = _selector(arg);
					return true;
				}
			}
			Dispose();
			return false;
		}

		public override IEnumerable<TResult2> Select<TResult2>(Func<TResult, TResult2> selector)
		{
			return new ArrayWhereSelectIterator<TSource, TResult2>(_source, _predicate, Utilities.CombineSelectors(_selector, selector));
		}

		public override int GetCount(bool onlyIfCheap)
		{
			return GetCount(onlyIfCheap, _source, _predicate, _selector);
		}

		public static int GetCount(bool onlyIfCheap, ReadOnlySpan<TSource> source, Func<TSource, bool> predicate, Func<TSource, TResult> selector)
		{
			if (onlyIfCheap)
			{
				return -1;
			}
			int num = 0;
			ReadOnlySpan<TSource> readOnlySpan = source;
			for (int i = 0; i < readOnlySpan.Length; i++)
			{
				TSource arg = readOnlySpan[i];
				if (predicate(arg))
				{
					selector(arg);
					num = checked(num + 1);
				}
			}
			return num;
		}

		public override TResult[] ToArray()
		{
			return ToArray(_source, _predicate, _selector);
		}

		public static TResult[] ToArray(ReadOnlySpan<TSource> source, Func<TSource, bool> predicate, Func<TSource, TResult> selector)
		{
			SegmentedArrayBuilder<TResult>.ScratchBuffer buffer = default(SegmentedArrayBuilder<TResult>.ScratchBuffer);
			SegmentedArrayBuilder<TResult> segmentedArrayBuilder = new SegmentedArrayBuilder<TResult>(global::_003CPrivateImplementationDetails_003E.InlineArrayAsSpan<SegmentedArrayBuilder<TResult>.ScratchBuffer, TResult>(ref buffer, 8));
			ReadOnlySpan<TSource> readOnlySpan = source;
			for (int i = 0; i < readOnlySpan.Length; i++)
			{
				TSource arg = readOnlySpan[i];
				if (predicate(arg))
				{
					segmentedArrayBuilder.Add(selector(arg));
				}
			}
			TResult[] result = segmentedArrayBuilder.ToArray();
			segmentedArrayBuilder.Dispose();
			return result;
		}

		public override List<TResult> ToList()
		{
			return ToList(_source, _predicate, _selector);
		}

		public static List<TResult> ToList(ReadOnlySpan<TSource> source, Func<TSource, bool> predicate, Func<TSource, TResult> selector)
		{
			SegmentedArrayBuilder<TResult>.ScratchBuffer buffer = default(SegmentedArrayBuilder<TResult>.ScratchBuffer);
			SegmentedArrayBuilder<TResult> segmentedArrayBuilder = new SegmentedArrayBuilder<TResult>(global::_003CPrivateImplementationDetails_003E.InlineArrayAsSpan<SegmentedArrayBuilder<TResult>.ScratchBuffer, TResult>(ref buffer, 8));
			ReadOnlySpan<TSource> readOnlySpan = source;
			for (int i = 0; i < readOnlySpan.Length; i++)
			{
				TSource arg = readOnlySpan[i];
				if (predicate(arg))
				{
					segmentedArrayBuilder.Add(selector(arg));
				}
			}
			List<TResult> result = segmentedArrayBuilder.ToList();
			segmentedArrayBuilder.Dispose();
			return result;
		}

		public override TResult TryGetFirst(out bool found)
		{
			return TryGetFirst(_source, _predicate, _selector, out found);
		}

		public static TResult TryGetFirst(ReadOnlySpan<TSource> source, Func<TSource, bool> predicate, Func<TSource, TResult> selector, out bool found)
		{
			ReadOnlySpan<TSource> readOnlySpan = source;
			for (int i = 0; i < readOnlySpan.Length; i++)
			{
				TSource arg = readOnlySpan[i];
				if (predicate(arg))
				{
					found = true;
					return selector(arg);
				}
			}
			found = false;
			return default(TResult);
		}

		public override TResult TryGetLast(out bool found)
		{
			return TryGetLast(_source, _predicate, _selector, out found);
		}

		public static TResult TryGetLast(ReadOnlySpan<TSource> source, Func<TSource, bool> predicate, Func<TSource, TResult> selector, out bool found)
		{
			for (int num = source.Length - 1; num >= 0; num--)
			{
				if (predicate(source[num]))
				{
					found = true;
					return selector(source[num]);
				}
			}
			found = false;
			return default(TResult);
		}

		public override TResult TryGetElementAt(int index, out bool found)
		{
			return TryGetElementAt(_source, _predicate, _selector, index, out found);
		}

		public static TResult TryGetElementAt(ReadOnlySpan<TSource> source, Func<TSource, bool> predicate, Func<TSource, TResult> selector, int index, out bool found)
		{
			if (index >= 0)
			{
				ReadOnlySpan<TSource> readOnlySpan = source;
				for (int i = 0; i < readOnlySpan.Length; i++)
				{
					TSource arg = readOnlySpan[i];
					if (predicate(arg))
					{
						if (index == 0)
						{
							found = true;
							return selector(arg);
						}
						index--;
					}
				}
			}
			found = false;
			return default(TResult);
		}

		public override bool Contains(TResult value)
		{
			return Contains(_source, _predicate, _selector, value);
		}

		public static bool Contains(ReadOnlySpan<TSource> source, Func<TSource, bool> predicate, Func<TSource, TResult> selector, TResult value)
		{
			ReadOnlySpan<TSource> readOnlySpan = source;
			for (int i = 0; i < readOnlySpan.Length; i++)
			{
				TSource arg = readOnlySpan[i];
				if (predicate(arg) && EqualityComparer<TResult>.Default.Equals(selector(arg), value))
				{
					return true;
				}
			}
			return false;
		}
	}

	private sealed class ListWhereSelectIterator<TSource, TResult> : Iterator<TResult>
	{
		private readonly List<TSource> _source;

		private readonly Func<TSource, bool> _predicate;

		private readonly Func<TSource, TResult> _selector;

		private List<TSource>.Enumerator _enumerator;

		public ListWhereSelectIterator(List<TSource> source, Func<TSource, bool> predicate, Func<TSource, TResult> selector)
		{
			_source = source;
			_predicate = predicate;
			_selector = selector;
		}

		private protected override Iterator<TResult> Clone()
		{
			return new ListWhereSelectIterator<TSource, TResult>(_source, _predicate, _selector);
		}

		public override bool MoveNext()
		{
			int state = _state;
			if (state != 1)
			{
				if (state != 2)
				{
					goto IL_006c;
				}
			}
			else
			{
				_enumerator = _source.GetEnumerator();
				_state = 2;
			}
			while (_enumerator.MoveNext())
			{
				TSource current = _enumerator.Current;
				if (_predicate(current))
				{
					_current = _selector(current);
					return true;
				}
			}
			Dispose();
			goto IL_006c;
			IL_006c:
			return false;
		}

		public override IEnumerable<TResult2> Select<TResult2>(Func<TResult, TResult2> selector)
		{
			return new ListWhereSelectIterator<TSource, TResult2>(_source, _predicate, Utilities.CombineSelectors(_selector, selector));
		}

		public override int GetCount(bool onlyIfCheap)
		{
			return ArrayWhereSelectIterator<TSource, TResult>.GetCount(onlyIfCheap, CollectionsMarshal.AsSpan(_source), _predicate, _selector);
		}

		public override TResult[] ToArray()
		{
			return ArrayWhereSelectIterator<TSource, TResult>.ToArray(CollectionsMarshal.AsSpan(_source), _predicate, _selector);
		}

		public override List<TResult> ToList()
		{
			return ArrayWhereSelectIterator<TSource, TResult>.ToList(CollectionsMarshal.AsSpan(_source), _predicate, _selector);
		}

		public override TResult TryGetElementAt(int index, out bool found)
		{
			return ArrayWhereSelectIterator<TSource, TResult>.TryGetElementAt(CollectionsMarshal.AsSpan(_source), _predicate, _selector, index, out found);
		}

		public override TResult TryGetFirst(out bool found)
		{
			return ArrayWhereSelectIterator<TSource, TResult>.TryGetFirst(CollectionsMarshal.AsSpan(_source), _predicate, _selector, out found);
		}

		public override TResult TryGetLast(out bool found)
		{
			return ArrayWhereSelectIterator<TSource, TResult>.TryGetLast(CollectionsMarshal.AsSpan(_source), _predicate, _selector, out found);
		}

		public override bool Contains(TResult value)
		{
			return ArrayWhereSelectIterator<TSource, TResult>.Contains(CollectionsMarshal.AsSpan(_source), _predicate, _selector, value);
		}
	}

	private sealed class IEnumerableWhereSelectIterator<TSource, TResult> : Iterator<TResult>
	{
		private readonly IEnumerable<TSource> _source;

		private readonly Func<TSource, bool> _predicate;

		private readonly Func<TSource, TResult> _selector;

		private IEnumerator<TSource> _enumerator;

		public IEnumerableWhereSelectIterator(IEnumerable<TSource> source, Func<TSource, bool> predicate, Func<TSource, TResult> selector)
		{
			_source = source;
			_predicate = predicate;
			_selector = selector;
		}

		private protected override Iterator<TResult> Clone()
		{
			return new IEnumerableWhereSelectIterator<TSource, TResult>(_source, _predicate, _selector);
		}

		public override void Dispose()
		{
			if (_enumerator != null)
			{
				_enumerator.Dispose();
				_enumerator = null;
			}
			base.Dispose();
		}

		public override bool MoveNext()
		{
			int state = _state;
			if (state != 1)
			{
				if (state != 2)
				{
					goto IL_006c;
				}
			}
			else
			{
				_enumerator = _source.GetEnumerator();
				_state = 2;
			}
			while (_enumerator.MoveNext())
			{
				TSource current = _enumerator.Current;
				if (_predicate(current))
				{
					_current = _selector(current);
					return true;
				}
			}
			Dispose();
			goto IL_006c;
			IL_006c:
			return false;
		}

		public override IEnumerable<TResult2> Select<TResult2>(Func<TResult, TResult2> selector)
		{
			return new IEnumerableWhereSelectIterator<TSource, TResult2>(_source, _predicate, Utilities.CombineSelectors(_selector, selector));
		}

		public override int GetCount(bool onlyIfCheap)
		{
			if (onlyIfCheap)
			{
				return -1;
			}
			int num = 0;
			foreach (TSource item in _source)
			{
				if (_predicate(item))
				{
					_selector(item);
					num = checked(num + 1);
				}
			}
			return num;
		}

		public override TResult[] ToArray()
		{
			SegmentedArrayBuilder<TResult>.ScratchBuffer buffer = default(SegmentedArrayBuilder<TResult>.ScratchBuffer);
			SegmentedArrayBuilder<TResult> segmentedArrayBuilder = new SegmentedArrayBuilder<TResult>(global::_003CPrivateImplementationDetails_003E.InlineArrayAsSpan<SegmentedArrayBuilder<TResult>.ScratchBuffer, TResult>(ref buffer, 8));
			Func<TSource, bool> predicate = _predicate;
			Func<TSource, TResult> selector = _selector;
			foreach (TSource item in _source)
			{
				if (predicate(item))
				{
					segmentedArrayBuilder.Add(selector(item));
				}
			}
			TResult[] result = segmentedArrayBuilder.ToArray();
			segmentedArrayBuilder.Dispose();
			return result;
		}

		public override List<TResult> ToList()
		{
			SegmentedArrayBuilder<TResult>.ScratchBuffer buffer = default(SegmentedArrayBuilder<TResult>.ScratchBuffer);
			SegmentedArrayBuilder<TResult> segmentedArrayBuilder = new SegmentedArrayBuilder<TResult>(global::_003CPrivateImplementationDetails_003E.InlineArrayAsSpan<SegmentedArrayBuilder<TResult>.ScratchBuffer, TResult>(ref buffer, 8));
			Func<TSource, bool> predicate = _predicate;
			Func<TSource, TResult> selector = _selector;
			foreach (TSource item in _source)
			{
				if (predicate(item))
				{
					segmentedArrayBuilder.Add(selector(item));
				}
			}
			List<TResult> result = segmentedArrayBuilder.ToList();
			segmentedArrayBuilder.Dispose();
			return result;
		}

		public override TResult TryGetFirst(out bool found)
		{
			Func<TSource, bool> predicate = _predicate;
			foreach (TSource item in _source)
			{
				if (predicate(item))
				{
					found = true;
					return _selector(item);
				}
			}
			found = false;
			return default(TResult);
		}

		public override TResult TryGetLast(out bool found)
		{
			using IEnumerator<TSource> enumerator = _source.GetEnumerator();
			if (enumerator.MoveNext())
			{
				Func<TSource, bool> predicate = _predicate;
				TSource val = default(TSource);
				do
				{
					TSource current = enumerator.Current;
					if (!predicate(current))
					{
						continue;
					}
					val = current;
					found = true;
					while (enumerator.MoveNext())
					{
						current = enumerator.Current;
						if (predicate(current))
						{
							val = current;
						}
					}
					return _selector(val);
				}
				while (enumerator.MoveNext());
			}
			found = false;
			return default(TResult);
		}

		public override TResult TryGetElementAt(int index, out bool found)
		{
			if (index >= 0)
			{
				Func<TSource, bool> predicate = _predicate;
				foreach (TSource item in _source)
				{
					if (predicate(item))
					{
						if (index == 0)
						{
							found = true;
							return _selector(item);
						}
						index--;
					}
				}
			}
			found = false;
			return default(TResult);
		}

		public override bool Contains(TResult value)
		{
			Func<TSource, bool> predicate = _predicate;
			foreach (TSource item in _source)
			{
				if (predicate(item) && EqualityComparer<TResult>.Default.Equals(_selector(item), value))
				{
					return true;
				}
			}
			return false;
		}
	}

	private sealed class SizeOptIListWhereIterator<TSource> : Iterator<TSource>
	{
		private readonly IList<TSource> _source;

		private readonly Func<TSource, bool> _predicate;

		private IEnumerator<TSource> _enumerator;

		public SizeOptIListWhereIterator(IList<TSource> source, Func<TSource, bool> predicate)
		{
			_source = source;
			_predicate = predicate;
		}

		private protected override Iterator<TSource> Clone()
		{
			return new SizeOptIListWhereIterator<TSource>(_source, _predicate);
		}

		public override bool MoveNext()
		{
			int state = _state;
			if (state != 1)
			{
				if (state != 2)
				{
					goto IL_0061;
				}
			}
			else
			{
				_enumerator = _source.GetEnumerator();
				_state = 2;
			}
			while (_enumerator.MoveNext())
			{
				TSource current = _enumerator.Current;
				if (_predicate(current))
				{
					_current = current;
					return true;
				}
			}
			Dispose();
			goto IL_0061;
			IL_0061:
			return false;
		}

		public override IEnumerable<TSource> Where(Func<TSource, bool> predicate)
		{
			return new SizeOptIListWhereIterator<TSource>(_source, Utilities.CombinePredicates(_predicate, predicate));
		}

		public override TSource[] ToArray()
		{
			SegmentedArrayBuilder<TSource>.ScratchBuffer buffer = default(SegmentedArrayBuilder<TSource>.ScratchBuffer);
			SegmentedArrayBuilder<TSource> segmentedArrayBuilder = new SegmentedArrayBuilder<TSource>(global::_003CPrivateImplementationDetails_003E.InlineArrayAsSpan<SegmentedArrayBuilder<TSource>.ScratchBuffer, TSource>(ref buffer, 8));
			foreach (TSource item in _source)
			{
				if (_predicate(item))
				{
					segmentedArrayBuilder.Add(item);
				}
			}
			TSource[] result = segmentedArrayBuilder.ToArray();
			segmentedArrayBuilder.Dispose();
			return result;
		}

		public override List<TSource> ToList()
		{
			SegmentedArrayBuilder<TSource>.ScratchBuffer buffer = default(SegmentedArrayBuilder<TSource>.ScratchBuffer);
			SegmentedArrayBuilder<TSource> segmentedArrayBuilder = new SegmentedArrayBuilder<TSource>(global::_003CPrivateImplementationDetails_003E.InlineArrayAsSpan<SegmentedArrayBuilder<TSource>.ScratchBuffer, TSource>(ref buffer, 8));
			foreach (TSource item in _source)
			{
				if (_predicate(item))
				{
					segmentedArrayBuilder.Add(item);
				}
			}
			List<TSource> result = segmentedArrayBuilder.ToList();
			segmentedArrayBuilder.Dispose();
			return result;
		}

		public override int GetCount(bool onlyIfCheap)
		{
			if (onlyIfCheap)
			{
				return -1;
			}
			int num = 0;
			foreach (TSource item in _source)
			{
				if (_predicate(item))
				{
					num = checked(num + 1);
				}
			}
			return num;
		}
	}

	public static TSource Aggregate<TSource>(this IEnumerable<TSource> source, Func<TSource, TSource, TSource> func)
	{
		if (source == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
		}
		if (func == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.func);
		}
		TSource val;
		if (source.TryGetSpan<TSource>(out var span))
		{
			if (span.IsEmpty)
			{
				ThrowHelper.ThrowNoElementsException();
			}
			val = span[0];
			for (int i = 1; i < span.Length; i++)
			{
				val = func(val, span[i]);
			}
		}
		else
		{
			using IEnumerator<TSource> enumerator = source.GetEnumerator();
			if (!enumerator.MoveNext())
			{
				ThrowHelper.ThrowNoElementsException();
			}
			val = enumerator.Current;
			while (enumerator.MoveNext())
			{
				val = func(val, enumerator.Current);
			}
		}
		return val;
	}

	public static TAccumulate Aggregate<TSource, TAccumulate>(this IEnumerable<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func)
	{
		if (source == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
		}
		if (func == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.func);
		}
		TAccumulate val = seed;
		if (source.TryGetSpan<TSource>(out var span))
		{
			ReadOnlySpan<TSource> readOnlySpan = span;
			for (int i = 0; i < readOnlySpan.Length; i++)
			{
				TSource arg = readOnlySpan[i];
				val = func(val, arg);
			}
		}
		else
		{
			foreach (TSource item in source)
			{
				val = func(val, item);
			}
		}
		return val;
	}

	public static bool Any<TSource>(this IEnumerable<TSource> source)
	{
		if (source == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
		}
		if (source is ICollection<TSource> collection)
		{
			return collection.Count != 0;
		}
		if (1 == 0)
		{
		}
		if (source is ICollection collection2)
		{
			return collection2.Count != 0;
		}
		using IEnumerator<TSource> enumerator = source.GetEnumerator();
		return enumerator.MoveNext();
	}

	public static bool Any<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
	{
		if (source == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
		}
		if (predicate == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.predicate);
		}
		if (source.TryGetSpan<TSource>(out var span))
		{
			ReadOnlySpan<TSource> readOnlySpan = span;
			for (int i = 0; i < readOnlySpan.Length; i++)
			{
				TSource arg = readOnlySpan[i];
				if (predicate(arg))
				{
					return true;
				}
			}
		}
		else
		{
			foreach (TSource item in source)
			{
				if (predicate(item))
				{
					return true;
				}
			}
		}
		return false;
	}

	public static bool All<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
	{
		if (source == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
		}
		if (predicate == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.predicate);
		}
		if (source.TryGetSpan<TSource>(out var span))
		{
			ReadOnlySpan<TSource> readOnlySpan = span;
			for (int i = 0; i < readOnlySpan.Length; i++)
			{
				TSource arg = readOnlySpan[i];
				if (!predicate(arg))
				{
					return false;
				}
			}
		}
		else
		{
			foreach (TSource item in source)
			{
				if (!predicate(item))
				{
					return false;
				}
			}
		}
		return true;
	}

	public static IEnumerable<TSource> Prepend<TSource>(this IEnumerable<TSource> source, TSource element)
	{
		if (source == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
		}
		if (!(source is AppendPrependIterator<TSource> appendPrependIterator))
		{
			return new AppendPrepend1Iterator<TSource>(source, element, appending: false);
		}
		return appendPrependIterator.Prepend(element);
	}

	public static IEnumerable<TResult> Cast<TResult>(this IEnumerable source)
	{
		if (source is IEnumerable<TResult> result)
		{
			return result;
		}
		if (source == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
		}
		if (source is ICollection source2)
		{
			return new CastICollectionIterator<TResult>(source2);
		}
		return CastIterator<TResult>(source);
	}

	private static IEnumerable<TResult> CastIterator<TResult>(IEnumerable source)
	{
		foreach (object item in source)
		{
			yield return (TResult)item;
		}
	}

	public static IEnumerable<TSource> Concat<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second)
	{
		if (first == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.first);
		}
		if (second == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.second);
		}
		if (IsEmptyArray(first))
		{
			return second;
		}
		if (IsEmptyArray(second))
		{
			return first;
		}
		if (!(first is ConcatIterator<TSource> concatIterator))
		{
			return new Concat2Iterator<TSource>(first, second);
		}
		return concatIterator.Concat(second);
	}

	public static bool Contains<TSource>(this IEnumerable<TSource> source, TSource value)
	{
		if (source is ICollection<TSource> collection)
		{
			return collection.Contains(value);
		}
		if (1 == 0)
		{
		}
		if (source == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
		}
		return ContainsIterate(source, value, null);
	}

	public static bool Contains<TSource>(this IEnumerable<TSource> source, TSource value, IEqualityComparer<TSource>? comparer)
	{
		if (source == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
		}
		if (source.TryGetSpan<TSource>(out var span))
		{
			return span.Contains(value, comparer);
		}
		return ContainsIterate(source, value, comparer);
	}

	private static bool ContainsIterate<TSource>(IEnumerable<TSource> source, TSource value, IEqualityComparer<TSource> comparer)
	{
		if (comparer == null)
		{
			if (typeof(TSource).IsValueType)
			{
				foreach (TSource item in source)
				{
					if (EqualityComparer<TSource>.Default.Equals(item, value))
					{
						return true;
					}
				}
				return false;
			}
			comparer = EqualityComparer<TSource>.Default;
		}
		foreach (TSource item2 in source)
		{
			if (comparer.Equals(item2, value))
			{
				return true;
			}
		}
		return false;
	}

	public static int Count<TSource>(this IEnumerable<TSource> source)
	{
		if (source == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
		}
		if (source is ICollection<TSource> collection)
		{
			return collection.Count;
		}
		if (source is Iterator<TSource> iterator)
		{
			return iterator.GetCount(onlyIfCheap: false);
		}
		if (source is ICollection collection2)
		{
			return collection2.Count;
		}
		int num = 0;
		using IEnumerator<TSource> enumerator = source.GetEnumerator();
		while (enumerator.MoveNext())
		{
			num = checked(num + 1);
		}
		return num;
	}

	public static int Count<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
	{
		if (source == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
		}
		if (predicate == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.predicate);
		}
		int num = 0;
		if (source.TryGetSpan<TSource>(out var span))
		{
			ReadOnlySpan<TSource> readOnlySpan = span;
			for (int i = 0; i < readOnlySpan.Length; i++)
			{
				TSource arg = readOnlySpan[i];
				if (predicate(arg))
				{
					num++;
				}
			}
		}
		else
		{
			foreach (TSource item in source)
			{
				if (predicate(item))
				{
					num = checked(num + 1);
				}
			}
		}
		return num;
	}

	public static bool TryGetNonEnumeratedCount<TSource>(this IEnumerable<TSource> source, out int count)
	{
		if (source == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
		}
		if (source is ICollection<TSource> collection)
		{
			count = collection.Count;
			return true;
		}
		if (source is Iterator<TSource> iterator)
		{
			int count2 = iterator.GetCount(onlyIfCheap: true);
			if (count2 >= 0)
			{
				count = count2;
				return true;
			}
		}
		if (source is ICollection collection2)
		{
			count = collection2.Count;
			return true;
		}
		count = 0;
		return false;
	}

	public static IEnumerable<TSource?> DefaultIfEmpty<TSource>(this IEnumerable<TSource> source)
	{
		return source.DefaultIfEmpty(default(TSource));
	}

	public static IEnumerable<TSource> DefaultIfEmpty<TSource>(this IEnumerable<TSource> source, TSource defaultValue)
	{
		if (source == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
		}
		if (source is TSource[] array && array.Length > 0)
		{
			return source;
		}
		return new DefaultIfEmptyIterator<TSource>(source, defaultValue);
	}

	public static IEnumerable<TSource> Distinct<TSource>(this IEnumerable<TSource> source)
	{
		return source.Distinct(null);
	}

	public static IEnumerable<TSource> Distinct<TSource>(this IEnumerable<TSource> source, IEqualityComparer<TSource>? comparer)
	{
		if (source == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
		}
		if (IsEmptyArray(source))
		{
			return Array.Empty<TSource>();
		}
		return new DistinctIterator<TSource>(source, comparer);
	}

	public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
	{
		return source.DistinctBy(keySelector, null);
	}

	public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer)
	{
		if (source == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
		}
		if (keySelector == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.keySelector);
		}
		if (IsEmptyArray(source))
		{
			return Array.Empty<TSource>();
		}
		return DistinctByIterator(source, keySelector, comparer);
	}

	private static IEnumerable<TSource> DistinctByIterator<TSource, TKey>(IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
	{
		using IEnumerator<TSource> enumerator = source.GetEnumerator();
		if (!enumerator.MoveNext())
		{
			yield break;
		}
		HashSet<TKey> set = new HashSet<TKey>(7, comparer);
		do
		{
			TSource current = enumerator.Current;
			if (set.Add(keySelector(current)))
			{
				yield return current;
			}
		}
		while (enumerator.MoveNext());
	}

	public static TSource ElementAt<TSource>(this IEnumerable<TSource> source, int index)
	{
		if (source == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
		}
		if (source is IList<TSource> list)
		{
			return list[index];
		}
		bool found;
		object result = ((source is Iterator<TSource> iterator) ? ((object)iterator.TryGetElementAt(index, out found)) : ((object)TryGetElementAtNonIterator(source, index, out found)));
		if (!found)
		{
			ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.index);
		}
		return (TSource)result;
	}

	public static TSource? ElementAtOrDefault<TSource>(this IEnumerable<TSource> source, int index)
	{
		if (source == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
		}
		bool found;
		return source.TryGetElementAt(index, out found);
	}

	private static TSource TryGetElementAt<TSource>(this IEnumerable<TSource> source, int index, out bool found)
	{
		if (source is IList<TSource> list)
		{
			if (!(found = (uint)index < (uint)list.Count))
			{
				return default(TSource);
			}
			return list[index];
		}
		if (!(source is Iterator<TSource> iterator))
		{
			return TryGetElementAtNonIterator(source, index, out found);
		}
		return iterator.TryGetElementAt(index, out found);
	}

	private static TSource TryGetElementAtNonIterator<TSource>(IEnumerable<TSource> source, int index, out bool found)
	{
		if (index >= 0)
		{
			using IEnumerator<TSource> enumerator = source.GetEnumerator();
			while (enumerator.MoveNext())
			{
				if (index == 0)
				{
					found = true;
					return enumerator.Current;
				}
				index--;
			}
		}
		found = false;
		return default(TSource);
	}

	public static IEnumerable<TSource> AsEnumerable<TSource>(this IEnumerable<TSource> source)
	{
		return source;
	}

	public static IEnumerable<TResult> Empty<TResult>()
	{
		return Array.Empty<TResult>();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static bool IsEmptyArray<TSource>(IEnumerable<TSource> source)
	{
		if (source is TSource[] array)
		{
			return array.Length == 0;
		}
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static Span<T> SetCountAndGetSpan<T>(List<T> list, int count)
	{
		CollectionsMarshal.SetCount(list, count);
		return CollectionsMarshal.AsSpan(list);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static bool TryGetSpan<TSource>(this IEnumerable<TSource> source, out ReadOnlySpan<TSource> span)
	{
		bool result = true;
		if (source.GetType() == typeof(TSource[]))
		{
			span = Unsafe.As<TSource[]>(source);
		}
		else if (source.GetType() == typeof(List<TSource>))
		{
			span = CollectionsMarshal.AsSpan(Unsafe.As<List<TSource>>(source));
		}
		else
		{
			span = default(ReadOnlySpan<TSource>);
			result = false;
		}
		return result;
	}

	public static IEnumerable<TSource> Except<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second)
	{
		if (first == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.first);
		}
		if (second == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.second);
		}
		return ExceptIterator(first, second, null);
	}

	private static IEnumerable<TSource> ExceptIterator<TSource>(IEnumerable<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource> comparer)
	{
		HashSet<TSource> set = new HashSet<TSource>(second, comparer);
		foreach (TSource item in first)
		{
			if (set.Add(item))
			{
				yield return item;
			}
		}
	}

	public static TSource First<TSource>(this IEnumerable<TSource> source)
	{
		bool found;
		TSource result = source.TryGetFirst(out found);
		if (!found)
		{
			ThrowHelper.ThrowNoElementsException();
		}
		return result;
	}

	public static TSource First<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
	{
		bool found;
		TSource result = source.TryGetFirst(predicate, out found);
		if (!found)
		{
			ThrowHelper.ThrowNoMatchException();
		}
		return result;
	}

	public static TSource? FirstOrDefault<TSource>(this IEnumerable<TSource> source)
	{
		bool found;
		return source.TryGetFirst(out found);
	}

	public static TSource? FirstOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
	{
		bool found;
		return source.TryGetFirst(predicate, out found);
	}

	private static TSource TryGetFirst<TSource>(this IEnumerable<TSource> source, out bool found)
	{
		if (source == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
		}
		if (1 == 0)
		{
		}
		return TryGetFirstNonIterator(source, out found);
	}

	private static TSource TryGetFirstNonIterator<TSource>(IEnumerable<TSource> source, out bool found)
	{
		if (source is IList<TSource> list)
		{
			if (list.Count > 0)
			{
				found = true;
				return list[0];
			}
		}
		else
		{
			using IEnumerator<TSource> enumerator = source.GetEnumerator();
			if (enumerator.MoveNext())
			{
				found = true;
				return enumerator.Current;
			}
		}
		found = false;
		return default(TSource);
	}

	private static TSource TryGetFirst<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate, out bool found)
	{
		if (source == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
		}
		if (predicate == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.predicate);
		}
		if (source.TryGetSpan(out var span))
		{
			ReadOnlySpan<TSource> readOnlySpan = span;
			for (int i = 0; i < readOnlySpan.Length; i++)
			{
				TSource val = readOnlySpan[i];
				if (predicate(val))
				{
					found = true;
					return val;
				}
			}
		}
		else
		{
			foreach (TSource item in source)
			{
				if (predicate(item))
				{
					found = true;
					return item;
				}
			}
		}
		found = false;
		return default(TSource);
	}

	public static IEnumerable<IGrouping<TKey, TSource>> GroupBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
	{
		return source.GroupBy(keySelector, null);
	}

	public static IEnumerable<IGrouping<TKey, TSource>> GroupBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer)
	{
		if (source == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
		}
		if (keySelector == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.keySelector);
		}
		if (IsEmptyArray(source))
		{
			return Array.Empty<IGrouping<TKey, TSource>>();
		}
		return new GroupByIterator<TSource, TKey>(source, keySelector, comparer);
	}

	public static IEnumerable<IGrouping<TKey, TElement>> GroupBy<TSource, TKey, TElement>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector)
	{
		return source.GroupBy(keySelector, elementSelector, null);
	}

	public static IEnumerable<IGrouping<TKey, TElement>> GroupBy<TSource, TKey, TElement>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer)
	{
		if (source == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
		}
		if (keySelector == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.keySelector);
		}
		if (elementSelector == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.elementSelector);
		}
		if (IsEmptyArray(source))
		{
			return Array.Empty<IGrouping<TKey, TElement>>();
		}
		return new GroupByIterator<TSource, TKey, TElement>(source, keySelector, elementSelector, comparer);
	}

	public static IEnumerable<TResult> GroupBy<TSource, TKey, TResult>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TKey, IEnumerable<TSource>, TResult> resultSelector)
	{
		return source.GroupBy(keySelector, resultSelector, null);
	}

	public static IEnumerable<TResult> GroupBy<TSource, TKey, TResult>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TKey, IEnumerable<TSource>, TResult> resultSelector, IEqualityComparer<TKey>? comparer)
	{
		if (source == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
		}
		if (keySelector == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.keySelector);
		}
		if (resultSelector == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.resultSelector);
		}
		if (IsEmptyArray(source))
		{
			return Array.Empty<TResult>();
		}
		return new GroupByResultIterator<TSource, TKey, TResult>(source, keySelector, resultSelector, comparer);
	}

	public static IEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(this IEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
	{
		return outer.Join(inner, outerKeySelector, innerKeySelector, resultSelector, null);
	}

	public static IEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(this IEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector, IEqualityComparer<TKey>? comparer)
	{
		if (outer == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.outer);
		}
		if (inner == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.inner);
		}
		if (outerKeySelector == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.outerKeySelector);
		}
		if (innerKeySelector == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.innerKeySelector);
		}
		if (resultSelector == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.resultSelector);
		}
		if (IsEmptyArray(outer))
		{
			return Array.Empty<TResult>();
		}
		return JoinIterator(outer, inner, outerKeySelector, innerKeySelector, resultSelector, comparer);
	}

	private static IEnumerable<TResult> JoinIterator<TOuter, TInner, TKey, TResult>(IEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector, IEqualityComparer<TKey> comparer)
	{
		using IEnumerator<TOuter> e = outer.GetEnumerator();
		if (!e.MoveNext())
		{
			yield break;
		}
		Lookup<TKey, TInner> lookup = Lookup<TKey, TInner>.CreateForJoin(inner, innerKeySelector, comparer);
		if (lookup.Count == 0)
		{
			yield break;
		}
		do
		{
			TOuter item = e.Current;
			Grouping<TKey, TInner> grouping = lookup.GetGrouping(outerKeySelector(item), create: false);
			if (grouping != null)
			{
				int count = grouping._count;
				TInner[] elements = grouping._elements;
				int i = 0;
				while (i != count)
				{
					yield return resultSelector(item, elements[i]);
					int num = i + 1;
					i = num;
				}
			}
		}
		while (e.MoveNext());
	}

	public static TSource Last<TSource>(this IEnumerable<TSource> source)
	{
		bool found;
		TSource result = source.TryGetLast(out found);
		if (!found)
		{
			ThrowHelper.ThrowNoElementsException();
		}
		return result;
	}

	public static TSource Last<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
	{
		bool found;
		TSource result = source.TryGetLast(predicate, out found);
		if (!found)
		{
			ThrowHelper.ThrowNoMatchException();
		}
		return result;
	}

	public static TSource? LastOrDefault<TSource>(this IEnumerable<TSource> source)
	{
		bool found;
		return source.TryGetLast(out found);
	}

	public static TSource? LastOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
	{
		bool found;
		return source.TryGetLast(predicate, out found);
	}

	private static TSource TryGetLast<TSource>(this IEnumerable<TSource> source, out bool found)
	{
		if (source == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
		}
		if (!(source is Iterator<TSource> iterator))
		{
			return TryGetLastNonIterator(source, out found);
		}
		return iterator.TryGetLast(out found);
	}

	private static TSource TryGetLastNonIterator<TSource>(IEnumerable<TSource> source, out bool found)
	{
		if (source is IList<TSource> { Count: var count } list)
		{
			if (count > 0)
			{
				found = true;
				return list[count - 1];
			}
		}
		else
		{
			using IEnumerator<TSource> enumerator = source.GetEnumerator();
			if (enumerator.MoveNext())
			{
				TSource current;
				do
				{
					current = enumerator.Current;
				}
				while (enumerator.MoveNext());
				found = true;
				return current;
			}
		}
		found = false;
		return default(TSource);
	}

	private static TSource TryGetLast<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate, out bool found)
	{
		if (source == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
		}
		if (predicate == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.predicate);
		}
		if (source is OrderedIterator<TSource> orderedIterator)
		{
			return orderedIterator.TryGetLast(predicate, out found);
		}
		if (source is IList<TSource> list)
		{
			for (int num = list.Count - 1; num >= 0; num--)
			{
				TSource val = list[num];
				if (predicate(val))
				{
					found = true;
					return val;
				}
			}
		}
		else
		{
			using IEnumerator<TSource> enumerator = source.GetEnumerator();
			while (enumerator.MoveNext())
			{
				TSource val2 = enumerator.Current;
				if (!predicate(val2))
				{
					continue;
				}
				while (enumerator.MoveNext())
				{
					TSource current = enumerator.Current;
					if (predicate(current))
					{
						val2 = current;
					}
				}
				found = true;
				return val2;
			}
		}
		found = false;
		return default(TSource);
	}

	public static ILookup<TKey, TElement> ToLookup<TSource, TKey, TElement>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector)
	{
		return source.ToLookup(keySelector, elementSelector, null);
	}

	public static ILookup<TKey, TElement> ToLookup<TSource, TKey, TElement>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer)
	{
		if (source == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
		}
		if (keySelector == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.keySelector);
		}
		if (elementSelector == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.elementSelector);
		}
		if (IsEmptyArray(source))
		{
			return EmptyLookup<TKey, TElement>.Instance;
		}
		return Lookup<TKey, TElement>.Create(source, keySelector, elementSelector, comparer);
	}

	public static int Max(this IEnumerable<int> source)
	{
		return source.MinMaxInteger<int, MaxCalc<int>>();
	}

	public static int Max<TSource>(this IEnumerable<TSource> source, Func<TSource, int> selector)
	{
		return source.MaxInteger(selector);
	}

	private static TResult MaxInteger<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector) where TResult : struct, IBinaryInteger<TResult>
	{
		if (source == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
		}
		if (selector == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.selector);
		}
		using IEnumerator<TSource> enumerator = source.GetEnumerator();
		if (!enumerator.MoveNext())
		{
			ThrowHelper.ThrowNoElementsException();
		}
		TResult val = selector(enumerator.Current);
		while (enumerator.MoveNext())
		{
			TResult val2 = selector(enumerator.Current);
			if (val2 > val)
			{
				val = val2;
			}
		}
		return val;
	}

	private static T MinMaxInteger<T, TMinMax>(this IEnumerable<T> source) where T : struct, IBinaryInteger<T> where TMinMax : IMinMaxCalc<T>
	{
		if (source == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
		}
		T val;
		if (source.TryGetSpan(out var span))
		{
			if (span.IsEmpty)
			{
				ThrowHelper.ThrowNoElementsException();
			}
			if (!Vector128.IsHardwareAccelerated || !Vector128<T>.IsSupported || span.Length < Vector128<T>.Count)
			{
				val = span[0];
				for (int i = 1; i < span.Length; i++)
				{
					if (TMinMax.Compare(span[i], val))
					{
						val = span[i];
					}
				}
			}
			else
			{
				if (false)
				{
				}
				ref T reference = ref MemoryMarshal.GetReference(span);
				ref T reference2 = ref Unsafe.Add(ref reference, span.Length - Vector128<T>.Count);
				Vector128<T> left = Vector128.LoadUnsafe(in reference);
				reference = ref Unsafe.Add(ref reference, Vector128<T>.Count);
				while (Unsafe.IsAddressLessThan(in reference, in reference2))
				{
					left = TMinMax.Compare(left, Vector128.LoadUnsafe(in reference));
					reference = ref Unsafe.Add(ref reference, Vector128<T>.Count);
				}
				left = TMinMax.Compare(left, Vector128.LoadUnsafe(in reference2));
				val = left[0];
				for (int j = 1; j < Vector128<T>.Count; j++)
				{
					if (TMinMax.Compare(left[j], val))
					{
						val = left[j];
					}
				}
			}
		}
		else
		{
			using IEnumerator<T> enumerator = source.GetEnumerator();
			if (!enumerator.MoveNext())
			{
				ThrowHelper.ThrowNoElementsException();
			}
			val = enumerator.Current;
			while (enumerator.MoveNext())
			{
				T current = enumerator.Current;
				if (TMinMax.Compare(current, val))
				{
					val = current;
				}
			}
		}
		return val;
	}

	public static TSource? MinBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
	{
		return source.MinBy(keySelector, null);
	}

	public static TSource? MinBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey>? comparer)
	{
		if (source == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
		}
		if (keySelector == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.keySelector);
		}
		if (comparer == null)
		{
			comparer = Comparer<TKey>.Default;
		}
		using IEnumerator<TSource> enumerator = source.GetEnumerator();
		if (!enumerator.MoveNext())
		{
			if (default(TSource) == null)
			{
				return default(TSource);
			}
			ThrowHelper.ThrowNoElementsException();
		}
		TSource val = enumerator.Current;
		TKey val2 = keySelector(val);
		if (default(TKey) == null)
		{
			if (val2 == null)
			{
				TSource result = val;
				do
				{
					if (!enumerator.MoveNext())
					{
						return result;
					}
					val = enumerator.Current;
					val2 = keySelector(val);
				}
				while (val2 == null);
			}
			while (enumerator.MoveNext())
			{
				TSource current = enumerator.Current;
				TKey val3 = keySelector(current);
				if (val3 != null && comparer.Compare(val3, val2) < 0)
				{
					val2 = val3;
					val = current;
				}
			}
		}
		else if (comparer == Comparer<TKey>.Default)
		{
			while (enumerator.MoveNext())
			{
				TSource current2 = enumerator.Current;
				TKey val4 = keySelector(current2);
				if (Comparer<TKey>.Default.Compare(val4, val2) < 0)
				{
					val2 = val4;
					val = current2;
				}
			}
		}
		else
		{
			while (enumerator.MoveNext())
			{
				TSource current3 = enumerator.Current;
				TKey val5 = keySelector(current3);
				if (comparer.Compare(val5, val2) < 0)
				{
					val2 = val5;
					val = current3;
				}
			}
		}
		return val;
	}

	public static int Min<TSource>(this IEnumerable<TSource> source, Func<TSource, int> selector)
	{
		return source.MinInteger(selector);
	}

	private static TResult MinInteger<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector) where TResult : struct, IBinaryInteger<TResult>
	{
		if (source == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
		}
		if (selector == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.selector);
		}
		using IEnumerator<TSource> enumerator = source.GetEnumerator();
		if (!enumerator.MoveNext())
		{
			ThrowHelper.ThrowNoElementsException();
		}
		TResult val = selector(enumerator.Current);
		while (enumerator.MoveNext())
		{
			TResult val2 = selector(enumerator.Current);
			if (val2 < val)
			{
				val = val2;
			}
		}
		return val;
	}

	public static IEnumerable<TResult> OfType<TResult>(this IEnumerable source)
	{
		if (source == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
		}
		if (default(TResult) != null && source is IEnumerable<TResult> result)
		{
			return result;
		}
		return new OfTypeIterator<TResult>(source);
	}

	public static IOrderedEnumerable<TSource> OrderBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
	{
		return new OrderedIterator<TSource, TKey>(source, keySelector, null, descending: false, null);
	}

	public static IOrderedEnumerable<TSource> OrderBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey>? comparer)
	{
		return new OrderedIterator<TSource, TKey>(source, keySelector, comparer, descending: false, null);
	}

	public static IOrderedEnumerable<TSource> OrderByDescending<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
	{
		return new OrderedIterator<TSource, TKey>(source, keySelector, null, descending: true, null);
	}

	public static IOrderedEnumerable<TSource> ThenBy<TSource, TKey>(this IOrderedEnumerable<TSource> source, Func<TSource, TKey> keySelector)
	{
		if (source == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
		}
		return source.CreateOrderedEnumerable(keySelector, null, descending: false);
	}

	public static IEnumerable<int> Range(int start, int count)
	{
		long num = (long)start + (long)count - 1;
		if (count < 0 || num > int.MaxValue)
		{
			ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.count);
		}
		if (count == 0)
		{
			return Array.Empty<int>();
		}
		return new RangeIterator<int>(start, start + count);
	}

	private static void FillIncrementing<T>(Span<T> destination, T value) where T : INumber<T>
	{
		ref T reference = ref MemoryMarshal.GetReference(destination);
		ref T reference2 = ref Unsafe.Add(ref reference, destination.Length);
		if (Vector.IsHardwareAccelerated && Vector<T>.IsSupported && destination.Length >= Vector<T>.Count)
		{
			Vector<T> indices = Vector<T>.Indices;
			Vector<T> source = new Vector<T>(value) + indices;
			Vector<T> vector = new Vector<T>(T.CreateTruncating(Vector<T>.Count));
			ref T right = ref Unsafe.Subtract(ref reference2, Vector<T>.Count);
			do
			{
				source.StoreUnsafe(ref reference);
				source += vector;
				reference = ref Unsafe.Add(ref reference, Vector<T>.Count);
			}
			while (Unsafe.IsAddressLessThanOrEqualTo(in reference, in right));
			value = source[0];
		}
		while (Unsafe.IsAddressLessThan(in reference, in reference2))
		{
			reference = value++;
			reference = ref Unsafe.Add(ref reference, 1);
		}
	}

	public static IEnumerable<TResult> Repeat<TResult>(TResult element, int count)
	{
		if (count < 0)
		{
			ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.count);
		}
		if (count == 0)
		{
			return Array.Empty<TResult>();
		}
		return new RepeatIterator<TResult>(element, count);
	}

	public static IEnumerable<TSource> Reverse<TSource>(this IEnumerable<TSource> source)
	{
		if (source == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
		}
		if (IsEmptyArray(source))
		{
			return Array.Empty<TSource>();
		}
		return new ReverseIterator<TSource>(source);
	}

	public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
	{
		if (source == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
		}
		if (selector == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.selector);
		}
		if (source is Iterator<TSource> iterator)
		{
			_ = 1;
			if (typeof(TResult).IsValueType)
			{
				if (!(source is IList<TSource> source2))
				{
					return new IEnumerableSelectIterator<TSource, TResult>(iterator, selector);
				}
				return new SizeOptIListSelectIterator<TSource, TResult>(source2, selector);
			}
			return iterator.Select(selector);
		}
		if (source is IList<TSource> source3)
		{
			_ = 1;
			return new SizeOptIListSelectIterator<TSource, TResult>(source3, selector);
		}
		return new IEnumerableSelectIterator<TSource, TResult>(source, selector);
	}

	public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, int, TResult> selector)
	{
		if (source == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
		}
		if (selector == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.selector);
		}
		if (IsEmptyArray(source))
		{
			return Array.Empty<TResult>();
		}
		return SelectIterator(source, selector);
	}

	private static IEnumerable<TResult> SelectIterator<TSource, TResult>(IEnumerable<TSource> source, Func<TSource, int, TResult> selector)
	{
		int index = -1;
		foreach (TSource item in source)
		{
			index = checked(index + 1);
			yield return selector(item, index);
		}
	}

	public static IEnumerable<TResult> SelectMany<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, IEnumerable<TResult>> selector)
	{
		if (source == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
		}
		if (selector == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.selector);
		}
		if (IsEmptyArray(source))
		{
			return Array.Empty<TResult>();
		}
		return new SelectManySingleSelectorIterator<TSource, TResult>(source, selector);
	}

	public static IEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(this IEnumerable<TSource> source, Func<TSource, IEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector)
	{
		if (source == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
		}
		if (collectionSelector == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.collectionSelector);
		}
		if (resultSelector == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.resultSelector);
		}
		if (IsEmptyArray(source))
		{
			return Array.Empty<TResult>();
		}
		return SelectManyIterator(source, collectionSelector, resultSelector);
	}

	private static IEnumerable<TResult> SelectManyIterator<TSource, TCollection, TResult>(IEnumerable<TSource> source, Func<TSource, IEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector)
	{
		foreach (TSource element in source)
		{
			foreach (TCollection item in collectionSelector(element))
			{
				yield return resultSelector(element, item);
			}
		}
	}

	public static bool SequenceEqual<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second)
	{
		return first.SequenceEqual(second, null);
	}

	public static bool SequenceEqual<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource>? comparer)
	{
		if (first == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.first);
		}
		if (second == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.second);
		}
		if (first is ICollection<TSource> collection && second is ICollection<TSource> collection2)
		{
			if (first.TryGetSpan<TSource>(out var span) && second.TryGetSpan<TSource>(out var span2))
			{
				return span.SequenceEqual(span2, comparer);
			}
			if (collection.Count != collection2.Count)
			{
				return false;
			}
			if (collection is IList<TSource> list && collection2 is IList<TSource> list2)
			{
				if (comparer == null)
				{
					comparer = EqualityComparer<TSource>.Default;
				}
				int count = collection.Count;
				for (int i = 0; i < count; i++)
				{
					if (!comparer.Equals(list[i], list2[i]))
					{
						return false;
					}
				}
				return true;
			}
		}
		using IEnumerator<TSource> enumerator = first.GetEnumerator();
		using IEnumerator<TSource> enumerator2 = second.GetEnumerator();
		if (comparer == null)
		{
			comparer = EqualityComparer<TSource>.Default;
		}
		while (enumerator.MoveNext())
		{
			if (!enumerator2.MoveNext() || !comparer.Equals(enumerator.Current, enumerator2.Current))
			{
				return false;
			}
		}
		return !enumerator2.MoveNext();
	}

	public static TSource Single<TSource>(this IEnumerable<TSource> source)
	{
		bool found;
		TSource result = source.TryGetSingle(out found);
		if (!found)
		{
			ThrowHelper.ThrowNoElementsException();
		}
		return result;
	}

	public static TSource Single<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
	{
		bool found;
		TSource result = source.TryGetSingle(predicate, out found);
		if (!found)
		{
			ThrowHelper.ThrowNoMatchException();
		}
		return result;
	}

	public static TSource? SingleOrDefault<TSource>(this IEnumerable<TSource> source)
	{
		bool found;
		return source.TryGetSingle(out found);
	}

	public static TSource? SingleOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
	{
		bool found;
		return source.TryGetSingle(predicate, out found);
	}

	private static TSource TryGetSingle<TSource>(this IEnumerable<TSource> source, out bool found)
	{
		if (source == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
		}
		if (source is IList<TSource> { Count: var count } list)
		{
			switch (count)
			{
			case 0:
				found = false;
				return default(TSource);
			case 1:
				found = true;
				return list[0];
			}
		}
		else
		{
			using IEnumerator<TSource> enumerator = source.GetEnumerator();
			if (!enumerator.MoveNext())
			{
				found = false;
				return default(TSource);
			}
			TSource current = enumerator.Current;
			if (!enumerator.MoveNext())
			{
				found = true;
				return current;
			}
		}
		found = false;
		ThrowHelper.ThrowMoreThanOneElementException();
		return default(TSource);
	}

	private static TSource TryGetSingle<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate, out bool found)
	{
		if (source == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
		}
		if (predicate == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.predicate);
		}
		if (source.TryGetSpan(out var span))
		{
			for (int i = 0; i < span.Length; i++)
			{
				TSource val = span[i];
				if (!predicate(val))
				{
					continue;
				}
				for (i++; (uint)i < (uint)span.Length; i++)
				{
					if (predicate(span[i]))
					{
						ThrowHelper.ThrowMoreThanOneMatchException();
					}
				}
				found = true;
				return val;
			}
		}
		else
		{
			using IEnumerator<TSource> enumerator = source.GetEnumerator();
			while (enumerator.MoveNext())
			{
				TSource current = enumerator.Current;
				if (!predicate(current))
				{
					continue;
				}
				while (enumerator.MoveNext())
				{
					if (predicate(enumerator.Current))
					{
						ThrowHelper.ThrowMoreThanOneMatchException();
					}
				}
				found = true;
				return current;
			}
		}
		found = false;
		return default(TSource);
	}

	public static IEnumerable<TSource> Skip<TSource>(this IEnumerable<TSource> source, int count)
	{
		if (source == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
		}
		if (IsEmptyArray(source))
		{
			return Array.Empty<TSource>();
		}
		if (count <= 0)
		{
			if (source is Iterator<TSource>)
			{
				return source;
			}
			count = 0;
		}
		else if (source is Iterator<TSource> iterator)
		{
			IEnumerable<TSource> enumerable = iterator.Skip(count);
			return enumerable ?? Empty<TSource>();
		}
		return SpeedOptimizedSkipIterator(source, count);
	}

	public static IEnumerable<TSource> SkipWhile<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
	{
		if (source == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
		}
		if (predicate == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.predicate);
		}
		if (IsEmptyArray(source))
		{
			return Array.Empty<TSource>();
		}
		return SkipWhileIterator(source, predicate);
	}

	private static IEnumerable<TSource> SkipWhileIterator<TSource>(IEnumerable<TSource> source, Func<TSource, bool> predicate)
	{
		using IEnumerator<TSource> e = source.GetEnumerator();
		while (e.MoveNext())
		{
			TSource current = e.Current;
			if (!predicate(current))
			{
				yield return current;
				while (e.MoveNext())
				{
					yield return e.Current;
				}
				break;
			}
		}
	}

	private static IEnumerable<TSource> SpeedOptimizedSkipIterator<TSource>(IEnumerable<TSource> source, int count)
	{
		if (!(source is IList<TSource> source2))
		{
			return new IEnumerableSkipTakeIterator<TSource>(source, count, -1);
		}
		return new IListSkipTakeIterator<TSource>(source2, count, int.MaxValue);
	}

	public static decimal Sum(this IEnumerable<decimal> source)
	{
		return source.Sum<decimal, decimal>();
	}

	private static TResult Sum<TSource, TResult>(this IEnumerable<TSource> source) where TSource : struct, INumber<TSource> where TResult : struct, INumber<TResult>
	{
		if (source == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
		}
		if (source.TryGetSpan(out var span))
		{
			return Sum<TSource, TResult>(span);
		}
		TResult val = TResult.Zero;
		foreach (TSource item in source)
		{
			val = checked(val + TResult.CreateChecked(item));
		}
		return val;
	}

	private static TResult Sum<T, TResult>(ReadOnlySpan<T> span) where T : struct, INumber<T> where TResult : struct, INumber<TResult>
	{
		if (typeof(T) == typeof(TResult) && Vector<T>.IsSupported && Vector.IsHardwareAccelerated && Vector<T>.Count > 2 && span.Length >= Vector<T>.Count * 4)
		{
			if (typeof(T) == typeof(long))
			{
				return (TResult)(object)SumSignedIntegersVectorized(Unsafe.BitCast<ReadOnlySpan<T>, ReadOnlySpan<long>>(span));
			}
			if (typeof(T) == typeof(int))
			{
				return (TResult)(object)SumSignedIntegersVectorized(Unsafe.BitCast<ReadOnlySpan<T>, ReadOnlySpan<int>>(span));
			}
		}
		TResult val = TResult.Zero;
		ReadOnlySpan<T> readOnlySpan = span;
		for (int i = 0; i < readOnlySpan.Length; i++)
		{
			T value = readOnlySpan[i];
			val = checked(val + TResult.CreateChecked(value));
		}
		return val;
	}

	private static T SumSignedIntegersVectorized<T>(ReadOnlySpan<T> span) where T : struct, IBinaryInteger<T>, ISignedNumber<T>, IMinMaxValue<T>
	{
		ref T reference = ref MemoryMarshal.GetReference(span);
		nuint num = (nuint)span.Length;
		Vector<T> vector = Vector<T>.Zero;
		Vector<T> vector2 = new Vector<T>(T.MinValue);
		nuint num2 = 0u;
		nuint num3 = num - (nuint)((nint)Vector<T>.Count * (nint)4);
		do
		{
			Vector<T> vector3 = Vector.LoadUnsafe(in reference, num2);
			Vector<T> vector4 = vector + vector3;
			Vector<T> vector5 = (vector4 ^ vector) & (vector4 ^ vector3);
			vector3 = Vector.LoadUnsafe(in reference, num2 + (nuint)Vector<T>.Count);
			vector = vector4 + vector3;
			Vector<T> vector6 = vector5 | ((vector ^ vector4) & (vector ^ vector3));
			vector3 = Vector.LoadUnsafe(in reference, num2 + (nuint)((nint)Vector<T>.Count * (nint)2));
			vector4 = vector + vector3;
			Vector<T> vector7 = vector6 | ((vector4 ^ vector) & (vector4 ^ vector3));
			vector3 = Vector.LoadUnsafe(in reference, num2 + (nuint)((nint)Vector<T>.Count * (nint)3));
			vector = vector4 + vector3;
			if (((vector7 | ((vector ^ vector4) & (vector ^ vector3))) & vector2) != Vector<T>.Zero)
			{
				ThrowHelper.ThrowOverflowException();
			}
			num2 += (nuint)((nint)Vector<T>.Count * (nint)4);
		}
		while (num2 < num3);
		num3 = num - (nuint)Vector<T>.Count;
		if (num2 < num3)
		{
			Vector<T> zero = Vector<T>.Zero;
			do
			{
				Vector<T> vector8 = Vector.LoadUnsafe(in reference, num2);
				Vector<T> vector9 = vector + vector8;
				zero |= (vector9 ^ vector) & (vector9 ^ vector8);
				vector = vector9;
				num2 += (nuint)Vector<T>.Count;
			}
			while (num2 < num3);
			if ((zero & vector2) != Vector<T>.Zero)
			{
				ThrowHelper.ThrowOverflowException();
			}
		}
		T val = T.Zero;
		for (int i = 0; i < Vector<T>.Count; i++)
		{
			val = checked(val + vector[i]);
		}
		for (; num2 < num; num2++)
		{
			val = checked(val + Unsafe.Add(ref reference, num2));
		}
		return val;
	}

	public static decimal? Sum(this IEnumerable<decimal?> source)
	{
		return source.Sum<decimal, decimal>();
	}

	private static TSource? Sum<TSource, TAccumulator>(this IEnumerable<TSource?> source) where TSource : struct, INumber<TSource> where TAccumulator : struct, INumber<TAccumulator>
	{
		if (source == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
		}
		TAccumulator val = TAccumulator.Zero;
		foreach (TSource? item in source)
		{
			if (item.HasValue)
			{
				val = checked(val + TAccumulator.CreateChecked(item.GetValueOrDefault()));
			}
		}
		return TSource.CreateTruncating(val);
	}

	public static int Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, int> selector)
	{
		return source.Sum<TSource, int, int>(selector);
	}

	public static long Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, long> selector)
	{
		return source.Sum<TSource, long, long>(selector);
	}

	public static decimal Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal> selector)
	{
		return source.Sum<TSource, decimal, decimal>(selector);
	}

	private static TResult Sum<TSource, TResult, TAccumulator>(this IEnumerable<TSource> source, Func<TSource, TResult> selector) where TResult : struct, INumber<TResult> where TAccumulator : struct, INumber<TAccumulator>
	{
		if (source == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
		}
		if (selector == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.selector);
		}
		TAccumulator val = TAccumulator.Zero;
		foreach (TSource item in source)
		{
			val = checked(val + TAccumulator.CreateChecked(selector(item)));
		}
		return TResult.CreateTruncating(val);
	}

	public static decimal? Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal?> selector)
	{
		return source.Sum<TSource, decimal, decimal>(selector);
	}

	private static TResult? Sum<TSource, TResult, TAccumulator>(this IEnumerable<TSource> source, Func<TSource, TResult?> selector) where TResult : struct, INumber<TResult> where TAccumulator : struct, INumber<TAccumulator>
	{
		if (source == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
		}
		if (selector == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.selector);
		}
		TAccumulator val = TAccumulator.Zero;
		foreach (TSource item in source)
		{
			TResult? val2 = selector(item);
			if (val2.HasValue)
			{
				TResult valueOrDefault = val2.GetValueOrDefault();
				val = checked(val + TAccumulator.CreateChecked(valueOrDefault));
			}
		}
		return TResult.CreateTruncating(val);
	}

	public static IEnumerable<TSource> Take<TSource>(this IEnumerable<TSource> source, int count)
	{
		if (source == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
		}
		if (count <= 0 || IsEmptyArray(source))
		{
			return Array.Empty<TSource>();
		}
		return SpeedOptimizedTakeIterator(source, count);
	}

	private static IEnumerable<TSource> TakeRangeFromEndIterator<TSource>(IEnumerable<TSource> source, bool isStartIndexFromEnd, int startIndex, bool isEndIndexFromEnd, int endIndex)
	{
		if (source.TryGetNonEnumeratedCount(out var count))
		{
			startIndex = CalculateStartIndex(isStartIndexFromEnd, startIndex, count);
			endIndex = CalculateEndIndex(isEndIndexFromEnd, endIndex, count);
			if (startIndex >= endIndex)
			{
				yield break;
			}
			IEnumerable<TSource> enumerable = SpeedOptimizedTakeRangeIterator(source, startIndex, endIndex);
			foreach (TSource item in enumerable)
			{
				yield return item;
			}
			yield break;
		}
		if (isStartIndexFromEnd)
		{
			Queue<TSource> queue;
			using (IEnumerator<TSource> enumerator2 = source.GetEnumerator())
			{
				if (!enumerator2.MoveNext())
				{
					yield break;
				}
				queue = new Queue<TSource>();
				queue.Enqueue(enumerator2.Current);
				count = 1;
				while (enumerator2.MoveNext())
				{
					if (count < startIndex)
					{
						queue.Enqueue(enumerator2.Current);
						count++;
						continue;
					}
					do
					{
						queue.Dequeue();
						queue.Enqueue(enumerator2.Current);
						count = checked(count + 1);
					}
					while (enumerator2.MoveNext());
					break;
				}
			}
			startIndex = CalculateStartIndex(isStartIndexFromEnd: true, startIndex, count);
			endIndex = CalculateEndIndex(isEndIndexFromEnd, endIndex, count);
			for (int rangeIndex = startIndex; rangeIndex < endIndex; rangeIndex++)
			{
				yield return queue.Dequeue();
			}
			yield break;
		}
		using (IEnumerator<TSource> enumerator = source.GetEnumerator())
		{
			for (count = 0; count < startIndex; count++)
			{
				if (!enumerator.MoveNext())
				{
					break;
				}
			}
			if (count != startIndex)
			{
				yield break;
			}
			Queue<TSource> queue = new Queue<TSource>();
			while (enumerator.MoveNext())
			{
				if (queue.Count == endIndex)
				{
					do
					{
						queue.Enqueue(enumerator.Current);
						yield return queue.Dequeue();
					}
					while (enumerator.MoveNext());
					break;
				}
				queue.Enqueue(enumerator.Current);
			}
		}
		static int CalculateEndIndex(bool flag, int num2, int num)
		{
			return Math.Min(num, flag ? (num - num2) : num2);
		}
		static int CalculateStartIndex(bool flag, int num2, int num)
		{
			return Math.Max(0, flag ? (num - num2) : num2);
		}
	}

	public static IEnumerable<TSource> TakeWhile<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
	{
		if (source == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
		}
		if (predicate == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.predicate);
		}
		if (IsEmptyArray(source))
		{
			return Array.Empty<TSource>();
		}
		return TakeWhileIterator(source, predicate);
	}

	private static IEnumerable<TSource> TakeWhileIterator<TSource>(IEnumerable<TSource> source, Func<TSource, bool> predicate)
	{
		foreach (TSource item in source)
		{
			if (!predicate(item))
			{
				break;
			}
			yield return item;
		}
	}

	public static IEnumerable<TSource> TakeLast<TSource>(this IEnumerable<TSource> source, int count)
	{
		if (source == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
		}
		if (count > 0 && !IsEmptyArray(source))
		{
			return TakeRangeFromEndIterator(source, isStartIndexFromEnd: true, count, isEndIndexFromEnd: true, 0);
		}
		return Array.Empty<TSource>();
	}

	private static IEnumerable<TSource> SpeedOptimizedTakeIterator<TSource>(IEnumerable<TSource> source, int count)
	{
		if (!(source is Iterator<TSource> iterator))
		{
			if (!(source is IList<TSource> source2))
			{
				return new IEnumerableSkipTakeIterator<TSource>(source, 0, count - 1);
			}
			return new IListSkipTakeIterator<TSource>(source2, 0, count - 1);
		}
		IEnumerable<TSource> enumerable = iterator.Take(count);
		return enumerable ?? Empty<TSource>();
	}

	private static IEnumerable<TSource> SpeedOptimizedTakeRangeIterator<TSource>(IEnumerable<TSource> source, int startIndex, int endIndex)
	{
		if (!(source is Iterator<TSource> iterator))
		{
			if (!(source is IList<TSource> source2))
			{
				return new IEnumerableSkipTakeIterator<TSource>(source, startIndex, endIndex - 1);
			}
			return new IListSkipTakeIterator<TSource>(source2, startIndex, endIndex - 1);
		}
		return TakeIteratorRange(iterator, startIndex, endIndex);
		static IEnumerable<TSource> TakeIteratorRange(Iterator<TSource> iterator3, int num2, int num)
		{
			Iterator<TSource> iterator2;
			if (num != 0 && (iterator2 = iterator3.Take(num)) != null && (num2 == 0 || (iterator2 = iterator2.Skip(num2)) != null))
			{
				return iterator2;
			}
			return Array.Empty<TSource>();
		}
	}

	public static TSource[] ToArray<TSource>(this IEnumerable<TSource> source)
	{
		if (1 == 0)
		{
		}
		if (source is ICollection<TSource> collection)
		{
			return ICollectionToArray(collection);
		}
		return EnumerableToArray(source);
		[MethodImpl(MethodImplOptions.NoInlining)]
		static TSource[] EnumerableToArray(IEnumerable<TSource> enumerable)
		{
			if (enumerable == null)
			{
				ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
			}
			SegmentedArrayBuilder<TSource>.ScratchBuffer buffer = default(SegmentedArrayBuilder<TSource>.ScratchBuffer);
			SegmentedArrayBuilder<TSource> segmentedArrayBuilder = new SegmentedArrayBuilder<TSource>(global::_003CPrivateImplementationDetails_003E.InlineArrayAsSpan<SegmentedArrayBuilder<TSource>.ScratchBuffer, TSource>(ref buffer, 8));
			segmentedArrayBuilder.AddNonICollectionRangeInlined(enumerable);
			TSource[] result = segmentedArrayBuilder.ToArray();
			segmentedArrayBuilder.Dispose();
			return result;
		}
	}

	private static TSource[] ICollectionToArray<TSource>(ICollection<TSource> collection)
	{
		int count = collection.Count;
		if (count != 0)
		{
			TSource[] array = new TSource[count];
			collection.CopyTo(array, 0);
			return array;
		}
		return Array.Empty<TSource>();
	}

	public static List<TSource> ToList<TSource>(this IEnumerable<TSource> source)
	{
		if (source == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
		}
		if (1 == 0)
		{
		}
		return new List<TSource>(source);
	}

	public static Dictionary<TKey, TValue> ToDictionary<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> source) where TKey : notnull
	{
		return source.ToDictionary(null);
	}

	public static Dictionary<TKey, TValue> ToDictionary<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> source, IEqualityComparer<TKey>? comparer) where TKey : notnull
	{
		if (source == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
		}
		return new Dictionary<TKey, TValue>(source, comparer);
	}

	public static Dictionary<TKey, TValue> ToDictionary<TKey, TValue>(this IEnumerable<(TKey Key, TValue Value)> source) where TKey : notnull
	{
		return source.ToDictionary(null);
	}

	public static Dictionary<TKey, TValue> ToDictionary<TKey, TValue>(this IEnumerable<(TKey Key, TValue Value)> source, IEqualityComparer<TKey>? comparer) where TKey : notnull
	{
		return source.ToDictionary<(TKey, TValue), TKey, TValue>(((TKey Key, TValue Value) vt) => vt.Key, ((TKey Key, TValue Value) vt) => vt.Value, comparer);
	}

	public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector) where TKey : notnull
	{
		return source.ToDictionary(keySelector, null);
	}

	public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer) where TKey : notnull
	{
		if (source == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
		}
		if (keySelector == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.keySelector);
		}
		if (source.TryGetNonEnumeratedCount(out var count))
		{
			if (count == 0)
			{
				return new Dictionary<TKey, TSource>(comparer);
			}
			if (source is TSource[] array)
			{
				return SpanToDictionary(array, keySelector, comparer);
			}
			if (source is List<TSource> list)
			{
				return SpanToDictionary(CollectionsMarshal.AsSpan(list), keySelector, comparer);
			}
		}
		Dictionary<TKey, TSource> dictionary = new Dictionary<TKey, TSource>(count, comparer);
		foreach (TSource item in source)
		{
			dictionary.Add(keySelector(item), item);
		}
		return dictionary;
	}

	private static Dictionary<TKey, TSource> SpanToDictionary<TSource, TKey>(ReadOnlySpan<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
	{
		Dictionary<TKey, TSource> dictionary = new Dictionary<TKey, TSource>(source.Length, comparer);
		ReadOnlySpan<TSource> readOnlySpan = source;
		for (int i = 0; i < readOnlySpan.Length; i++)
		{
			TSource val = readOnlySpan[i];
			dictionary.Add(keySelector(val), val);
		}
		return dictionary;
	}

	public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector) where TKey : notnull
	{
		return source.ToDictionary(keySelector, elementSelector, null);
	}

	public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer) where TKey : notnull
	{
		if (source == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
		}
		if (keySelector == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.keySelector);
		}
		if (elementSelector == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.elementSelector);
		}
		if (source.TryGetNonEnumeratedCount(out var count))
		{
			if (count == 0)
			{
				return new Dictionary<TKey, TElement>(comparer);
			}
			if (source is TSource[] array)
			{
				return SpanToDictionary(array, keySelector, elementSelector, comparer);
			}
			if (source is List<TSource> list)
			{
				return SpanToDictionary(CollectionsMarshal.AsSpan(list), keySelector, elementSelector, comparer);
			}
		}
		Dictionary<TKey, TElement> dictionary = new Dictionary<TKey, TElement>(count, comparer);
		foreach (TSource item in source)
		{
			dictionary.Add(keySelector(item), elementSelector(item));
		}
		return dictionary;
	}

	private static Dictionary<TKey, TElement> SpanToDictionary<TSource, TKey, TElement>(ReadOnlySpan<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer)
	{
		Dictionary<TKey, TElement> dictionary = new Dictionary<TKey, TElement>(source.Length, comparer);
		ReadOnlySpan<TSource> readOnlySpan = source;
		for (int i = 0; i < readOnlySpan.Length; i++)
		{
			TSource arg = readOnlySpan[i];
			dictionary.Add(keySelector(arg), elementSelector(arg));
		}
		return dictionary;
	}

	public static IEnumerable<TSource> Union<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second)
	{
		return first.Union(second, null);
	}

	public static IEnumerable<TSource> Union<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource>? comparer)
	{
		if (first == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.first);
		}
		if (second == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.second);
		}
		if (!(first is UnionIterator<TSource> unionIterator) || !Utilities.AreEqualityComparersEqual<TSource>(comparer, unionIterator._comparer))
		{
			return new UnionIterator2<TSource>(first, second, comparer);
		}
		return unionIterator.Union(second);
	}

	public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
	{
		if (source == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
		}
		if (predicate == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.predicate);
		}
		if (source is Iterator<TSource> iterator)
		{
			return iterator.Where(predicate);
		}
		_ = 1;
		if (source is IList<TSource> source2)
		{
			return new SizeOptIListWhereIterator<TSource>(source2, predicate);
		}
		if (source is TSource[] array)
		{
			if (array.Length == 0)
			{
				return Array.Empty<TSource>();
			}
			return new ArrayWhereIterator<TSource>(array, predicate);
		}
		if (source is List<TSource> source3)
		{
			return new ListWhereIterator<TSource>(source3, predicate);
		}
		return new IEnumerableWhereIterator<TSource>(source, predicate);
	}

	public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source, Func<TSource, int, bool> predicate)
	{
		if (source == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
		}
		if (predicate == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.predicate);
		}
		if (IsEmptyArray(source))
		{
			return Array.Empty<TSource>();
		}
		return WhereIterator(source, predicate);
	}

	private static IEnumerable<TSource> WhereIterator<TSource>(IEnumerable<TSource> source, Func<TSource, int, bool> predicate)
	{
		int index = -1;
		foreach (TSource item in source)
		{
			index = checked(index + 1);
			if (predicate(item, index))
			{
				yield return item;
			}
		}
	}

	public static IEnumerable<TResult> Zip<TFirst, TSecond, TResult>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> resultSelector)
	{
		if (first == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.first);
		}
		if (second == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.second);
		}
		if (resultSelector == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.resultSelector);
		}
		return ZipIterator(first, second, resultSelector);
	}

	private static IEnumerable<TResult> ZipIterator<TFirst, TSecond, TResult>(IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> resultSelector)
	{
		using IEnumerator<TFirst> e1 = first.GetEnumerator();
		using IEnumerator<TSecond> e2 = second.GetEnumerator();
		while (e1.MoveNext() && e2.MoveNext())
		{
			yield return resultSelector(e1.Current, e2.Current);
		}
	}
}
