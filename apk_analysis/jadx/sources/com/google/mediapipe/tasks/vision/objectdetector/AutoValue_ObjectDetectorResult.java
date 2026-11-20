package com.google.mediapipe.tasks.vision.objectdetector;

import com.google.mediapipe.tasks.components.containers.Detection;
import java.util.List;

/* JADX INFO: loaded from: classes3.dex */
final class AutoValue_ObjectDetectorResult extends ObjectDetectorResult {
    private final List<Detection> detections;
    private final long timestampMs;

    AutoValue_ObjectDetectorResult(long j, List<Detection> list) {
        this.timestampMs = j;
        if (list == null) {
            throw new NullPointerException("Null detections");
        }
        this.detections = list;
    }

    @Override // com.google.mediapipe.tasks.vision.objectdetector.ObjectDetectionResult, com.google.mediapipe.tasks.core.TaskResult
    public long timestampMs() {
        return this.timestampMs;
    }

    @Override // com.google.mediapipe.tasks.vision.objectdetector.ObjectDetectionResult
    public List<Detection> detections() {
        return this.detections;
    }

    public String toString() {
        return "ObjectDetectorResult{timestampMs=" + this.timestampMs + ", detections=" + this.detections + "}";
    }

    public boolean equals(Object obj) {
        if (obj == this) {
            return true;
        }
        if (obj instanceof ObjectDetectorResult) {
            ObjectDetectorResult objectDetectorResult = (ObjectDetectorResult) obj;
            if (this.timestampMs == objectDetectorResult.timestampMs() && this.detections.equals(objectDetectorResult.detections())) {
                return true;
            }
        }
        return false;
    }

    public int hashCode() {
        long j = this.timestampMs;
        return ((((int) (j ^ (j >>> 32))) ^ 1000003) * 1000003) ^ this.detections.hashCode();
    }
}
