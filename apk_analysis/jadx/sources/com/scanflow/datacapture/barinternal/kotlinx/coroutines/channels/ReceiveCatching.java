package com.scanflow.datacapture.barinternal.kotlinx.coroutines.channels;

import com.scanflow.datacapture.barinternal.kotlinx.coroutines.CancellableContinuationImpl;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.Waiter;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.internal.Segment;

/* JADX INFO: compiled from: BufferedChannel.kt */
/* JADX INFO: loaded from: classes3.dex */
final class ReceiveCatching implements Waiter {
    public final CancellableContinuationImpl cont;

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.Waiter
    public void invokeOnCancellation(Segment segment, int i) {
        this.cont.invokeOnCancellation(segment, i);
    }

    public ReceiveCatching(CancellableContinuationImpl cancellableContinuationImpl) {
        this.cont = cancellableContinuationImpl;
    }
}
