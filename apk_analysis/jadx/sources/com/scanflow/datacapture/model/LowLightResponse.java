package com.scanflow.datacapture.model;

import android.graphics.Bitmap;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: loaded from: classes3.dex */
public final class LowLightResponse {
    private final Bitmap bitmap;
    private final boolean isLowLight;

    public LowLightResponse(Bitmap bitmap, boolean z) {
        Intrinsics.checkNotNullParameter(bitmap, "bitmap");
        this.bitmap = bitmap;
        this.isLowLight = z;
    }

    public static /* synthetic */ LowLightResponse copy$default(LowLightResponse lowLightResponse, Bitmap bitmap, boolean z, int i, Object obj) {
        if ((i & 1) != 0) {
            bitmap = lowLightResponse.bitmap;
        }
        if ((i & 2) != 0) {
            z = lowLightResponse.isLowLight;
        }
        return lowLightResponse.copy(bitmap, z);
    }

    public final Bitmap component1() {
        return this.bitmap;
    }

    public final boolean component2() {
        return this.isLowLight;
    }

    public final LowLightResponse copy(Bitmap bitmap, boolean z) {
        Intrinsics.checkNotNullParameter(bitmap, "bitmap");
        return new LowLightResponse(bitmap, z);
    }

    public boolean equals(Object obj) {
        if (this == obj) {
            return true;
        }
        if (!(obj instanceof LowLightResponse)) {
            return false;
        }
        LowLightResponse lowLightResponse = (LowLightResponse) obj;
        return Intrinsics.areEqual(this.bitmap, lowLightResponse.bitmap) && this.isLowLight == lowLightResponse.isLowLight;
    }

    public final Bitmap getBitmap() {
        return this.bitmap;
    }

    public int hashCode() {
        return Boolean.hashCode(this.isLowLight) + (this.bitmap.hashCode() * 31);
    }

    public final boolean isLowLight() {
        return this.isLowLight;
    }

    public String toString() {
        return "LowLightResponse(bitmap=" + this.bitmap + ", isLowLight=" + this.isLowLight + ')';
    }
}
