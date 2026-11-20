package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreutils.internal.time.SystemTimeProvider;

/* JADX INFO: loaded from: classes3.dex */
public final class G6 implements InterfaceC0360je {
    public final SystemTimeProvider a = new SystemTimeProvider();

    public final long a(I0 i0) {
        long j = i0.e;
        return j > 0 ? j : this.a.currentTimeMillis();
    }
}
