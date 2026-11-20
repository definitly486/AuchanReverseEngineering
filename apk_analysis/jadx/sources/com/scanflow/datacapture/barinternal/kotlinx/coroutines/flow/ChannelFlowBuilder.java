package com.scanflow.datacapture.barinternal.kotlinx.coroutines.flow;

import com.scanflow.datacapture.barinternal.kotlin.Unit;
import com.scanflow.datacapture.barinternal.kotlin.coroutines.intrinsics.IntrinsicsKt;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.channels.BufferOverflow;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.channels.ProducerScope;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.flow.internal.ChannelFlow;
import kotlin.coroutines.Continuation;
import kotlin.coroutines.CoroutineContext;
import kotlin.jvm.functions.Function2;

/* JADX INFO: compiled from: Builders.kt */
/* JADX INFO: loaded from: classes3.dex */
abstract class ChannelFlowBuilder extends ChannelFlow {
    private final Function2 block;

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.flow.internal.ChannelFlow
    protected Object collectTo(ProducerScope producerScope, Continuation continuation) {
        return collectTo$suspendImpl(this, producerScope, continuation);
    }

    public ChannelFlowBuilder(Function2 function2, CoroutineContext coroutineContext, int i, BufferOverflow bufferOverflow) {
        super(coroutineContext, i, bufferOverflow);
        this.block = function2;
    }

    static /* synthetic */ Object collectTo$suspendImpl(ChannelFlowBuilder channelFlowBuilder, ProducerScope producerScope, Continuation continuation) {
        Object objInvoke = channelFlowBuilder.block.invoke(producerScope, continuation);
        return objInvoke == IntrinsicsKt.getCOROUTINE_SUSPENDED() ? objInvoke : Unit.INSTANCE;
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.flow.internal.ChannelFlow
    public String toString() {
        return "block[" + this.block + "] -> " + super.toString();
    }
}
