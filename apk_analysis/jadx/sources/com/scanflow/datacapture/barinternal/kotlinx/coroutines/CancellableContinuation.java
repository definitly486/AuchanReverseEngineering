package com.scanflow.datacapture.barinternal.kotlinx.coroutines;

import com.scanflow.datacapture.barinternal.kotlin.jvm.functions.Function3;
import kotlin.coroutines.Continuation;
import kotlin.jvm.functions.Function1;

/* JADX INFO: compiled from: CancellableContinuation.kt */
/* JADX INFO: loaded from: classes3.dex */
public interface CancellableContinuation extends Continuation {
    boolean cancel(Throwable th);

    void completeResume(Object obj);

    void invokeOnCancellation(Function1 function1);

    void resume(Object obj, Function3 function3);

    void resumeUndispatched(CoroutineDispatcher coroutineDispatcher, Object obj);

    Object tryResume(Object obj, Object obj2, Function3 function3);

    /* JADX INFO: compiled from: CancellableContinuation.kt */
    public static final class DefaultImpls {
        public static /* synthetic */ boolean cancel$default(CancellableContinuation cancellableContinuation, Throwable th, int i, Object obj) {
            if (obj != null) {
                throw new UnsupportedOperationException("Super calls with default arguments not supported in this target, function: cancel");
            }
            if ((i & 1) != 0) {
                th = null;
            }
            return cancellableContinuation.cancel(th);
        }
    }
}
