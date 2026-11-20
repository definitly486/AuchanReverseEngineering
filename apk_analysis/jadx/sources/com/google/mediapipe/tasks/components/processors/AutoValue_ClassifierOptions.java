package com.google.mediapipe.tasks.components.processors;

import java.util.List;
import java.util.Optional;

/* JADX INFO: loaded from: classes3.dex */
final class AutoValue_ClassifierOptions extends ClassifierOptions {
    private final List<String> categoryAllowlist;
    private final List<String> categoryDenylist;
    private final Optional<String> displayNamesLocale;
    private final Optional<Integer> maxResults;
    private final Optional<Float> scoreThreshold;

    private AutoValue_ClassifierOptions(Optional<String> optional, Optional<Integer> optional2, Optional<Float> optional3, List<String> list, List<String> list2) {
        this.displayNamesLocale = optional;
        this.maxResults = optional2;
        this.scoreThreshold = optional3;
        this.categoryAllowlist = list;
        this.categoryDenylist = list2;
    }

    @Override // com.google.mediapipe.tasks.components.processors.ClassifierOptions
    public Optional<String> displayNamesLocale() {
        return this.displayNamesLocale;
    }

    @Override // com.google.mediapipe.tasks.components.processors.ClassifierOptions
    public Optional<Integer> maxResults() {
        return this.maxResults;
    }

    @Override // com.google.mediapipe.tasks.components.processors.ClassifierOptions
    public Optional<Float> scoreThreshold() {
        return this.scoreThreshold;
    }

    @Override // com.google.mediapipe.tasks.components.processors.ClassifierOptions
    public List<String> categoryAllowlist() {
        return this.categoryAllowlist;
    }

    @Override // com.google.mediapipe.tasks.components.processors.ClassifierOptions
    public List<String> categoryDenylist() {
        return this.categoryDenylist;
    }

    public String toString() {
        return "ClassifierOptions{displayNamesLocale=" + this.displayNamesLocale + ", maxResults=" + this.maxResults + ", scoreThreshold=" + this.scoreThreshold + ", categoryAllowlist=" + this.categoryAllowlist + ", categoryDenylist=" + this.categoryDenylist + "}";
    }

    public boolean equals(Object obj) {
        if (obj == this) {
            return true;
        }
        if (obj instanceof ClassifierOptions) {
            ClassifierOptions classifierOptions = (ClassifierOptions) obj;
            if (this.displayNamesLocale.equals(classifierOptions.displayNamesLocale()) && this.maxResults.equals(classifierOptions.maxResults()) && this.scoreThreshold.equals(classifierOptions.scoreThreshold()) && this.categoryAllowlist.equals(classifierOptions.categoryAllowlist()) && this.categoryDenylist.equals(classifierOptions.categoryDenylist())) {
                return true;
            }
        }
        return false;
    }

    public int hashCode() {
        return ((((((((this.displayNamesLocale.hashCode() ^ 1000003) * 1000003) ^ this.maxResults.hashCode()) * 1000003) ^ this.scoreThreshold.hashCode()) * 1000003) ^ this.categoryAllowlist.hashCode()) * 1000003) ^ this.categoryDenylist.hashCode();
    }

    static final class Builder extends ClassifierOptions.Builder {
        private List<String> categoryAllowlist;
        private List<String> categoryDenylist;
        private Optional<String> displayNamesLocale = Optional.empty();
        private Optional<Integer> maxResults = Optional.empty();
        private Optional<Float> scoreThreshold = Optional.empty();

        Builder() {
        }

        @Override // com.google.mediapipe.tasks.components.processors.ClassifierOptions.Builder
        public ClassifierOptions.Builder setDisplayNamesLocale(String str) {
            this.displayNamesLocale = Optional.of(str);
            return this;
        }

        @Override // com.google.mediapipe.tasks.components.processors.ClassifierOptions.Builder
        public ClassifierOptions.Builder setMaxResults(Integer num) {
            this.maxResults = Optional.of(num);
            return this;
        }

        @Override // com.google.mediapipe.tasks.components.processors.ClassifierOptions.Builder
        public ClassifierOptions.Builder setScoreThreshold(Float f) {
            this.scoreThreshold = Optional.of(f);
            return this;
        }

        @Override // com.google.mediapipe.tasks.components.processors.ClassifierOptions.Builder
        public ClassifierOptions.Builder setCategoryAllowlist(List<String> list) {
            if (list == null) {
                throw new NullPointerException("Null categoryAllowlist");
            }
            this.categoryAllowlist = list;
            return this;
        }

        @Override // com.google.mediapipe.tasks.components.processors.ClassifierOptions.Builder
        public ClassifierOptions.Builder setCategoryDenylist(List<String> list) {
            if (list == null) {
                throw new NullPointerException("Null categoryDenylist");
            }
            this.categoryDenylist = list;
            return this;
        }

        @Override // com.google.mediapipe.tasks.components.processors.ClassifierOptions.Builder
        ClassifierOptions autoBuild() {
            String str = "";
            if (this.categoryAllowlist == null) {
                str = " categoryAllowlist";
            }
            if (this.categoryDenylist == null) {
                str = str + " categoryDenylist";
            }
            if (!str.isEmpty()) {
                throw new IllegalStateException("Missing required properties:" + str);
            }
            return new AutoValue_ClassifierOptions(this.displayNamesLocale, this.maxResults, this.scoreThreshold, this.categoryAllowlist, this.categoryDenylist);
        }
    }
}
