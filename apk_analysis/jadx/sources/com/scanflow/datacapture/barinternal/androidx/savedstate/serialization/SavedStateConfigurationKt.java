package com.scanflow.datacapture.barinternal.androidx.savedstate.serialization;

import android.os.Bundle;
import com.scanflow.datacapture.barinternal.androidx.savedstate.serialization.serializers.SavedStateSerializer;
import kotlin.jvm.internal.Reflection;
import kotlinx.serialization.modules.SerializersModule;
import kotlinx.serialization.modules.SerializersModuleBuilder;
import kotlinx.serialization.modules.SerializersModuleKt;

/* JADX INFO: compiled from: SavedStateConfiguration.kt */
/* JADX INFO: loaded from: classes.dex */
public abstract class SavedStateConfigurationKt {
    private static final SerializersModule DEFAULT_SERIALIZERS_MODULE;

    static {
        SerializersModuleBuilder serializersModuleBuilder = new SerializersModuleBuilder();
        serializersModuleBuilder.contextual(Reflection.getOrCreateKotlinClass(Bundle.class), SavedStateSerializer.INSTANCE);
        DEFAULT_SERIALIZERS_MODULE = SerializersModuleKt.plus(serializersModuleBuilder.build(), SavedStateConfig_androidKt.getDefaultSerializersModuleOnPlatform());
    }
}
