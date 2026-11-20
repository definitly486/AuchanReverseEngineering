using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Java.Interop.Tools.JavaCallableWrappers;

namespace Java.Interop.Tools.TypeNameMappings;

internal static class JavaNativeTypeManager
{
	private static readonly Lazy<Type> IJavaPeerableType = new Lazy<Type>(() => Type.GetType("Java.Interop.IJavaPeerable, Java.Interop", throwOnError: true));

	public static PackageNamingPolicy PackageNamingPolicy { get; set; } = PackageNamingPolicy.LowercaseCrc64;

	public static string ToJniName(Type type)
	{
		return ToJniName(type, ExportParameterKind.Unspecified) ?? "java/lang/Object";
	}

	private static string? ToJniName(Type type, ExportParameterKind exportKind)
	{
		if (type == null)
		{
			throw new ArgumentNullException("type");
		}
		if (type.IsValueType)
		{
			return GetPrimitiveClass(type);
		}
		if (type == typeof(string))
		{
			return "java/lang/String";
		}
		if (ShouldCheckSpecialExportJniType(type))
		{
			return GetSpecialExportJniType(type.FullName, exportKind);
		}
		return ToJniName(type, (Type t) => t.DeclaringType, (Type t) => t.Name, GetPackageName, (Type t) => ToJniNameFromAttributes(t), (Type _) => false);
	}

	private static bool ShouldCheckSpecialExportJniType(Type type)
	{
		return !IJavaPeerableType.Value.IsAssignableFrom(type);
	}

	public static string ToJniName(string jniType, int rank)
	{
		if (rank == 0)
		{
			return jniType;
		}
		if (jniType.Length > 1 && jniType[0] != '[')
		{
			jniType = "L" + jniType + ";";
		}
		return new string('[', rank) + jniType;
	}

	private static bool IsPackageNamePreservedForAssembly(string assemblyName)
	{
		return assemblyName == "Mono.Android";
	}

	public static string GetPackageName(Type type)
	{
		string assemblyName = GetAssemblyName(type.Assembly);
		if (IsPackageNamePreservedForAssembly(assemblyName))
		{
			return type.Namespace.ToLowerInvariant();
		}
		return PackageNamingPolicy switch
		{
			PackageNamingPolicy.Lowercase => type.Namespace.ToLowerInvariant(), 
			PackageNamingPolicy.LowercaseWithAssemblyName => "assembly_" + (assemblyName.Replace('.', '_') + "." + type.Namespace).ToLowerInvariant(), 
			PackageNamingPolicy.LowercaseCrc64 => "crc64" + ToCrc64(type.Namespace + ":" + assemblyName), 
			_ => throw new NotSupportedException($"PackageNamingPolicy.{PackageNamingPolicy} is no longer supported."), 
		};
	}

	private static string GetAssemblyName(Assembly assembly)
	{
		string fullName = assembly.FullName;
		int num = fullName.IndexOf(',');
		if (num != -1)
		{
			return fullName.Substring(0, num);
		}
		return fullName;
	}

	public static int GetArrayInfo(Type type, out Type elementType)
	{
		elementType = type;
		int num = 0;
		while (type.IsArray)
		{
			num++;
			elementType = (type = type.GetElementType());
		}
		return num;
	}

	private static string? GetPrimitiveClass(Type type)
	{
		if (type.IsEnum)
		{
			return GetPrimitiveClass(Enum.GetUnderlyingType(type));
		}
		if (type == typeof(byte))
		{
			return "B";
		}
		if (type == typeof(char))
		{
			return "C";
		}
		if (type == typeof(double))
		{
			return "D";
		}
		if (type == typeof(float))
		{
			return "F";
		}
		if (type == typeof(int))
		{
			return "I";
		}
		if (type == typeof(uint))
		{
			return "I";
		}
		if (type == typeof(long))
		{
			return "J";
		}
		if (type == typeof(ulong))
		{
			return "J";
		}
		if (type == typeof(short))
		{
			return "S";
		}
		if (type == typeof(ushort))
		{
			return "S";
		}
		if (type == typeof(bool))
		{
			return "Z";
		}
		return null;
	}

	private static string? GetSpecialExportJniType(string typeName, ExportParameterKind exportKind)
	{
		switch (exportKind)
		{
		case ExportParameterKind.InputStream:
			if (typeName != "System.IO.Stream")
			{
				throw new ArgumentException("ExportParameterKind.InputStream is valid only for System.IO.Stream parameter type");
			}
			return "java/io/InputStream";
		case ExportParameterKind.OutputStream:
			if (typeName != "System.IO.Stream")
			{
				throw new ArgumentException("ExportParameterKind.OutputStream is valid only for System.IO.Stream parameter type");
			}
			return "java/io/OutputStream";
		case ExportParameterKind.XmlPullParser:
			if (typeName != "System.Xml.XmlReader")
			{
				throw new ArgumentException("ExportParameterKind.XmlPullParser is valid only for System.Xml.XmlReader parameter type");
			}
			return "org/xmlpull/v1/XmlPullParser";
		case ExportParameterKind.XmlResourceParser:
			if (typeName != "System.Xml.XmlReader")
			{
				throw new ArgumentException("ExportParameterKind.XmlResourceParser is valid only for System.Xml.XmlReader parameter type");
			}
			return "android/content/res/XmlResourceParser";
		default:
			return null;
		}
	}

