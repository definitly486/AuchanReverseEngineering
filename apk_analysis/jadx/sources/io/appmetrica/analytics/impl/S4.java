package io.appmetrica.analytics.impl;

import java.util.ArrayList;

/* JADX INFO: loaded from: classes3.dex */
public final class S4 extends AbstractC0130ag {
    public final R4 a;

    public S4(N4 n4) {
        this.a = new R4(n4);
    }

    @Override // io.appmetrica.analytics.impl.AbstractC0130ag
    public final AbstractC0538q9 a(int i) {
        ArrayList arrayList = new ArrayList();
        int iOrdinal = EnumC0721xb.a(i).ordinal();
        if (iOrdinal == 12) {
            arrayList.add(this.a.a);
        } else if (iOrdinal == 14) {
            arrayList.add(this.a.b);
        } else if (iOrdinal == 34) {
            arrayList.add(this.a.c);
        }
        return new C0511p9(arrayList);
    }
}
