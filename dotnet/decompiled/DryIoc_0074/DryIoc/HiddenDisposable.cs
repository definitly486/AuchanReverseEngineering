using System.Reflection;

namespace DryIoc;

public sealed class HiddenDisposable
{
	internal static ConstructorInfo Ctor = typeof(HiddenDisposable).GetConstructors()[0];

	internal static FieldInfo ValueField = typeof(HiddenDisposable).GetField("Value");

	public readonly object Value;

	public HiddenDisposable(object value)
	{
		Value = value;
	}
}
