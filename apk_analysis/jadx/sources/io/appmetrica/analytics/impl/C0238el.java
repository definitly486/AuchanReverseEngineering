package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreutils.internal.data.BaseProtobufStateSerializer;
import io.appmetrica.analytics.protobuf.nano.MessageNano;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.el, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0238el extends BaseProtobufStateSerializer {
    public final C0187cl a() {
        return new C0187cl();
    }

    @Override // io.appmetrica.analytics.coreutils.internal.data.BaseProtobufStateSerializer, io.appmetrica.analytics.coreapi.internal.data.StateSerializer
    public final MessageNano defaultValue() {
        return new C0187cl();
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.StateSerializer
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final C0187cl toState(byte[] bArr) {
        return (C0187cl) MessageNano.mergeFrom(new C0187cl(), bArr);
    }

    @Override // io.appmetrica.analytics.coreutils.internal.data.BaseProtobufStateSerializer, io.appmetrica.analytics.coreapi.internal.data.StateSerializer
    public final Object defaultValue() {
        return new C0187cl();
    }
}
