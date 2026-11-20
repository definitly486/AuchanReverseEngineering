package com.google.mediapipe.tasks.vision.imageembedder;

import com.google.mediapipe.framework.image.MPImage;
import com.google.mediapipe.tasks.core.BaseOptions;
import com.google.mediapipe.tasks.core.ErrorListener;
import com.google.mediapipe.tasks.core.OutputHandler;
import com.google.mediapipe.tasks.vision.core.RunningMode;
import java.util.Optional;

/* JADX INFO: loaded from: classes3.dex */
final class AutoValue_ImageEmbedder_ImageEmbedderOptions extends ImageEmbedder.ImageEmbedderOptions {
    private final BaseOptions baseOptions;
    private final Optional<ErrorListener> errorListener;
    private final boolean l2Normalize;
    private final boolean quantize;
    private final Optional<OutputHandler.ResultListener<ImageEmbedderResult, MPImage>> resultListener;
    private final RunningMode runningMode;

    private AutoValue_ImageEmbedder_ImageEmbedderOptions(BaseOptions baseOptions, RunningMode runningMode, boolean z, boolean z2, Optional<OutputHandler.ResultListener<ImageEmbedderResult, MPImage>> optional, Optional<ErrorListener> optional2) {
        this.baseOptions = baseOptions;
        this.runningMode = runningMode;
        this.l2Normalize = z;
        this.quantize = z2;
        this.resultListener = optional;
        this.errorListener = optional2;
    }

    @Override // com.google.mediapipe.tasks.vision.imageembedder.ImageEmbedder.ImageEmbedderOptions
    BaseOptions baseOptions() {
        return this.baseOptions;
    }

    @Override // com.google.mediapipe.tasks.vision.imageembedder.ImageEmbedder.ImageEmbedderOptions
    RunningMode runningMode() {
        return this.runningMode;
    }

    @Override // com.google.mediapipe.tasks.vision.imageembedder.ImageEmbedder.ImageEmbedderOptions
    boolean l2Normalize() {
        return this.l2Normalize;
    }

    @Override // com.google.mediapipe.tasks.vision.imageembedder.ImageEmbedder.ImageEmbedderOptions
    boolean quantize() {
        return this.quantize;
    }

    @Override // com.google.mediapipe.tasks.vision.imageembedder.ImageEmbedder.ImageEmbedderOptions
    Optional<OutputHandler.ResultListener<ImageEmbedderResult, MPImage>> resultListener() {
        return this.resultListener;
    }

    @Override // com.google.mediapipe.tasks.vision.imageembedder.ImageEmbedder.ImageEmbedderOptions
    Optional<ErrorListener> errorListener() {
        return this.errorListener;
    }

    public String toString() {
        return "ImageEmbedderOptions{baseOptions=" + this.baseOptions + ", runningMode=" + this.runningMode + ", l2Normalize=" + this.l2Normalize + ", quantize=" + this.quantize + ", resultListener=" + this.resultListener + ", errorListener=" + this.errorListener + "}";
    }

    public boolean equals(Object obj) {
        if (obj == this) {
            return true;
        }
        if (obj instanceof ImageEmbedder.ImageEmbedderOptions) {
            ImageEmbedder.ImageEmbedderOptions imageEmbedderOptions = (ImageEmbedder.ImageEmbedderOptions) obj;
            if (this.baseOptions.equals(imageEmbedderOptions.baseOptions()) && this.runningMode.equals(imageEmbedderOptions.runningMode()) && this.l2Normalize == imageEmbedderOptions.l2Normalize() && this.quantize == imageEmbedderOptions.quantize() && this.resultListener.equals(imageEmbedderOptions.resultListener()) && this.errorListener.equals(imageEmbedderOptions.errorListener())) {
                return true;
            }
        }
        return false;
    }

    public int hashCode() {
        return ((((((((((this.baseOptions.hashCode() ^ 1000003) * 1000003) ^ this.runningMode.hashCode()) * 1000003) ^ (this.l2Normalize ? 1231 : 1237)) * 1000003) ^ (this.quantize ? 1231 : 1237)) * 1000003) ^ this.resultListener.hashCode()) * 1000003) ^ this.errorListener.hashCode();
    }

    static final class Builder extends ImageEmbedder.ImageEmbedderOptions.Builder {
        private BaseOptions baseOptions;
        private Boolean l2Normalize;
        private Boolean quantize;
        private RunningMode runningMode;
        private Optional<OutputHandler.ResultListener<ImageEmbedderResult, MPImage>> resultListener = Optional.empty();
        private Optional<ErrorListener> errorListener = Optional.empty();

        Builder() {
        }

        @Override // com.google.mediapipe.tasks.vision.imageembedder.ImageEmbedder.ImageEmbedderOptions.Builder
        public ImageEmbedder.ImageEmbedderOptions.Builder setBaseOptions(BaseOptions baseOptions) {
            if (baseOptions == null) {
                throw new NullPointerException("Null baseOptions");
            }
            this.baseOptions = baseOptions;
            return this;
        }

        @Override // com.google.mediapipe.tasks.vision.imageembedder.ImageEmbedder.ImageEmbedderOptions.Builder
        public ImageEmbedder.ImageEmbedderOptions.Builder setRunningMode(RunningMode runningMode) {
            if (runningMode == null) {
                throw new NullPointerException("Null runningMode");
            }
            this.runningMode = runningMode;
            return this;
        }

        @Override // com.google.mediapipe.tasks.vision.imageembedder.ImageEmbedder.ImageEmbedderOptions.Builder
        public ImageEmbedder.ImageEmbedderOptions.Builder setL2Normalize(boolean z) {
            this.l2Normalize = Boolean.valueOf(z);
            return this;
        }

        @Override // com.google.mediapipe.tasks.vision.imageembedder.ImageEmbedder.ImageEmbedderOptions.Builder
        public ImageEmbedder.ImageEmbedderOptions.Builder setQuantize(boolean z) {
            this.quantize = Boolean.valueOf(z);
            return this;
        }

        @Override // com.google.mediapipe.tasks.vision.imageembedder.ImageEmbedder.ImageEmbedderOptions.Builder
        public ImageEmbedder.ImageEmbedderOptions.Builder setResultListener(OutputHandler.ResultListener<ImageEmbedderResult, MPImage> resultListener) {
            this.resultListener = Optional.of(resultListener);
            return this;
        }

        @Override // com.google.mediapipe.tasks.vision.imageembedder.ImageEmbedder.ImageEmbedderOptions.Builder
        public ImageEmbedder.ImageEmbedderOptions.Builder setErrorListener(ErrorListener errorListener) {
            this.errorListener = Optional.of(errorListener);
            return this;
        }

        @Override // com.google.mediapipe.tasks.vision.imageembedder.ImageEmbedder.ImageEmbedderOptions.Builder
        ImageEmbedder.ImageEmbedderOptions autoBuild() {
            String str = "";
            if (this.baseOptions == null) {
                str = " baseOptions";
            }
            if (this.runningMode == null) {
                str = str + " runningMode";
            }
            if (this.l2Normalize == null) {
                str = str + " l2Normalize";
            }
            if (this.quantize == null) {
                str = str + " quantize";
            }
            if (!str.isEmpty()) {
                throw new IllegalStateException("Missing required properties:" + str);
            }
            return new AutoValue_ImageEmbedder_ImageEmbedderOptions(this.baseOptions, this.runningMode, this.l2Normalize.booleanValue(), this.quantize.booleanValue(), this.resultListener, this.errorListener);
        }
    }
}
