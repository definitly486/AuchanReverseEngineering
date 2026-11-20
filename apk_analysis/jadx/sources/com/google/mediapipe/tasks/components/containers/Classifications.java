package com.google.mediapipe.tasks.components.containers;

import com.google.auto.value.AutoValue;
import com.google.mediapipe.tasks.components.containers.proto.ClassificationsProto;
import java.util.Collections;
import java.util.List;
import java.util.Optional;

/* JADX INFO: loaded from: classes3.dex */
@AutoValue
public abstract class Classifications {
    public abstract List<Category> categories();

    public abstract int headIndex();

    public abstract Optional<String> headName();

    public static Classifications create(List<Category> list, int i, Optional<String> optional) {
        return new AutoValue_Classifications(Collections.unmodifiableList(list), i, optional);
    }

    public static Classifications createFromProto(ClassificationsProto.Classifications classifications) {
        return create(Category.createListFromProto(classifications.getClassificationList()), classifications.getHeadIndex(), classifications.hasHeadName() ? Optional.of(classifications.getHeadName()) : Optional.empty());
    }
}
