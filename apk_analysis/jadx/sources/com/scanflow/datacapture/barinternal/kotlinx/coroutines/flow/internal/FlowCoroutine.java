package com.scanflow.datacapture.barinternal.kotlinx.coroutines.flow.internal;

import com.scanflow.datacapture.barinternal.kotlinx.coroutines.internal.ScopeCoroutine;
import kotlin.coroutines.Continuation;
import kotlin.coroutines.CoroutineContext;

/* JADX INFO: compiled from: FlowCoroutine.kt */
/* JADX INFO: loaded from: classes3.dex */
final class FlowCoroutine extends ScopeCoroutine {
    public FlowCoroutine(CoroutineContext coroutineContext, Continuation continuation) {
        super(coroutineContext, continuation);
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.JobSupport
    public boolean childCancelled(Throwable th) {
        return cancelImpl$kotlinx_coroutines_core(th);
    }
}
