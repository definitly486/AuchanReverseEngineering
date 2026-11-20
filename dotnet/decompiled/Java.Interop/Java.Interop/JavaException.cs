using System;

namespace Java.Interop;

[JniTypeSignature("java/lang/Throwable", GenerateJavaPeer = false)]
public class JavaException : Exception, IJavaPeerable, IDisposable
{
	private static readonly JniPeerMembers _members = new JniPeerMembers("java/lang/Throwable", typeof(JavaException));

	private unsafe JniObjectReferenceControlBlock* jniObjectReferenceControlBlock;

	protected unsafe static readonly JniObjectReference* InvalidJniObjectReference = null;

	public string? JavaStackTrace { get; private set; }

	public int JniIdentityHashCode { get; private set; }

	public JniManagedPeerStates JniManagedPeerState { get; private set; }

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

	public override string StackTrace => base.StackTrace + "\n" + "  --- End of managed " + GetType().FullName + " stack trace ---" + "\n" + JavaStackTrace;

	unsafe nint IJavaPeerable.JniObjectReferenceControlBlock => (nint)jniObjectReferenceControlBlock;

	public unsafe JavaException()
		: this(ref *InvalidJniObjectReference, JniObjectReferenceOptions.None)
	{
		if (!PeerReference.IsValid)
		{
			JniObjectReference reference = JniPeerMembers.InstanceMethods.StartCreateInstance("()V", GetType(), null);
			Construct(ref reference, JniObjectReferenceOptions.CopyAndDispose);
			JniPeerMembers.InstanceMethods.FinishCreateInstance("()V", this, null);
			SetJavaStackTrace();
		}
	}

