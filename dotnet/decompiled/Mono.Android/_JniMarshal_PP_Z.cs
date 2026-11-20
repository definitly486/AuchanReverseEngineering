using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate bool _JniMarshal_PP_Z(nint jnienv, nint klass);
