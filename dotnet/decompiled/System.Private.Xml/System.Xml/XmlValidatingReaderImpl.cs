using System.Runtime.CompilerServices;

namespace System.Xml;

internal sealed class XmlValidatingReaderImpl : XmlReader
{
	public override XmlNodeType NodeType
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw new NotSupportedException("Linked away");
		}
	}

	public override string LocalName
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw new NotSupportedException("Linked away");
		}
	}

	public override string NamespaceURI
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw new NotSupportedException("Linked away");
		}
	}

	public override string Prefix
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw new NotSupportedException("Linked away");
		}
	}

	public override string Value
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw new NotSupportedException("Linked away");
		}
	}

	public override int Depth
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw new NotSupportedException("Linked away");
		}
	}

	public override string BaseURI
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw new NotSupportedException("Linked away");
		}
	}

	public override bool IsEmptyElement
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw new NotSupportedException("Linked away");
		}
	}

	public override ReadState ReadState
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw new NotSupportedException("Linked away");
		}
	}

	public override bool EOF
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw new NotSupportedException("Linked away");
		}
	}

	public override XmlNameTable NameTable
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw new NotSupportedException("Linked away");
		}
	}

	public override int AttributeCount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw new NotSupportedException("Linked away");
		}
	}

	internal XmlTextReaderImpl ReaderImpl
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw new NotSupportedException("Linked away");
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override string GetAttribute(string name)
	{
		throw new NotSupportedException("Linked away");
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override string GetAttribute(string localName, string namespaceURI)
	{
		throw new NotSupportedException("Linked away");
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override string GetAttribute(int i)
	{
		throw new NotSupportedException("Linked away");
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool MoveToAttribute(string name)
	{
		throw new NotSupportedException("Linked away");
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool MoveToAttribute(string localName, string namespaceURI)
	{
		throw new NotSupportedException("Linked away");
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool MoveToFirstAttribute()
	{
		throw new NotSupportedException("Linked away");
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool MoveToNextAttribute()
	{
		throw new NotSupportedException("Linked away");
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool MoveToElement()
	{
		throw new NotSupportedException("Linked away");
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool Read()
	{
		throw new NotSupportedException("Linked away");
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override string LookupNamespace(string prefix)
	{
		throw new NotSupportedException("Linked away");
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool ReadAttributeValue()
	{
		throw new NotSupportedException("Linked away");
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void ResolveEntity()
	{
		throw new NotSupportedException("Linked away");
	}
}
