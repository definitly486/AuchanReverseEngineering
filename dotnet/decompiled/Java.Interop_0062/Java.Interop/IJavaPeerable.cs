using System;

namespace Java.Interop;

public interface IJavaPeerable : IDisposable
{
	int JniIdentityHashCode { get; }

	JniObjectReference PeerReference { get; }

	JniPeerMembers JniPeerMembers { get; }

	JniManagedPeerStates JniManagedPeerState { get; }

	nint JniObjectReferenceControlBlock => IntPtr.Zero;

	void SetJniIdentityHashCode(int value);

	void SetPeerReference(JniObjectReference reference);

	void SetJniManagedPeerState(JniManagedPeerStates value);

	void UnregisterFromRuntime();

	void DisposeUnlessReferenced();

	void Disposed();

	void Finalized();
}
