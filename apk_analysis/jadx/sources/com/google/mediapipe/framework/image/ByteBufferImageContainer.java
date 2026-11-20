package com.google.mediapipe.framework.image;

import java.nio.ByteBuffer;

/* JADX INFO: loaded from: classes3.dex */
class ByteBufferImageContainer implements MPImageContainer {
    private final ByteBuffer buffer;
    private final MPImageProperties properties;

    @Override // com.google.mediapipe.framework.image.MPImageContainer
    public void close() {
    }

    public ByteBufferImageContainer(ByteBuffer byteBuffer, int i) {
        this.buffer = byteBuffer;
        this.properties = MPImageProperties.builder().setStorageType(2).setImageFormat(i).build();
    }

    public ByteBuffer getByteBuffer() {
        return this.buffer;
    }

    @Override // com.google.mediapipe.framework.image.MPImageContainer
    public MPImageProperties getImageProperties() {
        return this.properties;
    }

    public int getImageFormat() {
        return this.properties.getImageFormat();
    }
}
