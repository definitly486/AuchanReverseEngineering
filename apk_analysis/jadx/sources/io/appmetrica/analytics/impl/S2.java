package io.appmetrica.analytics.impl;

import java.util.Iterator;

/* JADX INFO: loaded from: classes3.dex */
public abstract class S2 {
    public final AbstractC0130ag a;
    public final InterfaceC0203db b;

    public S2(AbstractC0130ag abstractC0130ag, InterfaceC0203db interfaceC0203db) {
        this.a = abstractC0130ag;
        this.b = interfaceC0203db;
    }

    public final boolean a(C0249f6 c0249f6, R2 r2) {
        Iterator it = ((C0511p9) this.a.a(c0249f6.d)).a.iterator();
        while (it.hasNext()) {
            if (r2.a(it.next(), c0249f6)) {
                return true;
            }
        }
        return false;
    }

    public final AbstractC0130ag b() {
        return this.a;
    }

    public final InterfaceC0203db a() {
        return this.b;
    }
}
