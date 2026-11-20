using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate sbyte _JniMarshal_PPIFF_B(nint jnienv, nint klass, int p0, float p1, float p2);
