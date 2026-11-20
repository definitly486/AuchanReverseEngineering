package com.google.mediapipe.tasks.components.containers;

import java.util.Optional;

/* JADX INFO: loaded from: classes3.dex */
final class AutoValue_NormalizedLandmark extends NormalizedLandmark {
    private final Optional<Float> presence;
    private final Optional<Float> visibility;
    private final float x;
    private final float y;
    private final float z;

    AutoValue_NormalizedLandmark(float f, float f2, float f3, Optional<Float> optional, Optional<Float> optional2) {
        this.x = f;
        this.y = f2;
        this.z = f3;
        if (optional == null) {
            throw new NullPointerException("Null visibility");
        }
        this.visibility = optional;
        if (optional2 == null) {
            throw new NullPointerException("Null presence");
        }
        this.presence = optional2;
    }

    @Override // com.google.mediapipe.tasks.components.containers.NormalizedLandmark
    public float x() {
        return this.x;
    }

    @Override // com.google.mediapipe.tasks.components.containers.NormalizedLandmark
    public float y() {
        return this.y;
    }

    @Override // com.google.mediapipe.tasks.components.containers.NormalizedLandmark
    public float z() {
        return this.z;
    }

    @Override // com.google.mediapipe.tasks.components.containers.NormalizedLandmark
    public Optional<Float> visibility() {
        return this.visibility;
    }

    @Override // com.google.mediapipe.tasks.components.containers.NormalizedLandmark
    public Optional<Float> presence() {
        return this.presence;
    }
}
