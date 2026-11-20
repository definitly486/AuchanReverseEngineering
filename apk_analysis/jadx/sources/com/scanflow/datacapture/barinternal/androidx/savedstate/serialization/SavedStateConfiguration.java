package com.scanflow.datacapture.barinternal.androidx.savedstate.serialization;

import kotlin.jvm.internal.DefaultConstructorMarker;
import kotlinx.serialization.modules.SerializersModule;

/* JADX INFO: compiled from: SavedStateConfiguration.kt */
/* JADX INFO: loaded from: classes.dex */
public final class SavedStateConfiguration {
    public static final Companion Companion = new Companion(null);
    public static final SavedStateConfiguration DEFAULT = new SavedStateConfiguration(null, 0, false, 7, null);
    private final int classDiscriminatorMode;
    private final boolean encodeDefaults;
    private final SerializersModule serializersModule;

    private SavedStateConfiguration(SerializersModule serializersModule, int i, boolean z) {
        this.serializersModule = serializersModule;
        this.classDiscriminatorMode = i;
        this.encodeDefaults = z;
    }

    /* synthetic */ SavedStateConfiguration(SerializersModule serializersModule, int i, boolean z, int i2, DefaultConstructorMarker defaultConstructorMarker) {
        this((i2 & 1) != 0 ? SavedStateConfigurationKt.DEFAULT_SERIALIZERS_MODULE : serializersModule, (i2 & 2) != 0 ? 2 : i, (i2 & 4) != 0 ? false : z);
    }

    public final SerializersModule getSerializersModule() {
        return this.serializersModule;
    }

    public final int getClassDiscriminatorMode() {
        return this.classDiscriminatorMode;
    }

    public final boolean getEncodeDefaults() {
        return this.encodeDefaults;
    }

    /* JADX INFO: compiled from: SavedStateConfiguration.kt */
    public static final class Companion {
        public /* synthetic */ Companion(DefaultConstructorMarker defaultConstructorMarker) {
            this();
        }

        private Companion() {
        }
    }
}
