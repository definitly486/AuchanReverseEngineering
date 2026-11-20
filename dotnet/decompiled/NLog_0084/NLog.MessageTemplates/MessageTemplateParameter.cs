using NLog.Internal;

namespace NLog.MessageTemplates;

public readonly struct MessageTemplateParameter
{
	public string Name { get; }

	public object? Value { get; }

	public string? Format { get; }

	public CaptureType CaptureType { get; }

	public int? PositionalIndex
	{
		get
		{
			switch (Name)
			{
			case "0":
				return 0;
			case "1":
				return 1;
			case "2":
				return 2;
			case "3":
				return 3;
			case "4":
				return 4;
			case "5":
				return 5;
			case "6":
				return 6;
			case "7":
				return 7;
			case "8":
				return 8;
			case "9":
				return 9;
			default:
			{
				string name = Name;
				if (name != null && name.Length >= 1 && Name[0] >= '0' && Name[0] <= '9' && int.TryParse(Name, out var result))
				{
					return result;
				}
				return null;
			}
			}
		}
	}

	internal MessageTemplateParameter(string name, object? value, string? format)
	{
		Name = Guard.ThrowIfNull(name, "name");
		Value = value;
		Format = format;
		CaptureType = CaptureType.Normal;
	}

	public MessageTemplateParameter(string name, object? value, string? format, CaptureType captureType)
	{
		Name = Guard.ThrowIfNull(name, "name");
		Value = value;
		Format = format;
		CaptureType = captureType;
	}
}
