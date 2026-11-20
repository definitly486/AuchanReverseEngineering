using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Reflection;
using System.Xml;
using Android.Runtime;
using Java.Lang;
using Mono.CodeGeneration;

namespace Java.Interop;

[RequiresDynamicCode("Mono.Android.Export uses dynamic features.")]
[RequiresUnreferencedCode("Mono.Android.Export uses dynamic features.")]
internal class DynamicInvokeTypeInfo
{
	private enum SymbolKind
	{
		Array,
		CharSequence,
		Class,
		Collection,
		Enum,
		SimpleFormat,
		GenericTypeParameter,
		Interface,
		Stream,
		String,
		XmlReader
	}

	private static readonly MethodInfo jnienv_newarray;

	private static readonly MethodInfo jnienv_getarray;

	private static readonly MethodInfo charsequence_tojnihandle;

	private static readonly MethodInfo jnienv_tojnihandle;

	private static readonly MethodInfo jnienv_newstring;

	private static readonly MethodInfo jnienv_getstring;

	private static readonly MethodInfo object_getobject;

	private static readonly BindingFlags sloppy_flags;

	private static readonly MethodInfo inputstreaminvoker_fromjnihandle;

	private static readonly MethodInfo inputstreamadapter_tojnihandle;

	private static readonly MethodInfo outputstreaminvoker_fromjnihandle;

	private static readonly MethodInfo outputstreamadapter_tojnihandle;

	private static readonly MethodInfo xmlpullparserreader_fromjnihandle;

	private static readonly MethodInfo xmlreaderpullparser_tojnihandle;

	private static readonly MethodInfo xmlresourceparserreader_fromjnihandle;

	private static readonly MethodInfo xmlreaderresourceparser_tojnihandle;

	private static readonly CodeLiteral do_not_transfer_literal;

	private Type type;

	private ExportParameterKind parameter_kind;

	public Type NativeType => GetNativeType(type);

	public bool NeedsPrep => NeedsPreparation(type, parameter_kind);

	static DynamicInvokeTypeInfo()
	{
		jnienv_newarray = GetTArrayToIntPtr<int>(JNIEnv.NewArray<int>);
		jnienv_getarray = GetIntPtrToTArray(JNIEnv.GetArray<int>);
		charsequence_tojnihandle = GetEnumerableCharToIntPtrMethodInfo(CharSequence.ToLocalJniHandle);
		jnienv_tojnihandle = GetObjectToIntPtrMethodInfo(JNIEnv.ToLocalJniHandle);
		jnienv_newstring = GetStringToIntPtrMethodInfo(JNIEnv.NewString);
		jnienv_getstring = GetHandleToStringMethodInfo(JNIEnv.GetString);
		object_getobject = typeof(Java.Lang.Object).GetMethod("GetObject", new Type[2]
		{
			typeof(nint),
			typeof(JniHandleOwnership)
		});
		sloppy_flags = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;
		inputstreaminvoker_fromjnihandle = GetHandleToStreamMethodInfo(InputStreamInvoker.FromJniHandle);
		inputstreamadapter_tojnihandle = GetStreamToIntPtrMethodInfo(InputStreamAdapter.ToLocalJniHandle);
		outputstreaminvoker_fromjnihandle = GetHandleToStreamMethodInfo(OutputStreamInvoker.FromJniHandle);
		outputstreamadapter_tojnihandle = GetStreamToIntPtrMethodInfo(OutputStreamAdapter.ToLocalJniHandle);
		xmlpullparserreader_fromjnihandle = GetHandleToXmlReaderMethodInfo(XmlPullParserReader.FromJniHandle);
		xmlreaderpullparser_tojnihandle = GetXmlResourceParserReaderToIntPtrMethodInfo(XmlReaderPullParser.ToLocalJniHandle);
		xmlresourceparserreader_fromjnihandle = GetHandleToXmlResourceParserReaderMethodInfo(XmlResourceParserReader.FromJniHandle);
		xmlreaderresourceparser_tojnihandle = GetXmlReaderToIntPtrMethodInfo(XmlReaderResourceParser.ToLocalJniHandle);
		do_not_transfer_literal = new CodeLiteral(JniHandleOwnership.DoNotTransfer);
		CheckReflection(jnienv_newarray, "JNIEnv.NewArray<T>");
		CheckReflection(jnienv_getarray, "JNIEnv.GetArray<T>");
		CheckReflection(charsequence_tojnihandle, "ICharSequence.ToLocalJniHandle");
		CheckReflection(jnienv_tojnihandle, "JNIEnv.ToLocalJniHandle");
		CheckReflection(jnienv_newstring, "JNIEnv.NewString");
		CheckReflection(jnienv_getstring, "JNIEnv.GetString");
		CheckReflection(object_getobject, "Java.Lang.Object.GetObject");
		CheckReflection(xmlpullparserreader_fromjnihandle, "XmlPullParserReader.FromJniHandle");
		CheckReflection(xmlresourceparserreader_fromjnihandle, "XmlResourceParserReader.FromJniHandle");
		CheckReflection(xmlreaderpullparser_tojnihandle, "XmlReaderPullParser.ToLocalJniHandle");
		CheckReflection(xmlreaderresourceparser_tojnihandle, "XmlReaderResourceParser.ToLocalJniHandle");
		CheckReflection(inputstreaminvoker_fromjnihandle, "InputStreamInvoker.FromJniHandle");
		CheckReflection(inputstreamadapter_tojnihandle, "InputStreamAdapter.ToLocalJniHandle");
		CheckReflection(outputstreaminvoker_fromjnihandle, "OutputStreamInvoker.FromJniHandle");
		CheckReflection(outputstreamadapter_tojnihandle, "OutputStreamAdapter.ToLocalJniHandle");
	}

