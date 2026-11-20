package com.google.mediapipe.framework.image;

import android.media.Image;

/* JADX INFO: loaded from: classes3.dex */
public class MediaImageBuilder {
    private final Image mediaImage;
    private long timestamp = 0;

    public MediaImageBuilder(Image image) {
        this.mediaImage = image;
    }

    MediaImageBuilder setTimestamp(long j) {
        this.timestamp = j;
        return this;
    }

    public MPImage build() {
        return new MPImage(new MediaImageContainer(this.mediaImage), this.timestamp, this.mediaImage.getWidth(), this.mediaImage.getHeight());
    }
}
