package androidx.concurrent.futures;

import com.google.common.util.concurrent.ListenableFuture;
import com.scanflow.datacapture.barinternal.kotlin.Result;
import com.scanflow.datacapture.barinternal.kotlin.ResultKt;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.CancellableContinuation;
import java.util.concurrent.ExecutionException;

/* JADX INFO: compiled from: ListenableFuture.kt */
/* JADX INFO: loaded from: classes.dex */
final class ToContinuation implements Runnable {
    private final CancellableContinuation continuation;
    private final ListenableFuture futureToObserve;

    public ToContinuation(ListenableFuture listenableFuture, CancellableContinuation cancellableContinuation) {
        this.futureToObserve = listenableFuture;
        this.continuation = cancellableContinuation;
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
            cancellableContinuation.resumeWith(Result.m681constructorimpl(AbstractResolvableFuture.getUninterruptibly(this.futureToObserve)));
        } catch (ExecutionException e) {
            CancellableContinuation cancellableContinuation2 = this.continuation;
            Result.Companion companion2 = Result.Companion;
            cancellableContinuation2.resumeWith(Result.m681constructorimpl(ResultKt.createFailure(ListenableFutureKt.nonNullCause(e))));
        }
    }
}
