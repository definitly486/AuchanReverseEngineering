package com.google.mediapipe.tasks.components.containers;

import com.google.auto.value.AutoValue;
import com.google.mediapipe.tasks.components.containers.proto.EmbeddingsProto;
import java.util.Optional;

/* JADX INFO: loaded from: classes3.dex */
@AutoValue
public abstract class Embedding {
    public abstract float[] floatEmbedding();

    public abstract int headIndex();

    public abstract Optional<String> headName();

    public abstract byte[] quantizedEmbedding();

    public static Embedding create(float[] fArr, byte[] bArr, int i, Optional<String> optional) {
        return new AutoValue_Embedding(fArr, bArr, i, optional);
    }

    public static Embedding createFromProto(EmbeddingsProto.Embedding embedding) {
        float[] fArr;
        byte[] byteArray;
        if (embedding.hasFloatEmbedding()) {
            int valuesCount = embedding.getFloatEmbedding().getValuesCount();
            fArr = new float[valuesCount];
            for (int i = 0; i < valuesCount; i++) {
                fArr[i] = embedding.getFloatEmbedding().getValues(i);
            }
        } else {
            fArr = new float[0];
        }
        if (embedding.hasQuantizedEmbedding()) {
            byteArray = embedding.getQuantizedEmbedding().getValues().toByteArray();
        } else {
            byteArray = new byte[0];
        }
        return create(fArr, byteArray, embedding.getHeadIndex(), embedding.hasHeadName() ? Optional.of(embedding.getHeadName()) : Optional.empty());
    }
}
