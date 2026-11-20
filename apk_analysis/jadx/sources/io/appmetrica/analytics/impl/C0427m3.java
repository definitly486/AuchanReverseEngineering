package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreapi.internal.executors.IHandlerExecutor;
import io.appmetrica.analytics.coreutils.internal.buffering.AccumulatingTaskBuffer;
import io.appmetrica.analytics.coreutils.internal.buffering.BatchProcessor;
import io.appmetrica.analytics.coreutils.internal.buffering.DeferredBatchExecutor;
import java.util.List;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.m3, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0427m3 {
    public final X8 a;
    public final DeferredBatchExecutor b;

    public C0427m3(X8 x8, IHandlerExecutor iHandlerExecutor) {
        this.a = x8;
        this.b = new DeferredBatchExecutor(iHandlerExecutor, new AccumulatingTaskBuffer(), new BatchProcessor() { // from class: io.appmetrica.analytics.impl.m3$$ExternalSyntheticLambda0
            @Override // io.appmetrica.analytics.coreutils.internal.buffering.BatchProcessor
            public final void processBatch(List list) {
                C0427m3.a(this.f$0, list);
            }
        }, 1000L, "[BufferedEventsWriter]");
    }

    public static final void a(C0427m3 c0427m3, List list) {
        try {
            c0427m3.a.b(list);
            c0427m3.a.a(list);
        } catch (Exception unused) {
        }
    }
}
