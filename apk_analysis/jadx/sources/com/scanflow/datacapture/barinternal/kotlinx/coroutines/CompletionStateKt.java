package com.scanflow.datacapture.barinternal.kotlinx.coroutines;

import com.scanflow.datacapture.barinternal.kotlin.Result;
import com.scanflow.datacapture.barinternal.kotlin.ResultKt;
import kotlin.coroutines.Continuation;

/* JADX INFO: compiled from: CompletionState.kt */
/* JADX INFO: loaded from: classes3.dex */
public abstract class CompletionStateKt {
    public static final Object toState(Object obj) {
        Throwable thM683exceptionOrNullimpl = Result.m683exceptionOrNullimpl(obj);
        return thM683exceptionOrNullimpl == null ? obj : new CompletedExceptionally(thM683exceptionOrNullimpl, false, 2, null);
    }

    public static final Object toState(Object obj, CancellableContinuation cancellableContinuation) {
        Throwable thM683exceptionOrNullimpl = Result.m683exceptionOrNullimpl(obj);
        return thM683exceptionOrNullimpl == null ? obj : new CompletedExceptionally(thM683exceptionOrNullimpl, false, 2, null);
    }

    public static final Object recoverResult(Object obj, Continuation continuation) {
        if (obj instanceof CompletedExceptionally) {
            Result.Companion companion = Result.Companion;
            return Result.m681constructorimpl(ResultKt.createFailure(((CompletedExceptionally) obj).cause));
        }
        return Result.m681constructorimpl(obj);
    }
}
