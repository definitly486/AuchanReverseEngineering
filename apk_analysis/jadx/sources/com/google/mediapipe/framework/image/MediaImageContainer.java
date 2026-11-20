package com.google.mediapipe.framework.image;

import android.media.Image;

/* JADX INFO: loaded from: classes3.dex */
class MediaImageContainer implements MPImageContainer {
    private final Image mediaImage;
    private final MPImageProperties properties;

    static int convertFormatCode(int i) {
        if (i == 42) {
            return 1;
        }
        if (i == 41) {
            return 2;
        }
        if (i != 35) {
            return i != 256 ? 0 : 9;
        }
        return 7;
    }

    public MediaImageContainer(Image image) {
        this.mediaImage = image;
        this.properties = MPImageProperties.builder().setStorageType(3).setImageFormat(convertFormatCode(image.getFormat())).build();
    }

    public Image getImage() {
        return this.mediaImage;
    }

    @Override // com.google.mediapipe.framework.image.MPImageContainer
    public MPImageProperties getImageProperties() {
        return this.properties;
    }

    @Override // com.google.mediapipe.framework.image.MPImageContainer
    public void close() {
        this.mediaImage.close();
    }
}