	private static MethodInfo GetEnumerableCharToIntPtrMethodInfo(Func<IEnumerable<char>, nint> func)
	{
		return func.Method;
	}

	private static MethodInfo GetObjectToIntPtrMethodInfo(Func<IJavaObject, nint> func)
	{
		return func.Method;
	}

	private static MethodInfo GetHandleToStreamMethodInfo(Func<nint, JniHandleOwnership, Stream> func)
	{
		return func.Method;
	}

	private static MethodInfo GetHandleToStringMethodInfo(Func<nint, JniHandleOwnership, string> func)
	{
		return func.Method;
	}

	private static MethodInfo GetHandleToXmlReaderMethodInfo(Func<nint, JniHandleOwnership, XmlReader> func)
	{
		return func.Method;
	}

	private static MethodInfo GetHandleToXmlResourceParserReaderMethodInfo(Func<nint, JniHandleOwnership, XmlResourceParserReader> func)
	{
		return func.Method;
	}

	private static MethodInfo GetIntPtrToTArray<T>(Func<nint, T[]> func)
	{
		return func.Method.GetGenericMethodDefinition();
	}

	private static MethodInfo GetStreamToIntPtrMethodInfo(Func<Stream, nint> func)
	{
		return func.Method;
	}

	private static MethodInfo GetStringToIntPtrMethodInfo(Func<string, nint> func)
	{
		return func.Method;
	}

	private static MethodInfo GetTArrayToIntPtr<T>(Func<T[], nint> func)
	{
		return func.Method.GetGenericMethodDefinition();
	}

	private static MethodInfo GetXmlReaderToIntPtrMethodInfo(Func<XmlReader, nint> func)
	{
		return func.Method;
	}

	private static MethodInfo GetXmlResourceParserReaderToIntPtrMethodInfo(Func<XmlResourceParserReader, nint> func)
	{
		return func.Method;
	}

	private static void CheckReflection(MethodInfo mi, string name)
	{
		if (mi == null)
		{
			throw new InvalidOperationException(".NET for Android bug: JNIEnv type contains incompatible method signatures : " + name);
		}
	}

	public static DynamicInvokeTypeInfo Get(Type type, ExportParameterKind kind)
	{
		return new DynamicInvokeTypeInfo(type, kind);
	}

	private DynamicInvokeTypeInfo(Type type, ExportParameterKind parameterKind)
	{
		this.type = type;
		parameter_kind = parameterKind;
	}

	public CodeExpression PrepareCallback(CodeExpression arg)
	{
		return GetCallbackPrep(type, parameter_kind, arg);
	}

