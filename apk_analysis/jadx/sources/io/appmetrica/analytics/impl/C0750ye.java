package io.appmetrica.analytics.impl;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.ye, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0750ye implements Bg {
    public final String a;
    public final String b;

    public C0750ye(String str) {
        this.a = str;
        this.b = str == null ? "<unknown-package-installer>" : str;
    }

    @Override // io.appmetrica.analytics.impl.Bg
    public final String a() {
        return this.b;
    }

    @Override // io.appmetrica.analytics.impl.Bg
    public final void a(InterfaceC0726xg interfaceC0726xg) {
        interfaceC0726xg.a(new Cg("Package installer " + this.a + " is not supported", null, 2, null));
    }
}
