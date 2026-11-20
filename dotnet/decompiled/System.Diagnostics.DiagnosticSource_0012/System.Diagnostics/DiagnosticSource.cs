using System.Diagnostics.CodeAnalysis;

namespace System.Diagnostics;

public abstract class DiagnosticSource
{
	[RequiresUnreferencedCode("The type of object being written to DiagnosticSource cannot be discovered statically.")]
	public abstract void Write(string name, object? value);

	[RequiresUnreferencedCode("Only the properties of the T type will be preserved. Properties of referenced types and properties of derived types may be trimmed.")]
	public void Write<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicProperties)] T>(string name, T value)
	{
		Write(name, (object?)value);
	}

	public abstract bool IsEnabled(string name);

	public virtual bool IsEnabled(string name, object? arg1, object? arg2 = null)
	{
		return IsEnabled(name);
	}
}
