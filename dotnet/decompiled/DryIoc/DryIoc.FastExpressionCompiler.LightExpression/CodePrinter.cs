using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public static class CodePrinter
{
	public interface IObjectToCode
	{
		string ToCode(object x, bool stripNamespace = false, Func<Type, string, string> printType = null);
	}

	private class ConstantValueToCode : IObjectToCode
	{
		public string ToCode(object x, bool stripNamespace = false, Func<Type, string, string> printType = null)
		{
			return "default(" + x.GetType().ToCode(stripNamespace, printType, printGenericTypeArgs: false) + ")/* (!) Please provide the non-default value for the constant */";
		}
	}

	private const string _nonPubStatMethods = "BindingFlags.NonPublic|BindingFlags.Static";

	private const string _nonPubInstMethods = "BindingFlags.NonPublic|BindingFlags.Instance";

	private static readonly char[] _enumValueSeparators = new char[2] { ',', ' ' };

	internal static readonly IObjectToCode DefaultConstantValueToCode = new ConstantValueToCode();

	private static readonly Type[] TypesImplementedByArray = (from t in typeof(object[]).GetInterfaces()
		where t.GetTypeInfo().IsGenericType
		select t.GetGenericTypeDefinition()).ToArray();

	public static StringBuilder AppendTypeof(this StringBuilder sb, Type type, bool stripNamespace = false, Func<Type, string, string> printType = null, bool printGenericTypeArgs = false)
	{
		if (type == null)
		{
			return sb.Append("null");
		}
		sb.Append("typeof(").Append(type.ToCode(stripNamespace, printType, printGenericTypeArgs)).Append(')');
		if (!type.IsByRef)
		{
			return sb;
		}
		return sb.Append(".MakeByRefType()");
	}

	public static StringBuilder AppendTypeofList(this StringBuilder sb, Type[] types, bool stripNamespace = false, Func<Type, string, string> printType = null, bool printGenericTypeArgs = false)
	{
		for (int i = 0; i < types.Length; i++)
		{
			((i > 0) ? sb.Append(", ") : sb).AppendTypeof(types[i], stripNamespace, printType, printGenericTypeArgs);
		}
		return sb;
	}

	internal static StringBuilder AppendMember(this StringBuilder sb, MemberInfo member, bool stripNamespace = false, Func<Type, string, string> printType = null)
	{
		if (!(member is FieldInfo field))
		{
			return sb.AppendProperty((PropertyInfo)member, stripNamespace, printType);
		}
		return sb.AppendField(field, stripNamespace, printType);
	}

	internal static StringBuilder AppendField(this StringBuilder sb, FieldInfo field, bool stripNamespace = false, Func<Type, string, string> printType = null)
	{
		return sb.AppendTypeof(field.DeclaringType, stripNamespace, printType).Append(".GetTypeInfo().GetDeclaredField(\"").Append(field.Name)
			.Append("\")");
	}

	internal static StringBuilder AppendProperty(this StringBuilder sb, PropertyInfo property, bool stripNamespace = false, Func<Type, string, string> printType = null)
	{
		return sb.AppendTypeof(property.DeclaringType, stripNamespace, printType).Append(".GetTypeInfo().GetDeclaredProperty(\"").Append(property.Name)
			.Append("\")");
	}

	internal static StringBuilder AppendEnum<TEnum>(this StringBuilder sb, TEnum value, bool stripNamespace = false, Func<Type, string, string> printType = null)
	{
		return sb.Append(typeof(TEnum).ToCode(stripNamespace, printType)).Append('.').Append(Enum.GetName(typeof(TEnum), value));
	}

	public static StringBuilder AppendMethod(this StringBuilder sb, MethodInfo method, bool stripNamespace = false, Func<Type, string, string> printType = null)
	{
		if (method == null)
		{
			return sb.Append("null");
		}
		sb.AppendTypeof(method.DeclaringType, stripNamespace, printType);
		sb.Append(".GetMethods(");
		if (!method.IsPublic)
		{
			sb.Append(method.IsStatic ? "BindingFlags.NonPublic|BindingFlags.Static" : "BindingFlags.NonPublic|BindingFlags.Instance");
		}
		ParameterInfo[] parameters = method.GetParameters();
		if (!method.IsGenericMethod)
		{
			sb.Append(").Single(x => !x.IsGenericMethod && x.Name == \"").Append(method.Name).Append("\" && ");
			if (parameters.Length != 0)
			{
				return sb.Append("x.GetParameters().Select(y => y.ParameterType).SequenceEqual(new[] { ").AppendTypeofList(parameters.Select((ParameterInfo x) => x.ParameterType).ToArray(), stripNamespace, printType).Append(" }))");
			}
			return sb.Append("x.GetParameters().Length == 0)");
		}
		Type[] genericArguments = method.GetGenericArguments();
		sb.Append(").Where(x => x.IsGenericMethod && x.Name == \"").Append(method.Name).Append("\" && ");
		if (parameters.Length == 0)
		{
			sb.Append("x.GetParameters().Length == 0 && x.GetGenericArguments().Length == ").Append(genericArguments.Length);
			sb.Append(").Select(x => x.IsGenericMethodDefinition ? x.MakeGenericMethod(").AppendTypeofList(genericArguments, stripNamespace, printType);
			return sb.Append(") : x).Single()");
		}
		sb.Append("x.GetGenericArguments().Length == ").Append(genericArguments.Length);
		sb.Append(").Select(x => x.IsGenericMethodDefinition ? x.MakeGenericMethod(").AppendTypeofList(genericArguments, stripNamespace, printType);
		sb.Append(") : x).Single(x => x.GetParameters().Select(y => y.ParameterType).SequenceEqual(new[] { ");
		sb.AppendTypeofList(parameters.Select((ParameterInfo x) => x.ParameterType).ToArray(), stripNamespace, printType);
		return sb.Append(" }))");
	}

	internal static StringBuilder AppendName<T>(this StringBuilder sb, string name, Type type, T identity)
	{
		if (name == null)
		{
			return sb.Append(type.ToCode(stripNamespace: true).Replace('.', '_').Replace('<', '_')
				.Replace('>', '_')
				.Replace(", ", "_")
				.ToLowerInvariant()).Append("__").Append(identity.GetHashCode());
		}
		return sb.Append(name);
	}

	public static string ToCode(this Type type, bool stripNamespace = false, Func<Type, string, string> printType = null, bool printGenericTypeArgs = false)
	{
		if (type.IsGenericParameter)
		{
			object obj;
			if (printGenericTypeArgs)
			{
				obj = printType?.Invoke(type, type.Name);
				if (obj == null)
				{
					return type.Name;
				}
			}
			else
			{
				obj = string.Empty;
			}
			return (string)obj;
		}
		Type underlyingType = Nullable.GetUnderlyingType(type);
		if ((object)underlyingType != null && !type.IsGenericTypeDefinition)
		{
			string text = underlyingType.ToCode(stripNamespace, printType, printGenericTypeArgs) + "?";
			return printType?.Invoke(type, text) ?? text;
		}
		Type type2 = null;
		if (type.IsArray)
		{
			type2 = type;
			type = type.GetElementType();
		}
		string text2 = null;
		if (type == typeof(void))
		{
			text2 = "void";
		}
		else if (type == typeof(object))
		{
			text2 = "object";
		}
		else if (type == typeof(bool))
		{
			text2 = "bool";
		}
		else if (type == typeof(int))
		{
			text2 = "int";
		}
		else if (type == typeof(short))
		{
			text2 = "short";
		}
		else if (type == typeof(byte))
		{
			text2 = "byte";
		}
		else if (type == typeof(double))
		{
			text2 = "double";
		}
		else if (type == typeof(float))
		{
			text2 = "float";
		}
		else if (type == typeof(char))
		{
			text2 = "char";
		}
		else if (type == typeof(string))
		{
			text2 = "string";
		}
		if (text2 != null)
		{
			if (type2 != null)
			{
				text2 += "[]";
			}
			return printType?.Invoke(type2 ?? type, text2) ?? text2;
		}
		int num = 0;
		TypeInfo typeInfo = type.GetTypeInfo();
		while (typeInfo.IsNested)
		{
			num++;
			typeInfo = typeInfo.DeclaringType.GetTypeInfo();
		}
		Type[] array = null;
		if (num > 0)
		{
			array = new Type[num];
			Type declaringType = type.DeclaringType;
			int num2 = 0;
			while (num2 < array.Length)
			{
				array[num2] = declaringType;
				num2++;
				declaringType = declaringType.DeclaringType;
			}
		}
		TypeInfo typeInfo2 = type.GetTypeInfo();
		Type[] array2 = null;
		bool flag = false;
		if (type.IsGenericType)
		{
			flag = !typeInfo2.IsGenericTypeDefinition;
			array2 = (flag ? typeInfo2.GenericTypeArguments : typeInfo2.GenericTypeParameters);
		}
		int num3 = 0;
		StringBuilder stringBuilder = new StringBuilder();
		if (!stripNamespace && !string.IsNullOrEmpty(type.Namespace))
		{
			stringBuilder.Append(type.Namespace).Append('.');
		}
		if (array != null)
		{
			for (int num4 = array.Length - 1; num4 >= 0; num4--)
			{
				Type type3 = array[num4];
				if (!type3.IsGenericType)
				{
					stringBuilder.Append(type3.Name).Append('.');
				}
				else
				{
					TypeInfo typeInfo3 = type3.GetTypeInfo();
					Type[] array3 = null;
					if (typeInfo3.IsGenericTypeDefinition)
					{
						array3 = typeInfo3.GenericTypeParameters;
						if (flag)
						{
							for (int i = 0; i < array3.Length; i++)
							{
								array3[i] = array2[i];
							}
						}
						int num5 = array3.Length;
						if (num3 > 0)
						{
							int num6 = num5 - num3;
							if (num6 == 0)
							{
								array3 = null;
							}
							else
							{
								Type[] array4 = new Type[num6];
								for (int j = 0; j < array4.Length; j++)
								{
									array4[j] = array3[j + num3];
								}
								array3 = array4;
							}
						}
						num3 = num5;
					}
					else
					{
						array3 = typeInfo3.GenericTypeArguments;
					}
					int length = type3.Name.IndexOf('`');
					stringBuilder.Append(type3.Name.Substring(0, length));
					if (array3 != null && array3.Length != 0)
					{
						stringBuilder.Append('<');
						for (int k = 0; k < array3.Length; k++)
						{
							((k == 0) ? stringBuilder : stringBuilder.Append(", ")).Append(array3[k].ToCode(stripNamespace, printType, printGenericTypeArgs));
						}
						stringBuilder.Append('>');
					}
					stringBuilder.Append('.');
				}
			}
		}
		string text3 = type.Name.TrimStart('<', '>').TrimEnd('&');
		if (array2 != null && num3 < array2.Length)
		{
			stringBuilder.Append(text3[..text3.IndexOf('`')]).Append('<');
			for (int l = 0; l < array2.Length - num3; l++)
			{
				((l == 0) ? stringBuilder : stringBuilder.Append(", ")).Append(array2[l + num3].ToCode(stripNamespace, printType, printGenericTypeArgs));
			}
			stringBuilder.Append('>');
		}
		else
		{
			stringBuilder.Append(text3);
		}
		if (type2 != null)
		{
			stringBuilder.Append("[]");
		}
		return printType?.Invoke(type2 ?? type, stringBuilder.ToString()) ?? stringBuilder.ToString();
	}

	public static string ToCode(this bool x)
	{
		if (!x)
		{
			return "false";
		}
		return "true";
	}

	public static string ToCode(this string x)
	{
		if (x != null)
		{
			return "\"" + x.Replace("\"", "\\\"").Replace("\r", "\\r").Replace("\n", "\\n") + "\"";
		}
		return "null";
	}

	public static string ToEnumValueCode(this Type enumType, object x, bool stripNamespace = false, Func<Type, string, string> printType = null)
	{
		string text = enumType.ToCode(stripNamespace, printType) + ".";
		string text2 = x.ToString();
		string[] array = text2.Split(_enumValueSeparators, StringSplitOptions.RemoveEmptyEntries);
		if (array.Length == 1)
		{
			return text + text2;
		}
		string separator = "|" + text;
		return text + string.Join(separator, array);
	}

	private static Type[] GetGenericTypeParametersOrArguments(this TypeInfo typeInfo)
	{
		if (!typeInfo.IsGenericTypeDefinition)
		{
			return typeInfo.GenericTypeArguments;
		}
		return typeInfo.GenericTypeParameters;
	}

	public static string ToCommaSeparatedCode(this IEnumerable items, IObjectToCode notRecognizedToCode, bool stripNamespace = false, Func<Type, string, string> printType = null)
	{
		StringBuilder stringBuilder = new StringBuilder();
		bool flag = true;
		foreach (object item in items)
		{
			if (flag)
			{
				flag = false;
			}
			else
			{
				stringBuilder.Append(", ");
			}
			stringBuilder.Append(item.ToCode(notRecognizedToCode, stripNamespace, printType));
		}
		return stringBuilder.ToString();
	}

	public static string ToArrayInitializerCode(this IEnumerable items, Type itemType, IObjectToCode notRecognizedToCode, bool stripNamespace = false, Func<Type, string, string> printType = null)
	{
		return $"new {itemType.ToCode(stripNamespace, printType)}[]{{{items.ToCommaSeparatedCode(notRecognizedToCode, stripNamespace, printType)}}}";
	}

	public static string ToCode(this object x, IObjectToCode notRecognizedToCode, bool stripNamespace = false, Func<Type, string, string> printType = null)
	{
		if (x == null)
		{
			return "null";
		}
		if (x is bool x2)
		{
			return x2.ToCode();
		}
		if (x is int num)
		{
			return num.ToString();
		}
		if (x is double num2)
		{
			return num2.ToString();
		}
		if (x is string x3)
		{
			return x3.ToCode();
		}
		if (x is char c)
		{
			return "'" + c + "'";
		}
		if (x is Type type)
		{
			return type.ToCode(stripNamespace, printType);
		}
		if (x is Guid guid)
		{
			return "Guid.Parse(" + guid.ToString().ToCode() + ")";
		}
		if (x is DateTime dateTime)
		{
			return "DateTime.Parse(" + dateTime.ToString().ToCode() + ")";
		}
		if (x is TimeSpan timeSpan)
		{
			return "TimeSpan.Parse(" + timeSpan.ToString().ToCode() + ")";
		}
		Type type2 = x.GetType();
		TypeInfo typeInfo = type2.GetTypeInfo();
		if (typeInfo.IsArray || (typeInfo.IsGenericType && TypesImplementedByArray.Contains(type2.GetGenericTypeDefinition())))
		{
			Type type3 = (typeInfo.IsArray ? typeInfo.GetElementType() : typeInfo.GetGenericTypeParametersOrArguments().GetFirst());
			if (type3 != null)
			{
				return ((IEnumerable)x).ToArrayInitializerCode(type3, notRecognizedToCode);
			}
		}
		if (typeInfo.IsGenericType && typeInfo.GetGenericTypeDefinition() == typeof(Nullable<>))
		{
			type2 = typeInfo.GetElementType();
			typeInfo = type2.GetTypeInfo();
		}
		if (typeInfo.IsEnum)
		{
			return x.GetType().ToEnumValueCode(x, stripNamespace, printType);
		}
		if (typeInfo.IsPrimitive)
		{
			return "(" + x.GetType().ToCode(stripNamespace: true) + ")" + x.ToString();
		}
		return notRecognizedToCode?.ToCode(x, stripNamespace, printType) ?? x.ToString();
	}

	internal static StringBuilder NewLineIdent(this StringBuilder sb, int lineIdent)
	{
		return sb.AppendLine().Append(' ', lineIdent);
	}

	internal static StringBuilder NewLine(this StringBuilder sb, int lineIdent, int identSpaces)
	{
		return sb.AppendLine().Append(' ', Math.Max(lineIdent - identSpaces, 0));
	}

	internal static StringBuilder NewLineIdentExpr(this StringBuilder sb, Expression expr, List<ParameterExpression> paramsExprs, List<Expression> uniqueExprs, List<LabelTarget> lts, int lineIdent, bool stripNamespace, Func<Type, string, string> printType, int identSpaces, TryPrintConstant tryPrintConstant)
	{
		sb.NewLineIdent(lineIdent);
		return expr?.ToExpressionString(sb, paramsExprs, uniqueExprs, lts, lineIdent + identSpaces, stripNamespace, printType, identSpaces, tryPrintConstant) ?? sb.Append("null");
	}

	internal static StringBuilder NewLineIdentArgumentExprs<T>(this StringBuilder sb, IReadOnlyList<T> exprs, List<ParameterExpression> paramsExprs, List<Expression> uniqueExprs, List<LabelTarget> lts, int lineIdent, bool stripNamespace, Func<Type, string, string> printType, int identSpaces, TryPrintConstant tryPrintConstant) where T : Expression
	{
		if (exprs.Count == 0)
		{
			return sb.Append(" new ").Append(typeof(T).ToCode(stripNamespace: true)).Append("[0]");
		}
		for (int i = 0; i < exprs.Count; i++)
		{
			((i > 0) ? sb.Append(", ") : sb).NewLineIdentExpr(exprs[i], paramsExprs, uniqueExprs, lts, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant);
		}
		return sb;
	}

	internal static StringBuilder NewLineIdentCs(this StringBuilder sb, Expression expr, int lineIdent, bool stripNamespace, Func<Type, string, string> printType, int identSpaces, TryPrintConstant tryPrintConstant)
	{
		sb.NewLineIdent(lineIdent);
		return expr?.ToCSharpString(sb, lineIdent + identSpaces, stripNamespace, printType, identSpaces, tryPrintConstant) ?? sb.Append("null");
	}
}
