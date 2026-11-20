package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreapi.internal.data.Converter;
import io.appmetrica.analytics.protobuf.nano.MessageNano;

/* JADX INFO: loaded from: classes3.dex */
public final class Hb implements Converter {
    public final C0308hd a;

    public Hb() {
        this(new C0308hd(new C0370jo()));
    }

    /* JADX WARN: Multi-variable type inference failed */
    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final byte[] fromModel(C0344io c0344io) {
        return MessageNano.toByteArray((MessageNano) this.a.a.fromModel(c0344io));
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    public final Object toModel(Object obj) {
        throw new UnsupportedOperationException();
    }

    public Hb(C0308hd c0308hd) {
        this.a = c0308hd;
    }

    public final C0344io a(byte[] bArr) {
        throw new UnsupportedOperationException();
    }
}
