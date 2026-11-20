package com.google.mediapipe.tasks.vision.imagesegmenter;

import com.google.mediapipe.tasks.vision.core.ImageProcessingOptions;

/* JADX INFO: loaded from: classes3.dex */
final class AutoValue_ImageSegmenter_SegmentationOptions extends ImageSegmenter.SegmentationOptions {
    private final ImageProcessingOptions imageProcessingOptions;
    private final int outputHeight;
    private final int outputWidth;

    private AutoValue_ImageSegmenter_SegmentationOptions(int i, int i2, ImageProcessingOptions imageProcessingOptions) {
        this.outputWidth = i;
        this.outputHeight = i2;
        this.imageProcessingOptions = imageProcessingOptions;
    }

    @Override // com.google.mediapipe.tasks.vision.imagesegmenter.ImageSegmenter.SegmentationOptions
    int outputWidth() {
        return this.outputWidth;
    }

    @Override // com.google.mediapipe.tasks.vision.imagesegmenter.ImageSegmenter.SegmentationOptions
    int outputHeight() {
        return this.outputHeight;
    }

    @Override // com.google.mediapipe.tasks.vision.imagesegmenter.ImageSegmenter.SegmentationOptions
    ImageProcessingOptions imageProcessingOptions() {
        return this.imageProcessingOptions;
    }

    public String toString() {
        return "SegmentationOptions{outputWidth=" + this.outputWidth + ", outputHeight=" + this.outputHeight + ", imageProcessingOptions=" + this.imageProcessingOptions + "}";
    }

    public boolean equals(Object obj) {
        if (obj == this) {
            return true;
        }
        if (obj instanceof ImageSegmenter.SegmentationOptions) {
            ImageSegmenter.SegmentationOptions segmentationOptions = (ImageSegmenter.SegmentationOptions) obj;
            if (this.outputWidth == segmentationOptions.outputWidth() && this.outputHeight == segmentationOptions.outputHeight() && this.imageProcessingOptions.equals(segmentationOptions.imageProcessingOptions())) {
                return true;
            }
        }
        return false;
    }

    public int hashCode() {
        return ((((this.outputWidth ^ 1000003) * 1000003) ^ this.outputHeight) * 1000003) ^ this.imageProcessingOptions.hashCode();
    }

    static final class Builder extends ImageSegmenter.SegmentationOptions.Builder {
        private ImageProcessingOptions imageProcessingOptions;
        private Integer outputHeight;
        private Integer outputWidth;

        Builder() {
        }

        @Override // com.google.mediapipe.tasks.vision.imagesegmenter.ImageSegmenter.SegmentationOptions.Builder
        public ImageSegmenter.SegmentationOptions.Builder setOutputWidth(int i) {
            this.outputWidth = Integer.valueOf(i);
            return this;
        }

        @Override // com.google.mediapipe.tasks.vision.imagesegmenter.ImageSegmenter.SegmentationOptions.Builder
        public ImageSegmenter.SegmentationOptions.Builder setOutputHeight(int i) {
            this.outputHeight = Integer.valueOf(i);
            return this;
        }

        @Override // com.google.mediapipe.tasks.vision.imagesegmenter.ImageSegmenter.SegmentationOptions.Builder
        public ImageSegmenter.SegmentationOptions.Builder setImageProcessingOptions(ImageProcessingOptions imageProcessingOptions) {
            if (imageProcessingOptions == null) {
                throw new NullPointerException("Null imageProcessingOptions");
            }
            this.imageProcessingOptions = imageProcessingOptions;
            return this;
        }

        @Override // com.google.mediapipe.tasks.vision.imagesegmenter.ImageSegmenter.SegmentationOptions.Builder
        ImageSegmenter.SegmentationOptions autoBuild() {
            String str = "";
            if (this.outputWidth == null) {
                str = " outputWidth";
            }
            if (this.outputHeight == null) {
                str = str + " outputHeight";
            }
            if (this.imageProcessingOptions == null) {
                str = str + " imageProcessingOptions";
            }
            if (!str.isEmpty()) {
                throw new IllegalStateException("Missing required properties:" + str);
            }
            return new AutoValue_ImageSegmenter_SegmentationOptions(this.outputWidth.intValue(), this.outputHeight.intValue(), this.imageProcessingOptions);
        }
    }
}
