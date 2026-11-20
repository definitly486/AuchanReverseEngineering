package com.scanflow.datacapture.barinternal.kotlinx.serialization.internal;

import kotlinx.serialization.KSerializer;

/* JADX INFO: compiled from: PluginHelperInterfaces.kt */
/* JADX INFO: loaded from: classes3.dex */
public interface GeneratedSerializer extends KSerializer {
    KSerializer[] childSerializers();

    default KSerializer[] typeParametersSerializers() {
        return PluginHelperInterfacesKt.EMPTY_SERIALIZER_ARRAY;
    }
}
