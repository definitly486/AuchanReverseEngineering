package com.scanflow.datacapture.barinternal.boofcv.abst.filter.binary;

import com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.GThresholdImageOps;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayU8;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageGray;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageType;

/* JADX INFO: loaded from: classes.dex */
public class GlobalFixedBinaryFilter implements InputToBinary {
    boolean down;
    ImageType inputType;
    double threshold;

    public GlobalFixedBinaryFilter(double d, boolean z, ImageType imageType) {
        this.threshold = d;
        this.down = z;
        this.inputType = imageType;
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.abst.filter.binary.InputToBinary
    public void process(ImageGray imageGray, GrayU8 grayU8) {
        GThresholdImageOps.threshold(imageGray, grayU8, this.threshold, this.down);
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.abst.filter.binary.InputToBinary
    public ImageType getInputType() {
        return this.inputType;
    }
}
