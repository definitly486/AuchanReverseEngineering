package com.scanflow.datacapture.barinternal.androidx.savedstate.serialization.serializers;

import com.scanflow.datacapture.barinternal.kotlin.Lazy;
import com.scanflow.datacapture.barinternal.kotlinx.serialization.UnknownFieldException;
import com.scanflow.datacapture.barinternal.kotlinx.serialization.internal.ArrayListSerializer;
import com.scanflow.datacapture.barinternal.kotlinx.serialization.internal.GeneratedSerializer;
import com.scanflow.datacapture.barinternal.kotlinx.serialization.internal.PluginGeneratedSerialDescriptor;
import java.util.List;
import kotlin.jvm.internal.Intrinsics;
import kotlinx.serialization.DeserializationStrategy;
import kotlinx.serialization.KSerializer;
import kotlinx.serialization.descriptors.SerialDescriptor;
import kotlinx.serialization.encoding.CompositeDecoder;
import kotlinx.serialization.encoding.CompositeEncoder;
import kotlinx.serialization.encoding.Decoder;
import kotlinx.serialization.encoding.Encoder;

/* JADX INFO: compiled from: BuiltInSerializer.android.kt */
/* JADX INFO: loaded from: classes.dex */
public /* synthetic */ class SparseArraySerializer$SparseArraySurrogate$$serializer implements GeneratedSerializer {
    private final SerialDescriptor descriptor;
    private final /* synthetic */ KSerializer typeSerial0;

    @Override // kotlinx.serialization.KSerializer, kotlinx.serialization.SerializationStrategy, kotlinx.serialization.DeserializationStrategy
    public final SerialDescriptor getDescriptor() {
        return this.descriptor;
    }

    private SparseArraySerializer$SparseArraySurrogate$$serializer() {
        PluginGeneratedSerialDescriptor pluginGeneratedSerialDescriptor = new PluginGeneratedSerialDescriptor("androidx.savedstate.serialization.serializers.SparseArraySerializer.SparseArraySurrogate", this, 2);
        pluginGeneratedSerialDescriptor.addElement("keys", false);
        pluginGeneratedSerialDescriptor.addElement("values", false);
        this.descriptor = pluginGeneratedSerialDescriptor;
    }

    /* JADX WARN: 'this' call moved to the top of the method (can break code semantics) */
    public SparseArraySerializer$SparseArraySurrogate$$serializer(KSerializer typeSerial0) {
        this();
        Intrinsics.checkNotNullParameter(typeSerial0, "typeSerial0");
        this.typeSerial0 = typeSerial0;
    }

    /* JADX WARN: Multi-variable type inference failed */
    @Override // com.scanflow.datacapture.barinternal.kotlinx.serialization.internal.GeneratedSerializer
    public final KSerializer[] childSerializers() {
        return new KSerializer[]{SparseArraySerializer.SparseArraySurrogate.$childSerializers[0].getValue(), new ArrayListSerializer(this.typeSerial0)};
    }

    @Override // kotlinx.serialization.DeserializationStrategy
    public final SparseArraySerializer.SparseArraySurrogate deserialize(Decoder decoder) {
        List list;
        List list2;
        int i;
        Intrinsics.checkNotNullParameter(decoder, "decoder");
        SerialDescriptor serialDescriptor = this.descriptor;
        CompositeDecoder compositeDecoderBeginStructure = decoder.beginStructure(serialDescriptor);
        Lazy[] lazyArr = SparseArraySerializer.SparseArraySurrogate.$childSerializers;
        if (compositeDecoderBeginStructure.decodeSequentially()) {
            list = (List) compositeDecoderBeginStructure.decodeSerializableElement(serialDescriptor, 0, (DeserializationStrategy) lazyArr[0].getValue(), null);
            list2 = (List) compositeDecoderBeginStructure.decodeSerializableElement(serialDescriptor, 1, new ArrayListSerializer(this.typeSerial0), null);
            i = 3;
        } else {
            boolean z = true;
            int i2 = 0;
            List list3 = null;
            List list4 = null;
            while (z) {
                int iDecodeElementIndex = compositeDecoderBeginStructure.decodeElementIndex(serialDescriptor);
                if (iDecodeElementIndex == -1) {
                    z = false;
                } else if (iDecodeElementIndex == 0) {
                    list3 = (List) compositeDecoderBeginStructure.decodeSerializableElement(serialDescriptor, 0, (DeserializationStrategy) lazyArr[0].getValue(), list3);
                    i2 |= 1;
                } else {
                    if (iDecodeElementIndex != 1) {
                        throw new UnknownFieldException(iDecodeElementIndex);
                    }
                    list4 = (List) compositeDecoderBeginStructure.decodeSerializableElement(serialDescriptor, 1, new ArrayListSerializer(this.typeSerial0), list4);
                    i2 |= 2;
                }
            }
            list = list3;
            list2 = list4;
            i = i2;
        }
        compositeDecoderBeginStructure.endStructure(serialDescriptor);
        return new SparseArraySerializer.SparseArraySurrogate(i, list, list2, null);
    }

    @Override // kotlinx.serialization.SerializationStrategy
    public final void serialize(Encoder encoder, SparseArraySerializer.SparseArraySurrogate value) {
        Intrinsics.checkNotNullParameter(encoder, "encoder");
        Intrinsics.checkNotNullParameter(value, "value");
        SerialDescriptor serialDescriptor = this.descriptor;
        CompositeEncoder compositeEncoderBeginStructure = encoder.beginStructure(serialDescriptor);
        SparseArraySerializer.SparseArraySurrogate.write$Self$savedstate_release(value, compositeEncoderBeginStructure, serialDescriptor, this.typeSerial0);
        compositeEncoderBeginStructure.endStructure(serialDescriptor);
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.serialization.internal.GeneratedSerializer
    public final KSerializer[] typeParametersSerializers() {
        return new KSerializer[]{this.typeSerial0};
    }
}
