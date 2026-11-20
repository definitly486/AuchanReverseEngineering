using System.Diagnostics.CodeAnalysis;

namespace System.Net.Http.Headers;

public class EntityTagHeaderValue : ICloneable
{
	public string Tag { get; private init; }

	public bool IsWeak { get; private init; }

	public static EntityTagHeaderValue Any { get; } = new EntityTagHeaderValue("*", isWeak: false, _: false);

	private EntityTagHeaderValue(string tag, bool isWeak, bool _)
	{
		Tag = tag;
		IsWeak = isWeak;
	}

	public EntityTagHeaderValue(string tag)
		: this(tag, isWeak: false)
	{
	}

	public EntityTagHeaderValue(string tag, bool isWeak)
	{
		HeaderUtilities.CheckValidQuotedString(tag, "tag");
		Tag = tag;
		IsWeak = isWeak;
	}

	private EntityTagHeaderValue(EntityTagHeaderValue source)
	{
		Tag = source.Tag;
		IsWeak = source.IsWeak;
	}

	public override string ToString()
	{
		if (!IsWeak)
		{
			return Tag;
		}
		return "W/" + Tag;
	}

	public override bool Equals([NotNullWhen(true)] object? obj)
	{
		if (obj is EntityTagHeaderValue entityTagHeaderValue && IsWeak == entityTagHeaderValue.IsWeak)
		{
			return string.Equals(Tag, entityTagHeaderValue.Tag, StringComparison.Ordinal);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return HashCode.Combine(Tag, IsWeak);
	}

	public static EntityTagHeaderValue Parse(string input)
	{
		int index = 0;
		return (EntityTagHeaderValue)GenericHeaderParser.SingleValueEntityTagParser.ParseValue(input, null, ref index);
	}

	public static bool TryParse([NotNullWhen(true)] string? input, [NotNullWhen(true)] out EntityTagHeaderValue? parsedValue)
	{
		int index = 0;
		parsedValue = null;
		if (GenericHeaderParser.SingleValueEntityTagParser.TryParseValue(input, null, ref index, out var parsedValue2))
		{
			parsedValue = (EntityTagHeaderValue)parsedValue2;
			return true;
		}
		return false;
	}

	internal static int GetEntityTagLength(string input, int startIndex, out EntityTagHeaderValue parsedValue)
	{
		parsedValue = null;
		if (string.IsNullOrEmpty(input) || startIndex >= input.Length)
		{
			return 0;
		}
		bool isWeak = false;
		int num = startIndex;
		char c = input[startIndex];
		if (c == '*')
		{
			parsedValue = Any;
			num++;
		}
		else
		{
			if (c == 'W' || c == 'w')
			{
				num++;
				if (num + 2 >= input.Length || input[num] != '/')
				{
					return 0;
				}
				isWeak = true;
				num++;
				num += HttpRuleParser.GetWhitespaceLength(input, num);
			}
			if (num == input.Length || HttpRuleParser.GetQuotedStringLength(input, num, out var length) != HttpParseResult.Parsed)
			{
				return 0;
			}
			parsedValue = new EntityTagHeaderValue(input.Substring(num, length), isWeak, _: false);
			num += length;
		}
		num += HttpRuleParser.GetWhitespaceLength(input, num);
		return num - startIndex;
	}

	object ICloneable.Clone()
	{
		if (this != Any)
		{
			return new EntityTagHeaderValue(this);
		}
		return Any;
	}
}
