package com.scanflow.datacapture.barinternal.kotlinx.coroutines.channels;

import java.util.concurrent.CancellationException;
import kotlin.coroutines.Continuation;

/* JADX INFO: compiled from: Channel.kt */
/* JADX INFO: loaded from: classes3.dex */
public interface ReceiveChannel {
    void cancel(CancellationException cancellationException);

    ChannelIterator iterator();

    /* JADX INFO: renamed from: receiveCatching-JP2dKIU */
    Object mo837receiveCatchingJP2dKIU(Continuation continuation);

    /* JADX INFO: renamed from: tryReceive-PtdJZtk */
    Object mo838tryReceivePtdJZtk();
}
