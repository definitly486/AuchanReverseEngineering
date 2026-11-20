package io.appmetrica.analytics.impl;

import java.util.List;

/* JADX INFO: loaded from: classes3.dex */
public final class H4 extends I4 {
    public H4(Ei ei) {
        super(ei);
    }

    public final void a(EnumC0721xb enumC0721xb, List<AbstractC0131ah> list) {
        if (!Q9.h.contains(enumC0721xb)) {
            list.add(this.a.s);
        }
        if (Q9.b.contains(enumC0721xb)) {
            return;
        }
        list.add(this.a.c);
    }
}
