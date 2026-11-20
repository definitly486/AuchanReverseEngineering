package com.scanflow.datacapture.barinternal.kotlinx.coroutines.flow;

import com.scanflow.datacapture.barinternal.kotlin.Unit;
import com.scanflow.datacapture.barinternal.kotlin.coroutines.intrinsics.IntrinsicsKt;
import kotlin.coroutines.Continuation;
import kotlin.jvm.functions.Function2;
import kotlinx.coroutines.flow.FlowCollector;

/* JADX INFO: compiled from: Builders.kt */
/* JADX INFO: loaded from: classes3.dex */
final class SafeFlow extends AbstractFlow {
    private final Function2 block;

    public SafeFlow(Function2 function2) {
        this.block = function2;
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.flow.AbstractFlow
    public Object collectSafely(FlowCollector flowCollector, Continuation continuation) {
        Object objInvoke = this.block.invoke(flowCollector, continuation);
        return objInvoke == IntrinsicsKt.getCOROUTINE_SUSPENDED() ? objInvoke : Unit.INSTANCE;
    }
}
