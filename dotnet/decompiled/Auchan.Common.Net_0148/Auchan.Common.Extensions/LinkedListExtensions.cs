using System.Collections.Generic;

namespace Auchan.Common.Extensions;

public static class LinkedListExtensions
{
	public static IEnumerable<LinkedListNode<T>> EnumerateNodes<T>(this LinkedList<T> list)
	{
		for (LinkedListNode<T> node = list.First; node != null; node = node.Next)
		{
			yield return node;
		}
	}
}
