using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.InteropServices;

namespace System.Reflection.Emit;

[StructLayout(LayoutKind.Sequential)]
internal sealed class RuntimeGenericTypeParameterBuilder : GenericTypeParameterBuilder
{
	private RuntimeTypeBuilder tbuilder;

	private RuntimeMethodBuilder mbuilder;

	private string name;

	private int index;

	private Type base_type;

	private Type[] iface_constraints;

	private CustomAttributeBuilder[] cattrs;

	private GenericParameterAttributes attrs;

	public override bool IsSZArray => false;

	public override Type UnderlyingSystemType => this;

	public override Assembly Assembly => tbuilder.Assembly;

	public override string AssemblyQualifiedName => null;

	public override Type BaseType => base_type;

	public override string FullName => null;

	public override Guid GUID
	{
		get
		{
			throw not_supported();
		}
	}

	public override string Name => name;

	public override string Namespace => null;

	public override Module Module => tbuilder.Module;

	public override Type DeclaringType
	{
		get
		{
			if (!(mbuilder != null))
			{
				return tbuilder;
			}
			return mbuilder.DeclaringType;
		}
	}

	public override Type ReflectedType => DeclaringType;

	public override RuntimeTypeHandle TypeHandle
	{
		get
		{
			throw not_supported();
		}
	}

	public override bool ContainsGenericParameters => true;

	public override bool IsGenericParameter => true;

	public override bool IsGenericType => false;

	public override bool IsGenericTypeDefinition => false;

	public override GenericParameterAttributes GenericParameterAttributes => attrs;

	public override int GenericParameterPosition => index;

	public override MethodBase DeclaringMethod => mbuilder;

	internal override bool IsUserType => false;

	public override bool IsByRefLike => false;

	internal RuntimeGenericTypeParameterBuilder(RuntimeTypeBuilder tbuilder, RuntimeMethodBuilder mbuilder, string name, int index)
	{
		this.tbuilder = tbuilder;
		this.mbuilder = mbuilder;
		this.name = name;
		this.index = index;
	}

	protected override void SetBaseTypeConstraintCore([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] Type baseTypeConstraint)
	{
		base_type = baseTypeConstraint ?? typeof(object);
	}

	protected override void SetInterfaceConstraintsCore(params Type[] interfaceConstraints)
	{
		iface_constraints = interfaceConstraints;
	}

	protected override void SetGenericParameterAttributesCore(GenericParameterAttributes genericParameterAttributes)
	{
		attrs = genericParameterAttributes;
	}

	internal override Type InternalResolve()
	{
		if (mbuilder != null)
		{
			return MethodBase.GetMethodFromHandle(mbuilder.MethodHandleInternal, mbuilder.TypeBuilder.InternalResolve().TypeHandle).GetGenericArguments()[index];
		}
		return tbuilder.InternalResolve().GetGenericArguments()[index];
	}

	internal override Type RuntimeResolve()
	{
		if (mbuilder != null)
		{
			return MethodBase.GetMethodFromHandle(mbuilder.MethodHandleInternal, mbuilder.TypeBuilder.RuntimeResolve().TypeHandle).GetGenericArguments()[index];
		}
		return tbuilder.RuntimeResolve().GetGenericArguments()[index];
	}

	public override bool IsSubclassOf(Type c)
	{
		throw not_supported();
	}