	public unsafe JavaException(string message)
		: base(message)
	{
		JniObjectReference reference = JniEnvironment.Strings.NewString(message);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(reference);
			JniObjectReference reference2 = JniPeerMembers.InstanceMethods.StartCreateInstance("(Ljava/lang/String;)V", GetType(), ptr);
			Construct(ref reference2, JniObjectReferenceOptions.CopyAndDispose);
			JniPeerMembers.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JniObjectReference.Dispose(ref reference, JniObjectReferenceOptions.CopyAndDispose);
		}
		SetJavaStackTrace();
	}

	public unsafe JavaException(string message, Exception innerException)
		: base(message, innerException)
	{
		JniObjectReference reference = JniEnvironment.Strings.NewString(message);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(reference);
			JniObjectReference reference2 = JniPeerMembers.InstanceMethods.StartCreateInstance("(Ljava/lang/String;)V", GetType(), ptr);
			Construct(ref reference2, JniObjectReferenceOptions.CopyAndDispose);
			JniPeerMembers.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JniObjectReference.Dispose(ref reference, JniObjectReferenceOptions.CopyAndDispose);
		}
		SetJavaStackTrace();
	}

	protected JavaException(ref JniObjectReference reference, JniObjectReferenceOptions transfer, JniObjectReference throwableOverride)
		: base(GetMessage(throwableOverride), GetCause(throwableOverride))
	{
		Construct(ref reference, transfer);
		SetJavaStackTrace(throwableOverride);
	}

	public JavaException(ref JniObjectReference reference, JniObjectReferenceOptions transfer)
		: base(GetMessage(ref reference, transfer), GetCause(ref reference, transfer))
	{
		Construct(ref reference, transfer);
		if (PeerReference.IsValid)
		{
			SetJavaStackTrace();
		}
	}

	protected void Construct(ref JniObjectReference reference, JniObjectReferenceOptions options)
	{
		JniEnvironment.Runtime.ValueManager.ConstructPeer(this, ref reference, options);
	}

	~JavaException()
	{
		JniEnvironment.Runtime.ValueManager.FinalizePeer(this);
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

	public void DisposeUnlessReferenced()
	{
		JniEnvironment.Runtime.ValueManager.DisposePeerUnlessReferenced(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (base.InnerException is JavaException ex)
		{
			ex.Dispose();
		}
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

	private static string? GetMessage(ref JniObjectReference reference, JniObjectReferenceOptions transfer)
	{
		if (transfer == JniObjectReferenceOptions.None)
		{
			return null;
		}
		return GetMessage(reference);
	}

	private static string? GetMessage(JniObjectReference reference)
	{
		if (!reference.IsValid)
		{
			return null;
		}
		JniMethodInfo methodInfo = _members.InstanceMethods.GetMethodInfo("getMessage.()Ljava/lang/String;");
		JniObjectReference value = JniEnvironment.InstanceMethods.CallObjectMethod(reference, methodInfo);
		return JniEnvironment.Strings.ToString(ref value, JniObjectReferenceOptions.CopyAndDispose);
	}

	private static Exception? GetCause(ref JniObjectReference reference, JniObjectReferenceOptions transfer)
	{
		if (transfer == JniObjectReferenceOptions.None)
		{
			return null;
		}
		return GetCause(reference);
	}

	private static Exception? GetCause(JniObjectReference reference)
	{
		if (!reference.IsValid)
		{
			return null;
		}
		JniMethodInfo methodInfo = _members.InstanceMethods.GetMethodInfo("getCause.()Ljava/lang/Throwable;");
		JniObjectReference reference2 = JniEnvironment.InstanceMethods.CallObjectMethod(reference, methodInfo);
		return JniEnvironment.Runtime.GetExceptionForThrowable(ref reference2, JniObjectReferenceOptions.CopyAndDispose);
	}

	protected void SetJavaStackTrace(JniObjectReference peerReferenceOverride = default(JniObjectReference))
	{
		if (!peerReferenceOverride.IsValid)
		{
			peerReferenceOverride = PeerReference;
		}
		if (peerReferenceOverride.IsValid)
		{
			JavaStackTrace = GetJavaStack(peerReferenceOverride);
		}
	}

	private unsafe string? GetJavaStack(JniObjectReference handle)
	{
		using JniType jniType = new JniType("java/io/StringWriter");
		using JniType jniType2 = new JniType("java/io/PrintWriter");
		JniMethodInfo constructor = jniType.GetConstructor("()V");
		JniMethodInfo constructor2 = jniType2.GetConstructor("(Ljava/io/Writer;)V");
		JniObjectReference reference = jniType.NewObject(constructor, null);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(reference);
			JniObjectReference reference2 = jniType2.NewObject(constructor2, ptr);
			try
			{
				JniMethodInfo methodInfo = _members.InstanceMethods.GetMethodInfo("printStackTrace.(Ljava/io/PrintWriter;)V");
				JniArgumentValue* ptr2 = stackalloc JniArgumentValue[1];
				*ptr2 = new JniArgumentValue(reference2);
				JniEnvironment.InstanceMethods.CallVoidMethod(handle, methodInfo, ptr2);
				JniObjectReference value = JniEnvironment.Object.ToString(reference);
				return JniEnvironment.Strings.ToString(ref value, JniObjectReferenceOptions.CopyAndDispose);
			}
			finally
			{
				JniObjectReference.Dispose(ref reference2, JniObjectReferenceOptions.CopyAndDispose);
			}
		}
		finally
		{
			JniObjectReference.Dispose(ref reference, JniObjectReferenceOptions.CopyAndDispose);
		}
	}

	void IJavaPeerable.Disposed()
	{
		JniManagedPeerState |= (JniManagedPeerStates)4;
		Dispose(disposing: true);
	}

	void IJavaPeerable.Finalized()
	{
		JniManagedPeerState |= (JniManagedPeerStates)4;
		Dispose(disposing: false);
	}

	void IJavaPeerable.SetJniIdentityHashCode(int value)
	{
		JniIdentityHashCode = value;
	}

	void IJavaPeerable.SetJniManagedPeerState(JniManagedPeerStates value)
	{
		JniManagedPeerState = value;
	}

	unsafe void IJavaPeerable.SetPeerReference(JniObjectReference reference)
	{
		SetPeerReference(ref reference, JniObjectReferenceOptions.Copy);
		if (!reference.IsValid && JniManagedPeerState.HasFlag((JniManagedPeerStates)4))
		{
			JniObjectReferenceControlBlock.Free(ref jniObjectReferenceControlBlock);
		}
	}
}
