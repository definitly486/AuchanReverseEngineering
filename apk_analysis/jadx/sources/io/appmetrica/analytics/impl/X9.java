package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreapi.internal.data.ProtobufConverter;

/* JADX INFO: loaded from: classes3.dex */
public final class X9 implements ProtobufConverter {
    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final Hm fromModel(W9 w9) {
        Hm hm = new Hm();
        if (w9 != null) {
            hm.a = w9.a;
        }
        return hm;
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    public final Object toModel(Object obj) {
        return new W9(((Hm) obj).a);
    }

    public final W9 a(Hm hm) {
        return new W9(hm.a);
    }
}
