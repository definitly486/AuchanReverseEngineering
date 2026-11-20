package com.scanflow.datacapture.barinternal.kotlinx.coroutines.internal;

import com.scanflow.datacapture.barinternal.kotlin.coroutines.intrinsics.IntrinsicsKt;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.AbstractCoroutine;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.CompletionStateKt;
import kotlin.coroutines.Continuation;
import kotlin.coroutines.CoroutineContext;
import kotlin.coroutines.jvm.internal.CoroutineStackFrame;

/* JADX INFO: compiled from: Scopes.kt */
/* JADX INFO: loaded from: classes3.dex */
public class ScopeCoroutine extends AbstractCoroutine implements CoroutineStackFrame {
    public final Continuation uCont;

    public ScopeCoroutine(CoroutineContext coroutineContext, Continuation continuation) {
        super(coroutineContext, true, true);
        this.uCont = continuation;
    }

    @Override // kotlin.coroutines.jvm.internal.CoroutineStackFrame
    public final CoroutineStackFrame getCallerFrame() {
        Continuation continuation = this.uCont;
        if (continuation instanceof CoroutineStackFrame) {
            return (CoroutineStackFrame) continuation;
        }
        return null;
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.JobSupport
    protected final boolean isScopedCoroutine() {
        return true;
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.JobSupport
    protected void afterCompletion(Object obj) {
        DispatchedContinuationKt.resumeCancellableWith(IntrinsicsKt.intercepted(this.uCont), CompletionStateKt.recoverResult(obj, this.uCont));
    }

    public void afterCompletionUndispatched() {
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.AbstractCoroutine
    protected void afterResume(Object obj) {
        Continuation continuation = this.uCont;
        continuation.resumeWith(CompletionStateKt.recoverResult(obj, continuation));
    }
}
