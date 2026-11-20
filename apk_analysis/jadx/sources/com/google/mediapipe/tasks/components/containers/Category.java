package com.google.mediapipe.tasks.components.containers;

import com.google.auto.value.AutoValue;
import com.google.mediapipe.formats.proto.ClassificationProto;
import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;
import java.util.Objects;

/* JADX INFO: loaded from: classes3.dex */
@AutoValue
public abstract class Category {
    private static final float TOLERANCE = 1.0E-6f;

    public abstract String categoryName();

    public abstract String displayName();

    public abstract int index();

    public abstract float score();

    public static Category create(float f, int i, String str, String str2) {
        return new AutoValue_Category(f, i, str, str2);
    }

    public static Category createFromProto(ClassificationProto.Classification classification) {
        return create(classification.getScore(), classification.getIndex(), classification.getLabel(), classification.getDisplayName());
    }

    public static List<Category> createListFromProto(ClassificationProto.ClassificationList classificationList) {
        ArrayList arrayList = new ArrayList();
        Iterator<ClassificationProto.Classification> it = classificationList.getClassificationList().iterator();
        while (it.hasNext()) {
            arrayList.add(createFromProto(it.next()));
        }
        return arrayList;
    }

    public final boolean equals(Object obj) {
        if (!(obj instanceof Category)) {
            return false;
        }
        Category category = (Category) obj;
        return Math.abs(category.score() - score()) < TOLERANCE && category.index() == index() && category.categoryName().equals(categoryName()) && category.displayName().equals(displayName());
    }

    public final int hashCode() {
        return Objects.hash(categoryName(), displayName(), Float.valueOf(score()), Integer.valueOf(index()));
    }

    public final String toString() {
        return "<Category \"" + categoryName() + "\" (displayName=" + displayName() + " score=" + score() + " index=" + index() + ")>";
    }
}
