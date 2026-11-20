package com.scanflow.datacapture.barinternal.kotlinx.coroutines;

/* JADX INFO: compiled from: JobSupport.kt */
/* JADX INFO: loaded from: classes3.dex */
final class ChildHandleNode extends JobNode implements ChildHandle {
    public final ChildJob childJob;

    public ChildHandleNode(ChildJob childJob) {
        this.childJob = childJob;
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.ChildHandle
    public Job getParent() {
        return getJob();
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.JobNode
    public boolean getOnCancelling() {
        return true;
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.JobNode
    public void invoke(Throwable th) {
        this.childJob.parentCancelled(getJob());
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.ChildHandle
    public boolean childCancelled(Throwable th) {
        return getJob().childCancelled(th);
    }
}
