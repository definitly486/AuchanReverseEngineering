package com.google.mediapipe.framework.image;

import java.nio.ByteBuffer;

/* JADX INFO: loaded from: classes3.dex */
public class ByteBufferImageBuilder {
    private final ByteBuffer buffer;
    private final int height;
    private final int imageFormat;
    private long timestamp = 0;
    private final int width;

    public ByteBufferImageBuilder(ByteBuffer byteBuffer, int i, int i2, int i3) {
        this.buffer = byteBuffer;
        this.width = i;
        this.height = i2;
        this.imageFormat = i3;
    }

    ByteBufferImageBuilder setTimestamp(long j) {
        this.timestamp = j;
        return this;
    }

    public MPImage build() {
        return new MPImage(new ByteBufferImageContainer(this.buffer, this.imageFormat), this.timestamp, this.width, this.height);
    }
}
