package com.scanflow.datacapture.barinternal.kotlinx.coroutines;

import com.scanflow.datacapture.barinternal.kotlin.coroutines.intrinsics.IntrinsicsKt;
import kotlin.coroutines.Continuation;

/* JADX INFO: compiled from: CompletableDeferred.kt */
/* JADX INFO: loaded from: classes3.dex */
final class CompletableDeferredImpl extends JobSupport implements CompletableDeferred {
    public CompletableDeferredImpl(Job job) {
        super(true);
        initParentJob(job);
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.JobSupport
    public boolean getOnCancelComplete$kotlinx_coroutines_core() {
        return true;
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.Deferred
    public Object getCompleted() {
        return getCompletedInternal$kotlinx_coroutines_core();
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.Deferred
    public Object await(Continuation continuation) throws Throwable {
        Object objAwaitInternal = awaitInternal(continuation);
        IntrinsicsKt.getCOROUTINE_SUSPENDED();
        return objAwaitInternal;
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.CompletableDeferred
    public boolean complete(Object obj) {
        return makeCompleting$kotlinx_coroutines_core(obj);
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.CompletableDeferred
    public boolean completeExceptionally(Throwable th) {
        return makeCompleting$kotlinx_coroutines_core(new CompletedExceptionally(th, false, 2, null));
    }
}
