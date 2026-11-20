package com.scanflow.datacapture.barinternal.kotlinx.coroutines.flow;

import com.scanflow.datacapture.barinternal.kotlinx.coroutines.Job;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.channels.BufferOverflow;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.flow.internal.FusibleFlow;
import java.util.List;
import kotlin.coroutines.Continuation;
import kotlin.coroutines.CoroutineContext;
import kotlinx.coroutines.flow.Flow;
import kotlinx.coroutines.flow.FlowCollector;
import kotlinx.coroutines.flow.StateFlow;

/* JADX INFO: compiled from: Share.kt */
/* JADX INFO: loaded from: classes3.dex */
final class ReadonlyStateFlow implements StateFlow, Flow, FusibleFlow {
    private final /* synthetic */ StateFlow $$delegate_0;
    private final Job job;

    @Override // kotlinx.coroutines.flow.SharedFlow, kotlinx.coroutines.flow.Flow
    public Object collect(FlowCollector flowCollector, Continuation continuation) {
        return this.$$delegate_0.collect(flowCollector, continuation);
    }

    @Override // kotlinx.coroutines.flow.SharedFlow
    public List getReplayCache() {
        return this.$$delegate_0.getReplayCache();
    }

    @Override // kotlinx.coroutines.flow.StateFlow
    public Object getValue() {
        return this.$$delegate_0.getValue();
    }

    public ReadonlyStateFlow(StateFlow stateFlow, Job job) {
        this.$$delegate_0 = stateFlow;
        this.job = job;
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.flow.internal.FusibleFlow
    public Flow fuse(CoroutineContext coroutineContext, int i, BufferOverflow bufferOverflow) {
        return StateFlowKt.fuseStateFlow(this, coroutineContext, i, bufferOverflow);
    }
}
