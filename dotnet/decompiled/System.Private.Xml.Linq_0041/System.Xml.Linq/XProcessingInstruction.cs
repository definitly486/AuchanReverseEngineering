namespace System.Xml.Linq;

public class XProcessingInstruction : XNode
{
	internal string target;

	internal string data;

	public string Data
	{
		get
		{
			return data;
		}
		set
		{
			ArgumentNullException.ThrowIfNull(value, "value");
			bool num = NotifyChanging(this, XObjectChangeEventArgs.Value);
			data = value;
			if (num)
			{
				NotifyChanged(this, XObjectChangeEventArgs.Value);
			}
		}
	}

	public override XmlNodeType NodeType => XmlNodeType.ProcessingInstruction;

	public string Target => target;

	public XProcessingInstruction(string target, string data)
	{
		ArgumentNullException.ThrowIfNull(data, "data");
		ValidateName(target);
		this.target = target;
		this.data = data;
	}

	public XProcessingInstruction(XProcessingInstruction other)
	{
		ArgumentNullException.ThrowIfNull(other, "other");
		target = other.target;
		data = other.data;
	}

	public override void WriteTo(XmlWriter writer)
	{
		ArgumentNullException.ThrowIfNull(writer, "writer");
		writer.WriteProcessingInstruction(target, data);
	}

	internal override XNode CloneNode()
	{
		return new XProcessingInstruction(this);
	}

	private static void ValidateName(string name)
	{
		XmlConvert.VerifyNCName(name);
		if (string.Equals(name, "xml", StringComparison.OrdinalIgnoreCase))
		{
			throw new ArgumentException(System.SR.Format("Argument_InvalidPIName", name));
		}
	}
}
