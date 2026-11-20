package com.scanflow.datacapture.barinternal.kotlinx.serialization.internal;

import kotlin.jvm.internal.DefaultConstructorMarker;
import kotlin.jvm.internal.Intrinsics;
import kotlinx.serialization.KSerializer;
import kotlinx.serialization.SerializationException;
import kotlinx.serialization.descriptors.SerialDescriptor;
import kotlinx.serialization.encoding.CompositeDecoder;
import kotlinx.serialization.encoding.CompositeEncoder;
import kotlinx.serialization.encoding.Decoder;
import kotlinx.serialization.encoding.Encoder;

/* JADX INFO: compiled from: Tuples.kt */
/* JADX INFO: loaded from: classes3.dex */
public abstract class KeyValueSerializer implements KSerializer {
    private final KSerializer keySerializer;
    private final KSerializer valueSerializer;

    public /* synthetic */ KeyValueSerializer(KSerializer kSerializer, KSerializer kSerializer2, DefaultConstructorMarker defaultConstructorMarker) {
        this(kSerializer, kSerializer2);
    }

    protected abstract Object getKey(Object obj);

    protected abstract Object getValue(Object obj);

    protected abstract Object toResult(Object obj, Object obj2);

    private KeyValueSerializer(KSerializer kSerializer, KSerializer kSerializer2) {
        this.keySerializer = kSerializer;
        this.valueSerializer = kSerializer2;
    }

    protected final KSerializer getKeySerializer() {
        return this.keySerializer;
    }

    protected final KSerializer getValueSerializer() {
        return this.valueSerializer;
    }

    @Override // kotlinx.serialization.SerializationStrategy
    public void serialize(Encoder encoder, Object obj) {
        Intrinsics.checkNotNullParameter(encoder, "encoder");
        CompositeEncoder compositeEncoderBeginStructure = encoder.beginStructure(getDescriptor());
        compositeEncoderBeginStructure.encodeSerializableElement(getDescriptor(), 0, this.keySerializer, getKey(obj));
        compositeEncoderBeginStructure.encodeSerializableElement(getDescriptor(), 1, this.valueSerializer, getValue(obj));
        compositeEncoderBeginStructure.endStructure(getDescriptor());
    }

    @Override // kotlinx.serialization.DeserializationStrategy
    public Object deserialize(Decoder decoder) {
        Object result;
        Intrinsics.checkNotNullParameter(decoder, "decoder");
        SerialDescriptor descriptor = getDescriptor();
        CompositeDecoder compositeDecoderBeginStructure = decoder.beginStructure(descriptor);
        if (!compositeDecoderBeginStructure.decodeSequentially()) {
            Object objDecodeSerializableElement$default = TuplesKt.NULL;
            Object objDecodeSerializableElement$default2 = TuplesKt.NULL;
            while (true) {
                int iDecodeElementIndex = compositeDecoderBeginStructure.decodeElementIndex(getDescriptor());
                if (iDecodeElementIndex == -1) {
                    if (objDecodeSerializableElement$default != TuplesKt.NULL) {
                        if (objDecodeSerializableElement$default2 == TuplesKt.NULL) {
                            throw new SerializationException("Element 'value' is missing");
                        }
                        result = toResult(objDecodeSerializableElement$default, objDecodeSerializableElement$default2);
                        break;
                    }
                    throw new SerializationException("Element 'key' is missing");
                }
                if (iDecodeElementIndex == 0) {
                    objDecodeSerializableElement$default = CompositeDecoder.decodeSerializableElement$default(compositeDecoderBeginStructure, getDescriptor(), 0, getKeySerializer(), null, 8, null);
                } else if (iDecodeElementIndex == 1) {
                    objDecodeSerializableElement$default2 = CompositeDecoder.decodeSerializableElement$default(compositeDecoderBeginStructure, getDescriptor(), 1, getValueSerializer(), null, 8, null);
                } else {
                    throw new SerializationException("Invalid index: " + iDecodeElementIndex);
                }
            }
        } else {
            result = toResult(CompositeDecoder.decodeSerializableElement$default(compositeDecoderBeginStructure, getDescriptor(), 0, getKeySerializer(), null, 8, null), CompositeDecoder.decodeSerializableElement$default(compositeDecoderBeginStructure, getDescriptor(), 1, getValueSerializer(), null, 8, null));
        }
        compositeDecoderBeginStructure.endStructure(descriptor);
        return result;
    }
}
