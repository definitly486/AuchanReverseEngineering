package com.scanflow.datacapture.barinternal.kotlinx.coroutines.internal;

import com.scanflow.datacapture.barinternal.kotlinx.coroutines.CancellableContinuation;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.CoroutineDispatcher;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.DefaultExecutorKt;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.Delay;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.DisposableHandle;
import kotlin.coroutines.CoroutineContext;

/* JADX INFO: compiled from: NamedDispatcher.kt */
/* JADX INFO: loaded from: classes3.dex */
public final class NamedDispatcher extends CoroutineDispatcher implements Delay {
    private final /* synthetic */ Delay $$delegate_0;
    private final CoroutineDispatcher dispatcher;
    private final String name;

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.Delay
    public DisposableHandle invokeOnTimeout(long j, Runnable runnable, CoroutineContext coroutineContext) {
        return this.$$delegate_0.invokeOnTimeout(j, runnable, coroutineContext);
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.Delay
    public void scheduleResumeAfterDelay(long j, CancellableContinuation cancellableContinuation) {
        this.$$delegate_0.scheduleResumeAfterDelay(j, cancellableContinuation);
    }

    /* JADX WARN: Multi-variable type inference failed */
    public NamedDispatcher(CoroutineDispatcher coroutineDispatcher, String str) {
        Delay delay = coroutineDispatcher instanceof Delay ? (Delay) coroutineDispatcher : null;
        this.$$delegate_0 = delay == null ? DefaultExecutorKt.getDefaultDelay() : delay;
        this.dispatcher = coroutineDispatcher;
        this.name = str;
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.CoroutineDispatcher
    public boolean isDispatchNeeded(CoroutineContext coroutineContext) {
        return this.dispatcher.isDispatchNeeded(coroutineContext);
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.CoroutineDispatcher
    public void dispatch(CoroutineContext coroutineContext, Runnable runnable) {
        this.dispatcher.dispatch(coroutineContext, runnable);
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.CoroutineDispatcher
    public void dispatchYield(CoroutineContext coroutineContext, Runnable runnable) {
        this.dispatcher.dispatchYield(coroutineContext, runnable);
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.CoroutineDispatcher
    public String toString() {
        return this.name;
    }
}
