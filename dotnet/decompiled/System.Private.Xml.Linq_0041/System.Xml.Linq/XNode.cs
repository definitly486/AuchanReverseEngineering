using System.Globalization;
using System.IO;
using System.Text;

namespace System.Xml.Linq;

public abstract class XNode : XObject
{
	internal XNode next;

	public XNode? NextNode
	{
		get
		{
			if (parent != null && this != parent.content)
			{
				return next;
			}
			return null;
		}
	}

	public XNode? PreviousNode
	{
		get
		{
			if (parent == null)
			{
				return null;
			}
			XNode xNode = ((XNode)parent.content).next;
			XNode result = null;
			while (xNode != this)
			{
				result = xNode;
				xNode = xNode.next;
			}
			return result;
		}
	}

	internal XNode()
	{
	}

	public void Remove()
	{
		if (parent == null)
		{
			throw new InvalidOperationException("InvalidOperation_MissingParent");
		}
		parent.RemoveNode(this);
	}

	public override string ToString()
	{
		return GetXmlString(GetSaveOptionsFromAnnotations());
	}

	public string ToString(SaveOptions options)
	{
		return GetXmlString(options);
	}

	public abstract void WriteTo(XmlWriter writer);

	internal virtual void AppendText(StringBuilder sb)
	{
	}

	internal abstract XNode CloneNode();

	private string GetXmlString(SaveOptions o)
	{
		using StringWriter stringWriter = new StringWriter(CultureInfo.InvariantCulture);
		XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
		xmlWriterSettings.OmitXmlDeclaration = true;
		if ((o & SaveOptions.DisableFormatting) == 0)
		{
			xmlWriterSettings.Indent = true;
		}
		if ((o & SaveOptions.OmitDuplicateNamespaces) != SaveOptions.None)
		{
			xmlWriterSettings.NamespaceHandling |= NamespaceHandling.OmitDuplicates;
		}
		if (this is XText)
		{
			xmlWriterSettings.ConformanceLevel = ConformanceLevel.Fragment;
		}
		using (XmlWriter writer = XmlWriter.Create(stringWriter, xmlWriterSettings))
		{
			if (this is XDocument xDocument)
			{
				xDocument.WriteContentTo(writer);
			}
			else
			{
				WriteTo(writer);
			}
		}
		return stringWriter.ToString();
	}
}
