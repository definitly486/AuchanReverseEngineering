package com.google.mlkit.vision.text.pipeline;

import com.google.android.gms.common.annotation.KeepForSdk;

/* JADX INFO: compiled from: com.google.mlkit:text-recognition-bundled-common@@17.0.0 */
/* JADX INFO: loaded from: classes3.dex */
@KeepForSdk
public abstract class VkpTextRecognizerOptions {

    /* JADX INFO: compiled from: com.google.mlkit:text-recognition-bundled-common@@17.0.0 */
    @KeepForSdk
    public static abstract class Builder {
        @KeepForSdk
        public abstract VkpTextRecognizerOptions build();

        @KeepForSdk
        abstract Builder setConfigLabel(String str);

        @KeepForSdk
        public abstract Builder setEnableLowLatencyInBackground(boolean z);

        @KeepForSdk
        public abstract Builder setLanguageHint(String str);

        @KeepForSdk
        public abstract Builder setModelDir(String str);
    }

    @KeepForSdk
    public static Builder builder(String str, String str2, String str3) {
        zbc zbcVar = new zbc();
        zbcVar.setConfigLabel(str);
        if (str2 == null) {
            str2 = "mlkit-google-ocr-models";
        }
        zbcVar.setModelDir(str2);
        zbcVar.setLanguageHint(str3);
        zbcVar.setEnableLowLatencyInBackground(false);
        return zbcVar;
    }

    abstract String zba();

    abstract String zbb();

    abstract String zbc();

    abstract boolean zbd();
}
