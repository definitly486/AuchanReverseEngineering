namespace Java.Interop;

internal delegate int AttachCurrentThreadDelegate(nint javavm, out nint env, ref JavaVMThreadAttachArgs args);
