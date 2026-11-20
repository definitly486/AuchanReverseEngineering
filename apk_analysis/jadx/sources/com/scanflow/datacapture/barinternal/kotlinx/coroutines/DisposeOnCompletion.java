package com.scanflow.datacapture.barinternal.kotlinx.coroutines;

/* JADX INFO: compiled from: Job.kt */
/* JADX INFO: loaded from: classes3.dex */
final class DisposeOnCompletion extends JobNode {
    private final DisposableHandle handle;

    public DisposeOnCompletion(DisposableHandle disposableHandle) {
        this.handle = disposableHandle;
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.JobNode
    public boolean getOnCancelling() {
        return false;
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.JobNode
    public void invoke(Throwable th) {
        this.handle.dispose();
    }
}
