package com.google.mediapipe.tasks.vision.poselandmarker;

import com.google.mediapipe.framework.image.MPImage;
import com.google.mediapipe.tasks.core.BaseOptions;
import com.google.mediapipe.tasks.core.ErrorListener;
import com.google.mediapipe.tasks.core.OutputHandler;
import com.google.mediapipe.tasks.vision.core.RunningMode;
import java.util.Optional;

/* JADX INFO: loaded from: classes3.dex */
final class AutoValue_PoseLandmarker_PoseLandmarkerOptions extends PoseLandmarker.PoseLandmarkerOptions {
    private final BaseOptions baseOptions;
    private final Optional<ErrorListener> errorListener;
    private final Optional<Float> minPoseDetectionConfidence;
    private final Optional<Float> minPosePresenceConfidence;
    private final Optional<Float> minTrackingConfidence;
    private final Optional<Integer> numPoses;
    private final boolean outputSegmentationMasks;
    private final Optional<OutputHandler.ResultListener<PoseLandmarkerResult, MPImage>> resultListener;
    private final RunningMode runningMode;

    private AutoValue_PoseLandmarker_PoseLandmarkerOptions(BaseOptions baseOptions, RunningMode runningMode, Optional<Integer> optional, Optional<Float> optional2, Optional<Float> optional3, Optional<Float> optional4, boolean z, Optional<OutputHandler.ResultListener<PoseLandmarkerResult, MPImage>> optional5, Optional<ErrorListener> optional6) {
        this.baseOptions = baseOptions;
        this.runningMode = runningMode;
        this.numPoses = optional;
        this.minPoseDetectionConfidence = optional2;
        this.minPosePresenceConfidence = optional3;
        this.minTrackingConfidence = optional4;
        this.outputSegmentationMasks = z;
        this.resultListener = optional5;
        this.errorListener = optional6;
    }

    @Override // com.google.mediapipe.tasks.vision.poselandmarker.PoseLandmarker.PoseLandmarkerOptions
    BaseOptions baseOptions() {
        return this.baseOptions;
    }

    @Override // com.google.mediapipe.tasks.vision.poselandmarker.PoseLandmarker.PoseLandmarkerOptions
    RunningMode runningMode() {
        return this.runningMode;
    }

    @Override // com.google.mediapipe.tasks.vision.poselandmarker.PoseLandmarker.PoseLandmarkerOptions
    Optional<Integer> numPoses() {
        return this.numPoses;
    }

    @Override // com.google.mediapipe.tasks.vision.poselandmarker.PoseLandmarker.PoseLandmarkerOptions
    Optional<Float> minPoseDetectionConfidence() {
        return this.minPoseDetectionConfidence;
    }

    @Override // com.google.mediapipe.tasks.vision.poselandmarker.PoseLandmarker.PoseLandmarkerOptions
    Optional<Float> minPosePresenceConfidence() {
        return this.minPosePresenceConfidence;
    }

    @Override // com.google.mediapipe.tasks.vision.poselandmarker.PoseLandmarker.PoseLandmarkerOptions
    Optional<Float> minTrackingConfidence() {
        return this.minTrackingConfidence;
    }

    @Override // com.google.mediapipe.tasks.vision.poselandmarker.PoseLandmarker.PoseLandmarkerOptions
    boolean outputSegmentationMasks() {
        return this.outputSegmentationMasks;
    }

    @Override // com.google.mediapipe.tasks.vision.poselandmarker.PoseLandmarker.PoseLandmarkerOptions
    Optional<OutputHandler.ResultListener<PoseLandmarkerResult, MPImage>> resultListener() {
        return this.resultListener;
    }

    @Override // com.google.mediapipe.tasks.vision.poselandmarker.PoseLandmarker.PoseLandmarkerOptions
    Optional<ErrorListener> errorListener() {
        return this.errorListener;
    }

    public String toString() {
        return "PoseLandmarkerOptions{baseOptions=" + this.baseOptions + ", runningMode=" + this.runningMode + ", numPoses=" + this.numPoses + ", minPoseDetectionConfidence=" + this.minPoseDetectionConfidence + ", minPosePresenceConfidence=" + this.minPosePresenceConfidence + ", minTrackingConfidence=" + this.minTrackingConfidence + ", outputSegmentationMasks=" + this.outputSegmentationMasks + ", resultListener=" + this.resultListener + ", errorListener=" + this.errorListener + "}";
    }

    public boolean equals(Object obj) {
        if (obj == this) {
            return true;
        }
        if (obj instanceof PoseLandmarker.PoseLandmarkerOptions) {
            PoseLandmarker.PoseLandmarkerOptions poseLandmarkerOptions = (PoseLandmarker.PoseLandmarkerOptions) obj;
            if (this.baseOptions.equals(poseLandmarkerOptions.baseOptions()) && this.runningMode.equals(poseLandmarkerOptions.runningMode()) && this.numPoses.equals(poseLandmarkerOptions.numPoses()) && this.minPoseDetectionConfidence.equals(poseLandmarkerOptions.minPoseDetectionConfidence()) && this.minPosePresenceConfidence.equals(poseLandmarkerOptions.minPosePresenceConfidence()) && this.minTrackingConfidence.equals(poseLandmarkerOptions.minTrackingConfidence()) && this.outputSegmentationMasks == poseLandmarkerOptions.outputSegmentationMasks() && this.resultListener.equals(poseLandmarkerOptions.resultListener()) && this.errorListener.equals(poseLandmarkerOptions.errorListener())) {
                return true;
            }
        }
        return false;
    }

