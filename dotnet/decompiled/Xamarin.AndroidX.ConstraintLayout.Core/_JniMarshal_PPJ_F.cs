using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate float _JniMarshal_PPJ_F(nint jnienv, nint klass, long p0);
