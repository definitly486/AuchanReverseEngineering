using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace System.Reflection;

public readonly struct CustomAttributeTypedArgument : IEquatable<CustomAttributeTypedArgument>
{
	private readonly object _value;

	private readonly Type _argumentType;

	public Type ArgumentType => _argumentType;

	public object? Value => _value;

	public static bool operator ==(CustomAttributeTypedArgument left, CustomAttributeTypedArgument right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(CustomAttributeTypedArgument left, CustomAttributeTypedArgument right)
	{
		return !left.Equals(right);
	}

	public CustomAttributeTypedArgument(Type argumentType, object? value)
	{
		ArgumentNullException.ThrowIfNull(argumentType, "argumentType");
		_value = CanonicalizeValue(value);
		_argumentType = argumentType;
	}

	public CustomAttributeTypedArgument(object value)
	{
		ArgumentNullException.ThrowIfNull(value, "value");
		_value = CanonicalizeValue(value);
		_argumentType = value.GetType();
	}

	public override string ToString()
	{
		return ToString(typed: false);
	}

	internal string ToString(bool typed)
	{
		if ((object)_argumentType == null)
		{
			return base.ToString();
		}
		if (ArgumentType.IsEnum)
		{
			if (typed)
			{
				return $"{Value}";
			}
			return $"({ArgumentType.FullName}){Value}";
		}
		if (Value == null)
		{
			if (!typed)
			{
				return "(" + ArgumentType.Name + ")null";
			}
			return "null";
		}
		if (ArgumentType == typeof(string))
		{
			return $"\"{Value}\"";
		}
		if (ArgumentType == typeof(char))
		{
			return $"'{Value}'";
		}
		if (ArgumentType == typeof(Type))
		{
			return "typeof(" + ((Type)Value).FullName + ")";
		}
		if (ArgumentType.IsArray)
		{
			IList<CustomAttributeTypedArgument> list = (IList<CustomAttributeTypedArgument>)Value;
			Type elementType = ArgumentType.GetElementType();
			Span<char> initialBuffer = stackalloc char[256];
			ValueStringBuilder valueStringBuilder = new ValueStringBuilder(initialBuffer);
			valueStringBuilder.Append("new ");
			valueStringBuilder.Append(elementType.IsEnum ? elementType.FullName : elementType.Name);
			valueStringBuilder.Append('[');
			int count = list.Count;
			valueStringBuilder.Append(count.ToString());
			valueStringBuilder.Append("] { ");
			for (int i = 0; i < count; i++)
			{
				if (i != 0)
				{
					valueStringBuilder.Append(", ");
				}
				valueStringBuilder.Append(list[i].ToString(elementType != typeof(object)));
			}
			valueStringBuilder.Append(" }");
			return valueStringBuilder.ToString();
		}
		if (typed)
		{
			return $"{Value}";
		}
		return $"({ArgumentType.Name}){Value}";
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	public override bool Equals([NotNullWhen(true)] object? obj)
	{
		if (obj is CustomAttributeTypedArgument other)
		{
			return Equals(other);
		}
		return false;
	}

	public bool Equals(CustomAttributeTypedArgument other)
	{
		if (_value == other._value)
		{
			return _argumentType == other._argumentType;
		}
		return false;
	}

	private static object CanonicalizeValue(object value)
	{
		if (!(value is Enum obj))
		{
			return value;
		}
		return obj.GetValue();
	}
}
