using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Java.Interop;

internal sealed class ProxyValueMarshaler : JniValueMarshaler<object?>
{
	internal static ProxyValueMarshaler Instance = new ProxyValueMarshaler();

	[return: MaybeNull]
	public override object? CreateGenericValue(ref JniObjectReference reference, JniObjectReferenceOptions options, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] Type? targetType)
	{
		JniRuntime runtime = JniEnvironment.Runtime;
		if (targetType == null || targetType == typeof(object))
		{
			targetType = runtime.ValueManager.GetRuntimeType(reference);
		}
		if (targetType != null)
		{
			JniValueMarshaler valueMarshaler = runtime.ValueManager.GetValueMarshaler(targetType);
			if (valueMarshaler != Instance)
			{
				return valueMarshaler.CreateValue(ref reference, options, targetType);
			}
		}
		object obj = runtime.ValueManager.PeekValue(reference);
		if (obj != null)
		{
			JniObjectReference.Dispose(ref reference, options);
			return obj;
		}
		return runtime.ValueManager.CreatePeer(ref reference, options, targetType);
	}

	public override JniValueMarshalerState CreateGenericObjectReferenceArgumentState([MaybeNull] object? value, ParameterAttributes synchronize)
	{
		if (value == null)
		{
			return default(JniValueMarshalerState);
		}
		JniValueMarshaler valueMarshaler = JniEnvironment.Runtime.ValueManager.GetValueMarshaler(value.GetType());
		if (valueMarshaler != Instance)
		{
			return new JniValueMarshalerState(valueMarshaler.CreateObjectReferenceArgumentState(value, synchronize), valueMarshaler);
		}
		return new JniValueMarshalerState(JavaProxyObject.GetProxy(value).PeerReference.NewLocalRef());
	}

	public override void DestroyGenericArgumentState(object? value, ref JniValueMarshalerState state, ParameterAttributes synchronize)
	{
		if (state.Extra is JniValueMarshaler jniValueMarshaler)
		{
			jniValueMarshaler.DestroyArgumentState(value, ref state, synchronize);
			return;
		}
		JniObjectReference reference = state.ReferenceValue;
		JniObjectReference.Dispose(ref reference);
		state = default(JniValueMarshalerState);
	}
}
