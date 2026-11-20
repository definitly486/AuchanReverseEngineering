using System.Reflection;
using System.Runtime.CompilerServices;

namespace System.Xml.Serialization;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.ReturnValue, AllowMultiple = false)]
public class XmlChoiceIdentifierAttribute : Attribute
{
	public string MemberName
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw new NotSupportedException("Linked away");
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal MemberInfo GetMemberInfo()
	{
		throw new NotSupportedException("Linked away");
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void SetMemberInfo(MemberInfo memberInfo)
	{
		throw new NotSupportedException("Linked away");
	}
}
