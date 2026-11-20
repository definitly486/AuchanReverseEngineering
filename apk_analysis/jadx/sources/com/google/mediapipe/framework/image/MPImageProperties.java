package com.google.mediapipe.framework.image;

import com.google.auto.value.AutoValue;
import com.google.auto.value.extension.memoized.Memoized;

/* JADX INFO: loaded from: classes3.dex */
@AutoValue
public abstract class MPImageProperties {
    public abstract int getImageFormat();

    public abstract int getStorageType();

    @Memoized
    public abstract int hashCode();

    static Builder builder() {
        return new C$AutoValue_MPImageProperties.Builder();
    }

    @AutoValue.Builder
    static abstract class Builder {
        abstract MPImageProperties build();

        abstract Builder setImageFormat(int i);

        abstract Builder setStorageType(int i);

        Builder() {
        }
    }

    MPImageProperties() {
    }
}
