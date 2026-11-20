package androidx.work.impl;

import com.google.common.util.concurrent.ListenableFuture;
import com.scanflow.datacapture.barinternal.kotlin.Result;
import com.scanflow.datacapture.barinternal.kotlin.ResultKt;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.CancellableContinuation;
import java.util.concurrent.ExecutionException;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: WorkerWrapper.kt */
/* JADX INFO: loaded from: classes.dex */
final class ToContinuation implements Runnable {
    private final CancellableContinuation continuation;
    private final ListenableFuture futureToObserve;

    public ToContinuation(ListenableFuture futureToObserve, CancellableContinuation continuation) {
        Intrinsics.checkNotNullParameter(futureToObserve, "futureToObserve");
        Intrinsics.checkNotNullParameter(continuation, "continuation");
        this.futureToObserve = futureToObserve;
        this.continuation = continuation;
    }

    @Override // java.lang.Runnable
    public void run() {
        if (this.futureToObserve.isCancelled()) {
            CancellableContinuation.DefaultImpls.cancel$default(this.continuation, null, 1, null);
            return;
        }
        try {
            CancellableContinuation cancellableContinuation = this.continuation;
            Result.Companion companion = Result.Companion;
            cancellableContinuation.resumeWith(Result.m681constructorimpl(WorkerWrapperKt.getUninterruptibly(this.futureToObserve)));
        } catch (ExecutionException e) {
            CancellableContinuation cancellableContinuation2 = this.continuation;
            Result.Companion companion2 = Result.Companion;
            cancellableContinuation2.resumeWith(Result.m681constructorimpl(ResultKt.createFailure(WorkerWrapperKt.nonNullCause(e))));
        }
    }
}
