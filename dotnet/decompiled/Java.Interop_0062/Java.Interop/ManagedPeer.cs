using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace Java.Interop;

[JniTypeSignature("net/dot/jni/ManagedPeer", GenerateJavaPeer = false)]
internal sealed class ManagedPeer : JavaObject
{
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	private delegate void ConstructMarshalMethod(nint jnienv, nint klass, nint n_self, nint n_constructorSignature, nint n_constructorArguments);

	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	private delegate void RegisterMarshalMethod(nint jnienv, nint klass, nint n_nativeClass, nint n_methods);

	private static readonly JniPeerMembers _members;

	private static Dictionary<string, ConstructorInfo?> ConstructorCache;

	static ManagedPeer()
	{
		_members = new JniPeerMembers("net/dot/jni/ManagedPeer", typeof(ManagedPeer));
		ConstructorCache = new Dictionary<string, ConstructorInfo>();
		_members.JniPeerType.RegisterNativeMethods(new JniNativeMethodRegistration("construct", "(Ljava/lang/Object;Ljava/lang/String;[Ljava/lang/Object;)V", new ConstructMarshalMethod(Construct)), new JniNativeMethodRegistration("registerNativeMembers", "(Ljava/lang/Class;Ljava/lang/String;)V", new RegisterMarshalMethod(RegisterNativeMembers)));
	}

	internal static void Init()
	{
	}

	private static void Construct(nint jnienv, nint klass, nint n_self, nint n_constructorSignature, nint n_constructorArguments)
	{
		JniTransition jniTransition = new JniTransition(jnienv);
		try
		{
			JniRuntime runtime = JniEnvironment.Runtime;
			JniObjectReference jniObjectReference = new JniObjectReference(n_self);
			IJavaPeerable javaPeerable = runtime.ValueManager.PeekPeer(jniObjectReference);
			if (javaPeerable != null)
			{
				JniManagedPeerStates jniManagedPeerState = javaPeerable.JniManagedPeerState;
				if ((jniManagedPeerState & JniManagedPeerStates.Activatable) != JniManagedPeerStates.Activatable && (jniManagedPeerState & JniManagedPeerStates.Replaceable) != JniManagedPeerStates.Replaceable)
				{
					return;
				}
			}
			if (JniEnvironment.WithinNewObjectScope)
			{
				if (runtime.ObjectReferenceManager.LogGlobalReferenceMessages)
				{
					runtime.ObjectReferenceManager.WriteGlobalReferenceLine("Warning: Skipping managed constructor invocation for PeerReference={0} IdentityHashCode=0x{1} Java.Type={2}. Please use JniPeerMembers.InstanceMethods.StartCreateInstance() + JniPeerMembers.InstanceMethods.FinishCreateInstance() instead of JniEnvironment.Object.NewObject().", jniObjectReference, runtime.ValueManager.GetJniIdentityHashCode(jniObjectReference).ToString("x"), JniEnvironment.Types.GetJniTypeNameFromInstance(jniObjectReference));
				}
				return;
			}
			JniTypeSignature typeSignature = new JniTypeSignature(JniEnvironment.Types.GetJniTypeNameFromInstance(jniObjectReference));
			Type typeFromSignature = GetTypeFromSignature(runtime.TypeManager, typeSignature);
			if (typeFromSignature.IsGenericTypeDefinition)
			{
				throw new NotSupportedException("Constructing instances of generic types from Java is not supported, as the type parameters cannot be determined.", CreateJniLocationException());
			}
			string signature = JniEnvironment.Strings.ToString(n_constructorSignature) ?? "()V";
			ConstructorInfo constructorInfo = GetConstructor(typeFromSignature, typeSignature.SimpleReference, signature) ?? throw CreateMissingConstructorException(typeFromSignature, signature);
			object[] values = GetValues(runtime, new JniObjectReference(n_constructorArguments), constructorInfo);
			if (javaPeerable != null)
			{
				constructorInfo.Invoke(javaPeerable, values);
			}
			else
			{
				JniEnvironment.Runtime.ValueManager.ActivatePeer(javaPeerable, new JniObjectReference(n_self), constructorInfo, values);
			}
		}
		catch (Exception ex) when (JniEnvironment.Runtime.ExceptionShouldTransitionToJni(ex))
		{
			jniTransition.SetPendingException(ex);
		}
		finally
		{
			jniTransition.Dispose();
		}
	}

