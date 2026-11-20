package com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.impl;

import com.google.common.primitives.UnsignedBytes;
import com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.ThresholdBlock;
import com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.ThresholdBlockMinMax;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayU8;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.InterleavedU8;

/* JADX INFO: loaded from: classes.dex */
public class ThresholdBlockMinMax_U8 extends ThresholdBlockMinMax {
    double scale;

    public ThresholdBlockMinMax_U8(double d, double d2, boolean z) {
        super(d, z);
        this.scale = d2;
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.ThresholdBlock.BlockProcessor
    public void thresholdBlock(int i, int i2, GrayU8 grayU8, InterleavedU8 interleavedU8, GrayU8 grayU9) {
        int iMin;
        int iMin2;
        int iMax = i;
        int iMax2 = i2;
        int i3 = this.blockWidth;
        int i4 = iMax * i3;
        int i5 = this.blockHeight;
        int i6 = iMax2 * i5;
        int i7 = interleavedU8.width;
        int i8 = iMax == i7 + (-1) ? grayU8.width : i3 * (iMax + 1);
        int i9 = iMax2 == interleavedU8.height - 1 ? grayU8.height : i5 * (iMax2 + 1);
        int i10 = 0;
        if (this.thresholdFromLocalBlocks) {
            iMin = Math.min(i7 - 1, iMax + 1);
            iMin2 = Math.min(interleavedU8.height - 1, iMax2 + 1);
            iMax = Math.max(0, iMax - 1);
            iMax2 = Math.max(0, iMax2 - 1);
        } else {
            iMin = iMax;
            iMin2 = iMax2;
        }
        int i11 = Integer.MAX_VALUE;
        int i12 = -2147483647;
        while (iMax2 <= iMin2) {
            int i13 = iMax;
            while (i13 <= iMin) {
                int i14 = iMax;
                int band = interleavedU8.getBand(i13, iMax2, i10);
                int i15 = i4;
                int band2 = interleavedU8.getBand(i13, iMax2, 1);
                if (band < i11) {
                    i11 = band;
                }
                if (band2 > i12) {
                    i12 = band2;
                }
                i13++;
                iMax = i14;
                i4 = i15;
                i10 = 0;
            }
            iMax2++;
            i10 = 0;
        }
        int i16 = i4;
        int i17 = (int) this.minimumSpread;
        if (this.down) {
            while (i6 < i9) {
                int i18 = grayU8.startIndex + (grayU8.stride * i6) + i16;
                int i19 = grayU9.startIndex + (grayU9.stride * i6) + i16;
                int i20 = i16;
                while (i20 < i8) {
                    if (i12 - i11 <= i17) {
                        grayU9.data[i19] = 1;
                    } else {
                        grayU9.data[i19] = (grayU8.data[i18] & UnsignedBytes.MAX_VALUE) <= ((int) (this.scale * ((double) ((i12 + i11) / 2)))) ? (byte) 1 : (byte) 0;
                    }
                    i20++;
                    i19++;
                    i18++;
                }
                i6++;
            }
            return;
        }
        while (i6 < i9) {
            int i21 = grayU8.startIndex + (grayU8.stride * i6) + i16;
            int i22 = grayU9.startIndex + (grayU9.stride * i6) + i16;
            int i23 = i16;
            while (i23 < i8) {
                if (i12 - i11 <= i17) {
                    grayU9.data[i22] = 1;
                } else {
                    grayU9.data[i22] = (grayU8.data[i21] & UnsignedBytes.MAX_VALUE) > ((int) (this.scale * ((double) ((i12 + i11) / 2)))) ? (byte) 1 : (byte) 0;
                }
                i23++;
                i22++;
                i21++;
            }
            i6++;
        }
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.ThresholdBlock.BlockProcessor
    public InterleavedU8 createStats() {
        return new InterleavedU8(1, 1, 2);
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.ThresholdBlock.BlockProcessor
    public void computeBlockStatistics(int i, int i2, int i3, int i4, int i5, GrayU8 grayU8, InterleavedU8 interleavedU8) {
        int iUnsafe_get = grayU8.unsafe_get(i, i2);
        int i6 = iUnsafe_get;
        for (int i7 = 0; i7 < i4; i7++) {
            int i8 = grayU8.startIndex + ((i2 + i7) * grayU8.stride) + i;
            int i9 = 0;
            while (i9 < i3) {
                int i10 = i8 + 1;
                int i11 = grayU8.data[i8] & UnsignedBytes.MAX_VALUE;
                if (i11 < iUnsafe_get) {
                    iUnsafe_get = i11;
                } else if (i11 > i6) {
                    i6 = i11;
                }
                i9++;
                i8 = i10;
            }
        }
        byte[] bArr = interleavedU8.data;
        bArr[i5] = (byte) iUnsafe_get;
        bArr[i5 + 1] = (byte) i6;
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.ThresholdBlock.BlockProcessor
    public ThresholdBlock.BlockProcessor copy() {
        return new ThresholdBlockMinMax_U8((float) this.minimumSpread, this.scale, this.down);
    }
}
