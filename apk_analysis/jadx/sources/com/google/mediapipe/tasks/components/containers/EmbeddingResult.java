package com.google.mediapipe.tasks.components.containers;

import com.google.auto.value.AutoValue;
import com.google.mediapipe.tasks.components.containers.proto.EmbeddingsProto;
import java.util.ArrayList;
import java.util.Collections;
import java.util.Iterator;
import java.util.List;
import java.util.Optional;

/* JADX INFO: loaded from: classes3.dex */
@AutoValue
public abstract class EmbeddingResult {
    public abstract List<Embedding> embeddings();

    public abstract Optional<Long> timestampMs();

    public static EmbeddingResult create(List<Embedding> list, Optional<Long> optional) {
        return new AutoValue_EmbeddingResult(Collections.unmodifiableList(list), optional);
    }

    public static EmbeddingResult createFromProto(EmbeddingsProto.EmbeddingResult embeddingResult) {
        ArrayList arrayList = new ArrayList();
        Iterator<EmbeddingsProto.Embedding> it = embeddingResult.getEmbeddingsList().iterator();
        while (it.hasNext()) {
            arrayList.add(Embedding.createFromProto(it.next()));
        }
        return create(arrayList, embeddingResult.hasTimestampMs() ? Optional.of(Long.valueOf(embeddingResult.getTimestampMs())) : Optional.empty());
    }
}
