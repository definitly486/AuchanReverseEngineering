package io.appmetrica.analytics.impl;

import android.content.Context;

/* JADX INFO: loaded from: classes3.dex */
public final class Kg implements InterfaceC0317hm, InterfaceC0254fb {
    public final Context a;
    public final C0274g5 b;
    public final C0300h5 c;
    public final Rm d;
    public final InterfaceC0383kb e;

    public Kg(Context context, C0274g5 c0274g5, G4 g4, InterfaceC0481o5 interfaceC0481o5, C0300h5 c0300h5, Yl yl) {
        this.a = context;
        this.b = c0274g5;
        this.c = c0300h5;
        Rm rmA = yl.a(context, c0274g5, g4.a);
        this.d = rmA;
        this.e = interfaceC0481o5.a(context, c0274g5, g4.b, rmA);
        yl.a(c0274g5, this);
    }

    public final C0274g5 a() {
        return this.b;
    }

    public final Context b() {
        return this.a;
    }

    public final void a(InterfaceC0688w4 interfaceC0688w4) {
        this.c.a.add(interfaceC0688w4);
    }

    public final void b(InterfaceC0688w4 interfaceC0688w4) {
        this.c.a.remove(interfaceC0688w4);
        if (this.c.a.isEmpty()) {
            ((InterfaceC0203db) this.e).c();
        }
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0317hm
    public final void a(C0706wm c0706wm) {
        ((C0455n5) this.e).a(c0706wm);
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0317hm
    public final void a(EnumC0136am enumC0136am, C0706wm c0706wm) {
        ((C0455n5) this.e).getClass();
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0254fb
    public final void a(G4 g4) {
        this.d.a(g4.a);
        this.e.a(g4.b);
    }

    public final void a(C0249f6 c0249f6, G4 g4) {
        if (!Q9.c.contains(EnumC0721xb.a(c0249f6.d))) {
            this.e.a(g4.b);
        }
        ((C0455n5) this.e).a(c0249f6);
    }

    public Kg(Context context, C0274g5 c0274g5, G4 g4, InterfaceC0481o5 interfaceC0481o5) {
        this(context, c0274g5, g4, interfaceC0481o5, new C0300h5(), Yl.a());
    }
}
