package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreapi.internal.data.ProtobufConverter;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.v3, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0661v3 implements ProtobufConverter {
    public final Fm a(C0609t3 c0609t3) {
        Fm fm = new Fm();
        fm.a = c0609t3.a;
        return fm;
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    public final Object fromModel(Object obj) {
        Fm fm = new Fm();
        fm.a = ((C0609t3) obj).a;
        return fm;
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    public final Object toModel(Object obj) {
        return new C0609t3(((Fm) obj).a);
    }

    public final C0609t3 a(Fm fm) {
        return new C0609t3(fm.a);
    }
}
