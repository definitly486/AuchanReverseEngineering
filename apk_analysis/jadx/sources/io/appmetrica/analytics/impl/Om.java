package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreutils.internal.data.BaseProtobufStateSerializer;
import io.appmetrica.analytics.protobuf.nano.MessageNano;

/* JADX INFO: loaded from: classes3.dex */
public final class Om extends BaseProtobufStateSerializer {
    @Override // io.appmetrica.analytics.coreutils.internal.data.BaseProtobufStateSerializer, io.appmetrica.analytics.coreapi.internal.data.StateSerializer
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final Nm defaultValue() {
        Nm nm = new Nm();
        nm.i = new Im();
        return nm;
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.StateSerializer
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final Nm toState(byte[] bArr) {
        return (Nm) MessageNano.mergeFrom(new Nm(), bArr);
    }
}
