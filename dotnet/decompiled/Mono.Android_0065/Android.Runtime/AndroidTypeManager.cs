using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using Java.Interop;
using Java.Interop.Tools.TypeNameMappings;

namespace Android.Runtime;

internal class AndroidTypeManager : JniRuntime.JniTypeManager
{
	private struct JniRemappingReplacementMethod
	{
		public string target_type;

		public string target_name;

		public bool is_static;
	}

	private delegate Delegate GetCallbackHandler();

	private class MagicRegistrationMap
	{
		private static Dictionary<string, int>? typesMap;

		public static bool Filled
		{
			get
			{
				if (typesMap != null)
				{
					return typesMap.Count > 0;
				}
				return false;
			}
		}

		private static void Prefill()
		{
		}

		static MagicRegistrationMap()
		{
			Prefill();
		}

		internal static bool CallRegisterMethod(JniNativeMethodRegistrationArguments arguments, string typeName)
		{
			int value = 0;
			if (typeName != null)
			{
				Dictionary<string, int>? dictionary = typesMap;
				if (dictionary != null && dictionary.TryGetValue(typeName, out value))
				{
					return CallRegisterMethodByIndex(arguments, value);
				}
			}
			return false;
		}

		private static bool CallRegisterMethodByIndex(JniNativeMethodRegistrationArguments arguments, int? typeIdx)
		{
			return false;
		}
	}

	private bool jniAddNativeMethodRegistrationAttributePresent;

	private static MethodInfo? dynamic_callback_gen;

	private static List<JniNativeMethodRegistration> sharedRegistrations = new List<JniNativeMethodRegistration>();

	public AndroidTypeManager(bool jniAddNativeMethodRegistrationAttributePresent)
	{
		this.jniAddNativeMethodRegistrationAttributePresent = jniAddNativeMethodRegistrationAttributePresent;
	}

	protected override IEnumerable<Type> GetTypesForSimpleReference(string jniSimpleReference)
	{
		foreach (Type item in base.GetTypesForSimpleReference(jniSimpleReference))
		{
			yield return item;
		}
		Type javaToManagedType = Java.Interop.TypeManager.GetJavaToManagedType(jniSimpleReference);
		if (javaToManagedType != null)
		{
			yield return javaToManagedType;
		}
	}

	protected override string? GetSimpleReference(Type type)
	{
		string text = JNIEnv.TypemapManagedToJava(type);
		if (text != null)
		{
			return GetReplacementTypeCore(text) ?? text;
		}
		return null;
	}

	protected override IEnumerable<string> GetSimpleReferences(Type type)
	{
		string text = JNIEnv.TypemapManagedToJava(type);
		text = GetReplacementTypeCore(text) ?? text;
		if (text != null)
		{
			return new string[1] { text };
		}
		return Array.Empty<string>();
	}

	protected override IReadOnlyList<string>? GetStaticMethodFallbackTypesCore(string jniSimpleReference)
	{
		ReadOnlySpan<char> readOnlySpan = jniSimpleReference.AsSpan();
		int num = readOnlySpan.LastIndexOf('/');
		StringBuilder stringBuilder = new StringBuilder(jniSimpleReference.Length + "Desugar".Length);
		if (num > 0)
		{
			stringBuilder.Append(readOnlySpan.Slice(0, num + 1)).Append("Desugar").Append(readOnlySpan.Slice(num + 1));
		}
		else
		{
			stringBuilder.Append("Desugar").Append(readOnlySpan);
		}
		string text = stringBuilder.ToString();
		string text2 = jniSimpleReference + "$-CC";
		string[] array = new string[2]
		{
			GetReplacementTypeCore(text) ?? text,
			GetReplacementTypeCore(text2) ?? text2
		};
		if (Logger.LogAssembly)
		{
			string log = $"Remapping type `{jniSimpleReference}` to one one of {{ `{array[0]}`, `{array[1]}` }}";
			Logger.Log(LogLevel.Debug, "monodroid-assembly", log);
		}
		return array;
	}

	protected override string? GetReplacementTypeCore(string jniSimpleReference)
	{
		if (!JNIEnvInit.jniRemappingInUse)
		{
			return null;
		}
		nint num = RuntimeNativeMethods._monodroid_lookup_replacement_type(jniSimpleReference);
		if (num == IntPtr.Zero)
		{
			return null;
		}
		return Marshal.PtrToStringAnsi(num);
	}

