using System.Buffers.Binary;
using System.Globalization;
using System.Runtime.InteropServices;

namespace System.Reflection.Emit;

[StructLayout(LayoutKind.Sequential)]
internal sealed class RuntimeFieldBuilder : FieldBuilder
{
	private FieldAttributes attrs;

	private Type type;

	private string name;

	private object def_value;

	private int offset;

	internal RuntimeTypeBuilder typeb;

	private byte[] rva_data;

	private CustomAttributeBuilder[] cattrs;

	private UnmanagedMarshal marshal_info;

	private RuntimeFieldHandle handle;

	private Type[] modReq;

	private Type[] modOpt;

	public override FieldAttributes Attributes => attrs;

	public override Type DeclaringType
	{
		get
		{
			if (typeb.is_hidden_global_type)
			{
				return null;
			}
			return typeb;
		}
	}

	public override RuntimeFieldHandle FieldHandle
	{
		get
		{
			throw CreateNotSupportedException();
		}
	}

	public override Type FieldType => type;

	public override string Name => name;

	public override Type ReflectedType => typeb;

	public override int MetadataToken => ((RuntimeModuleBuilder)typeb.Module).GetToken(this);

	public override Module Module => base.Module;

	internal RuntimeFieldBuilder(RuntimeTypeBuilder tb, string fieldName, Type type, FieldAttributes attributes, Type[] modReq, Type[] modOpt)
	{
		ArgumentNullException.ThrowIfNull(type, "type");
		attrs = attributes & ~FieldAttributes.ReservedMask;
		name = fieldName;
		this.type = type;
		this.modReq = modReq;
		this.modOpt = modOpt;
		offset = -1;
		typeb = tb;
		((RuntimeModuleBuilder)tb.Module).RegisterToken(this, MetadataToken);
	}

	public override object[] GetCustomAttributes(bool inherit)
	{
		if (typeb.is_created)
		{
			return CustomAttribute.GetCustomAttributes(this, inherit);
		}
		throw CreateNotSupportedException();
	}

	public override object[] GetCustomAttributes(Type attributeType, bool inherit)
	{
		if (typeb.is_created)
		{
			return CustomAttribute.GetCustomAttributes(this, attributeType, inherit);
		}
		throw CreateNotSupportedException();
	}

	public override object GetValue(object obj)
	{
		throw CreateNotSupportedException();
	}

	public override bool IsDefined(Type attributeType, bool inherit)
	{
		throw CreateNotSupportedException();
	}

	internal override int GetFieldOffset()
	{
		return 0;
	}

	internal void SetRVAData(byte[] data)
	{
		attrs |= FieldAttributes.HasFieldRVA;
		rva_data = (byte[])data.Clone();
	}

	internal static PackingSize RVADataPackingSize(int size)
	{
		if (size % 8 == 0)
		{
			return PackingSize.Size8;
		}
		if (size % 4 == 0)
		{
			return PackingSize.Size4;
		}
		if (size % 2 == 0)
		{
			return PackingSize.Size2;
		}
		return PackingSize.Size1;
	}

	protected override void SetConstantCore(object defaultValue)
	{
		RejectIfCreated();
		def_value = defaultValue;
	}

	protected override void SetCustomAttributeCore(ConstructorInfo con, ReadOnlySpan<byte> binaryAttribute)
	{
		RejectIfCreated();
		CustomAttributeBuilder customAttributeBuilder = new CustomAttributeBuilder(con, binaryAttribute);
		switch (con.ReflectedType.FullName)
		{
		case "System.Runtime.InteropServices.FieldOffsetAttribute":
			offset = BinaryPrimitives.ReadInt32LittleEndian(binaryAttribute.Slice(2));
			return;
		case "System.NonSerializedAttribute":
			attrs |= FieldAttributes.NotSerialized;
			return;
		case "System.Runtime.CompilerServices.SpecialNameAttribute":
			attrs |= FieldAttributes.SpecialName;
			return;
		case "System.Runtime.InteropServices.MarshalAsAttribute":
			attrs |= FieldAttributes.HasFieldMarshal;
			marshal_info = CustomAttributeBuilder.get_umarshal(customAttributeBuilder, is_field: true);
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

	protected override void SetOffsetCore(int iOffset)
	{
		RejectIfCreated();
		if (iOffset < 0)
		{
			throw new ArgumentException("Argument_NegativeFieldOffsetNotPermitted");
		}
		offset = iOffset;
	}

	public override void SetValue(object obj, object val, BindingFlags invokeAttr, Binder binder, CultureInfo culture)
	{
		throw CreateNotSupportedException();
	}

	private static NotSupportedException CreateNotSupportedException()
	{
		return new NotSupportedException("NotSupported_DynamicModule");
	}

	private void RejectIfCreated()
	{
		if (typeb.is_created)
		{
			throw new InvalidOperationException("InvalidOperation_TypeHasBeenCreated");
		}
	}

	internal void ResolveUserTypes()
	{
		type = RuntimeTypeBuilder.ResolveUserType(type);
		RuntimeTypeBuilder.ResolveUserTypes(modReq);
		RuntimeTypeBuilder.ResolveUserTypes(modOpt);
		if (marshal_info != null)
		{
			marshal_info.marshaltyperef = RuntimeTypeBuilder.ResolveUserType(marshal_info.marshaltyperef);
		}
	}

	internal FieldInfo RuntimeResolve()
	{
		return FieldInfo.GetFieldFromHandle(declaringType: new RuntimeTypeHandle(typeb.CreateType() as RuntimeType), handle: handle);
	}
}
