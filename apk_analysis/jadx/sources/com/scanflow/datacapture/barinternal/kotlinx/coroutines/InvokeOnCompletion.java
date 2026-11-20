package com.scanflow.datacapture.barinternal.kotlinx.coroutines;

import kotlin.jvm.functions.Function1;

/* JADX INFO: compiled from: JobSupport.kt */
/* JADX INFO: loaded from: classes3.dex */
final class InvokeOnCompletion extends JobNode {
    private final Function1 handler;

    public InvokeOnCompletion(Function1 function1) {
        this.handler = function1;
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.JobNode
    public boolean getOnCancelling() {
        return false;
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.JobNode
    public void invoke(Throwable th) {
        this.handler.invoke(th);
    }
}
