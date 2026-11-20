package io.appmetrica.analytics.impl;

import java.util.List;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.h, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0294h extends Oa {
    public final C0274g5 b;

    public C0294h(Ei ei, C0274g5 c0274g5) {
        super(ei);
        this.b = c0274g5;
    }

    @Override // io.appmetrica.analytics.impl.Oa
    public final void a(List<AbstractC0131ah> list) {
        list.add(this.a.p);
        list.add(this.a.o);
        list.add(this.a.r);
        list.add(this.a.g);
        if (this.b.d()) {
            list.add(this.a.q);
        }
    }
}
