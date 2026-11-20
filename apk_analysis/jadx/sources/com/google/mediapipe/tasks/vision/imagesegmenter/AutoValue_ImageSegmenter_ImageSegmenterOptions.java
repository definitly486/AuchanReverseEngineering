package com.google.mediapipe.tasks.vision.imagesegmenter;

import com.google.mediapipe.framework.image.MPImage;
import com.google.mediapipe.tasks.core.BaseOptions;
import com.google.mediapipe.tasks.core.ErrorListener;
import com.google.mediapipe.tasks.core.OutputHandler;
import com.google.mediapipe.tasks.vision.core.RunningMode;
import java.util.Optional;

/* JADX INFO: loaded from: classes3.dex */
final class AutoValue_ImageSegmenter_ImageSegmenterOptions extends ImageSegmenter.ImageSegmenterOptions {
    private final BaseOptions baseOptions;
    private final String displayNamesLocale;
    private final Optional<ErrorListener> errorListener;
    private final boolean outputCategoryMask;
    private final boolean outputConfidenceMasks;
    private final Optional<OutputHandler.ResultListener<ImageSegmenterResult, MPImage>> resultListener;
    private final RunningMode runningMode;

    private AutoValue_ImageSegmenter_ImageSegmenterOptions(BaseOptions baseOptions, RunningMode runningMode, String str, boolean z, boolean z2, Optional<OutputHandler.ResultListener<ImageSegmenterResult, MPImage>> optional, Optional<ErrorListener> optional2) {
        this.baseOptions = baseOptions;
        this.runningMode = runningMode;
        this.displayNamesLocale = str;
        this.outputConfidenceMasks = z;
        this.outputCategoryMask = z2;
        this.resultListener = optional;
        this.errorListener = optional2;
    }

    @Override // com.google.mediapipe.tasks.vision.imagesegmenter.ImageSegmenter.ImageSegmenterOptions
    BaseOptions baseOptions() {
        return this.baseOptions;
    }

    @Override // com.google.mediapipe.tasks.vision.imagesegmenter.ImageSegmenter.ImageSegmenterOptions
    RunningMode runningMode() {
        return this.runningMode;
    }

    @Override // com.google.mediapipe.tasks.vision.imagesegmenter.ImageSegmenter.ImageSegmenterOptions
    String displayNamesLocale() {
        return this.displayNamesLocale;
    }

    @Override // com.google.mediapipe.tasks.vision.imagesegmenter.ImageSegmenter.ImageSegmenterOptions
    boolean outputConfidenceMasks() {
        return this.outputConfidenceMasks;
    }

    @Override // com.google.mediapipe.tasks.vision.imagesegmenter.ImageSegmenter.ImageSegmenterOptions
    boolean outputCategoryMask() {
        return this.outputCategoryMask;
    }

    @Override // com.google.mediapipe.tasks.vision.imagesegmenter.ImageSegmenter.ImageSegmenterOptions
    Optional<OutputHandler.ResultListener<ImageSegmenterResult, MPImage>> resultListener() {
        return this.resultListener;
    }

    @Override // com.google.mediapipe.tasks.vision.imagesegmenter.ImageSegmenter.ImageSegmenterOptions
    Optional<ErrorListener> errorListener() {
        return this.errorListener;
    }

    public String toString() {
        return "ImageSegmenterOptions{baseOptions=" + this.baseOptions + ", runningMode=" + this.runningMode + ", displayNamesLocale=" + this.displayNamesLocale + ", outputConfidenceMasks=" + this.outputConfidenceMasks + ", outputCategoryMask=" + this.outputCategoryMask + ", resultListener=" + this.resultListener + ", errorListener=" + this.errorListener + "}";
    }

    public boolean equals(Object obj) {
        if (obj == this) {
            return true;
        }
        if (obj instanceof ImageSegmenter.ImageSegmenterOptions) {
            ImageSegmenter.ImageSegmenterOptions imageSegmenterOptions = (ImageSegmenter.ImageSegmenterOptions) obj;
            if (this.baseOptions.equals(imageSegmenterOptions.baseOptions()) && this.runningMode.equals(imageSegmenterOptions.runningMode()) && this.displayNamesLocale.equals(imageSegmenterOptions.displayNamesLocale()) && this.outputConfidenceMasks == imageSegmenterOptions.outputConfidenceMasks() && this.outputCategoryMask == imageSegmenterOptions.outputCategoryMask() && this.resultListener.equals(imageSegmenterOptions.resultListener()) && this.errorListener.equals(imageSegmenterOptions.errorListener())) {
                return true;
            }
        }
        return false;
    }

