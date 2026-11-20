package com.google.crypto.tink.internal;

import com.google.crypto.tink.shaded.protobuf.MessageLite;

/* JADX INFO: loaded from: classes2.dex */
public abstract class PrimitiveFactory<PrimitiveT, KeyProtoT extends MessageLite> {
    private final Class<PrimitiveT> clazz;

    public abstract PrimitiveT getPrimitive(KeyProtoT keyprotot);

    public PrimitiveFactory(Class<PrimitiveT> cls) {
        this.clazz = cls;
    }

    final Class<PrimitiveT> getPrimitiveClass() {
        return this.clazz;
    }
}
