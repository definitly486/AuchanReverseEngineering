package io.appmetrica.analytics.impl;

import android.os.Bundle;

/* JADX INFO: loaded from: classes3.dex */
public final class Da extends Q4 {
    public Da(N4 n4) {
        super(n4);
    }

    @Override // io.appmetrica.analytics.impl.Q4
    public final boolean a(C0249f6 c0249f6, L4 l4) {
        Bundle bundle = c0249f6.m;
        C0617tb c0617tb = bundle != null ? (C0617tb) bundle.getParcelable("io.appmetrica.analytics.impl.IdentifiersData") : null;
        if (c0617tb != null) {
            if (c0617tb.d) {
                F4 f4 = l4.b.d.a;
                Boolean bool = f4.n;
                Boolean bool2 = f4.i;
                Ka.I.c().c(bool != null ? bool.booleanValue() : true);
                Ka.I.h().b(bool2);
            }
        }
        this.a.a(c0617tb);
        return false;
    }
}
