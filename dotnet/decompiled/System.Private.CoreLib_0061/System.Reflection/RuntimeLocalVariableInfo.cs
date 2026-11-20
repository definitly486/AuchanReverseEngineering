using System.Runtime.InteropServices;

namespace System.Reflection;

[StructLayout(LayoutKind.Sequential)]
internal sealed class RuntimeLocalVariableInfo : LocalVariableInfo
{
	internal Type type;

	internal bool is_pinned;

	internal ushort position;

	public override bool IsPinned => is_pinned;

	public override int LocalIndex => position;

	public override Type LocalType => type;
}
