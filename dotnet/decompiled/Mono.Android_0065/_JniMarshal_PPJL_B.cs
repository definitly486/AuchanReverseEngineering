using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate sbyte _JniMarshal_PPJL_B(nint jnienv, nint klass, long p0, nint p1);
