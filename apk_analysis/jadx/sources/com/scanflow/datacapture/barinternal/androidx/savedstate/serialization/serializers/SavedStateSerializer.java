package com.scanflow.datacapture.barinternal.androidx.savedstate.serialization.serializers;

import android.os.Bundle;
import com.scanflow.datacapture.barinternal.androidx.savedstate.SavedStateReader;
import com.scanflow.datacapture.barinternal.androidx.savedstate.SavedStateWriter;
import com.scanflow.datacapture.barinternal.androidx.savedstate.serialization.SavedStateDecoder;
import com.scanflow.datacapture.barinternal.androidx.savedstate.serialization.SavedStateEncoder;
import kotlin.jvm.internal.Intrinsics;
import kotlinx.serialization.KSerializer;
import kotlinx.serialization.descriptors.SerialDescriptor;
import kotlinx.serialization.descriptors.SerialDescriptorsKt;
import kotlinx.serialization.encoding.Decoder;
import kotlinx.serialization.encoding.Encoder;

/* JADX INFO: compiled from: BuiltInSerializer.kt */
/* JADX INFO: loaded from: classes.dex */
public final class SavedStateSerializer implements KSerializer {
    public static final SavedStateSerializer INSTANCE = new SavedStateSerializer();
    private static final SerialDescriptor descriptor = SerialDescriptorsKt.buildClassSerialDescriptor$default("androidx.savedstate.SavedState", new SerialDescriptor[0], null, 4, null);

    private SavedStateSerializer() {
    }

    @Override // kotlinx.serialization.KSerializer, kotlinx.serialization.SerializationStrategy, kotlinx.serialization.DeserializationStrategy
    public SerialDescriptor getDescriptor() {
        return descriptor;
    }

    @Override // kotlinx.serialization.SerializationStrategy
    public void serialize(Encoder encoder, Bundle value) {
        Intrinsics.checkNotNullParameter(encoder, "encoder");
        Intrinsics.checkNotNullParameter(value, "value");
        if (!(encoder instanceof SavedStateEncoder)) {
            throw new IllegalArgumentException(BuiltInSerializerKt.encoderErrorMessage(INSTANCE.getDescriptor().getSerialName(), encoder).toString());
        }
        SavedStateEncoder savedStateEncoder = (SavedStateEncoder) encoder;
        if (Intrinsics.areEqual(savedStateEncoder.getKey$savedstate_release(), "")) {
            SavedStateWriter.m592putAllimpl(SavedStateWriter.m591constructorimpl(savedStateEncoder.getSavedState$savedstate_release()), value);
        } else {
            SavedStateWriter.m615putSavedStateimpl(SavedStateWriter.m591constructorimpl(savedStateEncoder.getSavedState$savedstate_release()), savedStateEncoder.getKey$savedstate_release(), value);
        }
    }

    @Override // kotlinx.serialization.DeserializationStrategy
    public Bundle deserialize(Decoder decoder) {
        Intrinsics.checkNotNullParameter(decoder, "decoder");
        if (!(decoder instanceof SavedStateDecoder)) {
            throw new IllegalArgumentException(BuiltInSerializerKt.decoderErrorMessage(INSTANCE.getDescriptor().getSerialName(), decoder).toString());
        }
        SavedStateDecoder savedStateDecoder = (SavedStateDecoder) decoder;
        if (Intrinsics.areEqual(savedStateDecoder.getKey$savedstate_release(), "")) {
            return savedStateDecoder.getSavedState$savedstate_release();
        }
        return SavedStateReader.m577getSavedStateimpl(SavedStateReader.m553constructorimpl(savedStateDecoder.getSavedState$savedstate_release()), savedStateDecoder.getKey$savedstate_release());
    }
}
