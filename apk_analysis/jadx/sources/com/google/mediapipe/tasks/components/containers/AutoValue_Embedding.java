package com.google.mediapipe.tasks.components.containers;

import java.util.Arrays;
import java.util.Optional;

/* JADX INFO: loaded from: classes3.dex */
final class AutoValue_Embedding extends Embedding {
    private final float[] floatEmbedding;
    private final int headIndex;
    private final Optional<String> headName;
    private final byte[] quantizedEmbedding;

    AutoValue_Embedding(float[] fArr, byte[] bArr, int i, Optional<String> optional) {
        if (fArr == null) {
            throw new NullPointerException("Null floatEmbedding");
        }
        this.floatEmbedding = fArr;
        if (bArr == null) {
            throw new NullPointerException("Null quantizedEmbedding");
        }
        this.quantizedEmbedding = bArr;
        this.headIndex = i;
        if (optional == null) {
            throw new NullPointerException("Null headName");
        }
        this.headName = optional;
    }

    @Override // com.google.mediapipe.tasks.components.containers.Embedding
    public float[] floatEmbedding() {
        return this.floatEmbedding;
    }

    @Override // com.google.mediapipe.tasks.components.containers.Embedding
    public byte[] quantizedEmbedding() {
        return this.quantizedEmbedding;
    }

    @Override // com.google.mediapipe.tasks.components.containers.Embedding
    public int headIndex() {
        return this.headIndex;
    }

    @Override // com.google.mediapipe.tasks.components.containers.Embedding
    public Optional<String> headName() {
        return this.headName;
    }

    public String toString() {
        return "Embedding{floatEmbedding=" + Arrays.toString(this.floatEmbedding) + ", quantizedEmbedding=" + Arrays.toString(this.quantizedEmbedding) + ", headIndex=" + this.headIndex + ", headName=" + this.headName + "}";
    }

    public boolean equals(Object obj) {
        if (obj == this) {
            return true;
        }
        if (obj instanceof Embedding) {
            Embedding embedding = (Embedding) obj;
            boolean z = embedding instanceof AutoValue_Embedding;
            if (Arrays.equals(this.floatEmbedding, z ? ((AutoValue_Embedding) embedding).floatEmbedding : embedding.floatEmbedding())) {
                if (Arrays.equals(this.quantizedEmbedding, z ? ((AutoValue_Embedding) embedding).quantizedEmbedding : embedding.quantizedEmbedding()) && this.headIndex == embedding.headIndex() && this.headName.equals(embedding.headName())) {
                    return true;
                }
            }
        }
        return false;
    }

    public int hashCode() {
        return ((((((Arrays.hashCode(this.floatEmbedding) ^ 1000003) * 1000003) ^ Arrays.hashCode(this.quantizedEmbedding)) * 1000003) ^ this.headIndex) * 1000003) ^ this.headName.hashCode();
    }
}
