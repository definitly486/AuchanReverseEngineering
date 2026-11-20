using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate sbyte _JniMarshal_PPILI_B(nint jnienv, nint klass, int p0, nint p1, int p2);
