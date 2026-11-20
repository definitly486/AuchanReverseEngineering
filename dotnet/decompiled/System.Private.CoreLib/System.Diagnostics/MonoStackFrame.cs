using System.Reflection;
using System.Runtime.InteropServices;

namespace System.Diagnostics;

[StructLayout(LayoutKind.Sequential)]
internal sealed class MonoStackFrame
{
	internal int ilOffset;

	internal int nativeOffset;

	internal long methodAddress;

	internal uint methodIndex;

	internal MethodBase methodBase;

	internal string fileName;

	internal int lineNumber;

	internal int columnNumber;

	internal string internalMethodName;

	internal bool isLastFrameFromForeignException;
}
