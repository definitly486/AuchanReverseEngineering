package io.appmetrica.analytics.impl;

import android.content.Context;

/* JADX INFO: loaded from: classes3.dex */
public final class Hc implements InterfaceC0714x4 {
    @Override // io.appmetrica.analytics.impl.InterfaceC0714x4
    /* JADX INFO: renamed from: b, reason: merged with bridge method [inline-methods] */
    public final Ic a(Context context, C0611t5 c0611t5, C0273g4 c0273g4, G4 g4) {
        Kg kg;
        Jc jc = new Jc(c0273g4.b, c0273g4.a);
        Lg lg = new Lg(new Lc());
        synchronized (c0611t5) {
            kg = (Kg) c0611t5.a(jc, g4, lg, c0611t5.a);
        }
        return new Ic(context, kg);
    }
}
