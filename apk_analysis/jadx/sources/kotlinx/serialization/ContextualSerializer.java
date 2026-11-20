package kotlinx.serialization;

import com.scanflow.datacapture.barinternal.kotlin.KotlinNothingValueException;
import com.scanflow.datacapture.barinternal.kotlin.Unit;
import com.scanflow.datacapture.barinternal.kotlin.collections.ArraysKt;
import com.scanflow.datacapture.barinternal.kotlin.collections.CollectionsKt;
import com.scanflow.datacapture.barinternal.kotlinx.serialization.internal.Platform_commonKt;
import com.scanflow.datacapture.barinternal.kotlinx.serialization.internal.PluginHelperInterfacesKt;
import java.util.List;
import kotlin.jvm.functions.Function1;
import kotlin.jvm.internal.Intrinsics;
import kotlin.reflect.KClass;
import kotlinx.serialization.ContextualSerializer;
import kotlinx.serialization.descriptors.ClassSerialDescriptorBuilder;
import kotlinx.serialization.descriptors.ContextAwareKt;
import kotlinx.serialization.descriptors.SerialDescriptor;
import kotlinx.serialization.descriptors.SerialDescriptorsKt;
import kotlinx.serialization.descriptors.SerialKind;
import kotlinx.serialization.encoding.Decoder;
import kotlinx.serialization.encoding.Encoder;
import kotlinx.serialization.modules.SerializersModule;

/* JADX INFO: compiled from: ContextualSerializer.kt */
/* JADX INFO: loaded from: classes3.dex */
@ExperimentalSerializationApi
public final class ContextualSerializer<T> implements KSerializer<T> {
    private final SerialDescriptor descriptor;
    private final KSerializer fallbackSerializer;
    private final KClass serializableClass;
    private final List typeArgumentsSerializers;

    public ContextualSerializer(KClass<T> serializableClass, KSerializer<T> kSerializer, KSerializer<?>[] typeArgumentsSerializers) {
        Intrinsics.checkNotNullParameter(serializableClass, "serializableClass");
        Intrinsics.checkNotNullParameter(typeArgumentsSerializers, "typeArgumentsSerializers");
        this.serializableClass = serializableClass;
        this.fallbackSerializer = kSerializer;
        this.typeArgumentsSerializers = ArraysKt.asList(typeArgumentsSerializers);
        this.descriptor = ContextAwareKt.withContext(SerialDescriptorsKt.buildSerialDescriptor("kotlinx.serialization.ContextualSerializer", SerialKind.CONTEXTUAL.INSTANCE, new SerialDescriptor[0], new Function1() { // from class: com.scanflow.datacapture.barinternal.kotlinx.serialization.ContextualSerializer$$ExternalSyntheticLambda0
            @Override // kotlin.jvm.functions.Function1
            public final Object invoke(Object obj) {
                return ContextualSerializer.descriptor$lambda$0(this.f$0, (ClassSerialDescriptorBuilder) obj);
            }
        }), serializableClass);
    }

    private final KSerializer serializer(SerializersModule serializersModule) {
        KSerializer<T> contextual = serializersModule.getContextual(this.serializableClass, this.typeArgumentsSerializers);
        if (contextual != null) {
            return contextual;
        }
        KSerializer kSerializer = this.fallbackSerializer;
        if (kSerializer != null) {
            return kSerializer;
        }
        Platform_commonKt.serializerNotRegistered(this.serializableClass);
        throw new KotlinNothingValueException();
    }

    /* JADX WARN: 'this' call moved to the top of the method (can break code semantics) */
    public ContextualSerializer(KClass<T> serializableClass) {
        this(serializableClass, null, PluginHelperInterfacesKt.EMPTY_SERIALIZER_ARRAY);
        Intrinsics.checkNotNullParameter(serializableClass, "serializableClass");
    }

    @Override // kotlinx.serialization.KSerializer, kotlinx.serialization.SerializationStrategy, kotlinx.serialization.DeserializationStrategy
    public SerialDescriptor getDescriptor() {
        return this.descriptor;
    }

    /* JADX INFO: Access modifiers changed from: private */
    public static final Unit descriptor$lambda$0(ContextualSerializer contextualSerializer, ClassSerialDescriptorBuilder buildSerialDescriptor) {
        SerialDescriptor descriptor;
        Intrinsics.checkNotNullParameter(buildSerialDescriptor, "$this$buildSerialDescriptor");
        KSerializer kSerializer = contextualSerializer.fallbackSerializer;
        List annotations = (kSerializer == null || (descriptor = kSerializer.getDescriptor()) == null) ? null : descriptor.getAnnotations();
        if (annotations == null) {
            annotations = CollectionsKt.emptyList();
        }
        buildSerialDescriptor.setAnnotations(annotations);
        return Unit.INSTANCE;
    }

    @Override // kotlinx.serialization.SerializationStrategy
    public void serialize(Encoder encoder, T value) {
        Intrinsics.checkNotNullParameter(encoder, "encoder");
        Intrinsics.checkNotNullParameter(value, "value");
        encoder.encodeSerializableValue(serializer(encoder.getSerializersModule()), value);
    }

    @Override // kotlinx.serialization.DeserializationStrategy
    public T deserialize(Decoder decoder) {
        Intrinsics.checkNotNullParameter(decoder, "decoder");
        return (T) decoder.decodeSerializableValue(serializer(decoder.getSerializersModule()));
    }
}
