package com.scanflow.datacapture.barinternal.kotlinx.coroutines.sync;

import com.scanflow.datacapture.barinternal.kotlinx.coroutines.internal.Segment;
import java.util.concurrent.atomic.AtomicReferenceArray;
import kotlin.coroutines.CoroutineContext;

/* JADX INFO: compiled from: Semaphore.kt */
/* JADX INFO: loaded from: classes3.dex */
final class SemaphoreSegment extends Segment {
    private final /* synthetic */ AtomicReferenceArray acquirers;

    public final /* synthetic */ AtomicReferenceArray getAcquirers() {
        return this.acquirers;
    }

    public SemaphoreSegment(long j, SemaphoreSegment semaphoreSegment, int i) {
        super(j, semaphoreSegment, i);
        this.acquirers = new AtomicReferenceArray(SemaphoreKt.SEGMENT_SIZE);
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.internal.Segment
    public int getNumberOfSlots() {
        return SemaphoreKt.SEGMENT_SIZE;
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.internal.Segment
    public void onCancellation(int i, Throwable th, CoroutineContext coroutineContext) {
        getAcquirers().set(i, SemaphoreKt.CANCELLED);
        onSlotCleaned();
    }

    public String toString() {
        return "SemaphoreSegment[id=" + this.id + ", hashCode=" + hashCode() + ']';
    }
}
