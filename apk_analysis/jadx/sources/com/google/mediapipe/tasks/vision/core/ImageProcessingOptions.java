package com.google.mediapipe.tasks.vision.core;

import android.graphics.RectF;
import com.google.auto.value.AutoValue;
import java.util.Optional;

/* JADX INFO: loaded from: classes3.dex */
@AutoValue
public abstract class ImageProcessingOptions {
    public abstract Optional<RectF> regionOfInterest();

    public abstract int rotationDegrees();

    @AutoValue.Builder
    public static abstract class Builder {
        abstract ImageProcessingOptions autoBuild();

        public abstract Builder setRegionOfInterest(RectF rectF);

        public abstract Builder setRotationDegrees(int i);

        public final ImageProcessingOptions build() {
            ImageProcessingOptions imageProcessingOptionsAutoBuild = autoBuild();
            if (imageProcessingOptionsAutoBuild.regionOfInterest().isPresent()) {
                RectF rectF = imageProcessingOptionsAutoBuild.regionOfInterest().get();
                float f = rectF.left;
                float f2 = rectF.right;
                if (f < f2) {
                    float f3 = rectF.top;
                    float f4 = rectF.bottom;
                    if (f3 < f4) {
                        if (f < 0.0f || f2 > 1.0f || f3 < 0.0f || f4 > 1.0f) {
                            throw new IllegalArgumentException(String.format("Expected RectF values in [0,1], found: %s.", rectF.toShortString()));
                        }
                    }
                }
                throw new IllegalArgumentException(String.format("Expected left < right and top < bottom, found: %s.", rectF.toShortString()));
            }
            if (imageProcessingOptionsAutoBuild.rotationDegrees() % 90 == 0) {
                return imageProcessingOptionsAutoBuild;
            }
            throw new IllegalArgumentException(String.format("Expected rotation to be a multiple of 90°, found: %d.", Integer.valueOf(imageProcessingOptionsAutoBuild.rotationDegrees())));
        }
    }

    public static Builder builder() {
        return new AutoValue_ImageProcessingOptions.Builder().setRotationDegrees(0);
    }
}
