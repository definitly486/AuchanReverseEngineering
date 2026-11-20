package com.google.mediapipe.tasks.vision.imageembedder;

import com.google.auto.value.AutoValue;
import com.google.mediapipe.tasks.components.containers.EmbeddingResult;
import com.google.mediapipe.tasks.components.containers.proto.EmbeddingsProto;
import com.google.mediapipe.tasks.core.TaskResult;

/* JADX INFO: loaded from: classes3.dex */
@AutoValue
public abstract class ImageEmbedderResult implements TaskResult {
    public abstract EmbeddingResult embeddingResult();

    @Override // com.google.mediapipe.tasks.core.TaskResult
    public abstract long timestampMs();

    static ImageEmbedderResult create(EmbeddingResult embeddingResult, long j) {
        return new AutoValue_ImageEmbedderResult(embeddingResult, j);
    }

    static ImageEmbedderResult createFromProto(EmbeddingsProto.EmbeddingResult embeddingResult, long j) {
        return create(EmbeddingResult.createFromProto(embeddingResult), j);
    }
}
