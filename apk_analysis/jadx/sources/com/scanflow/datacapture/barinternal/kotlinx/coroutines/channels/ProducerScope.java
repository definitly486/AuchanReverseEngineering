package com.scanflow.datacapture.barinternal.kotlinx.coroutines.channels;

import kotlinx.coroutines.CoroutineScope;

/* JADX INFO: compiled from: Produce.kt */
/* JADX INFO: loaded from: classes3.dex */
public interface ProducerScope extends CoroutineScope, SendChannel {
    SendChannel getChannel();
}
