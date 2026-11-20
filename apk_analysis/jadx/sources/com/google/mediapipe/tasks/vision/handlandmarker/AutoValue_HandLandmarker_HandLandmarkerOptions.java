package com.google.mediapipe.tasks.vision.handlandmarker;

import com.google.mediapipe.framework.image.MPImage;
import com.google.mediapipe.tasks.core.BaseOptions;
import com.google.mediapipe.tasks.core.ErrorListener;
import com.google.mediapipe.tasks.core.OutputHandler;
import com.google.mediapipe.tasks.vision.core.RunningMode;
import java.util.Optional;

/* JADX INFO: loaded from: classes3.dex */
final class AutoValue_HandLandmarker_HandLandmarkerOptions extends HandLandmarker.HandLandmarkerOptions {
    private final BaseOptions baseOptions;
    private final Optional<ErrorListener> errorListener;
    private final Optional<Float> minHandDetectionConfidence;
    private final Optional<Float> minHandPresenceConfidence;
    private final Optional<Float> minTrackingConfidence;
    private final Optional<Integer> numHands;
    private final Optional<OutputHandler.ResultListener<HandLandmarkerResult, MPImage>> resultListener;
    private final RunningMode runningMode;

    private AutoValue_HandLandmarker_HandLandmarkerOptions(BaseOptions baseOptions, RunningMode runningMode, Optional<Integer> optional, Optional<Float> optional2, Optional<Float> optional3, Optional<Float> optional4, Optional<OutputHandler.ResultListener<HandLandmarkerResult, MPImage>> optional5, Optional<ErrorListener> optional6) {
        this.baseOptions = baseOptions;
        this.runningMode = runningMode;
        this.numHands = optional;
        this.minHandDetectionConfidence = optional2;
        this.minHandPresenceConfidence = optional3;
        this.minTrackingConfidence = optional4;
        this.resultListener = optional5;
        this.errorListener = optional6;
    }

    @Override // com.google.mediapipe.tasks.vision.handlandmarker.HandLandmarker.HandLandmarkerOptions
    BaseOptions baseOptions() {
        return this.baseOptions;
    }

    @Override // com.google.mediapipe.tasks.vision.handlandmarker.HandLandmarker.HandLandmarkerOptions
    RunningMode runningMode() {
        return this.runningMode;
    }

    @Override // com.google.mediapipe.tasks.vision.handlandmarker.HandLandmarker.HandLandmarkerOptions
    Optional<Integer> numHands() {
        return this.numHands;
    }

    @Override // com.google.mediapipe.tasks.vision.handlandmarker.HandLandmarker.HandLandmarkerOptions
    Optional<Float> minHandDetectionConfidence() {
        return this.minHandDetectionConfidence;
    }

    @Override // com.google.mediapipe.tasks.vision.handlandmarker.HandLandmarker.HandLandmarkerOptions
    Optional<Float> minHandPresenceConfidence() {
        return this.minHandPresenceConfidence;
    }

    @Override // com.google.mediapipe.tasks.vision.handlandmarker.HandLandmarker.HandLandmarkerOptions
    Optional<Float> minTrackingConfidence() {
        return this.minTrackingConfidence;
    }

    @Override // com.google.mediapipe.tasks.vision.handlandmarker.HandLandmarker.HandLandmarkerOptions
    Optional<OutputHandler.ResultListener<HandLandmarkerResult, MPImage>> resultListener() {
        return this.resultListener;
    }

    @Override // com.google.mediapipe.tasks.vision.handlandmarker.HandLandmarker.HandLandmarkerOptions
    Optional<ErrorListener> errorListener() {
        return this.errorListener;
    }

    public String toString() {
        return "HandLandmarkerOptions{baseOptions=" + this.baseOptions + ", runningMode=" + this.runningMode + ", numHands=" + this.numHands + ", minHandDetectionConfidence=" + this.minHandDetectionConfidence + ", minHandPresenceConfidence=" + this.minHandPresenceConfidence + ", minTrackingConfidence=" + this.minTrackingConfidence + ", resultListener=" + this.resultListener + ", errorListener=" + this.errorListener + "}";
    }

    public boolean equals(Object obj) {
        if (obj == this) {
            return true;
        }
        if (obj instanceof HandLandmarker.HandLandmarkerOptions) {
            HandLandmarker.HandLandmarkerOptions handLandmarkerOptions = (HandLandmarker.HandLandmarkerOptions) obj;
            if (this.baseOptions.equals(handLandmarkerOptions.baseOptions()) && this.runningMode.equals(handLandmarkerOptions.runningMode()) && this.numHands.equals(handLandmarkerOptions.numHands()) && this.minHandDetectionConfidence.equals(handLandmarkerOptions.minHandDetectionConfidence()) && this.minHandPresenceConfidence.equals(handLandmarkerOptions.minHandPresenceConfidence()) && this.minTrackingConfidence.equals(handLandmarkerOptions.minTrackingConfidence()) && this.resultListener.equals(handLandmarkerOptions.resultListener()) && this.errorListener.equals(handLandmarkerOptions.errorListener())) {
                return true;
            }
        }
        return false;
    }

