using System;
using System.Collections.Generic;
using Auchan.Common.PersonalCabinet;

namespace Auchan.Common.AdminTool.Tags;

internal sealed class TagsReplacer : ITagsReplacer
{
	private const string LastNameTag = "{lastname}";

	private readonly IUserContext _userContext;

	private readonly Dictionary<string, Func<string?>> _tagsAndValuesToReplace;

	public TagsReplacer(IUserContext userContext)
	{
		_userContext = userContext;
		_tagsAndValuesToReplace = GetTagsAndValuesToReplace();
	}

	public string? Replace(string? source)
	{
		if (string.IsNullOrWhiteSpace(source))
		{
			return source;
		}
		foreach (KeyValuePair<string, Func<string>> item in _tagsAndValuesToReplace)
		{
			source = ((!(item.Key == "{lastname}")) ? source.Replace(item.Key, item.Value()) : ReplaceLastName(source, item.Value()));
		}
		return ClearUnknownTags(source);
	}

	private Dictionary<string, Func<string?>> GetTagsAndValuesToReplace()
	{
		return new Dictionary<string, Func<string>>
		{
			{
				"{firstname}",
				() => _userContext.Profile?.FirstName
			},
			{
				"{lastname}",
				() => _userContext.Profile?.LastName
			}
		};
	}

	private static string ReplaceLastName(string source, string? lastName)
	{
		int num = source.IndexOf("{lastname}", StringComparison.Ordinal);
		if (num == -1)
		{
			return source;
		}
		if (!string.IsNullOrEmpty(lastName))
		{
			return source.Replace("{lastname}", lastName);
		}
		if (num > 0)
		{
			return source.Remove(num - 1, "{lastname}".Length + 1);
		}
		return source.Remove(num, "{lastname}".Length);
	}

	private static string ClearUnknownTags(string source)
	{
		while (true)
		{
			int num = source.LastIndexOf('{');
			int num2 = source.LastIndexOf('}');
			if (num == -1 && num2 == -1)
			{
				break;
			}
			source = ((num != -1) ? ((num2 != -1) ? ((num2 <= num) ? source.Remove(num, 1) : source.Remove(num, num2 - num + 1)) : source.Remove(num, 1)) : source.Remove(num2, 1));
		}
		return source;
	}
}
