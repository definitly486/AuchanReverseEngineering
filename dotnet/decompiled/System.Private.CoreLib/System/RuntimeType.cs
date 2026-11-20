using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Reflection;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Mono;

namespace System;

internal sealed class RuntimeType : TypeInfo, ICloneable
{
	internal enum MemberListType
	{
		All,
		CaseSensitive,
		CaseInsensitive,
		HandleToInfo
	}

	private struct ListBuilder<T> where T : class
	{
		private T[] _items;

		private T _item;

		private int _count;

		private int _capacity;

		public T this[int index]
		{
			get
			{
				if (_items == null)
				{
					return _item;
				}
				return _items[index];
			}
		}

		public int Count => _count;

		public ListBuilder(int capacity)
		{
			_items = null;
			_item = null;
			_count = 0;
			_capacity = capacity;
		}

		public T[] ToArray()
		{
			if (_count == 0)
			{
				return Array.Empty<T>();
			}
			if (_count == 1)
			{
				return new T[1] { _item };
			}
			Array.Resize(ref _items, _count);
			_capacity = _count;
			return _items;
		}

		public void CopyTo(object[] array, int index)
		{
			if (_count != 0)
			{
				if (_count == 1)
				{
					array[index] = _item;
				}
				else
				{
					Array.Copy(_items, 0, array, index, _count);
				}
			}
		}

		public void Add(T item)
		{
			if (_count == 0)
			{
				_item = item;
			}
			else
			{
				if (_count == 1)
				{
					if (_capacity < 2)
					{
						_capacity = 4;
					}
					_items = new T[_capacity];
					_items[0] = _item;
				}
				else if (_capacity == _count)
				{
					int num = 2 * _capacity;
					Array.Resize(ref _items, num);
					_capacity = num;
				}
				_items[_count] = item;
			}
			_count++;
		}
	}

	[Flags]
	private enum TypeCacheEntries
	{
		IsGenericTypeDef = 1,
		IsDelegate = 2,
		IsValueType = 4,
		IsActualEnum = 8,
		IsGenericType = 0x10,
		CorElementType = 0x20,
		TypeAttributes = 0x40,
		DefaultCtor = 0x80
	}

	internal sealed class TypeCache
	{
		public object EnumInfo;

		public TypeCode TypeCode;

		public string full_name;

		public RuntimeConstructorInfo default_ctor;

		public CorElementType CorElementType;

		public TypeAttributes TypeAttributes;

		public int Flags;

		public int Cached;
	}

	private enum CheckValueStatus
	{
		Success,
		ArgumentException,
		NotSupported_ByRefLike
	}

	internal static readonly RuntimeType ValueType = (RuntimeType)typeof(ValueType);

	internal static readonly RuntimeType EnumType = (RuntimeType)typeof(Enum);

	private static readonly RuntimeType ObjectType = (RuntimeType)typeof(object);

	private static readonly RuntimeType StringType = (RuntimeType)typeof(string);

	private TypeCache cache;

	internal bool IsActualInterface => base.IsInterface;

	internal bool IsActualValueType => RuntimeTypeHandle.IsValueType(this);

	public override bool IsEnum => GetBaseType() == EnumType;

	public override bool IsCollectible => false;

	internal bool IsActualEnum
	{
		get
		{
			TypeCache typeCache = Cache;
			if ((typeCache.Cached & 8) != 0)
			{
				return (typeCache.Flags & 8) != 0;
			}
			bool flag = !IsGenericParameter && GetParentType() == EnumType;
			CacheFlag(TypeCacheEntries.IsActualEnum, flag);
			return flag;
		}
	}

	public override bool IsByRefLike => RuntimeTypeHandle.IsByRefLike(this);

	public override bool IsConstructedGenericType
	{
		get
		{
			if (IsGenericType)
			{
				return !IsGenericTypeDefinition;
			}
			return false;
		}
	}

	public override bool IsGenericType
	{
		get
		{
			TypeCache typeCache = Cache;
			if ((typeCache.Cached & 0x10) != 0)
			{
				return (typeCache.Flags & 0x10) != 0;
			}
			bool flag = RuntimeTypeHandle.HasInstantiation(this);
			CacheFlag(TypeCacheEntries.IsGenericType, flag);
			return flag;
		}
	}

	public override bool IsGenericTypeDefinition
	{
		get
		{
			TypeCache typeCache = Cache;
			if ((typeCache.Cached & 1) != 0)
			{
				return (typeCache.Flags & 1) != 0;
			}
			bool flag = RuntimeTypeHandle.IsGenericTypeDefinition(this);
			CacheFlag(TypeCacheEntries.IsGenericTypeDef, flag);
			return flag;
		}
	}

	public override GenericParameterAttributes GenericParameterAttributes
	{
		get
		{
			if (!IsGenericParameter)
			{
				throw new InvalidOperationException("Arg_NotGenericParameter");
			}
			return GetGenericParameterAttributes();
		}
	}

	public override int GenericParameterPosition
	{
		get
		{
			if (!IsGenericParameter)
			{
				throw new InvalidOperationException("Arg_NotGenericParameter");
			}
			RuntimeType type = this;
			return GetGenericParameterPosition(new QCallTypeHandle(ref type));
		}
	}

	internal TypeCache Cache => Volatile.Read(in cache) ?? Interlocked.CompareExchange(ref cache, new TypeCache(), null) ?? cache;

	public override StructLayoutAttribute StructLayoutAttribute => GetStructLayoutAttribute();

	public override bool ContainsGenericParameters
	{
		get
		{
			if (IsGenericParameter)
			{
				return true;
			}
			if (IsGenericType)
			{
				Type[] genericArguments = GetGenericArguments();
				for (int i = 0; i < genericArguments.Length; i++)
				{
					if (genericArguments[i].ContainsGenericParameters)
					{
						return true;
					}
				}
			}
			if (base.HasElementType)
			{
				return GetElementType().ContainsGenericParameters;
			}
			if (IsFunctionPointer)
			{
				if (GetFunctionPointerReturnType().ContainsGenericParameters)
				{
					return true;
				}
				Type[] genericArguments = GetFunctionPointerParameterTypes();
				for (int i = 0; i < genericArguments.Length; i++)
				{
					if (genericArguments[i].ContainsGenericParameters)
					{
						return true;
					}
				}
			}
			return false;
		}
	}

	public override Guid GUID
	{
		get
		{
			object[] customAttributes = GetCustomAttributes(typeof(GuidAttribute), inherit: true);
			if (customAttributes.Length == 0)
			{
				return Guid.Empty;
			}
			return new Guid(((GuidAttribute)customAttributes[0]).Value);
		}
	}

	public override MethodBase DeclaringMethod
	{
		get
		{
			RuntimeType type = this;
			MethodBase o = null;
			GetDeclaringMethod(new QCallTypeHandle(ref type), ObjectHandleOnStack.Create(ref o));
			return o;
		}
	}

	public override string AssemblyQualifiedName => getFullName(full_name: true, assembly_qualified: true);

	public override Type DeclaringType
	{
		get
		{
			RuntimeType type = this;
			Type o = null;
			GetDeclaringType(new QCallTypeHandle(ref type), ObjectHandleOnStack.Create(ref o));
			return o;
		}
	}

	public override string Name
	{
		get
		{
			RuntimeType type = this;
			string o = null;
			GetName(new QCallTypeHandle(ref type), ObjectHandleOnStack.Create(ref o));
			return o;
		}
	}

	public override string Namespace
	{
		get
		{
			Type rootElementType = GetRootElementType();
			if (rootElementType.IsFunctionPointer)
			{
				return null;
			}
			RuntimeType type = (RuntimeType)rootElementType;
			string o = null;
			GetNamespace(new QCallTypeHandle(ref type), ObjectHandleOnStack.Create(ref o));
			return o;
		}
	}

	public override string FullName
	{
		get
		{
			TypeCache typeCache = Cache;
			string result;
			if ((result = typeCache.full_name) == null)
			{
				result = (typeCache.full_name = getFullName(full_name: true, assembly_qualified: false));
			}
			return result;
		}
	}

	internal bool IsNullableOfT => Nullable.GetUnderlyingType(this) != null;

	public override bool IsSZArray => RuntimeTypeHandle.IsSzArray(this);

	public override bool IsFunctionPointer => RuntimeTypeHandle.IsFunctionPointer(this);

	public override bool IsUnmanagedFunctionPointer => IsUnmanagedFunctionPointerInternal(this);

	internal override bool IsUserType => false;

	public override Assembly Assembly => RuntimeTypeHandle.GetAssembly(this);

	public override Type BaseType => GetBaseType();

	public override bool IsGenericParameter => RuntimeTypeHandle.IsGenericVariable(this);

	public override bool IsTypeDefinition => RuntimeTypeHandle.IsTypeDefinition(this);

	public override bool IsSecurityCritical => true;

	public override bool IsSecuritySafeCritical => false;

	public override bool IsSecurityTransparent => false;

	public override MemberTypes MemberType
	{
		get
		{
			if (!base.IsPublic && !base.IsNotPublic)
			{
				return MemberTypes.NestedType;
			}
			return MemberTypes.TypeInfo;
		}
	}

	public override int MetadataToken => RuntimeTypeHandle.GetToken(this);

	public override Module Module => GetRuntimeModule();

	public override Type ReflectedType => DeclaringType;

	public override RuntimeTypeHandle TypeHandle
	{
		[Intrinsic]
		get
		{
			return new RuntimeTypeHandle(this);
		}
	}

	public override Type UnderlyingSystemType => this;

