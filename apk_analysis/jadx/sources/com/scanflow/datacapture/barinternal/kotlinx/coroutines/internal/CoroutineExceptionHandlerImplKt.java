package com.scanflow.datacapture.barinternal.kotlinx.coroutines.internal;

import com.scanflow.datacapture.barinternal.kotlin.sequences.SequencesKt;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.CoroutineExceptionHandler;
import java.util.Collection;
import java.util.ServiceLoader;

/* JADX INFO: compiled from: CoroutineExceptionHandlerImpl.kt */
/* JADX INFO: loaded from: classes3.dex */
public abstract class CoroutineExceptionHandlerImplKt {
    private static final Collection platformExceptionHandlers = SequencesKt.toList(SequencesKt.asSequence(ServiceLoader.load(CoroutineExceptionHandler.class, CoroutineExceptionHandler.class.getClassLoader()).iterator()));

    public static final Collection getPlatformExceptionHandlers() {
        return platformExceptionHandlers;
    }

    public static final void propagateExceptionFinalResort(Throwable th) {
        Thread threadCurrentThread = Thread.currentThread();
        threadCurrentThread.getUncaughtExceptionHandler().uncaughtException(threadCurrentThread, th);
    }
}
