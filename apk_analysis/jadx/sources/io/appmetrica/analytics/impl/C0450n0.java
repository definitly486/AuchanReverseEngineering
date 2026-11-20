package io.appmetrica.analytics.impl;

import java.util.List;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.n0, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0450n0 {
    public final List a;
    public final boolean b;

    public C0450n0(List list, boolean z) {
        this.a = list;
        this.b = z;
    }

    public final String toString() {
        return "AppMetricaConfigExtension(autoCollectedDataSubscribers=" + this.a + ", needClearEnvironment=" + this.b + ')';
    }
}
