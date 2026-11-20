using System.Runtime.CompilerServices;

namespace System.Xml.Serialization;

[AttributeUsage(AttributeTargets.Assembly)]
public sealed class XmlSerializerVersionAttribute : Attribute
{
	public string? ParentAssemblyId
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw new NotSupportedException("Linked away");
		}
	}

	public string? Namespace
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw new NotSupportedException("Linked away");
		}
	}
}
