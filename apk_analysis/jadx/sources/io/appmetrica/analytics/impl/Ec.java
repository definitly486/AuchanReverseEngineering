package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.AnrListener;

/* JADX INFO: loaded from: classes3.dex */
public final class Ec {
    public int a = 5;
    public final C0216e b;

    public Ec(InterfaceC0321i0 interfaceC0321i0) {
        this.b = new C0216e(new Zb(interfaceC0321i0));
    }

    public static final void b(AnrListener anrListener) {
        anrListener.onAppNotResponding();
    }

    public final void a(final AnrListener anrListener) {
        C0216e c0216e = this.b;
        c0216e.a.add(new InterfaceC0165c() { // from class: io.appmetrica.analytics.impl.Ec$$ExternalSyntheticLambda0
            @Override // io.appmetrica.analytics.impl.InterfaceC0165c
            public final void onAppNotResponding() {
                Ec.b(anrListener);
            }
        });
    }
}
