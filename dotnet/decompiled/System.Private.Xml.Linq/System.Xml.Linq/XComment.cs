namespace System.Xml.Linq;

public class XComment : XNode
{
	internal string value;

	public override XmlNodeType NodeType => XmlNodeType.Comment;

	public string Value
	{
		get
		{
			return value;
		}
		set
		{
			ArgumentNullException.ThrowIfNull(value, "value");
			bool num = NotifyChanging(this, XObjectChangeEventArgs.Value);
			this.value = value;
			if (num)
			{
				NotifyChanged(this, XObjectChangeEventArgs.Value);
			}
		}
	}

	public XComment(string value)
	{
		ArgumentNullException.ThrowIfNull(value, "value");
		this.value = value;
	}

	public XComment(XComment other)
	{
		ArgumentNullException.ThrowIfNull(other, "other");
		value = other.value;
	}

	public override void WriteTo(XmlWriter writer)
	{
		ArgumentNullException.ThrowIfNull(writer, "writer");
		writer.WriteComment(value);
	}

	internal override XNode CloneNode()
	{
		return new XComment(this);
	}
}
