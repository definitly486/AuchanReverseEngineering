using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate sbyte _JniMarshal_PPIB_B(nint jnienv, nint klass, int p0, sbyte p1);
