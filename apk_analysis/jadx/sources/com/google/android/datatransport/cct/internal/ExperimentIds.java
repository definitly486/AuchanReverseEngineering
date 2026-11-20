package com.google.android.datatransport.cct.internal;

import com.google.auto.value.AutoValue;

/* JADX INFO: loaded from: classes.dex */
@AutoValue
public abstract class ExperimentIds {

    @AutoValue.Builder
    public static abstract class Builder {
        public abstract ExperimentIds build();

        public abstract Builder setClearBlob(byte[] bArr);

        public abstract Builder setEncryptedBlob(byte[] bArr);
    }

    public abstract byte[] getClearBlob();

    public abstract byte[] getEncryptedBlob();

    public static Builder builder() {
        return new AutoValue_ExperimentIds.Builder();
    }
}
