package io.appmetrica.analytics.impl;

import androidx.fragment.app.FragmentTransaction;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.lk, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0418lk implements InterfaceC0726xg {
    public final /* synthetic */ C0444mk a;

    public C0418lk(C0444mk c0444mk) {
        this.a = c0444mk;
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0726xg
    public final void a(Eg eg) {
        C0674vg c0674vgA = eg.a();
        if (c0674vgA == null || this.a.b()) {
            return;
        }
        try {
            C0249f6 c0249f6 = new C0249f6("", "", 0);
            c0249f6.setValueBytes(c0674vgA.a());
            EnumC0721xb enumC0721xb = EnumC0721xb.EVENT_TYPE_UNDEFINED;
            c0249f6.d = FragmentTransaction.TRANSIT_FRAGMENT_OPEN;
            this.a.a.a(c0249f6);
            C0444mk.b(this.a);
        } catch (Throwable unused) {
        }
    }
}
