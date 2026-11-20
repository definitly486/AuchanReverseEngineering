package com.scanflow.datacapture.barinternal.kotlinx.coroutines;

import com.scanflow.datacapture.barinternal.kotlin.coroutines.intrinsics.IntrinsicsKt;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.internal.DispatchedContinuationKt;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.internal.ScopeCoroutine;
import java.util.concurrent.atomic.AtomicIntegerFieldUpdater;
import kotlin.coroutines.Continuation;
import kotlin.coroutines.CoroutineContext;

/* JADX INFO: compiled from: Builders.common.kt */
/* JADX INFO: loaded from: classes3.dex */
public final class DispatchedCoroutine extends ScopeCoroutine {
    private static final /* synthetic */ AtomicIntegerFieldUpdater _decision$volatile$FU = AtomicIntegerFieldUpdater.newUpdater(DispatchedCoroutine.class, "_decision$volatile");
    private volatile /* synthetic */ int _decision$volatile;

    public DispatchedCoroutine(CoroutineContext coroutineContext, Continuation continuation) {
        super(coroutineContext, continuation);
    }

    private final boolean trySuspend() {
        AtomicIntegerFieldUpdater atomicIntegerFieldUpdater = _decision$volatile$FU;
        do {
            int i = atomicIntegerFieldUpdater.get(this);
            if (i != 0) {
                if (i == 2) {
                    return false;
                }
                throw new IllegalStateException("Already suspended");
            }
        } while (!_decision$volatile$FU.compareAndSet(this, 0, 1));
        return true;
    }

    private final boolean tryResume() {
        AtomicIntegerFieldUpdater atomicIntegerFieldUpdater = _decision$volatile$FU;
        do {
            int i = atomicIntegerFieldUpdater.get(this);
            if (i != 0) {
                if (i == 1) {
                    return false;
                }
                throw new IllegalStateException("Already resumed");
            }
        } while (!_decision$volatile$FU.compareAndSet(this, 0, 2));
        return true;
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.internal.ScopeCoroutine, com.scanflow.datacapture.barinternal.kotlinx.coroutines.JobSupport
    protected void afterCompletion(Object obj) {
        afterResume(obj);
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.internal.ScopeCoroutine, com.scanflow.datacapture.barinternal.kotlinx.coroutines.AbstractCoroutine
    protected void afterResume(Object obj) {
        if (tryResume()) {
            return;
        }
        DispatchedContinuationKt.resumeCancellableWith(IntrinsicsKt.intercepted(this.uCont), CompletionStateKt.recoverResult(obj, this.uCont));
    }

    public final Object getResult$kotlinx_coroutines_core() {
        if (trySuspend()) {
            return IntrinsicsKt.getCOROUTINE_SUSPENDED();
        }
        Object objUnboxState = JobSupportKt.unboxState(getState$kotlinx_coroutines_core());
        if (objUnboxState instanceof CompletedExceptionally) {
            throw ((CompletedExceptionally) objUnboxState).cause;
        }
        return objUnboxState;
    }
}
