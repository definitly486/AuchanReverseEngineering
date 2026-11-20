package com.google.mediapipe.framework.image;

import android.graphics.Bitmap;

/* JADX INFO: loaded from: classes3.dex */
public final class BitmapExtractor {
    public static Bitmap extract(MPImage mPImage) {
        MPImageContainer container = mPImage.getContainer(1);
        if (container != null) {
            return ((BitmapImageContainer) container).getBitmap();
        }
        throw new IllegalArgumentException("Extracting Bitmap from a MPImage created by objects other than Bitmap is not supported");
    }

    private BitmapExtractor() {
    }
}
