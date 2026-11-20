package com.google.mediapipe.tasks.vision.holisticlandmarker;

import com.google.mediapipe.framework.image.MPImage;
import com.google.mediapipe.tasks.components.containers.Category;
import com.google.mediapipe.tasks.components.containers.Landmark;
import com.google.mediapipe.tasks.components.containers.NormalizedLandmark;
import java.util.List;
import java.util.Optional;

/* JADX INFO: loaded from: classes3.dex */
final class AutoValue_HolisticLandmarkerResult extends HolisticLandmarkerResult {
    private final Optional<List<Category>> faceBlendshapes;
    private final List<NormalizedLandmark> faceLandmarks;
    private final List<NormalizedLandmark> leftHandLandmarks;
    private final List<Landmark> leftHandWorldLandmarks;
    private final List<NormalizedLandmark> poseLandmarks;
    private final List<Landmark> poseWorldLandmarks;
    private final List<NormalizedLandmark> rightHandLandmarks;
    private final List<Landmark> rightHandWorldLandmarks;
    private final Optional<MPImage> segmentationMask;
    private final long timestampMs;

    AutoValue_HolisticLandmarkerResult(long j, List<NormalizedLandmark> list, Optional<List<Category>> optional, List<NormalizedLandmark> list2, List<Landmark> list3, Optional<MPImage> optional2, List<NormalizedLandmark> list4, List<Landmark> list5, List<NormalizedLandmark> list6, List<Landmark> list7) {
        this.timestampMs = j;
        if (list == null) {
            throw new NullPointerException("Null faceLandmarks");
        }
        this.faceLandmarks = list;
        if (optional == null) {
            throw new NullPointerException("Null faceBlendshapes");
        }
        this.faceBlendshapes = optional;
        if (list2 == null) {
            throw new NullPointerException("Null poseLandmarks");
        }
        this.poseLandmarks = list2;
        if (list3 == null) {
            throw new NullPointerException("Null poseWorldLandmarks");
        }
        this.poseWorldLandmarks = list3;
        if (optional2 == null) {
            throw new NullPointerException("Null segmentationMask");
        }
        this.segmentationMask = optional2;
        if (list4 == null) {
            throw new NullPointerException("Null leftHandLandmarks");
        }
        this.leftHandLandmarks = list4;
        if (list5 == null) {
            throw new NullPointerException("Null leftHandWorldLandmarks");
        }
        this.leftHandWorldLandmarks = list5;
        if (list6 == null) {
            throw new NullPointerException("Null rightHandLandmarks");
        }
        this.rightHandLandmarks = list6;
        if (list7 == null) {
            throw new NullPointerException("Null rightHandWorldLandmarks");
        }
        this.rightHandWorldLandmarks = list7;
    }

    @Override // com.google.mediapipe.tasks.vision.holisticlandmarker.HolisticLandmarkerResult, com.google.mediapipe.tasks.core.TaskResult
    public long timestampMs() {
        return this.timestampMs;
    }

    @Override // com.google.mediapipe.tasks.vision.holisticlandmarker.HolisticLandmarkerResult
    public List<NormalizedLandmark> faceLandmarks() {
        return this.faceLandmarks;
    }

    @Override // com.google.mediapipe.tasks.vision.holisticlandmarker.HolisticLandmarkerResult
    public Optional<List<Category>> faceBlendshapes() {
        return this.faceBlendshapes;
    }

    @Override // com.google.mediapipe.tasks.vision.holisticlandmarker.HolisticLandmarkerResult
    public List<NormalizedLandmark> poseLandmarks() {
        return this.poseLandmarks;
    }

    @Override // com.google.mediapipe.tasks.vision.holisticlandmarker.HolisticLandmarkerResult
    public List<Landmark> poseWorldLandmarks() {
        return this.poseWorldLandmarks;
    }

    @Override // com.google.mediapipe.tasks.vision.holisticlandmarker.HolisticLandmarkerResult
    public Optional<MPImage> segmentationMask() {
        return this.segmentationMask;
    }

    @Override // com.google.mediapipe.tasks.vision.holisticlandmarker.HolisticLandmarkerResult
    public List<NormalizedLandmark> leftHandLandmarks() {
        return this.leftHandLandmarks;
    }

    @Override // com.google.mediapipe.tasks.vision.holisticlandmarker.HolisticLandmarkerResult
    public List<Landmark> leftHandWorldLandmarks() {
        return this.leftHandWorldLandmarks;
    }

    @Override // com.google.mediapipe.tasks.vision.holisticlandmarker.HolisticLandmarkerResult
    public List<NormalizedLandmark> rightHandLandmarks() {
        return this.rightHandLandmarks;
    }

    @Override // com.google.mediapipe.tasks.vision.holisticlandmarker.HolisticLandmarkerResult
    public List<Landmark> rightHandWorldLandmarks() {
        return this.rightHandWorldLandmarks;
    }

    public String toString() {
        return "HolisticLandmarkerResult{timestampMs=" + this.timestampMs + ", faceLandmarks=" + this.faceLandmarks + ", faceBlendshapes=" + this.faceBlendshapes + ", poseLandmarks=" + this.poseLandmarks + ", poseWorldLandmarks=" + this.poseWorldLandmarks + ", segmentationMask=" + this.segmentationMask + ", leftHandLandmarks=" + this.leftHandLandmarks + ", leftHandWorldLandmarks=" + this.leftHandWorldLandmarks + ", rightHandLandmarks=" + this.rightHandLandmarks + ", rightHandWorldLandmarks=" + this.rightHandWorldLandmarks + "}";
    }

    public boolean equals(Object obj) {
        if (obj == this) {
            return true;
        }
        if (obj instanceof HolisticLandmarkerResult) {
            HolisticLandmarkerResult holisticLandmarkerResult = (HolisticLandmarkerResult) obj;
            if (this.timestampMs == holisticLandmarkerResult.timestampMs() && this.faceLandmarks.equals(holisticLandmarkerResult.faceLandmarks()) && this.faceBlendshapes.equals(holisticLandmarkerResult.faceBlendshapes()) && this.poseLandmarks.equals(holisticLandmarkerResult.poseLandmarks()) && this.poseWorldLandmarks.equals(holisticLandmarkerResult.poseWorldLandmarks()) && this.segmentationMask.equals(holisticLandmarkerResult.segmentationMask()) && this.leftHandLandmarks.equals(holisticLandmarkerResult.leftHandLandmarks()) && this.leftHandWorldLandmarks.equals(holisticLandmarkerResult.leftHandWorldLandmarks()) && this.rightHandLandmarks.equals(holisticLandmarkerResult.rightHandLandmarks()) && this.rightHandWorldLandmarks.equals(holisticLandmarkerResult.rightHandWorldLandmarks())) {
                return true;
            }
        }
        return false;
    }

    public int hashCode() {
        long j = this.timestampMs;
        return ((((((((((((((((((((int) (j ^ (j >>> 32))) ^ 1000003) * 1000003) ^ this.faceLandmarks.hashCode()) * 1000003) ^ this.faceBlendshapes.hashCode()) * 1000003) ^ this.poseLandmarks.hashCode()) * 1000003) ^ this.poseWorldLandmarks.hashCode()) * 1000003) ^ this.segmentationMask.hashCode()) * 1000003) ^ this.leftHandLandmarks.hashCode()) * 1000003) ^ this.leftHandWorldLandmarks.hashCode()) * 1000003) ^ this.rightHandLandmarks.hashCode()) * 1000003) ^ this.rightHandWorldLandmarks.hashCode();
    }
}
