package com.google.mediapipe.tasks.vision.facedetector;

import com.google.mediapipe.tasks.components.containers.Detection;
import java.util.List;

/* JADX INFO: loaded from: classes3.dex */
final class AutoValue_FaceDetectorResult extends FaceDetectorResult {
    private final List<Detection> detections;
    private final long timestampMs;

    AutoValue_FaceDetectorResult(long j, List<Detection> list) {
        this.timestampMs = j;
        if (list == null) {
            throw new NullPointerException("Null detections");
        }
        this.detections = list;
    }

    @Override // com.google.mediapipe.tasks.vision.facedetector.FaceDetectorResult, com.google.mediapipe.tasks.core.TaskResult
    public long timestampMs() {
        return this.timestampMs;
    }

    @Override // com.google.mediapipe.tasks.vision.facedetector.FaceDetectorResult
    public List<Detection> detections() {
        return this.detections;
    }

    public String toString() {
        return "FaceDetectorResult{timestampMs=" + this.timestampMs + ", detections=" + this.detections + "}";
    }

    public boolean equals(Object obj) {
        if (obj == this) {
            return true;
        }
        if (obj instanceof FaceDetectorResult) {
            FaceDetectorResult faceDetectorResult = (FaceDetectorResult) obj;
            if (this.timestampMs == faceDetectorResult.timestampMs() && this.detections.equals(faceDetectorResult.detections())) {
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
