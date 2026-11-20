package com.scanflow.datacapture.barinternal.kotlinx.coroutines.sync;

import kotlin.coroutines.Continuation;

/* JADX INFO: compiled from: Mutex.kt */
/* JADX INFO: loaded from: classes3.dex */
public interface Mutex {
    Object lock(Object obj, Continuation continuation);

    void unlock(Object obj);
}
