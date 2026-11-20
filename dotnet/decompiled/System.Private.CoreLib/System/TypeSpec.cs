using System.Collections.Generic;
using System.Text;

namespace System;

internal sealed class TypeSpec
{
	[Flags]
	internal enum DisplayNameFormat
	{
		Default = 0,
		WANT_ASSEMBLY = 1,
		NO_MODIFIERS = 2
	}

	private sealed class TypeSpecTypeName : TypeNames.ATypeName, ITypeName, IEquatable<ITypeName>
	{
		private readonly TypeSpec ts;

		private readonly bool want_modifiers;

		public override string DisplayName
		{
			get
			{
				if (want_modifiers)
				{
					return ts.DisplayFullName;
				}
				return ts.GetDisplayFullName(DisplayNameFormat.NO_MODIFIERS);
			}
		}

		internal TypeSpecTypeName(TypeSpec ts, bool wantModifiers)
		{
			this.ts = ts;
			want_modifiers = wantModifiers;
		}

		public override ITypeName NestedName(ITypeIdentifier innerName)
		{
			return TypeNames.FromDisplay(DisplayName + "+" + innerName.DisplayName);
		}
	}

	private ITypeIdentifier name;

	private string assembly_name;

	private List<ITypeIdentifier> nested;

	private List<TypeSpec> generic_params;

	private List<IModifierSpec> modifier_spec;

	private bool is_byref;

	private string display_fullname;

	internal bool HasModifiers => modifier_spec != null;

	internal bool IsNested
	{
		get
		{
			if (nested != null)
			{
				return nested.Count > 0;
			}
			return false;
		}
	}

	internal bool IsByRef => is_byref;

	internal ITypeName Name => name;

	internal IEnumerable<ITypeName> Nested
	{
		get
		{
			if (nested != null)
			{
				return nested;
			}
			return Array.Empty<ITypeName>();
		}
	}

	internal IEnumerable<IModifierSpec> Modifiers
	{
		get
		{
			if (modifier_spec != null)
			{
				return modifier_spec;
			}
			return Array.Empty<IModifierSpec>();
		}
	}

	internal string DisplayFullName => display_fullname ?? (display_fullname = GetDisplayFullName(DisplayNameFormat.Default));

	internal ITypeName TypeName => new TypeSpecTypeName(this, wantModifiers: true);

	private string GetDisplayFullName(DisplayNameFormat flags)
	{
		bool flag = (flags & DisplayNameFormat.WANT_ASSEMBLY) != 0;
		bool flag2 = (flags & DisplayNameFormat.NO_MODIFIERS) == 0;
		StringBuilder stringBuilder = new StringBuilder(name.DisplayName);
		if (nested != null)
		{
			foreach (ITypeIdentifier item in nested)
			{
				stringBuilder.Append('+').Append(item.DisplayName);
			}
		}
		if (generic_params != null)
		{
			stringBuilder.Append('[');
			for (int i = 0; i < generic_params.Count; i++)
			{
				if (i > 0)
				{
					stringBuilder.Append(", ");
				}
				if (generic_params[i].assembly_name != null)
				{
					stringBuilder.Append('[').Append(generic_params[i].DisplayFullName).Append(']');
				}
				else
				{
					stringBuilder.Append(generic_params[i].DisplayFullName);
				}
			}
			stringBuilder.Append(']');
		}
		if (flag2)
		{
			GetModifierString(stringBuilder);
		}
		if (assembly_name != null && flag)
		{
			stringBuilder.Append(", ").Append(assembly_name);
		}
		return stringBuilder.ToString();
	}

	private StringBuilder GetModifierString(StringBuilder sb)
	{
		if (modifier_spec != null)
		{
			foreach (IModifierSpec item in modifier_spec)
			{
				item.Append(sb);
			}
		}
		if (is_byref)
		{
			sb.Append('&');
		}
		return sb;
	}

