package io.appmetrica.analytics.impl;

import android.content.Context;
import io.appmetrica.analytics.coreutils.internal.WrapUtils;

/* JADX INFO: loaded from: classes3.dex */
public final class Ic extends AbstractC0242f {
    public Ic(Context context, Kg kg) {
        super(context, kg);
    }

    @Override // io.appmetrica.analytics.impl.AbstractC0242f
    public final void b(C0249f6 c0249f6, G4 g4) {
        boolean zBooleanValue = ((Boolean) WrapUtils.getOrDefault(g4.b.b, Boolean.FALSE)).booleanValue();
        InterfaceC0281gc interfaceC0281gcM = Ka.I.m();
        interfaceC0281gcM.a(zBooleanValue);
        interfaceC0281gcM.a(g4.b.c);
        Boolean bool = g4.b.n;
        if (bool != null) {
            Ka.I.c().b(bool.booleanValue());
        }
        this.b.a(c0249f6, g4);
    }
}
