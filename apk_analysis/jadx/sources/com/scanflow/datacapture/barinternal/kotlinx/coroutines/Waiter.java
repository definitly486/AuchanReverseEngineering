package com.scanflow.datacapture.barinternal.kotlinx.coroutines;

import com.scanflow.datacapture.barinternal.kotlinx.coroutines.internal.Segment;

/* JADX INFO: compiled from: Waiter.kt */
/* JADX INFO: loaded from: classes3.dex */
public interface Waiter {
    void invokeOnCancellation(Segment segment, int i);
}
