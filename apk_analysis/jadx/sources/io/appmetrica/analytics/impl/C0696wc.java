package io.appmetrica.analytics.impl;

import android.content.Context;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.wc, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0696wc implements InterfaceC0714x4 {
    @Override // io.appmetrica.analytics.impl.InterfaceC0714x4
    /* JADX INFO: renamed from: b, reason: merged with bridge method [inline-methods] */
    public final L4 a(Context context, C0611t5 c0611t5, C0273g4 c0273g4, G4 g4) {
        N4 n4;
        M4 m4 = new M4(c0273g4.b);
        O4 o4 = new O4();
        synchronized (c0611t5) {
            n4 = (N4) c0611t5.a(m4, g4, o4, c0611t5.b);
        }
        return new L4(context, n4, g4);
    }
}
