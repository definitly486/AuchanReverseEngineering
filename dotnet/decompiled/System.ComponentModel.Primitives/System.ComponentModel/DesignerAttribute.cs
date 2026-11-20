namespace System.ComponentModel;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = true, Inherited = true)]
public sealed class DesignerAttribute : Attribute
{
	private string _typeId;

	public string DesignerBaseTypeName { get; }

	public string DesignerTypeName { get; }

	public override object TypeId
	{
		get
		{
			if (_typeId == null)
			{
				string text = DesignerBaseTypeName ?? string.Empty;
				int num = text.IndexOf(',');
				if (num != -1)
				{
					text = text.Substring(0, num);
				}
				_typeId = GetType().FullName + text;
			}
			return _typeId;
		}
	}

	public DesignerAttribute(string designerTypeName)
	{
		ArgumentNullException.ThrowIfNull(designerTypeName, "designerTypeName");
		DesignerTypeName = designerTypeName;
		DesignerBaseTypeName = "System.ComponentModel.Design.IDesigner, System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089";
	}

	public DesignerAttribute(string designerTypeName, string designerBaseTypeName)
	{
		ArgumentNullException.ThrowIfNull(designerTypeName, "designerTypeName");
		DesignerTypeName = designerTypeName;
		DesignerBaseTypeName = designerBaseTypeName;
	}

	public override bool Equals(object? obj)
	{
		if (obj == this)
		{
			return true;
		}
		if (obj is DesignerAttribute designerAttribute && designerAttribute.DesignerBaseTypeName == DesignerBaseTypeName)
		{
			return designerAttribute.DesignerTypeName == DesignerTypeName;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return HashCode.Combine(DesignerBaseTypeName, DesignerTypeName);
	}
}
