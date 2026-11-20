package com.google.mediapipe.tasks.vision.core;

import android.graphics.RectF;
import java.util.Optional;

/* JADX INFO: loaded from: classes3.dex */
final class AutoValue_ImageProcessingOptions extends ImageProcessingOptions {
    private final Optional<RectF> regionOfInterest;
    private final int rotationDegrees;

    private AutoValue_ImageProcessingOptions(Optional<RectF> optional, int i) {
        this.regionOfInterest = optional;
        this.rotationDegrees = i;
    }

    @Override // com.google.mediapipe.tasks.vision.core.ImageProcessingOptions
    public Optional<RectF> regionOfInterest() {
        return this.regionOfInterest;
    }

    @Override // com.google.mediapipe.tasks.vision.core.ImageProcessingOptions
    public int rotationDegrees() {
        return this.rotationDegrees;
    }

    public String toString() {
        return "ImageProcessingOptions{regionOfInterest=" + this.regionOfInterest + ", rotationDegrees=" + this.rotationDegrees + "}";
    }

    public boolean equals(Object obj) {
        if (obj == this) {
            return true;
        }
        if (obj instanceof ImageProcessingOptions) {
            ImageProcessingOptions imageProcessingOptions = (ImageProcessingOptions) obj;
            if (this.regionOfInterest.equals(imageProcessingOptions.regionOfInterest()) && this.rotationDegrees == imageProcessingOptions.rotationDegrees()) {
                return true;
            }
        }
        return false;
    }

    public int hashCode() {
        return ((this.regionOfInterest.hashCode() ^ 1000003) * 1000003) ^ this.rotationDegrees;
    }

    static final class Builder extends ImageProcessingOptions.Builder {
        private Optional<RectF> regionOfInterest = Optional.empty();
        private Integer rotationDegrees;

        Builder() {
        }

        @Override // com.google.mediapipe.tasks.vision.core.ImageProcessingOptions.Builder
        public ImageProcessingOptions.Builder setRegionOfInterest(RectF rectF) {
            this.regionOfInterest = Optional.of(rectF);
            return this;
        }

        @Override // com.google.mediapipe.tasks.vision.core.ImageProcessingOptions.Builder
        public ImageProcessingOptions.Builder setRotationDegrees(int i) {
            this.rotationDegrees = Integer.valueOf(i);
            return this;
        }

        @Override // com.google.mediapipe.tasks.vision.core.ImageProcessingOptions.Builder
        ImageProcessingOptions autoBuild() {
            String str = "";
            if (this.rotationDegrees == null) {
                str = " rotationDegrees";
            }
            if (!str.isEmpty()) {
                throw new IllegalStateException("Missing required properties:" + str);
            }
            return new AutoValue_ImageProcessingOptions(this.regionOfInterest, this.rotationDegrees.intValue());
        }
    }
}
