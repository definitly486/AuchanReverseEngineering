package com.scanflow.datacapture.barinternal.boofcv.abst.filter.binary;

import com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.GThresholdImageOps;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayU8;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageBase;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageGray;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageType;

/* JADX INFO: loaded from: classes.dex */
public abstract class GlobalBinaryFilter implements InputToBinary {
    boolean down;
    ImageType inputType;
    double maxValue;
    double minValue;
    double scale;

    abstract double computeThreshold(ImageGray imageGray);

    protected GlobalBinaryFilter(double d, double d2, double d3, boolean z, ImageType imageType) {
        this.minValue = d;
        this.maxValue = d2;
        this.down = z;
        this.scale = d3;
        this.inputType = imageType;
    }

    public void process(ImageGray imageGray, GrayU8 grayU8) {
        double d;
        if (this.down) {
            d = this.scale;
        } else {
            double d2 = this.scale;
            d = d2 <= 0.0d ? 0.0d : 1.0d / d2;
        }
        GThresholdImageOps.threshold(imageGray, grayU8, computeThreshold(imageGray) * d, this.down);
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.abst.filter.binary.InputToBinary
    public ImageType getInputType() {
        return this.inputType;
    }

    public static class Otsu extends GlobalBinaryFilter {
        @Override // com.scanflow.datacapture.barinternal.boofcv.abst.filter.binary.InputToBinary
        public /* bridge */ /* synthetic */ void process(ImageBase imageBase, GrayU8 grayU8) {
            super.process((ImageGray) imageBase, grayU8);
        }

        public Otsu(double d, double d2, double d3, boolean z, ImageType imageType) {
            super(d, d2, d3, z, imageType);
        }

        @Override // com.scanflow.datacapture.barinternal.boofcv.abst.filter.binary.GlobalBinaryFilter
        double computeThreshold(ImageGray imageGray) {
            return GThresholdImageOps.computeOtsu(imageGray, this.minValue, this.maxValue);
        }
    }

    public static class Li extends GlobalBinaryFilter {
        @Override // com.scanflow.datacapture.barinternal.boofcv.abst.filter.binary.InputToBinary
        public /* bridge */ /* synthetic */ void process(ImageBase imageBase, GrayU8 grayU8) {
            super.process((ImageGray) imageBase, grayU8);
        }

        public Li(double d, double d2, double d3, boolean z, ImageType imageType) {
            super(d, d2, d3, z, imageType);
        }

        @Override // com.scanflow.datacapture.barinternal.boofcv.abst.filter.binary.GlobalBinaryFilter
        double computeThreshold(ImageGray imageGray) {
            return GThresholdImageOps.computeLi(imageGray, this.minValue, this.maxValue);
        }
    }

    public static class Huang extends GlobalBinaryFilter {
        @Override // com.scanflow.datacapture.barinternal.boofcv.abst.filter.binary.InputToBinary
        public /* bridge */ /* synthetic */ void process(ImageBase imageBase, GrayU8 grayU8) {
            super.process((ImageGray) imageBase, grayU8);
        }

        public Huang(double d, double d2, double d3, boolean z, ImageType imageType) {
            super(d, d2, d3, z, imageType);
        }

        @Override // com.scanflow.datacapture.barinternal.boofcv.abst.filter.binary.GlobalBinaryFilter
        double computeThreshold(ImageGray imageGray) {
            return GThresholdImageOps.computeHuang(imageGray, this.minValue, this.maxValue);
        }
    }

    public static class Entropy extends GlobalBinaryFilter {
        @Override // com.scanflow.datacapture.barinternal.boofcv.abst.filter.binary.InputToBinary
        public /* bridge */ /* synthetic */ void process(ImageBase imageBase, GrayU8 grayU8) {
            super.process((ImageGray) imageBase, grayU8);
        }

        public Entropy(double d, double d2, double d3, boolean z, ImageType imageType) {
            super(d, d2, d3, z, imageType);
        }

        @Override // com.scanflow.datacapture.barinternal.boofcv.abst.filter.binary.GlobalBinaryFilter
        double computeThreshold(ImageGray imageGray) {
            return GThresholdImageOps.computeEntropy(imageGray, this.minValue, this.maxValue);
        }
    }
}
