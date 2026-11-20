using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate bool _JniMarshal_PPJ_Z(nint jnienv, nint klass, long p0);
