package com.scanflow.datacapture.barinternal.kotlinx.coroutines;

/* JADX INFO: compiled from: Supervisor.kt */
/* JADX INFO: loaded from: classes3.dex */
final class SupervisorJobImpl extends JobImpl {
    public SupervisorJobImpl(Job job) {
        super(job);
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.JobSupport
    public boolean childCancelled(Throwable th) {
        return false;
    }
}
