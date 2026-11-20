package io.appmetrica.analytics.impl;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.g6, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0275g6 extends K4 {
    public C0275g6(String str, double d) {
        super(2, str, Double.valueOf(d), new Mb(), new J4(new C0178cc(new D4(100))));
    }

    @Override // io.appmetrica.analytics.impl.K4
    public final void a(C0734xo c0734xo) {
        C0786zo c0786zo = c0734xo.d;
        c0786zo.c = ((Double) this.f).doubleValue() + c0786zo.c;
    }
}
