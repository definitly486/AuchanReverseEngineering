using System;

namespace Refit;

public class CamelCaseUrlParameterKeyFormatter : IUrlParameterKeyFormatter
{
	public string Format(string key)
	{
		if (string.IsNullOrEmpty(key) || !char.IsUpper(key[0]))
		{
			return key;
		}
		return string.Create(key.Length, key, delegate(Span<char> chars, string name)
		{
			name.CopyTo(chars);
			FixCasing(chars);
		});
	}

	private static void FixCasing(Span<char> chars)
	{
		for (int i = 0; i < chars.Length && (i != 1 || char.IsUpper(chars[i])); i++)
		{
			bool flag = i + 1 < chars.Length;
			if (!(i > 0 && flag) || char.IsUpper(chars[i + 1]))
			{
				chars[i] = char.ToLowerInvariant(chars[i]);
				continue;
			}
			break;
		}
	}
}
