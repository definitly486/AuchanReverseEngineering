using System.Runtime.CompilerServices;

namespace System.Xml.Serialization;

internal sealed class MembersMapping : TypeMapping
{
	internal MemberMapping[] Members
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw new NotSupportedException("Linked away");
		}
	}

	internal bool HasWrapperElement
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw new NotSupportedException("Linked away");
		}
	}

	internal bool ValidateRpcWrapperElement
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw new NotSupportedException("Linked away");
		}
	}

	internal bool WriteAccessors
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw new NotSupportedException("Linked away");
		}
	}
}
