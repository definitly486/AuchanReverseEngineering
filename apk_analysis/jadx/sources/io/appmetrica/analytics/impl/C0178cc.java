package io.appmetrica.analytics.impl;

import java.util.HashMap;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.cc, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0178cc implements InterfaceC0686w2 {
    public final D4 a;

    public C0178cc(D4 d4) {
        this.a = d4;
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0686w2
    public final C0734xo a(C0682vo c0682vo, C0734xo c0734xo) {
        int i = c0682vo.b;
        int i2 = this.a.a;
        if (i == i2) {
            if (((C0734xo) ((HashMap) c0682vo.a.get(c0734xo.b)).get(new String(c0734xo.a))) != null) {
                ((HashMap) c0682vo.a.get(c0734xo.b)).put(new String(c0734xo.a), c0734xo);
                return c0734xo;
            }
        } else if (i < i2) {
            ((HashMap) c0682vo.a.get(c0734xo.b)).put(new String(c0734xo.a), c0734xo);
            c0682vo.b++;
        }
        return c0734xo;
    }
}
