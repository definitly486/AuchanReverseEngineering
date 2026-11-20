package kotlinx.serialization.modules;

import com.scanflow.datacapture.barinternal.kotlin.collections.CollectionsKt;
import java.util.List;
import kotlin.jvm.internal.DefaultConstructorMarker;
import kotlin.jvm.internal.Intrinsics;
import kotlin.reflect.KClass;
import kotlinx.serialization.DeserializationStrategy;
import kotlinx.serialization.ExperimentalSerializationApi;
import kotlinx.serialization.KSerializer;
import kotlinx.serialization.SerializationStrategy;

/* JADX INFO: compiled from: SerializersModule.kt */
/* JADX INFO: loaded from: classes3.dex */
public abstract class SerializersModule {
    public /* synthetic */ SerializersModule(DefaultConstructorMarker defaultConstructorMarker) {
        this();
    }

    @ExperimentalSerializationApi
    public abstract void dumpTo(SerializersModuleCollector serializersModuleCollector);

    @ExperimentalSerializationApi
    public abstract <T> KSerializer<T> getContextual(KClass<T> kClass, List<? extends KSerializer<?>> list);

    public abstract boolean getHasInterfaceContextualSerializers$kotlinx_serialization_core();

    @ExperimentalSerializationApi
    public abstract <T> DeserializationStrategy<T> getPolymorphic(KClass<? super T> kClass, String str);

    @ExperimentalSerializationApi
    public abstract <T> SerializationStrategy<T> getPolymorphic(KClass<? super T> kClass, T t);

    private SerializersModule() {
    }

    @ExperimentalSerializationApi
    public final /* synthetic */ KSerializer getContextual(KClass kclass) {
        Intrinsics.checkNotNullParameter(kclass, "kclass");
        return getContextual(kclass, CollectionsKt.emptyList());
    }

    /* JADX WARN: Multi-variable type inference failed */
    public static /* synthetic */ KSerializer getContextual$default(SerializersModule serializersModule, KClass kClass, List list, int i, Object obj) {
        if (obj != null) {
            throw new UnsupportedOperationException("Super calls with default arguments not supported in this target, function: getContextual");
        }
        if ((i & 2) != 0) {
            list = CollectionsKt.emptyList();
        }
        return serializersModule.getContextual(kClass, list);
    }
}
