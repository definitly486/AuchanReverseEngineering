using System.Runtime.CompilerServices;

namespace System.Collections.Generic;

public interface IEnumerable<out T> : IEnumerable
{
	[Intrinsic]
	new IEnumerator<T> GetEnumerator();
}
