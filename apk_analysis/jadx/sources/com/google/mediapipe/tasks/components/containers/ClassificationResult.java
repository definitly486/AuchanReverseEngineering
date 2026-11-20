package com.google.mediapipe.tasks.components.containers;

import com.google.auto.value.AutoValue;
import com.google.mediapipe.tasks.components.containers.proto.ClassificationsProto;
import java.util.ArrayList;
import java.util.Collections;
import java.util.Iterator;
import java.util.List;
import java.util.Optional;

/* JADX INFO: loaded from: classes3.dex */
@AutoValue
public abstract class ClassificationResult {
    public abstract List<Classifications> classifications();

    public abstract Optional<Long> timestampMs();

    public static ClassificationResult create(List<Classifications> list, Optional<Long> optional) {
        return new AutoValue_ClassificationResult(Collections.unmodifiableList(list), optional);
    }

    public static ClassificationResult createFromProto(ClassificationsProto.ClassificationResult classificationResult) {
        ArrayList arrayList = new ArrayList();
        Iterator<ClassificationsProto.Classifications> it = classificationResult.getClassificationsList().iterator();
        while (it.hasNext()) {
            arrayList.add(Classifications.createFromProto(it.next()));
        }
        return create(arrayList, classificationResult.hasTimestampMs() ? Optional.of(Long.valueOf(classificationResult.getTimestampMs())) : Optional.empty());
    }
}
