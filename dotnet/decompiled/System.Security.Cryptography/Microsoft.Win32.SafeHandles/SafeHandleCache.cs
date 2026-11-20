using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace Microsoft.Win32.SafeHandles;

internal static class SafeHandleCache<T> where T : SafeHandle
{
	private static T s_invalidHandle;

	internal static T GetInvalidHandle(Func<T> invalidHandleFactory)
	{
		return s_invalidHandle ?? CreateInvalidHandle(invalidHandleFactory);
		static T CreateInvalidHandle(Func<T> func)
		{
			T val = func();
			T val2 = Interlocked.CompareExchange(ref s_invalidHandle, val, null);
			if (val2 == null)
			{
				GC.SuppressFinalize(val);
				val2 = val;
			}
			else
			{
				val.Dispose();
			}
			return val2;
		}
	}

	internal static bool IsCachedInvalidHandle(SafeHandle handle)
	{
		return handle == s_invalidHandle;
	}
}