	protected override JniRuntime.ReplacementMethodInfo? GetReplacementMethodInfoCore(string jniSourceType, string jniMethodName, string jniMethodSignature)
	{
		if (!JNIEnvInit.jniRemappingInUse)
		{
			return null;
		}
		nint num = RuntimeNativeMethods._monodroid_lookup_replacement_method_info(jniSourceType, jniMethodName, jniMethodSignature);
		if (num == IntPtr.Zero)
		{
			return null;
		}
		JniRemappingReplacementMethod jniRemappingReplacementMethod = default(JniRemappingReplacementMethod);
		jniRemappingReplacementMethod = Marshal.PtrToStructure<JniRemappingReplacementMethod>(num);
		string text = jniMethodSignature;
		int? num2 = null;
		if (jniRemappingReplacementMethod.is_static)
		{
			num2 = JniMemberSignature.GetParameterCountFromMethodSignature(jniMethodSignature) + 1;
			text = "(L" + jniSourceType + ";" + jniMethodSignature.Substring("(".Length);
		}
		if (Logger.LogAssembly)
		{
			string log = $"Remapping method `{jniSourceType}.{jniMethodName}{jniMethodSignature}` to `{jniRemappingReplacementMethod.target_type}.{jniRemappingReplacementMethod.target_name}{text}`; param-count: {num2}; instance-to-static? {jniRemappingReplacementMethod.is_static}";
			Logger.Log(LogLevel.Debug, "monodroid-assembly", log);
		}
		return new JniRuntime.ReplacementMethodInfo
		{
			SourceJniType = jniSourceType,
			SourceJniMethodName = jniMethodName,
			SourceJniMethodSignature = jniMethodSignature,
			TargetJniType = jniRemappingReplacementMethod.target_type,
			TargetJniMethodName = jniRemappingReplacementMethod.target_name,
			TargetJniMethodSignature = text,
			TargetJniMethodParameterCount = num2,
			TargetJniMethodInstanceToStatic = jniRemappingReplacementMethod.is_static
		};
	}

	[return: DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
	protected override Type? GetInvokerTypeCore([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] Type type)
	{
		if (type.IsInterface || type.IsAbstract)
		{
			return JavaObjectExtensions.GetInvokerType(type) ?? base.GetInvokerTypeCore(type);
		}
		return null;
	}

	[UnconditionalSuppressMessage("Trimming", "IL2026", Justification = "Mono.Android.Export.dll is preserved when [Export] is used via [DynamicDependency].")]
	[UnconditionalSuppressMessage("Trimming", "IL2075", Justification = "Mono.Android.Export.dll is preserved when [Export] is used via [DynamicDependency].")]
	private static Delegate CreateDynamicCallback(MethodInfo method)
	{
		if (dynamic_callback_gen == null)
		{
			Assembly assembly = Assembly.Load("Mono.Android.Export");
			if (assembly == null)
			{
				throw new InvalidOperationException("To use methods marked with ExportAttribute, Mono.Android.Export.dll needs to be referenced in the application");
			}
			Type? type = assembly.GetType("Java.Interop.DynamicCallbackCodeGenerator");
			if (type == null)
			{
				throw new InvalidOperationException("The referenced Mono.Android.Export.dll does not match the expected version. The required type was not found.");
			}
			dynamic_callback_gen = type.GetMethod("Create");
			if (dynamic_callback_gen == null)
			{
				throw new InvalidOperationException("The referenced Mono.Android.Export.dll does not match the expected version. The required method was not found.");
			}
		}
		return (Delegate)dynamic_callback_gen.Invoke(null, new object[1] { method });
	}

	private static bool FastRegisterNativeMembers(JniType nativeClass, Type type, ReadOnlySpan<char> methods)
	{
		if (!MagicRegistrationMap.Filled)
		{
			return false;
		}
		bool lockTaken = false;
		bool result = false;
		try
		{
			Monitor.TryEnter(sharedRegistrations, ref lockTaken);
			List<JniNativeMethodRegistration> list;
			if (lockTaken)
			{
				sharedRegistrations.Clear();
				list = sharedRegistrations;
			}
			else
			{
				list = new List<JniNativeMethodRegistration>();
			}
			result = MagicRegistrationMap.CallRegisterMethod(new JniNativeMethodRegistrationArguments(list, methods.ToString()), type.FullName);
			if (list.Count > 0)
			{
				nativeClass.RegisterNativeMethods(list.ToArray());
			}
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(sharedRegistrations);
			}
		}
		return result;
	}

