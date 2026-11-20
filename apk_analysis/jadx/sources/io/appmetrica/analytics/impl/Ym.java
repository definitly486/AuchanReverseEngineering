package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreapi.internal.data.ProtobufConverter;

/* JADX INFO: loaded from: classes3.dex */
public final class Ym implements ProtobufConverter {
    public final Mm a(Xm xm) {
        Mm mm = new Mm();
        mm.a = xm.a;
        return mm;
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    public final Object fromModel(Object obj) {
        Mm mm = new Mm();
        mm.a = ((Xm) obj).a;
        return mm;
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    public final Object toModel(Object obj) {
        return new Xm(((Mm) obj).a);
    }

    public final Xm a(Mm mm) {
        return new Xm(mm.a);
    }
}
