package io.appmetrica.analytics.impl;

import android.content.Context;

/* JADX INFO: loaded from: classes3.dex */
public final class Lg implements InterfaceC0277g8 {
    public final InterfaceC0481o5 a;

    public Lg(InterfaceC0481o5 interfaceC0481o5) {
        this.a = interfaceC0481o5;
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0277g8
    /* JADX INFO: renamed from: b, reason: merged with bridge method [inline-methods] */
    public final Kg a(Context context, C0274g5 c0274g5, G4 g4) {
        return new Kg(context, c0274g5, g4, this.a, new C0300h5(), Yl.a());
    }

    public final InterfaceC0481o5 a() {
        return this.a;
    }
}
