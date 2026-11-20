namespace System.Xml;

internal class XmlAsyncCheckReaderWithLineInfoNS : XmlAsyncCheckReaderWithLineInfo, IXmlNamespaceResolver
{
	private readonly IXmlNamespaceResolver _readerAsIXmlNamespaceResolver;

	public XmlAsyncCheckReaderWithLineInfoNS(XmlReader reader)
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
