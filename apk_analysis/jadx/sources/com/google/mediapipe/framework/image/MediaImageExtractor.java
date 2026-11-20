package com.google.mediapipe.framework.image;

import android.media.Image;

/* JADX INFO: loaded from: classes3.dex */
public class MediaImageExtractor {
    private MediaImageExtractor() {
    }

    public static Image extract(MPImage mPImage) {
        MPImageContainer container = mPImage.getContainer(3);
        if (container != null) {
            return ((MediaImageContainer) container).getImage();
        }
        throw new IllegalArgumentException("Extract Media Image from a MPImage created by objects other than Media Image is not supported");
    }
}
