using System;
using System.Runtime.CompilerServices;

namespace Java.Interop;

public abstract class JniMemberSignatureAttribute : Attribute
{
	[CompilerGenerated]
	private readonly string _003CMemberName_003Ek__BackingField;

	[CompilerGenerated]
	private readonly string _003CMemberSignature_003Ek__BackingField;

	internal JniMemberSignatureAttribute(string memberName, string memberSignature)
	{
		if (string.IsNullOrEmpty(memberName))
		{
			throw new ArgumentNullException("memberName");
		}
		if (string.IsNullOrEmpty(memberSignature))
		{
			throw new ArgumentNullException("memberSignature");
		}
		_003CMemberName_003Ek__BackingField = memberName;
		_003CMemberSignature_003Ek__BackingField = memberSignature;
	}
}
