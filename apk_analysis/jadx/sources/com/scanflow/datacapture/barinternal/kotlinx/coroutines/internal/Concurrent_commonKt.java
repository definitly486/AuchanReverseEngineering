package com.scanflow.datacapture.barinternal.kotlinx.coroutines.internal;

import java.util.concurrent.atomic.AtomicReference;

/* JADX INFO: compiled from: Concurrent.common.kt */
/* JADX INFO: loaded from: classes3.dex */
public abstract class Concurrent_commonKt {
    public static final Object getValue(AtomicReference atomicReference) {
        return atomicReference.get();
    }

    public static final void setValue(AtomicReference atomicReference, Object obj) {
        atomicReference.set(obj);
    }
}
