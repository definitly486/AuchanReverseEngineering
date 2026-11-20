package io.appmetrica.analytics.impl;

import java.util.LinkedList;

/* JADX INFO: loaded from: classes3.dex */
public final class F9 extends AbstractC0130ag {
    public final C0779zh a;
    public final Bh b;
    public final C0467nh c;

    public F9(C0455n5 c0455n5) {
        this.a = new C0779zh(c0455n5);
        this.b = new Bh(c0455n5);
        this.c = new C0467nh(c0455n5);
    }

    @Override // io.appmetrica.analytics.impl.AbstractC0130ag
    public final AbstractC0538q9 a(int i) {
        LinkedList linkedList = new LinkedList();
        int iOrdinal = EnumC0721xb.a(i).ordinal();
        if (iOrdinal == 1) {
            linkedList.add(this.a);
        } else if (iOrdinal == 3) {
            linkedList.add(this.c);
        } else if (iOrdinal == 27) {
            linkedList.add(this.b);
            linkedList.add(this.a);
        }
        return new C0511p9(linkedList);
    }
}
