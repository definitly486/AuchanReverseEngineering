using System.Diagnostics;

namespace System.Text.Json;

[DebuggerDisplay("{DebuggerDisplay,nq}")]
public readonly struct JsonProperty
{
	public JsonElement Value { get; }

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string DebuggerDisplay
	{
		get
		{
			if (Value.ValueKind != JsonValueKind.Undefined)
			{
				return "\"" + ToString() + "\"";
			}
			return "<Undefined>";
		}
	}

	internal JsonProperty(JsonElement value)
	{
		Value = value;
	}

	public override string ToString()
	{
		return Value.GetPropertyRawText();
	}
}