	protected override TypeAttributes GetAttributeFlagsImpl()
	{
		return TypeAttributes.Public;
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
	protected override ConstructorInfo GetConstructorImpl(BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers)
	{
		throw not_supported();
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
	public override ConstructorInfo[] GetConstructors(BindingFlags bindingAttr)
	{
		throw not_supported();
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicEvents | DynamicallyAccessedMemberTypes.NonPublicEvents)]
	public override EventInfo GetEvent(string name, BindingFlags bindingAttr)
	{
		throw not_supported();
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicEvents)]
	public override EventInfo[] GetEvents()
	{
		throw not_supported();
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicEvents | DynamicallyAccessedMemberTypes.NonPublicEvents)]
	public override EventInfo[] GetEvents(BindingFlags bindingAttr)
	{
		throw not_supported();
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields)]
	public override FieldInfo GetField(string name, BindingFlags bindingAttr)
	{
		throw not_supported();
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields)]
	public override FieldInfo[] GetFields(BindingFlags bindingAttr)
	{
		throw not_supported();
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.Interfaces)]
	[return: DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.Interfaces)]
	public override Type GetInterface(string name, bool ignoreCase)
	{
		throw not_supported();
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.Interfaces)]
	public override Type[] GetInterfaces()
	{
		throw not_supported();
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicNestedTypes | DynamicallyAccessedMemberTypes.NonPublicNestedTypes | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties | DynamicallyAccessedMemberTypes.PublicEvents | DynamicallyAccessedMemberTypes.NonPublicEvents)]
	public override MemberInfo[] GetMembers(BindingFlags bindingAttr)
	{
		throw not_supported();
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicNestedTypes | DynamicallyAccessedMemberTypes.NonPublicNestedTypes | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties | DynamicallyAccessedMemberTypes.PublicEvents | DynamicallyAccessedMemberTypes.NonPublicEvents)]
	public override MemberInfo[] GetMember(string name, MemberTypes type, BindingFlags bindingAttr)
	{
		throw not_supported();
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods)]
	public override MethodInfo[] GetMethods(BindingFlags bindingAttr)
	{
		throw not_supported();
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods)]
	protected override MethodInfo GetMethodImpl(string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers)
	{
		throw not_supported();
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicNestedTypes | DynamicallyAccessedMemberTypes.NonPublicNestedTypes)]
	public override Type GetNestedType(string name, BindingFlags bindingAttr)
	{
		throw not_supported();
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicNestedTypes | DynamicallyAccessedMemberTypes.NonPublicNestedTypes)]
	public override Type[] GetNestedTypes(BindingFlags bindingAttr)
	{
		throw not_supported();
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)]
	public override PropertyInfo[] GetProperties(BindingFlags bindingAttr)
	{
		throw not_supported();
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)]
	protected override PropertyInfo GetPropertyImpl(string name, BindingFlags bindingAttr, Binder binder, Type returnType, Type[] types, ParameterModifier[] modifiers)
	{
		throw not_supported();
	}

	protected override bool HasElementTypeImpl()
	{
		return false;
	}

	public override bool IsAssignableFrom([NotNullWhen(true)] Type c)
	{
		throw not_supported();
	}

	public override bool IsAssignableFrom([NotNullWhen(true)] TypeInfo typeInfo)
	{
		if (typeInfo == null)
		{
			return false;
		}
		return IsAssignableFrom(typeInfo.AsType());
	}

	public override bool IsInstanceOfType(object o)
	{
		throw not_supported();
	}

	protected override bool IsArrayImpl()
	{
		return false;
	}

	protected override bool IsByRefImpl()
	{
		return false;
	}

	protected override bool IsCOMObjectImpl()
	{
		return false;
	}

	protected override bool IsPointerImpl()
	{
		return false;
	}

	protected override bool IsPrimitiveImpl()
	{
		return false;
	}

	protected override bool IsValueTypeImpl()
	{
		if (!(base_type != null))
		{
			return false;
		}
		return base_type.IsValueType;
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)]
	public override object InvokeMember(string name, BindingFlags invokeAttr, Binder binder, object target, object[] args, ParameterModifier[] modifiers, CultureInfo culture, string[] namedParameters)
	{
		throw not_supported();
	}

	public override Type GetElementType()
	{
		throw not_supported();
	}

	public override bool IsDefined(Type attributeType, bool inherit)
	{
		throw not_supported();
	}

	public override object[] GetCustomAttributes(bool inherit)
	{
		throw not_supported();
	}

	public override object[] GetCustomAttributes(Type attributeType, bool inherit)
	{
		throw not_supported();
	}

	public override InterfaceMapping GetInterfaceMap([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods)] Type interfaceType)
	{
		throw not_supported();
	}

	public override Type[] GetGenericArguments()
	{
		throw new InvalidOperationException();
	}

	public override Type GetGenericTypeDefinition()
	{
		throw new InvalidOperationException();
	}

	public override Type[] GetGenericParameterConstraints()
	{
		throw new InvalidOperationException();
	}

	protected override void SetCustomAttributeCore(ConstructorInfo con, ReadOnlySpan<byte> binaryAttribute)
	{
		CustomAttributeBuilder customAttributeBuilder = new CustomAttributeBuilder(con, binaryAttribute);
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

	private static NotSupportedException not_supported()
	{
		return new NotSupportedException();
	}

	public override string ToString()
	{
		return name;
	}

	public override bool Equals(object o)
	{
		return base.Equals(o);
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	[RequiresDynamicCode("The code for an array of the specified type might not be available.")]
	public override Type MakeArrayType()
	{
		return SymbolType.FormCompoundType("[]", this, 0);
	}

	[RequiresDynamicCode("The code for an array of the specified type might not be available.")]
	public override Type MakeArrayType(int rank)
	{
		return SymbolType.FormCompoundType(TypeInfo.GetRankString(rank), this, 0);
	}

	public override Type MakeByRefType()
	{
		return SymbolType.FormCompoundType("&", this, 0);
	}

	[RequiresDynamicCode("The native code for this instantiation might not be available at runtime.")]
	[RequiresUnreferencedCode("If some of the generic arguments are annotated (either with DynamicallyAccessedMembersAttribute, or generic constraints), trimming can't validate that the requirements of those annotations are met.")]
	public override Type MakeGenericType(params Type[] typeArguments)
	{
		throw new InvalidOperationException(SR.Format("Arg_NotGenericTypeDefinition", this));
	}

	public override Type MakePointerType()
	{
		return SymbolType.FormCompoundType("*", this, 0);
	}
}
