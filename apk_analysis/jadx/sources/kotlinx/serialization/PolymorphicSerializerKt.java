package kotlinx.serialization;

import com.scanflow.datacapture.barinternal.kotlin.KotlinNothingValueException;
import com.scanflow.datacapture.barinternal.kotlinx.serialization.internal.AbstractPolymorphicSerializer;
import com.scanflow.datacapture.barinternal.kotlinx.serialization.internal.AbstractPolymorphicSerializerKt;
import kotlin.jvm.internal.Intrinsics;
import kotlin.jvm.internal.Reflection;
import kotlinx.serialization.encoding.CompositeDecoder;
import kotlinx.serialization.encoding.Encoder;

/* JADX INFO: compiled from: PolymorphicSerializer.kt */
/* JADX INFO: loaded from: classes3.dex */
public final class PolymorphicSerializerKt {
    public static final DeserializationStrategy findPolymorphicSerializer(AbstractPolymorphicSerializer abstractPolymorphicSerializer, CompositeDecoder decoder, String str) {
        Intrinsics.checkNotNullParameter(abstractPolymorphicSerializer, "<this>");
        Intrinsics.checkNotNullParameter(decoder, "decoder");
        DeserializationStrategy deserializationStrategyFindPolymorphicSerializerOrNull = abstractPolymorphicSerializer.findPolymorphicSerializerOrNull(decoder, str);
        if (deserializationStrategyFindPolymorphicSerializerOrNull != null) {
            return deserializationStrategyFindPolymorphicSerializerOrNull;
        }
        AbstractPolymorphicSerializerKt.throwSubtypeNotRegistered(str, abstractPolymorphicSerializer.getBaseClass());
        throw new KotlinNothingValueException();
    }

    public static final SerializationStrategy findPolymorphicSerializer(AbstractPolymorphicSerializer abstractPolymorphicSerializer, Encoder encoder, Object value) {
        Intrinsics.checkNotNullParameter(abstractPolymorphicSerializer, "<this>");
        Intrinsics.checkNotNullParameter(encoder, "encoder");
        Intrinsics.checkNotNullParameter(value, "value");
        SerializationStrategy serializationStrategyFindPolymorphicSerializerOrNull = abstractPolymorphicSerializer.findPolymorphicSerializerOrNull(encoder, value);
        if (serializationStrategyFindPolymorphicSerializerOrNull != null) {
            return serializationStrategyFindPolymorphicSerializerOrNull;
        }
        AbstractPolymorphicSerializerKt.throwSubtypeNotRegistered(Reflection.getOrCreateKotlinClass(value.getClass()), abstractPolymorphicSerializer.getBaseClass());
        throw new KotlinNothingValueException();
    }
}