    public int hashCode() {
        return ((((((((((((((((this.baseOptions.hashCode() ^ 1000003) * 1000003) ^ this.runningMode.hashCode()) * 1000003) ^ this.numPoses.hashCode()) * 1000003) ^ this.minPoseDetectionConfidence.hashCode()) * 1000003) ^ this.minPosePresenceConfidence.hashCode()) * 1000003) ^ this.minTrackingConfidence.hashCode()) * 1000003) ^ (this.outputSegmentationMasks ? 1231 : 1237)) * 1000003) ^ this.resultListener.hashCode()) * 1000003) ^ this.errorListener.hashCode();
    }

    static final class Builder extends PoseLandmarker.PoseLandmarkerOptions.Builder {
        private BaseOptions baseOptions;
        private Boolean outputSegmentationMasks;
        private RunningMode runningMode;
        private Optional<Integer> numPoses = Optional.empty();
        private Optional<Float> minPoseDetectionConfidence = Optional.empty();
        private Optional<Float> minPosePresenceConfidence = Optional.empty();
        private Optional<Float> minTrackingConfidence = Optional.empty();
        private Optional<OutputHandler.ResultListener<PoseLandmarkerResult, MPImage>> resultListener = Optional.empty();
        private Optional<ErrorListener> errorListener = Optional.empty();

        Builder() {
        }

        @Override // com.google.mediapipe.tasks.vision.poselandmarker.PoseLandmarker.PoseLandmarkerOptions.Builder
        public PoseLandmarker.PoseLandmarkerOptions.Builder setBaseOptions(BaseOptions baseOptions) {
            if (baseOptions == null) {
                throw new NullPointerException("Null baseOptions");
            }
            this.baseOptions = baseOptions;
            return this;
        }

        @Override // com.google.mediapipe.tasks.vision.poselandmarker.PoseLandmarker.PoseLandmarkerOptions.Builder
        public PoseLandmarker.PoseLandmarkerOptions.Builder setRunningMode(RunningMode runningMode) {
            if (runningMode == null) {
                throw new NullPointerException("Null runningMode");
            }
            this.runningMode = runningMode;
            return this;
        }

        @Override // com.google.mediapipe.tasks.vision.poselandmarker.PoseLandmarker.PoseLandmarkerOptions.Builder
        public PoseLandmarker.PoseLandmarkerOptions.Builder setNumPoses(Integer num) {
            this.numPoses = Optional.of(num);
            return this;
        }

        @Override // com.google.mediapipe.tasks.vision.poselandmarker.PoseLandmarker.PoseLandmarkerOptions.Builder
        public PoseLandmarker.PoseLandmarkerOptions.Builder setMinPoseDetectionConfidence(Float f) {
            this.minPoseDetectionConfidence = Optional.of(f);
            return this;
        }

        @Override // com.google.mediapipe.tasks.vision.poselandmarker.PoseLandmarker.PoseLandmarkerOptions.Builder
        public PoseLandmarker.PoseLandmarkerOptions.Builder setMinPosePresenceConfidence(Float f) {
            this.minPosePresenceConfidence = Optional.of(f);
            return this;
        }

        @Override // com.google.mediapipe.tasks.vision.poselandmarker.PoseLandmarker.PoseLandmarkerOptions.Builder
        public PoseLandmarker.PoseLandmarkerOptions.Builder setMinTrackingConfidence(Float f) {
            this.minTrackingConfidence = Optional.of(f);
            return this;
        }

        @Override // com.google.mediapipe.tasks.vision.poselandmarker.PoseLandmarker.PoseLandmarkerOptions.Builder
        public PoseLandmarker.PoseLandmarkerOptions.Builder setOutputSegmentationMasks(boolean z) {
            this.outputSegmentationMasks = Boolean.valueOf(z);
            return this;
        }

        @Override // com.google.mediapipe.tasks.vision.poselandmarker.PoseLandmarker.PoseLandmarkerOptions.Builder
        public PoseLandmarker.PoseLandmarkerOptions.Builder setResultListener(OutputHandler.ResultListener<PoseLandmarkerResult, MPImage> resultListener) {
            this.resultListener = Optional.of(resultListener);
            return this;
        }

        @Override // com.google.mediapipe.tasks.vision.poselandmarker.PoseLandmarker.PoseLandmarkerOptions.Builder
        public PoseLandmarker.PoseLandmarkerOptions.Builder setErrorListener(ErrorListener errorListener) {
            this.errorListener = Optional.of(errorListener);
            return this;
        }

        @Override // com.google.mediapipe.tasks.vision.poselandmarker.PoseLandmarker.PoseLandmarkerOptions.Builder
        PoseLandmarker.PoseLandmarkerOptions autoBuild() {
            String str = "";
            if (this.baseOptions == null) {
                str = " baseOptions";
            }
            if (this.runningMode == null) {
                str = str + " runningMode";
            }
            if (this.outputSegmentationMasks == null) {
                str = str + " outputSegmentationMasks";
            }
            if (!str.isEmpty()) {
                throw new IllegalStateException("Missing required properties:" + str);
            }
            return new AutoValue_PoseLandmarker_PoseLandmarkerOptions(this.baseOptions, this.runningMode, this.numPoses, this.minPoseDetectionConfidence, this.minPosePresenceConfidence, this.minTrackingConfidence, this.outputSegmentationMasks.booleanValue(), this.resultListener, this.errorListener);
        }
    }
}