	internal static TypeSpec Parse(string typeName)
	{
		int p = 0;
		ArgumentNullException.ThrowIfNull(typeName, "typeName");
		TypeSpec result = Parse(typeName, ref p, is_recurse: false, allow_aqn: true);
		if (p < typeName.Length)
		{
			throw new ArgumentException("Argument_TypeParseError", "typeName");
		}
		return result;
	}

	internal static string EscapeDisplayName(string internalName)
	{
		StringBuilder stringBuilder = new StringBuilder(internalName.Length);
		foreach (char c in internalName)
		{
			switch (c)
			{
			case '&':
			case '*':
			case '+':
			case ',':
			case '[':
			case '\\':
			case ']':
				stringBuilder.Append('\\').Append(c);
				break;
			default:
				stringBuilder.Append(c);
				break;
			}
		}
		return stringBuilder.ToString();
	}

	internal static string UnescapeInternalName(string displayName)
	{
		StringBuilder stringBuilder = new StringBuilder(displayName.Length);
		for (int i = 0; i < displayName.Length; i++)
		{
			char c = displayName[i];
			if (c == '\\' && ++i < displayName.Length)
			{
				c = displayName[i];
			}
			stringBuilder.Append(c);
		}
		return stringBuilder.ToString();
	}

	private void AddName(string type_name)
	{
		if (name == null)
		{
			name = ParsedTypeIdentifier(type_name);
			return;
		}
		if (nested == null)
		{
			nested = new List<ITypeIdentifier>();
		}
		nested.Add(ParsedTypeIdentifier(type_name));
	}

	private void AddModifier(IModifierSpec md)
	{
		if (modifier_spec == null)
		{
			modifier_spec = new List<IModifierSpec>();
		}
		modifier_spec.Add(md);
	}

	private static void SkipSpace(string name, ref int pos)
	{
		int i;
		for (i = pos; i < name.Length && char.IsWhiteSpace(name[i]); i++)
		{
		}
		pos = i;
	}

	private static void BoundCheck(int idx, string s)
	{
		if (idx >= s.Length)
		{
			throw new ArgumentException("Argument_InvalidGenericArg", "typeName");
		}
	}

	private static ITypeIdentifier ParsedTypeIdentifier(string displayName)
	{
		return TypeIdentifiers.FromDisplay(displayName);
	}

