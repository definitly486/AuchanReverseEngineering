package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreapi.internal.data.ProtobufConverter;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.f0, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0243f0 implements ProtobufConverter {
    public final Y a;
    public final C0716x6 b;

    public C0243f0() {
        this(new Y(new Pn()), new C0716x6());
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final C0327i6 fromModel(C0217e0 c0217e0) {
        C0327i6 c0327i6 = new C0327i6();
        c0327i6.a = this.a.fromModel(c0217e0.a);
        String str = c0217e0.b;
        if (str != null) {
            c0327i6.b = str;
        }
        c0327i6.c = this.b.a(c0217e0.c);
        return c0327i6;
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    public final Object toModel(Object obj) {
        throw new UnsupportedOperationException();
    }

    public C0243f0(Y y, C0716x6 c0716x6) {
        this.a = y;
        this.b = c0716x6;
    }

    public final C0217e0 a(C0327i6 c0327i6) {
        throw new UnsupportedOperationException();
    }
}
