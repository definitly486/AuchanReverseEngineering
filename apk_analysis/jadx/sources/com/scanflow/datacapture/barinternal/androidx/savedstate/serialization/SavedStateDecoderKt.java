package com.scanflow.datacapture.barinternal.androidx.savedstate.serialization;

import android.os.Bundle;
import kotlin.jvm.internal.Intrinsics;
import kotlinx.serialization.DeserializationStrategy;

/* JADX INFO: compiled from: SavedStateDecoder.kt */
/* JADX INFO: loaded from: classes.dex */
public abstract class SavedStateDecoderKt {
    public static final Object decodeFromSavedState(DeserializationStrategy deserializer, Bundle savedState, SavedStateConfiguration configuration) {
        Intrinsics.checkNotNullParameter(deserializer, "deserializer");
        Intrinsics.checkNotNullParameter(savedState, "savedState");
        Intrinsics.checkNotNullParameter(configuration, "configuration");
        return new SavedStateDecoder(savedState, configuration).decodeSerializableValue(deserializer);
    }
}
