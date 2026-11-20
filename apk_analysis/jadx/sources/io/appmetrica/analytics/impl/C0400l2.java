package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreutils.internal.data.BaseProtobufStateSerializer;
import io.appmetrica.analytics.protobuf.nano.MessageNano;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.l2, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0400l2 extends BaseProtobufStateSerializer {
    public final C0374k2 a() {
        return new C0374k2();
    }

    @Override // io.appmetrica.analytics.coreutils.internal.data.BaseProtobufStateSerializer, io.appmetrica.analytics.coreapi.internal.data.StateSerializer
    public final MessageNano defaultValue() {
        return new C0374k2();
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.StateSerializer
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final C0374k2 toState(byte[] bArr) {
        return (C0374k2) MessageNano.mergeFrom(new C0374k2(), bArr);
    }

    @Override // io.appmetrica.analytics.coreutils.internal.data.BaseProtobufStateSerializer, io.appmetrica.analytics.coreapi.internal.data.StateSerializer
    public final Object defaultValue() {
        return new C0374k2();
    }
}
