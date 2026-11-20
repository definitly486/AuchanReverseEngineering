package io.appmetrica.analytics.impl;

import android.content.Context;

/* JADX INFO: loaded from: classes3.dex */
public final class Ph implements InterfaceC0714x4 {
    public final InterfaceC0481o5 a;

    public Ph(InterfaceC0481o5 interfaceC0481o5) {
        this.a = interfaceC0481o5;
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0714x4
    /* JADX INFO: renamed from: b, reason: merged with bridge method [inline-methods] */
    public final Jg a(Context context, C0611t5 c0611t5, C0273g4 c0273g4, G4 g4) {
        Kg kg;
        C0274g5 c0274g5 = new C0274g5(c0273g4.b, c0273g4.a);
        Lg lg = new Lg(this.a);
        synchronized (c0611t5) {
            kg = (Kg) c0611t5.a(c0274g5, g4, lg, c0611t5.a);
        }
        return new Jg(context, kg);
    }
}
