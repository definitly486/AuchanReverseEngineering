package com.scanflow.datacapture.barinternal.kotlinx.coroutines;

/* JADX INFO: compiled from: CancellableContinuationImpl.kt */
/* JADX INFO: loaded from: classes3.dex */
final class ChildContinuation extends JobNode {
    public final CancellableContinuationImpl child;

    public ChildContinuation(CancellableContinuationImpl cancellableContinuationImpl) {
        this.child = cancellableContinuationImpl;
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.JobNode
    public boolean getOnCancelling() {
        return true;
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.JobNode
    public void invoke(Throwable th) {
        CancellableContinuationImpl cancellableContinuationImpl = this.child;
        cancellableContinuationImpl.parentCancelled$kotlinx_coroutines_core(cancellableContinuationImpl.getContinuationCancellationCause(getJob()));
    }
}
