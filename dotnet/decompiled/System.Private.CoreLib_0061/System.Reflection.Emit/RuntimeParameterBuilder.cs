using System.Runtime.InteropServices;

namespace System.Reflection.Emit;

[StructLayout(LayoutKind.Sequential)]
internal sealed class RuntimeParameterBuilder : ParameterBuilder
{
	private MethodBase methodb;

	private string name;

	private CustomAttributeBuilder[] cattrs;

	private UnmanagedMarshal marshal_info;

	private ParameterAttributes attrs;

	private int position;

	private int table_idx;

	private object def_value;

	public override int Attributes => (int)attrs;

	public override string Name => name;

	public override int Position => position;

	internal RuntimeParameterBuilder(MethodBase mb, int pos, ParameterAttributes attributes, string strParamName)
	{
		name = strParamName;
		position = pos;
		attrs = attributes;
		methodb = mb;
		if (mb is DynamicMethod)
		{
			table_idx = 0;
		}
		else
		{
			table_idx = mb.get_next_table_index(8, 1);
		}
	}

	public override void SetConstant(object defaultValue)
	{
		if (position > 0)
		{
			RuntimeTypeBuilder.SetConstantValue(methodb.GetParameterType(position - 1), defaultValue, ref defaultValue);
		}
		def_value = defaultValue;
		attrs |= ParameterAttributes.HasDefault;
	}

	protected override void SetCustomAttributeCore(ConstructorInfo con, ReadOnlySpan<byte> binaryAttribute)
	{
		CustomAttributeBuilder customAttributeBuilder = new CustomAttributeBuilder(con, binaryAttribute);
		switch (con.ReflectedType.FullName)
		{
		case "System.Runtime.InteropServices.InAttribute":
			attrs |= ParameterAttributes.In;
			return;
		case "System.Runtime.InteropServices.OutAttribute":
			attrs |= ParameterAttributes.Out;
			return;
		case "System.Runtime.InteropServices.OptionalAttribute":
			attrs |= ParameterAttributes.Optional;
			return;
		case "System.Runtime.InteropServices.MarshalAsAttribute":
			attrs |= ParameterAttributes.HasFieldMarshal;
			marshal_info = CustomAttributeBuilder.get_umarshal(customAttributeBuilder, is_field: false);
			return;
		case "System.Runtime.InteropServices.DefaultParameterValueAttribute":
			SetConstant(CustomAttributeBuilder.decode_cattr(customAttributeBuilder).ctorArgs[0]);
			return;
		}
		if (cattrs != null)
		{
			CustomAttributeBuilder[] array = new CustomAttributeBuilder[cattrs.Length + 1];
			cattrs.CopyTo(array, 0);
			array[cattrs.Length] = customAttributeBuilder;
			cattrs = array;
		}
		else
		{
			cattrs = new CustomAttributeBuilder[1];
			cattrs[0] = customAttributeBuilder;
		}
	}
}
