using System.Collections.Generic;

namespace System.Xml.Schema;

internal sealed class AllElementsContentValidator : ContentValidator
{
	private readonly Dictionary<XmlQualifiedName, int> _elements;

	private readonly object[] _particles;

	private readonly BitSet _isRequired;

	private int _countRequired;

	public override bool IsEmptiable
	{
		get
		{
			if (!base.IsEmptiable)
			{
				return _countRequired == 0;
			}
			return true;
		}
	}

	public AllElementsContentValidator(XmlSchemaContentType contentType, int size, bool isEmptiable)
		: base(contentType, isOpen: false, isEmptiable)
	{
		_elements = new Dictionary<XmlQualifiedName, int>(size);
		_particles = new object[size];
		_isRequired = new BitSet(size);
	}

	public bool AddElement(XmlQualifiedName name, object particle, bool isEmptiable)
	{
		int count = _elements.Count;
		if (_elements.TryAdd(name, count))
		{
			_particles[count] = particle;
			if (!isEmptiable)
			{
				_isRequired.Set(count);
				_countRequired++;
			}
			return true;
		}
		return false;
	}
}
