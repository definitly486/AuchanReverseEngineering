package io.appmetrica.analytics.screenshot.impl;

import io.appmetrica.analytics.coreapi.internal.data.Converter;

/* JADX INFO: loaded from: classes3.dex */
public final class Z implements Converter {
    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final M fromModel(X x) {
        M m = new M();
        m.a = x.a;
        m.b = x.b;
        return m;
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    public final Object toModel(Object obj) {
        M m = (M) obj;
        return new X(m.a, m.b);
    }

    public final X a(M m) {
        return new X(m.a, m.b);
    }
}
