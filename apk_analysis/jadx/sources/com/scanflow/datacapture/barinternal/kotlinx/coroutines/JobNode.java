package com.scanflow.datacapture.barinternal.kotlinx.coroutines;

import com.scanflow.datacapture.barinternal.kotlinx.coroutines.internal.LockFreeLinkedListNode;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: JobSupport.kt */
/* JADX INFO: loaded from: classes3.dex */
public abstract class JobNode extends LockFreeLinkedListNode implements DisposableHandle, Incomplete {
    public JobSupport job;

    public abstract boolean getOnCancelling();

    public abstract void invoke(Throwable th);

    public final JobSupport getJob() {
        JobSupport jobSupport = this.job;
        if (jobSupport != null) {
            return jobSupport;
        }
        Intrinsics.throwUninitializedPropertyAccessException("job");
        return null;
    }

    public final void setJob(JobSupport jobSupport) {
        this.job = jobSupport;
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.Incomplete
    public boolean isActive() {
        return true;
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.Incomplete
    public NodeList getList() {
        return null;
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.DisposableHandle
    public void dispose() {
        getJob().removeNode$kotlinx_coroutines_core(this);
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.internal.LockFreeLinkedListNode
    public String toString() {
        return DebugStringsKt.getClassSimpleName(this) + '@' + DebugStringsKt.getHexAddress(this) + "[job@" + DebugStringsKt.getHexAddress(getJob()) + ']';
    }
}
