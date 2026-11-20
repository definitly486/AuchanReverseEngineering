package com.google.mediapipe.tasks.vision.objectdetector;

import com.google.mediapipe.framework.image.MPImage;
import com.google.mediapipe.tasks.core.BaseOptions;
import com.google.mediapipe.tasks.core.ErrorListener;
import com.google.mediapipe.tasks.core.OutputHandler;
import com.google.mediapipe.tasks.vision.core.RunningMode;
import java.util.List;
import java.util.Optional;

/* JADX INFO: loaded from: classes3.dex */
final class AutoValue_ObjectDetector_ObjectDetectorOptions extends ObjectDetector.ObjectDetectorOptions {
    private final BaseOptions baseOptions;
    private final List<String> categoryAllowlist;
    private final List<String> categoryDenylist;
    private final Optional<String> displayNamesLocale;
    private final Optional<ErrorListener> errorListener;
    private final Optional<Integer> maxResults;
    private final Optional<OutputHandler.ResultListener<ObjectDetectorResult, MPImage>> resultListener;
    private final RunningMode runningMode;
    private final Optional<Float> scoreThreshold;

    private AutoValue_ObjectDetector_ObjectDetectorOptions(BaseOptions baseOptions, RunningMode runningMode, Optional<String> optional, Optional<Integer> optional2, Optional<Float> optional3, List<String> list, List<String> list2, Optional<OutputHandler.ResultListener<ObjectDetectorResult, MPImage>> optional4, Optional<ErrorListener> optional5) {
        this.baseOptions = baseOptions;
        this.runningMode = runningMode;
        this.displayNamesLocale = optional;
        this.maxResults = optional2;
        this.scoreThreshold = optional3;
        this.categoryAllowlist = list;
        this.categoryDenylist = list2;
        this.resultListener = optional4;
        this.errorListener = optional5;
    }

    @Override // com.google.mediapipe.tasks.vision.objectdetector.ObjectDetector.ObjectDetectorOptions
    BaseOptions baseOptions() {
        return this.baseOptions;
    }

    @Override // com.google.mediapipe.tasks.vision.objectdetector.ObjectDetector.ObjectDetectorOptions
    RunningMode runningMode() {
        return this.runningMode;
    }

    @Override // com.google.mediapipe.tasks.vision.objectdetector.ObjectDetector.ObjectDetectorOptions
    Optional<String> displayNamesLocale() {
        return this.displayNamesLocale;
    }

    @Override // com.google.mediapipe.tasks.vision.objectdetector.ObjectDetector.ObjectDetectorOptions
    Optional<Integer> maxResults() {
        return this.maxResults;
    }

    @Override // com.google.mediapipe.tasks.vision.objectdetector.ObjectDetector.ObjectDetectorOptions
    Optional<Float> scoreThreshold() {
        return this.scoreThreshold;
    }

    @Override // com.google.mediapipe.tasks.vision.objectdetector.ObjectDetector.ObjectDetectorOptions
    List<String> categoryAllowlist() {
        return this.categoryAllowlist;
    }

    @Override // com.google.mediapipe.tasks.vision.objectdetector.ObjectDetector.ObjectDetectorOptions
    List<String> categoryDenylist() {
        return this.categoryDenylist;
    }

    @Override // com.google.mediapipe.tasks.vision.objectdetector.ObjectDetector.ObjectDetectorOptions
    Optional<OutputHandler.ResultListener<ObjectDetectorResult, MPImage>> resultListener() {
        return this.resultListener;
    }

    @Override // com.google.mediapipe.tasks.vision.objectdetector.ObjectDetector.ObjectDetectorOptions
    Optional<ErrorListener> errorListener() {
        return this.errorListener;
    }

    public String toString() {
        return "ObjectDetectorOptions{baseOptions=" + this.baseOptions + ", runningMode=" + this.runningMode + ", displayNamesLocale=" + this.displayNamesLocale + ", maxResults=" + this.maxResults + ", scoreThreshold=" + this.scoreThreshold + ", categoryAllowlist=" + this.categoryAllowlist + ", categoryDenylist=" + this.categoryDenylist + ", resultListener=" + this.resultListener + ", errorListener=" + this.errorListener + "}";
    }

    public boolean equals(Object obj) {
        if (obj == this) {
            return true;
        }
        if (obj instanceof ObjectDetector.ObjectDetectorOptions) {
            ObjectDetector.ObjectDetectorOptions objectDetectorOptions = (ObjectDetector.ObjectDetectorOptions) obj;
            if (this.baseOptions.equals(objectDetectorOptions.baseOptions()) && this.runningMode.equals(objectDetectorOptions.runningMode()) && this.displayNamesLocale.equals(objectDetectorOptions.displayNamesLocale()) && this.maxResults.equals(objectDetectorOptions.maxResults()) && this.scoreThreshold.equals(objectDetectorOptions.scoreThreshold()) && this.categoryAllowlist.equals(objectDetectorOptions.categoryAllowlist()) && this.categoryDenylist.equals(objectDetectorOptions.categoryDenylist()) && this.resultListener.equals(objectDetectorOptions.resultListener()) && this.errorListener.equals(objectDetectorOptions.errorListener())) {
                return true;
            }
        }
        return false;
    }

