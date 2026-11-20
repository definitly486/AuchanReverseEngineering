using System.Runtime.InteropServices;

namespace System.Reflection.Emit;

[StructLayout(LayoutKind.Sequential)]
internal sealed class RuntimeLocalBuilder : LocalBuilder
{
	internal Type type;

	internal bool is_pinned;

	internal ushort position;

	private string name;

	internal ILGenerator ilgen;

	private int startOffset;

	private int endOffset;

	public override Type LocalType => type;

	public override bool IsPinned => is_pinned;

	public override int LocalIndex => position;

	internal RuntimeLocalBuilder(Type t, ILGenerator ilgen)
	{
		type = t;
		this.ilgen = ilgen;
	}
}