	public CodeExpression CleanupCallback(CodeExpression arg, CodeExpression orgArg)
	{
		return GetCallbackCleanup(type, arg, orgArg);
	}

	private static bool NeedsPreparation(Type type, ExportParameterKind pkind)
	{
		SymbolKind kind = GetKind(type);
		if ((uint)kind <= 1u || kind == SymbolKind.String)
		{
			return true;
		}
		return false;
	}

	public static CodeExpression GetCallbackPrep(Type type, ExportParameterKind pkind, CodeExpression arg)
	{
		return GetKind(type) switch
		{
			SymbolKind.Array => new CodeMethodCall(jnienv_getarray, arg, do_not_transfer_literal, new CodeLiteral(type)).CastTo(type), 
			SymbolKind.CharSequence => new CodeMethodCall(object_getobject.MakeGenericMethod(typeof(ICharSequence)), arg, do_not_transfer_literal), 
			SymbolKind.Stream => arg, 
			SymbolKind.String => new CodeMethodCall(jnienv_getstring, arg, do_not_transfer_literal), 
			SymbolKind.XmlReader => arg, 
			_ => arg, 
		};
	}

	public static CodeExpression GetCallbackCleanup(Type type, CodeExpression arg, CodeExpression orgArg)
	{
		switch (GetKind(type))
		{
		case SymbolKind.Array:
		{
			MethodInfo method;
			switch (Type.GetTypeCode(type))
			{
			case TypeCode.Empty:
			case TypeCode.DBNull:
				throw new NotSupportedException("Only primitive types and IJavaObject is supported in array type in callback method parameter or return value");
			case TypeCode.Object:
				if (typeof(IJavaObject).IsAssignableFrom(type))
				{
					method = typeof(JNIEnv).GetMethod("CopyArray", new Type[2]
					{
						typeof(IJavaObject),
						typeof(nint)
					});
					break;
				}
				goto case TypeCode.Empty;
			default:
				method = typeof(JNIEnv).GetMethod("CopyArray", new Type[2]
				{
					type,
					typeof(nint)
				});
				break;
			}
			return new CodeWhen(arg.IsNull, arg, new CodeMethodCall(method, arg, orgArg));
		}
		case SymbolKind.CharSequence:
			return new CodeMethodCall(object_getobject.MakeGenericMethod(typeof(ICharSequence)), arg, do_not_transfer_literal);
		default:
			return arg;
		}
	}

	private static SymbolKind GetKind(Type type)
	{
		if (type.IsArray)
		{
			return SymbolKind.Array;
		}
		if (type.IsEnum)
		{
			return SymbolKind.Enum;
		}
		if (type == typeof(ICharSequence))
		{
			return SymbolKind.CharSequence;
		}
		if (type == typeof(Stream))
		{
			return SymbolKind.Stream;
		}
		if (type == typeof(XmlReader))
		{
			return SymbolKind.XmlReader;
		}
		if (type == typeof(string))
		{
			return SymbolKind.String;
		}
		if (Type.GetTypeCode(type) != TypeCode.Object)
		{
			return SymbolKind.SimpleFormat;
		}
		if (type == typeof(IList) || type == typeof(IDictionary) || type == typeof(ICollection))
		{
			return SymbolKind.Collection;
		}
		if (type.IsGenericParameter)
		{
			return SymbolKind.GenericTypeParameter;
		}
		if (type.IsGenericTypeDefinition)
		{
			throw new NotSupportedException("Dynamic method generation is not supported for generic type definition");
		}
		if (type.IsInterface)
		{
			return SymbolKind.Interface;
		}
		return SymbolKind.Class;
	}

