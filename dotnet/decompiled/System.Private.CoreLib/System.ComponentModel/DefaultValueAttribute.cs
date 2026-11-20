using System.Diagnostics.CodeAnalysis;

namespace System.ComponentModel;

[AttributeUsage(AttributeTargets.All)]
public class DefaultValueAttribute : Attribute
{
	private object _value;

	private static readonly object s_throwSentinel;

	[FeatureSwitchDefinition("System.ComponentModel.DefaultValueAttribute.IsSupported")]
	[FeatureGuard(typeof(RequiresUnreferencedCodeAttribute))]
	internal static bool IsSupported => false;

	public virtual object? Value
	{
		get
		{
			_ = 0;
			if (_value == s_throwSentinel)
			{
				throw new ArgumentException("RuntimeInstanceNotAllowed");
			}
			return _value;
		}
	}

	public DefaultValueAttribute(Type type, string? value)
	{
		_ = 0;
		_value = s_throwSentinel;
	}

	public DefaultValueAttribute(char value)
	{
		_value = value;
	}

	public DefaultValueAttribute(byte value)
	{
		_value = value;
	}

	public DefaultValueAttribute(short value)
	{
		_value = value;
	}

	public DefaultValueAttribute(int value)
	{
		_value = value;
	}

	public DefaultValueAttribute(long value)
	{
		_value = value;
	}

	public DefaultValueAttribute(float value)
	{
		_value = value;
	}

	public DefaultValueAttribute(double value)
	{
		_value = value;
	}

	public DefaultValueAttribute(bool value)
	{
		_value = value;
	}

	public DefaultValueAttribute(string? value)
	{
		_value = value;
	}

	public DefaultValueAttribute(object? value)
	{
		_value = value;
	}

	[CLSCompliant(false)]
	public DefaultValueAttribute(sbyte value)
	{
		_value = value;
	}

	[CLSCompliant(false)]
	public DefaultValueAttribute(ushort value)
	{
		_value = value;
	}

	[CLSCompliant(false)]
	public DefaultValueAttribute(uint value)
	{
		_value = value;
	}

	[CLSCompliant(false)]
	public DefaultValueAttribute(ulong value)
	{
		_value = value;
	}

	public override bool Equals([NotNullWhen(true)] object? obj)
	{
		if (obj == this)
		{
			return true;
		}
		if (!(obj is DefaultValueAttribute defaultValueAttribute))
		{
			return false;
		}
		if (Value == null)
		{
			return defaultValueAttribute.Value == null;
		}
		return Value.Equals(defaultValueAttribute.Value);
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	protected void SetValue(object? value)
	{
		_value = value;
	}

	static DefaultValueAttribute()
	{
		_ = 0;
		s_throwSentinel = new object();
	}
}
