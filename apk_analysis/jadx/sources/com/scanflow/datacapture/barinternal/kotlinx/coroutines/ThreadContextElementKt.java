package com.scanflow.datacapture.barinternal.kotlinx.coroutines;

import com.scanflow.datacapture.barinternal.kotlinx.coroutines.internal.ThreadLocalElement;

/* JADX INFO: compiled from: ThreadContextElement.kt */
/* JADX INFO: loaded from: classes3.dex */
public abstract class ThreadContextElementKt {
    public static final ThreadContextElement asContextElement(ThreadLocal threadLocal, Object obj) {
        return new ThreadLocalElement(obj, threadLocal);
    }
}
