using System.Diagnostics.CodeAnalysis;

namespace System.ComponentModel;

[AttributeUsage(AttributeTargets.All)]
public class ToolboxItemAttribute : Attribute
{
	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]
	private readonly string _toolboxItemTypeName;

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]
	public string ToolboxItemTypeName => _toolboxItemTypeName ?? string.Empty;

	public override bool IsDefaultAttribute()
	{
		return _toolboxItemTypeName == "System.Drawing.Design.ToolboxItem, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a";
	}

	public ToolboxItemAttribute(bool defaultType)
	{
		if (defaultType)
		{
			_ = 0;
			throw new NotSupportedException("IDesignerHostNotSupported");
		}
	}

	public ToolboxItemAttribute([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] string toolboxItemTypeName)
	{
		ArgumentNullException.ThrowIfNull(toolboxItemTypeName, "toolboxItemTypeName");
		_toolboxItemTypeName = toolboxItemTypeName;
	}

	public override bool Equals([NotNullWhen(true)] object? obj)
	{
		if (obj == this)
		{
			return true;
		}
		if (obj is ToolboxItemAttribute toolboxItemAttribute)
		{
			return toolboxItemAttribute.ToolboxItemTypeName == ToolboxItemTypeName;
		}
		return false;
	}

	public override int GetHashCode()
	{
		if (_toolboxItemTypeName != null)
		{
			return _toolboxItemTypeName.GetHashCode();
		}
		return base.GetHashCode();
	}
}
