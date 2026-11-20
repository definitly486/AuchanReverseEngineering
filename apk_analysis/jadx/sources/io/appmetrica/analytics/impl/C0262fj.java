package io.appmetrica.analytics.impl;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.fj, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0262fj implements Bg {
    public final Bg a;

    public C0262fj(Bg bg) {
        this.a = bg;
    }

    @Override // io.appmetrica.analytics.impl.Bg
    public final String a() {
        return this.a.a();
    }

    @Override // io.appmetrica.analytics.impl.Bg
    public final void a(InterfaceC0726xg interfaceC0726xg) {
        try {
            this.a.a(interfaceC0726xg);
        } catch (Throwable th) {
            String str = "Failed to request " + this.a.a() + " referrer";
            C0263fk c0263fk = Dj.a;
            c0263fk.getClass();
            c0263fk.a(new Ej(str, th));
            interfaceC0726xg.a(new Cg(str, th));
        }
    }
}
