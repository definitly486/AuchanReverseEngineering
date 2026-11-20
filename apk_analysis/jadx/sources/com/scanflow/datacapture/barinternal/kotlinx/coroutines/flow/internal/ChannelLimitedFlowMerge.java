package com.scanflow.datacapture.barinternal.kotlinx.coroutines.flow.internal;

import com.scanflow.datacapture.barinternal.kotlin.Unit;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.BuildersKt__Builders_commonKt;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.channels.BufferOverflow;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.channels.ProduceKt;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.channels.ProducerScope;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.channels.ReceiveChannel;
import java.util.Iterator;
import kotlin.coroutines.Continuation;
import kotlin.coroutines.CoroutineContext;
import kotlin.coroutines.EmptyCoroutineContext;
import kotlin.jvm.internal.DefaultConstructorMarker;
import kotlinx.coroutines.CoroutineScope;
import kotlinx.coroutines.flow.Flow;

/* JADX INFO: compiled from: Merge.kt */
/* JADX INFO: loaded from: classes3.dex */
public final class ChannelLimitedFlowMerge extends ChannelFlow {
    private final Iterable flows;

    public /* synthetic */ ChannelLimitedFlowMerge(Iterable iterable, CoroutineContext coroutineContext, int i, BufferOverflow bufferOverflow, int i2, DefaultConstructorMarker defaultConstructorMarker) {
        this(iterable, (i2 & 2) != 0 ? EmptyCoroutineContext.INSTANCE : coroutineContext, (i2 & 4) != 0 ? -2 : i, (i2 & 8) != 0 ? BufferOverflow.SUSPEND : bufferOverflow);
    }

    public ChannelLimitedFlowMerge(Iterable iterable, CoroutineContext coroutineContext, int i, BufferOverflow bufferOverflow) {
        super(coroutineContext, i, bufferOverflow);
        this.flows = iterable;
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.flow.internal.ChannelFlow
    protected ChannelFlow create(CoroutineContext coroutineContext, int i, BufferOverflow bufferOverflow) {
        return new ChannelLimitedFlowMerge(this.flows, coroutineContext, i, bufferOverflow);
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.flow.internal.ChannelFlow
    public ReceiveChannel produceImpl(CoroutineScope coroutineScope) {
        return ProduceKt.produce(coroutineScope, this.context, this.capacity, getCollectToFun$kotlinx_coroutines_core());
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.flow.internal.ChannelFlow
    protected Object collectTo(ProducerScope producerScope, Continuation continuation) {
        SendingCollector sendingCollector = new SendingCollector(producerScope);
        Iterator it = this.flows.iterator();
        while (it.hasNext()) {
            BuildersKt__Builders_commonKt.launch$default(producerScope, null, null, new ChannelLimitedFlowMerge$collectTo$2$1((Flow) it.next(), sendingCollector, null), 3, null);
        }
        return Unit.INSTANCE;
    }
}
