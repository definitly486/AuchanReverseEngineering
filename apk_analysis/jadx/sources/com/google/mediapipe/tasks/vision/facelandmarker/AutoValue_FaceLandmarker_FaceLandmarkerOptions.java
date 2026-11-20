package com.google.mediapipe.tasks.vision.facelandmarker;

import com.google.mediapipe.framework.image.MPImage;
import com.google.mediapipe.tasks.core.BaseOptions;
import com.google.mediapipe.tasks.core.ErrorListener;
import com.google.mediapipe.tasks.core.OutputHandler;
import com.google.mediapipe.tasks.vision.core.RunningMode;
import java.util.Optional;

/* JADX INFO: loaded from: classes3.dex */
final class AutoValue_FaceLandmarker_FaceLandmarkerOptions extends FaceLandmarker.FaceLandmarkerOptions {
    private final BaseOptions baseOptions;
    private final Optional<ErrorListener> errorListener;
    private final Optional<Float> minFaceDetectionConfidence;
    private final Optional<Float> minFacePresenceConfidence;
    private final Optional<Float> minTrackingConfidence;
    private final Optional<Integer> numFaces;
    private final boolean outputFaceBlendshapes;
    private final boolean outputFacialTransformationMatrixes;
    private final Optional<OutputHandler.ResultListener<FaceLandmarkerResult, MPImage>> resultListener;
    private final RunningMode runningMode;

    private AutoValue_FaceLandmarker_FaceLandmarkerOptions(BaseOptions baseOptions, RunningMode runningMode, Optional<Integer> optional, Optional<Float> optional2, Optional<Float> optional3, Optional<Float> optional4, boolean z, boolean z2, Optional<OutputHandler.ResultListener<FaceLandmarkerResult, MPImage>> optional5, Optional<ErrorListener> optional6) {
        this.baseOptions = baseOptions;
        this.runningMode = runningMode;
        this.numFaces = optional;
        this.minFaceDetectionConfidence = optional2;
        this.minFacePresenceConfidence = optional3;
        this.minTrackingConfidence = optional4;
        this.outputFaceBlendshapes = z;
        this.outputFacialTransformationMatrixes = z2;
        this.resultListener = optional5;
        this.errorListener = optional6;
    }

    @Override // com.google.mediapipe.tasks.vision.facelandmarker.FaceLandmarker.FaceLandmarkerOptions
    BaseOptions baseOptions() {
        return this.baseOptions;
    }

    @Override // com.google.mediapipe.tasks.vision.facelandmarker.FaceLandmarker.FaceLandmarkerOptions
    RunningMode runningMode() {
        return this.runningMode;
    }

    @Override // com.google.mediapipe.tasks.vision.facelandmarker.FaceLandmarker.FaceLandmarkerOptions
    Optional<Integer> numFaces() {
        return this.numFaces;
    }

    @Override // com.google.mediapipe.tasks.vision.facelandmarker.FaceLandmarker.FaceLandmarkerOptions
    Optional<Float> minFaceDetectionConfidence() {
        return this.minFaceDetectionConfidence;
    }

    @Override // com.google.mediapipe.tasks.vision.facelandmarker.FaceLandmarker.FaceLandmarkerOptions
    Optional<Float> minFacePresenceConfidence() {
        return this.minFacePresenceConfidence;
    }

    @Override // com.google.mediapipe.tasks.vision.facelandmarker.FaceLandmarker.FaceLandmarkerOptions
    Optional<Float> minTrackingConfidence() {
        return this.minTrackingConfidence;
    }

    @Override // com.google.mediapipe.tasks.vision.facelandmarker.FaceLandmarker.FaceLandmarkerOptions
    boolean outputFaceBlendshapes() {
        return this.outputFaceBlendshapes;
    }

    @Override // com.google.mediapipe.tasks.vision.facelandmarker.FaceLandmarker.FaceLandmarkerOptions
    boolean outputFacialTransformationMatrixes() {
        return this.outputFacialTransformationMatrixes;
    }

    @Override // com.google.mediapipe.tasks.vision.facelandmarker.FaceLandmarker.FaceLandmarkerOptions
    Optional<OutputHandler.ResultListener<FaceLandmarkerResult, MPImage>> resultListener() {
        return this.resultListener;
    }

