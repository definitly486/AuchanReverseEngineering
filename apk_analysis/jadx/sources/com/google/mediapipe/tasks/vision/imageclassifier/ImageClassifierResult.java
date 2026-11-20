package com.google.mediapipe.tasks.vision.imageclassifier;

import com.google.auto.value.AutoValue;
import com.google.mediapipe.tasks.components.containers.ClassificationResult;
import com.google.mediapipe.tasks.components.containers.proto.ClassificationsProto;
import com.google.mediapipe.tasks.core.TaskResult;

/* JADX INFO: loaded from: classes3.dex */
@AutoValue
public abstract class ImageClassifierResult implements TaskResult {
    public abstract ClassificationResult classificationResult();

    @Override // com.google.mediapipe.tasks.core.TaskResult
    public abstract long timestampMs();

    static ImageClassifierResult create(ClassificationResult classificationResult, long j) {
        return new AutoValue_ImageClassifierResult(classificationResult, j);
    }

    static ImageClassifierResult createFromProto(ClassificationsProto.ClassificationResult classificationResult, long j) {
        return create(ClassificationResult.createFromProto(classificationResult), j);
    }
}
