package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreapi.internal.data.ProtobufConverter;
import io.appmetrica.analytics.coreutils.internal.WrapUtils;

/* JADX INFO: loaded from: classes3.dex */
public final class Tl implements ProtobufConverter {
    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final C0508p6 fromModel(Ul ul) {
        C0508p6 c0508p6 = new C0508p6();
        c0508p6.a = (String) WrapUtils.getOrDefault(ul.a, c0508p6.a);
        c0508p6.b = (String) WrapUtils.getOrDefault(ul.b, c0508p6.b);
        c0508p6.c = ((Integer) WrapUtils.getOrDefault(ul.c, Integer.valueOf(c0508p6.c))).intValue();
        c0508p6.f = ((Integer) WrapUtils.getOrDefault(ul.d, Integer.valueOf(c0508p6.f))).intValue();
        c0508p6.d = (String) WrapUtils.getOrDefault(ul.e, c0508p6.d);
        c0508p6.e = ((Boolean) WrapUtils.getOrDefault(ul.f, Boolean.valueOf(c0508p6.e))).booleanValue();
        return c0508p6;
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    public final Object toModel(Object obj) {
        throw new UnsupportedOperationException();
    }

    public final Ul a(C0508p6 c0508p6) {
        throw new UnsupportedOperationException();
    }
}
