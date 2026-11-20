package com.scanflow.datacapture.barinternal.boofcv.alg.misc.impl;

import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayF32;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayF64;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayI16;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayI8;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayS32;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayS64;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.InterleavedF32;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.InterleavedF64;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.InterleavedI16;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.InterleavedI8;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.InterleavedS32;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.InterleavedS64;

/* JADX INFO: loaded from: classes.dex */
public abstract class ImplImageMiscOps {
    public static void copy(int i, int i2, int i3, int i4, int i5, int i6, GrayI8 grayI8, GrayI8 grayI9) {
        if (grayI8.width < i + i5 || grayI8.height < i2 + i6) {
            throw new IllegalArgumentException("Copy region must be contained in the input image");
        }
        if (grayI9.width < i3 + i5 || grayI9.height < i4 + i6) {
            throw new IllegalArgumentException("Copy region must be contained in the output image");
        }
        for (int i7 = 0; i7 < i6; i7++) {
            System.arraycopy(grayI8.data, grayI8.startIndex + ((i2 + i7) * grayI8.stride) + i, grayI9.data, grayI9.startIndex + ((i4 + i7) * grayI9.stride) + i3, i5);
        }
    }

    public static void insertBand(GrayI8 grayI8, int i, InterleavedI8 interleavedI8) {
        int i2 = interleavedI8.numBands;
        for (int i3 = 0; i3 < grayI8.height; i3++) {
            int startIndex = grayI8.getStartIndex() + (grayI8.getStride() * i3);
            int startIndex2 = interleavedI8.getStartIndex() + (interleavedI8.getStride() * i3) + i;
            int i4 = ((interleavedI8.width * i2) + startIndex2) - i;
            while (startIndex2 < i4) {
                interleavedI8.data[startIndex2] = grayI8.data[startIndex];
                startIndex2 += i2;
                startIndex++;
            }
        }
    }

    public static void fillBorder(GrayI8 grayI8, int i, int i2) {
        for (int i3 = 0; i3 < i2; i3++) {
            int i4 = grayI8.startIndex;
            int i5 = grayI8.stride;
            int i6 = (i3 * i5) + i4;
            int i7 = i4 + (((grayI8.height - i3) - 1) * i5);
            int i8 = 0;
            while (i8 < grayI8.width) {
                byte[] bArr = grayI8.data;
                byte b = (byte) i;
                bArr[i6] = b;
                bArr[i7] = b;
                i8++;
                i7++;
                i6++;
            }
        }
        int i9 = grayI8.height - i2;
        int i10 = grayI8.startIndex + (grayI8.stride * i2);
        for (int i11 = 0; i11 < i2; i11++) {
            int i12 = i10 + i11;
            int i13 = ((grayI8.width + i10) - 1) - i11;
            for (int i14 = i2; i14 < i9; i14++) {
                byte[] bArr2 = grayI8.data;
                byte b2 = (byte) i;
                bArr2[i12] = b2;
                bArr2[i13] = b2;
                int i15 = grayI8.stride;
                i12 += i15;
                i13 += i15;
            }
        }
    }

    public static void insertBand(GrayI16 grayI16, int i, InterleavedI16 interleavedI16) {
        int i2 = interleavedI16.numBands;
        for (int i3 = 0; i3 < grayI16.height; i3++) {
            int startIndex = grayI16.getStartIndex() + (grayI16.getStride() * i3);
            int startIndex2 = interleavedI16.getStartIndex() + (interleavedI16.getStride() * i3) + i;
            int i4 = ((interleavedI16.width * i2) + startIndex2) - i;
            while (startIndex2 < i4) {
                interleavedI16.data[startIndex2] = grayI16.data[startIndex];
                startIndex2 += i2;
                startIndex++;
            }
        }
    }

    public static void insertBand(GrayS32 grayS32, int i, InterleavedS32 interleavedS32) {
        int i2 = interleavedS32.numBands;
        for (int i3 = 0; i3 < grayS32.height; i3++) {
            int startIndex = grayS32.getStartIndex() + (grayS32.getStride() * i3);
            int startIndex2 = interleavedS32.getStartIndex() + (interleavedS32.getStride() * i3) + i;
            int i4 = ((interleavedS32.width * i2) + startIndex2) - i;
            while (startIndex2 < i4) {
                interleavedS32.data[startIndex2] = grayS32.data[startIndex];
                startIndex2 += i2;
                startIndex++;
            }
        }
    }

    public static void insertBand(GrayS64 grayS64, int i, InterleavedS64 interleavedS64) {
        int i2 = interleavedS64.numBands;
        for (int i3 = 0; i3 < grayS64.height; i3++) {
            int startIndex = grayS64.getStartIndex() + (grayS64.getStride() * i3);
            int startIndex2 = interleavedS64.getStartIndex() + (interleavedS64.getStride() * i3) + i;
            int i4 = ((interleavedS64.width * i2) + startIndex2) - i;
            while (startIndex2 < i4) {
                interleavedS64.data[startIndex2] = grayS64.data[startIndex];
                startIndex2 += i2;
                startIndex++;
            }
        }
    }

    public static void insertBand(GrayF32 grayF32, int i, InterleavedF32 interleavedF32) {
        int i2 = interleavedF32.numBands;
        for (int i3 = 0; i3 < grayF32.height; i3++) {
            int startIndex = grayF32.getStartIndex() + (grayF32.getStride() * i3);
            int startIndex2 = interleavedF32.getStartIndex() + (interleavedF32.getStride() * i3) + i;
            int i4 = ((interleavedF32.width * i2) + startIndex2) - i;
            while (startIndex2 < i4) {
                interleavedF32.data[startIndex2] = grayF32.data[startIndex];
                startIndex2 += i2;
                startIndex++;
            }
        }
    }

    public static void insertBand(GrayF64 grayF64, int i, InterleavedF64 interleavedF64) {
        int i2 = interleavedF64.numBands;
        for (int i3 = 0; i3 < grayF64.height; i3++) {
            int startIndex = grayF64.getStartIndex() + (grayF64.getStride() * i3);
            int startIndex2 = interleavedF64.getStartIndex() + (interleavedF64.getStride() * i3) + i;
            int i4 = ((interleavedF64.width * i2) + startIndex2) - i;
            while (startIndex2 < i4) {
                interleavedF64.data[startIndex2] = grayF64.data[startIndex];
                startIndex2 += i2;
                startIndex++;
            }
        }
    }
}
