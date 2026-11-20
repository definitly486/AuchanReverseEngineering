package com.google.mediapipe.framework.image;

import java.nio.ByteBuffer;

/* JADX INFO: loaded from: classes3.dex */
final class AutoValue_ByteBufferExtractor_Result extends ByteBufferExtractor.Result {
    private final ByteBuffer buffer;
    private final int format;

    AutoValue_ByteBufferExtractor_Result(ByteBuffer byteBuffer, int i) {
        if (byteBuffer == null) {
            throw new NullPointerException("Null buffer");
        }
        this.buffer = byteBuffer;
        this.format = i;
    }

    @Override // com.google.mediapipe.framework.image.ByteBufferExtractor.Result
    public ByteBuffer buffer() {
        return this.buffer;
    }

    @Override // com.google.mediapipe.framework.image.ByteBufferExtractor.Result
    public int format() {
        return this.format;
    }

    public String toString() {
        return "Result{buffer=" + this.buffer + ", format=" + this.format + "}";
    }

    public boolean equals(Object obj) {
        if (obj == this) {
            return true;
        }
        if (obj instanceof ByteBufferExtractor.Result) {
            ByteBufferExtractor.Result result = (ByteBufferExtractor.Result) obj;
            if (this.buffer.equals(result.buffer()) && this.format == result.format()) {
                return true;
            }
        }
        return false;
    }

    public int hashCode() {
        return ((this.buffer.hashCode() ^ 1000003) * 1000003) ^ this.format;
    }
}
