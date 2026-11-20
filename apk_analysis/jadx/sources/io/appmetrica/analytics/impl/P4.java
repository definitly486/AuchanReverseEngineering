package io.appmetrica.analytics.impl;

/* JADX INFO: loaded from: classes3.dex */
public final class P4 {
    public final C0152bc a;

    public P4() {
        this(Ka.k().l());
    }

    public static U4 a(N4 n4) {
        return new U4(new S4(n4), n4);
    }

    public P4(C0152bc c0152bc) {
        this.a = c0152bc;
    }

    public final Bn a(N4 n4, Rm rm) {
        Bn bn = new Bn(n4, new Rg(rm));
        C0152bc c0152bc = this.a;
        synchronized (c0152bc) {
            c0152bc.c.add(bn);
        }
        return bn;
    }
}
