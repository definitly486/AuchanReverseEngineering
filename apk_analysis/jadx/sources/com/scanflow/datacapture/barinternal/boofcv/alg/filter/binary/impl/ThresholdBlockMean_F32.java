package com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.impl;

import com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.ThresholdBlock;
import com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.ThresholdBlockMean;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayF32;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayU8;

/* JADX INFO: loaded from: classes.dex */
public class ThresholdBlockMean_F32 extends ThresholdBlockMean {
    float scale;

    public ThresholdBlockMean_F32(double d, boolean z) {
        super(z);
        this.scale = (float) d;
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.ThresholdBlock.BlockProcessor
    public void thresholdBlock(int i, int i2, GrayF32 grayF32, GrayF32 grayF33, GrayU8 grayU8) {
        int iMin;
        int iMin2;
        int i3 = this.blockWidth;
        int i4 = i * i3;
        int i5 = this.blockHeight;
        int i6 = grayF33.width;
        int i7 = i == i6 + (-1) ? grayF32.width : i3 * (i + 1);
        int i8 = i2 == grayF33.height + (-1) ? grayF32.height : i5 * (i2 + 1);
        if (this.thresholdFromLocalBlocks) {
            iMin = Math.min(i6 - 1, i + 1);
            iMin2 = Math.min(grayF33.height - 1, i2 + 1);
            i = Math.max(0, i - 1);
            i2 = Math.max(0, i2 - 1);
        } else {
            iMin = i;
            iMin2 = i2;
        }
        float fUnsafe_get = 0.0f;
        for (int i9 = i2; i9 <= iMin2; i9++) {
            for (int i10 = i; i10 <= iMin; i10++) {
                fUnsafe_get += grayF33.unsafe_get(i10, i9);
            }
        }
        float f = fUnsafe_get / (((iMin2 - i2) + 1) * ((iMin - i) + 1));
        for (int i11 = i2 * i5; i11 < i8; i11++) {
            int i12 = grayF32.startIndex + (grayF32.stride * i11) + i4;
            int i13 = grayU8.startIndex + (grayU8.stride * i11) + i4;
            int i14 = (i7 - i4) + i13;
            while (i13 < i14) {
                grayU8.data[i13] = grayF32.data[i12] <= f ? this.a : this.b;
                i13++;
                i12++;
            }
        }
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.ThresholdBlock.BlockProcessor
    public ThresholdBlock.BlockProcessor copy() {
        return new ThresholdBlockMean_F32(this.scale, isDown());
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.ThresholdBlock.BlockProcessor
    public GrayF32 createStats() {
        return new GrayF32(1, 1);
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.ThresholdBlock.BlockProcessor
    public void computeBlockStatistics(int i, int i2, int i3, int i4, int i5, GrayF32 grayF32, GrayF32 grayF33) {
        float f = 0.0f;
        for (int i6 = 0; i6 < i4; i6++) {
            int i7 = grayF32.startIndex + ((i2 + i6) * grayF32.stride) + i;
            int i8 = 0;
            while (i8 < i3) {
                f += grayF32.data[i7];
                i8++;
                i7++;
            }
        }
        grayF33.data[i5] = (this.scale * f) / (i3 * i4);
    }
}
