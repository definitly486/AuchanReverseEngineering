package com.google.mediapipe.tasks.vision.imageembedder;

import com.google.mediapipe.tasks.components.containers.EmbeddingResult;

/* JADX INFO: loaded from: classes3.dex */
final class AutoValue_ImageEmbedderResult extends ImageEmbedderResult {
    private final EmbeddingResult embeddingResult;
    private final long timestampMs;

    AutoValue_ImageEmbedderResult(EmbeddingResult embeddingResult, long j) {
        if (embeddingResult == null) {
            throw new NullPointerException("Null embeddingResult");
        }
        this.embeddingResult = embeddingResult;
        this.timestampMs = j;
    }

    @Override // com.google.mediapipe.tasks.vision.imageembedder.ImageEmbedderResult
    public EmbeddingResult embeddingResult() {
        return this.embeddingResult;
    }

    @Override // com.google.mediapipe.tasks.vision.imageembedder.ImageEmbedderResult, com.google.mediapipe.tasks.core.TaskResult
    public long timestampMs() {
        return this.timestampMs;
    }

    public String toString() {
        return "ImageEmbedderResult{embeddingResult=" + this.embeddingResult + ", timestampMs=" + this.timestampMs + "}";
    }

    public boolean equals(Object obj) {
        if (obj == this) {
            return true;
        }
        if (obj instanceof ImageEmbedderResult) {
            ImageEmbedderResult imageEmbedderResult = (ImageEmbedderResult) obj;
            if (this.embeddingResult.equals(imageEmbedderResult.embeddingResult()) && this.timestampMs == imageEmbedderResult.timestampMs()) {
                return true;
            }
        }
        return false;
    }

    public int hashCode() {
        int iHashCode = (this.embeddingResult.hashCode() ^ 1000003) * 1000003;
        long j = this.timestampMs;
        return iHashCode ^ ((int) (j ^ (j >>> 32)));
    }
}
