package com.scanflow.datacapture.barinternal.kotlinx.coroutines;

import com.scanflow.datacapture.barinternal.kotlinx.coroutines.internal.ScopeCoroutine;
import kotlin.coroutines.Continuation;

/* JADX INFO: compiled from: Timeout.kt */
/* JADX INFO: loaded from: classes3.dex */
final class TimeoutCoroutine extends ScopeCoroutine implements Runnable {
    public final long time;

    public TimeoutCoroutine(long j, Continuation continuation) {
        super(continuation.getContext(), continuation);
        this.time = j;
    }

    @Override // java.lang.Runnable
    public void run() {
        cancelCoroutine(TimeoutKt.TimeoutCancellationException(this.time, DelayKt.getDelay(getContext()), this));
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.AbstractCoroutine, com.scanflow.datacapture.barinternal.kotlinx.coroutines.JobSupport
    public String nameString$kotlinx_coroutines_core() {
        return super.nameString$kotlinx_coroutines_core() + "(timeMillis=" + this.time + ')';
    }
}
