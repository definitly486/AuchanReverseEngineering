using System;
using Java.Interop;
using Java.Lang;

namespace Android.Runtime;

internal class AndroidRuntime : JniRuntime
{
	internal AndroidRuntime(nint jnienv, nint vm, nint classLoader, JniTypeManager typeManager, JniValueManager valueManager, bool jniAddNativeMethodRegistrationAttributePresent)
		: base(new AndroidRuntimeOptions(jnienv, vm, classLoader, typeManager, valueManager, jniAddNativeMethodRegistrationAttributePresent))
	{
		AndroidEnvironmentInternal.UnhandledExceptionHandler = AndroidEnvironment.UnhandledException;
	}

	public override System.Exception? GetExceptionForThrowable(ref JniObjectReference reference, JniObjectReferenceOptions options)
	{
		if (!reference.IsValid)
		{
			return null;
		}
		IJavaPeerable javaPeerable = JniEnvironment.Runtime.ValueManager.PeekPeer(reference);
		if (!(javaPeerable is System.Exception result))
		{
			Throwable? result2 = Java.Lang.Object.GetObject<Throwable>(reference.Handle, JniHandleOwnership.DoNotTransfer);
			JniObjectReference.Dispose(ref reference, options);
			return result2;
		}
		JniObjectReference.Dispose(ref reference, options);
		if (JniEnvironment.Runtime.ValueManager.PeekValue(javaPeerable.PeerReference) is System.Exception result3)
		{
			return result3;
		}
		return result;
	}

	public override void OnUserUnhandledException(ref JniTransition transition, System.Exception e)
	{
		if (!AndroidEnvironment.TryRaiseUnhandledException(e))
		{
			base.OnUserUnhandledException(ref transition, e);
		}
	}

	public override void RaisePendingException(System.Exception pendingException)
	{
		JavaException ex = pendingException as JavaException;
		if (ex == null)
		{
			ex = JavaProxyThrowable.Create(pendingException);
		}
		JniEnvironment.Exceptions.Throw(ex.PeerReference);
	}
}
