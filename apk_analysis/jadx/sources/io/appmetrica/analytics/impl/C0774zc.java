package io.appmetrica.analytics.impl;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.zc, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0774zc implements L9 {
    public final A5 a;

    public C0774zc(P9 p9, C0173c7 c0173c7, Zg zg, F4 f4, C0274g5 c0274g5, C0544qf c0544qf) {
        C0748yc c0748yc = new C0748yc(c0173c7, zg, this, f4, c0544qf);
        this.a = new A5(p9, c0748yc.a(), c0748yc.b(), c0274g5);
    }

    @Override // io.appmetrica.analytics.impl.L9
    public final K9 a() {
        return this.a;
    }

    public final A5 b() {
        return this.a;
    }
}
