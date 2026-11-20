package io.appmetrica.analytics.impl;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.pn, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0525pn extends K4 {
    public final Cdo g;

    public C0525pn(String str, String str2, Cdo cdo, Ko ko, W2 w2) {
        super(0, str, str2, ko, w2);
        this.g = cdo;
    }

    @Override // io.appmetrica.analytics.impl.K4
    public final void a(C0734xo c0734xo) {
        String str = (String) this.g.a((String) this.f);
        c0734xo.d.a = str == null ? new byte[0] : str.getBytes();
    }

    public final Cdo h() {
        return this.g;
    }
}
