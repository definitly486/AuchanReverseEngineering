using System;
using System.Diagnostics.CodeAnalysis;

namespace Java.Interop;

[Serializable]
[JniTypeSignature("java/lang/Object", GenerateJavaPeer = false)]
public class JavaObject : IJavaPeerable, IDisposable
{
	internal const DynamicallyAccessedMemberTypes Constructors = DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors;

	private static readonly JniPeerMembers _members = new JniPeerMembers("java/lang/Object", typeof(JavaObject));

	[NonSerialized]
	private int identityHashCode;

	[NonSerialized]
	private JniManagedPeerStates managedPeerState;

	[NonSerialized]
	private unsafe JniObjectReferenceControlBlock* jniObjectReferenceControlBlock;

	protected unsafe static readonly JniObjectReference* InvalidJniObjectReference = null;

	private const JniManagedPeerStates Disposed = (JniManagedPeerStates)4;

	public int JniIdentityHashCode => identityHashCode;

	public JniManagedPeerStates JniManagedPeerState => managedPeerState;

	public unsafe JniObjectReference PeerReference
	{
		get
		{
			JniObjectReferenceControlBlock* ptr = jniObjectReferenceControlBlock;
			if (ptr == null)
			{
				return default(JniObjectReference);
			}
			return new JniObjectReference(ptr->handle, (JniObjectReferenceType)ptr->handle_type);
		}
	}

	public virtual JniPeerMembers JniPeerMembers => _members;

	unsafe nint IJavaPeerable.JniObjectReferenceControlBlock => (nint)jniObjectReferenceControlBlock;

	~JavaObject()
	{
		JniEnvironment.Runtime.ValueManager.FinalizePeer(this);
	}

	public JavaObject(ref JniObjectReference reference, JniObjectReferenceOptions options)
	{
		Construct(ref reference, options);
	}

	[JniConstructorSignature("()V")]
	public unsafe JavaObject()
		: this(ref *InvalidJniObjectReference, JniObjectReferenceOptions.None)
	{
		if (!PeerReference.IsValid)
		{
			JniObjectReference reference = JniPeerMembers.InstanceMethods.StartCreateInstance("()V", GetType(), null);
			Construct(ref reference, JniObjectReferenceOptions.CopyAndDispose);
			JniPeerMembers.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	protected void Construct(ref JniObjectReference reference, JniObjectReferenceOptions options)
	{
		JniEnvironment.Runtime.ValueManager.ConstructPeer(this, ref reference, options);
	}

	protected unsafe void SetPeerReference(ref JniObjectReference reference, JniObjectReferenceOptions options)
	{
		if (options == JniObjectReferenceOptions.None)
		{
			((IJavaPeerable)this).SetPeerReference(default(JniObjectReference));
			return;
		}
		JniObjectReferenceControlBlock* ptr = jniObjectReferenceControlBlock;
		if (ptr == null)
		{
			ptr = (jniObjectReferenceControlBlock = JniObjectReferenceControlBlock.Alloc(reference));
		}
		else
		{
			ptr->handle = reference.Handle;
			ptr->handle_type = (int)reference.Type;
		}
		JniObjectReference.Dispose(ref reference, options);
	}

	public void UnregisterFromRuntime()
	{
		if (!PeerReference.IsValid)
		{
			throw JniEnvironment.CreateObjectDisposedException(this);
		}
		JniEnvironment.Runtime.ValueManager.RemovePeer(this);
	}

	public void Dispose()
	{
		JniEnvironment.Runtime.ValueManager.DisposePeer(this);
	}

	public virtual void DisposeUnlessReferenced()
	{
		JniEnvironment.Runtime.ValueManager.DisposePeerUnlessReferenced(this);
	}

	protected virtual void Dispose(bool disposing)
	{
	}

	public override bool Equals(object? obj)
	{
		Java.Interop.JniPeerMembers.AssertSelf(this);
		if (obj == this)
		{
			return true;
		}
		if (obj is IJavaPeerable javaPeerable)
		{
			return JniEnvironment.Types.IsSameObject(PeerReference, javaPeerable.PeerReference);
		}
		return false;
	}

	public unsafe override int GetHashCode()
	{
		return _members.InstanceMethods.InvokeVirtualInt32Method("hashCode.()I", this, null);
	}

	public unsafe override string? ToString()
	{
		JniObjectReference value = _members.InstanceMethods.InvokeVirtualObjectMethod("toString.()Ljava/lang/String;", this, null);
		return JniEnvironment.Strings.ToString(ref value, JniObjectReferenceOptions.CopyAndDispose);
	}

	void IJavaPeerable.Disposed()
	{
		managedPeerState |= (JniManagedPeerStates)4;
		Dispose(disposing: true);
	}

	void IJavaPeerable.Finalized()
	{
		managedPeerState |= (JniManagedPeerStates)4;
		Dispose(disposing: false);
	}

	void IJavaPeerable.SetJniIdentityHashCode(int value)
	{
		identityHashCode = value;
	}

	void IJavaPeerable.SetJniManagedPeerState(JniManagedPeerStates value)
	{
		managedPeerState = value;
	}

	unsafe void IJavaPeerable.SetPeerReference(JniObjectReference reference)
	{
		SetPeerReference(ref reference, JniObjectReferenceOptions.Copy);
		if (!reference.IsValid && managedPeerState.HasFlag((JniManagedPeerStates)4))
		{
			JniObjectReferenceControlBlock.Free(ref jniObjectReferenceControlBlock);
		}
	}
}
