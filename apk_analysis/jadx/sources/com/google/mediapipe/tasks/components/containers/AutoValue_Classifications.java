package com.google.mediapipe.tasks.components.containers;

import java.util.List;
import java.util.Optional;

/* JADX INFO: loaded from: classes3.dex */
final class AutoValue_Classifications extends Classifications {
    private final List<Category> categories;
    private final int headIndex;
    private final Optional<String> headName;

    AutoValue_Classifications(List<Category> list, int i, Optional<String> optional) {
        if (list == null) {
            throw new NullPointerException("Null categories");
        }
        this.categories = list;
        this.headIndex = i;
        if (optional == null) {
            throw new NullPointerException("Null headName");
        }
        this.headName = optional;
    }

    @Override // com.google.mediapipe.tasks.components.containers.Classifications
    public List<Category> categories() {
        return this.categories;
    }

    @Override // com.google.mediapipe.tasks.components.containers.Classifications
    public int headIndex() {
        return this.headIndex;
    }

    @Override // com.google.mediapipe.tasks.components.containers.Classifications
    public Optional<String> headName() {
        return this.headName;
    }

    public String toString() {
        return "Classifications{categories=" + this.categories + ", headIndex=" + this.headIndex + ", headName=" + this.headName + "}";
    }

    public boolean equals(Object obj) {
        if (obj == this) {
            return true;
        }
        if (obj instanceof Classifications) {
            Classifications classifications = (Classifications) obj;
            if (this.categories.equals(classifications.categories()) && this.headIndex == classifications.headIndex() && this.headName.equals(classifications.headName())) {
                return true;
            }
        }
        return false;
    }

    public int hashCode() {
        return ((((this.categories.hashCode() ^ 1000003) * 1000003) ^ this.headIndex) * 1000003) ^ this.headName.hashCode();
    }
}