	private static TypeSpec Parse(string name, ref int p, bool is_recurse, bool allow_aqn)
	{
		int i = p;
		bool flag = false;
		TypeSpec typeSpec = new TypeSpec();
		SkipSpace(name, ref i);
		int num = i;
		for (; i < name.Length; i++)
		{
			switch (name[i])
			{
			case '+':
				typeSpec.AddName(name.Substring(num, i - num));
				num = i + 1;
				break;
			case ',':
			case ']':
				typeSpec.AddName(name.Substring(num, i - num));
				num = i + 1;
				flag = true;
				if (is_recurse && !allow_aqn)
				{
					p = i;
					return typeSpec;
				}
				break;
			case '&':
			case '*':
			case '[':
				if (name[i] != '[' && is_recurse)
				{
					throw new ArgumentException("Argument_GenericArgumentCannotBeByrefOrPointerType", "typeName");
				}
				typeSpec.AddName(name.Substring(num, i - num));
				num = i + 1;
				flag = true;
				break;
			case '\\':
				i++;
				break;
			}
			if (flag)
			{
				break;
			}
		}
		if (num < i)
		{
			typeSpec.AddName(name.Substring(num, i - num));
		}
		else if (num == i)
		{
			typeSpec.AddName(string.Empty);
		}
		if (flag)
		{
			for (; i < name.Length; i++)
			{
				switch (name[i])
				{
				case '&':
					if (typeSpec.is_byref)
					{
						throw new ArgumentException(SR.Format("CannotCreateByRefOfByRef", typeSpec.TypeName), "typeName");
					}
					typeSpec.is_byref = true;
					break;
				case '*':
				{
					if (typeSpec.is_byref)
					{
						throw new ArgumentException(SR.Format("CannotCreatePointerOfByRef", typeSpec.TypeName), "typeName");
					}
					int num2 = 1;
					while (i + 1 < name.Length && name[i + 1] == '*')
					{
						i++;
						num2++;
					}
					typeSpec.AddModifier(new PointerSpec(num2));
					break;
				}
				case ',':
					if (is_recurse && allow_aqn)
					{
						int j;
						for (j = i; j < name.Length && name[j] != ']'; j++)
						{
						}
						if (j >= name.Length)
						{
							throw new ArgumentException("Argument_UnmatchedSquareBracketWhileParsingGenericArgAssemblyName");
						}
						typeSpec.assembly_name = name.Substring(i + 1, j - i - 1).Trim();
						p = j;
						return typeSpec;
					}
					if (is_recurse)
					{
						p = i;
						return typeSpec;
					}
					if (allow_aqn)
					{
						typeSpec.assembly_name = name.Substring(i + 1).Trim();
						i = name.Length;
					}
					break;
				case '[':
				{
					if (typeSpec.is_byref)
					{
						throw new ArgumentException("Argument_ByrefQualifierMustBeLastOneOfAType", "typeName");
					}
					i++;
					if (i >= name.Length)
					{
						throw new ArgumentException("Argument_InvalidArrayType", "typeName");
					}
					SkipSpace(name, ref i);
					if (name[i] != ',' && name[i] != '*' && name[i] != ']')
					{
						List<TypeSpec> list = new List<TypeSpec>();
						if (typeSpec.HasModifiers)
						{
							throw new ArgumentException("Arg_GenericArgumentsAfterArrayOrPointerType", "typeName");
						}
						for (; i < name.Length; i++)
						{
							SkipSpace(name, ref i);
							bool flag2 = name[i] == '[';
							if (flag2)
							{
								i++;
							}
							list.Add(Parse(name, ref i, is_recurse: true, flag2));
							BoundCheck(i, name);
							if (flag2)
							{
								if (name[i] != ']')
								{
									throw new ArgumentException(SR.Format("Argument_UnclosedAssemblyQualifiedTypeName", name[i]), "typeName");
								}
								i++;
								BoundCheck(i, name);
							}
							if (name[i] == ']')
							{
								break;
							}
							if (name[i] != ',')
							{
								throw new ArgumentException(SR.Format("Argument_InvalidGenericArgumentsSeparator", name[i]), "typeName");
							}
						}
						if (i >= name.Length || name[i] != ']')
						{
							throw new ArgumentException("Argument_GenericParsingError", "typeName");
						}
						typeSpec.generic_params = list;
						break;
					}
					int num3 = 1;
					bool flag3 = false;
					while (i < name.Length && name[i] != ']')
					{
						if (name[i] == '*')
						{
							if (flag3)
							{
								throw new ArgumentException("Argument_MultiDimensionalArrayCannotBeBound", "typeName");
							}
							flag3 = true;
						}
						else
						{
							if (name[i] != ',')
							{
								throw new ArgumentException(SR.Format("Argument_InvalidCharInArraySpecification", name[i]), "typeName");
							}
							num3++;
						}
						i++;
						SkipSpace(name, ref i);
					}
					if (i >= name.Length || name[i] != ']')
					{
						throw new ArgumentException("Argument_ArrayParsingError", "typeName");
					}
					if (num3 > 1 && flag3)
					{
						throw new ArgumentException("Argument_MultiDimensionalArrayCannotBeBound", "typeName");
					}
					typeSpec.AddModifier(new IArraySpec(num3, flag3));
					break;
				}
				case ']':
					if (is_recurse)
					{
						p = i;
						return typeSpec;
					}
					throw new ArgumentException("Argument_UnmatchedSquareBracketWhileParsingGenericArgAssemblyName", "typeName");
				default:
					throw new ArgumentException(SR.Format("Argument_BadTypeDef", name[i], i), "typeName");
				}
			}
		}
		p = i;
		return typeSpec;
	}

	internal ITypeName TypeNameWithoutModifiers()
	{
		return new TypeSpecTypeName(this, wantModifiers: false);
	}
}
