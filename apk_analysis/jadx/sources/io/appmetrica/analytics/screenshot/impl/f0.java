package io.appmetrica.analytics.screenshot.impl;

import java.util.List;

/* JADX INFO: loaded from: classes3.dex */
public final class f0 {
    public final boolean a;
    public final List b;
    public final long c;

    public f0(boolean z, List list, long j) {
        this.a = z;
        this.b = list;
        this.c = j;
    }

    public final long a() {
        return this.c;
    }

    public final boolean b() {
        return this.a;
    }

    public final List c() {
        return this.b;
    }

    public final String toString() {
        return "ServiceSideContentObserverCaptorConfig(enabled=" + this.a + ", mediaStoreColumnNames=" + this.b + ", detectWindowSeconds=" + this.c + ')';
    }

    public f0(C0802p c0802p) {
        this(c0802p.b(), c0802p.c(), c0802p.a());
    }
}
