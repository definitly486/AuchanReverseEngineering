package com.google.android.datatransport.cct.internal;

import com.google.auto.value.AutoValue;

/* JADX INFO: loaded from: classes.dex */
@AutoValue
public abstract class ExternalPRequestContext {

    @AutoValue.Builder
    public static abstract class Builder {
        public abstract ExternalPRequestContext build();

        public abstract Builder setOriginAssociatedProductId(Integer num);
    }

    public abstract Integer getOriginAssociatedProductId();

    public static Builder builder() {
        return new AutoValue_ExternalPRequestContext.Builder();
    }
}
