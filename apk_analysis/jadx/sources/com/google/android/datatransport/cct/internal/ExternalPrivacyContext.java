package com.google.android.datatransport.cct.internal;

import com.google.auto.value.AutoValue;

/* JADX INFO: loaded from: classes.dex */
@AutoValue
public abstract class ExternalPrivacyContext {

    @AutoValue.Builder
    public static abstract class Builder {
        public abstract ExternalPrivacyContext build();

        public abstract Builder setPrequest(ExternalPRequestContext externalPRequestContext);
    }

    public abstract ExternalPRequestContext getPrequest();

    public static Builder builder() {
        return new AutoValue_ExternalPrivacyContext.Builder();
    }
}
