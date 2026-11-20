using System;
using System.Runtime.CompilerServices;

namespace SkiaSharp;

public class GRContextOptions
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	internal GRContextOptionsNative ToNative()
	{
		throw new NotSupportedException("Linked away");
	}
}