	internal RuntimeType GetParentType()
	{
		RuntimeType type = this;
		RuntimeType o = null;
		GetParentType(new QCallTypeHandle(ref type), ObjectHandleOnStack.Create(ref o));
		return o;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetParentType(QCallTypeHandle type, ObjectHandleOnStack res);

	[RequiresUnreferencedCode("Types might be removed")]
	internal static RuntimeType GetType(string typeName, bool throwOnError, bool ignoreCase, ref StackCrawlMark stackMark)
	{
		ArgumentNullException.ThrowIfNull(typeName, "typeName");
		return RuntimeTypeHandle.GetTypeByName(typeName, throwOnError, ignoreCase, ref stackMark);
	}

	private static void SplitName(string fullname, out string name, out string ns)
	{
		name = null;
		ns = null;
		if (fullname != null)
		{
			int num = TypeNameParserHelpers.IndexOfNamespaceDelimiter(fullname.AsSpan());
			if (num > 0)
			{
				ns = fullname.Substring(0, num);
				name = fullname.Substring(num + 1);
			}
			else
			{
				name = fullname;
			}
		}
	}

	internal static BindingFlags FilterPreCalculate(bool isPublic, bool isInherited, bool isStatic)
	{
		BindingFlags bindingFlags = (isPublic ? BindingFlags.Public : BindingFlags.NonPublic);
		if (isInherited)
		{
			bindingFlags |= BindingFlags.DeclaredOnly;
			if (isStatic)
			{
				return bindingFlags | (BindingFlags.Static | BindingFlags.FlattenHierarchy);
			}
			return bindingFlags | BindingFlags.Instance;
		}
		if (isStatic)
		{
			return bindingFlags | BindingFlags.Static;
		}
		return bindingFlags | BindingFlags.Instance;
	}

	private static void FilterHelper(BindingFlags bindingFlags, ref string name, bool allowPrefixLookup, out bool prefixLookup, out bool ignoreCase, out MemberListType listType)
	{
		prefixLookup = false;
		ignoreCase = false;
		if (name != null)
		{
			if ((bindingFlags & BindingFlags.IgnoreCase) != BindingFlags.Default)
			{
				name = name.ToLowerInvariant();
				ignoreCase = true;
				listType = MemberListType.CaseInsensitive;
			}
			else
			{
				listType = MemberListType.CaseSensitive;
			}
			if (allowPrefixLookup && name.EndsWith('*'))
			{
				name = name.Substring(0, name.Length - 1);
				prefixLookup = true;
				listType = MemberListType.All;
			}
		}
		else
		{
			listType = MemberListType.All;
		}
	}

	private static void FilterHelper(BindingFlags bindingFlags, ref string name, out bool ignoreCase, out MemberListType listType)
	{
		FilterHelper(bindingFlags, ref name, allowPrefixLookup: false, out var _, out ignoreCase, out listType);
	}

	private static bool FilterApplyPrefixLookup(MemberInfo memberInfo, string name, bool ignoreCase)
	{
		if (ignoreCase)
		{
			if (!memberInfo.Name.StartsWith(name, StringComparison.OrdinalIgnoreCase))
			{
				return false;
			}
		}
		else if (!memberInfo.Name.StartsWith(name, StringComparison.Ordinal))
		{
			return false;
		}
		return true;
	}

	private static bool FilterApplyBase(MemberInfo memberInfo, BindingFlags bindingFlags, bool isPublic, bool isNonProtectedInternal, bool isStatic, string name, bool prefixLookup)
	{
		if (isPublic)
		{
			if ((bindingFlags & BindingFlags.Public) == 0)
			{
				return false;
			}
		}
		else if ((bindingFlags & BindingFlags.NonPublic) == 0)
		{
			return false;
		}
		bool flag = (object)memberInfo.DeclaringType != memberInfo.ReflectedType;
		if ((bindingFlags & BindingFlags.DeclaredOnly) != 0 && flag)
		{
			return false;
		}
		if (memberInfo.MemberType != MemberTypes.TypeInfo && memberInfo.MemberType != MemberTypes.NestedType)
		{
			if (isStatic)
			{
				if ((bindingFlags & BindingFlags.FlattenHierarchy) == 0 && flag)
				{
					return false;
				}
				if ((bindingFlags & BindingFlags.Static) == 0)
				{
					return false;
				}
			}
			else if ((bindingFlags & BindingFlags.Instance) == 0)
			{
				return false;
			}
		}
		if (prefixLookup && !FilterApplyPrefixLookup(memberInfo, name, (bindingFlags & BindingFlags.IgnoreCase) != 0))
		{
			return false;
		}
		if ((bindingFlags & BindingFlags.DeclaredOnly) == 0 && flag && isNonProtectedInternal && (bindingFlags & BindingFlags.NonPublic) != BindingFlags.Default && !isStatic && (bindingFlags & BindingFlags.Instance) != BindingFlags.Default)
		{
			MethodInfo methodInfo = memberInfo as MethodInfo;
			if (methodInfo == null)
			{
				return false;
			}
			if (!methodInfo.IsVirtual && !methodInfo.IsAbstract)
			{
				return false;
			}
		}
		return true;
	}

	private static bool FilterApplyType(Type type, BindingFlags bindingFlags, string name, bool prefixLookup, string ns)
	{
		bool isPublic = type.IsNestedPublic || type.IsPublic;
		bool isStatic = false;
		if (!FilterApplyBase(type, bindingFlags, isPublic, type.IsNestedAssembly, isStatic, name, prefixLookup))
		{
			return false;
		}
		if (ns != null && ns != type.Namespace)
		{
			return false;
		}
		return true;
	}

	private static bool FilterApplyMethodInfo(RuntimeMethodInfo method, BindingFlags bindingFlags, CallingConventions callConv, Type[] argumentTypes)
	{
		return FilterApplyMethodBase(method, bindingFlags, callConv, argumentTypes);
	}

	private static bool FilterApplyConstructorInfo(RuntimeConstructorInfo constructor, BindingFlags bindingFlags, CallingConventions callConv, Type[] argumentTypes)
	{
		return FilterApplyMethodBase(constructor, bindingFlags, callConv, argumentTypes);
	}

	private static bool FilterApplyMethodBase(MethodBase methodBase, BindingFlags bindingFlags, CallingConventions callConv, Type[] argumentTypes)
	{
		bindingFlags ^= BindingFlags.DeclaredOnly;
		if ((callConv & CallingConventions.Any) == 0)
		{
			if ((callConv & CallingConventions.VarArgs) != 0 && (methodBase.CallingConvention & CallingConventions.VarArgs) == 0)
			{
				return false;
			}
			if ((callConv & CallingConventions.Standard) != 0 && (methodBase.CallingConvention & CallingConventions.Standard) == 0)
			{
				return false;
			}
		}
		if (argumentTypes != null)
		{
			ReadOnlySpan<ParameterInfo> parametersAsSpan = methodBase.GetParametersAsSpan();
			if (argumentTypes.Length != parametersAsSpan.Length)
			{
				if ((bindingFlags & (BindingFlags.InvokeMethod | BindingFlags.CreateInstance | BindingFlags.GetProperty | BindingFlags.SetProperty)) == 0)
				{
					return false;
				}
				bool flag = false;
				if (argumentTypes.Length > parametersAsSpan.Length)
				{
					if ((methodBase.CallingConvention & CallingConventions.VarArgs) == 0)
					{
						flag = true;
					}
				}
				else if ((bindingFlags & BindingFlags.OptionalParamBinding) == 0)
				{
					flag = true;
				}
				else if (!parametersAsSpan[argumentTypes.Length].IsOptional)
				{
					flag = true;
				}
				if (flag)
				{
					if (parametersAsSpan.Length == 0)
					{
						return false;
					}
					if (argumentTypes.Length < parametersAsSpan.Length - 1)
					{
						return false;
					}
					ParameterInfo parameterInfo = parametersAsSpan[parametersAsSpan.Length - 1];
					if (!parameterInfo.ParameterType.IsArray)
					{
						return false;
					}
					if (!parameterInfo.IsDefined(typeof(ParamArrayAttribute), inherit: false))
					{
						return false;
					}
				}
			}
			else if ((bindingFlags & BindingFlags.ExactBinding) != BindingFlags.Default && (bindingFlags & BindingFlags.InvokeMethod) == 0)
			{
				for (int i = 0; i < parametersAsSpan.Length; i++)
				{
					if ((object)argumentTypes[i] != null && !argumentTypes[i].MatchesParameterTypeExactly(parametersAsSpan[i]))
					{
						return false;
					}
				}
			}
		}
		return true;
	}

	internal RuntimeType()
	{
		throw new NotSupportedException();
	}

	private ListBuilder<MethodInfo> GetMethodCandidates(string name, BindingFlags bindingAttr, CallingConventions callConv, Type[] types, int genericParamCount, bool allowPrefixLookup)
	{
		FilterHelper(bindingAttr, ref name, allowPrefixLookup, out var prefixLookup, out var ignoreCase, out var listType);
		RuntimeMethodInfo[] methodsByName = GetMethodsByName(name, bindingAttr, listType, this);
		ListBuilder<MethodInfo> result = new ListBuilder<MethodInfo>(methodsByName.Length);
		foreach (RuntimeMethodInfo runtimeMethodInfo in methodsByName)
		{
			if (genericParamCount != -1)
			{
				bool isGenericMethod = runtimeMethodInfo.IsGenericMethod;
				if ((genericParamCount == 0 && isGenericMethod) || (genericParamCount > 0 && !isGenericMethod) || runtimeMethodInfo.GetGenericArguments().Length != genericParamCount)
				{
					continue;
				}
			}
			if (FilterApplyMethodInfo(runtimeMethodInfo, bindingAttr, callConv, types) && (!prefixLookup || FilterApplyPrefixLookup(runtimeMethodInfo, name, ignoreCase)))
			{
				result.Add(runtimeMethodInfo);
			}
		}
		return result;
	}

	private ListBuilder<ConstructorInfo> GetConstructorCandidates(string name, BindingFlags bindingAttr, CallingConventions callConv, Type[] types, bool allowPrefixLookup)
	{
		FilterHelper(bindingAttr, ref name, allowPrefixLookup, out var prefixLookup, out var ignoreCase, out var _);
		if (!string.IsNullOrEmpty(name) && name != ConstructorInfo.ConstructorName && name != ConstructorInfo.TypeConstructorName)
		{
			return new ListBuilder<ConstructorInfo>(0);
		}
		RuntimeConstructorInfo[] constructors_internal = GetConstructors_internal(bindingAttr, this);
		ListBuilder<ConstructorInfo> result = new ListBuilder<ConstructorInfo>(constructors_internal.Length);
		foreach (RuntimeConstructorInfo runtimeConstructorInfo in constructors_internal)
		{
			if (FilterApplyConstructorInfo(runtimeConstructorInfo, bindingAttr, callConv, types) && (!prefixLookup || FilterApplyPrefixLookup(runtimeConstructorInfo, name, ignoreCase)))
			{
				result.Add(runtimeConstructorInfo);
			}
		}
		return result;
	}

	private ListBuilder<PropertyInfo> GetPropertyCandidates(string name, BindingFlags bindingAttr, Type[] types, bool allowPrefixLookup)
	{
		FilterHelper(bindingAttr, ref name, allowPrefixLookup, out var prefixLookup, out var ignoreCase, out var listType);
		RuntimePropertyInfo[] propertiesByName = GetPropertiesByName(name, bindingAttr, listType, this);
		bindingAttr ^= BindingFlags.DeclaredOnly;
		ListBuilder<PropertyInfo> result = new ListBuilder<PropertyInfo>(propertiesByName.Length);
		foreach (RuntimePropertyInfo runtimePropertyInfo in propertiesByName)
		{
			if ((bindingAttr & runtimePropertyInfo.BindingFlags) == runtimePropertyInfo.BindingFlags && (!prefixLookup || FilterApplyPrefixLookup(runtimePropertyInfo, name, ignoreCase)) && (types == null || runtimePropertyInfo.GetIndexParameters().Length == types.Length))
			{
				result.Add(runtimePropertyInfo);
			}
		}
		return result;
	}

	private ListBuilder<EventInfo> GetEventCandidates(string name, BindingFlags bindingAttr, bool allowPrefixLookup)
	{
		FilterHelper(bindingAttr, ref name, allowPrefixLookup, out var prefixLookup, out var ignoreCase, out var listType);
		RuntimeEventInfo[] events_internal = GetEvents_internal(name, listType, this);
		bindingAttr ^= BindingFlags.DeclaredOnly;
		ListBuilder<EventInfo> result = new ListBuilder<EventInfo>(events_internal.Length);
		foreach (RuntimeEventInfo runtimeEventInfo in events_internal)
		{
			if ((bindingAttr & runtimeEventInfo.BindingFlags) == runtimeEventInfo.BindingFlags && (!prefixLookup || FilterApplyPrefixLookup(runtimeEventInfo, name, ignoreCase)))
			{
				result.Add(runtimeEventInfo);
			}
		}
		return result;
	}

	private ListBuilder<FieldInfo> GetFieldCandidates(string name, BindingFlags bindingAttr, bool allowPrefixLookup)
	{
		FilterHelper(bindingAttr, ref name, allowPrefixLookup, out var prefixLookup, out var ignoreCase, out var listType);
		RuntimeFieldInfo[] fields_internal = GetFields_internal(name, bindingAttr, listType, this);
		ListBuilder<FieldInfo> result = new ListBuilder<FieldInfo>(fields_internal.Length);
		foreach (RuntimeFieldInfo runtimeFieldInfo in fields_internal)
		{
			if (!prefixLookup || FilterApplyPrefixLookup(runtimeFieldInfo, name, ignoreCase))
			{
				result.Add(runtimeFieldInfo);
			}
		}
		return result;
	}

	private ListBuilder<Type> GetNestedTypeCandidates(string fullname, BindingFlags bindingAttr, bool allowPrefixLookup)
	{
		bindingAttr &= ~BindingFlags.Static;
		SplitName(fullname, out var name, out var ns);
		FilterHelper(bindingAttr, ref name, allowPrefixLookup, out var prefixLookup, out var _, out var listType);
		RuntimeType[] nestedTypes_internal = GetNestedTypes_internal(name, bindingAttr, listType);
		ListBuilder<Type> result = new ListBuilder<Type>(nestedTypes_internal.Length);
		foreach (RuntimeType runtimeType in nestedTypes_internal)
		{
			if (FilterApplyType(runtimeType, bindingAttr, name, prefixLookup, ns))
			{
				result.Add(runtimeType);
			}
		}
		return result;
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods)]
	public override MethodInfo[] GetMethods(BindingFlags bindingAttr)
	{
		return GetMethodCandidates(null, bindingAttr, CallingConventions.Any, null, -1, allowPrefixLookup: false).ToArray();
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
	public override ConstructorInfo[] GetConstructors(BindingFlags bindingAttr)
	{
		return GetConstructorCandidates(null, bindingAttr, CallingConventions.Any, null, allowPrefixLookup: false).ToArray();
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)]
	public override PropertyInfo[] GetProperties(BindingFlags bindingAttr)
	{
		return GetPropertyCandidates(null, bindingAttr, null, allowPrefixLookup: false).ToArray();
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicEvents | DynamicallyAccessedMemberTypes.NonPublicEvents)]
	public override EventInfo[] GetEvents(BindingFlags bindingAttr)
	{
		return GetEventCandidates(null, bindingAttr, allowPrefixLookup: false).ToArray();
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields)]
	public override FieldInfo[] GetFields(BindingFlags bindingAttr)
	{
		return GetFieldCandidates(null, bindingAttr, allowPrefixLookup: false).ToArray();
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicNestedTypes | DynamicallyAccessedMemberTypes.NonPublicNestedTypes)]
	public override Type[] GetNestedTypes(BindingFlags bindingAttr)
	{
		return GetNestedTypeCandidates(null, bindingAttr, allowPrefixLookup: false).ToArray();
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicNestedTypes | DynamicallyAccessedMemberTypes.NonPublicNestedTypes | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties | DynamicallyAccessedMemberTypes.PublicEvents | DynamicallyAccessedMemberTypes.NonPublicEvents)]
	public override MemberInfo[] GetMembers(BindingFlags bindingAttr)
	{
		ListBuilder<MethodInfo> methodCandidates = GetMethodCandidates(null, bindingAttr, CallingConventions.Any, null, -1, allowPrefixLookup: false);
		ListBuilder<ConstructorInfo> constructorCandidates = GetConstructorCandidates(null, bindingAttr, CallingConventions.Any, null, allowPrefixLookup: false);
		ListBuilder<PropertyInfo> propertyCandidates = GetPropertyCandidates(null, bindingAttr, null, allowPrefixLookup: false);
		ListBuilder<EventInfo> eventCandidates = GetEventCandidates(null, bindingAttr, allowPrefixLookup: false);
		ListBuilder<FieldInfo> fieldCandidates = GetFieldCandidates(null, bindingAttr, allowPrefixLookup: false);
		ListBuilder<Type> nestedTypeCandidates = GetNestedTypeCandidates(null, bindingAttr, allowPrefixLookup: false);
		MemberInfo[] array = new MemberInfo[methodCandidates.Count + constructorCandidates.Count + propertyCandidates.Count + eventCandidates.Count + fieldCandidates.Count + nestedTypeCandidates.Count];
		int num = 0;
		object[] array2 = array;
		methodCandidates.CopyTo(array2, num);
		num += methodCandidates.Count;
		array2 = array;
		constructorCandidates.CopyTo(array2, num);
		num += constructorCandidates.Count;
		array2 = array;
		propertyCandidates.CopyTo(array2, num);
		num += propertyCandidates.Count;
		array2 = array;
		eventCandidates.CopyTo(array2, num);
		num += eventCandidates.Count;
		array2 = array;
		fieldCandidates.CopyTo(array2, num);
		num += fieldCandidates.Count;
		array2 = array;
		nestedTypeCandidates.CopyTo(array2, num);
		num += nestedTypeCandidates.Count;
		return array;
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods)]
	protected override MethodInfo GetMethodImpl(string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers)
	{
		return GetMethodImpl(name, -1, bindingAttr, binder, callConvention, types, modifiers);
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods)]
	protected override MethodInfo GetMethodImpl(string name, int genericParamCount, BindingFlags bindingAttr, Binder binder, CallingConventions callConv, Type[] types, ParameterModifier[] modifiers)
	{
		ListBuilder<MethodInfo> methodCandidates = GetMethodCandidates(name, bindingAttr, callConv, types, genericParamCount, allowPrefixLookup: false);
		if (methodCandidates.Count == 0)
		{
			return null;
		}
		MethodBase[] match;
		if (types == null || types.Length == 0)
		{
			MethodInfo methodInfo = methodCandidates[0];
			if (methodCandidates.Count == 1)
			{
				return methodInfo;
			}
			if (types == null)
			{
				for (int i = 1; i < methodCandidates.Count; i++)
				{
					if (!System.DefaultBinder.CompareMethodSig(methodCandidates[i], methodInfo))
					{
						throw ThrowHelper.GetAmbiguousMatchException(methodInfo);
					}
				}
				match = methodCandidates.ToArray();
				return System.DefaultBinder.FindMostDerivedNewSlotMeth(match, methodCandidates.Count) as MethodInfo;
			}
		}
		if (binder == null)
		{
			binder = Type.DefaultBinder;
		}
		Binder binder2 = binder;
		match = methodCandidates.ToArray();
		return binder2.SelectMethod(bindingAttr, match, types, modifiers) as MethodInfo;
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
	protected override ConstructorInfo GetConstructorImpl(BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers)
	{
		ListBuilder<ConstructorInfo> constructorCandidates = GetConstructorCandidates(null, bindingAttr, CallingConventions.Any, types, allowPrefixLookup: false);
		if (constructorCandidates.Count == 0)
		{
			return null;
		}
		if (types.Length == 0 && constructorCandidates.Count == 1)
		{
			ConstructorInfo constructorInfo = constructorCandidates[0];
			if (constructorInfo.GetParametersAsSpan().Length == 0)
			{
				return constructorInfo;
			}
		}
		MethodBase[] match;
		if ((bindingAttr & BindingFlags.ExactBinding) != BindingFlags.Default)
		{
			match = constructorCandidates.ToArray();
			return System.DefaultBinder.ExactBinding(match, types) as ConstructorInfo;
		}
		if (binder == null)
		{
			binder = Type.DefaultBinder;
		}
		Binder binder2 = binder;
		match = constructorCandidates.ToArray();
		return binder2.SelectMethod(bindingAttr, match, types, modifiers) as ConstructorInfo;
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)]
	protected override PropertyInfo GetPropertyImpl(string name, BindingFlags bindingAttr, Binder binder, Type returnType, Type[] types, ParameterModifier[] modifiers)
	{
		ArgumentNullException.ThrowIfNull(name, "name");
		ListBuilder<PropertyInfo> propertyCandidates = GetPropertyCandidates(name, bindingAttr, types, allowPrefixLookup: false);
		if (propertyCandidates.Count == 0)
		{
			return null;
		}
		if (types == null || types.Length == 0)
		{
			PropertyInfo propertyInfo = propertyCandidates[0];
			if (propertyCandidates.Count == 1)
			{
				if ((object)returnType != null && !returnType.IsEquivalentTo(propertyInfo.PropertyType))
				{
					return null;
				}
				return propertyInfo;
			}
			if ((object)returnType == null)
			{
				throw ThrowHelper.GetAmbiguousMatchException(propertyInfo);
			}
		}
		if ((bindingAttr & BindingFlags.ExactBinding) != BindingFlags.Default)
		{
			return System.DefaultBinder.ExactPropertyBinding(propertyCandidates.ToArray(), returnType, types);
		}
		if (binder == null)
		{
			binder = Type.DefaultBinder;
		}
		return binder.SelectProperty(bindingAttr, propertyCandidates.ToArray(), returnType, types, modifiers);
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicEvents | DynamicallyAccessedMemberTypes.NonPublicEvents)]
	public override EventInfo GetEvent(string name, BindingFlags bindingAttr)
	{
		ArgumentNullException.ThrowIfNull(name, "name");
		FilterHelper(bindingAttr, ref name, out var _, out var listType);
		RuntimeEventInfo[] events_internal = GetEvents_internal(name, listType, this);
		EventInfo eventInfo = null;
		bindingAttr ^= BindingFlags.DeclaredOnly;
		foreach (RuntimeEventInfo runtimeEventInfo in events_internal)
		{
			if ((bindingAttr & runtimeEventInfo.BindingFlags) == runtimeEventInfo.BindingFlags)
			{
				if (eventInfo != null)
				{
					throw ThrowHelper.GetAmbiguousMatchException(eventInfo);
				}
				eventInfo = runtimeEventInfo;
			}
		}
		return eventInfo;
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields)]
	public override FieldInfo GetField(string name, BindingFlags bindingAttr)
	{
		ArgumentNullException.ThrowIfNull(name, "name");
		FilterHelper(bindingAttr, ref name, out var _, out var listType);
		RuntimeFieldInfo[] fields_internal = GetFields_internal(name, bindingAttr, listType, this);
		FieldInfo fieldInfo = null;
		bool flag = false;
		foreach (RuntimeFieldInfo runtimeFieldInfo in fields_internal)
		{
			if (fieldInfo != null)
			{
				if ((object)runtimeFieldInfo.DeclaringType == fieldInfo.DeclaringType)
				{
					throw ThrowHelper.GetAmbiguousMatchException(fieldInfo);
				}
				if (fieldInfo.DeclaringType.IsInterface && runtimeFieldInfo.DeclaringType.IsInterface)
				{
					flag = true;
				}
			}
			if (fieldInfo == null || runtimeFieldInfo.DeclaringType.IsSubclassOf(fieldInfo.DeclaringType) || fieldInfo.DeclaringType.IsInterface)
			{
				fieldInfo = runtimeFieldInfo;
			}
		}
		if (flag && fieldInfo.DeclaringType.IsInterface)
		{
			throw ThrowHelper.GetAmbiguousMatchException(fieldInfo);
		}
		return fieldInfo;
	}

	[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2063:UnrecognizedReflectionPattern", Justification = "Trimming makes sure that interfaces are fully preserved, so the Interfaces annotation is transitive.The cache doesn't carry the necessary annotation since it returns an array type,so the analysis complains that the returned value doesn't have the necessary annotation.")]
	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.Interfaces)]
	[return: DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.Interfaces)]
	public override Type GetInterface(string fullname, bool ignoreCase)
	{
		ArgumentNullException.ThrowIfNull(fullname, "fullname");
		BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.NonPublic;
		bindingFlags &= ~BindingFlags.Static;
		if (ignoreCase)
		{
			bindingFlags |= BindingFlags.IgnoreCase;
		}
		SplitName(fullname, out var name, out var ns);
		FilterHelper(bindingFlags, ref name, out ignoreCase, out var _);
		List<RuntimeType> list = null;
		StringComparison comparisonType = (ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);
		Type[] interfaces = GetInterfaces();
		for (int i = 0; i < interfaces.Length; i++)
		{
			RuntimeType runtimeType = (RuntimeType)interfaces[i];
			if (string.Equals(runtimeType.Name, name, comparisonType))
			{
				if (list == null)
				{
					list = new List<RuntimeType>(2);
				}
				list.Add(runtimeType);
			}
		}
		if (list == null)
		{
			return null;
		}
		RuntimeType[] array = list.ToArray();
		RuntimeType runtimeType2 = null;
		foreach (RuntimeType runtimeType3 in array)
		{
			if (FilterApplyType(runtimeType3, bindingFlags, name, prefixLookup: false, ns))
			{
				if (runtimeType2 != null)
				{
					throw ThrowHelper.GetAmbiguousMatchException(runtimeType2);
				}
				runtimeType2 = runtimeType3;
			}
		}
		return runtimeType2;
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicNestedTypes | DynamicallyAccessedMemberTypes.NonPublicNestedTypes)]
	public override Type GetNestedType(string fullname, BindingFlags bindingAttr)
	{
		ArgumentNullException.ThrowIfNull(fullname, "fullname");
		bindingAttr &= ~BindingFlags.Static;
		SplitName(fullname, out var name, out var ns);
		FilterHelper(bindingAttr, ref name, out var _, out var listType);
		RuntimeType[] nestedTypes_internal = GetNestedTypes_internal(name, bindingAttr, listType);
		RuntimeType runtimeType = null;
		foreach (RuntimeType runtimeType2 in nestedTypes_internal)
		{
			if (FilterApplyType(runtimeType2, bindingAttr, name, prefixLookup: false, ns))
			{
				if (runtimeType != null)
				{
					throw ThrowHelper.GetAmbiguousMatchException(runtimeType);
				}
				runtimeType = runtimeType2;
			}
		}
		return runtimeType;
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicNestedTypes | DynamicallyAccessedMemberTypes.NonPublicNestedTypes | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties | DynamicallyAccessedMemberTypes.PublicEvents | DynamicallyAccessedMemberTypes.NonPublicEvents)]
	public override MemberInfo[] GetMember(string name, MemberTypes type, BindingFlags bindingAttr)
	{
		ArgumentNullException.ThrowIfNull(name, "name");
		ListBuilder<MethodInfo> listBuilder = default(ListBuilder<MethodInfo>);
		ListBuilder<ConstructorInfo> listBuilder2 = default(ListBuilder<ConstructorInfo>);
		ListBuilder<PropertyInfo> listBuilder3 = default(ListBuilder<PropertyInfo>);
		ListBuilder<EventInfo> listBuilder4 = default(ListBuilder<EventInfo>);
		ListBuilder<FieldInfo> listBuilder5 = default(ListBuilder<FieldInfo>);
		ListBuilder<Type> listBuilder6 = default(ListBuilder<Type>);
		int num = 0;
		if ((type & MemberTypes.Method) != 0)
		{
			listBuilder = GetMethodCandidates(name, bindingAttr, CallingConventions.Any, null, -1, allowPrefixLookup: true);
			if (type == MemberTypes.Method)
			{
				return listBuilder.ToArray();
			}
			num += listBuilder.Count;
		}
		if ((type & MemberTypes.Constructor) != 0)
		{
			listBuilder2 = GetConstructorCandidates(name, bindingAttr, CallingConventions.Any, null, allowPrefixLookup: true);
			if (type == MemberTypes.Constructor)
			{
				return listBuilder2.ToArray();
			}
			num += listBuilder2.Count;
		}
		if ((type & MemberTypes.Property) != 0)
		{
			listBuilder3 = GetPropertyCandidates(name, bindingAttr, null, allowPrefixLookup: true);
			if (type == MemberTypes.Property)
			{
				return listBuilder3.ToArray();
			}
			num += listBuilder3.Count;
		}
		if ((type & MemberTypes.Event) != 0)
		{
			listBuilder4 = GetEventCandidates(name, bindingAttr, allowPrefixLookup: true);
			if (type == MemberTypes.Event)
			{
				return listBuilder4.ToArray();
			}
			num += listBuilder4.Count;
		}
		if ((type & MemberTypes.Field) != 0)
		{
			listBuilder5 = GetFieldCandidates(name, bindingAttr, allowPrefixLookup: true);
			if (type == MemberTypes.Field)
			{
				return listBuilder5.ToArray();
			}
			num += listBuilder5.Count;
		}
		if ((type & (MemberTypes.TypeInfo | MemberTypes.NestedType)) != 0)
		{
			listBuilder6 = GetNestedTypeCandidates(name, bindingAttr, allowPrefixLookup: true);
			if (type == MemberTypes.NestedType || type == MemberTypes.TypeInfo)
			{
				return listBuilder6.ToArray();
			}
			num += listBuilder6.Count;
		}
		MemberInfo[] array;
		if (type != (MemberTypes.Constructor | MemberTypes.Method))
		{
			array = new MemberInfo[num];
		}
		else
		{
			MemberInfo[] array2 = new MethodBase[num];
			array = array2;
		}
		MemberInfo[] array3 = array;
		int num2 = 0;
		object[] array4 = array3;
		listBuilder.CopyTo(array4, num2);
		num2 += listBuilder.Count;
		array4 = array3;
		listBuilder2.CopyTo(array4, num2);
		num2 += listBuilder2.Count;
		array4 = array3;
		listBuilder3.CopyTo(array4, num2);
		num2 += listBuilder3.Count;
		array4 = array3;
		listBuilder4.CopyTo(array4, num2);
		num2 += listBuilder4.Count;
		array4 = array3;
		listBuilder5.CopyTo(array4, num2);
		num2 += listBuilder5.Count;
		array4 = array3;
		listBuilder6.CopyTo(array4, num2);
		num2 += listBuilder6.Count;
		return array3;
	}

	public override MemberInfo GetMemberWithSameMetadataDefinitionAs(MemberInfo member)
	{
		ArgumentNullException.ThrowIfNull(member, "member");
		RuntimeType runtimeType = this;
		while (runtimeType != null)
		{
			MemberInfo memberInfo = member.MemberType switch
			{
				MemberTypes.Method => GetMethodWithSameMetadataDefinitionAs(runtimeType, member), 
				MemberTypes.Constructor => GetConstructorWithSameMetadataDefinitionAs(runtimeType, member), 
				MemberTypes.Property => GetPropertyWithSameMetadataDefinitionAs(runtimeType, member), 
				MemberTypes.Field => GetFieldWithSameMetadataDefinitionAs(runtimeType, member), 
				MemberTypes.Event => GetEventWithSameMetadataDefinitionAs(runtimeType, member), 
				MemberTypes.NestedType => GetNestedTypeWithSameMetadataDefinitionAs(runtimeType, member), 
				_ => null, 
			};
			if (memberInfo != null)
			{
				return memberInfo;
			}
			runtimeType = runtimeType.GetBaseType();
		}
		throw Type.CreateGetMemberWithSameMetadataDefinitionAsNotFoundException(member);
	}

	private static MethodInfo GetMethodWithSameMetadataDefinitionAs(RuntimeType runtimeType, MemberInfo methodInfo)
	{
		ListBuilder<MethodInfo> methodCandidates = runtimeType.GetMethodCandidates(methodInfo.Name, BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, CallingConventions.Any, null, -1, allowPrefixLookup: false);
		for (int i = 0; i < methodCandidates.Count; i++)
		{
			MethodInfo methodInfo2 = methodCandidates[i];
			if (methodInfo2.HasSameMetadataDefinitionAs(methodInfo))
			{
				return methodInfo2;
			}
		}
		return null;
	}

	private static ConstructorInfo GetConstructorWithSameMetadataDefinitionAs(RuntimeType runtimeType, MemberInfo constructorInfo)
	{
		ListBuilder<ConstructorInfo> constructorCandidates = runtimeType.GetConstructorCandidates(null, BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, CallingConventions.Any, null, allowPrefixLookup: false);
		for (int i = 0; i < constructorCandidates.Count; i++)
		{
			ConstructorInfo constructorInfo2 = constructorCandidates[i];
			if (constructorInfo2.HasSameMetadataDefinitionAs(constructorInfo))
			{
				return constructorInfo2;
			}
		}
		return null;
	}

	private static PropertyInfo GetPropertyWithSameMetadataDefinitionAs(RuntimeType runtimeType, MemberInfo propertyInfo)
	{
		ListBuilder<PropertyInfo> propertyCandidates = runtimeType.GetPropertyCandidates(propertyInfo.Name, BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, allowPrefixLookup: false);
		for (int i = 0; i < propertyCandidates.Count; i++)
		{
			PropertyInfo propertyInfo2 = propertyCandidates[i];
			if (propertyInfo2.HasSameMetadataDefinitionAs(propertyInfo))
			{
				return propertyInfo2;
			}
		}
		return null;
	}

	private static FieldInfo GetFieldWithSameMetadataDefinitionAs(RuntimeType runtimeType, MemberInfo fieldInfo)
	{
		ListBuilder<FieldInfo> fieldCandidates = runtimeType.GetFieldCandidates(fieldInfo.Name, BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, allowPrefixLookup: false);
		for (int i = 0; i < fieldCandidates.Count; i++)
		{
			FieldInfo fieldInfo2 = fieldCandidates[i];
			if (fieldInfo2.HasSameMetadataDefinitionAs(fieldInfo))
			{
				return fieldInfo2;
			}
		}
		return null;
	}

	private static EventInfo GetEventWithSameMetadataDefinitionAs(RuntimeType runtimeType, MemberInfo eventInfo)
	{
		ListBuilder<EventInfo> eventCandidates = runtimeType.GetEventCandidates(null, BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, allowPrefixLookup: false);
		for (int i = 0; i < eventCandidates.Count; i++)
		{
			EventInfo eventInfo2 = eventCandidates[i];
			if (eventInfo2.HasSameMetadataDefinitionAs(eventInfo))
			{
				return eventInfo2;
			}
		}
		return null;
	}

	private static Type GetNestedTypeWithSameMetadataDefinitionAs(RuntimeType runtimeType, MemberInfo nestedType)
	{
		ListBuilder<Type> nestedTypeCandidates = runtimeType.GetNestedTypeCandidates(nestedType.Name, BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, allowPrefixLookup: false);
		for (int i = 0; i < nestedTypeCandidates.Count; i++)
		{
			Type type = nestedTypeCandidates[i];
			if (type.HasSameMetadataDefinitionAs(nestedType))
			{
				return type;
			}
		}
		return null;
	}

	public override bool IsInstanceOfType([NotNullWhen(true)] object o)
	{
		return RuntimeTypeHandle.IsInstanceOfType(this, o);
	}

	protected override bool IsCOMObjectImpl()
	{
		return false;
	}

	public override bool IsEquivalentTo(Type other)
	{
		if (!(other is RuntimeType runtimeType))
		{
			return false;
		}
		if (runtimeType == this)
		{
			return true;
		}
		return false;
	}

	internal CorElementType GetCorElementType()
	{
		TypeCache typeCache = Cache;
		if ((typeCache.Cached & 0x20) != 0)
		{
			return typeCache.CorElementType;
		}
		RuntimeType type = this;
		typeCache.CorElementType = RuntimeTypeHandle.GetCorElementType(new QCallTypeHandle(ref type));
		Interlocked.MemoryBarrier();
		UpdateCached(TypeCacheEntries.CorElementType);
		return typeCache.CorElementType;
	}

	internal TypeAttributes GetAttributes()
	{
		TypeCache typeCache = Cache;
		if ((typeCache.Cached & 0x40) != 0)
		{
			return typeCache.TypeAttributes;
		}
		RuntimeType type = this;
		typeCache.TypeAttributes = RuntimeTypeHandle.GetAttributes(new QCallTypeHandle(ref type));
		Interlocked.MemoryBarrier();
		UpdateCached(TypeCacheEntries.TypeAttributes);
		return typeCache.TypeAttributes;
	}

	internal bool IsDelegate()
	{
		TypeCache typeCache = Cache;
		if ((typeCache.Cached & 2) != 0)
		{
			return (typeCache.Flags & 2) != 0;
		}
		bool flag = GetBaseType() == typeof(MulticastDelegate);
		CacheFlag(TypeCacheEntries.IsDelegate, flag);
		return flag;
	}

	protected override bool IsValueTypeImpl()
	{
		TypeCache typeCache = Cache;
		if ((typeCache.Cached & 4) != 0)
		{
			return (typeCache.Flags & 4) != 0;
		}
		bool flag = false;
		if (!(this == typeof(ValueType)) && !(this == typeof(Enum)))
		{
			flag = IsSubclassOf(typeof(ValueType));
		}
		CacheFlag(TypeCacheEntries.IsValueType, flag);
		return flag;
	}

	public override Type GetGenericTypeDefinition()
	{
		if (!IsGenericType)
		{
			throw new InvalidOperationException("InvalidOperation_NotGenericType");
		}
		return RuntimeTypeHandle.GetGenericTypeDefinition(this);
	}

	internal RuntimeType[] GetGenericArgumentsInternal()
	{
		RuntimeType[] o = null;
		RuntimeType type = this;
		GetGenericArgumentsInternal(new QCallTypeHandle(ref type), ObjectHandleOnStack.Create(ref o), runtimeArray: true);
		return o;
	}

	public override Type[] GetGenericArguments()
	{
		Type[] o = null;
		RuntimeType type = this;
		GetGenericArgumentsInternal(new QCallTypeHandle(ref type), ObjectHandleOnStack.Create(ref o), runtimeArray: false);
		return o ?? Type.EmptyTypes;
	}

	[RequiresUnreferencedCode("If some of the generic arguments are annotated (either with DynamicallyAccessedMembersAttribute, or generic constraints), trimming can't validate that the requirements of those annotations are met.")]
	public override Type MakeGenericType(params Type[] typeArguments)
	{
		ArgumentNullException.ThrowIfNull(typeArguments, "typeArguments");
		RuntimeType[] array = new RuntimeType[typeArguments.Length];
		if (!IsGenericTypeDefinition)
		{
			throw new InvalidOperationException(SR.Format("Arg_NotGenericTypeDefinition", this));
		}
		RuntimeType[] genericArgumentsInternal = GetGenericArgumentsInternal();
		if (genericArgumentsInternal.Length != typeArguments.Length)
		{
			throw new ArgumentException("Argument_GenericArgsCount", "typeArguments");
		}
		for (int i = 0; i < typeArguments.Length; i++)
		{
			Type type = typeArguments[i];
			if (type == null)
			{
				throw new ArgumentNullException();
			}
			RuntimeType runtimeType = type as RuntimeType;
			if (runtimeType == null)
			{
				if (type.IsSignatureType)
				{
					return Type.MakeGenericSignatureType(this, typeArguments);
				}
				Type[] array2 = new Type[typeArguments.Length];
				for (int j = 0; j < typeArguments.Length; j++)
				{
					array2[j] = typeArguments[j];
				}
				typeArguments = array2;
				if (1 == 0)
				{
				}
				return TypeBuilderInstantiation.MakeGenericType(this, typeArguments);
			}
			array[i] = runtimeType;
		}
		SanityCheckGenericArguments(array, genericArgumentsInternal);
		Type o = null;
		Type[] types = array;
		MakeGenericType(this, types, ObjectHandleOnStack.Create(ref o));
		if (o == null)
		{
			throw new TypeLoadException();
		}
		return o;
	}

	public static bool operator ==(RuntimeType left, RuntimeType right)
	{
		return (object)left == right;
	}

	public static bool operator !=(RuntimeType left, RuntimeType right)
	{
		return (object)left != right;
	}

	private void CreateInstanceCheckThis()
	{
		if (ContainsGenericParameters)
		{
			throw new ArgumentException(SR.Format("Acc_CreateGenericEx", this));
		}
		Type rootElementType = GetRootElementType();
		if ((object)rootElementType == typeof(ArgIterator))
		{
			throw new NotSupportedException("Acc_CreateArgIterator");
		}
		if ((object)rootElementType == typeof(void))
		{
			throw new NotSupportedException("Acc_CreateVoid");
		}
	}

	[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2082:UnrecognizedReflectionPattern", Justification = "Implementation detail of Activator that linker intrinsically recognizes")]
	[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2085:UnrecognizedReflectionPattern", Justification = "Implementation detail of Activator that linker intrinsically recognizes")]
	internal object CreateInstanceImpl(BindingFlags bindingAttr, Binder binder, object[] args, CultureInfo culture)
	{
		CreateInstanceCheckThis();
		object result;
		try
		{
			if (args == null)
			{
				args = Array.Empty<object>();
			}
			int num = args.Length;
			if (binder == null)
			{
				binder = Type.DefaultBinder;
			}
			bool publicOnly = (bindingAttr & BindingFlags.NonPublic) == 0;
			bool wrapExceptions = (bindingAttr & BindingFlags.DoNotWrapExceptions) == 0;
			if (num == 0 && (bindingAttr & BindingFlags.Public) != BindingFlags.Default && (bindingAttr & BindingFlags.Instance) != BindingFlags.Default && base.IsValueType)
			{
				result = CreateInstanceDefaultCtor(publicOnly, wrapExceptions);
			}
			else
			{
				ConstructorInfo[] constructors = GetConstructors(bindingAttr);
				List<MethodBase> list = new List<MethodBase>(constructors.Length);
				Type[] array = new Type[num];
				for (int i = 0; i < num; i++)
				{
					if (args[i] != null)
					{
						array[i] = args[i].GetType();
					}
				}
				for (int j = 0; j < constructors.Length; j++)
				{
					if (FilterApplyConstructorInfo((RuntimeConstructorInfo)constructors[j], bindingAttr, CallingConventions.Any, array))
					{
						list.Add(constructors[j]);
					}
				}
				MethodBase[] array2 = new MethodBase[list.Count];
				list.CopyTo(array2);
				if (array2 != null && array2.Length == 0)
				{
					array2 = null;
				}
				if (array2 == null)
				{
					throw new MissingMethodException(SR.Format("MissingConstructor_Name", FullName));
				}
				MethodBase methodBase;
				object state;
				try
				{
					methodBase = binder.BindToMethod(bindingAttr, array2, ref args, null, culture, null, out state);
				}
				catch (MissingMethodException inner)
				{
					throw new MissingMethodException(SR.Format("MissingConstructor_Name", FullName), inner);
				}
				if (methodBase == null)
				{
					throw new MissingMethodException(SR.Format("MissingConstructor_Name", FullName));
				}
				if (methodBase.GetParametersAsSpan().Length == 0)
				{
					if (args.Length != 0)
					{
						throw new NotSupportedException("NotSupported_CallToVarArg");
					}
					result = Activator.CreateInstance(this, nonPublic: true, wrapExceptions);
				}
				else
				{
					result = ((ConstructorInfo)methodBase).Invoke(bindingAttr, binder, args, culture);
					if (state != null)
					{
						binder.ReorderArgumentArray(ref args, state);
					}
				}
			}
		}
		catch (Exception)
		{
			throw;
		}
		return result;
	}

	[DebuggerStepThrough]
	[DebuggerHidden]
	internal object CreateInstanceDefaultCtor(bool publicOnly, bool wrapExceptions)
	{
		if (IsByRefLike)
		{
			throw new NotSupportedException("NotSupported_ByRefLike");
		}
		CreateInstanceCheckThis();
		return CreateInstanceMono(!publicOnly, wrapExceptions);
	}

	[DebuggerStepThrough]
	[DebuggerHidden]
	internal object CreateInstanceOfT()
	{
		return CreateInstanceMono(nonPublic: false, wrapExceptions: true);
	}

	[DebuggerStepThrough]
	[DebuggerHidden]
	internal unsafe void CallDefaultStructConstructor(ref byte value)
	{
		RuntimeConstructorInfo defaultConstructor = GetDefaultConstructor();
		if (defaultConstructor == null)
		{
			return;
		}
		if (!defaultConstructor.IsPublic)
		{
			throw new MissingMethodException(SR.Format("Arg_NoDefCTor", this));
		}
		delegate*<ref byte, void> functionPointer = (delegate*<ref byte, void>)defaultConstructor.MethodHandle.GetFunctionPointer();
		if (functionPointer == (delegate*<ref byte, void>)null)
		{
			throw new ExecutionEngineException();
		}
		try
		{
			functionPointer(ref value);
		}
		catch (Exception inner)
		{
			throw new TargetInvocationException(inner);
		}
	}

	private void UpdateCached(TypeCacheEntries entry)
	{
		TypeCache typeCache = Cache;
		int cached = typeCache.Cached;
		int value = cached | (int)entry;
		Interlocked.CompareExchange(ref typeCache.Cached, value, cached);
	}

	private void CacheFlag(TypeCacheEntries flag, bool value)
	{
		TypeCache typeCache = Cache;
		int flags = typeCache.Flags;
		int value2 = (value ? (flags | (int)flag) : flags);
		if (Interlocked.CompareExchange(ref typeCache.Flags, value2, flags) == flags)
		{
			UpdateCached(flag);
		}
	}

	internal RuntimeConstructorInfo GetDefaultConstructor()
	{
		TypeCache typeCache = Cache;
		RuntimeConstructorInfo result = null;
		if ((typeCache.Cached & 0x80) != 0)
		{
			return typeCache.default_ctor;
		}
		ListBuilder<ConstructorInfo> constructorCandidates = GetConstructorCandidates(null, BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, CallingConventions.Any, Type.EmptyTypes, allowPrefixLookup: false);
		if (constructorCandidates.Count == 1)
		{
			result = (typeCache.default_ctor = (RuntimeConstructorInfo)constructorCandidates[0]);
		}
		Interlocked.MemoryBarrier();
		UpdateCached(TypeCacheEntries.DefaultCtor);
		return result;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern MemberInfo GetCorrespondingInflatedMethod(QCallTypeHandle type, MemberInfo generic);

	internal override MethodInfo GetMethod(MethodInfo fromNoninstanciated)
	{
		ArgumentNullException.ThrowIfNull(fromNoninstanciated, "fromNoninstanciated");
		RuntimeType type = this;
		return (MethodInfo)GetCorrespondingInflatedMethod(new QCallTypeHandle(ref type), fromNoninstanciated);
	}

	internal override ConstructorInfo GetConstructor(ConstructorInfo fromNoninstanciated)
	{
		ArgumentNullException.ThrowIfNull(fromNoninstanciated, "fromNoninstanciated");
		RuntimeType type = this;
		return (ConstructorInfo)GetCorrespondingInflatedMethod(new QCallTypeHandle(ref type), fromNoninstanciated);
	}

	[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2085:UnrecognizedReflectionPattern", Justification = "We already have a FieldInfo so this will succeed")]
	internal override FieldInfo GetField(FieldInfo fromNoninstanciated)
	{
		BindingFlags bindingFlags = (fromNoninstanciated.IsStatic ? BindingFlags.Static : BindingFlags.Instance);
		bindingFlags = (BindingFlags)((int)bindingFlags | (fromNoninstanciated.IsPublic ? 16 : 32));
		return GetField(fromNoninstanciated.Name, bindingFlags);
	}

	private string GetDefaultMemberName()
	{
		object[] customAttributes = GetCustomAttributes(typeof(DefaultMemberAttribute), inherit: true);
		if (customAttributes.Length == 0)
		{
			return null;
		}
		return ((DefaultMemberAttribute)customAttributes[0]).MemberName;
	}

	private object CreateInstanceMono(bool nonPublic, bool wrapExceptions)
	{
		RuntimeConstructorInfo defaultConstructor = GetDefaultConstructor();
		if (!nonPublic && defaultConstructor != null && !defaultConstructor.IsPublic)
		{
			throw new MissingMethodException(SR.Format("Arg_NoDefCTor", this));
		}
		if (defaultConstructor == null)
		{
			Type rootElementType = GetRootElementType();
			if ((object)rootElementType == typeof(TypedReference) || (object)rootElementType == typeof(RuntimeArgumentHandle))
			{
				throw new NotSupportedException("NotSupported_ContainsStackPtr");
			}
			if (base.IsValueType)
			{
				RuntimeType type = this;
				return CreateInstanceInternal(new QCallTypeHandle(ref type));
			}
			throw new MissingMethodException(SR.Format("Arg_NoDefCTor", this));
		}
		if (base.IsAbstract)
		{
			throw new MissingMethodException(SR.Format("Acc_CreateAbstEx", this));
		}
		return defaultConstructor.Invoker.InvokeWithNoArgs(null, (!wrapExceptions) ? BindingFlags.DoNotWrapExceptions : BindingFlags.Default);
	}

	private CheckValueStatus TryChangeTypeSpecial(ref object value)
	{
		if (IsEnum)
		{
			Type underlyingType = Enum.GetUnderlyingType(this);
			if (underlyingType == value.GetType())
			{
				return CheckValueStatus.Success;
			}
			object obj = IsConvertibleToPrimitiveType(value, underlyingType);
			if (obj != null)
			{
				value = obj;
				return CheckValueStatus.Success;
			}
		}
		else if (base.IsPrimitive)
		{
			object obj2 = IsConvertibleToPrimitiveType(value, this);
			if (obj2 != null)
			{
				value = obj2;
				return CheckValueStatus.Success;
			}
		}
		else if (base.IsPointer)
		{
			object obj3 = value;
			if ((obj3 is nint || obj3 is nuint) ? true : false)
			{
				return CheckValueStatus.Success;
			}
			if (value is Pointer pointer && (Type?)pointer.GetPointerType() == (Type?)this)
			{
				value = pointer.GetPointerValue();
				return CheckValueStatus.Success;
			}
		}
		else if (IsFunctionPointer)
		{
			object obj3 = value;
			if ((obj3 is nint || obj3 is nuint) ? true : false)
			{
				return CheckValueStatus.Success;
			}
			value = (nint)value;
			return CheckValueStatus.Success;
		}
		return CheckValueStatus.ArgumentException;
	}

	private static object IsConvertibleToPrimitiveType(object value, Type targetType)
	{
		Type type = value.GetType();
		if (type.IsEnum)
		{
			type = Enum.GetUnderlyingType(type);
			if (type == targetType)
			{
				return value;
			}
		}
		TypeCode typeCode = Type.GetTypeCode(type);
		switch (Type.GetTypeCode(targetType))
		{
		case TypeCode.Char:
			switch (typeCode)
			{
			case TypeCode.Byte:
				return (char)(byte)value;
			case TypeCode.UInt16:
				return value;
			}
			break;
		case TypeCode.Int16:
			switch (typeCode)
			{
			case TypeCode.Byte:
				return (short)(byte)value;
			case TypeCode.SByte:
				return (short)(sbyte)value;
			}
			break;
		case TypeCode.UInt16:
			switch (typeCode)
			{
			case TypeCode.Byte:
				return (ushort)(byte)value;
			case TypeCode.Char:
				return value;
			}
			break;
		case TypeCode.Int32:
			switch (typeCode)
			{
			case TypeCode.Byte:
				return (int)(byte)value;
			case TypeCode.SByte:
				return (int)(sbyte)value;
			case TypeCode.Char:
				return (int)(char)value;
			case TypeCode.Int16:
				return (int)(short)value;
			case TypeCode.UInt16:
				return (int)(ushort)value;
			}
			break;
		case TypeCode.UInt32:
			switch (typeCode)
			{
			case TypeCode.Byte:
				return (uint)(byte)value;
			case TypeCode.Char:
				return (uint)(char)value;
			case TypeCode.UInt16:
				return (uint)(ushort)value;
			}
			break;
		case TypeCode.Int64:
			switch (typeCode)
			{
			case TypeCode.Byte:
				return (long)(byte)value;
			case TypeCode.SByte:
				return (long)(sbyte)value;
			case TypeCode.Int16:
				return (long)(short)value;
			case TypeCode.Char:
				return (long)(char)value;
			case TypeCode.UInt16:
				return (long)(ushort)value;
			case TypeCode.Int32:
				return (long)(int)value;
			case TypeCode.UInt32:
				return (long)(uint)value;
			}
			break;
		case TypeCode.UInt64:
			switch (typeCode)
			{
			case TypeCode.Byte:
				return (ulong)(byte)value;
			case TypeCode.Char:
				return (ulong)(char)value;
			case TypeCode.UInt16:
				return (ulong)(ushort)value;
			case TypeCode.UInt32:
				return (ulong)(uint)value;
			}
			break;
		case TypeCode.Single:
			switch (typeCode)
			{
			case TypeCode.Byte:
				return (float)(int)(byte)value;
			case TypeCode.SByte:
				return (float)(sbyte)value;
			case TypeCode.Int16:
				return (float)(short)value;
			case TypeCode.Char:
				return (float)(int)(char)value;
			case TypeCode.UInt16:
				return (float)(int)(ushort)value;
			case TypeCode.Int32:
				return (float)(int)value;
			case TypeCode.UInt32:
				return (float)(uint)value;
			case TypeCode.Int64:
				return (float)(long)value;
			case TypeCode.UInt64:
				return (float)(ulong)value;
			}
			break;
		case TypeCode.Double:
			switch (typeCode)
			{
			case TypeCode.Byte:
				return (double)(int)(byte)value;
			case TypeCode.SByte:
				return (double)(sbyte)value;
			case TypeCode.Char:
				return (double)(int)(char)value;
			case TypeCode.Int16:
				return (double)(short)value;
			case TypeCode.UInt16:
				return (double)(int)(ushort)value;
			case TypeCode.Int32:
				return (double)(int)value;
			case TypeCode.UInt32:
				return (double)(uint)value;
			case TypeCode.Int64:
				return (double)(long)value;
			case TypeCode.UInt64:
				return (double)(ulong)value;
			case TypeCode.Single:
				return (double)(float)value;
			}
			break;
		}
		return null;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void make_array_type(QCallTypeHandle type, int rank, ObjectHandleOnStack res);

	public override Type MakeArrayType()
	{
		Type o = null;
		RuntimeType type = this;
		make_array_type(new QCallTypeHandle(ref type), 0, ObjectHandleOnStack.Create(ref o));
		return o;
	}

	public override Type MakeArrayType(int rank)
	{
		if (rank < 1)
		{
			throw new IndexOutOfRangeException();
		}
		Type o = null;
		RuntimeType type = this;
		make_array_type(new QCallTypeHandle(ref type), rank, ObjectHandleOnStack.Create(ref o));
		return o;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void make_byref_type(QCallTypeHandle type, ObjectHandleOnStack res);

	public override Type MakeByRefType()
	{
		if (base.IsByRef)
		{
			throw new TypeLoadException(SR.Format("CannotCreateByRefOfByRef", GetType()));
		}
		Type o = null;
		RuntimeType type = this;
		make_byref_type(new QCallTypeHandle(ref type), ObjectHandleOnStack.Create(ref o));
		return o;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void make_pointer_type(QCallTypeHandle type, ObjectHandleOnStack res);

	public override Type MakePointerType()
	{
		if (base.IsByRef)
		{
			throw new TypeLoadException(SR.Format("CannotCreatePointerOfByRef", GetType()));
		}
		Type o = null;
		RuntimeType type = this;
		make_pointer_type(new QCallTypeHandle(ref type), ObjectHandleOnStack.Create(ref o));
		return o;
	}

	public override Type[] GetGenericParameterConstraints()
	{
		if (!IsGenericParameter)
		{
			throw new InvalidOperationException("Arg_NotGenericParameter");
		}
		return new RuntimeGenericParamInfoHandle(RuntimeTypeHandle.GetGenericParameterInfo(this)).Constraints ?? Type.EmptyTypes;
	}

	internal static object CreateInstanceForAnotherGenericParameter([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor)] Type genericType, RuntimeType genericArgument, RuntimeType genericArgument2 = null)
	{
		RuntimeType o = null;
		if (genericArgument2 != null)
		{
			MakeGenericType(genericType, new Type[2] { genericArgument, genericArgument2 }, ObjectHandleOnStack.Create(ref o));
		}
		else
		{
			MakeGenericType(genericType, new Type[1] { genericArgument }, ObjectHandleOnStack.Create(ref o));
		}
		RuntimeConstructorInfo defaultConstructor = o.GetDefaultConstructor();
		if ((object)defaultConstructor == null || !defaultConstructor.IsPublic)
		{
			throw new MissingMethodException(SR.Format("Arg_NoDefCTor", o));
		}
		return defaultConstructor.Invoker.InvokeWithNoArgs(null, BindingFlags.Default);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void MakeGenericType(Type gt, Type[] types, ObjectHandleOnStack res);

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern nint GetMethodsByName_native(QCallTypeHandle type, nint namePtr, BindingFlags bindingAttr, MemberListType listType);

	internal RuntimeMethodInfo[] GetMethodsByName(string name, BindingFlags bindingAttr, MemberListType listType, RuntimeType reflectedType)
	{
		RuntimeType type = this;
		RuntimeTypeHandle reflectedType2 = new RuntimeTypeHandle(reflectedType);
		using SafeStringMarshal safeStringMarshal = new SafeStringMarshal(name);
		using SafeGPtrArrayHandle safeGPtrArrayHandle = new SafeGPtrArrayHandle(GetMethodsByName_native(new QCallTypeHandle(ref type), safeStringMarshal.Value, bindingAttr, listType));
		int length = safeGPtrArrayHandle.Length;
		RuntimeMethodInfo[] array = new RuntimeMethodInfo[length];
		for (int i = 0; i < length; i++)
		{
			RuntimeMethodHandle handle = new RuntimeMethodHandle(safeGPtrArrayHandle[i]);
			array[i] = (RuntimeMethodInfo)RuntimeMethodInfo.GetMethodFromHandleNoGenericCheck(handle, reflectedType2);
		}
		return array;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern nint GetPropertiesByName_native(QCallTypeHandle type, nint name, BindingFlags bindingAttr, MemberListType listType);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern nint GetConstructors_native(QCallTypeHandle type, BindingFlags bindingAttr);

	private RuntimeConstructorInfo[] GetConstructors_internal(BindingFlags bindingAttr, RuntimeType reflectedType)
	{
		RuntimeTypeHandle reflectedType2 = new RuntimeTypeHandle(reflectedType);
		RuntimeType type = this;
		using SafeGPtrArrayHandle safeGPtrArrayHandle = new SafeGPtrArrayHandle(GetConstructors_native(new QCallTypeHandle(ref type), bindingAttr));
		int length = safeGPtrArrayHandle.Length;
		RuntimeConstructorInfo[] array = new RuntimeConstructorInfo[length];
		for (int i = 0; i < length; i++)
		{
			RuntimeMethodHandle handle = new RuntimeMethodHandle(safeGPtrArrayHandle[i]);
			array[i] = (RuntimeConstructorInfo)RuntimeMethodInfo.GetMethodFromHandleNoGenericCheck(handle, reflectedType2);
		}
		return array;
	}

	private RuntimePropertyInfo[] GetPropertiesByName(string name, BindingFlags bindingAttr, MemberListType listType, RuntimeType reflectedType)
	{
		RuntimeTypeHandle reflectedType2 = new RuntimeTypeHandle(reflectedType);
		RuntimeType type = this;
		using SafeStringMarshal safeStringMarshal = new SafeStringMarshal(name);
		using SafeGPtrArrayHandle safeGPtrArrayHandle = new SafeGPtrArrayHandle(GetPropertiesByName_native(new QCallTypeHandle(ref type), safeStringMarshal.Value, bindingAttr, listType));
		int length = safeGPtrArrayHandle.Length;
		RuntimePropertyInfo[] array = new RuntimePropertyInfo[length];
		for (int i = 0; i < length; i++)
		{
			RuntimePropertyHandle handle = new RuntimePropertyHandle(safeGPtrArrayHandle[i]);
			array[i] = (RuntimePropertyInfo)RuntimePropertyInfo.GetPropertyFromHandle(handle, reflectedType2);
		}
		return array;
	}

	public override InterfaceMapping GetInterfaceMap([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods)] Type interfaceType)
	{
		if (IsGenericParameter)
		{
			throw new InvalidOperationException("Arg_GenericParameter");
		}
		ArgumentNullException.ThrowIfNull(interfaceType, "interfaceType");
		RuntimeType type = interfaceType as RuntimeType;
		if (type == null)
		{
			throw new ArgumentException("Argument_MustBeRuntimeType", "interfaceType");
		}
		if (!interfaceType.IsInterface)
		{
			throw new ArgumentException("Arg_MustBeInterface", "interfaceType");
		}
		if (base.IsInterface)
		{
			throw new ArgumentException("Argument_InterfaceMap");
		}
		RuntimeType type2 = this;
		Unsafe.SkipInit(out InterfaceMapping result);
		result.TargetType = this;
		result.InterfaceType = interfaceType;
		GetInterfaceMapData(new QCallTypeHandle(ref type2), new QCallTypeHandle(ref type), out result.TargetMethods, out result.InterfaceMethods);
		if (result.TargetMethods == null)
		{
			throw new ArgumentException("Arg_NotFoundIFace", "interfaceType");
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetInterfaceMapData(QCallTypeHandle t, QCallTypeHandle iface, out MethodInfo[] targets, out MethodInfo[] methods);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetPacking(QCallTypeHandle type, out int packing, out int size);

	internal void GetPacking(out int packing, out int size)
	{
		RuntimeType type = this;
		GetPacking(new QCallTypeHandle(ref type), out packing, out size);
	}

	public override string ToString()
	{
		return getFullName(full_name: false, assembly_qualified: false);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern object CreateInstanceInternal(QCallTypeHandle type);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetDeclaringMethod(QCallTypeHandle type, ObjectHandleOnStack res);

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern void getFullName(QCallTypeHandle type, ObjectHandleOnStack res, bool full_name, bool assembly_qualified);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetGenericArgumentsInternal(QCallTypeHandle type, ObjectHandleOnStack res, bool runtimeArray);

	internal string getFullName(bool full_name, bool assembly_qualified)
	{
		if ((full_name || assembly_qualified) && !IsFullNameRoundtripCompatible(this))
		{
			return null;
		}
		RuntimeType type = this;
		string o = null;
		getFullName(new QCallTypeHandle(ref type), ObjectHandleOnStack.Create(ref o), full_name, assembly_qualified);
		return o;
	}

	private GenericParameterAttributes GetGenericParameterAttributes()
	{
		return new RuntimeGenericParamInfoHandle(RuntimeTypeHandle.GetGenericParameterInfo(this)).Attributes;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int GetGenericParameterPosition(QCallTypeHandle type);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern nint GetEvents_native(QCallTypeHandle type, nint name, MemberListType listType);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern nint GetFields_native(QCallTypeHandle type, nint name, BindingFlags bindingAttr, MemberListType listType);

	private RuntimeFieldInfo[] GetFields_internal(string name, BindingFlags bindingAttr, MemberListType listType, RuntimeType reflectedType)
	{
		RuntimeTypeHandle declaringType = new RuntimeTypeHandle(reflectedType);
		RuntimeType type = this;
		using SafeStringMarshal safeStringMarshal = new SafeStringMarshal(name);
		using SafeGPtrArrayHandle safeGPtrArrayHandle = new SafeGPtrArrayHandle(GetFields_native(new QCallTypeHandle(ref type), safeStringMarshal.Value, bindingAttr, listType));
		int length = safeGPtrArrayHandle.Length;
		RuntimeFieldInfo[] array = new RuntimeFieldInfo[length];
		for (int i = 0; i < length; i++)
		{
			RuntimeFieldHandle handle = new RuntimeFieldHandle(safeGPtrArrayHandle[i]);
			array[i] = (RuntimeFieldInfo)FieldInfo.GetFieldFromHandle(handle, declaringType);
		}
		return array;
	}

	private RuntimeEventInfo[] GetEvents_internal(string name, MemberListType listType, RuntimeType reflectedType)
	{
		RuntimeTypeHandle reflectedType2 = new RuntimeTypeHandle(reflectedType);
		RuntimeType type = this;
		using SafeStringMarshal safeStringMarshal = new SafeStringMarshal(name);
		using SafeGPtrArrayHandle safeGPtrArrayHandle = new SafeGPtrArrayHandle(GetEvents_native(new QCallTypeHandle(ref type), safeStringMarshal.Value, listType));
		int length = safeGPtrArrayHandle.Length;
		RuntimeEventInfo[] array = new RuntimeEventInfo[length];
		for (int i = 0; i < length; i++)
		{
			RuntimeEventHandle handle = new RuntimeEventHandle(safeGPtrArrayHandle[i]);
			array[i] = (RuntimeEventInfo)RuntimeEventInfo.GetEventFromHandle(handle, reflectedType2);
		}
		return array;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetInterfaces(QCallTypeHandle type, ObjectHandleOnStack res);

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.Interfaces)]
	public override Type[] GetInterfaces()
	{
		RuntimeType type = this;
		Type[] o = null;
		GetInterfaces(new QCallTypeHandle(ref type), ObjectHandleOnStack.Create(ref o));
		return o;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern nint GetNestedTypes_native(QCallTypeHandle type, nint name, BindingFlags bindingAttr, MemberListType listType);

	private RuntimeType[] GetNestedTypes_internal(string displayName, BindingFlags bindingAttr, MemberListType listType)
	{
		string str = null;
		if (displayName != null)
		{
			str = displayName;
		}
		RuntimeType type = this;
		using SafeStringMarshal safeStringMarshal = new SafeStringMarshal(str);
		using SafeGPtrArrayHandle safeGPtrArrayHandle = new SafeGPtrArrayHandle(GetNestedTypes_native(new QCallTypeHandle(ref type), safeStringMarshal.Value, bindingAttr, listType));
		int length = safeGPtrArrayHandle.Length;
		RuntimeType[] array = new RuntimeType[length];
		for (int i = 0; i < length; i++)
		{
			RuntimeTypeHandle handle = new RuntimeTypeHandle(safeGPtrArrayHandle[i]);
			array[i] = (RuntimeType)Type.GetTypeFromHandle(handle);
		}
		return array;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetDeclaringType(QCallTypeHandle type, ObjectHandleOnStack res);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetName(QCallTypeHandle type, ObjectHandleOnStack res);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetNamespace(QCallTypeHandle type, ObjectHandleOnStack res);

	public sealed override bool HasSameMetadataDefinitionAs(MemberInfo other)
	{
		return HasSameMetadataDefinitionAsCore<RuntimeType>(other);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern bool IsUnmanagedFunctionPointerInternal(QCallTypeHandle type);

	internal static bool IsUnmanagedFunctionPointerInternal(RuntimeType type)
	{
		return IsUnmanagedFunctionPointerInternal(new QCallTypeHandle(ref type));
	}

	public override Type[] GetFunctionPointerParameterTypes()
	{
		Type[] array = FunctionPointerReturnAndParameterTypes(this, returnType: false);
		if (array.Length != 0)
		{
			return array;
		}
		return Type.EmptyTypes;
	}

	public override Type GetFunctionPointerReturnType()
	{
		return FunctionPointerReturnAndParameterTypes(this, returnType: true)[0];
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern nint FunctionPointerReturnAndParameterTypes(QCallTypeHandle type);

	internal static Type[] FunctionPointerReturnAndParameterTypes(RuntimeType type, bool returnType)
	{
		if (!RuntimeTypeHandle.IsFunctionPointer(type))
		{
			throw new InvalidOperationException("InvalidOperation_NotFunctionPointer");
		}
		using SafeGPtrArrayHandle safeGPtrArrayHandle = new SafeGPtrArrayHandle(FunctionPointerReturnAndParameterTypes(new QCallTypeHandle(ref type)));
		int num = (returnType ? 1 : (safeGPtrArrayHandle.Length - 1));
		Type[] array = new Type[num];
		if (returnType)
		{
			RuntimeTypeHandle handle = new RuntimeTypeHandle(safeGPtrArrayHandle[0]);
			array[0] = (RuntimeType)Type.GetTypeFromHandle(handle);
		}
		else
		{
			for (int i = 1; i < num + 1; i++)
			{
				RuntimeTypeHandle handle2 = new RuntimeTypeHandle(safeGPtrArrayHandle[i]);
				array[i - 1] = (RuntimeType)Type.GetTypeFromHandle(handle2);
			}
		}
		return array;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern Type[] GetFunctionPointerTypeModifiers(QCallTypeHandle type, int position, bool optional);

	internal static Type[] GetFunctionPointerTypeModifiers(RuntimeType type, int position, bool optional)
	{
		return GetFunctionPointerTypeModifiers(new QCallTypeHandle(ref type), position, optional) ?? Type.EmptyTypes;
	}

	public Type[] GetCustomModifiersFromFunctionPointer(int position, bool optional)
	{
		return GetFunctionPointerTypeModifiers(this, position, optional);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern byte GetCallingConventionFromFunctionPointerInternal(QCallTypeHandle type);

	internal static byte GetCallingConventionFromFunctionPointerInternal(RuntimeType type)
	{
		return GetCallingConventionFromFunctionPointerInternal(new QCallTypeHandle(ref type));
	}

	public SignatureCallingConvention GetCallingConventionFromFunctionPointer()
	{
		return (SignatureCallingConvention)GetCallingConventionFromFunctionPointerInternal(this);
	}

	public override Type[] GetFunctionPointerCallingConventions()
	{
		if (!RuntimeTypeHandle.IsFunctionPointer(this))
		{
			throw new InvalidOperationException("InvalidOperation_NotFunctionPointer");
		}
		return Type.EmptyTypes;
	}

	public override bool IsSubclassOf(Type type)
	{
		ArgumentNullException.ThrowIfNull(type, "type");
		RuntimeType runtimeType = type as RuntimeType;
		if (runtimeType == null)
		{
			return false;
		}
		return RuntimeTypeHandle.IsSubclassOf(this, runtimeType);
	}

	internal StructLayoutAttribute GetStructLayoutAttribute()
	{
		if (base.IsInterface || base.HasElementType || IsGenericParameter)
		{
			return null;
		}
		LayoutKind layoutKind = LayoutKind.Auto;
		switch (base.Attributes & TypeAttributes.LayoutMask)
		{
		case TypeAttributes.ExplicitLayout:
			layoutKind = LayoutKind.Explicit;
			break;
		case TypeAttributes.NotPublic:
			layoutKind = LayoutKind.Auto;
			break;
		case TypeAttributes.SequentialLayout:
			layoutKind = LayoutKind.Sequential;
			break;
		}
		CharSet charSet = CharSet.None;
		switch (base.Attributes & TypeAttributes.StringFormatMask)
		{
		case TypeAttributes.NotPublic:
			charSet = CharSet.Ansi;
			break;
		case TypeAttributes.AutoClass:
			charSet = CharSet.Auto;
			break;
		case TypeAttributes.UnicodeClass:
			charSet = CharSet.Unicode;
			break;
		}
		GetPacking(out var packing, out var size);
		return new StructLayoutAttribute(layoutKind)
		{
			Pack = packing,
			Size = size,
			CharSet = charSet
		};
	}

	public object Clone()
	{
		return this;
	}

	public override bool Equals(object obj)
	{
		return obj == this;
	}

	public override int GetArrayRank()
	{
		if (!IsArrayImpl())
		{
			throw new ArgumentException("Argument_HasToBeArrayClass");
		}
		return RuntimeTypeHandle.GetArrayRank(this);
	}

	protected override TypeAttributes GetAttributeFlagsImpl()
	{
		return RuntimeTypeHandle.GetAttributes(this);
	}

	public override object[] GetCustomAttributes(bool inherit)
	{
		return CustomAttribute.GetCustomAttributes(this, ObjectType, inherit);
	}

	public override object[] GetCustomAttributes(Type attributeType, bool inherit)
	{
		ArgumentNullException.ThrowIfNull(attributeType, "attributeType");
		if (!(attributeType.UnderlyingSystemType is RuntimeType attributeType2))
		{
			throw new ArgumentException("Arg_MustBeType", "attributeType");
		}
		return CustomAttribute.GetCustomAttributes(this, attributeType2, inherit);
	}

	public override IList<CustomAttributeData> GetCustomAttributesData()
	{
		return RuntimeCustomAttributeData.GetCustomAttributesInternal(this);
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.PublicNestedTypes | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.PublicEvents)]
	public override MemberInfo[] GetDefaultMembers()
	{
		MemberInfo[] array = null;
		string defaultMemberName = GetDefaultMemberName();
		if (defaultMemberName != null)
		{
			array = GetMember(defaultMemberName);
		}
		return array ?? Array.Empty<MemberInfo>();
	}

	private static bool IsFullNameRoundtripCompatible(RuntimeType runtimeType)
	{
		Type rootElementType = runtimeType.GetRootElementType();
		if (!rootElementType.IsGenericTypeDefinition && rootElementType.ContainsGenericParameters)
		{
			return false;
		}
		if (rootElementType.IsFunctionPointer)
		{
			return false;
		}
		return true;
	}

	public override Type GetElementType()
	{
		return RuntimeTypeHandle.GetElementType(this);
	}

	public override string GetEnumName(object value)
	{
		ArgumentNullException.ThrowIfNull(value, "value");
		RuntimeType runtimeType = (RuntimeType)value.GetType();
		if (!runtimeType.IsActualEnum && !Type.IsIntegerType(runtimeType))
		{
			throw new ArgumentException("Arg_MustBeEnumBaseTypeOrEnum", "value");
		}
		return Enum.GetName(this, Enum.ToUInt64(value));
	}

	private static void ThrowMustBeEnum()
	{
		throw new ArgumentException("Arg_MustBeEnum", "enumType");
	}

	public override string[] GetEnumNames()
	{
		if (!IsActualEnum)
		{
			ThrowMustBeEnum();
		}
		return new ReadOnlySpan<string>(Enum.GetNamesNoCopy(this)).ToArray();
	}

	[RequiresDynamicCode("It might not be possible to create an array of the enum type at runtime. Use Enum.GetValues<T> or the GetEnumValuesAsUnderlyingType method instead.")]
	public override Array GetEnumValues()
	{
		if (!IsActualEnum)
		{
			ThrowMustBeEnum();
		}
		Array valuesAsUnderlyingTypeNoCopy = Enum.GetValuesAsUnderlyingTypeNoCopy(this);
		Array array = Array.CreateInstance(this, valuesAsUnderlyingTypeNoCopy.Length);
		Array.Copy(valuesAsUnderlyingTypeNoCopy, array, valuesAsUnderlyingTypeNoCopy.Length);
		return array;
	}

	public override Array GetEnumValuesAsUnderlyingType()
	{
		if (!IsActualEnum)
		{
			ThrowMustBeEnum();
		}
		return Enum.GetValuesAsUnderlyingType(this);
	}

	public override Type GetEnumUnderlyingType()
	{
		if (!IsActualEnum)
		{
			ThrowMustBeEnum();
		}
		return Enum.InternalGetUnderlyingType(this);
	}

	public override int GetHashCode()
	{
		return RuntimeHelpers.GetHashCode(this);
	}

	internal RuntimeModule GetRuntimeModule()
	{
		return RuntimeTypeHandle.GetModule(this);
	}

	protected override TypeCode GetTypeCodeImpl()
	{
		TypeCode typeCode = Cache.TypeCode;
		if (typeCode != TypeCode.Empty)
		{
			return typeCode;
		}
		typeCode = Type.GetRuntimeTypeCode(this);
		Cache.TypeCode = typeCode;
		return typeCode;
	}

	protected override bool HasElementTypeImpl()
	{
		return RuntimeTypeHandle.HasElementType(this);
	}

	protected override bool IsArrayImpl()
	{
		return RuntimeTypeHandle.IsArray(this);
	}

	protected override bool IsContextfulImpl()
	{
		return false;
	}

	public override bool IsDefined(Type attributeType, bool inherit)
	{
		ArgumentNullException.ThrowIfNull(attributeType, "attributeType");
		if (!(attributeType.UnderlyingSystemType is RuntimeType attributeType2))
		{
			throw new ArgumentException("Arg_MustBeType", "attributeType");
		}
		return CustomAttribute.IsDefined(this, attributeType2, inherit);
	}

	public override bool IsEnumDefined(object value)
	{
		ArgumentNullException.ThrowIfNull(value, "value");
		if (!IsActualEnum)
		{
			ThrowMustBeEnum();
		}
		RuntimeType runtimeType = (RuntimeType)value.GetType();
		if (runtimeType.IsActualEnum)
		{
			if (!runtimeType.IsEquivalentTo(this))
			{
				throw new ArgumentException(SR.Format("Arg_EnumAndObjectMustBeSameType", runtimeType, this));
			}
			runtimeType = (RuntimeType)runtimeType.GetEnumUnderlyingType();
		}
		if (runtimeType == StringType)
		{
			return Array.IndexOf(Enum.GetNamesNoCopy(this), (string)value) >= 0;
		}
		if (!Type.IsIntegerType(runtimeType))
		{
			throw new InvalidOperationException("InvalidOperation_UnknownEnumType");
		}
		RuntimeType runtimeType2 = Enum.InternalGetUnderlyingType(this);
		if (runtimeType2 != runtimeType)
		{
			throw new ArgumentException(SR.Format("Arg_EnumUnderlyingTypeAndObjectMustBeSameType", runtimeType, runtimeType2));
		}
		switch (Type.GetTypeCode(runtimeType2))
		{
		case TypeCode.SByte:
			return Enum.IsDefinedPrimitive(this, (byte)(sbyte)value);
		case TypeCode.Byte:
			return Enum.IsDefinedPrimitive(this, (byte)value);
		case TypeCode.Int16:
			return Enum.IsDefinedPrimitive(this, (ushort)(short)value);
		case TypeCode.UInt16:
			return Enum.IsDefinedPrimitive(this, (ushort)value);
		case TypeCode.Int32:
			return Enum.IsDefinedPrimitive(this, (uint)(int)value);
		case TypeCode.UInt32:
			return Enum.IsDefinedPrimitive(this, (uint)value);
		case TypeCode.Int64:
			return Enum.IsDefinedPrimitive(this, (ulong)(long)value);
		case TypeCode.UInt64:
			return Enum.IsDefinedPrimitive(this, (ulong)value);
		case TypeCode.Single:
			return Enum.IsDefinedPrimitive(this, (float)value);
		case TypeCode.Double:
			return Enum.IsDefinedPrimitive(this, (double)value);
		case TypeCode.Char:
			return Enum.IsDefinedPrimitive(this, (char)value);
		default:
		{
			bool result;
			if (!(runtimeType2 == typeof(nint)))
			{
				if (!(runtimeType2 == typeof(nuint)))
				{
					throw new InvalidOperationException("InvalidOperation_UnknownEnumType");
				}
				result = Enum.IsDefinedPrimitive<nuint>(this, (nuint)value);
			}
			else
			{
				result = Enum.IsDefinedPrimitive<nuint>(this, (nuint)(nint)value);
			}
			return result;
		}
		}
	}

	protected override bool IsByRefImpl()
	{
		return RuntimeTypeHandle.IsByRef(this);
	}

	protected override bool IsPrimitiveImpl()
	{
		return RuntimeTypeHandle.IsPrimitive(this);
	}

	protected override bool IsPointerImpl()
	{
		return RuntimeTypeHandle.IsPointer(this);
	}

	public override bool IsAssignableFrom([NotNullWhen(true)] TypeInfo typeInfo)
	{
		if (typeInfo != null)
		{
			return IsAssignableFrom(typeInfo.AsType());
		}
		return false;
	}

	public override bool IsAssignableFrom([NotNullWhen(true)] Type c)
	{
		if ((object)c == null)
		{
			return false;
		}
		if ((object)c == this)
		{
			return true;
		}
		if (c.UnderlyingSystemType is RuntimeType type)
		{
			return RuntimeTypeHandle.CanCastTo(type, this);
		}
		if (c is TypeBuilder)
		{
			if (c.IsSubclassOf(this))
			{
				return true;
			}
			if (IsActualInterface)
			{
				return c.ImplementInterface(this);
			}
			if (IsGenericParameter)
			{
				Type[] genericParameterConstraints = GetGenericParameterConstraints();
				for (int i = 0; i < genericParameterConstraints.Length; i++)
				{
					if (!genericParameterConstraints[i].IsAssignableFrom(c))
					{
						return false;
					}
				}
				return true;
			}
		}
		return false;
	}

	[DebuggerStepThrough]
	[DebuggerHidden]
	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)]
	public override object InvokeMember(string name, BindingFlags bindingFlags, Binder binder, object target, object[] providedArgs, ParameterModifier[] modifiers, CultureInfo culture, string[] namedParams)
	{
		if (IsGenericParameter)
		{
			throw new InvalidOperationException("Arg_GenericParameter");
		}
		if ((bindingFlags & (BindingFlags.InvokeMethod | BindingFlags.CreateInstance | BindingFlags.GetField | BindingFlags.SetField | BindingFlags.GetProperty | BindingFlags.SetProperty | BindingFlags.PutDispProperty | BindingFlags.PutRefDispProperty)) == 0)
		{
			throw new ArgumentException("Arg_NoAccessSpec", "bindingFlags");
		}
		if ((bindingFlags & (BindingFlags)255) == 0)
		{
			bindingFlags |= BindingFlags.Instance | BindingFlags.Public;
			if ((bindingFlags & BindingFlags.CreateInstance) == 0)
			{
				bindingFlags |= BindingFlags.Static;
			}
		}
		if (namedParams != null)
		{
			if (providedArgs != null)
			{
				if (namedParams.Length > providedArgs.Length)
				{
					throw new ArgumentException("Arg_NamedParamTooBig", "namedParams");
				}
			}
			else if (namedParams.Length != 0)
			{
				throw new ArgumentException("Arg_NamedParamTooBig", "namedParams");
			}
		}
		if (namedParams != null && Array.IndexOf(namedParams, null) >= 0)
		{
			throw new ArgumentException("Arg_NamedParamNull", "namedParams");
		}
		int num = ((providedArgs != null) ? providedArgs.Length : 0);
		if (binder == null)
		{
			binder = Type.DefaultBinder;
		}
		if ((bindingFlags & BindingFlags.CreateInstance) != BindingFlags.Default)
		{
			if ((bindingFlags & BindingFlags.CreateInstance) != BindingFlags.Default && (bindingFlags & (BindingFlags.InvokeMethod | BindingFlags.GetField | BindingFlags.SetField | BindingFlags.GetProperty | BindingFlags.SetProperty)) != BindingFlags.Default)
			{
				throw new ArgumentException("Arg_CreatInstAccess", "bindingFlags");
			}
			return Activator.CreateInstance(this, bindingFlags, binder, providedArgs, culture);
		}
		if ((bindingFlags & (BindingFlags.PutDispProperty | BindingFlags.PutRefDispProperty)) != BindingFlags.Default)
		{
			bindingFlags |= BindingFlags.SetProperty;
		}
		ArgumentNullException.ThrowIfNull(name, "name");
		if (name.Length == 0 || name.Equals("[DISPID=0]"))
		{
			name = GetDefaultMemberName() ?? "ToString";
		}
		bool flag = (bindingFlags & BindingFlags.GetField) != 0;
		bool flag2 = (bindingFlags & BindingFlags.SetField) != 0;
		if (flag || flag2)
		{
			if (flag)
			{
				if (flag2)
				{
					throw new ArgumentException("Arg_FldSetGet", "bindingFlags");
				}
				if ((bindingFlags & BindingFlags.SetProperty) != BindingFlags.Default)
				{
					throw new ArgumentException("Arg_FldGetPropSet", "bindingFlags");
				}
			}
			else
			{
				ArgumentNullException.ThrowIfNull(providedArgs, "providedArgs");
				if ((bindingFlags & BindingFlags.GetProperty) != BindingFlags.Default)
				{
					throw new ArgumentException("Arg_FldSetPropGet", "bindingFlags");
				}
				if ((bindingFlags & BindingFlags.InvokeMethod) != BindingFlags.Default)
				{
					throw new ArgumentException("Arg_FldSetInvoke", "bindingFlags");
				}
			}
			FieldInfo fieldInfo = null;
			FieldInfo[] array = GetFields(this, name, bindingFlags);
			if (array.Length == 1)
			{
				fieldInfo = array[0];
			}
			else if (array.Length != 0)
			{
				fieldInfo = binder.BindToField(bindingFlags, array, flag ? Empty.Value : providedArgs[0], culture);
			}
			if (fieldInfo != null)
			{
				if (fieldInfo.FieldType.IsArray || (object)fieldInfo.FieldType == typeof(Array))
				{
					int num2 = (((bindingFlags & BindingFlags.GetField) == 0) ? (num - 1) : num);
					if (num2 > 0)
					{
						int[] array2 = new int[num2];
						for (int i = 0; i < num2; i++)
						{
							try
							{
								array2[i] = ((IConvertible)providedArgs[i]).ToInt32(null);
							}
							catch (InvalidCastException)
							{
								throw new ArgumentException("Arg_IndexMustBeInt");
							}
						}
						Array array3 = (Array)fieldInfo.GetValue(target);
						if ((bindingFlags & BindingFlags.GetField) != BindingFlags.Default)
						{
							return array3.GetValue(array2);
						}
						array3.SetValue(providedArgs[num2], array2);
						return null;
					}
				}
				if (flag)
				{
					if (num != 0)
					{
						throw new ArgumentException("Arg_FldGetArgErr", "bindingFlags");
					}
					return fieldInfo.GetValue(target);
				}
				if (num != 1)
				{
					throw new ArgumentException("Arg_FldSetArgErr", "bindingFlags");
				}
				fieldInfo.SetValue(target, providedArgs[0], bindingFlags, binder, culture);
				return null;
			}
			if ((bindingFlags & (BindingFlags)16773888) == 0)
			{
				throw new MissingFieldException(FullName, name);
			}
		}
		bool flag3 = (bindingFlags & BindingFlags.GetProperty) != 0;
		bool flag4 = (bindingFlags & BindingFlags.SetProperty) != 0;
		if (flag3 || flag4)
		{
			if (flag3)
			{
				if (flag4)
				{
					throw new ArgumentException("Arg_PropSetGet", "bindingFlags");
				}
			}
			else if ((bindingFlags & BindingFlags.InvokeMethod) != BindingFlags.Default)
			{
				throw new ArgumentException("Arg_PropSetInvoke", "bindingFlags");
			}
		}
		MethodInfo[] array4 = null;
		MethodInfo methodInfo = null;
		if ((bindingFlags & BindingFlags.InvokeMethod) != BindingFlags.Default)
		{
			MethodInfo[] array5 = GetMethods(this, name, bindingFlags);
			List<MethodInfo> list = null;
			foreach (MethodInfo methodInfo2 in array5)
			{
				if (!FilterApplyMethodInfo((RuntimeMethodInfo)methodInfo2, bindingFlags, CallingConventions.Any, new Type[num]))
				{
					continue;
				}
				if (methodInfo == null)
				{
					methodInfo = methodInfo2;
					continue;
				}
				if (list == null)
				{
					list = new List<MethodInfo>(array5.Length) { methodInfo };
				}
				list.Add(methodInfo2);
			}
			if (list != null)
			{
				array4 = list.ToArray();
			}
		}
		if ((methodInfo == null && flag3) || flag4)
		{
			PropertyInfo[] array6 = GetProperties(this, name, bindingFlags);
			List<MethodInfo> list2 = null;
			for (int k = 0; k < array6.Length; k++)
			{
				MethodInfo methodInfo3 = null;
				methodInfo3 = ((!flag4) ? array6[k].GetGetMethod(nonPublic: true) : array6[k].GetSetMethod(nonPublic: true));
				if (methodInfo3 == null || !FilterApplyMethodInfo((RuntimeMethodInfo)methodInfo3, bindingFlags, CallingConventions.Any, new Type[num]))
				{
					continue;
				}
				if (methodInfo == null)
				{
					methodInfo = methodInfo3;
					continue;
				}
				if (list2 == null)
				{
					list2 = new List<MethodInfo>(array6.Length) { methodInfo };
				}
				list2.Add(methodInfo3);
			}
			if (list2 != null)
			{
				array4 = list2.ToArray();
			}
		}
		if (methodInfo != null)
		{
			if (array4 == null && num == 0 && methodInfo.GetParametersAsSpan().Length == 0 && (bindingFlags & BindingFlags.OptionalParamBinding) == 0)
			{
				return methodInfo.Invoke(target, bindingFlags, binder, providedArgs, culture);
			}
			if (array4 == null)
			{
				array4 = new MethodInfo[1] { methodInfo };
			}
			if (providedArgs == null)
			{
				providedArgs = Array.Empty<object>();
			}
			object state = null;
			MethodBase methodBase = null;
			try
			{
				Binder binder2 = binder;
				BindingFlags bindingAttr = bindingFlags;
				MethodBase[] match = array4;
				methodBase = binder2.BindToMethod(bindingAttr, match, ref providedArgs, modifiers, culture, namedParams, out state);
			}
			catch (MissingMethodException)
			{
			}
			if (methodBase == null)
			{
				throw new MissingMethodException(FullName, name);
			}
			object? result = ((MethodInfo)methodBase).Invoke(target, bindingFlags, binder, providedArgs, culture);
			if (state != null)
			{
				binder.ReorderArgumentArray(ref providedArgs, state);
			}
			return result;
		}
		throw new MissingMethodException(FullName, name);
		[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2070", Justification = "MemberTypes.Field is satisfied by (InvokeMemberMembers) on this method")]
		static FieldInfo[] GetFields(RuntimeType thisType, string name2, BindingFlags bindingAttr2)
		{
			return thisType.GetMember(name2, MemberTypes.Field, bindingAttr2) as FieldInfo[];
		}
		[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2070", Justification = "MemberTypes.Method is satisfied by (InvokeMemberMembers) on this method")]
		static MethodInfo[] GetMethods(RuntimeType thisType, string name2, BindingFlags bindingAttr2)
		{
			return thisType.GetMember(name2, MemberTypes.Method, bindingAttr2) as MethodInfo[];
		}
		[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2070", Justification = "MemberTypes.Property is satisfied by (InvokeMemberMembers) on this method")]
		static PropertyInfo[] GetProperties(RuntimeType thisType, string name2, BindingFlags bindingAttr2)
		{
			return thisType.GetMember(name2, MemberTypes.Property, bindingAttr2) as PropertyInfo[];
		}
	}

	private RuntimeType GetBaseType()
	{
		if (IsActualInterface)
		{
			return null;
		}
		if (RuntimeTypeHandle.IsGenericVariable(this))
		{
			Type[] genericParameterConstraints = GetGenericParameterConstraints();
			RuntimeType runtimeType = ObjectType;
			for (int i = 0; i < genericParameterConstraints.Length; i++)
			{
				RuntimeType runtimeType2 = (RuntimeType)genericParameterConstraints[i];
				if (runtimeType2.IsActualInterface)
				{
					continue;
				}
				if (runtimeType2.IsGenericParameter)
				{
					GenericParameterAttributes genericParameterAttributes = runtimeType2.GenericParameterAttributes;
					if ((genericParameterAttributes & GenericParameterAttributes.ReferenceTypeConstraint) == 0 && (genericParameterAttributes & GenericParameterAttributes.NotNullableValueTypeConstraint) == 0)
					{
						continue;
					}
				}
				runtimeType = runtimeType2;
			}
			if (runtimeType == ObjectType && (GenericParameterAttributes & GenericParameterAttributes.NotNullableValueTypeConstraint) != GenericParameterAttributes.None)
			{
				runtimeType = ValueType;
			}
			return runtimeType;
		}
		return GetParentType();
	}

	private static void ThrowIfTypeNeverValidGenericArgument(RuntimeType type)
	{
		if (type.IsPointer || type.IsFunctionPointer || type.IsByRef || type == typeof(void))
		{
			throw new ArgumentException(SR.Format("Argument_NeverValidGenericArgument", type));
		}
	}

	internal static void SanityCheckGenericArguments(RuntimeType[] genericArguments, RuntimeType[] genericParameters)
	{
		ArgumentNullException.ThrowIfNull(genericArguments, "genericArguments");
		for (int i = 0; i < genericArguments.Length; i++)
		{
			ArgumentNullException.ThrowIfNull(genericArguments[i]);
			ThrowIfTypeNeverValidGenericArgument(genericArguments[i]);
		}
		if (genericArguments.Length != genericParameters.Length)
		{
			throw new ArgumentException(SR.Format("Argument_NotEnoughGenArguments", genericArguments.Length, genericParameters.Length));
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static bool TryGetByRefElementType(RuntimeType type, [NotNullWhen(true)] out RuntimeType elementType)
	{
		if (type.GetCorElementType() == CorElementType.ELEMENT_TYPE_BYREF)
		{
			elementType = RuntimeTypeHandle.GetElementType(type);
			return true;
		}
		elementType = null;
		return false;
	}

	internal bool CheckValue(ref object value)
	{
		if (IsInstanceOfType(value))
		{
			if (IsNullableOfT)
			{
				value = RuntimeMethodHandle.ReboxToNullable(value, this);
				return true;
			}
			return false;
		}
		bool copyBack = false;
		return TryChangeType(ref value, ref copyBack) switch
		{
			CheckValueStatus.Success => copyBack, 
			CheckValueStatus.ArgumentException => throw new ArgumentException(SR.Format("Arg_ObjObjEx", value?.GetType(), this)), 
			CheckValueStatus.NotSupported_ByRefLike => throw new NotSupportedException("NotSupported_ByRefLike"), 
			_ => false, 
		};
	}

	internal bool CheckValue(ref object value, Binder binder, CultureInfo culture, BindingFlags invokeAttr)
	{
		if (IsInstanceOfType(value))
		{
			if (IsNullableOfT)
			{
				value = RuntimeMethodHandle.ReboxToNullable(value, this);
				return true;
			}
			return false;
		}
		bool copyBack = false;
		CheckValueStatus checkValueStatus = TryChangeType(ref value, ref copyBack);
		switch (checkValueStatus)
		{
		case CheckValueStatus.Success:
			return copyBack;
		case CheckValueStatus.ArgumentException:
			if ((invokeAttr & BindingFlags.ExactBinding) != BindingFlags.Default || binder == null || binder == Type.DefaultBinder)
			{
				break;
			}
			value = binder.ChangeType(value, this, culture);
			if (IsInstanceOfType(value))
			{
				if (IsNullableOfT)
				{
					value = RuntimeMethodHandle.ReboxToNullable(value, this);
				}
				return true;
			}
			checkValueStatus = TryChangeType(ref value, ref copyBack);
			if (checkValueStatus == CheckValueStatus.Success)
			{
				return copyBack;
			}
			break;
		}
		return checkValueStatus switch
		{
			CheckValueStatus.ArgumentException => throw new ArgumentException(SR.Format("Arg_ObjObjEx", value?.GetType(), this)), 
			CheckValueStatus.NotSupported_ByRefLike => throw new NotSupportedException("NotSupported_ByRefLike"), 
			_ => false, 
		};
	}

	[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2067:UnrecognizedReflectionPattern", Justification = "AllocateValueType is only called on a ValueType. You can always create an instance of a ValueType.")]
	[return: NotNullIfNotNull("value")]
	internal static object AllocateValueType(RuntimeType type, object value)
	{
		if (value != null)
		{
			return RuntimeHelpers.Box(ref value.GetRawData(), type.TypeHandle);
		}
		if (type.IsNullableOfT)
		{
			return RuntimeMethodHandle.ReboxToNullable(null, type);
		}
		return RuntimeHelpers.GetUninitializedObject(type);
	}

	private CheckValueStatus TryChangeType(ref object value, ref bool copyBack)
	{
		if (TryGetByRefElementType(this, out var elementType))
		{
			copyBack = true;
			if (elementType.IsInstanceOfType(value))
			{
				if (elementType.IsActualValueType)
				{
					if (elementType.IsNullableOfT)
					{
						value = RuntimeMethodHandle.ReboxToNullable(value, elementType);
					}
					else
					{
						value = AllocateValueType(elementType, value);
					}
				}
				return CheckValueStatus.Success;
			}
			if (value == null)
			{
				if (!elementType.IsActualValueType)
				{
					return CheckValueStatus.Success;
				}
				if (elementType.IsByRefLike)
				{
					return CheckValueStatus.NotSupported_ByRefLike;
				}
				value = AllocateValueType(elementType, null);
				return CheckValueStatus.Success;
			}
			return CheckValueStatus.ArgumentException;
		}
		if (value == null)
		{
			if (base.IsPointer || IsFunctionPointer)
			{
				value = (nint)0;
				return CheckValueStatus.Success;
			}
			if (!IsActualValueType)
			{
				return CheckValueStatus.Success;
			}
			if (IsByRefLike)
			{
				return CheckValueStatus.NotSupported_ByRefLike;
			}
			value = AllocateValueType(this, null);
			return CheckValueStatus.Success;
		}
		if (base.IsPointer || IsEnum || base.IsPrimitive || IsFunctionPointer)
		{
			return TryChangeTypeSpecial(ref value);
		}
		return CheckValueStatus.ArgumentException;
	}
}