    public int hashCode() {
        return ((((((((((((((this.baseOptions.hashCode() ^ 1000003) * 1000003) ^ this.runningMode.hashCode()) * 1000003) ^ this.numHands.hashCode()) * 1000003) ^ this.minHandDetectionConfidence.hashCode()) * 1000003) ^ this.minHandPresenceConfidence.hashCode()) * 1000003) ^ this.minTrackingConfidence.hashCode()) * 1000003) ^ this.resultListener.hashCode()) * 1000003) ^ this.errorListener.hashCode();
    }

    static final class Builder extends HandLandmarker.HandLandmarkerOptions.Builder {
        private BaseOptions baseOptions;
        private RunningMode runningMode;
        private Optional<Integer> numHands = Optional.empty();
        private Optional<Float> minHandDetectionConfidence = Optional.empty();
        private Optional<Float> minHandPresenceConfidence = Optional.empty();
        private Optional<Float> minTrackingConfidence = Optional.empty();
        private Optional<OutputHandler.ResultListener<HandLandmarkerResult, MPImage>> resultListener = Optional.empty();
        private Optional<ErrorListener> errorListener = Optional.empty();

        Builder() {
        }

        @Override // com.google.mediapipe.tasks.vision.handlandmarker.HandLandmarker.HandLandmarkerOptions.Builder
        public HandLandmarker.HandLandmarkerOptions.Builder setBaseOptions(BaseOptions baseOptions) {
            if (baseOptions == null) {
                throw new NullPointerException("Null baseOptions");
            }
            this.baseOptions = baseOptions;
            return this;
        }

        @Override // com.google.mediapipe.tasks.vision.handlandmarker.HandLandmarker.HandLandmarkerOptions.Builder
        public HandLandmarker.HandLandmarkerOptions.Builder setRunningMode(RunningMode runningMode) {
            if (runningMode == null) {
                throw new NullPointerException("Null runningMode");
            }
            this.runningMode = runningMode;
            return this;
        }

        @Override // com.google.mediapipe.tasks.vision.handlandmarker.HandLandmarker.HandLandmarkerOptions.Builder
        public HandLandmarker.HandLandmarkerOptions.Builder setNumHands(Integer num) {
            this.numHands = Optional.of(num);
            return this;
        }

        @Override // com.google.mediapipe.tasks.vision.handlandmarker.HandLandmarker.HandLandmarkerOptions.Builder
        public HandLandmarker.HandLandmarkerOptions.Builder setMinHandDetectionConfidence(Float f) {
            this.minHandDetectionConfidence = Optional.of(f);
            return this;
        }

        @Override // com.google.mediapipe.tasks.vision.handlandmarker.HandLandmarker.HandLandmarkerOptions.Builder
        public HandLandmarker.HandLandmarkerOptions.Builder setMinHandPresenceConfidence(Float f) {
            this.minHandPresenceConfidence = Optional.of(f);
            return this;
        }

        @Override // com.google.mediapipe.tasks.vision.handlandmarker.HandLandmarker.HandLandmarkerOptions.Builder
        public HandLandmarker.HandLandmarkerOptions.Builder setMinTrackingConfidence(Float f) {
            this.minTrackingConfidence = Optional.of(f);
            return this;
        }

        @Override // com.google.mediapipe.tasks.vision.handlandmarker.HandLandmarker.HandLandmarkerOptions.Builder
        public HandLandmarker.HandLandmarkerOptions.Builder setResultListener(OutputHandler.ResultListener<HandLandmarkerResult, MPImage> resultListener) {
            this.resultListener = Optional.of(resultListener);
            return this;
        }

        @Override // com.google.mediapipe.tasks.vision.handlandmarker.HandLandmarker.HandLandmarkerOptions.Builder
        public HandLandmarker.HandLandmarkerOptions.Builder setErrorListener(ErrorListener errorListener) {
            this.errorListener = Optional.of(errorListener);
            return this;
        }

        @Override // com.google.mediapipe.tasks.vision.handlandmarker.HandLandmarker.HandLandmarkerOptions.Builder
        HandLandmarker.HandLandmarkerOptions autoBuild() {
            String str = "";
            if (this.baseOptions == null) {
                str = " baseOptions";
            }
            if (this.runningMode == null) {
                str = str + " runningMode";
            }
            if (!str.isEmpty()) {
                throw new IllegalStateException("Missing required properties:" + str);
            }
            return new AutoValue_HandLandmarker_HandLandmarkerOptions(this.baseOptions, this.runningMode, this.numHands, this.minHandDetectionConfidence, this.minHandPresenceConfidence, this.minTrackingConfidence, this.resultListener, this.errorListener);
        }
    }
}
