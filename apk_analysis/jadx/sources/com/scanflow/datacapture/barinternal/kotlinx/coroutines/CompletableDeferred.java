package com.scanflow.datacapture.barinternal.kotlinx.coroutines;

/* JADX INFO: compiled from: CompletableDeferred.kt */
/* JADX INFO: loaded from: classes3.dex */
public interface CompletableDeferred extends Deferred {
    boolean complete(Object obj);

    boolean completeExceptionally(Throwable th);
}
