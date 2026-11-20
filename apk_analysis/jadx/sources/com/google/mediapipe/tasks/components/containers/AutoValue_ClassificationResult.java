package com.google.mediapipe.tasks.components.containers;

import java.util.List;
import java.util.Optional;

/* JADX INFO: loaded from: classes3.dex */
final class AutoValue_ClassificationResult extends ClassificationResult {
    private final List<Classifications> classifications;
    private final Optional<Long> timestampMs;

    AutoValue_ClassificationResult(List<Classifications> list, Optional<Long> optional) {
        if (list == null) {
            throw new NullPointerException("Null classifications");
        }
        this.classifications = list;
        if (optional == null) {
            throw new NullPointerException("Null timestampMs");
        }
        this.timestampMs = optional;
    }

    @Override // com.google.mediapipe.tasks.components.containers.ClassificationResult
    public List<Classifications> classifications() {
        return this.classifications;
    }

    @Override // com.google.mediapipe.tasks.components.containers.ClassificationResult
    public Optional<Long> timestampMs() {
        return this.timestampMs;
    }

    public String toString() {
        return "ClassificationResult{classifications=" + this.classifications + ", timestampMs=" + this.timestampMs + "}";
    }

    public boolean equals(Object obj) {
        if (obj == this) {
            return true;
        }
        if (obj instanceof ClassificationResult) {
            ClassificationResult classificationResult = (ClassificationResult) obj;
            if (this.classifications.equals(classificationResult.classifications()) && this.timestampMs.equals(classificationResult.timestampMs())) {
                return true;
            }
        }
        return false;
    }

    public int hashCode() {
        return ((this.classifications.hashCode() ^ 1000003) * 1000003) ^ this.timestampMs.hashCode();
    }
}
