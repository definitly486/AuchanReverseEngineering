package com.scanflow.datacapture.barinternal.kotlinx.coroutines.intrinsics;

import com.scanflow.datacapture.barinternal.kotlin.Result;
import com.scanflow.datacapture.barinternal.kotlin.ResultKt;
import com.scanflow.datacapture.barinternal.kotlin.Unit;
import com.scanflow.datacapture.barinternal.kotlin.coroutines.intrinsics.IntrinsicsKt;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.DispatchException;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.internal.DispatchedContinuationKt;
import kotlin.coroutines.Continuation;
import kotlin.jvm.functions.Function2;

/* JADX INFO: compiled from: Cancellable.kt */
/* JADX INFO: loaded from: classes3.dex */
public abstract class CancellableKt {
    public static final void startCoroutineCancellable(Function2 function2, Object obj, Continuation continuation) {
        try {
            Continuation continuationIntercepted = IntrinsicsKt.intercepted(IntrinsicsKt.createCoroutineUnintercepted(function2, obj, continuation));
            Result.Companion companion = Result.Companion;
            DispatchedContinuationKt.resumeCancellableWith(continuationIntercepted, Result.m681constructorimpl(Unit.INSTANCE));
        } catch (Throwable th) {
            dispatcherFailure(continuation, th);
        }
    }

    public static final void startCoroutineCancellable(Continuation continuation, Continuation continuation2) throws Throwable {
        try {
            Continuation continuationIntercepted = IntrinsicsKt.intercepted(continuation);
            Result.Companion companion = Result.Companion;
            DispatchedContinuationKt.resumeCancellableWith(continuationIntercepted, Result.m681constructorimpl(Unit.INSTANCE));
        } catch (Throwable th) {
            dispatcherFailure(continuation2, th);
        }
    }

    private static final void dispatcherFailure(Continuation continuation, Throwable th) throws Throwable {
        if (th instanceof DispatchException) {
            th = ((DispatchException) th).getCause();
        }
        Result.Companion companion = Result.Companion;
        continuation.resumeWith(Result.m681constructorimpl(ResultKt.createFailure(th)));
        throw th;
    }
}
