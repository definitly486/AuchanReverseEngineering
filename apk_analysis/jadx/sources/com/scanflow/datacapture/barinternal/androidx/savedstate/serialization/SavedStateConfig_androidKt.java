package com.scanflow.datacapture.barinternal.androidx.savedstate.serialization;

import android.util.Size;
import android.util.SizeF;
import android.util.SparseArray;
import com.scanflow.datacapture.barinternal.androidx.savedstate.serialization.serializers.SizeFSerializer;
import com.scanflow.datacapture.barinternal.androidx.savedstate.serialization.serializers.SizeSerializer;
import com.scanflow.datacapture.barinternal.androidx.savedstate.serialization.serializers.SparseArraySerializer;
import com.scanflow.datacapture.barinternal.kotlin.collections.CollectionsKt;
import java.util.List;
import kotlin.jvm.functions.Function1;
import kotlin.jvm.internal.Intrinsics;
import kotlin.jvm.internal.Reflection;
import kotlinx.serialization.KSerializer;
import kotlinx.serialization.modules.SerializersModule;
import kotlinx.serialization.modules.SerializersModuleBuilder;

/* JADX INFO: compiled from: SavedStateConfig.android.kt */
/* JADX INFO: loaded from: classes.dex */
public abstract class SavedStateConfig_androidKt {
    /* JADX INFO: Access modifiers changed from: private */
    public static final KSerializer getDefaultSerializersModuleOnPlatform$lambda$1$lambda$0(List argSerializers) {
        Intrinsics.checkNotNullParameter(argSerializers, "argSerializers");
        return new SparseArraySerializer((KSerializer) CollectionsKt.first(argSerializers));
    }

    public static final SerializersModule getDefaultSerializersModuleOnPlatform() {
        SerializersModuleBuilder serializersModuleBuilder = new SerializersModuleBuilder();
        serializersModuleBuilder.contextual(Reflection.getOrCreateKotlinClass(Size.class), SizeSerializer.INSTANCE);
        serializersModuleBuilder.contextual(Reflection.getOrCreateKotlinClass(SizeF.class), SizeFSerializer.INSTANCE);
        serializersModuleBuilder.contextual(Reflection.getOrCreateKotlinClass(SparseArray.class), new Function1() { // from class: com.scanflow.datacapture.barinternal.androidx.savedstate.serialization.SavedStateConfig_androidKt$$ExternalSyntheticLambda0
            @Override // kotlin.jvm.functions.Function1
            public final Object invoke(Object obj) {
                return SavedStateConfig_androidKt.getDefaultSerializersModuleOnPlatform$lambda$1$lambda$0((List) obj);
            }
        });
        return serializersModuleBuilder.build();
    }
}