	[Obsolete("Use RegisterNativeMembers(JniType, Type, ReadOnlySpan<char>) instead.")]
	public override void RegisterNativeMembers(JniType nativeClass, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.NonPublicNestedTypes)] Type type, string? methods)
	{
		RegisterNativeMembers(nativeClass, type, methods.AsSpan());
	}

	[UnconditionalSuppressMessage("Trimming", "IL2057", Justification = "Type.GetType() can never statically know the string value parsed from parameter 'methods'.")]
	[UnconditionalSuppressMessage("Trimming", "IL2067", Justification = "Delegate.CreateDelegate() can never statically know the string value parsed from parameter 'methods'.")]
	[UnconditionalSuppressMessage("Trimming", "IL2072", Justification = "Delegate.CreateDelegate() can never statically know the string value parsed from parameter 'methods'.")]
	public override void RegisterNativeMembers(JniType nativeClass, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.NonPublicNestedTypes)] Type type, ReadOnlySpan<char> methods)
	{
		try
		{
			if (methods.IsEmpty)
			{
				if (jniAddNativeMethodRegistrationAttributePresent)
				{
					base.RegisterNativeMembers(nativeClass, type, methods.ToString());
				}
			}
			else
			{
				if (FastRegisterNativeMembers(nativeClass, type, methods))
				{
					return;
				}
				int num = CountMethods(methods);
				if (num < 1)
				{
					if (jniAddNativeMethodRegistrationAttributePresent)
					{
						base.RegisterNativeMembers(nativeClass, type, methods.ToString());
					}
					return;
				}
				JniNativeMethodRegistration[] array = new JniNativeMethodRegistration[num];
				int numMethods = 0;
				MethodInfo[] array2 = null;
				ReadOnlySpan<char> span = methods;
				bool flag = false;
				while (!span.IsEmpty)
				{
					int num2 = span.IndexOf('\n');
					ReadOnlySpan<char> methodLine = span.Slice(0, (num2 != -1) ? num2 : span.Length);
					if (!methodLine.IsEmpty)
					{
						SplitMethodLine(methodLine, out var name, out var signature, out var callback, out var callbackDeclaringType);
						Delegate obj = null;
						if (callback.SequenceEqual("__export__".AsSpan()))
						{
							ReadOnlySpan<char> span2 = name.Slice(2);
							MethodInfo methodInfo = null;
							if (array2 == null)
							{
								array2 = type.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
							}
							MethodInfo[] array3 = array2;
							foreach (MethodInfo methodInfo2 in array3)
							{
								if (span2.SequenceEqual(methodInfo2.Name.AsSpan()) && signature.SequenceEqual(JavaNativeTypeManager.GetJniSignature(methodInfo2).AsSpan()))
								{
									methodInfo = methodInfo2;
									break;
								}
							}
							if (methodInfo == null)
							{
								throw new InvalidOperationException(FormattableString.Invariant($"Specified managed method '{span2.ToString()}' was not found. Signature: {signature.ToString()}"));
							}
							obj = CreateDynamicCallback(methodInfo);
							flag = true;
						}
						else
						{
							Type type2 = type;
							if (!callbackDeclaringType.IsEmpty)
							{
								type2 = Type.GetType(callbackDeclaringType.ToString(), throwOnError: true);
							}
							while (type2.ContainsGenericParameters)
							{
								type2 = type2.BaseType;
							}
							obj = ((GetCallbackHandler)Delegate.CreateDelegate(typeof(GetCallbackHandler), type2, callback.ToString()))();
						}
						if ((object)obj != null)
						{
							flag = true;
							array[numMethods++] = new JniNativeMethodRegistration(name.ToString(), signature.ToString(), obj);
						}
					}
					span = ((num2 != -1) ? span.Slice(num2 + 1) : default(ReadOnlySpan<char>));
				}
				if (flag)
				{
					JniEnvironment.Types.RegisterNatives(nativeClass.PeerReference, array, numMethods);
				}
			}
		}
		catch (Exception pendingException)
		{
			JniEnvironment.Runtime.RaisePendingException(pendingException);
		}
	}

	private static int CountMethods(ReadOnlySpan<char> methodsSpan)
	{
		int num = 0;
		while (!methodsSpan.IsEmpty)
		{
			num++;
			int num2 = methodsSpan.IndexOf('\n');
			methodsSpan = ((num2 != -1) ? methodsSpan.Slice(num2 + 1) : default(ReadOnlySpan<char>));
		}
		return num;
	}

	private static void SplitMethodLine(ReadOnlySpan<char> methodLine, out ReadOnlySpan<char> name, out ReadOnlySpan<char> signature, out ReadOnlySpan<char> callback, out ReadOnlySpan<char> callbackDeclaringType)
	{
		int num = methodLine.IndexOf(':');
		name = methodLine.Slice(0, num);
		methodLine = methodLine.Slice(num + 1);
		num = methodLine.IndexOf(':');
		signature = methodLine.Slice(0, num);
		methodLine = methodLine.Slice(num + 1);
		num = methodLine.IndexOf(':');
		callback = methodLine.Slice(0, (num != -1) ? num : methodLine.Length);
		callbackDeclaringType = ((num != -1) ? methodLine.Slice(num + 1) : default(ReadOnlySpan<char>));
	}
}