    @Override // com.google.mediapipe.tasks.vision.facelandmarker.FaceLandmarker.FaceLandmarkerOptions
    Optional<ErrorListener> errorListener() {
        return this.errorListener;
    }

    public String toString() {
        return "FaceLandmarkerOptions{baseOptions=" + this.baseOptions + ", runningMode=" + this.runningMode + ", numFaces=" + this.numFaces + ", minFaceDetectionConfidence=" + this.minFaceDetectionConfidence + ", minFacePresenceConfidence=" + this.minFacePresenceConfidence + ", minTrackingConfidence=" + this.minTrackingConfidence + ", outputFaceBlendshapes=" + this.outputFaceBlendshapes + ", outputFacialTransformationMatrixes=" + this.outputFacialTransformationMatrixes + ", resultListener=" + this.resultListener + ", errorListener=" + this.errorListener + "}";
    }

    public boolean equals(Object obj) {
        if (obj == this) {
            return true;
        }
        if (obj instanceof FaceLandmarker.FaceLandmarkerOptions) {
            FaceLandmarker.FaceLandmarkerOptions faceLandmarkerOptions = (FaceLandmarker.FaceLandmarkerOptions) obj;
            if (this.baseOptions.equals(faceLandmarkerOptions.baseOptions()) && this.runningMode.equals(faceLandmarkerOptions.runningMode()) && this.numFaces.equals(faceLandmarkerOptions.numFaces()) && this.minFaceDetectionConfidence.equals(faceLandmarkerOptions.minFaceDetectionConfidence()) && this.minFacePresenceConfidence.equals(faceLandmarkerOptions.minFacePresenceConfidence()) && this.minTrackingConfidence.equals(faceLandmarkerOptions.minTrackingConfidence()) && this.outputFaceBlendshapes == faceLandmarkerOptions.outputFaceBlendshapes() && this.outputFacialTransformationMatrixes == faceLandmarkerOptions.outputFacialTransformationMatrixes() && this.resultListener.equals(faceLandmarkerOptions.resultListener()) && this.errorListener.equals(faceLandmarkerOptions.errorListener())) {
                return true;
            }
        }
        return false;
    }

    public int hashCode() {
        return ((((((((((((((((((this.baseOptions.hashCode() ^ 1000003) * 1000003) ^ this.runningMode.hashCode()) * 1000003) ^ this.numFaces.hashCode()) * 1000003) ^ this.minFaceDetectionConfidence.hashCode()) * 1000003) ^ this.minFacePresenceConfidence.hashCode()) * 1000003) ^ this.minTrackingConfidence.hashCode()) * 1000003) ^ (this.outputFaceBlendshapes ? 1231 : 1237)) * 1000003) ^ (this.outputFacialTransformationMatrixes ? 1231 : 1237)) * 1000003) ^ this.resultListener.hashCode()) * 1000003) ^ this.errorListener.hashCode();
    }

    static final class Builder extends FaceLandmarker.FaceLandmarkerOptions.Builder {
        private BaseOptions baseOptions;
        private Boolean outputFaceBlendshapes;
        private Boolean outputFacialTransformationMatrixes;
        private RunningMode runningMode;
        private Optional<Integer> numFaces = Optional.empty();
        private Optional<Float> minFaceDetectionConfidence = Optional.empty();
        private Optional<Float> minFacePresenceConfidence = Optional.empty();
        private Optional<Float> minTrackingConfidence = Optional.empty();
        private Optional<OutputHandler.ResultListener<FaceLandmarkerResult, MPImage>> resultListener = Optional.empty();
        private Optional<ErrorListener> errorListener = Optional.empty();

        Builder() {
        }

        @Override // com.google.mediapipe.tasks.vision.facelandmarker.FaceLandmarker.FaceLandmarkerOptions.Builder
        public FaceLandmarker.FaceLandmarkerOptions.Builder setBaseOptions(BaseOptions baseOptions) {
            if (baseOptions == null) {
                throw new NullPointerException("Null baseOptions");
            }
            this.baseOptions = baseOptions;
            return this;
        }

