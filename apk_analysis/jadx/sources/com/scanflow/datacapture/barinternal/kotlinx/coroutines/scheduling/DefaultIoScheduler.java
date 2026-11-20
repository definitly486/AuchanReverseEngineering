package com.scanflow.datacapture.barinternal.kotlinx.coroutines.scheduling;

import com.scanflow.datacapture.barinternal.kotlin.ranges.RangesKt;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.CoroutineDispatcher;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.ExecutorCoroutineDispatcher;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.internal.SystemPropsKt;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.internal.SystemPropsKt__SystemProps_commonKt;
import java.util.concurrent.Executor;
import kotlin.coroutines.CoroutineContext;
import kotlin.coroutines.EmptyCoroutineContext;

/* JADX INFO: compiled from: Dispatcher.kt */
/* JADX INFO: loaded from: classes3.dex */
public final class DefaultIoScheduler extends ExecutorCoroutineDispatcher implements Executor {
    public static final DefaultIoScheduler INSTANCE = new DefaultIoScheduler();

    /* JADX INFO: renamed from: default, reason: not valid java name */
    private static final CoroutineDispatcher f2default = CoroutineDispatcher.limitedParallelism$default(UnlimitedIoScheduler.INSTANCE, SystemPropsKt__SystemProps_commonKt.systemProp$default("kotlinx.coroutines.io.parallelism", RangesKt.coerceAtLeast(64, SystemPropsKt.getAVAILABLE_PROCESSORS()), 0, 0, 12, (Object) null), null, 2, null);

    private DefaultIoScheduler() {
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.ExecutorCoroutineDispatcher
    public Executor getExecutor() {
        return this;
    }

    @Override // java.util.concurrent.Executor
    public void execute(Runnable runnable) {
        dispatch(EmptyCoroutineContext.INSTANCE, runnable);
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.CoroutineDispatcher
    public CoroutineDispatcher limitedParallelism(int i, String str) {
        return UnlimitedIoScheduler.INSTANCE.limitedParallelism(i, str);
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.CoroutineDispatcher
    public void dispatch(CoroutineContext coroutineContext, Runnable runnable) {
        f2default.dispatch(coroutineContext, runnable);
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.CoroutineDispatcher
    public void dispatchYield(CoroutineContext coroutineContext, Runnable runnable) {
        f2default.dispatchYield(coroutineContext, runnable);
    }

    @Override // java.io.Closeable, java.lang.AutoCloseable
    public void close() {
        throw new IllegalStateException("Cannot be invoked on Dispatchers.IO");
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.CoroutineDispatcher
    public String toString() {
        return "Dispatchers.IO";
    }
}
