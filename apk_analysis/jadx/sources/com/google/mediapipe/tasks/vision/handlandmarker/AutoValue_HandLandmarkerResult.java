package com.google.mediapipe.tasks.vision.handlandmarker;

import com.google.mediapipe.tasks.components.containers.Category;
import com.google.mediapipe.tasks.components.containers.Landmark;
import com.google.mediapipe.tasks.components.containers.NormalizedLandmark;
import java.util.List;

/* JADX INFO: loaded from: classes3.dex */
final class AutoValue_HandLandmarkerResult extends HandLandmarkerResult {
    private final List<List<Category>> handedness;
    private final List<List<NormalizedLandmark>> landmarks;
    private final long timestampMs;
    private final List<List<Landmark>> worldLandmarks;

    AutoValue_HandLandmarkerResult(long j, List<List<NormalizedLandmark>> list, List<List<Landmark>> list2, List<List<Category>> list3) {
        this.timestampMs = j;
        if (list == null) {
            throw new NullPointerException("Null landmarks");
        }
        this.landmarks = list;
        if (list2 == null) {
            throw new NullPointerException("Null worldLandmarks");
        }
        this.worldLandmarks = list2;
        if (list3 == null) {
            throw new NullPointerException("Null handedness");
        }
        this.handedness = list3;
    }

    @Override // com.google.mediapipe.tasks.vision.handlandmarker.HandLandmarkerResult, com.google.mediapipe.tasks.core.TaskResult
    public long timestampMs() {
        return this.timestampMs;
    }

    @Override // com.google.mediapipe.tasks.vision.handlandmarker.HandLandmarkerResult
    public List<List<NormalizedLandmark>> landmarks() {
        return this.landmarks;
    }

    @Override // com.google.mediapipe.tasks.vision.handlandmarker.HandLandmarkerResult
    public List<List<Landmark>> worldLandmarks() {
        return this.worldLandmarks;
    }

    @Override // com.google.mediapipe.tasks.vision.handlandmarker.HandLandmarkerResult
    public List<List<Category>> handedness() {
        return this.handedness;
    }

    public String toString() {
        return "HandLandmarkerResult{timestampMs=" + this.timestampMs + ", landmarks=" + this.landmarks + ", worldLandmarks=" + this.worldLandmarks + ", handedness=" + this.handedness + "}";
    }

    public boolean equals(Object obj) {
        if (obj == this) {
            return true;
        }
        if (obj instanceof HandLandmarkerResult) {
            HandLandmarkerResult handLandmarkerResult = (HandLandmarkerResult) obj;
            if (this.timestampMs == handLandmarkerResult.timestampMs() && this.landmarks.equals(handLandmarkerResult.landmarks()) && this.worldLandmarks.equals(handLandmarkerResult.worldLandmarks()) && this.handedness.equals(handLandmarkerResult.handedness())) {
                return true;
            }
        }
        return false;
    }

    public int hashCode() {
        long j = this.timestampMs;
        return ((((((((int) (j ^ (j >>> 32))) ^ 1000003) * 1000003) ^ this.landmarks.hashCode()) * 1000003) ^ this.worldLandmarks.hashCode()) * 1000003) ^ this.handedness.hashCode();
    }
}
