package kotlinx.serialization.builtins;

import com.scanflow.datacapture.barinternal.kotlin.Unit;
import com.scanflow.datacapture.barinternal.kotlin.collections.CollectionsKt;
import com.scanflow.datacapture.barinternal.kotlin.time.Instant;
import com.scanflow.datacapture.barinternal.kotlinx.serialization.internal.LongSerializer;
import java.lang.annotation.Annotation;
import java.util.List;
import kotlin.jvm.functions.Function1;
import kotlin.jvm.internal.Intrinsics;
import kotlinx.serialization.KSerializer;
import kotlinx.serialization.MissingFieldException;
import kotlinx.serialization.SerializationException;
import kotlinx.serialization.builtins.InstantComponentSerializer;
import kotlinx.serialization.descriptors.ClassSerialDescriptorBuilder;
import kotlinx.serialization.descriptors.SerialDescriptor;
import kotlinx.serialization.descriptors.SerialDescriptorsKt;
import kotlinx.serialization.encoding.CompositeDecoder;
import kotlinx.serialization.encoding.CompositeEncoder;
import kotlinx.serialization.encoding.Decoder;
import kotlinx.serialization.encoding.Encoder;

/* JADX INFO: compiled from: InstantComponentSerializer.kt */
/* JADX INFO: loaded from: classes3.dex */
public final class InstantComponentSerializer implements KSerializer<Instant> {
    public static final InstantComponentSerializer INSTANCE = new InstantComponentSerializer();
    private static final SerialDescriptor descriptor = SerialDescriptorsKt.buildClassSerialDescriptor("kotlinx.serialization.InstantComponentSerializer", new SerialDescriptor[0], new Function1() { // from class: com.scanflow.datacapture.barinternal.kotlinx.serialization.builtins.InstantComponentSerializer$$ExternalSyntheticLambda0
        @Override // kotlin.jvm.functions.Function1
        public final Object invoke(Object obj) {
            return InstantComponentSerializer.descriptor$lambda$0((ClassSerialDescriptorBuilder) obj);
        }
    });

    private InstantComponentSerializer() {
    }

    @Override // kotlinx.serialization.KSerializer, kotlinx.serialization.SerializationStrategy, kotlinx.serialization.DeserializationStrategy
    public SerialDescriptor getDescriptor() {
        return descriptor;
    }

    @Override // kotlinx.serialization.DeserializationStrategy
    public Instant deserialize(Decoder decoder) {
        Intrinsics.checkNotNullParameter(decoder, "decoder");
        SerialDescriptor descriptor2 = getDescriptor();
        CompositeDecoder compositeDecoderBeginStructure = decoder.beginStructure(descriptor2);
        long jDecodeLongElement = 0;
        boolean z = true;
        int iDecodeIntElement = 0;
        while (true) {
            InstantComponentSerializer instantComponentSerializer = INSTANCE;
            int iDecodeElementIndex = compositeDecoderBeginStructure.decodeElementIndex(instantComponentSerializer.getDescriptor());
            if (iDecodeElementIndex == -1) {
                if (z) {
                    throw new MissingFieldException("epochSeconds", instantComponentSerializer.getDescriptor().getSerialName());
                }
                Instant instantFromEpochSeconds = Instant.Companion.fromEpochSeconds(jDecodeLongElement, iDecodeIntElement);
                compositeDecoderBeginStructure.endStructure(descriptor2);
                return instantFromEpochSeconds;
            }
            if (iDecodeElementIndex == 0) {
                jDecodeLongElement = compositeDecoderBeginStructure.decodeLongElement(instantComponentSerializer.getDescriptor(), 0);
                z = false;
            } else if (iDecodeElementIndex == 1) {
                iDecodeIntElement = compositeDecoderBeginStructure.decodeIntElement(instantComponentSerializer.getDescriptor(), 1);
            } else {
                throw new SerializationException("Unexpected index: " + iDecodeElementIndex);
            }
        }
    }

    @Override // kotlinx.serialization.SerializationStrategy
    public void serialize(Encoder encoder, Instant value) {
        Intrinsics.checkNotNullParameter(encoder, "encoder");
        Intrinsics.checkNotNullParameter(value, "value");
        SerialDescriptor descriptor2 = getDescriptor();
        CompositeEncoder compositeEncoderBeginStructure = encoder.beginStructure(descriptor2);
        InstantComponentSerializer instantComponentSerializer = INSTANCE;
        compositeEncoderBeginStructure.encodeLongElement(instantComponentSerializer.getDescriptor(), 0, value.getEpochSeconds());
        if (value.getNanosecondsOfSecond() != 0 || compositeEncoderBeginStructure.shouldEncodeElementDefault(instantComponentSerializer.getDescriptor(), 1)) {
            compositeEncoderBeginStructure.encodeIntElement(instantComponentSerializer.getDescriptor(), 1, value.getNanosecondsOfSecond());
        }
        compositeEncoderBeginStructure.endStructure(descriptor2);
    }

    /* JADX INFO: Access modifiers changed from: private */
    public static final Unit descriptor$lambda$0(ClassSerialDescriptorBuilder buildClassSerialDescriptor) {
        Intrinsics.checkNotNullParameter(buildClassSerialDescriptor, "$this$buildClassSerialDescriptor");
        List<? extends Annotation> listEmptyList = CollectionsKt.emptyList();
        LongSerializer longSerializer = LongSerializer.INSTANCE;
        buildClassSerialDescriptor.element("epochSeconds", longSerializer.getDescriptor(), listEmptyList, false);
        buildClassSerialDescriptor.element("nanosecondsOfSecond", longSerializer.getDescriptor(), CollectionsKt.emptyList(), true);
        return Unit.INSTANCE;
    }
}
