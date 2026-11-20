using System.Runtime.CompilerServices;

namespace System.Text.Json.Serialization;

public abstract class ReferenceHandler
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	internal virtual ReferenceResolver CreateResolver(bool writing)
	{
		throw new NotSupportedException("Linked away");
	}
}
