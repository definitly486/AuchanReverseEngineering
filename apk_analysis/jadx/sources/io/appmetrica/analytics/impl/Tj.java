package io.appmetrica.analytics.impl;

/* JADX INFO: loaded from: classes3.dex */
public final class Tj implements InterfaceC0409lb {
    public final /* synthetic */ InterfaceC0340ik a;

    public Tj(InterfaceC0340ik interfaceC0340ik) {
        this.a = interfaceC0340ik;
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0409lb
    public final void a(InterfaceC0435mb interfaceC0435mb) {
        C0315hk c0315hkA = ((C0749yd) this.a).a();
        if (c0315hkA != null) {
            interfaceC0435mb.reportEvent(c0315hkA.a, c0315hkA.b);
        }
    }
}
