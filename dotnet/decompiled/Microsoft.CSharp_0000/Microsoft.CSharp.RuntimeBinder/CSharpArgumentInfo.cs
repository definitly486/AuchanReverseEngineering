using System.ComponentModel;

namespace Microsoft.CSharp.RuntimeBinder;

[EditorBrowsable(EditorBrowsableState.Never)]
public sealed class CSharpArgumentInfo
{
	internal static readonly CSharpArgumentInfo None = new CSharpArgumentInfo(CSharpArgumentInfoFlags.None, null);

	internal CSharpArgumentInfoFlags Flags { get; }

	internal string Name { get; }

	internal bool UseCompileTimeType => (Flags & CSharpArgumentInfoFlags.UseCompileTimeType) != 0;

	internal bool LiteralConstant => (Flags & CSharpArgumentInfoFlags.Constant) != 0;

	internal bool NamedArgument => (Flags & CSharpArgumentInfoFlags.NamedArgument) != 0;

	internal bool IsByRefOrOut => (Flags & (CSharpArgumentInfoFlags.IsRef | CSharpArgumentInfoFlags.IsOut)) != 0;

	internal bool IsOut => (Flags & CSharpArgumentInfoFlags.IsOut) != 0;

	internal bool IsStaticType => (Flags & CSharpArgumentInfoFlags.IsStaticType) != 0;

	private CSharpArgumentInfo(CSharpArgumentInfoFlags flags, string name)
	{
		Flags = flags;
		Name = name;
	}

	public static CSharpArgumentInfo Create(CSharpArgumentInfoFlags flags, string? name)
	{
		return new CSharpArgumentInfo(flags, name);
	}
}
