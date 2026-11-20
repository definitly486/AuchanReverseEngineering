package io.appmetrica.analytics.impl;

import java.util.Map;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.g0, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0269g0 implements Un {
    public final /* synthetic */ C0295h0 a;

    public C0269g0(C0295h0 c0295h0) {
        this.a = c0295h0;
    }

    @Override // io.appmetrica.analytics.impl.Un
    public final Thread a() {
        return this.a.b;
    }

    @Override // io.appmetrica.analytics.impl.Un
    public final StackTraceElement[] b() {
        C0295h0 c0295h0 = this.a;
        return (StackTraceElement[]) c0295h0.a.get(c0295h0.b);
    }

    @Override // io.appmetrica.analytics.impl.Un
    public final Map<Thread, StackTraceElement[]> c() {
        return this.a.a;
    }
}
