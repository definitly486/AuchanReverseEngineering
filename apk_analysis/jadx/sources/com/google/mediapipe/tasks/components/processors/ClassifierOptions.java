package com.google.mediapipe.tasks.components.processors;

import com.google.auto.value.AutoValue;
import com.google.mediapipe.tasks.components.processors.proto.ClassifierOptionsProto;
import java.util.Collections;
import java.util.List;
import java.util.Objects;
import java.util.Optional;

/* JADX INFO: loaded from: classes3.dex */
@AutoValue
public abstract class ClassifierOptions {
    public abstract List<String> categoryAllowlist();

    public abstract List<String> categoryDenylist();

    public abstract Optional<String> displayNamesLocale();

    public abstract Optional<Integer> maxResults();

    public abstract Optional<Float> scoreThreshold();

    @AutoValue.Builder
    public static abstract class Builder {
        abstract ClassifierOptions autoBuild();

        public abstract Builder setCategoryAllowlist(List<String> list);

        public abstract Builder setCategoryDenylist(List<String> list);

        public abstract Builder setDisplayNamesLocale(String str);

        public abstract Builder setMaxResults(Integer num);

        public abstract Builder setScoreThreshold(Float f);

        public final ClassifierOptions build() {
            ClassifierOptions classifierOptionsAutoBuild = autoBuild();
            if (!classifierOptionsAutoBuild.maxResults().isPresent() || classifierOptionsAutoBuild.maxResults().get().intValue() > 0) {
                return classifierOptionsAutoBuild;
            }
            throw new IllegalArgumentException("If specified, maxResults must be > 0");
        }
    }

    public static Builder builder() {
        AutoValue_ClassifierOptions.Builder builder = new AutoValue_ClassifierOptions.Builder();
        List<String> list = Collections.EMPTY_LIST;
        return builder.setCategoryAllowlist(list).setCategoryDenylist(list);
    }

    public ClassifierOptionsProto.ClassifierOptions convertToProto() {
        ClassifierOptionsProto.ClassifierOptions.Builder builderNewBuilder = ClassifierOptionsProto.ClassifierOptions.newBuilder();
        Optional<String> optionalDisplayNamesLocale = displayNamesLocale();
        Objects.requireNonNull(builderNewBuilder);
        optionalDisplayNamesLocale.ifPresent(new ClassifierOptions$$ExternalSyntheticLambda0(builderNewBuilder));
        maxResults().ifPresent(new ClassifierOptions$$ExternalSyntheticLambda1(builderNewBuilder));
        scoreThreshold().ifPresent(new ClassifierOptions$$ExternalSyntheticLambda2(builderNewBuilder));
        if (!categoryAllowlist().isEmpty()) {
            builderNewBuilder.addAllCategoryAllowlist(categoryAllowlist());
        }
        if (!categoryDenylist().isEmpty()) {
            builderNewBuilder.addAllCategoryDenylist(categoryDenylist());
        }
        return builderNewBuilder.build();
    }
}
