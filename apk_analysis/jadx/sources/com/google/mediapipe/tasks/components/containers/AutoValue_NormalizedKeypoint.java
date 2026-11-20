package com.google.mediapipe.tasks.components.containers;

import java.util.Optional;

/* JADX INFO: loaded from: classes3.dex */
final class AutoValue_NormalizedKeypoint extends NormalizedKeypoint {
    private final Optional<String> label;
    private final Optional<Float> score;
    private final float x;
    private final float y;

    AutoValue_NormalizedKeypoint(float f, float f2, Optional<String> optional, Optional<Float> optional2) {
        this.x = f;
        this.y = f2;
        if (optional == null) {
            throw new NullPointerException("Null label");
        }
        this.label = optional;
        if (optional2 == null) {
            throw new NullPointerException("Null score");
        }
        this.score = optional2;
    }

    @Override // com.google.mediapipe.tasks.components.containers.NormalizedKeypoint
    public float x() {
        return this.x;
    }

    @Override // com.google.mediapipe.tasks.components.containers.NormalizedKeypoint
    public float y() {
        return this.y;
    }

    @Override // com.google.mediapipe.tasks.components.containers.NormalizedKeypoint
    public Optional<String> label() {
        return this.label;
    }

    @Override // com.google.mediapipe.tasks.components.containers.NormalizedKeypoint
    public Optional<Float> score() {
        return this.score;
    }
}
