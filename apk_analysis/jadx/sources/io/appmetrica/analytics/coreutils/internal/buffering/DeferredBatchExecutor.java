package io.appmetrica.analytics.coreutils.internal.buffering;

import io.appmetrica.analytics.coreapi.internal.executors.IHandlerExecutor;
import io.appmetrica.analytics.coreutils.internal.buffering.DeferredBatchExecutor;
import java.util.List;
import kotlin.jvm.internal.DefaultConstructorMarker;

/* JADX INFO: loaded from: classes3.dex */
public final class DeferredBatchExecutor<T> {
    public static final Companion Companion = new Companion(null);
    private final IHandlerExecutor a;
    private final TaskBuffer b;
    private final BatchProcessor c;
    private final long d;
    private Runnable e;

    public static final class Companion {
        public /* synthetic */ Companion(DefaultConstructorMarker defaultConstructorMarker) {
            this();
        }

        private Companion() {
        }
    }

    public DeferredBatchExecutor(IHandlerExecutor iHandlerExecutor, TaskBuffer<T> taskBuffer, BatchProcessor<T> batchProcessor, long j, String str) {
        this.a = iHandlerExecutor;
        this.b = taskBuffer;
        this.c = batchProcessor;
        this.d = j;
    }

    /* JADX INFO: Access modifiers changed from: private */
    public static final void a(DeferredBatchExecutor deferredBatchExecutor) {
        deferredBatchExecutor.flush();
    }

    private final void b() {
        Runnable runnable = new Runnable() { // from class: com.scanflow.datacapture.barinternal.io.appmetrica.analytics.coreutils.internal.buffering.DeferredBatchExecutor$$ExternalSyntheticLambda1
            @Override // java.lang.Runnable
            public final void run() {
                DeferredBatchExecutor.b(this.f$0);
            }
        };
        this.e = runnable;
        this.a.executeDelayed(runnable, this.d);
    }

    public static /* synthetic */ void submit$default(DeferredBatchExecutor deferredBatchExecutor, Object obj, boolean z, int i, Object obj2) {
        if ((i & 2) != 0) {
            z = false;
        }
        deferredBatchExecutor.submit(obj, z);
    }

    public final synchronized void flush() {
        try {
            Runnable runnable = this.e;
            if (runnable != null) {
                this.a.remove(runnable);
                this.e = null;
            }
            if (!this.b.isEmpty()) {
                a();
            }
        } catch (Throwable th) {
            throw th;
        }
    }

    public final void flushAsync() {
        this.a.execute(new Runnable() { // from class: com.scanflow.datacapture.barinternal.io.appmetrica.analytics.coreutils.internal.buffering.DeferredBatchExecutor$$ExternalSyntheticLambda0
            @Override // java.lang.Runnable
            public final void run() {
                DeferredBatchExecutor.a(this.f$0);
            }
        });
    }

    public final synchronized void submit(T t, boolean z) {
        try {
            this.b.add(t);
            if (z) {
                Runnable runnable = this.e;
                if (runnable != null) {
                    this.a.remove(runnable);
                    this.e = null;
                }
                a();
            } else if (this.e == null) {
                b();
            }
        } catch (Throwable th) {
            throw th;
        }
    }

    private final void a() {
        if (this.b.isEmpty()) {
            this.e = null;
            return;
        }
        List<T> andClear = this.b.getAndClear();
        this.e = null;
        try {
            this.c.processBatch(andClear);
        } catch (Exception unused) {
        }
    }

    public /* synthetic */ DeferredBatchExecutor(IHandlerExecutor iHandlerExecutor, TaskBuffer taskBuffer, BatchProcessor batchProcessor, long j, String str, int i, DefaultConstructorMarker defaultConstructorMarker) {
        this(iHandlerExecutor, taskBuffer, batchProcessor, (i & 8) != 0 ? 1000L : j, (i & 16) != 0 ? "[DeferredBatchExecutor]" : str);
    }

    /* JADX INFO: Access modifiers changed from: private */
    public static final void b(DeferredBatchExecutor deferredBatchExecutor) {
        synchronized (deferredBatchExecutor) {
            deferredBatchExecutor.a();
        }
    }
}
