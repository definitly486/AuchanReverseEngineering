package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreapi.internal.data.Converter;
import io.appmetrica.analytics.coreutils.internal.StringUtils;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.a0, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0114a0 implements Converter {
    public final N7 a;
    public final Sa b;

    public C0114a0() {
        this(new N7(), new Sa(20));
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final Qi fromModel(C0140b0 c0140b0) {
        C0666v8 c0666v8 = new C0666v8();
        c0666v8.b = this.a.fromModel(c0140b0.a);
        C0241eo c0241eoA = this.b.a(c0140b0.b);
        c0666v8.a = StringUtils.getUTF8Bytes((String) c0241eoA.a);
        return new Qi(c0666v8, new C0532q3(C0532q3.b(c0241eoA)));
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    public final Object toModel(Object obj) {
        throw new UnsupportedOperationException();
    }

    public C0114a0(N7 n7, Sa sa) {
        this.a = n7;
        this.b = sa;
    }

    public final C0140b0 a(Qi qi) {
        throw new UnsupportedOperationException();
    }
}
