using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

namespace Java.Interop;

public class JniRuntime : IDisposable
{
	public class JniTypeManager : IDisposable, ISetRuntime
	{
		private readonly struct JniPrimitiveArrayInfo
		{
			public readonly JniTypeSignature JniTypeSignature;

			public readonly Type PrimitiveType;

			public readonly Type[] ArrayTypes;

			public JniPrimitiveArrayInfo(string jniSimpleReference, Type primitiveType, params Type[] arrayTypes)
			{
				JniTypeSignature = new JniTypeSignature(jniSimpleReference, 1, keyword: true);
				PrimitiveType = primitiveType;
				ArrayTypes = arrayTypes;
			}
		}

		private static readonly JniPrimitiveArrayInfo[] JniPrimitiveArrayTypes = new JniPrimitiveArrayInfo[8]
		{
			new JniPrimitiveArrayInfo("Z", typeof(bool), typeof(bool[]), typeof(JavaArray<bool>), typeof(JavaPrimitiveArray<bool>), typeof(JavaBooleanArray)),
			new JniPrimitiveArrayInfo("B", typeof(sbyte), typeof(sbyte[]), typeof(JavaArray<sbyte>), typeof(JavaPrimitiveArray<sbyte>), typeof(JavaSByteArray)),
			new JniPrimitiveArrayInfo("C", typeof(char), typeof(char[]), typeof(JavaArray<char>), typeof(JavaPrimitiveArray<char>), typeof(JavaCharArray)),
			new JniPrimitiveArrayInfo("S", typeof(short), typeof(short[]), typeof(JavaArray<short>), typeof(JavaPrimitiveArray<short>), typeof(JavaInt16Array)),
			new JniPrimitiveArrayInfo("I", typeof(int), typeof(int[]), typeof(JavaArray<int>), typeof(JavaPrimitiveArray<int>), typeof(JavaInt32Array)),
			new JniPrimitiveArrayInfo("J", typeof(long), typeof(long[]), typeof(JavaArray<long>), typeof(JavaPrimitiveArray<long>), typeof(JavaInt64Array)),
			new JniPrimitiveArrayInfo("F", typeof(float), typeof(float[]), typeof(JavaArray<float>), typeof(JavaPrimitiveArray<float>), typeof(JavaSingleArray)),
			new JniPrimitiveArrayInfo("D", typeof(double), typeof(double[]), typeof(JavaArray<double>), typeof(JavaPrimitiveArray<double>), typeof(JavaDoubleArray))
		};

		private JniRuntime? runtime;

		private bool disposed;

		private static readonly string[] EmptyStringArray = Array.Empty<string>();

		private static readonly Type[] EmptyTypeArray = Array.Empty<Type>();

		private static Type[] registerMethodParameters = new Type[1] { typeof(JniNativeMethodRegistrationArguments) };

		private static List<JniNativeMethodRegistration> sharedRegistrations = new List<JniNativeMethodRegistration>();

		public JniRuntime Runtime => runtime ?? throw new NotSupportedException();

		private static bool GetBuiltInTypeArraySignature(Type type, ref JniTypeSignature signature)
		{
			JniPrimitiveArrayInfo[] jniPrimitiveArrayTypes = JniPrimitiveArrayTypes;
			for (int i = 0; i < jniPrimitiveArrayTypes.Length; i++)
			{
				JniPrimitiveArrayInfo jniPrimitiveArrayInfo = jniPrimitiveArrayTypes[i];
				if (Array.IndexOf(jniPrimitiveArrayInfo.ArrayTypes, type) >= 0)
				{
					signature = jniPrimitiveArrayInfo.JniTypeSignature;
					return true;
				}
			}
			signature = default(JniTypeSignature);
			return false;
		}

		public virtual void OnSetRuntime(JniRuntime runtime)
		{
			AssertValid();
			this.runtime = runtime;
		}

		public void Dispose()
		{
			Dispose(disposing: false);
		}

		protected virtual void Dispose(bool disposing)
		{
			disposed = true;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void AssertValid()
		{
			if (!disposed)
			{
				return;
			}
			throw new ObjectDisposedException("JniTypeManager");
		}

		internal static void AssertSimpleReference(string jniSimpleReference, string argumentName = "jniSimpleReference")
		{
			if (string.IsNullOrEmpty(jniSimpleReference))
			{
				throw new ArgumentNullException(argumentName);
			}
			if (jniSimpleReference.IndexOf('.') >= 0)
			{
				throw new ArgumentException("JNI type names do not contain '.', they use '/'. Are you sure you're using a JNI type name?", argumentName);
			}
			switch (jniSimpleReference[0])
			{
			case '[':
				throw new ArgumentException("Arrays cannot be present in simplified type references.", argumentName);
			case 'L':
				if (jniSimpleReference[jniSimpleReference.Length - 1] == ';')
				{
					throw new ArgumentException("JNI type references are not supported.", argumentName);
				}
				break;
			}
		}

		public JniTypeSignature GetTypeSignature(Type type)
		{
			AssertValid();
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			type = GetUnderlyingType(type, out var rank);
			JniTypeSignature signature = JniTypeSignature.Empty;
			if (GetBuiltInTypeSignature(type, ref signature))
			{
				return signature.AddArrayRank(rank);
			}
			if (GetBuiltInTypeArraySignature(type, ref signature))
			{
				return signature.AddArrayRank(rank);
			}
			bool isGenericType = type.IsGenericType;
			Type type2 = (isGenericType ? type.GetGenericTypeDefinition() : type);
			if (isGenericType)
			{
				if (type2 == typeof(JavaArray<>) || type2 == typeof(JavaObjectArray<>))
				{
					return GetTypeSignature(type.GenericTypeArguments[0]).AddArrayRank(rank + 1);
				}
				string simpleReference = GetSimpleReference(type2);
				if (simpleReference != null)
				{
					return new JniTypeSignature(simpleReference, rank);
				}
			}
			string simpleReference2 = GetSimpleReference(type);
			if (simpleReference2 != null)
			{
				return new JniTypeSignature(simpleReference2, rank);
			}
			return default(JniTypeSignature);
		}

		private static Type GetUnderlyingType(Type type, out int rank)
		{
			rank = 0;
			Type type2 = type;
			while (type.IsArray)
			{
				if (type.IsArray && type.GetArrayRank() > 1)
				{
					throw new ArgumentException("Multidimensional array '" + type2.FullName + "' is not supported.", "type");
				}
				rank++;
				type = type.GetElementType();
			}
			if (type.IsEnum)
			{
				type = Enum.GetUnderlyingType(type);
			}
			return type;
		}

		protected virtual string? GetSimpleReference(Type type)
		{
			return GetSimpleReferences(type).FirstOrDefault();
		}

		protected virtual IEnumerable<string> GetSimpleReferences(Type type)
		{
			AssertValid();
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			if (type.IsArray)
			{
				throw new ArgumentException("Array type '" + type.FullName + "' is not supported.", "type");
			}
			JniTypeSignatureAttribute customAttribute = type.GetCustomAttribute<JniTypeSignatureAttribute>(inherit: false);
			if (customAttribute != null)
			{
				string replacementType = GetReplacementType(customAttribute.SimpleReference);
				if (replacementType != null)
				{
					yield return replacementType;
				}
				else
				{
					yield return customAttribute.SimpleReference;
				}
			}
		}

		[UnconditionalSuppressMessage("Trimming", "IL3050", Justification = "This code path is not used in Android projects.")]
		private static Type MakeArrayType(Type type)
		{
			return type.MakeArrayType();
		}

		[UnconditionalSuppressMessage("Trimming", "IL2055", Justification = "This code path is not used in Android projects.")]
		[UnconditionalSuppressMessage("Trimming", "IL3050", Justification = "This code path is not used in Android projects.")]
		private static Type MakeGenericType(Type type, Type arrayType)
		{
			return type.MakeGenericType(arrayType);
		}

		[UnconditionalSuppressMessage("Trimming", "IL2073", Justification = "Types returned here should be preserved via other means.")]
		[return: DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.NonPublicNestedTypes)]
		public Type? GetType(JniTypeSignature typeSignature)
		{
			AssertValid();
			return GetTypes(typeSignature).FirstOrDefault();
		}

		public virtual IEnumerable<Type> GetTypes(JniTypeSignature typeSignature)
		{
			AssertValid();
			if (typeSignature.SimpleReference == null)
			{
				return EmptyTypeArray;
			}
			return CreateGetTypesEnumerator(typeSignature);
		}