	public CodeExpression FromNative(CodeExpression arg)
	{
		return GetKind(type) switch
		{
			SymbolKind.Array => new CodeMethodCall(jnienv_getarray.MakeGenericMethod(type.GetElementType()), arg, do_not_transfer_literal, new CodeLiteral(type)).CastTo(type.GetElementType().MakeArrayType()), 
			SymbolKind.CharSequence => new CodeMethodCall(object_getobject.MakeGenericMethod(type), arg, do_not_transfer_literal), 
			SymbolKind.Class => new CodeMethodCall(object_getobject.MakeGenericMethod(type), arg, do_not_transfer_literal), 
			SymbolKind.Enum => arg.CastTo(type), 
			SymbolKind.SimpleFormat => arg, 
			SymbolKind.GenericTypeParameter => new CodeMethodCall(object_getobject.MakeGenericMethod(type), arg, do_not_transfer_literal).CastTo(type), 
			SymbolKind.Interface => new CodeMethodCall(object_getobject.MakeGenericMethod(type), arg, do_not_transfer_literal), 
			SymbolKind.Stream => parameter_kind switch
			{
				ExportParameterKind.InputStream => new CodeMethodCall(inputstreaminvoker_fromjnihandle, arg, do_not_transfer_literal), 
				ExportParameterKind.OutputStream => new CodeMethodCall(outputstreaminvoker_fromjnihandle, arg, do_not_transfer_literal), 
				_ => throw new NotSupportedException("To use Stream type in callback, ExportParameterAttribute is required on the parameter to indicate its Java appropriate parameter kind"), 
			}, 
			SymbolKind.String => new CodeMethodCall(jnienv_getstring, arg, do_not_transfer_literal), 
			SymbolKind.XmlReader => parameter_kind switch
			{
				ExportParameterKind.XmlPullParser => new CodeMethodCall(xmlpullparserreader_fromjnihandle, arg, do_not_transfer_literal), 
				ExportParameterKind.XmlResourceParser => new CodeMethodCall(xmlresourceparserreader_fromjnihandle, arg, do_not_transfer_literal), 
				_ => throw new NotSupportedException("To use XmlReader type in callback, ExportParameterAttribute is required on the parameter to indicate its Java appropriate parameter kind"), 
			}, 
			_ => throw new InvalidOperationException(), 
		};
	}

	public CodeExpression ToNative(CodeExpression arg)
	{
		return GetKind(type) switch
		{
			SymbolKind.Array => new CodeMethodCall(jnienv_newarray.MakeGenericMethod(type.GetElementType()), arg), 
			SymbolKind.CharSequence => new CodeMethodCall(charsequence_tojnihandle, arg), 
			SymbolKind.Class => new CodeMethodCall(jnienv_tojnihandle, arg), 
			SymbolKind.Collection => new CodeMethodCall(type.GetMethod("ToLocalJniHandle"), arg), 
			SymbolKind.Enum => arg.CastTo(typeof(int)), 
			SymbolKind.SimpleFormat => arg, 
			SymbolKind.GenericTypeParameter => new CodeMethodCall(jnienv_tojnihandle, arg), 
			SymbolKind.Interface => new CodeMethodCall(jnienv_tojnihandle, arg), 
			SymbolKind.Stream => parameter_kind switch
			{
				ExportParameterKind.InputStream => new CodeMethodCall(inputstreamadapter_tojnihandle, arg), 
				ExportParameterKind.OutputStream => new CodeMethodCall(outputstreamadapter_tojnihandle, arg), 
				_ => throw new NotSupportedException("To use Stream type in callback, ExportParameterAttribute is required on the parameter to indicate its Java appropriate parameter kind"), 
			}, 
			SymbolKind.String => new CodeMethodCall(jnienv_newstring, arg), 
			SymbolKind.XmlReader => parameter_kind switch
			{
				ExportParameterKind.XmlPullParser => new CodeMethodCall(xmlreaderpullparser_tojnihandle, arg), 
				ExportParameterKind.XmlResourceParser => new CodeMethodCall(xmlreaderresourceparser_tojnihandle, arg), 
				_ => throw new NotSupportedException("To use XmlReader type in callback, ExportParameterAttribute is required on the parameter to indicate its Java appropriate parameter kind"), 
			}, 
			_ => throw new InvalidOperationException(), 
		};
	}

	public static Type GetNativeType(Type type)
	{
		if (type == typeof(void))
		{
			return typeof(void);
		}
		if (type.IsEnum)
		{
			return typeof(int);
		}
		TypeCode typeCode = Type.GetTypeCode(type);
		if ((uint)(typeCode - 1) <= 1u || typeCode == TypeCode.String)
		{
			return typeof(nint);
		}
		return type;
	}
}
