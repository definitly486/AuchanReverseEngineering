package com.scanflow.datacapture.barinternal.kotlinx.coroutines;

import com.scanflow.datacapture.barinternal.kotlin.Result;
import com.scanflow.datacapture.barinternal.kotlin.Unit;
import kotlin.coroutines.Continuation;

/* JADX INFO: compiled from: JobSupport.kt */
/* JADX INFO: loaded from: classes3.dex */
final class ResumeOnCompletion extends JobNode {
    private final Continuation continuation;

    public ResumeOnCompletion(Continuation continuation) {
        this.continuation = continuation;
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.JobNode
    public boolean getOnCancelling() {
        return false;
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.JobNode
    public void invoke(Throwable th) {
        Continuation continuation = this.continuation;
        Result.Companion companion = Result.Companion;
        continuation.resumeWith(Result.m681constructorimpl(Unit.INSTANCE));
    }
}
