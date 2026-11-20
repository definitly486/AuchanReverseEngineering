using System;
using NLog.Internal;

namespace NLog.Common;

public static class ConversionHelpers
{
	public static bool TryParseEnum<TEnum>(string inputValue, out TEnum resultValue, TEnum defaultValue = default(TEnum)) where TEnum : struct
	{
		if (!TryParseEnum<TEnum>(inputValue, ignoreCase: true, out resultValue))
		{
			resultValue = defaultValue;
			return false;
		}
		return true;
	}

	internal static bool TryParseEnum(string inputValue, Type enumType, out object? resultValue)
	{
		if (StringHelpers.IsNullOrWhiteSpace(inputValue))
		{
			resultValue = null;
			return false;
		}
		try
		{
			resultValue = Enum.Parse(enumType, inputValue, ignoreCase: true);
			return true;
		}
		catch (ArgumentException)
		{
			resultValue = null;
			return false;
		}
	}

	internal static bool TryParseEnum<TEnum>(string inputValue, bool ignoreCase, out TEnum resultValue) where TEnum : struct
	{
		if (StringHelpers.IsNullOrWhiteSpace(inputValue))
		{
			resultValue = default(TEnum);
			return false;
		}
		return Enum.TryParse<TEnum>(inputValue, ignoreCase, out resultValue);
	}

	private static bool TryParseEnum_net3<TEnum>(string value, bool ignoreCase, out TEnum result) where TEnum : struct
	{
		Type typeFromHandle = typeof(TEnum);
		if (!typeFromHandle.IsEnum)
		{
			throw new ArgumentException("Type '" + typeFromHandle.FullName + "' is not an enum");
		}
		if (StringHelpers.IsNullOrWhiteSpace(value))
		{
			result = default(TEnum);
			return false;
		}
		try
		{
			result = (TEnum)Enum.Parse(typeFromHandle, value, ignoreCase);
			return true;
		}
		catch (Exception)
		{
			result = default(TEnum);
			return false;
		}
	}
}
