using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Xml.Schema;

namespace System.Xml.XPath;

[DebuggerDisplay("{debuggerDisplayProxy}")]
public abstract class XPathNavigator : XPathItem, ICloneable, IXmlNamespaceResolver
{
	public override XmlSchemaType? XmlType
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw new NotSupportedException("Linked away");
		}
	}

	public override object TypedValue
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw new NotSupportedException("Linked away");
		}
	}

	public override Type ValueType
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw new NotSupportedException("Linked away");
		}
	}

	public override bool ValueAsBoolean
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw new NotSupportedException("Linked away");
		}
	}

	public override DateTime ValueAsDateTime
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw new NotSupportedException("Linked away");
		}
	}

	public override double ValueAsDouble
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw new NotSupportedException("Linked away");
		}
	}

	public override int ValueAsInt
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw new NotSupportedException("Linked away");
		}
	}

	public override long ValueAsLong
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw new NotSupportedException("Linked away");
		}
	}

	private object debuggerDisplayProxy
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw new NotSupportedException("Linked away");
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override object ValueAs(Type returnType, IXmlNamespaceResolver? nsResolver)
	{
		throw new NotSupportedException("Linked away");
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	object ICloneable.Clone()
	{
		throw new NotSupportedException("Linked away");
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual string? LookupNamespace(string prefix)
	{
		throw new NotSupportedException("Linked away");
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual string? LookupPrefix(string namespaceURI)
	{
		throw new NotSupportedException("Linked away");
	}
}
