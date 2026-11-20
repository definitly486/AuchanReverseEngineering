package io.appmetrica.analytics.impl;

import android.content.Context;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.f, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public abstract class AbstractC0242f implements InterfaceC0688w4 {
    public final Context a;
    public final Kg b;

    public AbstractC0242f(Context context, Kg kg) {
        this.a = context.getApplicationContext();
        this.b = kg;
        kg.a(this);
        Ka.k().n().b(this);
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0688w4
    public final void a(C0249f6 c0249f6, G4 g4) {
        b(c0249f6, g4);
    }

    public final Kg b() {
        return this.b;
    }

    public abstract void b(C0249f6 c0249f6, G4 g4);

    public final Context c() {
        return this.a;
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0688w4
    public final void a() {
        this.b.b(this);
        Ka.I.m().a(this);
    }
}
