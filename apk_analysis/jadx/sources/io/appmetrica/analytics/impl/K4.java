package io.appmetrica.analytics.impl;

import java.util.HashMap;

/* JADX INFO: loaded from: classes3.dex */
public abstract class K4 extends Ud {
    public final Object f;

    public K4(int i, String str, Object obj, Ko ko, W2 w2) {
        super(i, str, ko, w2);
        this.f = obj;
    }

    @Override // io.appmetrica.analytics.impl.Ud, io.appmetrica.analytics.impl.InterfaceC0708wo
    public final void a(C0682vo c0682vo) {
        if (f()) {
            W2 w2 = this.d;
            int i = this.b;
            C0734xo c0734xoA = w2.a(c0682vo, (C0734xo) ((HashMap) c0682vo.a.get(i)).get(this.a), this);
            if (c0734xoA != null) {
                a(c0734xoA);
            }
        }
    }

    public abstract void a(C0734xo c0734xo);

    public final Object g() {
        return this.f;
    }
}
