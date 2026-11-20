package com.scanflow.datacapture.barinternal.kotlinx.coroutines.flow;

import com.scanflow.datacapture.barinternal.kotlinx.coroutines.channels.BufferOverflow;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.flow.internal.NullSurrogateKt;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.internal.Symbol;
import kotlin.coroutines.CoroutineContext;
import kotlinx.coroutines.flow.Flow;
import kotlinx.coroutines.flow.StateFlow;

/* JADX INFO: compiled from: StateFlow.kt */
/* JADX INFO: loaded from: classes3.dex */
public abstract class StateFlowKt {
    private static final Symbol NONE = new Symbol("NONE");
    private static final Symbol PENDING = new Symbol("PENDING");

    public static final MutableStateFlow MutableStateFlow(Object obj) {
        if (obj == null) {
            obj = NullSurrogateKt.NULL;
        }
        return new StateFlowImpl(obj);
    }

    public static final Flow fuseStateFlow(StateFlow stateFlow, CoroutineContext coroutineContext, int i, BufferOverflow bufferOverflow) {
        return (((i < 0 || i >= 2) && i != -2) || bufferOverflow != BufferOverflow.DROP_OLDEST) ? SharedFlowKt.fuseSharedFlow(stateFlow, coroutineContext, i, bufferOverflow) : stateFlow;
    }
}
