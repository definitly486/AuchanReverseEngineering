package com.scanflow.datacapture.barinternal.kotlinx.coroutines.channels;

import com.scanflow.datacapture.barinternal.kotlinx.coroutines.ExceptionsKt;
import java.util.concurrent.CancellationException;

/* JADX INFO: compiled from: Channels.common.kt */
/* JADX INFO: loaded from: classes3.dex */
abstract /* synthetic */ class ChannelsKt__Channels_commonKt {
    public static final void cancelConsumed(ReceiveChannel receiveChannel, Throwable th) {
        CancellationException CancellationException = null;
        if (th != null) {
            CancellationException = th instanceof CancellationException ? (CancellationException) th : null;
            if (CancellationException == null) {
                CancellationException = ExceptionsKt.CancellationException("Channel was consumed, consumer had failed", th);
            }
        }
        receiveChannel.cancel(CancellationException);
    }
}
