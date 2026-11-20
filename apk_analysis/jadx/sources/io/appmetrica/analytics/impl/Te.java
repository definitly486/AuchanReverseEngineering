package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreapi.internal.data.ProtobufConverter;

/* JADX INFO: loaded from: classes3.dex */
public final class Te implements ProtobufConverter {
    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final Km fromModel(Se se) {
        Km km = new Km();
        km.a = se.a;
        km.b = se.b;
        return km;
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    public final Object toModel(Object obj) {
        Km km = (Km) obj;
        return new Se(km.a, km.b);
    }

    public final Se a(Km km) {
        return new Se(km.a, km.b);
    }
}
