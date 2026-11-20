using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate void _JniMarshal_PPBs_V(nint jnienv, nint klass, sbyte p0, ushort p1);
