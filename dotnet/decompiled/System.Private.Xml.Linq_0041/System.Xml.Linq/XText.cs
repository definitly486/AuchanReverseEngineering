using System.Text;

namespace System.Xml.Linq;

public class XText : XNode
{
	internal string text;

	public override XmlNodeType NodeType => XmlNodeType.Text;

	public string Value
	{
		get
		{
			return text;
		}
		set
		{
			ArgumentNullException.ThrowIfNull(value, "value");
			bool num = NotifyChanging(this, XObjectChangeEventArgs.Value);
			text = value;
			if (num)
			{
				NotifyChanged(this, XObjectChangeEventArgs.Value);
			}
		}
	}

	public XText(string value)
	{
		ArgumentNullException.ThrowIfNull(value, "value");
		text = value;
	}

	public XText(XText other)
	{
		ArgumentNullException.ThrowIfNull(other, "other");
		text = other.text;
	}

	public override void WriteTo(XmlWriter writer)
	{
		ArgumentNullException.ThrowIfNull(writer, "writer");
		if (parent is XDocument)
		{
			writer.WriteWhitespace(text);
		}
		else
		{
			writer.WriteString(text);
		}
	}

	internal override void AppendText(StringBuilder sb)
	{
		sb.Append(text);
	}

	internal override XNode CloneNode()
	{
		return new XText(this);
	}
}
