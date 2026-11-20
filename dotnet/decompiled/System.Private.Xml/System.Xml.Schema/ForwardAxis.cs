namespace System.Xml.Schema;

internal sealed class ForwardAxis
{
	private readonly DoubleLinkAxis _topNode;

	private readonly DoubleLinkAxis _rootNode;

	private readonly bool _isAttribute;

	private readonly bool _isDss;

	private readonly bool _isSelfAxis;

	public ForwardAxis(DoubleLinkAxis axis, bool isdesorself)
	{
		_isDss = isdesorself;
		_isAttribute = Asttree.IsAttribute(axis);
		_topNode = axis;
		_rootNode = axis;
		while (_rootNode.Input != null)
		{
			_rootNode = (DoubleLinkAxis)_rootNode.Input;
		}
		_isSelfAxis = Asttree.IsSelf(_topNode);
	}
}
