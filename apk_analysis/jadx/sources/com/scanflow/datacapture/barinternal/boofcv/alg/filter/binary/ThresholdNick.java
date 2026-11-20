package com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary;

import com.scanflow.datacapture.barinternal.boofcv.abst.filter.binary.InputToBinary;
import com.scanflow.datacapture.barinternal.boofcv.alg.filter.blur.BlurImageOps;
import com.scanflow.datacapture.barinternal.boofcv.alg.misc.PixelMath;
import com.scanflow.datacapture.barinternal.boofcv.struct.ConfigLength;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayF32;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayU8;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageType;
import com.scanflow.datacapture.barinternal.pabeles.concurrency.GrowArray;

/* JADX INFO: loaded from: classes.dex */
public class ThresholdNick implements InputToBinary {
    boolean down;
    float k;
    ConfigLength width;
    GrayF32 imageI2 = new GrayF32(1, 1);
    GrayF32 meanImage = new GrayF32(1, 1);
    GrayF32 meanI2 = new GrayF32(1, 1);
    GrayF32 tmp = new GrayF32(1, 1);
    GrowArray work = new GrowArray(new ThresholdNiblackFamily$$ExternalSyntheticLambda0());

    public ThresholdNick(ConfigLength configLength, float f, boolean z) {
        this.k = f;
        this.width = configLength;
        this.down = z;
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.abst.filter.binary.InputToBinary
    public void process(GrayF32 grayF32, GrayU8 grayU8) {
        grayU8.reshape(grayF32.width, grayF32.height);
        this.imageI2.reshape(grayF32.width, grayF32.height);
        this.meanImage.reshape(grayF32.width, grayF32.height);
        this.meanI2.reshape(grayF32.width, grayF32.height);
        this.tmp.reshape(grayF32.width, grayF32.height);
        this.imageI2.reshape(grayF32.width, grayF32.height);
        int iComputeI = this.width.computeI(Math.min(grayF32.width, grayF32.height)) / 2;
        int i = (iComputeI * 2) + 1;
        float f = i * i;
        BlurImageOps.mean(grayF32, this.meanImage, iComputeI, this.tmp, this.work);
        PixelMath.pow2(grayF32, this.imageI2);
        BlurImageOps.mean(this.imageI2, this.meanI2, iComputeI, this.tmp, this.work);
        if (this.down) {
            for (int i2 = 0; i2 < grayF32.height; i2++) {
                int i3 = this.meanI2.width * i2;
                int i4 = grayF32.startIndex + (grayF32.stride * i2);
                int i5 = grayU8.startIndex + (grayU8.stride * i2);
                int i6 = 0;
                while (i6 < grayF32.width) {
                    float f2 = this.meanImage.data[i3];
                    int i7 = i5 + 1;
                    int i8 = i4 + 1;
                    grayU8.data[i5] = (byte) (grayF32.data[i4] <= f2 + (this.k * ((float) Math.sqrt((double) (this.meanI2.data[i3] - ((f2 * f2) / f))))) ? 1 : 0);
                    i6++;
                    i3++;
                    i5 = i7;
                    i4 = i8;
                }
            }
            return;
        }
        for (int i9 = 0; i9 < grayF32.height; i9++) {
            int i10 = this.meanI2.width * i9;
            int i11 = grayF32.startIndex + (grayF32.stride * i9);
            int i12 = grayU8.startIndex + (grayU8.stride * i9);
            int i13 = 0;
            while (i13 < grayF32.width) {
                float f3 = this.meanImage.data[i10];
                int i14 = i12 + 1;
                int i15 = i11 + 1;
                grayU8.data[i12] = (byte) (grayF32.data[i11] >= f3 + (this.k * ((float) Math.sqrt((double) (this.meanI2.data[i10] - ((f3 * f3) / f))))) ? 1 : 0);
                i13++;
                i10++;
                i12 = i14;
                i11 = i15;
            }
        }
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.abst.filter.binary.InputToBinary
    public ImageType getInputType() {
        return ImageType.SB_F32;
    }
}
