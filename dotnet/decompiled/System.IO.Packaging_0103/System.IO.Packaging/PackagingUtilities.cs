using System.Xml;

namespace System.IO.Packaging;

internal static class PackagingUtilities
{
	internal static readonly string RelationshipNamespaceUri = "http://schemas.openxmlformats.org/package/2006/relationships";

	internal static readonly ContentType RelationshipPartContentType = new ContentType("application/vnd.openxmlformats-package.relationships+xml");

	internal static void PerformInitialReadAndVerifyEncoding(XmlReader reader)
	{
		if (reader.Read() && reader.NodeType == XmlNodeType.XmlDeclaration && reader.Depth == 0)
		{
			string attribute = reader.GetAttribute("encoding");
			if (!string.IsNullOrEmpty(attribute) && !string.Equals(attribute, "utf-8", StringComparison.OrdinalIgnoreCase) && !string.Equals(attribute, "utf-16", StringComparison.OrdinalIgnoreCase))
			{
				throw new FileFormatException(System.SR.EncodingNotSupported);
			}
		}
	}

	internal static int GetNonXmlnsAttributeCount(XmlReader reader)
	{
		int num = 0;
		while (reader.MoveToNextAttribute())
		{
			if (!string.Equals(reader.Name, "xmlns", StringComparison.Ordinal) && !string.Equals(reader.Prefix, "xmlns", StringComparison.Ordinal))
			{
				num++;
			}
		}
		reader.MoveToElement();
		return num;
	}
}
