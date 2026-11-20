package io.appmetrica.analytics.screenshot.impl;

import java.util.List;

/* JADX INFO: loaded from: classes3.dex */
public final class S {
    public final List a;

    public S(InterfaceC0795i interfaceC0795i) {
        this.a = interfaceC0795i.a();
    }

    public final void a(C0798l c0798l) {
        for (P p : this.a) {
            C0799m c0799m = null;
            if (c0798l != null) {
                C0798l c0798l2 = c0798l.a ? c0798l : null;
                if (c0798l2 != null) {
                    c0799m = c0798l2.b;
                }
            }
            p.a(c0799m);
        }
    }
}