    public int hashCode() {
        return ((((((((((((((((this.baseOptions.hashCode() ^ 1000003) * 1000003) ^ this.runningMode.hashCode()) * 1000003) ^ this.displayNamesLocale.hashCode()) * 1000003) ^ this.maxResults.hashCode()) * 1000003) ^ this.scoreThreshold.hashCode()) * 1000003) ^ this.categoryAllowlist.hashCode()) * 1000003) ^ this.categoryDenylist.hashCode()) * 1000003) ^ this.resultListener.hashCode()) * 1000003) ^ this.errorListener.hashCode();
    }

    static final class Builder extends ObjectDetector.ObjectDetectorOptions.Builder {
        private BaseOptions baseOptions;
        private List<String> categoryAllowlist;
        private List<String> categoryDenylist;
        private RunningMode runningMode;
        private Optional<String> displayNamesLocale = Optional.empty();
        private Optional<Integer> maxResults = Optional.empty();
        private Optional<Float> scoreThreshold = Optional.empty();
        private Optional<OutputHandler.ResultListener<ObjectDetectorResult, MPImage>> resultListener = Optional.empty();
        private Optional<ErrorListener> errorListener = Optional.empty();

        Builder() {
        }

        @Override // com.google.mediapipe.tasks.vision.objectdetector.ObjectDetector.ObjectDetectorOptions.Builder
        public ObjectDetector.ObjectDetectorOptions.Builder setBaseOptions(BaseOptions baseOptions) {
            if (baseOptions == null) {
                throw new NullPointerException("Null baseOptions");
            }
            this.baseOptions = baseOptions;
            return this;
        }

        @Override // com.google.mediapipe.tasks.vision.objectdetector.ObjectDetector.ObjectDetectorOptions.Builder
        public ObjectDetector.ObjectDetectorOptions.Builder setRunningMode(RunningMode runningMode) {
            if (runningMode == null) {
                throw new NullPointerException("Null runningMode");
            }
            this.runningMode = runningMode;
            return this;
        }

        @Override // com.google.mediapipe.tasks.vision.objectdetector.ObjectDetector.ObjectDetectorOptions.Builder
        public ObjectDetector.ObjectDetectorOptions.Builder setDisplayNamesLocale(String str) {
            this.displayNamesLocale = Optional.of(str);
            return this;
        }

        @Override // com.google.mediapipe.tasks.vision.objectdetector.ObjectDetector.ObjectDetectorOptions.Builder
        public ObjectDetector.ObjectDetectorOptions.Builder setMaxResults(Integer num) {
            this.maxResults = Optional.of(num);
            return this;
        }

        @Override // com.google.mediapipe.tasks.vision.objectdetector.ObjectDetector.ObjectDetectorOptions.Builder
        public ObjectDetector.ObjectDetectorOptions.Builder setScoreThreshold(Float f) {
            this.scoreThreshold = Optional.of(f);
            return this;
        }

        @Override // com.google.mediapipe.tasks.vision.objectdetector.ObjectDetector.ObjectDetectorOptions.Builder
        public ObjectDetector.ObjectDetectorOptions.Builder setCategoryAllowlist(List<String> list) {
            if (list == null) {
                throw new NullPointerException("Null categoryAllowlist");
            }
            this.categoryAllowlist = list;
            return this;
        }

        @Override // com.google.mediapipe.tasks.vision.objectdetector.ObjectDetector.ObjectDetectorOptions.Builder
        public ObjectDetector.ObjectDetectorOptions.Builder setCategoryDenylist(List<String> list) {
            if (list == null) {
                throw new NullPointerException("Null categoryDenylist");
            }
            this.categoryDenylist = list;
            return this;
        }

        @Override // com.google.mediapipe.tasks.vision.objectdetector.ObjectDetector.ObjectDetectorOptions.Builder
        public ObjectDetector.ObjectDetectorOptions.Builder setResultListener(OutputHandler.ResultListener<ObjectDetectorResult, MPImage> resultListener) {
            this.resultListener = Optional.of(resultListener);
            return this;
        }

        @Override // com.google.mediapipe.tasks.vision.objectdetector.ObjectDetector.ObjectDetectorOptions.Builder
        public ObjectDetector.ObjectDetectorOptions.Builder setErrorListener(ErrorListener errorListener) {
            this.errorListener = Optional.of(errorListener);
            return this;
        }

        @Override // com.google.mediapipe.tasks.vision.objectdetector.ObjectDetector.ObjectDetectorOptions.Builder
        ObjectDetector.ObjectDetectorOptions autoBuild() {
            String str = "";
            if (this.baseOptions == null) {
                str = " baseOptions";
            }
            if (this.runningMode == null) {
                str = str + " runningMode";
            }
            if (this.categoryAllowlist == null) {
                str = str + " categoryAllowlist";
            }
            if (this.categoryDenylist == null) {
                str = str + " categoryDenylist";
            }
            if (!str.isEmpty()) {
                throw new IllegalStateException("Missing required properties:" + str);
            }
            return new AutoValue_ObjectDetector_ObjectDetectorOptions(this.baseOptions, this.runningMode, this.displayNamesLocale, this.maxResults, this.scoreThreshold, this.categoryAllowlist, this.categoryDenylist, this.resultListener, this.errorListener);
        }
    }
}
