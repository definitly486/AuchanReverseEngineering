package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreutils.internal.buffering.AccumulatingTaskBuffer;
import io.appmetrica.analytics.coreutils.internal.buffering.DeferredBatchExecutor;
import kotlin.jvm.functions.Function1;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.o3, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0479o3 {
    public final Function1 a;
    public final DeferredBatchExecutor b = new DeferredBatchExecutor(Ka.k().w().e(), new AccumulatingTaskBuffer(), new C0453n3(this), 1000, "[BufferedTempCacheWriter]");

    public C0479o3(In in) {
        this.a = in;
    }
}
