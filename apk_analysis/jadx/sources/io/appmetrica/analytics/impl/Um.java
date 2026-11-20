package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreapi.internal.data.ProtobufConverter;

/* JADX INFO: loaded from: classes3.dex */
public final class Um implements ProtobufConverter {
    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final Lm fromModel(Tm tm) {
        Lm lm = new Lm();
        lm.a = tm.a;
        return lm;
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    public final Object toModel(Object obj) {
        return new Tm(((Lm) obj).a);
    }

    public final Tm a(Lm lm) {
        return new Tm(lm.a);
    }
}
