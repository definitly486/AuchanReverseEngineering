package io.appmetrica.analytics.remotepermissions.impl;

import io.appmetrica.analytics.coreapi.internal.data.Converter;
import io.appmetrica.analytics.protobuf.nano.MessageNano;
import io.appmetrica.analytics.remotepermissions.internal.config.FeatureConfig;

/* JADX INFO: loaded from: classes3.dex */
public final class a implements Converter {
    public final b a = new b();

    public final byte[] a(FeatureConfig featureConfig) {
        return MessageNano.toByteArray(this.a.fromModel(featureConfig));
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    public final Object fromModel(Object obj) {
        return MessageNano.toByteArray(this.a.fromModel((FeatureConfig) obj));
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final FeatureConfig toModel(byte[] bArr) {
        return this.a.toModel((e) MessageNano.mergeFrom(new e(), bArr));
    }
}
