package com.scanflow.datacapture.barinternal.kotlinx.coroutines.flow;

import com.scanflow.datacapture.barinternal.kotlinx.coroutines.flow.internal.AbstractSharedFlowSlot;
import kotlin.coroutines.Continuation;

/* JADX INFO: compiled from: SharedFlow.kt */
/* JADX INFO: loaded from: classes3.dex */
public final class SharedFlowSlot extends AbstractSharedFlowSlot {
    public Continuation cont;
    public long index = -1;

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.flow.internal.AbstractSharedFlowSlot
    public boolean allocateLocked(SharedFlowImpl sharedFlowImpl) {
        if (this.index >= 0) {
            return false;
        }
        this.index = sharedFlowImpl.updateNewCollectorIndexLocked$kotlinx_coroutines_core();
        return true;
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.flow.internal.AbstractSharedFlowSlot
    public Continuation[] freeLocked(SharedFlowImpl sharedFlowImpl) {
        long j = this.index;
        this.index = -1L;
        this.cont = null;
        return sharedFlowImpl.updateCollectorIndexLocked$kotlinx_coroutines_core(j);
    }
}
