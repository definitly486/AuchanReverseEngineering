package io.appmetrica.analytics.impl;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.qo, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0553qo extends Q4 {
    public final W6 b;

    public C0553qo(N4 n4, W6 w6) {
        super(n4);
        this.b = w6;
    }

    @Override // io.appmetrica.analytics.impl.Q4
    public final boolean a(C0249f6 c0249f6, L4 l4) {
        F4 f4 = l4.b.d.a;
        this.b.a(f4.i);
        InterfaceC0281gc interfaceC0281gcM = Ka.I.m();
        if (Boolean.TRUE.equals(f4.b)) {
            interfaceC0281gcM.a(true);
        } else {
            if (Boolean.FALSE.equals(f4.b)) {
                interfaceC0281gcM.a(false);
            }
        }
        interfaceC0281gcM.a(f4.c);
        Boolean bool = f4.n;
        Ka.I.c().b(bool != null ? bool.booleanValue() : true);
        return false;
    }
}
