package com.google.mediapipe.tasks.components.containers;

/* JADX INFO: loaded from: classes3.dex */
final class AutoValue_Category extends Category {
    private final String categoryName;
    private final String displayName;
    private final int index;
    private final float score;

    AutoValue_Category(float f, int i, String str, String str2) {
        this.score = f;
        this.index = i;
        if (str == null) {
            throw new NullPointerException("Null categoryName");
        }
        this.categoryName = str;
        if (str2 == null) {
            throw new NullPointerException("Null displayName");
        }
        this.displayName = str2;
    }

    @Override // com.google.mediapipe.tasks.components.containers.Category
    public float score() {
        return this.score;
    }

    @Override // com.google.mediapipe.tasks.components.containers.Category
    public int index() {
        return this.index;
    }

    @Override // com.google.mediapipe.tasks.components.containers.Category
    public String categoryName() {
        return this.categoryName;
    }

    @Override // com.google.mediapipe.tasks.components.containers.Category
    public String displayName() {
        return this.displayName;
    }
}
