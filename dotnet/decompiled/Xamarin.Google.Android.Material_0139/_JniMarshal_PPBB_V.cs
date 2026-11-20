using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate void _JniMarshal_PPBB_V(nint jnienv, nint klass, sbyte p0, sbyte p1);
