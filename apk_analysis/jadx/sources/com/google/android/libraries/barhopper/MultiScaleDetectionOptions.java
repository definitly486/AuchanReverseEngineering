package com.google.android.libraries.barhopper;

import com.google.android.apps.common.proguard.UsedByNative;

/* JADX INFO: compiled from: com.google.mlkit:barcode-scanning@@17.3.0 */
/* JADX INFO: loaded from: classes2.dex */
@UsedByNative("jni_common.cc")
public final class MultiScaleDetectionOptions {

    @UsedByNative("jni_common.cc")
    private float[] extraScales = new float[0];

    public float[] getExtraScales() {
        return this.extraScales;
    }

    public void setExtraScales(float[] fArr) {
        this.extraScales = fArr;
    }
}
