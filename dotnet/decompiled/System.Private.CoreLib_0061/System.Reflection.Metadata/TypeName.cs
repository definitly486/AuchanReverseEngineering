using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Text;

namespace System.Reflection.Metadata;

[DebuggerDisplay("{AssemblyQualifiedName}")]
internal sealed class TypeName
{
	private readonly int _rankOrModifier;

	private readonly int _nestedNameLength;

	private readonly TypeName _elementOrGenericType;

	private readonly TypeName _declaringType;

	private readonly List<TypeName> _genericArguments;

	private string _name;

	private string _fullName;

	private string _assemblyQualifiedName;

	public string AssemblyQualifiedName
	{
		get
		{
			if (_assemblyQualifiedName == null)
			{
				if (_fullName != null && AssemblyName == null)
				{
					_assemblyQualifiedName = FullName;
				}
				else
				{
					Span<char> initialBuffer = stackalloc char[256];
					ValueStringBuilder builder = new ValueStringBuilder(initialBuffer);
					AppendFullName(ref builder);
					if (AssemblyName != null)
					{
						builder.Append(", ");
						AssemblyName.AppendFullName(ref builder);
					}
					_assemblyQualifiedName = builder.ToString();
					if (AssemblyName == null)
					{
						_fullName = _assemblyQualifiedName;
					}
				}
			}
			return _assemblyQualifiedName;
		}
	}

	public AssemblyNameInfo AssemblyName { get; }

	public TypeName DeclaringType
	{
		get
		{
			if (_declaringType == null)
			{
				TypeNameParserHelpers.ThrowInvalidOperation_NotNestedType();
			}
			return _declaringType;
		}
	}

	public string FullName
	{
		get
		{
			if (_fullName == null)
			{
				Span<char> initialBuffer = stackalloc char[128];
				ValueStringBuilder builder = new ValueStringBuilder(initialBuffer);
				AppendFullName(ref builder);
				_fullName = builder.ToString();
			}
			else if (_nestedNameLength > 0 && _fullName.Length > _nestedNameLength)
			{
				_fullName = _fullName.Substring(0, _nestedNameLength);
			}
			return _fullName;
		}
	}

	public bool IsArray
	{
		get
		{
			if (_rankOrModifier != -1)
			{
				return _rankOrModifier > 0;
			}
			return true;
		}
	}

	public bool IsConstructedGenericType => _genericArguments != null;

	[MemberNotNullWhen(false, "_elementOrGenericType")]
	public bool IsSimple
	{
		[MemberNotNullWhen(false, "_elementOrGenericType")]
		get
		{
			return _elementOrGenericType == null;
		}
	}

	public bool IsByRef => _rankOrModifier == -3;

	[MemberNotNullWhen(true, "_declaringType")]
	public bool IsNested
	{
		[MemberNotNullWhen(true, "_declaringType")]
		get
		{
			return _declaringType != null;
		}
	}

	public bool IsSZArray => _rankOrModifier == -1;

	public bool IsPointer => _rankOrModifier == -2;

	public string Name
	{
		get
		{
			if (_name == null)
			{
				Span<char> initialBuffer = stackalloc char[64];
				ValueStringBuilder builder = new ValueStringBuilder(initialBuffer);
				AppendName(ref builder);
				_name = builder.ToString();
			}
			return _name;
		}
	}

	internal TypeName(string fullName, AssemblyNameInfo assemblyName, TypeName elementOrGenericType = null, TypeName declaringType = null, List<TypeName> genericTypeArguments = null, int rankOrModifier = 0, int nestedNameLength = -1)
	{
		_fullName = fullName;
		AssemblyName = assemblyName;
		_rankOrModifier = rankOrModifier;
		_elementOrGenericType = elementOrGenericType;
		_declaringType = declaringType;
		_nestedNameLength = nestedNameLength;
		_genericArguments = genericTypeArguments;
	}

	private void AppendFullName(ref ValueStringBuilder builder)
	{
		if (_fullName == null)
		{
			if (IsConstructedGenericType)
			{
				GetGenericTypeDefinition().AppendFullName(ref builder);
				builder.Append('[');
				ReadOnlySpan<TypeName> genericArguments = GetGenericArguments();
				for (int i = 0; i < genericArguments.Length; i++)
				{
					TypeName typeName = genericArguments[i];
					builder.Append('[');
					typeName.AppendFullName(ref builder);
					if (typeName.AssemblyName != null)
					{
						builder.Append(", ");
						typeName.AssemblyName.AppendFullName(ref builder);
					}
					builder.Append("],");
				}
				builder[builder.Length - 1] = ']';
			}
			else if (IsArray || IsPointer || IsByRef)
			{
				GetElementType().AppendFullName(ref builder);
				TypeNameParserHelpers.AppendRankOrModifierStringRepresentation(_rankOrModifier, ref builder);
			}
		}
		else if (_nestedNameLength > 0 && _fullName.Length > _nestedNameLength)
		{
			builder.Append(_fullName.AsSpan(0, _nestedNameLength));
		}
		else
		{
			builder.Append(_fullName);
		}
	}

	private void AppendName(ref ValueStringBuilder builder)
	{
		if (IsConstructedGenericType)
		{
			GetGenericTypeDefinition().AppendName(ref builder);
			return;
		}
		if (IsPointer || IsByRef || IsArray)
		{
			GetElementType().AppendName(ref builder);
			TypeNameParserHelpers.AppendRankOrModifierStringRepresentation(_rankOrModifier, ref builder);
			return;
		}
		ReadOnlySpan<char> readOnlySpan = _fullName.AsSpan();
		if (_nestedNameLength > 0)
		{
			readOnlySpan = readOnlySpan.Slice(0, _nestedNameLength);
		}
		if (IsNested)
		{
			readOnlySpan = readOnlySpan.Slice(_declaringType._nestedNameLength + 1);
		}
		else
		{
			int num = TypeNameParserHelpers.IndexOfNamespaceDelimiter(readOnlySpan);
			if (num >= 0)
			{
				readOnlySpan = readOnlySpan.Slice(num + 1);
			}
		}
		builder.Append(readOnlySpan);
	}

	public TypeName GetElementType()
	{
		if (!IsArray && !IsPointer && !IsByRef)
		{
			TypeNameParserHelpers.ThrowInvalidOperation_NoElement();
		}
		return _elementOrGenericType;
	}

	public TypeName GetGenericTypeDefinition()
	{
		if (!IsConstructedGenericType)
		{
			TypeNameParserHelpers.ThrowInvalidOperation_NotGenericType();
		}
		return _elementOrGenericType;
	}

	public static string Unescape(string name)
	{
		if (name == null)
		{
			TypeNameParserHelpers.ThrowArgumentNullException("name");
		}
		return TypeNameParserHelpers.Unescape(name);
	}

	public int GetArrayRank()
	{
		if (_rankOrModifier != -1 && _rankOrModifier <= 0)
		{
			TypeNameParserHelpers.ThrowInvalidOperation_HasToBeArrayClass();
		}
		if (_rankOrModifier != -1)
		{
			return _rankOrModifier;
		}
		return 1;
	}

	public ReadOnlySpan<TypeName> GetGenericArguments()
	{
		return CollectionsMarshal.AsSpan(_genericArguments);
	}
}