        @Override // com.google.mediapipe.tasks.vision.facelandmarker.FaceLandmarker.FaceLandmarkerOptions.Builder
        public FaceLandmarker.FaceLandmarkerOptions.Builder setRunningMode(RunningMode runningMode) {
            if (runningMode == null) {
                throw new NullPointerException("Null runningMode");
            }
            this.runningMode = runningMode;
            return this;
        }

        @Override // com.google.mediapipe.tasks.vision.facelandmarker.FaceLandmarker.FaceLandmarkerOptions.Builder
        public FaceLandmarker.FaceLandmarkerOptions.Builder setNumFaces(Integer num) {
            this.numFaces = Optional.of(num);
            return this;
        }

        @Override // com.google.mediapipe.tasks.vision.facelandmarker.FaceLandmarker.FaceLandmarkerOptions.Builder
        public FaceLandmarker.FaceLandmarkerOptions.Builder setMinFaceDetectionConfidence(Float f) {
            this.minFaceDetectionConfidence = Optional.of(f);
            return this;
        }

        @Override // com.google.mediapipe.tasks.vision.facelandmarker.FaceLandmarker.FaceLandmarkerOptions.Builder
        public FaceLandmarker.FaceLandmarkerOptions.Builder setMinFacePresenceConfidence(Float f) {
            this.minFacePresenceConfidence = Optional.of(f);
            return this;
        }

        @Override // com.google.mediapipe.tasks.vision.facelandmarker.FaceLandmarker.FaceLandmarkerOptions.Builder
        public FaceLandmarker.FaceLandmarkerOptions.Builder setMinTrackingConfidence(Float f) {
            this.minTrackingConfidence = Optional.of(f);
            return this;
        }

        @Override // com.google.mediapipe.tasks.vision.facelandmarker.FaceLandmarker.FaceLandmarkerOptions.Builder
        public FaceLandmarker.FaceLandmarkerOptions.Builder setOutputFaceBlendshapes(boolean z) {
            this.outputFaceBlendshapes = Boolean.valueOf(z);
            return this;
        }

        @Override // com.google.mediapipe.tasks.vision.facelandmarker.FaceLandmarker.FaceLandmarkerOptions.Builder
        public FaceLandmarker.FaceLandmarkerOptions.Builder setOutputFacialTransformationMatrixes(boolean z) {
            this.outputFacialTransformationMatrixes = Boolean.valueOf(z);
            return this;
        }

        @Override // com.google.mediapipe.tasks.vision.facelandmarker.FaceLandmarker.FaceLandmarkerOptions.Builder
        public FaceLandmarker.FaceLandmarkerOptions.Builder setResultListener(OutputHandler.ResultListener<FaceLandmarkerResult, MPImage> resultListener) {
            this.resultListener = Optional.of(resultListener);
            return this;
        }

        @Override // com.google.mediapipe.tasks.vision.facelandmarker.FaceLandmarker.FaceLandmarkerOptions.Builder
        public FaceLandmarker.FaceLandmarkerOptions.Builder setErrorListener(ErrorListener errorListener) {
            this.errorListener = Optional.of(errorListener);
            return this;
        }

        @Override // com.google.mediapipe.tasks.vision.facelandmarker.FaceLandmarker.FaceLandmarkerOptions.Builder
        FaceLandmarker.FaceLandmarkerOptions autoBuild() {
            String str = "";
            if (this.baseOptions == null) {
                str = " baseOptions";
            }
            if (this.runningMode == null) {
                str = str + " runningMode";
            }
            if (this.outputFaceBlendshapes == null) {
                str = str + " outputFaceBlendshapes";
            }
            if (this.outputFacialTransformationMatrixes == null) {
                str = str + " outputFacialTransformationMatrixes";
            }
            if (!str.isEmpty()) {
                throw new IllegalStateException("Missing required properties:" + str);
            }
            return new AutoValue_FaceLandmarker_FaceLandmarkerOptions(this.baseOptions, this.runningMode, this.numFaces, this.minFaceDetectionConfidence, this.minFacePresenceConfidence, this.minTrackingConfidence, this.outputFaceBlendshapes.booleanValue(), this.outputFacialTransformationMatrixes.booleanValue(), this.resultListener, this.errorListener);
        }
    }
}
