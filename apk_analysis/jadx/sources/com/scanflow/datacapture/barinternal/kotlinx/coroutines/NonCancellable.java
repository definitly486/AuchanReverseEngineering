package com.scanflow.datacapture.barinternal.kotlinx.coroutines;

import java.util.concurrent.CancellationException;
import kotlin.coroutines.AbstractCoroutineContextElement;
import kotlin.coroutines.Continuation;
import kotlin.jvm.functions.Function1;

/* JADX INFO: compiled from: NonCancellable.kt */
/* JADX INFO: loaded from: classes3.dex */
public final class NonCancellable extends AbstractCoroutineContextElement implements Job {
    public static final NonCancellable INSTANCE = new NonCancellable();

    private NonCancellable() {
        super(Job.Key);
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.Job
    public boolean isActive() {
        return true;
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.Job
    public boolean isCancelled() {
        return false;
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.Job
    public boolean start() {
        return false;
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.Job
    public Object join(Continuation continuation) {
        throw new UnsupportedOperationException("This job is always active");
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.Job
    public CancellationException getCancellationException() {
        throw new IllegalStateException("This job is always active");
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.Job
    public DisposableHandle invokeOnCompletion(Function1 function1) {
        return NonDisposableHandle.INSTANCE;
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.Job
    public DisposableHandle invokeOnCompletion(boolean z, boolean z2, Function1 function1) {
        return NonDisposableHandle.INSTANCE;
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.Job
    public void cancel(CancellationException cancellationException) {
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.Job
    public ChildHandle attachChild(ChildJob childJob) {
        return NonDisposableHandle.INSTANCE;
    }

    public String toString() {
        return "NonCancellable";
    }
}
