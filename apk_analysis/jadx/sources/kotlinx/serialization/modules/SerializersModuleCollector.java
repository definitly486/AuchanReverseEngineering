package kotlinx.serialization.modules;

import java.util.List;
import kotlin.jvm.functions.Function1;
import kotlin.jvm.internal.Intrinsics;
import kotlin.reflect.KClass;
import kotlinx.serialization.DeserializationStrategy;
import kotlinx.serialization.ExperimentalSerializationApi;
import kotlinx.serialization.KSerializer;
import kotlinx.serialization.modules.SerializersModuleCollector;

/* JADX INFO: compiled from: SerializersModuleCollector.kt */
/* JADX INFO: loaded from: classes3.dex */
@ExperimentalSerializationApi
public interface SerializersModuleCollector {
    /* JADX INFO: Access modifiers changed from: private */
    static KSerializer contextual$lambda$0(KSerializer kSerializer, List it) {
        Intrinsics.checkNotNullParameter(it, "it");
        return kSerializer;
    }

    void contextual(KClass kClass, Function1 function1);

    void polymorphic(KClass kClass, KClass kClass2, KSerializer kSerializer);

    void polymorphicDefaultDeserializer(KClass kClass, Function1 function1);

    void polymorphicDefaultSerializer(KClass kClass, Function1 function1);

    /* JADX INFO: compiled from: SerializersModuleCollector.kt */
    public static final class DefaultImpls {
        @Deprecated
        public static <T> void contextual(SerializersModuleCollector serializersModuleCollector, KClass<T> kClass, KSerializer<T> serializer) {
            Intrinsics.checkNotNullParameter(kClass, "kClass");
            Intrinsics.checkNotNullParameter(serializer, "serializer");
            SerializersModuleCollector.super.contextual(kClass, serializer);
        }

        @Deprecated
        public static <Base> void polymorphicDefault(SerializersModuleCollector serializersModuleCollector, KClass<Base> baseClass, Function1<? super String, ? extends DeserializationStrategy<? extends Base>> defaultDeserializerProvider) {
            Intrinsics.checkNotNullParameter(baseClass, "baseClass");
            Intrinsics.checkNotNullParameter(defaultDeserializerProvider, "defaultDeserializerProvider");
            SerializersModuleCollector.super.polymorphicDefault(baseClass, defaultDeserializerProvider);
        }
    }

    default void contextual(KClass kClass, final KSerializer serializer) {
        Intrinsics.checkNotNullParameter(kClass, "kClass");
        Intrinsics.checkNotNullParameter(serializer, "serializer");
        contextual(kClass, new Function1() { // from class: com.scanflow.datacapture.barinternal.kotlinx.serialization.modules.SerializersModuleCollector$$ExternalSyntheticLambda0
            @Override // kotlin.jvm.functions.Function1
            public final Object invoke(Object obj) {
                return SerializersModuleCollector.contextual$lambda$0(serializer, (List) obj);
            }
        });
    }

    default void polymorphicDefault(KClass baseClass, Function1 defaultDeserializerProvider) {
        Intrinsics.checkNotNullParameter(baseClass, "baseClass");
        Intrinsics.checkNotNullParameter(defaultDeserializerProvider, "defaultDeserializerProvider");
        polymorphicDefaultDeserializer(baseClass, defaultDeserializerProvider);
    }
}
