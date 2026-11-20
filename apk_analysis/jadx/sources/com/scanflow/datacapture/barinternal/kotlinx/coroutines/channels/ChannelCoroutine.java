package com.scanflow.datacapture.barinternal.kotlinx.coroutines.channels;

import com.scanflow.datacapture.barinternal.kotlin.coroutines.intrinsics.IntrinsicsKt;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.AbstractCoroutine;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.JobCancellationException;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.JobSupport;
import java.util.concurrent.CancellationException;
import kotlin.coroutines.Continuation;
import kotlin.coroutines.CoroutineContext;
import kotlin.jvm.functions.Function1;

/* JADX INFO: compiled from: ChannelCoroutine.kt */
/* JADX INFO: loaded from: classes3.dex */
public abstract class ChannelCoroutine extends AbstractCoroutine implements Channel {
    private final Channel _channel;

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.channels.SendChannel
    public boolean close(Throwable th) {
        return this._channel.close(th);
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.channels.SendChannel
    public void invokeOnClose(Function1 function1) {
        this._channel.invokeOnClose(function1);
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.channels.SendChannel
    public boolean isClosedForSend() {
        return this._channel.isClosedForSend();
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.channels.ReceiveChannel
    public ChannelIterator iterator() {
        return this._channel.iterator();
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.channels.ReceiveChannel
    /* JADX INFO: renamed from: receiveCatching-JP2dKIU */
    public Object mo837receiveCatchingJP2dKIU(Continuation continuation) {
        Object objMo837receiveCatchingJP2dKIU = this._channel.mo837receiveCatchingJP2dKIU(continuation);
        IntrinsicsKt.getCOROUTINE_SUSPENDED();
        return objMo837receiveCatchingJP2dKIU;
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.channels.SendChannel
    public Object send(Object obj, Continuation continuation) {
        return this._channel.send(obj, continuation);
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.channels.ReceiveChannel
    /* JADX INFO: renamed from: tryReceive-PtdJZtk */
    public Object mo838tryReceivePtdJZtk() {
        return this._channel.mo838tryReceivePtdJZtk();
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.channels.SendChannel
    /* JADX INFO: renamed from: trySend-JP2dKIU */
    public Object mo839trySendJP2dKIU(Object obj) {
        return this._channel.mo839trySendJP2dKIU(obj);
    }

    protected final Channel get_channel() {
        return this._channel;
    }

    public ChannelCoroutine(CoroutineContext coroutineContext, Channel channel, boolean z, boolean z2) {
        super(coroutineContext, z, z2);
        this._channel = channel;
    }

    public final Channel getChannel() {
        return this;
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.JobSupport, com.scanflow.datacapture.barinternal.kotlinx.coroutines.Job
    public final void cancel(CancellationException cancellationException) {
        if (isCancelled()) {
            return;
        }
        if (cancellationException == null) {
            cancellationException = new JobCancellationException(cancellationExceptionMessage(), null, this);
        }
        cancelInternal(cancellationException);
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.JobSupport
    public void cancelInternal(Throwable th) {
        CancellationException cancellationException$default = JobSupport.toCancellationException$default(this, th, null, 1, null);
        this._channel.cancel(cancellationException$default);
        cancelCoroutine(cancellationException$default);
    }
}
