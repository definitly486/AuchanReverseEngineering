package io.appmetrica.analytics.screenshot.impl;

import io.appmetrica.analytics.coreapi.internal.data.Converter;

/* JADX INFO: renamed from: io.appmetrica.analytics.screenshot.impl.g, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0793g implements Converter {
    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final K fromModel(C0791e c0791e) {
        K k = new K();
        k.a = c0791e.a;
        return k;
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    public final Object toModel(Object obj) {
        return new C0791e(((K) obj).a);
    }

    public final C0791e a(K k) {
        return new C0791e(k.a);
    }
}
