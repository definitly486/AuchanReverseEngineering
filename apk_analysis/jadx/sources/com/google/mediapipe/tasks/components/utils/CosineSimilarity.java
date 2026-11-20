package com.google.mediapipe.tasks.components.utils;

import com.google.mediapipe.tasks.components.containers.Embedding;

/* JADX INFO: loaded from: classes3.dex */
public class CosineSimilarity {
    private CosineSimilarity() {
    }

    public static double compute(Embedding embedding, Embedding embedding2) {
        if (embedding.floatEmbedding().length > 0 && embedding2.floatEmbedding().length > 0) {
            return computeFloat(embedding.floatEmbedding(), embedding2.floatEmbedding());
        }
        if (embedding.quantizedEmbedding().length > 0 && embedding2.quantizedEmbedding().length > 0) {
            return computeQuantized(embedding.quantizedEmbedding(), embedding2.quantizedEmbedding());
        }
        throw new IllegalArgumentException("Cannot compute cosine similarity between quantized and float embeddings.");
    }

    private static double computeFloat(float[] fArr, float[] fArr2) {
        if (fArr.length != fArr2.length) {
            throw new IllegalArgumentException(String.format("Cannot compute cosine similarity between embeddings of different sizes (%d vs. %d).", Integer.valueOf(fArr.length), Integer.valueOf(fArr2.length)));
        }
        double d = 0.0d;
        double d2 = 0.0d;
        double d3 = 0.0d;
        for (int i = 0; i < fArr.length; i++) {
            float f = fArr[i];
            float f2 = fArr2[i];
            d2 += (double) (f * f2);
            d += (double) (f * f);
            d3 += (double) (f2 * f2);
        }
        if (d <= 0.0d || d3 <= 0.0d) {
            throw new IllegalArgumentException("Cannot compute cosine similarity on embedding with 0 norm.");
        }
        return d2 / Math.sqrt(d * d3);
    }

    private static double computeQuantized(byte[] bArr, byte[] bArr2) {
        if (bArr.length != bArr2.length) {
            throw new IllegalArgumentException(String.format("Cannot compute cosine similarity between embeddings of different sizes (%d vs. %d).", Integer.valueOf(bArr.length), Integer.valueOf(bArr2.length)));
        }
        double d = 0.0d;
        double d2 = 0.0d;
        double d3 = 0.0d;
        for (int i = 0; i < bArr.length; i++) {
            byte b = bArr[i];
            byte b2 = bArr2[i];
            d2 += (double) (b * b2);
            d += (double) (b * b);
            d3 += (double) (b2 * b2);
        }
        if (d <= 0.0d || d3 <= 0.0d) {
            throw new IllegalArgumentException("Cannot compute cosine similarity on embedding with 0 norm.");
        }
        return d2 / Math.sqrt(d * d3);
    }
}
