using System;

namespace NLog.Internal;

internal sealed class ReusableBufferCreator : ReusableObjectCreator<char[]>
{
	public ReusableBufferCreator(int initialCapacity)
		: base((Func<char[]>)(() => new char[initialCapacity]), (Action<char[]>)delegate
		{
		})
	{
	}
}
