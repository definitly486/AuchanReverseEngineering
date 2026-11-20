package com.google.mediapipe.tasks.vision.facelandmarker;

import com.google.mediapipe.tasks.components.containers.Category;
import com.google.mediapipe.tasks.components.containers.NormalizedLandmark;
import java.util.List;
import java.util.Optional;

/* JADX INFO: loaded from: classes3.dex */
final class AutoValue_FaceLandmarkerResult extends FaceLandmarkerResult {
    private final Optional<List<List<Category>>> faceBlendshapes;
    private final List<List<NormalizedLandmark>> faceLandmarks;
    private final Optional<List<float[]>> facialTransformationMatrixes;
    private final long timestampMs;

    AutoValue_FaceLandmarkerResult(long j, List<List<NormalizedLandmark>> list, Optional<List<List<Category>>> optional, Optional<List<float[]>> optional2) {
        this.timestampMs = j;
        if (list == null) {
            throw new NullPointerException("Null faceLandmarks");
        }
        this.faceLandmarks = list;
        if (optional == null) {
            throw new NullPointerException("Null faceBlendshapes");
        }
        this.faceBlendshapes = optional;
        if (optional2 == null) {
            throw new NullPointerException("Null facialTransformationMatrixes");
        }
        this.facialTransformationMatrixes = optional2;
    }

    @Override // com.google.mediapipe.tasks.vision.facelandmarker.FaceLandmarkerResult, com.google.mediapipe.tasks.core.TaskResult
    public long timestampMs() {
        return this.timestampMs;
    }

    @Override // com.google.mediapipe.tasks.vision.facelandmarker.FaceLandmarkerResult
    public List<List<NormalizedLandmark>> faceLandmarks() {
        return this.faceLandmarks;
    }

    @Override // com.google.mediapipe.tasks.vision.facelandmarker.FaceLandmarkerResult
    public Optional<List<List<Category>>> faceBlendshapes() {
        return this.faceBlendshapes;
    }

    @Override // com.google.mediapipe.tasks.vision.facelandmarker.FaceLandmarkerResult
    public Optional<List<float[]>> facialTransformationMatrixes() {
        return this.facialTransformationMatrixes;
    }

    public String toString() {
        return "FaceLandmarkerResult{timestampMs=" + this.timestampMs + ", faceLandmarks=" + this.faceLandmarks + ", faceBlendshapes=" + this.faceBlendshapes + ", facialTransformationMatrixes=" + this.facialTransformationMatrixes + "}";
    }

    public boolean equals(Object obj) {
        if (obj == this) {
            return true;
        }
        if (obj instanceof FaceLandmarkerResult) {
            FaceLandmarkerResult faceLandmarkerResult = (FaceLandmarkerResult) obj;
            if (this.timestampMs == faceLandmarkerResult.timestampMs() && this.faceLandmarks.equals(faceLandmarkerResult.faceLandmarks()) && this.faceBlendshapes.equals(faceLandmarkerResult.faceBlendshapes()) && this.facialTransformationMatrixes.equals(faceLandmarkerResult.facialTransformationMatrixes())) {
                return true;
            }
        }
        return false;
    }

    public int hashCode() {
        long j = this.timestampMs;
        return ((((((((int) (j ^ (j >>> 32))) ^ 1000003) * 1000003) ^ this.faceLandmarks.hashCode()) * 1000003) ^ this.faceBlendshapes.hashCode()) * 1000003) ^ this.facialTransformationMatrixes.hashCode();
    }
}
