using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace Auchan.Common.SupportChat.DTO;

public abstract record StructMessageReceivedWSDTO : BaseWSMessageDTO
{
	public abstract CacheMessageType CacheMessageType { get; }

	public static bool TryParse(string? text, [NotNullWhen(true)] out StructMessageReceivedWSDTO? message)
	{
		message = null;
		if (text != null)
		{
			foreach (var (text3, type2) in SupportedTypes())
			{
				if (!text.StartsWith(text3))
				{
					continue;
				}
				string value = text.Substring(text3.Length);
				try
				{
					if (JsonConvert.DeserializeObject(value, type2) is StructMessageReceivedWSDTO structMessageReceivedWSDTO)
					{
						message = structMessageReceivedWSDTO with
						{
							Event = WSMessageEventType.NewMessage
						};
						return true;
					}
				}
				catch
				{
					return false;
				}
			}
		}
		return false;
	}

	private static IEnumerable<KeyValuePair<string, Type>> SupportedTypes()
	{
		yield return new KeyValuePair<string, Type>("[STRUCT=Chips]", typeof(ChipsStructMessageReceivedWSDTO));
		yield return new KeyValuePair<string, Type>("[STRUCT=Products]", typeof(ProductsStructMessageReceiveWSDTO));
	}

	[CompilerGenerated]
	[SetsRequiredMembers]
	protected StructMessageReceivedWSDTO(StructMessageReceivedWSDTO original)
		: base(original)
	{
	}

	protected StructMessageReceivedWSDTO()
	{
	}
}
