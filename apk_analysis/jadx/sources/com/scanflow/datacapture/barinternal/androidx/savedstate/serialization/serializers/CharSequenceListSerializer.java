package com.scanflow.datacapture.barinternal.androidx.savedstate.serialization.serializers;

import com.scanflow.datacapture.barinternal.androidx.savedstate.SavedStateReader;
import com.scanflow.datacapture.barinternal.androidx.savedstate.SavedStateWriter;
import com.scanflow.datacapture.barinternal.androidx.savedstate.serialization.SavedStateDecoder;
import com.scanflow.datacapture.barinternal.androidx.savedstate.serialization.SavedStateEncoder;
import java.util.List;
import kotlin.jvm.internal.Intrinsics;
import kotlinx.serialization.KSerializer;
import kotlinx.serialization.descriptors.SerialDescriptor;
import kotlinx.serialization.descriptors.SerialDescriptorsKt;
import kotlinx.serialization.encoding.Decoder;
import kotlinx.serialization.encoding.Encoder;

/* JADX INFO: compiled from: BuiltInSerializer.android.kt */
/* JADX INFO: loaded from: classes.dex */
public final class CharSequenceListSerializer implements KSerializer {
    public static final CharSequenceListSerializer INSTANCE = new CharSequenceListSerializer();
    private static final SerialDescriptor descriptor = SerialDescriptorsKt.buildClassSerialDescriptor$default("kotlin.collections.List<kotlin.CharSequence>", new SerialDescriptor[0], null, 4, null);

    private CharSequenceListSerializer() {
    }

    @Override // kotlinx.serialization.KSerializer, kotlinx.serialization.SerializationStrategy, kotlinx.serialization.DeserializationStrategy
    public SerialDescriptor getDescriptor() {
        return descriptor;
    }

    @Override // kotlinx.serialization.SerializationStrategy
    public void serialize(Encoder encoder, List value) {
        Intrinsics.checkNotNullParameter(encoder, "encoder");
        Intrinsics.checkNotNullParameter(value, "value");
        if (!(encoder instanceof SavedStateEncoder)) {
            throw new IllegalArgumentException(BuiltInSerializerKt.encoderErrorMessage(INSTANCE.getDescriptor().getSerialName(), encoder).toString());
        }
        SavedStateEncoder savedStateEncoder = (SavedStateEncoder) encoder;
        SavedStateWriter.m600putCharSequenceListimpl(SavedStateWriter.m591constructorimpl(savedStateEncoder.getSavedState$savedstate_release()), savedStateEncoder.getKey$savedstate_release(), value);
    }

    @Override // kotlinx.serialization.DeserializationStrategy
    public List deserialize(Decoder decoder) {
        Intrinsics.checkNotNullParameter(decoder, "decoder");
        if (!(decoder instanceof SavedStateDecoder)) {
            throw new IllegalArgumentException(BuiltInSerializerKt.decoderErrorMessage(INSTANCE.getDescriptor().getSerialName(), decoder).toString());
        }
        SavedStateDecoder savedStateDecoder = (SavedStateDecoder) decoder;
        return SavedStateReader.m562getCharSequenceListimpl(SavedStateReader.m553constructorimpl(savedStateDecoder.getSavedState$savedstate_release()), savedStateDecoder.getKey$savedstate_release());
    }
}
