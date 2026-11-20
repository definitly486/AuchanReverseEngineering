using System.Runtime.CompilerServices;

namespace System.Collections.Generic;

[Intrinsic]
public interface IEnumerator<out T> : IDisposable, IEnumerator
{
	new T Current { get; }
}
