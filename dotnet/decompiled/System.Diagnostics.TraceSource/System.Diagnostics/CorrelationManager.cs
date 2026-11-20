using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;

namespace System.Diagnostics;

public class CorrelationManager
{
	private sealed class StackNode
	{
		internal int Count
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				throw new NotSupportedException("Linked away");
			}
		}

		internal object Value
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				throw new NotSupportedException("Linked away");
			}
		}

		internal StackNode Prev
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				throw new NotSupportedException("Linked away");
			}
		}
	}

	private sealed class AsyncLocalStackWrapper : Stack
	{
		private readonly AsyncLocal<StackNode> _stack;

		public override int Count => _stack.Value?.Count ?? 0;

		internal AsyncLocalStackWrapper(AsyncLocal<StackNode> stack)
		{
			_stack = stack;
		}

		public override object Clone()
		{
			return new AsyncLocalStackWrapper(_stack);
		}

		public override IEnumerator GetEnumerator()
		{
			return GetEnumerator(_stack.Value);
		}

		public override void CopyTo(Array array, int index)
		{
			for (StackNode stackNode = _stack.Value; stackNode != null; stackNode = stackNode.Prev)
			{
				array.SetValue(stackNode.Value, index++);
			}
		}

		private static IEnumerator GetEnumerator(StackNode n)
		{
			while (n != null)
			{
				yield return n.Value;
				n = n.Prev;
			}
		}

		public override object[] ToArray()
		{
			StackNode stackNode = _stack.Value;
			if (stackNode == null)
			{
				return Array.Empty<object>();
			}
			List<object> list = new List<object>();
			do
			{
				list.Add(stackNode.Value);
				stackNode = stackNode.Prev;
			}
			while (stackNode != null);
			return list.ToArray();
		}
	}

	private readonly AsyncLocal<Guid> _activityId = new AsyncLocal<Guid>();

	private readonly AsyncLocal<StackNode> _stack = new AsyncLocal<StackNode>();

	private readonly AsyncLocalStackWrapper _stackWrapper;

	public Stack LogicalOperationStack => _stackWrapper;

	internal CorrelationManager()
	{
		_stackWrapper = new AsyncLocalStackWrapper(_stack);
	}
}
