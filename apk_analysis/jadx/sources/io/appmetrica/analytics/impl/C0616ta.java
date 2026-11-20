package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreutils.internal.time.SystemTimeProvider;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.ta, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0616ta implements D6 {
    public final SystemTimeProvider a = new SystemTimeProvider();

    public final long a(Fb fb) {
        long j = fb.k;
        return j > 0 ? j : this.a.currentTimeMillis();
    }
}
