using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate long _JniMarshal_PP_J(nint jnienv, nint klass);
