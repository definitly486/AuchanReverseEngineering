package com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary;

import com.google.common.primitives.UnsignedBytes;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayU8;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.InterleavedS32;
import java.util.Arrays;

/* JADX INFO: loaded from: classes.dex */
public class ThresholdBlockOtsu implements ThresholdBlock.BlockProcessor {
    protected int blockHeight;
    protected int blockWidth;
    int[] histogram = new int[256];
    ComputeOtsu otsu;
    protected boolean thresholdFromLocalBlocks;

    public ThresholdBlockOtsu(boolean z, double d, double d2, boolean z2) {
        this.otsu = new ComputeOtsu(z, d, z2, d2);
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.ThresholdBlock.BlockProcessor
    public InterleavedS32 createStats() {
        return new InterleavedS32(1, 1, 256);
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.ThresholdBlock.BlockProcessor
    public void init(int i, int i2, boolean z) {
        this.blockWidth = i;
        this.blockHeight = i2;
        this.thresholdFromLocalBlocks = z;
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.ThresholdBlock.BlockProcessor
    public void computeBlockStatistics(int i, int i2, int i3, int i4, int i5, GrayU8 grayU8, InterleavedS32 interleavedS32) {
        Arrays.fill(interleavedS32.data, i5, i5 + 256, 0);
        for (int i6 = 0; i6 < i4; i6++) {
            int i7 = grayU8.startIndex + ((i2 + i6) * grayU8.stride) + i;
            int i8 = i7 + i3;
            while (i7 < i8) {
                int[] iArr = interleavedS32.data;
                int i9 = i7 + 1;
                int i10 = (grayU8.data[i7] & UnsignedBytes.MAX_VALUE) + i5;
                iArr[i10] = iArr[i10] + 1;
                i7 = i9;
            }
        }
    }

    /* JADX WARN: Multi-variable type inference failed */
    @Override // com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.ThresholdBlock.BlockProcessor
    public void thresholdBlock(int i, int i2, GrayU8 grayU8, InterleavedS32 interleavedS32, GrayU8 grayU9) {
        int iMin;
        int iMin2;
        int[] iArr;
        ThresholdBlockOtsu thresholdBlockOtsu = this;
        int iMax = i;
        int iMax2 = i2;
        int i3 = thresholdBlockOtsu.blockWidth;
        int i4 = iMax * i3;
        int i5 = thresholdBlockOtsu.blockHeight;
        int i6 = iMax2 * i5;
        int i7 = interleavedS32.width;
        int i8 = iMax == i7 + (-1) ? grayU8.width : i3 * (iMax + 1);
        int i9 = iMax2 == interleavedS32.height + (-1) ? grayU8.height : i5 * (iMax2 + 1);
        int i10 = 0;
        if (thresholdBlockOtsu.thresholdFromLocalBlocks) {
            iMin = Math.min(i7 - 1, iMax + 1);
            iMin2 = Math.min(interleavedS32.height - 1, iMax2 + 1);
            iMax = Math.max(0, iMax - 1);
            iMax2 = Math.max(0, iMax2 - 1);
        } else {
            iMin = iMax;
            iMin2 = iMax2;
        }
        int[] iArr2 = thresholdBlockOtsu.histogram;
        Arrays.fill(iArr2, 0, iArr2.length, 0);
        while (iMax2 <= iMin2) {
            int i11 = iMax;
            while (i11 <= iMin) {
                int index = interleavedS32.getIndex(i11, iMax2, i10);
                int i12 = i10;
                while (i12 < 256) {
                    int[] iArr3 = thresholdBlockOtsu.histogram;
                    iArr3[i12] = iArr3[i12] + interleavedS32.data[index + i12];
                    i12++;
                    iMax = iMax;
                }
                i11++;
                i10 = 0;
            }
            iMax2++;
            i10 = 0;
        }
        int i13 = 0;
        int i14 = 0;
        while (true) {
            iArr = thresholdBlockOtsu.histogram;
            if (i14 >= iArr.length) {
                break;
            }
            i13 += iArr[i14];
            i14++;
        }
        thresholdBlockOtsu.otsu.compute(iArr, iArr.length, i13);
        boolean z = thresholdBlockOtsu.otsu.down;
        boolean z2 = !z;
        while (i6 < i9) {
            int i15 = grayU8.startIndex + (grayU8.stride * i6) + i4;
            int i16 = grayU9.startIndex + (grayU9.stride * i6) + i4;
            int i17 = (i8 - i4) + i16;
            while (i16 < i17) {
                boolean z3 = z;
                grayU9.data[i16] = ((double) (grayU8.data[i15] & UnsignedBytes.MAX_VALUE)) <= thresholdBlockOtsu.otsu.threshold ? z3 : z2;
                i16++;
                i15++;
                thresholdBlockOtsu = this;
                z = z3;
            }
            i6++;
            thresholdBlockOtsu = this;
        }
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.ThresholdBlock.BlockProcessor
    public ThresholdBlock.BlockProcessor copy() {
        return new ThresholdBlockOtsu(this.otsu.isUseOtsu2(), this.otsu.getTuning(), this.otsu.getScale(), this.otsu.down);
    }
}