	private static Exception CreateMissingConstructorException(Type type, string signature)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Unable to find constructor for type `");
		stringBuilder.Append(type.FullName);
		stringBuilder.Append("` with JNI signature `");
		stringBuilder.Append(signature);
		stringBuilder.Append("`. Please provide the missing constructor.");
		return new NotSupportedException(stringBuilder.ToString(), CreateJniLocationException());
	}

	private static Exception CreateJniLocationException()
	{
		using JavaException ex = new JavaException();
		return new JniLocationException(ex.ToString());
	}

	private static ConstructorInfo? GetConstructor([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] Type type, string jniTypeName, string signature)
	{
		string text = jniTypeName + "." + signature;
		lock (ConstructorCache)
		{
			if (ConstructorCache.TryGetValue(text, out ConstructorInfo value))
			{
				return value;
			}
		}
		List<Type>[] constructorCandidateParameterTypes = GetConstructorCandidateParameterTypes(signature);
		if (constructorCandidateParameterTypes.Length == 0)
		{
			return CacheConstructor(text, type.GetConstructor(Array.Empty<Type>()));
		}
		List<ConstructorInfo> list = new List<ConstructorInfo>(type.GetConstructors(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
		for (int num = list.Count; num > 0; num--)
		{
			if (list[num - 1].GetParameters().Length != constructorCandidateParameterTypes.Length)
			{
				list.RemoveAt(num - 1);
			}
		}
		for (int num2 = list.Count; num2 > 0; num2--)
		{
			ParameterInfo[] parameters = list[num2 - 1].GetParameters();
			for (int i = 0; i < parameters.Length; i++)
			{
				if (!constructorCandidateParameterTypes[i].Contains(parameters[i].ParameterType))
				{
					list.RemoveAt(num2 - 1);
					break;
				}
			}
		}
		if (list.Count == 0)
		{
			return CacheConstructor(text, null);
		}
		if (list.Count != 1)
		{
			StringBuilder stringBuilder = new StringBuilder($"Found {list.Count} constructors matching JNI signature {signature}:").Append("\n");
			foreach (ConstructorInfo item in list)
			{
				stringBuilder.Append("  ").Append(item).Append("\n");
			}
			throw new NotSupportedException(stringBuilder.ToString(), CreateJniLocationException());
		}
		return CacheConstructor(text, list[0]);
	}

	private static ConstructorInfo? CacheConstructor(string cacheKey, ConstructorInfo? ctor)
	{
		lock (ConstructorCache)
		{
			if (ConstructorCache.TryGetValue(cacheKey, out ConstructorInfo value))
			{
				return value;
			}
			ConstructorCache.Add(cacheKey, ctor);
			return ctor;
		}
	}

	private static List<Type>[] GetConstructorCandidateParameterTypes(string signature)
	{
		int parameterCountFromMethodSignature = JniMemberSignature.GetParameterCountFromMethodSignature(signature);
		if (parameterCountFromMethodSignature == 0)
		{
			return Array.Empty<List<Type>>();
		}
		JniRuntime.JniTypeManager typeManager = JniEnvironment.Runtime.TypeManager;
		List<Type>[] array = new List<Type>[parameterCountFromMethodSignature];
		int num = 0;
		foreach (JniTypeSignature item in JniMemberSignature.GetParameterTypesFromMethodSignature(signature))
		{
			List<Type> list = new List<Type>(typeManager.GetTypes(item));
			if (list.Count == 0)
			{
				throw new NotSupportedException($"Could not find System.Type corresponding to Java type `{item}` within constructor signature `{signature}`.", CreateJniLocationException());
			}
			array[num++] = list;
		}
		return array;
	}

	private static object?[]? GetValues(JniRuntime runtime, JniObjectReference values, ConstructorInfo cinfo)
	{
		if (!values.IsValid)
		{
			return null;
		}
		ParameterInfo[] parameters = cinfo.GetParameters();
		int arrayLength = JniEnvironment.Arrays.GetArrayLength(values);
		object[] array = new object[arrayLength];
		for (int i = 0; i < arrayLength; i++)
		{
			JniObjectReference value = JniEnvironment.Arrays.GetObjectArrayElement(values, i);
			object obj = ValueManagerGetValue(runtime, ref value, parameters[i]);
			array[i] = obj;
		}
		return array;
		[UnconditionalSuppressMessage("Trimming", "IL2072", Justification = "Constructors are preserved by the MarkJavaObjects trimmer step.")]
		static object? ValueManagerGetValue(JniRuntime jniRuntime, ref JniObjectReference reference, ParameterInfo parameter)
		{
			return jniRuntime.ValueManager.GetValue(ref reference, JniObjectReferenceOptions.CopyAndDispose, parameter.ParameterType);
		}
	}

	private unsafe static void RegisterNativeMembers(nint jnienv, nint klass, nint n_nativeClass, nint n_methods)
	{
		JniTransition jniTransition = new JniTransition(jnienv);
		try
		{
			JniObjectReference peerReference = new JniObjectReference(n_nativeClass);
			JniType jniType = new JniType(ref peerReference, JniObjectReferenceOptions.Copy);
			JniObjectReference stringInstance = new JniObjectReference(n_methods);
			Type type = GetTypeFromSignature(typeSignature: new JniTypeSignature(jniType.Name), typeManager: JniEnvironment.Runtime.TypeManager);
			int stringLength = JniEnvironment.Strings.GetStringLength(stringInstance);
			char* stringChars = JniEnvironment.Strings.GetStringChars(stringInstance, null);
			ReadOnlySpan<char> methods = new ReadOnlySpan<char>(stringChars, stringLength);
			try
			{
				JniEnvironment.Runtime.TypeManager.RegisterNativeMembers(jniType, type, methods);
			}
			finally
			{
				JniEnvironment.Strings.ReleaseStringChars(stringInstance, stringChars);
			}
		}
		catch (Exception ex) when (JniEnvironment.Runtime.ExceptionShouldTransitionToJni(ex))
		{
			jniTransition.SetPendingException(ex);
		}
		finally
		{
			jniTransition.Dispose();
		}
	}

	[return: DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.NonPublicNestedTypes)]
	private static Type GetTypeFromSignature(JniRuntime.JniTypeManager typeManager, JniTypeSignature typeSignature, string? context = null)
	{
		return typeManager.GetType(typeSignature) ?? throw new NotSupportedException($"Could not find System.Type corresponding to Java type {typeSignature} {((context == null) ? "" : ("within `" + context + "`"))}.");
	}
}
