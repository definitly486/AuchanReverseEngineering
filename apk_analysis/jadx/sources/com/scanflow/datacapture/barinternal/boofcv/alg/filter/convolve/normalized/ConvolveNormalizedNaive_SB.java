package com.scanflow.datacapture.barinternal.boofcv.alg.filter.convolve.normalized;

import com.scanflow.datacapture.barinternal.boofcv.struct.convolve.Kernel1D_F32;
import com.scanflow.datacapture.barinternal.boofcv.struct.convolve.Kernel1D_S32;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayF32;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayI16;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayI8;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayU16;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayU8;

/* JADX INFO: loaded from: classes.dex */
public abstract class ConvolveNormalizedNaive_SB {
    public static void horizontal(Kernel1D_F32 kernel1D_F32, GrayF32 grayF32, GrayF32 grayF33) {
        int offset = kernel1D_F32.getOffset();
        int width = grayF32.getWidth();
        int height = grayF32.getHeight();
        for (int i = 0; i < height; i++) {
            for (int i2 = 0; i2 < width; i2++) {
                int i3 = i2 - offset;
                int width2 = kernel1D_F32.getWidth() + i3;
                if (i3 < 0) {
                    i3 = 0;
                }
                if (width2 > width) {
                    width2 = width;
                }
                float f = 0.0f;
                float f2 = 0.0f;
                while (i3 < width2) {
                    float f3 = kernel1D_F32.get((i3 - i2) + offset);
                    f += grayF32.get(i3, i) * f3;
                    f2 += f3;
                    i3++;
                }
                grayF33.set(i2, i, f / f2);
            }
        }
    }

    public static void vertical(Kernel1D_F32 kernel1D_F32, GrayF32 grayF32, GrayF32 grayF33) {
        int offset = kernel1D_F32.getOffset();
        int width = grayF32.getWidth();
        int height = grayF32.getHeight();
        for (int i = 0; i < height; i++) {
            for (int i2 = 0; i2 < width; i2++) {
                int i3 = i - offset;
                int width2 = kernel1D_F32.getWidth() + i3;
                if (i3 < 0) {
                    i3 = 0;
                }
                if (width2 > height) {
                    width2 = height;
                }
                float f = 0.0f;
                float f2 = 0.0f;
                while (i3 < width2) {
                    float f3 = kernel1D_F32.get((i3 - i) + offset);
                    f += grayF32.get(i2, i3) * f3;
                    f2 += f3;
                    i3++;
                }
                grayF33.set(i2, i, f / f2);
            }
        }
    }

    public static void horizontal(Kernel1D_S32 kernel1D_S32, GrayU8 grayU8, GrayI8 grayI8) {
        int offset = kernel1D_S32.getOffset();
        int width = grayU8.getWidth();
        int height = grayU8.getHeight();
        for (int i = 0; i < height; i++) {
            for (int i2 = 0; i2 < width; i2++) {
                int i3 = i2 - offset;
                int width2 = kernel1D_S32.getWidth() + i3;
                if (i3 < 0) {
                    i3 = 0;
                }
                if (width2 > width) {
                    width2 = width;
                }
                int i4 = 0;
                int i5 = 0;
                while (i3 < width2) {
                    int i6 = kernel1D_S32.get((i3 - i2) + offset);
                    i4 += grayU8.get(i3, i) * i6;
                    i5 += i6;
                    i3++;
                }
                grayI8.set(i2, i, (i4 + (i5 / 2)) / i5);
            }
        }
    }

    public static void vertical(Kernel1D_S32 kernel1D_S32, GrayU8 grayU8, GrayI8 grayI8) {
        int offset = kernel1D_S32.getOffset();
        int width = grayU8.getWidth();
        int height = grayU8.getHeight();
        for (int i = 0; i < height; i++) {
            for (int i2 = 0; i2 < width; i2++) {
                int i3 = i - offset;
                int width2 = kernel1D_S32.getWidth() + i3;
                if (i3 < 0) {
                    i3 = 0;
                }
                if (width2 > height) {
                    width2 = height;
                }
                int i4 = 0;
                int i5 = 0;
                while (i3 < width2) {
                    int i6 = kernel1D_S32.get((i3 - i) + offset);
                    i4 += grayU8.get(i2, i3) * i6;
                    i5 += i6;
                    i3++;
                }
                grayI8.set(i2, i, (i4 + (i5 / 2)) / i5);
            }
        }
    }

    public static void horizontal(Kernel1D_S32 kernel1D_S32, GrayU16 grayU16, GrayI16 grayI16) {
        int offset = kernel1D_S32.getOffset();
        int width = grayU16.getWidth();
        int height = grayU16.getHeight();
        for (int i = 0; i < height; i++) {
            for (int i2 = 0; i2 < width; i2++) {
                int i3 = i2 - offset;
                int width2 = kernel1D_S32.getWidth() + i3;
                if (i3 < 0) {
                    i3 = 0;
                }
                if (width2 > width) {
                    width2 = width;
                }
                int i4 = 0;
                int i5 = 0;
                while (i3 < width2) {
                    int i6 = kernel1D_S32.get((i3 - i2) + offset);
                    i4 += grayU16.get(i3, i) * i6;
                    i5 += i6;
                    i3++;
                }
                grayI16.set(i2, i, (i4 + (i5 / 2)) / i5);
            }
        }
    }

    public static void vertical(Kernel1D_S32 kernel1D_S32, GrayU16 grayU16, GrayI16 grayI16) {
        int offset = kernel1D_S32.getOffset();
        int width = grayU16.getWidth();
        int height = grayU16.getHeight();
        for (int i = 0; i < height; i++) {
            for (int i2 = 0; i2 < width; i2++) {
                int i3 = i - offset;
                int width2 = kernel1D_S32.getWidth() + i3;
                if (i3 < 0) {
                    i3 = 0;
                }
                if (width2 > height) {
                    width2 = height;
                }
                int i4 = 0;
                int i5 = 0;
                while (i3 < width2) {
                    int i6 = kernel1D_S32.get((i3 - i) + offset);
                    i4 += grayU16.get(i2, i3) * i6;
                    i5 += i6;
                    i3++;
                }
                grayI16.set(i2, i, (i4 + (i5 / 2)) / i5);
            }
        }
    }
}
