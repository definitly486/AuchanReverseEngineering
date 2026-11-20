package com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.impl;

import com.google.common.primitives.UnsignedBytes;
import com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.ThresholdBlock;
import com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.ThresholdBlockMean;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayU8;

/* JADX INFO: loaded from: classes.dex */
public class ThresholdBlockMean_U8 extends ThresholdBlockMean {
    double scale;

    public ThresholdBlockMean_U8(double d, boolean z) {
        super(z);
        this.scale = d;
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.ThresholdBlock.BlockProcessor
    public void thresholdBlock(int i, int i2, GrayU8 grayU8, GrayU8 grayU9, GrayU8 grayU10) {
        int iMin;
        int iMin2;
        int i3 = this.blockWidth;
        int i4 = i * i3;
        int i5 = this.blockHeight;
        int i6 = grayU9.width;
        int i7 = i == i6 + (-1) ? grayU8.width : i3 * (i + 1);
        int i8 = i2 == grayU9.height + (-1) ? grayU8.height : i5 * (i2 + 1);
        int iUnsafe_get = 0;
        if (this.thresholdFromLocalBlocks) {
            iMin = Math.min(i6 - 1, i + 1);
            iMin2 = Math.min(grayU9.height - 1, i2 + 1);
            i = Math.max(0, i - 1);
            i2 = Math.max(0, i2 - 1);
        } else {
            iMin = i;
            iMin2 = i2;
        }
        for (int i9 = i2; i9 <= iMin2; i9++) {
            for (int i10 = i; i10 <= iMin; i10++) {
                iUnsafe_get += grayU9.unsafe_get(i10, i9);
            }
        }
        int i11 = iUnsafe_get / (((iMin2 - i2) + 1) * ((iMin - i) + 1));
        for (int i12 = i2 * i5; i12 < i8; i12++) {
            int i13 = grayU8.startIndex + (grayU8.stride * i12) + i4;
            int i14 = grayU10.startIndex + (grayU10.stride * i12) + i4;
            int i15 = (i7 - i4) + i14;
            while (i14 < i15) {
                grayU10.data[i14] = (grayU8.data[i13] & UnsignedBytes.MAX_VALUE) <= i11 ? this.a : this.b;
                i14++;
                i13++;
            }
        }
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.ThresholdBlock.BlockProcessor
    public ThresholdBlock.BlockProcessor copy() {
        return new ThresholdBlockMean_U8(this.scale, isDown());
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.ThresholdBlock.BlockProcessor
    public GrayU8 createStats() {
        return new GrayU8(1, 1);
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.ThresholdBlock.BlockProcessor
    public void computeBlockStatistics(int i, int i2, int i3, int i4, int i5, GrayU8 grayU8, GrayU8 grayU9) {
        int i6 = 0;
        for (int i7 = 0; i7 < i4; i7++) {
            int i8 = grayU8.startIndex + ((i2 + i7) * grayU8.stride) + i;
            int i9 = 0;
            while (i9 < i3) {
                i6 += grayU8.data[i8] & UnsignedBytes.MAX_VALUE;
                i9++;
                i8++;
            }
        }
        grayU9.data[i5] = (byte) (((this.scale * ((double) i6)) / ((double) (i3 * i4))) + 0.5d);
    }
}