		private IEnumerable<Type> CreateGetTypesEnumerator(JniTypeSignature typeSignature)
		{
			if (!typeSignature.IsValid)
			{
				yield break;
			}
			foreach (Type type in GetTypesForSimpleReference(typeSignature.SimpleReference ?? throw new InvalidOperationException("Should not be reached")))
			{
				if (typeSignature.ArrayRank == 0)
				{
					yield return type;
					continue;
				}
				if (typeSignature.IsKeyword)
				{
					foreach (Type item in GetPrimitiveArrayTypesForSimpleReference(typeSignature, type))
					{
						yield return item;
					}
					continue;
				}
				if (typeSignature.ArrayRank > 0)
				{
					int arrayRank = typeSignature.ArrayRank;
					Type type2 = type;
					while (arrayRank-- > 0)
					{
						type2 = MakeGenericType(typeof(JavaObjectArray<>), type2);
					}
					yield return type2;
				}
				if (typeSignature.ArrayRank > 0)
				{
					int arrayRank2 = typeSignature.ArrayRank;
					Type type3 = type;
					while (arrayRank2-- > 0)
					{
						type3 = MakeArrayType(type3);
					}
					yield return type3;
				}
			}
		}

		private IEnumerable<Type> GetPrimitiveArrayTypesForSimpleReference(JniTypeSignature typeSignature, Type type)
		{
			int num = -1;
			for (int i = 0; i < JniPrimitiveArrayTypes.Length; i++)
			{
				if (JniPrimitiveArrayTypes[i].PrimitiveType == type)
				{
					num = i;
					break;
				}
			}
			if (num == -1)
			{
				throw new InvalidOperationException($"Should not be reached; Could not find JniPrimitiveArrayInfo for {type}");
			}
			Type[] arrayTypes = JniPrimitiveArrayTypes[num].ArrayTypes;
			foreach (Type t in arrayTypes)
			{
				int num2 = typeSignature.ArrayRank - 1;
				Type type2 = t;
				while (num2-- > 0)
				{
					type2 = MakeGenericType(typeof(JavaObjectArray<>), type2);
				}
				yield return type2;
				num2 = typeSignature.ArrayRank - 1;
				type2 = t;
				while (num2-- > 0)
				{
					type2 = MakeArrayType(type2);
				}
				yield return type2;
			}
		}

		protected virtual IEnumerable<Type> GetTypesForSimpleReference(string jniSimpleReference)
		{
			AssertValid();
			AssertSimpleReference(jniSimpleReference);
			return CreateGetTypesForSimpleReferenceEnumerator(jniSimpleReference);
		}

		private IEnumerable<Type> CreateGetTypesForSimpleReferenceEnumerator(string jniSimpleReference)
		{
			if (JniBuiltinSimpleReferenceToType.Value.TryGetValue(jniSimpleReference, out Type value))
			{
				yield return value;
			}
		}

		[return: DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
		public Type? GetInvokerType([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] Type type)
		{
			if (type.IsAbstract || type.IsInterface)
			{
				return GetInvokerTypeCore(type);
			}
			return null;
		}

		[return: DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
		protected virtual Type? GetInvokerTypeCore([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] Type type)
		{
			JniTypeSignatureAttribute customAttribute = type.GetCustomAttribute<JniTypeSignatureAttribute>();
			if (customAttribute == null || customAttribute.InvokerType == null)
			{
				return null;
			}
			Type[] genericArguments = type.GetGenericArguments();
			if (genericArguments.Length == 0)
			{
				return customAttribute.InvokerType;
			}
			return MakeGenericType(customAttribute.InvokerType, genericArguments);
			[UnconditionalSuppressMessage("Trimming", "IL2055", Justification = "Generic 'Invoker' types are preserved by the MarkJavaObjects trimmer step.")]
			[UnconditionalSuppressMessage("Trimming", "IL3050", Justification = "Generic 'Invoker' types are preserved by the MarkJavaObjects trimmer step.")]
			[return: DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
			static Type MakeGenericType([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] Type type2, Type[] arguments)
			{
				return type2.MakeGenericType(arguments);
			}
		}

		public IReadOnlyList<string>? GetStaticMethodFallbackTypes(string jniSimpleReference)
		{
			AssertValid();
			AssertSimpleReference(jniSimpleReference);
			return GetStaticMethodFallbackTypesCore(jniSimpleReference);
		}

		protected virtual IReadOnlyList<string>? GetStaticMethodFallbackTypesCore(string jniSimple)
		{
			return null;
		}

		public string? GetReplacementType(string jniSimpleReference)
		{
			AssertValid();
			AssertSimpleReference(jniSimpleReference);
			return GetReplacementTypeCore(jniSimpleReference);
		}

		protected virtual string? GetReplacementTypeCore(string jniSimpleReference)
		{
			return null;
		}

		public ReplacementMethodInfo? GetReplacementMethodInfo(string jniSimpleReference, string jniMethodName, string jniMethodSignature)
		{
			AssertValid();
			AssertSimpleReference(jniSimpleReference);
			if (string.IsNullOrEmpty(jniMethodName))
			{
				throw new ArgumentNullException("jniMethodName");
			}
			if (string.IsNullOrEmpty(jniMethodSignature))
			{
				throw new ArgumentNullException("jniMethodSignature");
			}
			return GetReplacementMethodInfoCore(jniSimpleReference, jniMethodName, jniMethodSignature);
		}

		protected virtual ReplacementMethodInfo? GetReplacementMethodInfoCore(string jniSimpleReference, string jniMethodName, string jniMethodSignature)
		{
			return null;
		}

		public virtual void RegisterNativeMembers(JniType nativeClass, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.NonPublicNestedTypes)] Type type, ReadOnlySpan<char> methods)
		{
			TryRegisterNativeMembers(nativeClass, type, methods);
		}

		protected bool TryRegisterNativeMembers(JniType nativeClass, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.NonPublicNestedTypes)] Type type, ReadOnlySpan<char> methods)
		{
			AssertValid();
			methods = methods;
			if (!TryLoadJniMarshalMethods(nativeClass, type, null))
			{
				return TryRegisterNativeMembers(nativeClass, type, null, null);
			}
			return true;
		}

