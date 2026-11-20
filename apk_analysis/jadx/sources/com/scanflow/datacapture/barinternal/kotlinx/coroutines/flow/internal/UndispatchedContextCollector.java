package com.scanflow.datacapture.barinternal.kotlinx.coroutines.flow.internal;

import com.scanflow.datacapture.barinternal.kotlin.Unit;
import com.scanflow.datacapture.barinternal.kotlin.coroutines.intrinsics.IntrinsicsKt;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.internal.ThreadContextKt;
import kotlin.coroutines.Continuation;
import kotlin.coroutines.CoroutineContext;
import kotlin.jvm.functions.Function2;
import kotlinx.coroutines.flow.FlowCollector;

/* JADX INFO: compiled from: ChannelFlow.kt */
/* JADX INFO: loaded from: classes3.dex */
final class UndispatchedContextCollector implements FlowCollector {
    private final Object countOrElement;
    private final CoroutineContext emitContext;
    private final Function2 emitRef;

    public UndispatchedContextCollector(FlowCollector flowCollector, CoroutineContext coroutineContext) {
        this.emitContext = coroutineContext;
        this.countOrElement = ThreadContextKt.threadContextElements(coroutineContext);
        this.emitRef = new UndispatchedContextCollector$emitRef$1(flowCollector, null);
    }

    @Override // kotlinx.coroutines.flow.FlowCollector
    public Object emit(Object obj, Continuation continuation) {
        Object objWithContextUndispatched = ChannelFlowKt.withContextUndispatched(this.emitContext, obj, this.countOrElement, this.emitRef, continuation);
        return objWithContextUndispatched == IntrinsicsKt.getCOROUTINE_SUSPENDED() ? objWithContextUndispatched : Unit.INSTANCE;
    }
}
