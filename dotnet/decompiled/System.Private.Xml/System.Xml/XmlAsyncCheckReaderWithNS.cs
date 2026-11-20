namespace System.Xml;

internal sealed class XmlAsyncCheckReaderWithNS : XmlAsyncCheckReader, IXmlNamespaceResolver
{
	private readonly IXmlNamespaceResolver _readerAsIXmlNamespaceResolver;

	public XmlAsyncCheckReaderWithNS(XmlReader reader)
		: base(reader)
	{
		_readerAsIXmlNamespaceResolver = (IXmlNamespaceResolver)reader;
	}

	string IXmlNamespaceResolver.LookupNamespace(string prefix)
	{
		return _readerAsIXmlNamespaceResolver.LookupNamespace(prefix);
	}

	string IXmlNamespaceResolver.LookupPrefix(string namespaceName)
	{
		return _readerAsIXmlNamespaceResolver.LookupPrefix(namespaceName);
	}
}
