package com.scanflow.datacapture.barinternal.kotlinx.coroutines.flow;

import androidx.camera.view.PreviewView$1$$ExternalSyntheticBackportWithForwarding0;
import com.scanflow.datacapture.barinternal.kotlin.Result;
import com.scanflow.datacapture.barinternal.kotlin.Unit;
import com.scanflow.datacapture.barinternal.kotlin.coroutines.intrinsics.IntrinsicsKt;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.CancellableContinuationImpl;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.flow.internal.AbstractSharedFlowKt;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.flow.internal.AbstractSharedFlowSlot;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.internal.Concurrent_commonKt;
import java.util.concurrent.atomic.AtomicReference;
import kotlin.coroutines.Continuation;
import kotlin.coroutines.jvm.internal.DebugProbesKt;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: StateFlow.kt */
/* JADX INFO: loaded from: classes3.dex */
final class StateFlowSlot extends AbstractSharedFlowSlot {
    private final AtomicReference _state = new AtomicReference(null);

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.flow.internal.AbstractSharedFlowSlot
    public boolean allocateLocked(StateFlowImpl stateFlowImpl) {
        if (Concurrent_commonKt.getValue(this._state) != null) {
            return false;
        }
        Concurrent_commonKt.setValue(this._state, StateFlowKt.NONE);
        return true;
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.flow.internal.AbstractSharedFlowSlot
    public Continuation[] freeLocked(StateFlowImpl stateFlowImpl) {
        Concurrent_commonKt.setValue(this._state, null);
        return AbstractSharedFlowKt.EMPTY_RESUMES;
    }

    public final void makePending() {
        AtomicReference atomicReference = this._state;
        while (true) {
            Object value = Concurrent_commonKt.getValue(atomicReference);
            if (value == null || value == StateFlowKt.PENDING) {
                return;
            }
            if (value == StateFlowKt.NONE) {
                if (PreviewView$1$$ExternalSyntheticBackportWithForwarding0.m(this._state, value, StateFlowKt.PENDING)) {
                    return;
                }
            } else if (PreviewView$1$$ExternalSyntheticBackportWithForwarding0.m(this._state, value, StateFlowKt.NONE)) {
                Result.Companion companion = Result.Companion;
                ((CancellableContinuationImpl) value).resumeWith(Result.m681constructorimpl(Unit.INSTANCE));
                return;
            }
        }
    }

    public final boolean takePending() {
        Object andSet = this._state.getAndSet(StateFlowKt.NONE);
        Intrinsics.checkNotNull(andSet);
        return andSet == StateFlowKt.PENDING;
    }

    public final Object awaitPending(Continuation continuation) {
        CancellableContinuationImpl cancellableContinuationImpl = new CancellableContinuationImpl(IntrinsicsKt.intercepted(continuation), 1);
        cancellableContinuationImpl.initCancellability();
        if (!PreviewView$1$$ExternalSyntheticBackportWithForwarding0.m(this._state, StateFlowKt.NONE, cancellableContinuationImpl)) {
            Result.Companion companion = Result.Companion;
            cancellableContinuationImpl.resumeWith(Result.m681constructorimpl(Unit.INSTANCE));
        }
        Object result = cancellableContinuationImpl.getResult();
        if (result == IntrinsicsKt.getCOROUTINE_SUSPENDED()) {
            DebugProbesKt.probeCoroutineSuspended(continuation);
        }
        return result == IntrinsicsKt.getCOROUTINE_SUSPENDED() ? result : Unit.INSTANCE;
    }
}
