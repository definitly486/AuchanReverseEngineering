using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace System.Reflection;

[StructLayout(LayoutKind.Sequential)]
internal sealed class RuntimeFieldInfo : RtFieldInfo
{
	internal nint klass;

	internal RuntimeFieldHandle fhandle;

	private string name;

	private Type type;

	private FieldAttributes attrs;

	public override Module Module => GetRuntimeModule();

	public override bool IsCollectible => false;

	public override FieldAttributes Attributes => attrs;

	public override RuntimeFieldHandle FieldHandle => fhandle;

	public override Type FieldType => type ?? (type = ResolveType());

	public override Type ReflectedType => GetParentType(declaring: false);

	public override Type DeclaringType
	{
		get
		{
			Type parentType = GetParentType(declaring: true);
			if (!(parentType.Name != "<Module>"))
			{
				return null;
			}
			return parentType;
		}
	}

	public override string Name => name;

	public override int MetadataToken => get_metadata_token(this);

	internal RuntimeType GetDeclaringTypeInternal()
	{
		return (RuntimeType)DeclaringType;
	}

	internal RuntimeModule GetRuntimeModule()
	{
		return GetDeclaringTypeInternal().GetRuntimeModule();
	}

	[DebuggerStepThrough]
	[DebuggerHidden]
	public unsafe override void SetValueDirect(TypedReference obj, object value)
	{
		if (obj.IsNull)
		{
			throw new ArgumentException("Arg_TypedReference_Null");
		}
		RuntimeFieldHandle.SetValueDirect(this, (RuntimeType)FieldType, &obj, value, (RuntimeType)DeclaringType);
	}

	[DebuggerStepThrough]
	[DebuggerHidden]
	public unsafe override object GetValueDirect(TypedReference obj)
	{
		if (obj.IsNull)
		{
			throw new ArgumentException("Arg_TypedReference_Null");
		}
		return RuntimeFieldHandle.GetValueDirect(this, (RuntimeType)FieldType, &obj, (RuntimeType)DeclaringType);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private extern Type ResolveType();

	[MethodImpl(MethodImplOptions.InternalCall)]
	private extern Type GetParentType(bool declaring);

	public override bool IsDefined(Type attributeType, bool inherit)
	{
		return CustomAttribute.IsDefined(this, attributeType, inherit);
	}

	public override object[] GetCustomAttributes(bool inherit)
	{
		return CustomAttribute.GetCustomAttributes(this, inherit);
	}

	public override object[] GetCustomAttributes(Type attributeType, bool inherit)
	{
		return CustomAttribute.GetCustomAttributes(this, attributeType, inherit);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal override extern int GetFieldOffset();

	[MethodImpl(MethodImplOptions.InternalCall)]
	private extern object GetValueInternal(object obj);

	public override object GetValue(object obj)
	{
		if (!base.IsStatic)
		{
			if (obj == null)
			{
				throw new TargetException("RFLCT_Targ_StatFldReqTarg");
			}
			if (!DeclaringType.IsAssignableFrom(obj.GetType()))
			{
				throw new ArgumentException(SR.Format("Arg_FieldDeclTarget", Name, DeclaringType, obj.GetType()), "obj");
			}
		}
		if (!base.IsLiteral)
		{
			CheckGeneric();
		}
		return GetValueInternal(obj);
	}

	public override string ToString()
	{
		return FieldType.FormatTypeName() + " " + name;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SetValueInternal(FieldInfo fi, object obj, object value);

	public override void SetValue(object obj, object val, BindingFlags invokeAttr, Binder binder, CultureInfo culture)
	{
		if (!base.IsStatic)
		{
			if (obj == null)
			{
				throw new TargetException("RFLCT_Targ_StatFldReqTarg");
			}
			if (!DeclaringType.IsAssignableFrom(obj.GetType()))
			{
				throw new ArgumentException(SR.Format("Arg_FieldDeclTarget", Name, DeclaringType, obj.GetType()), "obj");
			}
		}
		if (base.IsLiteral)
		{
			throw new FieldAccessException("Acc_ReadOnly");
		}
		if (binder == null)
		{
			binder = Type.DefaultBinder;
		}
		CheckGeneric();
		if (val != null)
		{
			RuntimeType runtimeType = (RuntimeType)FieldType;
			if ((object)val.GetType() != runtimeType)
			{
				runtimeType.CheckValue(ref val, binder, culture, invokeAttr);
			}
		}
		SetValueInternal(this, obj, val);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	public override extern object GetRawConstantValue();

	public override IList<CustomAttributeData> GetCustomAttributesData()
	{
		return RuntimeCustomAttributeData.GetCustomAttributesInternal(this);
	}

	private void CheckGeneric()
	{
		Type declaringType = DeclaringType;
		if (declaringType != null && declaringType.ContainsGenericParameters)
		{
			throw new InvalidOperationException("Arg_UnboundGenField");
		}
	}

	public sealed override bool HasSameMetadataDefinitionAs(MemberInfo other)
	{
		return HasSameMetadataDefinitionAsCore<RuntimeFieldInfo>(other);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern int get_metadata_token(RuntimeFieldInfo monoField);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private extern Type[] GetTypeModifiers(bool optional, int genericArgumentPosition = -1);

	public override Type[] GetOptionalCustomModifiers()
	{
		return GetCustomModifiers(optional: true);
	}

	public override Type[] GetRequiredCustomModifiers()
	{
		return GetCustomModifiers(optional: false);
	}

	private Type[] GetCustomModifiers(bool optional)
	{
		return GetTypeModifiers(optional) ?? Type.EmptyTypes;
	}

	internal Type[] GetCustomModifiersFromModifiedType(bool optional, int genericArgumentPosition)
	{
		return GetTypeModifiers(optional, genericArgumentPosition) ?? Type.EmptyTypes;
	}

	public override Type GetModifiedFieldType()
	{
		return ModifiedType.Create(FieldType, this);
	}
}
