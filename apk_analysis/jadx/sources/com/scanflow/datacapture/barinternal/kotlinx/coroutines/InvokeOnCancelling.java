package com.scanflow.datacapture.barinternal.kotlinx.coroutines;

import java.util.concurrent.atomic.AtomicIntegerFieldUpdater;
import kotlin.jvm.functions.Function1;

/* JADX INFO: compiled from: JobSupport.kt */
/* JADX INFO: loaded from: classes3.dex */
final class InvokeOnCancelling extends JobNode {
    private static final /* synthetic */ AtomicIntegerFieldUpdater _invoked$volatile$FU = AtomicIntegerFieldUpdater.newUpdater(InvokeOnCancelling.class, "_invoked$volatile");
    private volatile /* synthetic */ int _invoked$volatile;
    private final Function1 handler;

    public InvokeOnCancelling(Function1 function1) {
        this.handler = function1;
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.JobNode
    public boolean getOnCancelling() {
        return true;
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.JobNode
    public void invoke(Throwable th) {
        if (_invoked$volatile$FU.compareAndSet(this, 0, 1)) {
            this.handler.invoke(th);
        }
    }
}
