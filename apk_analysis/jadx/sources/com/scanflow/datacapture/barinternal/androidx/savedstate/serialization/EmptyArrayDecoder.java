package com.scanflow.datacapture.barinternal.androidx.savedstate.serialization;

import kotlin.jvm.internal.Intrinsics;
import kotlinx.serialization.descriptors.SerialDescriptor;
import kotlinx.serialization.encoding.AbstractDecoder;
import kotlinx.serialization.modules.SerializersModule;
import kotlinx.serialization.modules.SerializersModuleBuildersKt;

/* JADX INFO: compiled from: SavedStateDecoder.android.kt */
/* JADX INFO: loaded from: classes.dex */
final class EmptyArrayDecoder extends AbstractDecoder {
    public static final EmptyArrayDecoder INSTANCE = new EmptyArrayDecoder();
    private static final SerializersModule serializersModule = SerializersModuleBuildersKt.EmptySerializersModule();

    @Override // kotlinx.serialization.encoding.AbstractDecoder, kotlinx.serialization.encoding.CompositeDecoder
    public int decodeElementIndex(SerialDescriptor descriptor) {
        Intrinsics.checkNotNullParameter(descriptor, "descriptor");
        return -1;
    }

    private EmptyArrayDecoder() {
    }

    @Override // kotlinx.serialization.encoding.Decoder, kotlinx.serialization.encoding.CompositeDecoder
    public SerializersModule getSerializersModule() {
        return serializersModule;
    }
}
