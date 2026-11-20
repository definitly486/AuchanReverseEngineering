package com.google.mediapipe.tasks.components.containers;

import java.util.List;
import java.util.Optional;

/* JADX INFO: loaded from: classes3.dex */
final class AutoValue_EmbeddingResult extends EmbeddingResult {
    private final List<Embedding> embeddings;
    private final Optional<Long> timestampMs;

    AutoValue_EmbeddingResult(List<Embedding> list, Optional<Long> optional) {
        if (list == null) {
            throw new NullPointerException("Null embeddings");
        }
        this.embeddings = list;
        if (optional == null) {
            throw new NullPointerException("Null timestampMs");
        }
        this.timestampMs = optional;
    }

    @Override // com.google.mediapipe.tasks.components.containers.EmbeddingResult
    public List<Embedding> embeddings() {
        return this.embeddings;
    }

    @Override // com.google.mediapipe.tasks.components.containers.EmbeddingResult
    public Optional<Long> timestampMs() {
        return this.timestampMs;
    }

    public String toString() {
        return "EmbeddingResult{embeddings=" + this.embeddings + ", timestampMs=" + this.timestampMs + "}";
    }

    public boolean equals(Object obj) {
        if (obj == this) {
            return true;
        }
        if (obj instanceof EmbeddingResult) {
            EmbeddingResult embeddingResult = (EmbeddingResult) obj;
            if (this.embeddings.equals(embeddingResult.embeddings()) && this.timestampMs.equals(embeddingResult.timestampMs())) {
                return true;
            }
        }
        return false;
    }

    public int hashCode() {
        return ((this.embeddings.hashCode() ^ 1000003) * 1000003) ^ this.timestampMs.hashCode();
    }
}
