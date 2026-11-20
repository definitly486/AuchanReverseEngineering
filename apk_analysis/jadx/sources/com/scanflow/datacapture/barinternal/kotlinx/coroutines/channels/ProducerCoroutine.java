package com.scanflow.datacapture.barinternal.kotlinx.coroutines.channels;

import com.scanflow.datacapture.barinternal.kotlin.Unit;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.CoroutineExceptionHandlerKt;
import kotlin.coroutines.CoroutineContext;

/* JADX INFO: compiled from: Produce.kt */
/* JADX INFO: loaded from: classes3.dex */
final class ProducerCoroutine extends ChannelCoroutine implements ProducerScope {
    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.channels.ProducerScope
    public /* bridge */ /* synthetic */ SendChannel getChannel() {
        return getChannel();
    }

    public ProducerCoroutine(CoroutineContext coroutineContext, Channel channel) {
        super(coroutineContext, channel, true, true);
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.AbstractCoroutine, com.scanflow.datacapture.barinternal.kotlinx.coroutines.JobSupport, com.scanflow.datacapture.barinternal.kotlinx.coroutines.Job
    public boolean isActive() {
        return super.isActive();
    }

    /* JADX INFO: Access modifiers changed from: protected */
    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.AbstractCoroutine
    public void onCompleted(Unit unit) {
        SendChannel.DefaultImpls.close$default(get_channel(), null, 1, null);
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.AbstractCoroutine
    protected void onCancelled(Throwable th, boolean z) {
        if (get_channel().close(th) || z) {
            return;
        }
        CoroutineExceptionHandlerKt.handleCoroutineException(getContext(), th);
    }
}
