using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Reflection.Metadata;
using System.Threading;

namespace System.Reflection;

internal ref struct TypeNameResolver
{
	private Func<AssemblyName, Assembly> _assemblyResolver;

	private Func<Assembly, string, bool, Type> _typeResolver;

	private bool _throwOnError;

	private bool _ignoreCase;

	private ref StackCrawlMark _stackMark;

	[RequiresUnreferencedCode("The type might be removed")]
	internal static Type GetType(string typeName, Func<AssemblyName, Assembly> assemblyResolver, Func<Assembly, string, bool, Type> typeResolver, bool throwOnError, bool ignoreCase, ref StackCrawlMark stackMark)
	{
		ArgumentNullException.ThrowIfNull(typeName, "typeName");
		if (typeName.Length == 0)
		{
			if (throwOnError)
			{
				throw new TypeLoadException("Arg_TypeLoadNullStr");
			}
			return null;
		}
		TypeName typeName2 = TypeNameParser.Parse(typeName.AsSpan(), throwOnError);
		if (typeName2 == null)
		{
			return null;
		}
		return new TypeNameResolver
		{
			_assemblyResolver = assemblyResolver,
			_typeResolver = typeResolver,
			_throwOnError = throwOnError,
			_ignoreCase = ignoreCase,
			_stackMark = (StackCrawlMark)(ref stackMark)
		}.Resolve(typeName2);
	}

	private Assembly ResolveAssembly(AssemblyName name)
	{
		Assembly assembly;
		if (_assemblyResolver != null)
		{
			assembly = _assemblyResolver(name);
			if ((object)assembly == null && _throwOnError)
			{
				throw new FileNotFoundException(SR.Format("FileNotFound_ResolveAssembly", name.FullName));
			}
		}
		else if (_throwOnError)
		{
			assembly = Assembly.Load(name, ref _stackMark, null);
		}
		else
		{
			try
			{
				assembly = Assembly.Load(name, ref _stackMark, null);
			}
			catch (FileNotFoundException)
			{
				return null;
			}
		}
		return assembly;
	}

	[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2075:UnrecognizedReflectionPattern", Justification = "TypeNameResolver.GetType is marked as RequiresUnreferencedCode.")]
	[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "TypeNameResolver.GetType is marked as RequiresUnreferencedCode.")]
	private Type GetType(string escapedTypeName, ReadOnlySpan<string> nestedTypeNames, TypeName parsedName)
	{
		Assembly assembly = ((parsedName.AssemblyName != null) ? ResolveAssembly(parsedName.AssemblyName.ToAssemblyName()) : null);
		Type type;
		if (_typeResolver != null)
		{
			type = _typeResolver(assembly, escapedTypeName, _ignoreCase);
			if ((object)type == null)
			{
				if (_throwOnError)
				{
					throw new TypeLoadException(((object)assembly == null) ? SR.Format("TypeLoad_ResolveType", escapedTypeName) : SR.Format("TypeLoad_ResolveTypeFromAssembly", escapedTypeName, assembly.FullName), escapedTypeName);
				}
				return null;
			}
		}
		else
		{
			type = (((object)assembly != null) ? assembly.GetType(escapedTypeName, _throwOnError, _ignoreCase) : RuntimeType.GetType(escapedTypeName, _throwOnError, _ignoreCase, ref _stackMark));
			if ((object)type == null)
			{
				return null;
			}
		}
		for (int i = 0; i < nestedTypeNames.Length; i++)
		{
			BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.NonPublic;
			if (_ignoreCase)
			{
				bindingFlags |= BindingFlags.IgnoreCase;
			}
			type = type.GetNestedType(nestedTypeNames[i], bindingFlags);
			if ((object)type == null)
			{
				if (_throwOnError)
				{
					throw new TypeLoadException(SR.Format("TypeLoad_ResolveNestedType", nestedTypeNames[i], (i > 0) ? nestedTypeNames[i - 1] : TypeName.Unescape(escapedTypeName)), escapedTypeName);
				}
				return null;
			}
		}
		return type;
	}

	[UnconditionalSuppressMessage("ReflectionAnalysis", "IL3050:RequiresDynamicCode", Justification = "Used to implement resolving types from strings.")]
	private Type Resolve(TypeName typeName)
	{
		if (typeName.IsSimple)
		{
			return GetSimpleType(typeName);
		}
		if (typeName.IsConstructedGenericType)
		{
			return GetGenericType(typeName);
		}
		if (typeName.IsArray || typeName.IsPointer || typeName.IsByRef)
		{
			Type type = Resolve(typeName.GetElementType());
			if ((object)type == null)
			{
				return null;
			}
			if (typeName.IsArray)
			{
				if (!typeName.IsSZArray)
				{
					return type.MakeArrayType(typeName.GetArrayRank());
				}
				return type.MakeArrayType();
			}
			if (typeName.IsByRef)
			{
				return type.MakeByRefType();
			}
			if (typeName.IsPointer)
			{
				return type.MakePointerType();
			}
		}
		return null;
	}

	private Type GetSimpleType(TypeName typeName)
	{
		if (typeName.IsNested)
		{
			TypeName typeName2 = typeName;
			int num = 0;
			do
			{
				num++;
				typeName2 = typeName2.DeclaringType;
			}
			while (typeName2.IsNested);
			string[] array = new string[num];
			typeName2 = typeName;
			while (typeName2.IsNested)
			{
				array[--num] = TypeName.Unescape(typeName2.Name);
				typeName2 = typeName2.DeclaringType;
			}
			return GetType(typeName2.FullName, array, typeName);
		}
		return GetType(typeName.FullName, default(ReadOnlySpan<string>), typeName);
	}

	[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2055:UnrecognizedReflectionPattern", Justification = "Used to implement resolving types from strings.")]
	[UnconditionalSuppressMessage("ReflectionAnalysis", "IL3050:RequiresDynamicCode", Justification = "Used to implement resolving types from strings.")]
	private Type GetGenericType(TypeName typeName)
	{
		Type type = Resolve(typeName.GetGenericTypeDefinition());
		if ((object)type == null)
		{
			return null;
		}
		ReadOnlySpan<TypeName> genericArguments = typeName.GetGenericArguments();
		Type[] array = new Type[genericArguments.Length];
		for (int i = 0; i < genericArguments.Length; i++)
		{
			Type type2 = Resolve(genericArguments[i]);
			if ((object)type2 == null)
			{
				return null;
			}
			array[i] = type2;
		}
		return type.MakeGenericType(array);
	}
}
