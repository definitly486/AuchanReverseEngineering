namespace System.Xml.Serialization;

internal abstract class Mapping
{
	private bool _isSoap;

	internal bool IsSoap => _isSoap;

	internal Mapping()
	{
	}

	protected Mapping(Mapping mapping)
	{
		_isSoap = mapping._isSoap;
	}
}
