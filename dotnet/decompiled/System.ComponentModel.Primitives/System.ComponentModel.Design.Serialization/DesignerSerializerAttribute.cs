using System.Runtime.CompilerServices;

namespace System.ComponentModel.Design.Serialization;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = true, Inherited = true)]
public sealed class DesignerSerializerAttribute : Attribute
{
	private string _typeId;

	[CompilerGenerated]
	private readonly string _003CSerializerTypeName_003Ek__BackingField;

	public string? SerializerBaseTypeName { get; }

	public override object TypeId
	{
		get
		{
			if (_typeId == null)
			{
				string text = SerializerBaseTypeName ?? string.Empty;
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

	public DesignerSerializerAttribute(string? serializerTypeName, string? baseSerializerTypeName)
	{
		_003CSerializerTypeName_003Ek__BackingField = serializerTypeName;
		SerializerBaseTypeName = baseSerializerTypeName;
	}
}
