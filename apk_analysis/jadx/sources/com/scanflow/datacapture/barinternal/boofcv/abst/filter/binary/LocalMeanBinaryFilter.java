package com.scanflow.datacapture.barinternal.boofcv.abst.filter.binary;

import com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.GThresholdImageOps;
import com.scanflow.datacapture.barinternal.boofcv.core.image.GeneralizedImageOps;
import com.scanflow.datacapture.barinternal.boofcv.struct.ConfigLength;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayU8;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageGray;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageType;
import com.scanflow.datacapture.barinternal.pabeles.concurrency.GrowArray;

/* JADX INFO: loaded from: classes.dex */
public class LocalMeanBinaryFilter implements InputToBinary {
    boolean down;
    ImageType inputType;
    ConfigLength regionWidth;
    double scale;
    ImageGray work1;
    ImageGray work2;
    GrowArray work3;

    public LocalMeanBinaryFilter(ConfigLength configLength, double d, boolean z, ImageType imageType) {
        this.regionWidth = configLength;
        this.scale = d;
        this.down = z;
        this.inputType = imageType;
        this.work1 = (ImageGray) imageType.createImage(1, 1);
        this.work2 = (ImageGray) imageType.createImage(1, 1);
        this.work3 = GeneralizedImageOps.createGrowArray(imageType);
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.abst.filter.binary.InputToBinary
    public void process(ImageGray imageGray, GrayU8 grayU8) {
        this.work1.reshape(imageGray.width, imageGray.height);
        this.work2.reshape(imageGray.width, imageGray.height);
        GThresholdImageOps.localMean(imageGray, grayU8, this.regionWidth, this.scale, this.down, this.work1, this.work2, this.work3);
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.abst.filter.binary.InputToBinary
    public ImageType getInputType() {
        return this.inputType;
    }
}
