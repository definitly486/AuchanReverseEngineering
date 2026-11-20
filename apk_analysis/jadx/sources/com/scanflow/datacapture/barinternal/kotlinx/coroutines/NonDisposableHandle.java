package com.scanflow.datacapture.barinternal.kotlinx.coroutines;

/* JADX INFO: compiled from: Job.kt */
/* JADX INFO: loaded from: classes3.dex */
public final class NonDisposableHandle implements DisposableHandle, ChildHandle {
    public static final NonDisposableHandle INSTANCE = new NonDisposableHandle();

    private NonDisposableHandle() {
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.ChildHandle
    public Job getParent() {
        return null;
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.DisposableHandle
    public void dispose() {
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.ChildHandle
    public boolean childCancelled(Throwable th) {
        return false;
    }

    public String toString() {
        return "NonDisposableHandle";
    }
}
