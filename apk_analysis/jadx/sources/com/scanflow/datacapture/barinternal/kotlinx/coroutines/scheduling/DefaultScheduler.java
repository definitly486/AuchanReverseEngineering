package com.scanflow.datacapture.barinternal.kotlinx.coroutines.scheduling;

import com.scanflow.datacapture.barinternal.kotlinx.coroutines.CoroutineDispatcher;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.internal.LimitedDispatcherKt;

/* JADX INFO: compiled from: Dispatcher.kt */
/* JADX INFO: loaded from: classes3.dex */
public final class DefaultScheduler extends SchedulerCoroutineDispatcher {
    public static final DefaultScheduler INSTANCE = new DefaultScheduler();

    private DefaultScheduler() {
        super(TasksKt.CORE_POOL_SIZE, TasksKt.MAX_POOL_SIZE, TasksKt.IDLE_WORKER_KEEP_ALIVE_NS, TasksKt.DEFAULT_SCHEDULER_NAME);
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.CoroutineDispatcher
    public CoroutineDispatcher limitedParallelism(int i, String str) {
        LimitedDispatcherKt.checkParallelism(i);
        if (i >= TasksKt.CORE_POOL_SIZE) {
            return LimitedDispatcherKt.namedOrThis(this, str);
        }
        return super.limitedParallelism(i, str);
    }

    @Override // java.io.Closeable, java.lang.AutoCloseable
    public void close() {
        throw new UnsupportedOperationException("Dispatchers.Default cannot be closed");
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.CoroutineDispatcher
    public String toString() {
        return "Dispatchers.Default";
    }
}
