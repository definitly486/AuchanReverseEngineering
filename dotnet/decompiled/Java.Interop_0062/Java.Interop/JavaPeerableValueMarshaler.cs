using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Java.Interop;

internal sealed class JavaPeerableValueMarshaler : JniValueMarshaler<IJavaPeerable?>
{
	internal static JavaPeerableValueMarshaler Instance = new JavaPeerableValueMarshaler();

	[return: MaybeNull]
	public override IJavaPeerable? CreateGenericValue(ref JniObjectReference reference, JniObjectReferenceOptions options, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] Type? targetType)
	{
		JniRuntime runtime = JniEnvironment.Runtime;
		JniValueMarshaler valueMarshaler = runtime.ValueManager.GetValueMarshaler(targetType ?? typeof(IJavaPeerable));
		if (valueMarshaler != Instance)
		{
			return (IJavaPeerable)valueMarshaler.CreateValue(ref reference, options, targetType);
		}
		return runtime.ValueManager.CreatePeer(ref reference, options, targetType);
	}

	public override JniValueMarshalerState CreateGenericObjectReferenceArgumentState([MaybeNull] IJavaPeerable? value, ParameterAttributes synchronize)
	{
		if (value == null || !value.PeerReference.IsValid)
		{
			return default(JniValueMarshalerState);
		}
		return new JniValueMarshalerState(value.PeerReference.NewLocalRef());
	}

	public override void DestroyGenericArgumentState([MaybeNull] IJavaPeerable? value, ref JniValueMarshalerState state, ParameterAttributes synchronize)
	{
		JniObjectReference reference = state.ReferenceValue;
		JniObjectReference.Dispose(ref reference);
		state = default(JniValueMarshalerState);
	}
}
