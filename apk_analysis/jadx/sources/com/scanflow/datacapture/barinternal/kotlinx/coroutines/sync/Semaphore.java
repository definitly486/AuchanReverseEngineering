package com.scanflow.datacapture.barinternal.kotlinx.coroutines.sync;

import kotlin.coroutines.Continuation;

/* JADX INFO: compiled from: Semaphore.kt */
/* JADX INFO: loaded from: classes3.dex */
public interface Semaphore {
    Object acquire(Continuation continuation);

    int getAvailablePermits();

    void release();
}
