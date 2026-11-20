package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreutils.internal.time.SystemTimeProvider;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.v4, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0662v4 {
    public final SystemTimeProvider a;

    public C0662v4() {
        this(new SystemTimeProvider());
    }

    public final void a() {
        this.a.elapsedRealtime();
    }

    public C0662v4(SystemTimeProvider systemTimeProvider) {
        this.a = systemTimeProvider;
    }
}
