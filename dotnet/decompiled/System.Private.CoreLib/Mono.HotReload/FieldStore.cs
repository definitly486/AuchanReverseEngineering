using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Mono.HotReload;

[StructLayout(LayoutKind.Sequential)]
internal sealed class FieldStore
{
	private readonly object _loc;

	private FieldStore(object loc)
	{
		_loc = loc;
	}

	[RequiresUnreferencedCode("Hot reload required untrimmed apps")]
	public static FieldStore Create(RuntimeTypeHandle type)
	{
		Type type2 = Type.GetTypeFromHandle(type) ?? throw new ArgumentException("Arg_InvalidHandle", "type");
		object loc;
		if (type2.IsPrimitive || type2.IsValueType)
		{
			loc = RuntimeHelpers.GetUninitializedObject(type2);
		}
		else
		{
			if (!type2.IsClass && !type2.IsInterface)
			{
				throw new ArgumentException("Arg_EnC_ExpectedPrimitive");
			}
			loc = null;
		}
		return new FieldStore(loc);
	}
}
