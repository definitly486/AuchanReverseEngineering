using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace System.Reflection.Emit;

internal sealed class RuntimeEnumBuilder : EnumBuilder
{
	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)]
	private RuntimeTypeBuilder _tb;

	private FieldBuilder _underlyingField;

	private Type _underlyingType;

	public override Assembly Assembly => _tb.Assembly;

	public override string AssemblyQualifiedName => _tb.AssemblyQualifiedName;

	public override Type BaseType => _tb.BaseType;

	public override Type DeclaringType => _tb.DeclaringType;

	public override string FullName => _tb.FullName;

	public override Guid GUID => _tb.GUID;

	public override Module Module => _tb.Module;

	public override string Name => _tb.Name;

	public override string Namespace => _tb.Namespace;

	public override Type ReflectedType => _tb.ReflectedType;

	public override RuntimeTypeHandle TypeHandle => _tb.TypeHandle;

	protected override FieldBuilder UnderlyingFieldCore => _underlyingField;

	public override Type UnderlyingSystemType => _underlyingType;

	public override bool IsSZArray => false;

	internal override bool IsUserType => false;

	public override bool IsConstructedGenericType => false;

	public override bool IsTypeDefinition => true;

	public override bool IsByRefLike => false;

	[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2064:UnrecognizedReflectionPattern", Justification = "Reflection.Emit is not subject to trimming")]
	internal RuntimeEnumBuilder(RuntimeModuleBuilder mb, string name, TypeAttributes visibility, Type underlyingType)
	{
		if ((visibility & ~TypeAttributes.VisibilityMask) != TypeAttributes.NotPublic)
		{
			throw new ArgumentException("Argument_ShouldOnlySetVisibilityFlags", "name");
		}
		if ((visibility & TypeAttributes.VisibilityMask) >= TypeAttributes.NestedPublic && (visibility & TypeAttributes.VisibilityMask) <= TypeAttributes.VisibilityMask)
		{
			throw new ArgumentException();
		}
		_tb = new RuntimeTypeBuilder(mb, name, visibility | TypeAttributes.Sealed, typeof(Enum), null, PackingSize.Unspecified, 0, null);
		_underlyingType = underlyingType;
		_underlyingField = _tb.DefineField("value__", underlyingType, FieldAttributes.Public | FieldAttributes.SpecialName | FieldAttributes.RTSpecialName);
		setup_enum_type(_tb);
	}

	internal RuntimeTypeBuilder GetTypeBuilder()
	{
		return _tb;
	}

	internal override Type InternalResolve()
	{
		return _tb.InternalResolve();
	}

	internal override Type RuntimeResolve()
	{
		return _tb.RuntimeResolve();
	}

	[return: DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)]
	protected override TypeInfo CreateTypeInfoCore()
	{
		return _tb.CreateTypeInfo();
	}

	public override Type GetEnumUnderlyingType()
	{
		return _underlyingType;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2110:ReflectionToDynamicallyAccessedMembers", Justification = "For instance members with MethodImplOptions.InternalCall, the linker preserves all fields of the declaring type. The _tb field has DynamicallyAccessedMembersAttribute requirements, but the field access is safe because Reflection.Emit is not subject to trimming.")]
	private extern void setup_enum_type(Type t);

	protected override FieldBuilder DefineLiteralCore(string literalName, object literalValue)
	{
		FieldBuilder fieldBuilder = _tb.DefineField(literalName, this, FieldAttributes.Public | FieldAttributes.Static | FieldAttributes.Literal);
		fieldBuilder.SetConstant(literalValue);
		return fieldBuilder;
	}

	protected override TypeAttributes GetAttributeFlagsImpl()
	{
		return _tb.attrs;
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
	protected override ConstructorInfo GetConstructorImpl(BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers)
	{
		return _tb.GetConstructor(bindingAttr, binder, callConvention, types, modifiers);
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
	public override ConstructorInfo[] GetConstructors(BindingFlags bindingAttr)
	{
		return _tb.GetConstructors(bindingAttr);
	}

	public override object[] GetCustomAttributes(bool inherit)
	{
		return _tb.GetCustomAttributes(inherit);
	}

	public override object[] GetCustomAttributes(Type attributeType, bool inherit)
	{
		if (attributeType == null)
		{
			return _tb.GetCustomAttributes(inherit);
		}
		return _tb.GetCustomAttributes(attributeType, inherit);
	}

	public override Type GetElementType()
	{
		return _tb.GetElementType();
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicEvents | DynamicallyAccessedMemberTypes.NonPublicEvents)]
	public override EventInfo GetEvent(string name, BindingFlags bindingAttr)
	{
		return _tb.GetEvent(name, bindingAttr);
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicEvents)]
	public override EventInfo[] GetEvents()
	{
		return _tb.GetEvents();
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicEvents | DynamicallyAccessedMemberTypes.NonPublicEvents)]
	public override EventInfo[] GetEvents(BindingFlags bindingAttr)
	{
		return _tb.GetEvents(bindingAttr);
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields)]
	public override FieldInfo GetField(string name, BindingFlags bindingAttr)
	{
		return _tb.GetField(name, bindingAttr);
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields)]
	public override FieldInfo[] GetFields(BindingFlags bindingAttr)
	{
		return _tb.GetFields(bindingAttr);
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.Interfaces)]
	[return: DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.Interfaces)]
	public override Type GetInterface(string name, bool ignoreCase)
	{
		return _tb.GetInterface(name, ignoreCase);
	}

	public override InterfaceMapping GetInterfaceMap([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods)] Type interfaceType)
	{
		return _tb.GetInterfaceMap(interfaceType);
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.Interfaces)]
	public override Type[] GetInterfaces()
	{
		return _tb.GetInterfaces();
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicNestedTypes | DynamicallyAccessedMemberTypes.NonPublicNestedTypes | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties | DynamicallyAccessedMemberTypes.PublicEvents | DynamicallyAccessedMemberTypes.NonPublicEvents)]
	public override MemberInfo[] GetMember(string name, MemberTypes type, BindingFlags bindingAttr)
	{
		return _tb.GetMember(name, type, bindingAttr);
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicNestedTypes | DynamicallyAccessedMemberTypes.NonPublicNestedTypes | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties | DynamicallyAccessedMemberTypes.PublicEvents | DynamicallyAccessedMemberTypes.NonPublicEvents)]
	public override MemberInfo[] GetMembers(BindingFlags bindingAttr)
	{
		return _tb.GetMembers(bindingAttr);
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods)]
	protected override MethodInfo GetMethodImpl(string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers)
	{
		if (types == null)
		{
			return _tb.GetMethod(name, bindingAttr);
		}
		return _tb.GetMethod(name, bindingAttr, binder, callConvention, types, modifiers);
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods)]
	public override MethodInfo[] GetMethods(BindingFlags bindingAttr)
	{
		return _tb.GetMethods(bindingAttr);
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicNestedTypes | DynamicallyAccessedMemberTypes.NonPublicNestedTypes)]
	public override Type GetNestedType(string name, BindingFlags bindingAttr)
	{
		return _tb.GetNestedType(name, bindingAttr);
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicNestedTypes | DynamicallyAccessedMemberTypes.NonPublicNestedTypes)]
	public override Type[] GetNestedTypes(BindingFlags bindingAttr)
	{
		return _tb.GetNestedTypes(bindingAttr);
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)]
	public override PropertyInfo[] GetProperties(BindingFlags bindingAttr)
	{
		return _tb.GetProperties(bindingAttr);
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)]
	protected override PropertyInfo GetPropertyImpl(string name, BindingFlags bindingAttr, Binder binder, Type returnType, Type[] types, ParameterModifier[] modifiers)
	{
		throw new NotSupportedException("NotSupported_DynamicModule");
	}

	protected override bool HasElementTypeImpl()
	{
		return _tb.HasElementType;
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)]
	public override object InvokeMember(string name, BindingFlags invokeAttr, Binder binder, object target, object[] args, ParameterModifier[] modifiers, CultureInfo culture, string[] namedParameters)
	{
		return _tb.InvokeMember(name, invokeAttr, binder, target, args, modifiers, culture, namedParameters);
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
		return true;
	}

	public override bool IsDefined(Type attributeType, bool inherit)
	{
		return _tb.IsDefined(attributeType, inherit);
	}

	protected override void SetCustomAttributeCore(ConstructorInfo con, ReadOnlySpan<byte> binaryAttribute)
	{
		_tb.SetCustomAttribute(con, binaryAttribute);
	}

	public override bool IsAssignableFrom([NotNullWhen(true)] TypeInfo typeInfo)
	{
		if (typeInfo == null)
		{
			return false;
		}
		return IsAssignableFrom(typeInfo.AsType());
	}
}
