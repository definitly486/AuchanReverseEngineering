package com.scanflow.datacapture.barinternal.kotlinx.coroutines.flow.internal;

import com.scanflow.datacapture.barinternal.kotlin.Unit;
import com.scanflow.datacapture.barinternal.kotlin.coroutines.intrinsics.IntrinsicsKt;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.channels.SendChannel;
import kotlin.coroutines.Continuation;
import kotlinx.coroutines.flow.FlowCollector;

/* JADX INFO: compiled from: SendingCollector.kt */
/* JADX INFO: loaded from: classes3.dex */
public final class SendingCollector implements FlowCollector {
    private final SendChannel channel;

    public SendingCollector(SendChannel sendChannel) {
        this.channel = sendChannel;
    }

    @Override // kotlinx.coroutines.flow.FlowCollector
    public Object emit(Object obj, Continuation continuation) {
        Object objSend = this.channel.send(obj, continuation);
        return objSend == IntrinsicsKt.getCOROUTINE_SUSPENDED() ? objSend : Unit.INSTANCE;
    }
}
