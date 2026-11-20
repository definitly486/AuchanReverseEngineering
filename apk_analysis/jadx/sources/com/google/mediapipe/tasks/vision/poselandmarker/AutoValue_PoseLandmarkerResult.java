package com.google.mediapipe.tasks.vision.poselandmarker;

import com.google.mediapipe.framework.image.MPImage;
import com.google.mediapipe.tasks.components.containers.Landmark;
import com.google.mediapipe.tasks.components.containers.NormalizedLandmark;
import java.util.List;
import java.util.Optional;

/* JADX INFO: loaded from: classes3.dex */
final class AutoValue_PoseLandmarkerResult extends PoseLandmarkerResult {
    private final List<List<NormalizedLandmark>> landmarks;
    private final Optional<List<MPImage>> segmentationMasks;
    private final long timestampMs;
    private final List<List<Landmark>> worldLandmarks;

    AutoValue_PoseLandmarkerResult(long j, List<List<NormalizedLandmark>> list, List<List<Landmark>> list2, Optional<List<MPImage>> optional) {
        this.timestampMs = j;
        if (list == null) {
            throw new NullPointerException("Null landmarks");
        }
        this.landmarks = list;
        if (list2 == null) {
            throw new NullPointerException("Null worldLandmarks");
        }
        this.worldLandmarks = list2;
        if (optional == null) {
            throw new NullPointerException("Null segmentationMasks");
        }
        this.segmentationMasks = optional;
    }

    @Override // com.google.mediapipe.tasks.vision.poselandmarker.PoseLandmarkerResult, com.google.mediapipe.tasks.core.TaskResult
    public long timestampMs() {
        return this.timestampMs;
    }

    @Override // com.google.mediapipe.tasks.vision.poselandmarker.PoseLandmarkerResult
    public List<List<NormalizedLandmark>> landmarks() {
        return this.landmarks;
    }

    @Override // com.google.mediapipe.tasks.vision.poselandmarker.PoseLandmarkerResult
    public List<List<Landmark>> worldLandmarks() {
        return this.worldLandmarks;
    }

    @Override // com.google.mediapipe.tasks.vision.poselandmarker.PoseLandmarkerResult
    public Optional<List<MPImage>> segmentationMasks() {
        return this.segmentationMasks;
    }

    public String toString() {
        return "PoseLandmarkerResult{timestampMs=" + this.timestampMs + ", landmarks=" + this.landmarks + ", worldLandmarks=" + this.worldLandmarks + ", segmentationMasks=" + this.segmentationMasks + "}";
    }

    public boolean equals(Object obj) {
        if (obj == this) {
            return true;
        }
        if (obj instanceof PoseLandmarkerResult) {
            PoseLandmarkerResult poseLandmarkerResult = (PoseLandmarkerResult) obj;
            if (this.timestampMs == poseLandmarkerResult.timestampMs() && this.landmarks.equals(poseLandmarkerResult.landmarks()) && this.worldLandmarks.equals(poseLandmarkerResult.worldLandmarks()) && this.segmentationMasks.equals(poseLandmarkerResult.segmentationMasks())) {
                return true;
            }
        }
        return false;
    }

    public int hashCode() {
        long j = this.timestampMs;
        return ((((((((int) (j ^ (j >>> 32))) ^ 1000003) * 1000003) ^ this.landmarks.hashCode()) * 1000003) ^ this.worldLandmarks.hashCode()) * 1000003) ^ this.segmentationMasks.hashCode();
    }
}
