using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;

namespace Auchan.Common.Common;

public sealed record ReadOnlyEquatableList<T> : IReadOnlyList<T>, IEnumerable<T>, IEnumerable, IReadOnlyCollection<T>, IEquatable<IReadOnlyList<T>>, IEquatable<ReadOnlyEquatableList<T>> where T : IEquatable<T>
{
	public T this[int index] => _list[index];

	public int Count => _list.Count;

	private readonly IReadOnlyList<T> _list;

	public ReadOnlyEquatableList()
	{
		_list = Array.Empty<T>();
	}

	[JsonConstructor]
	public ReadOnlyEquatableList(IReadOnlyList<T> list)
	{
		_list = list;
	}

	public IEnumerator<T> GetEnumerator()
	{
		return _list.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return ((IEnumerable)_list).GetEnumerator();
	}

	public override int GetHashCode()
	{
		int num = EqualityComparer<Type>.Default.GetHashCode(EqualityContract);
		EqualityComparer<T> equalityComparer = EqualityComparer<T>.Default;
		for (int i = 0; i < _list.Count; i++)
		{
			num = num * -1521134295 + equalityComparer.GetHashCode(_list[i]);
		}
		return num;
	}

	public bool Equals(ReadOnlyEquatableList<T>? other)
	{
		return Equals((IReadOnlyList<T>?)other);
	}

	public bool Equals(IReadOnlyList<T>? other)
	{
		if (this != other)
		{
			if (other != null)
			{
				return this.SequenceEqual(other);
			}
			return false;
		}
		return true;
	}

	[CompilerGenerated]
	private bool PrintMembers(StringBuilder builder)
	{
		RuntimeHelpers.EnsureSufficientExecutionStack();
		builder.Append("Count = ");
		builder.Append(Count.ToString());
		return true;
	}
}
