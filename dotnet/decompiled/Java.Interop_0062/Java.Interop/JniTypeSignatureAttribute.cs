using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Java.Interop;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = false)]
public sealed class JniTypeSignatureAttribute : Attribute
{
	private int arrayRank;

	[CompilerGenerated]
	private bool _003CIsKeyword_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CGenerateJavaPeer_003Ek__BackingField;

	public bool IsKeyword
	{
		[CompilerGenerated]
		set
		{
			_003CIsKeyword_003Ek__BackingField = value;
		}
	}

	public string SimpleReference { get; private set; }

	public int ArrayRank
	{
		set
		{
			if (value < 0)
			{
				throw new ArgumentException("ArrayRank cannot be less than zero.", "value");
			}
			arrayRank = value;
		}
	}

	public bool GenerateJavaPeer
	{
		[CompilerGenerated]
		set
		{
			_003CGenerateJavaPeer_003Ek__BackingField = value;
		}
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
	public Type? InvokerType { get; }

	public JniTypeSignatureAttribute(string simpleReference)
	{
		JniRuntime.JniTypeManager.AssertSimpleReference(simpleReference, "simpleReference");
		SimpleReference = simpleReference;
	}
}
