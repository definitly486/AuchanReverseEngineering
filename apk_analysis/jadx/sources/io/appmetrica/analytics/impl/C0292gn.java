package io.appmetrica.analytics.impl;

import java.util.HashMap;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.gn, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0292gn {
    public final HashMap a;

    public C0292gn() {
        HashMap map = new HashMap();
        this.a = map;
        C0137an c0137an = new C0137an();
        C0163bn c0163bn = new C0163bn();
        C0189cn c0189cn = new C0189cn();
        C0215dn c0215dn = new C0215dn();
        map.put(Am.class, c0137an);
        map.put(C0271g2.class, c0163bn);
        map.put(C0725xf.class, c0189cn);
        map.put(J3.class, c0215dn);
    }

    public static InterfaceC0318hn a(Class cls) {
        return (InterfaceC0318hn) AbstractC0266fn.a.a.get(cls);
    }
}