		[Obsolete("Use RegisterNativeMembers(JniType, Type, ReadOnlySpan<char>)")]
		public virtual void RegisterNativeMembers(JniType nativeClass, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.NonPublicNestedTypes)] Type type, string? methods)
		{
			TryRegisterNativeMembers(nativeClass, type, methods);
		}

		[Obsolete("Use RegisterNativeMembers(JniType, Type, ReadOnlySpan<char>)")]
		protected bool TryRegisterNativeMembers(JniType nativeClass, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.NonPublicNestedTypes)] Type type, string? methods)
		{
			AssertValid();
			if (!TryLoadJniMarshalMethods(nativeClass, type, methods))
			{
				return TryRegisterNativeMembers(nativeClass, type, methods, null);
			}
			return true;
		}

		[UnconditionalSuppressMessage("Trimming", "IL2072", Justification = "'jni_marshal_methods' is preserved by the PreserveRegistrations trimmer step.")]
		[UnconditionalSuppressMessage("Trimming", "IL2075", Justification = "'jni_marshal_methods' is preserved by the PreserveRegistrations trimmer step.")]
		private bool TryLoadJniMarshalMethods(JniType nativeClass, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.NonPublicNestedTypes)] Type type, string? methods)
		{
			Type type2 = type?.GetNestedType("__<$>_jni_marshal_methods", BindingFlags.NonPublic);
			if (type2 == null)
			{
				return false;
			}
			MethodInfo method = type2.GetMethod("__RegisterNativeMembers", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, (CallingConventions)0, registerMethodParameters, null);
			return TryRegisterNativeMembers(nativeClass, type2, methods, method);
		}

		private bool TryRegisterNativeMembers(JniType nativeClass, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods)] Type marshalType, string? methods, MethodInfo? registerMethod)
		{
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
				JniNativeMethodRegistrationArguments jniNativeMethodRegistrationArguments = new JniNativeMethodRegistrationArguments(list, methods);
				if (registerMethod != null)
				{
					registerMethod.Invoke(null, new object[1] { jniNativeMethodRegistrationArguments });
					result = true;
				}
				else
				{
					result = FindAndCallRegisterMethod(marshalType, jniNativeMethodRegistrationArguments);
				}
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

		private bool FindAndCallRegisterMethod([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods)] Type marshalType, JniNativeMethodRegistrationArguments arguments)
		{
			if (!Runtime.JniAddNativeMethodRegistrationAttributePresent)
			{
				return false;
			}
			bool result = false;
			foreach (MethodInfo runtimeMethod in marshalType.GetRuntimeMethods())
			{
				if (runtimeMethod.GetCustomAttribute(typeof(JniAddNativeMethodRegistrationAttribute)) != null)
				{
					string value = runtimeMethod.DeclaringType?.FullName ?? "<no-decl-type>";
					if ((runtimeMethod.Attributes & MethodAttributes.Static) != MethodAttributes.Static)
					{
						throw new InvalidOperationException($"The method `{value}.{runtimeMethod}` marked with [{"JniAddNativeMethodRegistrationAttribute"}] must be static!");
					}
					((Action<JniNativeMethodRegistrationArguments>)runtimeMethod.CreateDelegate(typeof(Action<JniNativeMethodRegistrationArguments>)))(arguments);
					result = true;
				}
			}
			return result;
		}
	}

	public abstract class JniValueManager : ISetRuntime, IDisposable
	{
		private JniRuntime? runtime;

		private bool disposed;

		private static readonly Type ByRefJniObjectReference = typeof(JniObjectReference).MakeByRefType();

		private static readonly Type[] JIConstructorSignature = new Type[2]
		{
			ByRefJniObjectReference,
			typeof(JniObjectReferenceOptions)
		};

		private Dictionary<Type, JniValueMarshaler> Marshalers = new Dictionary<Type, JniValueMarshaler>();

		public JniRuntime Runtime => runtime ?? throw new NotSupportedException();

		public virtual void OnSetRuntime(JniRuntime runtime)
		{
			if (disposed)
			{
				throw new ObjectDisposedException(GetType().Name);
			}
			this.runtime = runtime;
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			disposed = true;
		}

		public abstract void WaitForGCBridgeProcessing();

		public abstract void AddPeer(IJavaPeerable value);

		public abstract void RemovePeer(IJavaPeerable value);

		public abstract void FinalizePeer(IJavaPeerable value);

		public abstract void ActivatePeer(IJavaPeerable? self, JniObjectReference reference, ConstructorInfo cinfo, object?[]? argumentValues);

		public void ConstructPeer(IJavaPeerable peer, ref JniObjectReference reference, JniObjectReferenceOptions options)
		{
			if (peer == null)
			{
				throw new ArgumentNullException("peer");
			}
			JniObjectReference peerReference = peer.PeerReference;
			if (peerReference.IsValid)
			{
				JniObjectReference.Dispose(ref reference, options);
				if (peer.JniManagedPeerState.HasFlag(JniManagedPeerStates.Activatable))
				{
					return;
				}
				JniObjectReference reference2 = peerReference;
				peerReference = reference2.NewGlobalRef();
				JniObjectReference.Dispose(ref reference2);
			}
			else
			{
				if (options == JniObjectReferenceOptions.None)
				{
					return;
				}
				if (!reference.IsValid)
				{
					throw new ArgumentException("JNI Object Reference is invalid.", "reference");
				}
				peerReference = reference;
				if ((options & JniObjectReferenceOptions.Copy) == JniObjectReferenceOptions.Copy)
				{
					peerReference = reference.NewGlobalRef();
				}
				JniObjectReference.Dispose(ref reference, options);
			}
			peer.SetPeerReference(peerReference);
			peer.SetJniIdentityHashCode(JniSystem.IdentityHashCode(peerReference));
			JniObjectReferenceManager objectReferenceManager = Runtime.ObjectReferenceManager;
			if (objectReferenceManager.LogGlobalReferenceMessages)
			{
				objectReferenceManager.WriteGlobalReferenceLine("Created PeerReference={0} IdentityHashCode=0x{1} Instance=0x{2} Instance.Type={3}, Java.Type={4}", peerReference.ToString(), peer.JniIdentityHashCode.ToString("x"), RuntimeHelpers.GetHashCode(peer).ToString("x"), peer.GetType().FullName, JniEnvironment.Types.GetJniTypeNameFromInstance(peerReference));
			}
			if ((options & (JniObjectReferenceOptions)4) != (JniObjectReferenceOptions)4)
			{
				AddPeer(peer);
			}
		}

		public int GetJniIdentityHashCode(JniObjectReference reference)
		{
			return JniSystem.IdentityHashCode(reference);
		}

		public virtual void DisposePeer(IJavaPeerable value)
		{
			if (disposed)
			{
				throw new ObjectDisposedException(GetType().Name);
			}
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			if (value.PeerReference.IsValid)
			{
				value.Disposed();
				RemovePeer(value);
				JniObjectReference peerReference = value.PeerReference;
				if (peerReference.IsValid)
				{
					DisposePeer(peerReference, value);
				}
			}
		}

		private void DisposePeer(JniObjectReference h, IJavaPeerable value)
		{
			if (disposed)
			{
				throw new ObjectDisposedException(GetType().Name);
			}
			JniObjectReferenceManager objectReferenceManager = Runtime.ObjectReferenceManager;
			if (objectReferenceManager.LogGlobalReferenceMessages)
			{
				objectReferenceManager.WriteGlobalReferenceLine("Disposing PeerReference={0} IdentityHashCode=0x{1} Instance=0x{2} Instance.Type={3} Java.Type={4}", h.ToString(), value.JniIdentityHashCode.ToString("x"), RuntimeHelpers.GetHashCode(value).ToString("x"), value.GetType().ToString(), JniEnvironment.Types.GetJniTypeNameFromInstance(h));
			}
			JniObjectReference.Dispose(ref h);
			value.SetPeerReference(default(JniObjectReference));
			GC.SuppressFinalize(value);
		}

		public virtual void DisposePeerUnlessReferenced(IJavaPeerable value)
		{
			if (disposed)
			{
				throw new ObjectDisposedException(GetType().Name);
			}
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			JniObjectReference peerReference = value.PeerReference;
			if (peerReference.IsValid)
			{
				IJavaPeerable javaPeerable = PeekPeer(peerReference);
				if (javaPeerable == null || javaPeerable != value)
				{
					DisposePeer(peerReference, value);
				}
			}
		}

		public abstract IJavaPeerable? PeekPeer(JniObjectReference reference);

		public object? PeekValue(JniObjectReference reference)
		{
			if (disposed)
			{
				throw new ObjectDisposedException(GetType().Name);
			}
			if (!reference.IsValid)
			{
				return null;
			}
			IJavaPeerable javaPeerable = PeekPeer(reference);
			if (javaPeerable == null)
			{
				return javaPeerable;
			}
			if (!TryUnboxPeerObject(javaPeerable, out object result))
			{
				return javaPeerable;
			}
			return result;
		}

		protected virtual bool TryUnboxPeerObject(IJavaPeerable value, [NotNullWhen(true)] out object? result)
		{
			result = null;
			if (value is JavaProxyObject javaProxyObject)
			{
				result = javaProxyObject.Value;
				return true;
			}
			if (value is JavaProxyThrowable javaProxyThrowable)
			{
				result = javaProxyThrowable.Exception;
				return true;
			}
			return false;
		}

		[return: DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
		private static Type GetPeerType([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] Type type)
		{
			if (type == typeof(object))
			{
				return typeof(JavaObject);
			}
			if (type == typeof(IJavaPeerable))
			{
				return typeof(JavaObject);
			}
			if (type == typeof(Exception))
			{
				return typeof(JavaException);
			}
			return type;
		}

		public IJavaPeerable? GetPeer(JniObjectReference reference, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] Type? targetType = null)
		{
			if (disposed)
			{
				throw new ObjectDisposedException(GetType().Name);
			}
			if (!reference.IsValid)
			{
				return null;
			}
			IJavaPeerable javaPeerable = PeekPeer(reference);
			if (javaPeerable != null && (targetType == null || targetType.IsAssignableFrom(javaPeerable.GetType())))
			{
				return javaPeerable;
			}
			return CreatePeer(ref reference, JniObjectReferenceOptions.Copy, targetType);
		}

		public virtual IJavaPeerable? CreatePeer(ref JniObjectReference reference, JniObjectReferenceOptions transfer, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] Type? targetType)
		{
			if (disposed)
			{
				throw new ObjectDisposedException(GetType().Name);
			}
			if (!reference.IsValid)
			{
				return null;
			}
			targetType = targetType ?? typeof(JavaObject);
			targetType = GetPeerType(targetType);
			if (!typeof(IJavaPeerable).IsAssignableFrom(targetType))
			{
				throw new ArgumentException("targetType `" + targetType.AssemblyQualifiedName + "` must implement IJavaPeerable!", "targetType");
			}
			JniTypeSignature typeSignature = Runtime.TypeManager.GetTypeSignature(targetType);
			if (!typeSignature.IsValid || typeSignature.SimpleReference == null)
			{
				throw new ArgumentException("Could not determine Java type corresponding to `" + targetType.AssemblyQualifiedName + "`.", "targetType");
			}
			JniObjectReference reference2 = JniEnvironment.Types.GetObjectClass(reference);
			JniObjectReference reference3;
			try
			{
				reference3 = JniEnvironment.Types.FindClass(typeSignature.SimpleReference);
			}
			catch (Exception innerException)
			{
				JniObjectReference.Dispose(ref reference2);
				throw new ArgumentException("Could not find Java class `" + typeSignature.SimpleReference + "`.", "targetType", innerException);
			}
			if (!JniEnvironment.Types.IsAssignableFrom(reference2, reference3))
			{
				JniObjectReference.Dispose(ref reference2);
				JniObjectReference.Dispose(ref reference3);
				return null;
			}
			JniObjectReference.Dispose(ref reference3);
			IJavaPeerable? obj = CreatePeerInstance(ref reference2, targetType, ref reference, transfer) ?? throw new NotSupportedException($"Could not find an appropriate constructable wrapper type for Java type '{JniEnvironment.Types.GetJniTypeNameFromInstance(reference)}', targetType='{targetType}'.");
			obj.SetJniManagedPeerState(obj.JniManagedPeerState | JniManagedPeerStates.Replaceable);
			return obj;
		}

		private IJavaPeerable? CreatePeerInstance(ref JniObjectReference klass, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] Type targetType, ref JniObjectReference reference, JniObjectReferenceOptions transfer)
		{
			string text = JniEnvironment.Types.GetJniTypeNameFromClass(klass);
			while (text != null)
			{
				if (!JniTypeSignature.TryParse(text, out var result))
				{
					return null;
				}
				Type type = GetTypeAssignableTo(result, targetType);
				if (type != null)
				{
					IJavaPeerable javaPeerable = TryCreatePeerInstance(ref reference, transfer, type);
					if (javaPeerable != null)
					{
						JniObjectReference.Dispose(ref klass);
						return javaPeerable;
					}
				}
				JniObjectReference superclass = JniEnvironment.Types.GetSuperclass(klass);
				text = (superclass.IsValid ? JniEnvironment.Types.GetJniTypeNameFromClass(superclass) : null);
				JniObjectReference.Dispose(ref klass, JniObjectReferenceOptions.CopyAndDispose);
				klass = superclass;
			}
			JniObjectReference.Dispose(ref klass, JniObjectReferenceOptions.CopyAndDispose);
			return TryCreatePeerInstance(ref reference, transfer, targetType);
			[UnconditionalSuppressMessage("Trimming", "IL2073", Justification = "Types returned here should be preserved via other means.")]
			[return: DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
			Type? GetTypeAssignableTo(JniTypeSignature sig, Type type2)
			{
				foreach (Type type2 in Runtime.TypeManager.GetTypes(sig))
				{
					if (type2.IsAssignableFrom(type2))
					{
						return type2;
					}
				}
				return null;
			}
		}

		private IJavaPeerable? TryCreatePeerInstance(ref JniObjectReference reference, JniObjectReferenceOptions options, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] Type type)
		{
			type = Runtime.TypeManager.GetInvokerType(type) ?? type;
			IJavaPeerable javaPeerable = GetUninitializedObject(type);
			bool flag = false;
			try
			{
				flag = TryConstructPeer(javaPeerable, ref reference, options, type);
			}
			finally
			{
				if (!flag)
				{
					GC.SuppressFinalize(javaPeerable);
					javaPeerable = null;
				}
			}
			return javaPeerable;
			static IJavaPeerable GetUninitializedObject([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] Type type2)
			{
				IJavaPeerable obj = (IJavaPeerable)RuntimeHelpers.GetUninitializedObject(type2);
				obj.SetJniManagedPeerState(JniManagedPeerStates.Activatable | JniManagedPeerStates.Replaceable);
				return obj;
			}
		}

		protected virtual bool TryConstructPeer(IJavaPeerable self, ref JniObjectReference reference, JniObjectReferenceOptions options, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] Type type)
		{
			ConstructorInfo constructor = type.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, JIConstructorSignature, null);
			if (constructor != null)
			{
				object[] array = new object[2] { reference, options };
				constructor.Invoke(self, array);
				reference = (JniObjectReference)array[0];
				return true;
			}
			return false;
		}

		[return: DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
		internal Type? GetRuntimeType(JniObjectReference reference)
		{
			if (!reference.IsValid)
			{
				return null;
			}
			if (!JniTypeSignature.TryParse(JniEnvironment.Types.GetJniTypeNameFromInstance(reference), out var result))
			{
				return null;
			}
			return Runtime.TypeManager.GetType(result);
		}

		public object? GetValue(ref JniObjectReference reference, JniObjectReferenceOptions options, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] Type? targetType = null)
		{
			if (disposed)
			{
				throw new ObjectDisposedException(GetType().Name);
			}
			if (!reference.IsValid)
			{
				return null;
			}
			object obj = PeekValue(reference);
			if (obj != null && (targetType == null || targetType.IsAssignableFrom(obj.GetType())))
			{
				JniObjectReference.Dispose(ref reference, options);
				return obj;
			}
			if (targetType != null && typeof(IJavaPeerable).IsAssignableFrom(targetType))
			{
				return JavaPeerableValueMarshaler.Instance.CreateGenericValue(ref reference, options, targetType);
			}
			targetType = targetType ?? GetRuntimeType(reference);
			if (targetType == null)
			{
				return JavaPeerableValueMarshaler.Instance.CreateGenericValue(ref reference, options, targetType);
			}
			return GetValueMarshaler(targetType).CreateValue(ref reference, options, targetType);
		}

		[return: MaybeNull]
		public T GetValue<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] T>(ref JniObjectReference reference, JniObjectReferenceOptions options, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] Type? targetType = null)
		{
			if (!reference.IsValid)
			{
				return default(T);
			}
			if (targetType != null && !typeof(T).IsAssignableFrom(targetType))
			{
				throw new ArgumentException(string.Format("Requested runtime '{0}' value of '{1}' is not compatible with requested compile-time type T of '{2}'.", "targetType", targetType, typeof(T)), "targetType");
			}
			targetType = targetType ?? typeof(T);
			object obj = PeekValue(reference);
			if (obj != null && (targetType == null || targetType.IsAssignableFrom(obj.GetType())))
			{
				JniObjectReference.Dispose(ref reference, options);
				return (T)obj;
			}
			if (typeof(IJavaPeerable).IsAssignableFrom(targetType))
			{
				return (T)JavaPeerableValueMarshaler.Instance.CreateGenericValue(ref reference, options, targetType);
			}
			return GetValueMarshaler<T>().CreateGenericValue(ref reference, options, targetType);
		}

		public JniValueMarshaler<T> GetValueMarshaler<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] T>()
		{
			if (disposed)
			{
				throw new ObjectDisposedException(GetType().Name);
			}
			JniValueMarshaler valueMarshaler = GetValueMarshaler(typeof(T));
			if (valueMarshaler is JniValueMarshaler<T> result)
			{
				return result;
			}
			lock (Marshalers)
			{
				if (!Marshalers.TryGetValue(typeof(T), out JniValueMarshaler value))
				{
					Marshalers.Add(typeof(T), value = new DelegatingValueMarshaler<T>(valueMarshaler));
				}
				return (JniValueMarshaler<T>)value;
			}
		}

		public JniValueMarshaler GetValueMarshaler(Type type)
		{
			if (disposed)
			{
				throw new ObjectDisposedException(GetType().Name);
			}
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			if (type.ContainsGenericParameters)
			{
				throw new ArgumentException("Generic type definitions are not supported.", "type");
			}
			JniValueMarshalerAttribute customAttribute = type.GetCustomAttribute<JniValueMarshalerAttribute>();
			if (customAttribute != null)
			{
				return (JniValueMarshaler)Activator.CreateInstance(customAttribute.MarshalerType);
			}
			if (typeof(IJavaPeerable) == type)
			{
				return JavaPeerableValueMarshaler.Instance;
			}
			if (typeof(void) == type)
			{
				return VoidValueMarshaler.Instance;
			}
			KeyValuePair<Type, JniValueMarshaler>[] value = JniBuiltinMarshalers.Value;
			for (int i = 0; i < value.Length; i++)
			{
				KeyValuePair<Type, JniValueMarshaler> keyValuePair = value[i];
				if (keyValuePair.Key == type)
				{
					return keyValuePair.Value;
				}
			}
			Type listType = GetListType(type);
			if (listType != null)
			{
				Type type2 = listType.GenericTypeArguments[0];
				if (type2.IsValueType)
				{
					value = JniPrimitiveArrayMarshalers.Value;
					for (int i = 0; i < value.Length; i++)
					{
						KeyValuePair<Type, JniValueMarshaler> keyValuePair2 = value[i];
						if (type.IsAssignableFrom(keyValuePair2.Key))
						{
							return keyValuePair2.Value;
						}
					}
				}
				return GetObjectArrayMarshaler(type2);
			}
			if (typeof(IJavaPeerable).IsAssignableFrom(type))
			{
				return JavaPeerableValueMarshaler.Instance;
			}
			return GetValueMarshalerCore(type);
		}

		private static Type? GetListType(Type type)
		{
			foreach (Type item in GetInterfaces(type).Concat(new Type[1] { type }))
			{
				if (typeof(IList<>).IsAssignableFrom(item.IsGenericType ? item.GetGenericTypeDefinition() : item))
				{
					return item;
				}
			}
			return null;
			[UnconditionalSuppressMessage("Trimming", "IL2070", Justification = "We handle the case if IList<> is trimmed away")]
			static Type[] GetInterfaces(Type type2)
			{
				return type2.GetInterfaces();
			}
		}

		private static JniValueMarshaler GetObjectArrayMarshaler(Type elementType)
		{
			MethodInfo method = MakeGenericMethod(new Func<JniValueMarshaler>(GetObjectArrayMarshalerHelper<object>).Method.GetGenericMethodDefinition(), elementType);
			return ((Func<JniValueMarshaler>)Delegate.CreateDelegate(typeof(Func<JniValueMarshaler>), method))();
			[UnconditionalSuppressMessage("Trimming", "IL2060", Justification = "This code path is not used in Android projects.")]
			[UnconditionalSuppressMessage("Trimming", "IL3050", Justification = "This code path is not used in Android projects.")]
			static MethodInfo MakeGenericMethod(MethodInfo methodInfo, Type type)
			{
				return methodInfo.MakeGenericMethod(type);
			}
		}

		private static JniValueMarshaler GetObjectArrayMarshalerHelper<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] T>()
		{
			return JavaObjectArray<T>.Instance;
		}

		protected virtual JniValueMarshaler GetValueMarshalerCore(Type type)
		{
			return ProxyValueMarshaler.Instance;
		}
	}

	public class CreationOptions
	{
		public bool TrackIDs { get; }

		public bool DestroyRuntimeOnDispose { get; }

		public JniVersion JniVersion { get; set; }

		public nint InvocationPointer { get; set; }

		public nint EnvironmentPointer { get; set; }

		public JniObjectReference ClassLoader { get; set; }

		public JniObjectReferenceManager? ObjectReferenceManager { get; set; }

		public JniTypeManager? TypeManager { get; set; }

		public bool JniAddNativeMethodRegistrationAttributePresent { get; set; } = true;

		public bool UseMarshalMemberBuilder { get; set; } = true;

		public JniMarshalMemberBuilder? MarshalMemberBuilder { get; }

		public JniValueManager? ValueManager { get; set; }

		public CreationOptions()
		{
			JniVersion = JniVersion.v1_2;
		}
	}

	private interface ISetRuntime
	{
		void OnSetRuntime(JniRuntime runtime);
	}

	public abstract class JniMarshalMemberBuilder : IDisposable, ISetRuntime
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public virtual void OnSetRuntime(JniRuntime runtime)
		{
			throw new NotSupportedException("Linked away");
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void Dispose()
		{
			throw new NotSupportedException("Linked away");
		}
	}

	public abstract class JniObjectReferenceManager : IDisposable, ISetRuntime
	{
		private JniRuntime? runtime;

		public abstract int GlobalReferenceCount { get; }

		public abstract int WeakGlobalReferenceCount { get; }

		public virtual bool LogGlobalReferenceMessages => false;

		public JniObjectReferenceManager()
		{
		}

		public virtual void OnSetRuntime(JniRuntime runtime)
		{
			this.runtime = runtime;
		}

		internal JniObjectReference CreateLocalReference(JniEnvironmentInfo environment, JniObjectReference reference)
		{
			int localReferenceCount = environment.LocalReferenceCount;
			JniObjectReference result = CreateLocalReference(reference, ref localReferenceCount);
			environment.LocalReferenceCount = localReferenceCount;
			return result;
		}

		public virtual JniObjectReference CreateLocalReference(JniObjectReference reference, ref int localReferenceCount)
		{
			if (!reference.IsValid)
			{
				return reference;
			}
			_ = localReferenceCount;
			_ = 0;
			localReferenceCount++;
			return JniEnvironment.References.NewLocalRef(reference);
		}

		internal void DeleteLocalReference(JniEnvironmentInfo environment, ref JniObjectReference reference)
		{
			int localReferenceCount = environment.LocalReferenceCount;
			DeleteLocalReference(ref reference, ref localReferenceCount);
			environment.LocalReferenceCount = localReferenceCount;
		}

		public virtual void DeleteLocalReference(ref JniObjectReference reference, ref int localReferenceCount)
		{
			if (reference.IsValid)
			{
				localReferenceCount--;
				_ = localReferenceCount;
				_ = 0;
				JniEnvironment.References.DeleteLocalRef(reference.Handle);
				reference.Invalidate();
			}
		}

		internal void CreatedLocalReference(JniEnvironmentInfo environment, JniObjectReference reference)
		{
			int localReferenceCount = environment.LocalReferenceCount;
			CreatedLocalReference(reference, ref localReferenceCount);
			environment.LocalReferenceCount = localReferenceCount;
		}

		public virtual void CreatedLocalReference(JniObjectReference reference, ref int localReferenceCount)
		{
			if (reference.IsValid)
			{
				_ = localReferenceCount;
				_ = 0;
				localReferenceCount++;
			}
		}

		public virtual void WriteGlobalReferenceLine(string format, params object?[] args)
		{
		}

		public virtual JniObjectReference CreateGlobalReference(JniObjectReference reference)
		{
			if (!reference.IsValid)
			{
				return reference;
			}
			JniObjectReference result = JniEnvironment.References.NewGlobalRef(reference);
			_ = GlobalReferenceCount;
			_ = 0;
			return result;
		}

		public virtual void DeleteGlobalReference(ref JniObjectReference reference)
		{
			if (reference.IsValid)
			{
				_ = GlobalReferenceCount;
				_ = 0;
				JniEnvironment.References.DeleteGlobalRef(reference.Handle);
				reference.Invalidate();
			}
		}

		public virtual void DeleteWeakGlobalReference(ref JniObjectReference reference)
		{
			if (reference.IsValid)
			{
				_ = WeakGlobalReferenceCount;
				_ = 0;
				JniEnvironment.References.DeleteWeakGlobalRef(reference.Handle);
				reference.Invalidate();
			}
		}

		public void Dispose()
		{
			Dispose(disposing: false);
		}

		protected virtual void Dispose(bool disposing)
		{
		}
	}

	public struct ReplacementMethodInfo : IEquatable<ReplacementMethodInfo>
	{
		public string? SourceJniType { get; set; }

		public string? SourceJniMethodName { get; set; }

		public string? SourceJniMethodSignature { get; set; }

		public string? TargetJniType { get; set; }

		public string? TargetJniMethodName { get; set; }

		public string? TargetJniMethodSignature { get; set; }

		public int? TargetJniMethodParameterCount { get; set; }

		public bool TargetJniMethodInstanceToStatic { get; set; }

		public override bool Equals(object? obj)
		{
			if (obj is ReplacementMethodInfo other)
			{
				return Equals(other);
			}
			return false;
		}

		public bool Equals(ReplacementMethodInfo other)
		{
			if (string.Equals(SourceJniType, other.SourceJniType) && string.Equals(SourceJniMethodName, other.SourceJniMethodName) && string.Equals(SourceJniMethodSignature, other.SourceJniMethodSignature) && string.Equals(TargetJniType, other.TargetJniType) && string.Equals(TargetJniMethodName, other.TargetJniMethodName) && string.Equals(TargetJniMethodSignature, other.TargetJniMethodSignature) && TargetJniMethodParameterCount == other.TargetJniMethodParameterCount)
			{
				return TargetJniMethodInstanceToStatic == other.TargetJniMethodInstanceToStatic;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return (SourceJniType?.GetHashCode() ?? 0) ^ (SourceJniMethodName?.GetHashCode() ?? 0) ^ (SourceJniMethodSignature?.GetHashCode() ?? 0) ^ (TargetJniType?.GetHashCode() ?? 0) ^ (TargetJniMethodName?.GetHashCode() ?? 0) ^ (TargetJniMethodSignature?.GetHashCode() ?? 0) ^ (TargetJniMethodParameterCount?.GetHashCode() ?? 0) ^ TargetJniMethodInstanceToStatic.GetHashCode();
		}

		public override string ToString()
		{
			return $"{"ReplacementMethodInfo"} {{ {"SourceJniType"} = \"{SourceJniType}\", {"SourceJniMethodName"} = \"{SourceJniMethodName}\", {"SourceJniMethodSignature"} = \"{SourceJniMethodSignature}\", {"TargetJniType"} = \"{TargetJniType}\", {"TargetJniMethodName"} = \"{TargetJniMethodName}\", {"TargetJniMethodSignature"} = \"{TargetJniMethodSignature}\", {"TargetJniMethodParameterCount"} = {TargetJniMethodParameterCount?.ToString() ?? "null"}, {"TargetJniMethodInstanceToStatic"} = {TargetJniMethodInstanceToStatic}}}";
		}

		public static bool operator ==(ReplacementMethodInfo a, ReplacementMethodInfo b)
		{
			return a.Equals(b);
		}

		public static bool operator !=(ReplacementMethodInfo a, ReplacementMethodInfo b)
		{
			return !a.Equals(b);
		}
	}

	private static readonly Lazy<KeyValuePair<Type, JniValueMarshaler>[]> JniPrimitiveArrayMarshalers = new Lazy<KeyValuePair<Type, JniValueMarshaler>[]>(InitJniPrimitiveArrayMarshalers);

	private static JniTypeSignature __StringTypeSignature;

	private static JniTypeSignature __VoidTypeSignature;

	private static JniTypeSignature __BooleanTypeSignature;

	private static JniTypeSignature __BooleanNullableTypeSignature;

	private static JniTypeSignature __SByteTypeSignature;

	private static JniTypeSignature __SByteNullableTypeSignature;

	private static JniTypeSignature __CharTypeSignature;

	private static JniTypeSignature __CharNullableTypeSignature;

	private static JniTypeSignature __Int16TypeSignature;

	private static JniTypeSignature __Int16NullableTypeSignature;

	private static JniTypeSignature __Int32TypeSignature;

	private static JniTypeSignature __Int32NullableTypeSignature;

	private static JniTypeSignature __Int64TypeSignature;

	private static JniTypeSignature __Int64NullableTypeSignature;

	private static JniTypeSignature __SingleTypeSignature;

	private static JniTypeSignature __SingleNullableTypeSignature;

	private static JniTypeSignature __DoubleTypeSignature;

	private static JniTypeSignature __DoubleNullableTypeSignature;

	private static readonly Lazy<Dictionary<string, Type>> JniBuiltinSimpleReferenceToType = new Lazy<Dictionary<string, Type>>(InitJniBuiltinSimpleReferenceToType);

	private static readonly Lazy<KeyValuePair<Type, JniValueMarshaler>[]> JniBuiltinMarshalers = new Lazy<KeyValuePair<Type, JniValueMarshaler>[]>(InitJniBuiltinMarshalers);

	private static Dictionary<nint, JniRuntime> Runtimes = new Dictionary<nint, JniRuntime>();

	private static JniRuntime? current;

	private Dictionary<nint, IDisposable> TrackedInstances = new Dictionary<nint, IDisposable>();

	private JavaVMInterface Invoker;

	private bool DestroyRuntimeOnDispose;

	internal JniObjectReference ClassLoader;

	[CompilerGenerated]
	private bool _003CTrackIDs_003Ek__BackingField;

	private JniMarshalMemberBuilder? marshalMemberBuilder;

	internal JniValueManager? valueManager;

	public static JniRuntime CurrentRuntime
	{
		get
		{
			JniRuntime jniRuntime = current;
			if (jniRuntime != null)
			{
				return jniRuntime;
			}
			int num = 0;
			lock (Runtimes)
			{
				foreach (JniRuntime value in Runtimes.Values)
				{
					if (num++ == 0)
					{
						jniRuntime = value;
					}
				}
			}
			if (num == 1)
			{
				Interlocked.CompareExchange(ref current, jniRuntime, null);
				return jniRuntime;
			}
			if (num > 1)
			{
				throw new NotSupportedException($"Found {num} known Java Runtime instances. Don't know which to use. Use JniRuntime.SetCurrent().");
			}
			throw new NotSupportedException("No available Java runtime to attach to. Please create one.");
		}
	}

	public nint InvocationPointer { get; private set; }

	public JniVersion JniVersion { get; private set; }

	private bool TrackIDs
	{
		[CompilerGenerated]
		set
		{
			_003CTrackIDs_003Ek__BackingField = value;
		}
	}

	internal bool JniAddNativeMethodRegistrationAttributePresent { get; }

	public JniObjectReferenceManager ObjectReferenceManager { get; private set; }

	public JniTypeManager TypeManager { get; private set; }

	public JniValueManager ValueManager => valueManager ?? throw new NotSupportedException();

	private static KeyValuePair<Type, JniValueMarshaler>[] InitJniPrimitiveArrayMarshalers()
	{
		return new KeyValuePair<Type, JniValueMarshaler>[32]
		{
			new KeyValuePair<Type, JniValueMarshaler>(typeof(bool[]), JavaBooleanArray.ArrayMarshaler),
			new KeyValuePair<Type, JniValueMarshaler>(typeof(JavaArray<bool>), JavaBooleanArray.ArrayMarshaler),
			new KeyValuePair<Type, JniValueMarshaler>(typeof(JavaPrimitiveArray<bool>), JavaBooleanArray.ArrayMarshaler),
			new KeyValuePair<Type, JniValueMarshaler>(typeof(JavaBooleanArray), JavaBooleanArray.ArrayMarshaler),
			new KeyValuePair<Type, JniValueMarshaler>(typeof(sbyte[]), JavaSByteArray.ArrayMarshaler),
			new KeyValuePair<Type, JniValueMarshaler>(typeof(JavaArray<sbyte>), JavaSByteArray.ArrayMarshaler),
			new KeyValuePair<Type, JniValueMarshaler>(typeof(JavaPrimitiveArray<sbyte>), JavaSByteArray.ArrayMarshaler),
			new KeyValuePair<Type, JniValueMarshaler>(typeof(JavaSByteArray), JavaSByteArray.ArrayMarshaler),
			new KeyValuePair<Type, JniValueMarshaler>(typeof(char[]), JavaCharArray.ArrayMarshaler),
			new KeyValuePair<Type, JniValueMarshaler>(typeof(JavaArray<char>), JavaCharArray.ArrayMarshaler),
			new KeyValuePair<Type, JniValueMarshaler>(typeof(JavaPrimitiveArray<char>), JavaCharArray.ArrayMarshaler),
			new KeyValuePair<Type, JniValueMarshaler>(typeof(JavaCharArray), JavaCharArray.ArrayMarshaler),
			new KeyValuePair<Type, JniValueMarshaler>(typeof(short[]), JavaInt16Array.ArrayMarshaler),
			new KeyValuePair<Type, JniValueMarshaler>(typeof(JavaArray<short>), JavaInt16Array.ArrayMarshaler),
			new KeyValuePair<Type, JniValueMarshaler>(typeof(JavaPrimitiveArray<short>), JavaInt16Array.ArrayMarshaler),
			new KeyValuePair<Type, JniValueMarshaler>(typeof(JavaInt16Array), JavaInt16Array.ArrayMarshaler),
			new KeyValuePair<Type, JniValueMarshaler>(typeof(int[]), JavaInt32Array.ArrayMarshaler),
			new KeyValuePair<Type, JniValueMarshaler>(typeof(JavaArray<int>), JavaInt32Array.ArrayMarshaler),
			new KeyValuePair<Type, JniValueMarshaler>(typeof(JavaPrimitiveArray<int>), JavaInt32Array.ArrayMarshaler),
			new KeyValuePair<Type, JniValueMarshaler>(typeof(JavaInt32Array), JavaInt32Array.ArrayMarshaler),
			new KeyValuePair<Type, JniValueMarshaler>(typeof(long[]), JavaInt64Array.ArrayMarshaler),
			new KeyValuePair<Type, JniValueMarshaler>(typeof(JavaArray<long>), JavaInt64Array.ArrayMarshaler),
			new KeyValuePair<Type, JniValueMarshaler>(typeof(JavaPrimitiveArray<long>), JavaInt64Array.ArrayMarshaler),
			new KeyValuePair<Type, JniValueMarshaler>(typeof(JavaInt64Array), JavaInt64Array.ArrayMarshaler),
			new KeyValuePair<Type, JniValueMarshaler>(typeof(float[]), JavaSingleArray.ArrayMarshaler),
			new KeyValuePair<Type, JniValueMarshaler>(typeof(JavaArray<float>), JavaSingleArray.ArrayMarshaler),
			new KeyValuePair<Type, JniValueMarshaler>(typeof(JavaPrimitiveArray<float>), JavaSingleArray.ArrayMarshaler),
			new KeyValuePair<Type, JniValueMarshaler>(typeof(JavaSingleArray), JavaSingleArray.ArrayMarshaler),
			new KeyValuePair<Type, JniValueMarshaler>(typeof(double[]), JavaDoubleArray.ArrayMarshaler),
			new KeyValuePair<Type, JniValueMarshaler>(typeof(JavaArray<double>), JavaDoubleArray.ArrayMarshaler),
			new KeyValuePair<Type, JniValueMarshaler>(typeof(JavaPrimitiveArray<double>), JavaDoubleArray.ArrayMarshaler),
			new KeyValuePair<Type, JniValueMarshaler>(typeof(JavaDoubleArray), JavaDoubleArray.ArrayMarshaler)
		};
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static JniTypeSignature GetCachedTypeSignature(ref JniTypeSignature field, string signature, int arrayRank = 0, bool keyword = false)
	{
		if (!field.IsValid)
		{
			field = new JniTypeSignature(signature, arrayRank, keyword);
		}
		return field;
	}

	private static bool GetBuiltInTypeSignature(Type type, ref JniTypeSignature signature)
	{
		switch (Type.GetTypeCode(type))
		{
		case TypeCode.String:
			signature = GetCachedTypeSignature(ref __StringTypeSignature, "java/lang/String");
			return true;
		case TypeCode.Boolean:
			signature = GetCachedTypeSignature(ref __BooleanTypeSignature, "Z", 0, keyword: true);
			return true;
		case TypeCode.SByte:
		case TypeCode.Byte:
			signature = GetCachedTypeSignature(ref __SByteTypeSignature, "B", 0, keyword: true);
			return true;
		case TypeCode.Char:
			signature = GetCachedTypeSignature(ref __CharTypeSignature, "C", 0, keyword: true);
			return true;
		case TypeCode.Int16:
		case TypeCode.UInt16:
			signature = GetCachedTypeSignature(ref __Int16TypeSignature, "S", 0, keyword: true);
			return true;
		case TypeCode.Int32:
		case TypeCode.UInt32:
			signature = GetCachedTypeSignature(ref __Int32TypeSignature, "I", 0, keyword: true);
			return true;
		case TypeCode.Int64:
		case TypeCode.UInt64:
			signature = GetCachedTypeSignature(ref __Int64TypeSignature, "J", 0, keyword: true);
			return true;
		case TypeCode.Single:
			signature = GetCachedTypeSignature(ref __SingleTypeSignature, "F", 0, keyword: true);
			return true;
		case TypeCode.Double:
			signature = GetCachedTypeSignature(ref __DoubleTypeSignature, "D", 0, keyword: true);
			return true;
		case TypeCode.Empty:
		case TypeCode.DBNull:
		case TypeCode.Decimal:
		case TypeCode.DateTime:
			return false;
		default:
			if (type == typeof(void))
			{
				signature = GetCachedTypeSignature(ref __VoidTypeSignature, "V", 0, keyword: true);
				return true;
			}
			if (!type.IsValueType)
			{
				return false;
			}
			if (type == typeof(bool?))
			{
				signature = GetCachedTypeSignature(ref __BooleanNullableTypeSignature, "java/lang/Boolean");
				return true;
			}
			if (type == typeof(sbyte?))
			{
				signature = GetCachedTypeSignature(ref __SByteNullableTypeSignature, "java/lang/Byte");
				return true;
			}
			if (type == typeof(char?))
			{
				signature = GetCachedTypeSignature(ref __CharNullableTypeSignature, "java/lang/Character");
				return true;
			}
			if (type == typeof(short?))
			{
				signature = GetCachedTypeSignature(ref __Int16NullableTypeSignature, "java/lang/Short");
				return true;
			}
			if (type == typeof(int?))
			{
				signature = GetCachedTypeSignature(ref __Int32NullableTypeSignature, "java/lang/Integer");
				return true;
			}
			if (type == typeof(long?))
			{
				signature = GetCachedTypeSignature(ref __Int64NullableTypeSignature, "java/lang/Long");
				return true;
			}
			if (type == typeof(float?))
			{
				signature = GetCachedTypeSignature(ref __SingleNullableTypeSignature, "java/lang/Float");
				return true;
			}
			if (type == typeof(double?))
			{
				signature = GetCachedTypeSignature(ref __DoubleNullableTypeSignature, "java/lang/Double");
				return true;
			}
			return false;
		}
	}

	private static Dictionary<string, Type> InitJniBuiltinSimpleReferenceToType()
	{
		return new Dictionary<string, Type>(StringComparer.Ordinal)
		{
			{
				"java/lang/String",
				typeof(string)
			},
			{
				"net/dot/jni/internal/JavaProxyObject",
				typeof(JavaProxyObject)
			},
			{
				"net/dot/jni/internal/JavaProxyThrowable",
				typeof(JavaProxyThrowable)
			},
			{
				"net/dot/jni/ManagedPeer",
				typeof(ManagedPeer)
			},
			{
				"V",
				typeof(void)
			},
			{
				"Z",
				typeof(bool)
			},
			{
				"java/lang/Boolean",
				typeof(bool?)
			},
			{
				"B",
				typeof(sbyte)
			},
			{
				"java/lang/Byte",
				typeof(sbyte?)
			},
			{
				"C",
				typeof(char)
			},
			{
				"java/lang/Character",
				typeof(char?)
			},
			{
				"S",
				typeof(short)
			},
			{
				"java/lang/Short",
				typeof(short?)
			},
			{
				"I",
				typeof(int)
			},
			{
				"java/lang/Integer",
				typeof(int?)
			},
			{
				"J",
				typeof(long)
			},
			{
				"java/lang/Long",
				typeof(long?)
			},
			{
				"F",
				typeof(float)
			},
			{
				"java/lang/Float",
				typeof(float?)
			},
			{
				"D",
				typeof(double)
			},
			{
				"java/lang/Double",
				typeof(double?)
			}
		};
	}

	private static KeyValuePair<Type, JniValueMarshaler>[] InitJniBuiltinMarshalers()
	{
		return new KeyValuePair<Type, JniValueMarshaler>[18]
		{
			new KeyValuePair<Type, JniValueMarshaler>(typeof(string), JniStringValueMarshaler.Instance),
			new KeyValuePair<Type, JniValueMarshaler>(typeof(JavaProxyObject), ProxyValueMarshaler.Instance),
			new KeyValuePair<Type, JniValueMarshaler>(typeof(bool), JniBooleanValueMarshaler.Instance),
			new KeyValuePair<Type, JniValueMarshaler>(typeof(bool?), JniNullableBooleanValueMarshaler.Instance),
			new KeyValuePair<Type, JniValueMarshaler>(typeof(sbyte), JniSByteValueMarshaler.Instance),
			new KeyValuePair<Type, JniValueMarshaler>(typeof(sbyte?), JniNullableSByteValueMarshaler.Instance),
			new KeyValuePair<Type, JniValueMarshaler>(typeof(char), JniCharValueMarshaler.Instance),
			new KeyValuePair<Type, JniValueMarshaler>(typeof(char?), JniNullableCharValueMarshaler.Instance),
			new KeyValuePair<Type, JniValueMarshaler>(typeof(short), JniInt16ValueMarshaler.Instance),
			new KeyValuePair<Type, JniValueMarshaler>(typeof(short?), JniNullableInt16ValueMarshaler.Instance),
			new KeyValuePair<Type, JniValueMarshaler>(typeof(int), JniInt32ValueMarshaler.Instance),
			new KeyValuePair<Type, JniValueMarshaler>(typeof(int?), JniNullableInt32ValueMarshaler.Instance),
			new KeyValuePair<Type, JniValueMarshaler>(typeof(long), JniInt64ValueMarshaler.Instance),
			new KeyValuePair<Type, JniValueMarshaler>(typeof(long?), JniNullableInt64ValueMarshaler.Instance),
			new KeyValuePair<Type, JniValueMarshaler>(typeof(float), JniSingleValueMarshaler.Instance),
			new KeyValuePair<Type, JniValueMarshaler>(typeof(float?), JniNullableSingleValueMarshaler.Instance),
			new KeyValuePair<Type, JniValueMarshaler>(typeof(double), JniDoubleValueMarshaler.Instance),
			new KeyValuePair<Type, JniValueMarshaler>(typeof(double?), JniNullableDoubleValueMarshaler.Instance)
		};
	}

	public static JniRuntime? GetRegisteredRuntime(nint invocationPointer)
	{
		lock (Runtimes)
		{
			JniRuntime value;
			return Runtimes.TryGetValue(invocationPointer, out value) ? value : null;
		}
	}

	protected JniRuntime(CreationOptions options)
	{
		if (options == null)
		{
			throw new ArgumentNullException("options");
		}
		if (options.InvocationPointer == IntPtr.Zero && options.EnvironmentPointer == IntPtr.Zero)
		{
			throw new ArgumentException("Need either options.InvocationPointer or options.EnvironmentPointer!", "options");
		}
		TrackIDs = options.TrackIDs;
		DestroyRuntimeOnDispose = options.DestroyRuntimeOnDispose;
		JniAddNativeMethodRegistrationAttributePresent = options.JniAddNativeMethodRegistrationAttributePresent;
		JniVersion = options.JniVersion;
		if (options.InvocationPointer == IntPtr.Zero && options.EnvironmentPointer != IntPtr.Zero)
		{
			InvocationPointer = GetInvocationPointerFromEnvironmentPointer(options.EnvironmentPointer);
		}
		else
		{
			InvocationPointer = options.InvocationPointer;
		}
		Invoker = CreateInvoker(InvocationPointer);
		SetValueManager(options);
		SetMarshalMemberBuilder(options);
		ObjectReferenceManager = SetRuntime(options.ObjectReferenceManager ?? throw new NotSupportedException("Please set CreationOptions.ObjectReferenceManager!"));
		TypeManager = SetRuntime(options.TypeManager ?? new JniTypeManager());
		Interlocked.CompareExchange(ref current, this, null);
		lock (Runtimes)
		{
			Runtimes[InvocationPointer] = this;
		}
		nint envptr = options.EnvironmentPointer;
		if (envptr == IntPtr.Zero && Invoker.GetEnv(InvocationPointer, out envptr, (int)JniVersion) != 0 && (envptr = _AttachCurrentThread()) == IntPtr.Zero)
		{
			throw new InvalidOperationException("Could not obtain JNIEnv* value!");
		}
		JniEnvironment.SetEnvironmentInfo(new JniEnvironmentInfo(envptr, this));
		ClassLoader = options.ClassLoader;
		if (ClassLoader.IsValid)
		{
			ClassLoader = ClassLoader.NewGlobalRef();
		}
		else
		{
			using JniType jniType = new JniType("java/lang/ClassLoader");
			JniMethodInfo staticMethod = jniType.GetStaticMethod("getSystemClassLoader", "()Ljava/lang/ClassLoader;");
			JniObjectReference reference = JniEnvironment.StaticMethods.CallStaticObjectMethod(jniType.PeerReference, staticMethod);
			ClassLoader = reference.NewGlobalRef();
			JniObjectReference.Dispose(ref reference);
		}
		ManagedPeer.Init();
	}

	private unsafe static nint GetInvocationPointerFromEnvironmentPointer(nint envp)
	{
		nint zero = IntPtr.Zero;
		int javaVM = JniNativeMethods.GetJavaVM(envp, &zero);
		if (javaVM != 0)
		{
			throw new InvalidOperationException($"Could not obtain JavaVM* from JNIEnv*; JNIEnv::GetJavaVM() returned {javaVM}!");
		}
		return zero;
	}

	private T SetRuntime<T>(T value) where T : class, ISetRuntime
	{
		if (value == null)
		{
			throw new NotSupportedException();
		}
		value.OnSetRuntime(this);
		return value;
	}

	private void SetValueManager(CreationOptions options)
	{
		JniValueManager jniValueManager = options.ValueManager;
		if (jniValueManager == null)
		{
			throw new ArgumentException("No JniValueManager specified in JniRuntime.CreationOptions.ValueManager.", "options");
		}
		valueManager = SetRuntime(jniValueManager);
	}

	[UnconditionalSuppressMessage("Trimming", "IL2026", Justification = "This code path is not used in Android projects.")]
	[UnconditionalSuppressMessage("Trimming", "IL2035", Justification = "Java.Interop.Export.dll is not always present.")]
	[UnconditionalSuppressMessage("Trimming", "IL3050", Justification = "This code path is not used in Android projects.")]
	private void SetMarshalMemberBuilder(CreationOptions options)
	{
		if (!options.UseMarshalMemberBuilder)
		{
			return;
		}
		if (options.MarshalMemberBuilder != null)
		{
			marshalMemberBuilder = SetRuntime(options.MarshalMemberBuilder);
			return;
		}
		Type? type = Type.GetType("Java.Interop.MarshalMemberBuilder, Java.Interop.Export", throwOnError: false);
		if (type == null)
		{
			throw new InvalidOperationException("Could not find Java.Interop.MarshalMemberBuilder from Java.Interop.Export.dll!");
		}
		JniMarshalMemberBuilder runtime = (JniMarshalMemberBuilder)Activator.CreateInstance(type);
		marshalMemberBuilder = SetRuntime(runtime);
	}

	private static JavaVMInterface CreateInvoker(nint handle)
	{
		return Marshal.PtrToStructure<JavaVMInterface>(Marshal.ReadIntPtr(handle));
	}

	~JniRuntime()
	{
		Dispose(disposing: false);
	}

	public override string ToString()
	{
		return string.Format("{0}(0x{1})", GetType().FullName, ((IntPtr)InvocationPointer).ToString("x"));
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (InvocationPointer == IntPtr.Zero)
		{
			return;
		}
		Interlocked.CompareExchange(ref current, null, this);
		lock (Runtimes)
		{
			if (Runtimes.TryGetValue(InvocationPointer, out JniRuntime value) && value == this)
			{
				Runtimes.Remove(InvocationPointer);
			}
		}
		if (disposing)
		{
			JniObjectReference.Dispose(ref ClassLoader);
			ClearTrackedReferences();
			ValueManager.Dispose();
			marshalMemberBuilder?.Dispose();
			TypeManager.Dispose();
			ObjectReferenceManager.Dispose();
			IList<JniEnvironmentInfo> values = JniEnvironment.Info.Values;
			for (int i = 0; i < values.Count; i++)
			{
				if (values[i].Runtime == this)
				{
					values[i].Dispose();
				}
			}
		}
		if (DestroyRuntimeOnDispose)
		{
			DestroyRuntime();
		}
		InvocationPointer = IntPtr.Zero;
		Invoker = default(JavaVMInterface);
	}

	internal nint _AttachCurrentThread(string? name = null, JniObjectReference group = default(JniObjectReference))
	{
		AssertValid();
		JavaVMThreadAttachArgs args = new JavaVMThreadAttachArgs
		{
			version = JniVersion
		};
		try
		{
			if (name != null)
			{
				args.name = Marshal.StringToHGlobalAnsi(name);
			}
			if (group.IsValid)
			{
				args.group = group.Handle;
			}
			nint env;
			int num = Invoker.AttachCurrentThread(InvocationPointer, out env, ref args);
			if (num != 0)
			{
				throw new NotSupportedException("AttachCurrentThread returned " + num);
			}
			return env;
		}
		finally
		{
			Marshal.FreeHGlobal(args.name);
		}
	}

	private void AssertValid()
	{
		if (InvocationPointer == IntPtr.Zero)
		{
			throw new ObjectDisposedException("JniRuntime");
		}
	}

	public void DestroyRuntime()
	{
		AssertValid();
		Invoker.DestroyJavaVM(InvocationPointer);
	}

	public virtual Exception? GetExceptionForThrowable(ref JniObjectReference reference, JniObjectReferenceOptions options)
	{
		return ValueManager.GetValue<Exception>(ref reference, options);
	}

	internal void Track(JniType value)
	{
		lock (TrackedInstances)
		{
			if (!TrackedInstances.ContainsKey(value.PeerReference.Handle))
			{
				TrackedInstances[value.PeerReference.Handle] = value;
			}
		}
	}

	internal void UnTrack(nint key)
	{
		lock (TrackedInstances)
		{
			if (TrackedInstances.ContainsKey(key))
			{
				TrackedInstances.Remove(key);
			}
		}
	}

	private void ClearTrackedReferences()
	{
		List<IDisposable> list;
		lock (TrackedInstances)
		{
			list = new List<IDisposable>(TrackedInstances.Values);
			TrackedInstances.Clear();
		}
		foreach (IDisposable item in list)
		{
			item.Dispose();
		}
	}

	public virtual bool ExceptionShouldTransitionToJni(Exception e)
	{
		return !Debugger.IsAttached;
	}

	public virtual void OnEnterMarshalMethod()
	{
		ValueManager.WaitForGCBridgeProcessing();
	}

	public virtual void OnUserUnhandledException(ref JniTransition transition, Exception e)
	{
		transition.SetPendingException(e);
		Debugger.BreakForUserUnhandledException(e);
	}

	public virtual void RaisePendingException(Exception pendingException)
	{
		JniEnvironment.Exceptions.Throw(pendingException);
	}
}
