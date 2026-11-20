using System;

namespace Java.Interop;

[Flags]
public enum JniObjectReferenceOptions
{
	None = 0,
	Copy = 1,
	CopyAndDispose = 3,
	CopyAndDoNotRegister = 5
}
