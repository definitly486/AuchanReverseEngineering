package com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.impl;

import com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.ThresholdBlock;
import com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.ThresholdBlockMinMax;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayF32;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayU8;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.InterleavedF32;

/* JADX INFO: loaded from: classes.dex */
public class ThresholdBlockMinMax_F32 extends ThresholdBlockMinMax {
    float scale;

    public ThresholdBlockMinMax_F32(float f, float f2, boolean z) {
        super(f, z);
        this.scale = f2;
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.ThresholdBlock.BlockProcessor
    public void thresholdBlock(int i, int i2, GrayF32 grayF32, InterleavedF32 interleavedF32, GrayU8 grayU8) {
        int iMin;
        int iMin2;
        int iMax = i;
        int iMax2 = i2;
        int i3 = this.blockWidth;
        int i4 = iMax * i3;
        int i5 = this.blockHeight;
        int i6 = iMax2 * i5;
        int i7 = interleavedF32.width;
        int i8 = iMax == i7 + (-1) ? grayF32.width : i3 * (iMax + 1);
        int i9 = iMax2 == interleavedF32.height - 1 ? grayF32.height : i5 * (iMax2 + 1);
        int i10 = 0;
        if (this.thresholdFromLocalBlocks) {
            iMin = Math.min(i7 - 1, iMax + 1);
            iMin2 = Math.min(interleavedF32.height - 1, iMax2 + 1);
            iMax = Math.max(0, iMax - 1);
            iMax2 = Math.max(0, iMax2 - 1);
        } else {
            iMin = iMax;
            iMin2 = iMax2;
        }
        float f = Float.MAX_VALUE;
        float f2 = -3.4028235E38f;
        while (iMax2 <= iMin2) {
            int i11 = iMax;
            while (i11 <= iMin) {
                float band = interleavedF32.getBand(i11, iMax2, i10);
                float band2 = interleavedF32.getBand(i11, iMax2, 1);
                if (band < f) {
                    f = band;
                }
                if (band2 > f2) {
                    f2 = band2;
                }
                i11++;
                i10 = 0;
            }
            iMax2++;
            i10 = 0;
        }
        float f3 = (float) this.minimumSpread;
        float f4 = 2.0f;
        if (!this.down) {
            while (i6 < i9) {
                int i12 = grayF32.startIndex + (grayF32.stride * i6) + i4;
                int i13 = grayU8.startIndex + (grayU8.stride * i6) + i4;
                int i14 = i4;
                while (i14 < i8) {
                    if (f2 - f <= f3) {
                        grayU8.data[i13] = 1;
                    } else {
                        grayU8.data[i13] = grayF32.data[i12] > (this.scale * (f2 + f)) / 2.0f ? (byte) 1 : (byte) 0;
                    }
                    i14++;
                    i13++;
                    i12++;
                }
                i6++;
            }
            return;
        }
        while (i6 < i9) {
            int i15 = grayF32.startIndex + (grayF32.stride * i6) + i4;
            int i16 = grayU8.startIndex + (grayU8.stride * i6) + i4;
            int i17 = i4;
            while (i17 < i8) {
                if (f2 - f <= f3) {
                    grayU8.data[i16] = 1;
                } else {
                    grayU8.data[i16] = grayF32.data[i15] <= (this.scale * (f2 + f)) / f4 ? (byte) 1 : (byte) 0;
                }
                i17++;
                i16++;
                i15++;
                f4 = f4;
            }
            i6++;
        }
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.ThresholdBlock.BlockProcessor
    public ThresholdBlock.BlockProcessor copy() {
        return new ThresholdBlockMinMax_F32((float) this.minimumSpread, this.scale, this.down);
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.ThresholdBlock.BlockProcessor
    public InterleavedF32 createStats() {
        return new InterleavedF32(1, 1, 2);
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.ThresholdBlock.BlockProcessor
    public void computeBlockStatistics(int i, int i2, int i3, int i4, int i5, GrayF32 grayF32, InterleavedF32 interleavedF32) {
        float fUnsafe_get = grayF32.unsafe_get(i, i2);
        float f = fUnsafe_get;
        for (int i6 = 0; i6 < i4; i6++) {
            int i7 = grayF32.startIndex + ((i2 + i6) * grayF32.stride) + i;
            int i8 = 0;
            while (i8 < i3) {
                int i9 = i7 + 1;
                float f2 = grayF32.data[i7];
                if (f2 < fUnsafe_get) {
                    fUnsafe_get = f2;
                } else if (f2 > f) {
                    f = f2;
                }
                i8++;
                i7 = i9;
            }
        }
        float[] fArr = interleavedF32.data;
        fArr[i5] = fUnsafe_get;
        fArr[i5 + 1] = f;
    }
}
