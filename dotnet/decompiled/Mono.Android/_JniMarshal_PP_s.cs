using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate ushort _JniMarshal_PP_s(nint jnienv, nint klass);
[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate short _JniMarshal_PP_S(nint jnienv, nint klass);
