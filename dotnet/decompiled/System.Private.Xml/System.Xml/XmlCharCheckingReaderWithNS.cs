namespace System.Xml;

internal sealed class XmlCharCheckingReaderWithNS : XmlCharCheckingReader, IXmlNamespaceResolver
{
	internal IXmlNamespaceResolver readerAsNSResolver;

	internal XmlCharCheckingReaderWithNS(XmlReader reader, IXmlNamespaceResolver readerAsNSResolver, bool checkCharacters, bool ignoreWhitespace, bool ignoreComments, bool ignorePis, DtdProcessing dtdProcessing)
		: base(reader, checkCharacters, ignoreWhitespace, ignoreComments, ignorePis, dtdProcessing)
	{
		this.readerAsNSResolver = readerAsNSResolver;
	}

	string IXmlNamespaceResolver.LookupNamespace(string prefix)
	{
		return readerAsNSResolver.LookupNamespace(prefix);
	}

	string IXmlNamespaceResolver.LookupPrefix(string namespaceName)
	{
		return readerAsNSResolver.LookupPrefix(namespaceName);
	}
}
