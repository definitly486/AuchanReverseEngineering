using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Reflection;
using System.Runtime.CompilerServices;
using Java.Interop;

namespace Android.Runtime;

internal class AndroidValueManager : JniRuntime.JniValueManager
{
	private Dictionary<nint, IdentityHashTargets> instances = new Dictionary<nint, IdentityHashTargets>();

	public override void WaitForGCBridgeProcessing()
	{
		if (AndroidRuntimeInternal.BridgeProcessing)
		{
			RuntimeNativeMethods._monodroid_gc_wait_for_bridge_processing();
		}
	}

	public override IJavaPeerable? CreatePeer(ref JniObjectReference reference, JniObjectReferenceOptions options, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] Type? targetType)
	{
		if (!reference.IsValid)
		{
			return null;
		}
		IJavaPeerable? result = Java.Interop.TypeManager.CreateInstance(reference.Handle, JniHandleOwnership.DoNotTransfer, targetType);
		JniObjectReference.Dispose(ref reference, options);
		return result;
	}

	public override void AddPeer(IJavaPeerable value)
	{
		if (value == null)
		{
			throw new ArgumentNullException("value");
		}
		if (!value.PeerReference.IsValid)
		{
			throw new ArgumentException("Must have a valid JNI object reference!", "value");
		}
		JniObjectReference peerReference = value.PeerReference;
		nint hash = JNIEnv.IdentityHash(peerReference.Handle);
		AddPeer(value, peerReference, hash);
	}

	internal void AddPeer(IJavaPeerable value, JniObjectReference reference, nint hash)
	{
		lock (instances)
		{
			if (!instances.TryGetValue(hash, out IdentityHashTargets value2))
			{
				value2 = new IdentityHashTargets(value);
				instances.Add(hash, value2);
				return;
			}
			bool flag = false;
			for (int i = 0; i < value2.Count; i++)
			{
				WeakReference<IJavaPeerable> current = value2[i];
				if (ShouldReplaceMapping(current, reference, value, out IJavaPeerable target))
				{
					flag = true;
					value2[i] = IdentityHashTargets.CreateWeakReference(value);
					break;
				}
				if (JniEnvironment.Types.IsSameObject(value.PeerReference, target.PeerReference))
				{
					flag = true;
					if (Logger.LogGlobalRef)
					{
						Logger.Log(LogLevel.Info, "monodroid-gref", FormattableString.Invariant($"warning: not replacing previous registered handle {target.PeerReference} with handle {reference} for key_handle 0x{hash:x}"));
					}
				}
			}
			if (!flag)
			{
				value2.Add(value);
			}
		}
	}

	private bool ShouldReplaceMapping(WeakReference<IJavaPeerable> current, JniObjectReference reference, IJavaPeerable value, out IJavaPeerable? target)
	{
		target = null;
		if (current == null)
		{
			return true;
		}
		if (!current.TryGetTarget(out target) || target == null)
		{
			return true;
		}
		if (!target.PeerReference.IsValid)
		{
			return true;
		}
		if (!JniEnvironment.Types.IsSameObject(target.PeerReference, reference))
		{
			return false;
		}
		if (target.JniManagedPeerState.HasFlag(JniManagedPeerStates.Replaceable) && !value.JniManagedPeerState.HasFlag(JniManagedPeerStates.Replaceable))
		{
			return true;
		}
		return false;
	}

	public override void RemovePeer(IJavaPeerable value)
	{
		if (value == null)
		{
			throw new ArgumentNullException("value");
		}
		JniObjectReference peerReference = value.PeerReference;
		if (peerReference.IsValid)
		{
			nint hash = JNIEnv.IdentityHash(peerReference.Handle);
			RemovePeer(value, hash);
		}
	}

	internal void RemovePeer(IJavaPeerable value, nint hash)
	{
		lock (instances)
		{
			if (!instances.TryGetValue(hash, out IdentityHashTargets value2))
			{
				return;
			}
			for (int num = value2.Count - 1; num >= 0; num--)
			{
				if (!value2[num].TryGetTarget(out IJavaPeerable target))
				{
					value2.RemoveAt(num);
				}
				else if (target == value)
				{
					value2.RemoveAt(num);
				}
			}
			if (value2.Count == 0)
			{
				instances.Remove(hash);
			}
		}
	}

	public override IJavaPeerable? PeekPeer(JniObjectReference reference)
	{
		if (!reference.IsValid)
		{
			return null;
		}
		nint key = JNIEnv.IdentityHash(reference.Handle);
		lock (instances)
		{
			if (instances.TryGetValue(key, out IdentityHashTargets value))
			{
				for (int num = value.Count - 1; num >= 0; num--)
				{
					if (!value[num].TryGetTarget(out IJavaPeerable target) || !target.PeerReference.IsValid)
					{
						value.RemoveAt(num);
					}
					else if (JniEnvironment.Types.IsSameObject(reference, target.PeerReference))
					{
						return target;
					}
				}
			}
		}
		return null;
	}

	public override void ActivatePeer(IJavaPeerable? self, JniObjectReference reference, ConstructorInfo cinfo, object?[]? argumentValues)
	{
		Java.Interop.TypeManager.Activate(reference.Handle, cinfo, argumentValues);
	}

	protected override bool TryUnboxPeerObject(IJavaPeerable value, [NotNullWhen(true)] out object? result)
	{
		if (value is JavaProxyThrowable javaProxyThrowable)
		{
			result = javaProxyThrowable.InnerException;
			return true;
		}
		return base.TryUnboxPeerObject(value, out result);
	}

	public override void FinalizePeer(IJavaPeerable value)
	{
		if (value == null)
		{
			throw new ArgumentNullException("value");
		}
		if (Logger.LogGlobalRef)
		{
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			InlineArray4<object> buffer = default(InlineArray4<object>);
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<InlineArray4<object>, object>(ref buffer, 0) = value.GetType().ToString();
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<InlineArray4<object>, object>(ref buffer, 1) = value.PeerReference.ToString();
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<InlineArray4<object>, object>(ref buffer, 2) = value.JniIdentityHashCode;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<InlineArray4<object>, object>(ref buffer, 3) = RuntimeHelpers.GetHashCode(value);
			RuntimeNativeMethods._monodroid_gref_log(string.Format(invariantCulture, "Finalizing Instance.Type={0} PeerReference={1} IdentityHashCode=0x{2:x} Instance=0x{3:x}", global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<InlineArray4<object>, object>(in buffer, 4)));
		}
		if (value.PeerReference.IsValid)
		{
			GC.ReRegisterForFinalize(value);
			return;
		}
		RemovePeer(value, value.JniIdentityHashCode);
		value.SetPeerReference(default(JniObjectReference));
		value.Finalized();
	}
}
