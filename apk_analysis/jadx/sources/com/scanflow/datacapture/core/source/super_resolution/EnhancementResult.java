package com.scanflow.datacapture.core.source.super_resolution;

import android.graphics.Bitmap;

/* JADX INFO: loaded from: classes3.dex */
public class EnhancementResult {
    private final Bitmap[] enhancedImages;

    public EnhancementResult(Bitmap[] bitmapArr) {
        this.enhancedImages = bitmapArr;
    }

    public Bitmap[] getEnhancedImages() {
        return this.enhancedImages;
    }
}
