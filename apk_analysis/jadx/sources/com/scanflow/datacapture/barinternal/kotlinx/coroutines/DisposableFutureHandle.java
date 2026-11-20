package com.scanflow.datacapture.barinternal.kotlinx.coroutines;

import java.util.concurrent.Future;

/* JADX INFO: compiled from: Executors.kt */
/* JADX INFO: loaded from: classes3.dex */
final class DisposableFutureHandle implements DisposableHandle {
    private final Future future;

    public DisposableFutureHandle(Future future) {
        this.future = future;
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.DisposableHandle
    public void dispose() {
        this.future.cancel(false);
    }

    public String toString() {
        return "DisposableFutureHandle[" + this.future + ']';
    }
}
