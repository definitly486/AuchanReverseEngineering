using System.Diagnostics.CodeAnalysis;

namespace System.Xml;

public abstract class XmlCharacterData : XmlLinkedNode
{
	private string _data;

	public override string? Value
	{
		get
		{
			return Data;
		}
		set
		{
			Data = value;
		}
	}

	public override string InnerText
	{
		get
		{
			return Value;
		}
		set
		{
			Value = value;
		}
	}

	public virtual string Data
	{
		get
		{
			if (_data != null)
			{
				return _data;
			}
			return string.Empty;
		}
		[param: AllowNull]
		set
		{
			XmlNode xmlNode = ParentNode;
			XmlNodeChangedEventArgs eventArgs = GetEventArgs(this, xmlNode, xmlNode, _data, value, XmlNodeChangedAction.Change);
			if (eventArgs != null)
			{
				BeforeEvent(eventArgs);
			}
			_data = value;
			if (eventArgs != null)
			{
				AfterEvent(eventArgs);
			}
		}
	}

	protected internal XmlCharacterData(string? data, XmlDocument doc)
		: base(doc)
	{
		_data = data;
	}

	internal static bool CheckOnData(string data)
	{
		return XmlCharType.IsOnlyWhitespace(data.AsSpan());
	}
}