    public int hashCode() {
        return ((((((((((((this.baseOptions.hashCode() ^ 1000003) * 1000003) ^ this.runningMode.hashCode()) * 1000003) ^ this.displayNamesLocale.hashCode()) * 1000003) ^ (this.outputConfidenceMasks ? 1231 : 1237)) * 1000003) ^ (this.outputCategoryMask ? 1231 : 1237)) * 1000003) ^ this.resultListener.hashCode()) * 1000003) ^ this.errorListener.hashCode();
    }

    static final class Builder extends ImageSegmenter.ImageSegmenterOptions.Builder {
        private BaseOptions baseOptions;
        private String displayNamesLocale;
        private Boolean outputCategoryMask;
        private Boolean outputConfidenceMasks;
        private RunningMode runningMode;
        private Optional<OutputHandler.ResultListener<ImageSegmenterResult, MPImage>> resultListener = Optional.empty();
        private Optional<ErrorListener> errorListener = Optional.empty();

        Builder() {
        }

        @Override // com.google.mediapipe.tasks.vision.imagesegmenter.ImageSegmenter.ImageSegmenterOptions.Builder
        public ImageSegmenter.ImageSegmenterOptions.Builder setBaseOptions(BaseOptions baseOptions) {
            if (baseOptions == null) {
                throw new NullPointerException("Null baseOptions");
            }
            this.baseOptions = baseOptions;
            return this;
        }

        @Override // com.google.mediapipe.tasks.vision.imagesegmenter.ImageSegmenter.ImageSegmenterOptions.Builder
        public ImageSegmenter.ImageSegmenterOptions.Builder setRunningMode(RunningMode runningMode) {
            if (runningMode == null) {
                throw new NullPointerException("Null runningMode");
            }
            this.runningMode = runningMode;
            return this;
        }

        @Override // com.google.mediapipe.tasks.vision.imagesegmenter.ImageSegmenter.ImageSegmenterOptions.Builder
        public ImageSegmenter.ImageSegmenterOptions.Builder setDisplayNamesLocale(String str) {
            if (str == null) {
                throw new NullPointerException("Null displayNamesLocale");
            }
            this.displayNamesLocale = str;
            return this;
        }

        @Override // com.google.mediapipe.tasks.vision.imagesegmenter.ImageSegmenter.ImageSegmenterOptions.Builder
        public ImageSegmenter.ImageSegmenterOptions.Builder setOutputConfidenceMasks(boolean z) {
            this.outputConfidenceMasks = Boolean.valueOf(z);
            return this;
        }

        @Override // com.google.mediapipe.tasks.vision.imagesegmenter.ImageSegmenter.ImageSegmenterOptions.Builder
        public ImageSegmenter.ImageSegmenterOptions.Builder setOutputCategoryMask(boolean z) {
            this.outputCategoryMask = Boolean.valueOf(z);
            return this;
        }

        @Override // com.google.mediapipe.tasks.vision.imagesegmenter.ImageSegmenter.ImageSegmenterOptions.Builder
        public ImageSegmenter.ImageSegmenterOptions.Builder setResultListener(OutputHandler.ResultListener<ImageSegmenterResult, MPImage> resultListener) {
            this.resultListener = Optional.of(resultListener);
            return this;
        }

        @Override // com.google.mediapipe.tasks.vision.imagesegmenter.ImageSegmenter.ImageSegmenterOptions.Builder
        public ImageSegmenter.ImageSegmenterOptions.Builder setErrorListener(ErrorListener errorListener) {
            this.errorListener = Optional.of(errorListener);
            return this;
        }

        @Override // com.google.mediapipe.tasks.vision.imagesegmenter.ImageSegmenter.ImageSegmenterOptions.Builder
        ImageSegmenter.ImageSegmenterOptions autoBuild() {
            String str = "";
            if (this.baseOptions == null) {
                str = " baseOptions";
            }
            if (this.runningMode == null) {
                str = str + " runningMode";
            }
            if (this.displayNamesLocale == null) {
                str = str + " displayNamesLocale";
            }
            if (this.outputConfidenceMasks == null) {
                str = str + " outputConfidenceMasks";
            }
            if (this.outputCategoryMask == null) {
                str = str + " outputCategoryMask";
            }
            if (!str.isEmpty()) {
                throw new IllegalStateException("Missing required properties:" + str);
            }
            return new AutoValue_ImageSegmenter_ImageSegmenterOptions(this.baseOptions, this.runningMode, this.displayNamesLocale, this.outputConfidenceMasks.booleanValue(), this.outputCategoryMask.booleanValue(), this.resultListener, this.errorListener);
        }
    }
}
