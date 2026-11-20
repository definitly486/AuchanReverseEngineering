package com.scanflow.datacapture.barinternal.kotlinx.coroutines.channels;

import kotlin.coroutines.Continuation;

/* JADX INFO: compiled from: Channel.kt */
/* JADX INFO: loaded from: classes3.dex */
public interface ChannelIterator {
    Object hasNext(Continuation continuation);

    Object next();
}
