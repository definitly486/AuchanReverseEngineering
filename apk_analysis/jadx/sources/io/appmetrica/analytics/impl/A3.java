package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreapi.internal.data.Converter;

/* JADX INFO: loaded from: classes3.dex */
public final class A3 implements Converter {
    public final C0156bg a;
    public final N7 b;
    public final Sf c;
    public final C0596sg d;

    public A3() {
        this(new C0156bg(), new N7(), new Sf(), new C0596sg());
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final Qi fromModel(B3 b3) {
        Qi qiA;
        C0718x8 c0718x8 = new C0718x8();
        Qi qiA2 = this.a.fromModel(b3.a);
        c0718x8.a = (G8) qiA2.a;
        c0718x8.c = this.b.fromModel(b3.b);
        Qi qiA3 = this.c.fromModel(b3.c);
        c0718x8.d = (F8) qiA3.a;
        Gg gg = b3.d;
        if (gg != null) {
            qiA = this.d.fromModel(gg);
            c0718x8.b = (I8) qiA.a;
        } else {
            qiA = null;
        }
        return new Qi(c0718x8, new C0532q3(C0532q3.b(qiA2, qiA3, qiA)));
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    public final Object toModel(Object obj) {
        throw new UnsupportedOperationException();
    }

    public A3(C0156bg c0156bg, N7 n7, Sf sf, C0596sg c0596sg) {
        this.a = c0156bg;
        this.b = n7;
        this.c = sf;
        this.d = c0596sg;
    }

    public final B3 a(Qi qi) {
        throw new UnsupportedOperationException();
    }
}
