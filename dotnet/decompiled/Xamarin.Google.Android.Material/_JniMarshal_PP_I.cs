using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate int _JniMarshal_PP_I(nint jnienv, nint klass);
