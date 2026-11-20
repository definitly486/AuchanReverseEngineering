package com.scanflow.datacapture.barinternal.boofcv.alg.misc.impl;

import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayF32;

/* JADX INFO: loaded from: classes.dex */
public abstract class ImplPixelMath {
    public static void subtract(GrayF32 grayF32, GrayF32 grayF33, GrayF32 grayF34) {
        int height = grayF32.getHeight();
        int width = grayF32.getWidth();
        for (int i = 0; i < height; i++) {
            int startIndex = grayF32.getStartIndex() + (grayF32.getStride() * i);
            int startIndex2 = grayF33.getStartIndex() + (grayF33.getStride() * i);
            int startIndex3 = grayF34.getStartIndex() + (grayF34.getStride() * i);
            int i2 = startIndex + width;
            while (startIndex < i2) {
                grayF34.data[startIndex3] = grayF32.data[startIndex] - grayF33.data[startIndex2];
                startIndex++;
                startIndex2++;
                startIndex3++;
            }
        }
    }

    public static void sqrt(float[] fArr, int i, int i2, float[] fArr2, int i3, int i4, int i5, int i6) {
        for (int i7 = 0; i7 < i5; i7++) {
            int i8 = (i7 * i2) + i;
            int i9 = (i7 * i4) + i3;
            int i10 = i8 + i6;
            while (i8 < i10) {
                fArr2[i9] = (float) Math.sqrt(fArr[i8]);
                i8++;
                i9++;
            }
        }
    }

    public static void pow2(float[] fArr, int i, int i2, float[] fArr2, int i3, int i4, int i5, int i6) {
        for (int i7 = 0; i7 < i5; i7++) {
            int i8 = (i7 * i2) + i;
            int i9 = (i7 * i4) + i3;
            int i10 = i8 + i6;
            while (i8 < i10) {
                float f = fArr[i8];
                fArr2[i9] = f * f;
                i8++;
                i9++;
            }
        }
    }
}