	public static string? ToJniNameFromAttributes(Type type)
	{
		IJniNameProviderAttribute[] array = (IJniNameProviderAttribute[])type.GetCustomAttributes(typeof(IJniNameProviderAttribute), inherit: false);
		if (array.Length == 0 || string.IsNullOrEmpty(array[0].Name))
		{
			return null;
		}
		return array[0].Name.Replace('.', '/');
	}

	private static string? GetJniSignature<T, P>(IEnumerable<P> parameters, Func<P, T> getParameterType, Func<P, ExportParameterKind> getExportKind, T returnType, ExportParameterKind returnExportKind, Func<T, ExportParameterKind, string?> getJniTypeName, bool isConstructor)
	{
		StringBuilder stringBuilder = new StringBuilder().Append("(");
		foreach (P parameter in parameters)
		{
			string text = getJniTypeName(getParameterType(parameter), getExportKind(parameter));
			if (text == null)
			{
				return null;
			}
			stringBuilder.Append(text);
		}
		stringBuilder.Append(')');
		if (isConstructor)
		{
			stringBuilder.Append("V");
		}
		else
		{
			string text2 = getJniTypeName(returnType, returnExportKind);
			if (text2 == null)
			{
				return null;
			}
			stringBuilder.Append(text2);
		}
		return stringBuilder.ToString();
	}

	private static string? GetJniTypeName<TR, TD>(TR typeRef, ExportParameterKind exportKind, Func<TR, TD> resolve, Func<TR, KeyValuePair<int, TR>> getArrayInfo, Func<TD, string> getFullName, Func<TD, ExportParameterKind, string?> toJniName)
	{
		TD val = resolve(typeRef);
		KeyValuePair<int, TR> keyValuePair = getArrayInfo(typeRef);
		int key = keyValuePair.Key;
		TR value = keyValuePair.Value;
		val = resolve(value);
		if (val == null)
		{
			return null;
		}
		if (getFullName(val) == "System.Void")
		{
			return "V";
		}
		if (getFullName(val) == "System.IntPtr")
		{
			return null;
		}
		string text = toJniName(val, exportKind);
		if (text == null)
		{
			return null;
		}
		if (key != 0 || text.Length <= 1 || text[0] == '[')
		{
			return ToJniName(text, key);
		}
		return "L" + text + ";";
	}

	private static ExportParameterKind GetExportKind(ICustomAttributeProvider p)
	{
		object[] customAttributes = p.GetCustomAttributes(typeof(ExportParameterAttribute), inherit: false);
		int num = 0;
		if (num < customAttributes.Length)
		{
			return ((ExportParameterAttribute)customAttributes[num]).Kind;
		}
		return ExportParameterKind.Unspecified;
	}

	public static string? GetJniSignature(MethodInfo method)
	{
		return GetJniSignature(method.GetParameters(), (ParameterInfo p) => p.ParameterType, (ParameterInfo p) => GetExportKind(p), method.ReturnType, GetExportKind(method.ReturnParameter), (Type t, ExportParameterKind k) => GetJniTypeName(t, k), method.IsConstructor);
	}

	internal static string? GetJniTypeName(Type typeRef, ExportParameterKind exportKind)
	{
		Type elementType;
		return GetJniTypeName(typeRef, exportKind, (Type t) => t, (Type t) => new KeyValuePair<int, Type>(GetArrayInfo(t, out elementType), elementType), (Type t) => t.FullName, (Type t, ExportParameterKind k) => ToJniNameWhichShouldReplaceExistingToJniName(t, k));
	}

	private static string? ToJniNameWhichShouldReplaceExistingToJniName(Type type, ExportParameterKind exportKind)
	{
		return ToJniNameFromAttributes(type) ?? ToJniName(type, exportKind);
	}

	private static string ToJniName<T>(T type, Func<T, T> decl, Func<T, string> name, Func<T, string> ns, Func<T, string?> overrideName, Func<T, bool> shouldUpdateName) where T : class
	{
		List<string> list = new List<string>();
		string text = null;
		T arg = type;
		for (T val = type; val != null; val = decl(val))
		{
			arg = val;
			text = overrideName(val);
			if (text != null)
			{
				break;
			}
			string text2 = name(val).Replace('`', '_');
			if (shouldUpdateName(val))
			{
				text2 = "$" + name(decl(val)) + "_" + text2;
			}
			list.Add(text2);
		}
		if (list.Count == 0 && text != null)
		{
			return text;
		}
		list.Reverse();
		string text3 = string.Join("_", list.ToArray()).Replace("_$", "$");
		if (text != null)
		{
			return (text + "_" + text3).Replace("_$", "$");
		}
		text = text3;
		string text4 = ToLowerCase(ns(arg));
		if (!string.IsNullOrEmpty(text4))
		{
			return text4.Replace('.', '/') + "/" + text;
		}
		return text;
	}

	private static string ToCrc64(string value)
	{
		byte[] array = Crc64Helper.Compute(Encoding.UTF8.GetBytes(value));
		StringBuilder stringBuilder = new StringBuilder(array.Length * 2);
		byte[] array2 = array;
		foreach (byte b in array2)
		{
			stringBuilder.AppendFormat("{0:x2}", b);
		}
		return stringBuilder.ToString();
	}

	private static string ToLowerCase(string value)
	{
		if (string.IsNullOrEmpty(value))
		{
			return value;
		}
		string[] array = value.Split('.');
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = array[i].ToLowerInvariant();
		}
		return string.Join(".", array);
	}
}
