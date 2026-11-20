using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auchan.Common.SupportChat.DTO;

public class WSDataContentDTO
{
	private StructMessageReceivedWSDTO? _structuredMessage;

	private bool _textParsed;

	[JsonProperty("text")]
	public string? Text { get; set; }

	[JsonProperty("buttons")]
	public List<string> Buttons { get; set; } = new List<string>();

	[JsonProperty("operatorInfo")]
	public WSDataOperatorDTO? OperatorInfo { get; set; }

	public StructMessageReceivedWSDTO? AsStructuredMessage()
	{
		if (_textParsed)
		{
			return _structuredMessage;
		}
		_textParsed = true;
		if (StructMessageReceivedWSDTO.TryParse(Text, out _structuredMessage))
		{
			return _structuredMessage;
		}
		return null;
	}
}
