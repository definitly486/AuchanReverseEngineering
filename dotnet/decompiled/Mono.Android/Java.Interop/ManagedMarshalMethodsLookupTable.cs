using System;
using System.Runtime.InteropServices;
using Android.Runtime;

namespace Java.Interop;

internal class ManagedMarshalMethodsLookupTable
{
	[UnmanagedCallersOnly]
	internal unsafe static void GetFunctionPointer(int assemblyIndex, int classIndex, int methodIndex, nint* target)
	{
		try
		{
			nint functionPointer = GetFunctionPointer(assemblyIndex, classIndex, methodIndex);
			if (functionPointer == IntPtr.Zero || functionPointer == -1)
			{
				throw new InvalidOperationException($"Failed to get function pointer for ({assemblyIndex}, {classIndex}, {methodIndex})");
			}
			*target = functionPointer;
		}
		catch (Exception e)
		{
			AndroidEnvironment.UnhandledException(e);
			AndroidEnvironment.FailFast("GetFunctionPointer failed: should not be reached");
		}
	}

	private static nint GetFunctionPointer(int assemblyIndex, int classIndex, int methodIndex)
	{
		throw new NotImplementedException();
	}
}
