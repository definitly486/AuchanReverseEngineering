package com.scanflow.datacapture.barinternal.kotlinx.coroutines;

import com.scanflow.datacapture.barinternal.kotlin.Result;
import com.scanflow.datacapture.barinternal.kotlin.ResultKt;

/* JADX INFO: compiled from: JobSupport.kt */
/* JADX INFO: loaded from: classes3.dex */
final class ResumeAwaitOnCompletion extends JobNode {
    private final CancellableContinuationImpl continuation;

    public ResumeAwaitOnCompletion(CancellableContinuationImpl cancellableContinuationImpl) {
        this.continuation = cancellableContinuationImpl;
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.JobNode
    public boolean getOnCancelling() {
        return false;
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.JobNode
    public void invoke(Throwable th) {
        Object state$kotlinx_coroutines_core = getJob().getState$kotlinx_coroutines_core();
        if (state$kotlinx_coroutines_core instanceof CompletedExceptionally) {
            CancellableContinuationImpl cancellableContinuationImpl = this.continuation;
            Result.Companion companion = Result.Companion;
            cancellableContinuationImpl.resumeWith(Result.m681constructorimpl(ResultKt.createFailure(((CompletedExceptionally) state$kotlinx_coroutines_core).cause)));
        } else {
            CancellableContinuationImpl cancellableContinuationImpl2 = this.continuation;
            Result.Companion companion2 = Result.Companion;
            cancellableContinuationImpl2.resumeWith(Result.m681constructorimpl(JobSupportKt.unboxState(state$kotlinx_coroutines_core)));
        }
    }
}
