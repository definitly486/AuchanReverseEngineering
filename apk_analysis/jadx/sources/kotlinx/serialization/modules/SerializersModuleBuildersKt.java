package kotlinx.serialization.modules;

import com.scanflow.datacapture.barinternal.kotlin.Unit;
import kotlin.jvm.functions.Function1;
import kotlin.jvm.internal.Intrinsics;
import kotlin.jvm.internal.Reflection;
import kotlin.reflect.KClass;
import kotlinx.serialization.KSerializer;

/* JADX INFO: compiled from: SerializersModuleBuilders.kt */
/* JADX INFO: loaded from: classes3.dex */
public final class SerializersModuleBuildersKt {
    public static final /* synthetic */ <T> SerializersModule serializersModuleOf(KSerializer<T> serializer) {
        Intrinsics.checkNotNullParameter(serializer, "serializer");
        Intrinsics.reifiedOperationMarker(4, "T");
        return serializersModuleOf(Reflection.getOrCreateKotlinClass(Object.class), serializer);
    }

    public static final SerializersModule SerializersModule(Function1<? super SerializersModuleBuilder, Unit> builderAction) {
        Intrinsics.checkNotNullParameter(builderAction, "builderAction");
        SerializersModuleBuilder serializersModuleBuilder = new SerializersModuleBuilder();
        builderAction.invoke(serializersModuleBuilder);
        return serializersModuleBuilder.build();
    }

    public static final <T> SerializersModule serializersModuleOf(KClass<T> kClass, KSerializer<T> serializer) {
        Intrinsics.checkNotNullParameter(kClass, "kClass");
        Intrinsics.checkNotNullParameter(serializer, "serializer");
        SerializersModuleBuilder serializersModuleBuilder = new SerializersModuleBuilder();
        serializersModuleBuilder.contextual(kClass, serializer);
        return serializersModuleBuilder.build();
    }

    public static final SerializersModule EmptySerializersModule() {
        return SerializersModuleKt.getEmptySerializersModule();
    }

    public static final <Base> void polymorphic(SerializersModuleBuilder serializersModuleBuilder, KClass<Base> baseClass, KSerializer<Base> kSerializer, Function1<? super PolymorphicModuleBuilder<? super Base>, Unit> builderAction) {
        Intrinsics.checkNotNullParameter(serializersModuleBuilder, "<this>");
        Intrinsics.checkNotNullParameter(baseClass, "baseClass");
        Intrinsics.checkNotNullParameter(builderAction, "builderAction");
        PolymorphicModuleBuilder polymorphicModuleBuilder = new PolymorphicModuleBuilder(baseClass, kSerializer);
        builderAction.invoke(polymorphicModuleBuilder);
        polymorphicModuleBuilder.buildTo(serializersModuleBuilder);
    }
}
