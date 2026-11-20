package io.appmetrica.analytics.impl;

import android.content.Context;

/* JADX INFO: loaded from: classes3.dex */
public final class Aj implements InterfaceC0714x4 {
    @Override // io.appmetrica.analytics.impl.InterfaceC0714x4
    /* JADX INFO: renamed from: b, reason: merged with bridge method [inline-methods] */
    public final C0703wj a(Context context, C0611t5 c0611t5, C0273g4 c0273g4, G4 g4) {
        Kg kg;
        C0274g5 c0274g5 = new C0274g5(c0273g4.b, c0273g4.a);
        synchronized (c0611t5) {
            kg = (Kg) c0611t5.a.get(c0274g5.toString());
        }
        return new C0703wj(kg);
    }
}
