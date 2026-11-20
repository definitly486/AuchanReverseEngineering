package com.scanflow.datacapture.barinternal.kotlinx.coroutines;

import com.scanflow.datacapture.barinternal.kotlin.coroutines.intrinsics.IntrinsicsKt;
import kotlin.coroutines.Continuation;
import kotlin.coroutines.CoroutineContext;

/* JADX INFO: compiled from: Builders.common.kt */
/* JADX INFO: loaded from: classes3.dex */
class DeferredCoroutine extends AbstractCoroutine implements Deferred {
    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.Deferred
    public Object await(Continuation continuation) {
        return await$suspendImpl(this, continuation);
    }

    public DeferredCoroutine(CoroutineContext coroutineContext, boolean z) {
        super(coroutineContext, true, z);
    }

    static /* synthetic */ Object await$suspendImpl(DeferredCoroutine deferredCoroutine, Continuation continuation) throws Throwable {
        Object objAwaitInternal = deferredCoroutine.awaitInternal(continuation);
        IntrinsicsKt.getCOROUTINE_SUSPENDED();
        return objAwaitInternal;
    }
}
