using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate sbyte _JniMarshal_PPIIILL_B(nint jnienv, nint klass, int p0, int p1, int p2, nint p3, nint p4);
