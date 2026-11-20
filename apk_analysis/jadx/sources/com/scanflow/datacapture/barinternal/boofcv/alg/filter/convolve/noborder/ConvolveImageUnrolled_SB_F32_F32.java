package com.scanflow.datacapture.barinternal.boofcv.alg.filter.convolve.noborder;

import com.scanflow.datacapture.barinternal.boofcv.struct.convolve.Kernel1D_F32;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayF32;

/* JADX INFO: loaded from: classes.dex */
public abstract class ConvolveImageUnrolled_SB_F32_F32 {
    public static boolean horizontal(Kernel1D_F32 kernel1D_F32, GrayF32 grayF32, GrayF32 grayF33) {
        int i = kernel1D_F32.offset;
        int i2 = kernel1D_F32.width;
        if (i != i2 / 2 || i2 % 2 == 0) {
            return false;
        }
        if (i2 == 3) {
            horizontal3(kernel1D_F32, grayF32, grayF33);
            return true;
        }
        if (i2 == 5) {
            horizontal5(kernel1D_F32, grayF32, grayF33);
            return true;
        }
        if (i2 == 7) {
            horizontal7(kernel1D_F32, grayF32, grayF33);
            return true;
        }
        if (i2 == 9) {
            horizontal9(kernel1D_F32, grayF32, grayF33);
            return true;
        }
        if (i2 != 11) {
            return false;
        }
        horizontal11(kernel1D_F32, grayF32, grayF33);
        return true;
    }

    public static boolean vertical(Kernel1D_F32 kernel1D_F32, GrayF32 grayF32, GrayF32 grayF33) {
        int i = kernel1D_F32.offset;
        int i2 = kernel1D_F32.width;
        if (i != i2 / 2 || i2 % 2 == 0) {
            return false;
        }
        if (i2 == 3) {
            vertical3(kernel1D_F32, grayF32, grayF33);
            return true;
        }
        if (i2 == 5) {
            vertical5(kernel1D_F32, grayF32, grayF33);
            return true;
        }
        if (i2 == 7) {
            vertical7(kernel1D_F32, grayF32, grayF33);
            return true;
        }
        if (i2 == 9) {
            vertical9(kernel1D_F32, grayF32, grayF33);
            return true;
        }
        if (i2 != 11) {
            return false;
        }
        vertical11(kernel1D_F32, grayF32, grayF33);
        return true;
    }

    public static void horizontal3(Kernel1D_F32 kernel1D_F32, GrayF32 grayF32, GrayF32 grayF33) {
        float[] fArr = grayF32.data;
        float[] fArr2 = grayF33.data;
        float[] fArr3 = kernel1D_F32.data;
        float f = fArr3[0];
        float f2 = fArr3[1];
        float f3 = fArr3[2];
        int radius = kernel1D_F32.getRadius();
        int width = grayF32.getWidth();
        for (int i = 0; i < grayF32.height; i++) {
            int i2 = grayF33.startIndex + (grayF33.stride * i) + radius;
            int i3 = (grayF32.startIndex + (grayF32.stride * i)) - radius;
            int i4 = (i3 + width) - radius;
            int i5 = i3 + radius;
            while (i5 < i4) {
                int i6 = i5 + 1;
                fArr2[i2] = (fArr[i5] * f) + (fArr[i6] * f2) + (fArr[i5 + 2] * f3);
                i2++;
                i5 = i6;
            }
        }
    }

    public static void horizontal5(Kernel1D_F32 kernel1D_F32, GrayF32 grayF32, GrayF32 grayF33) {
        float[] fArr = grayF32.data;
        float[] fArr2 = grayF33.data;
        float[] fArr3 = kernel1D_F32.data;
        float f = fArr3[0];
        float f2 = fArr3[1];
        float f3 = fArr3[2];
        float f4 = fArr3[3];
        float f5 = fArr3[4];
        int radius = kernel1D_F32.getRadius();
        int width = grayF32.getWidth();
        for (int i = 0; i < grayF32.height; i++) {
            int i2 = grayF33.startIndex + (grayF33.stride * i) + radius;
            int i3 = (grayF32.startIndex + (grayF32.stride * i)) - radius;
            int i4 = (i3 + width) - radius;
            int i5 = i3 + radius;
            while (i5 < i4) {
                int i6 = i5 + 1;
                float f6 = (fArr[i5] * f) + (fArr[i6] * f2) + (fArr[i5 + 2] * f3);
                fArr2[i2] = f6 + (fArr[i5 + 3] * f4) + (fArr[i5 + 4] * f5);
                i2++;
                i5 = i6;
            }
        }
    }

    public static void horizontal7(Kernel1D_F32 kernel1D_F32, GrayF32 grayF32, GrayF32 grayF33) {
        GrayF32 grayF34 = grayF33;
        float[] fArr = grayF32.data;
        float[] fArr2 = grayF34.data;
        float[] fArr3 = kernel1D_F32.data;
        int i = 0;
        float f = fArr3[0];
        float f2 = fArr3[1];
        float f3 = fArr3[2];
        float f4 = fArr3[3];
        float f5 = fArr3[4];
        float f6 = fArr3[5];
        float f7 = fArr3[6];
        int radius = kernel1D_F32.getRadius();
        int width = grayF32.getWidth();
        while (i < grayF32.height) {
            int i2 = grayF34.startIndex + (grayF34.stride * i) + radius;
            int i3 = (grayF32.startIndex + (grayF32.stride * i)) - radius;
            int i4 = (i3 + width) - radius;
            int i5 = i3 + radius;
            while (i5 < i4) {
                int i6 = i5 + 1;
                float f8 = (fArr[i5] * f) + (fArr[i6] * f2) + (fArr[i5 + 2] * f3) + (fArr[i5 + 3] * f4) + (fArr[i5 + 4] * f5);
                fArr2[i2] = f8 + (fArr[i5 + 5] * f6) + (fArr[i5 + 6] * f7);
                i2++;
                i5 = i6;
            }
            i++;
            grayF34 = grayF33;
        }
    }

    public static void horizontal9(Kernel1D_F32 kernel1D_F32, GrayF32 grayF32, GrayF32 grayF33) {
        GrayF32 grayF34 = grayF32;
        GrayF32 grayF35 = grayF33;
        float[] fArr = grayF34.data;
        float[] fArr2 = grayF35.data;
        float[] fArr3 = kernel1D_F32.data;
        int i = 0;
        float f = fArr3[0];
        float f2 = fArr3[1];
        float f3 = fArr3[2];
        float f4 = fArr3[3];
        float f5 = fArr3[4];
        float f6 = fArr3[5];
        float f7 = fArr3[6];
        float f8 = fArr3[7];
        float f9 = fArr3[8];
        int radius = kernel1D_F32.getRadius();
        int width = grayF34.getWidth();
        while (i < grayF34.height) {
            int i2 = grayF35.startIndex + (grayF35.stride * i) + radius;
            int i3 = (grayF34.startIndex + (grayF34.stride * i)) - radius;
            int i4 = (i3 + width) - radius;
            int i5 = i3 + radius;
            while (i5 < i4) {
                int i6 = i5 + 1;
                float f10 = (fArr[i5] * f) + (fArr[i6] * f2) + (fArr[i5 + 2] * f3) + (fArr[i5 + 3] * f4) + (fArr[i5 + 4] * f5) + (fArr[i5 + 5] * f6) + (fArr[i5 + 6] * f7);
                fArr2[i2] = f10 + (fArr[i5 + 7] * f8) + (fArr[i5 + 8] * f9);
                i2++;
                i5 = i6;
            }
            i++;
            grayF34 = grayF32;
            grayF35 = grayF33;
        }
    }

    public static void horizontal11(Kernel1D_F32 kernel1D_F32, GrayF32 grayF32, GrayF32 grayF33) {
        GrayF32 grayF34 = grayF32;
        GrayF32 grayF35 = grayF33;
        float[] fArr = grayF34.data;
        float[] fArr2 = grayF35.data;
        float[] fArr3 = kernel1D_F32.data;
        int i = 0;
        float f = fArr3[0];
        float f2 = fArr3[1];
        float f3 = fArr3[2];
        float f4 = fArr3[3];
        float f5 = fArr3[4];
        float f6 = fArr3[5];
        float f7 = fArr3[6];
        float f8 = fArr3[7];
        float f9 = fArr3[8];
        float f10 = fArr3[9];
        float f11 = fArr3[10];
        int radius = kernel1D_F32.getRadius();
        int width = grayF34.getWidth();
        while (i < grayF34.height) {
            int i2 = grayF35.startIndex + (grayF35.stride * i) + radius;
            int i3 = (grayF34.startIndex + (grayF34.stride * i)) - radius;
            int i4 = (i3 + width) - radius;
            int i5 = i3 + radius;
            while (i5 < i4) {
                int i6 = i5 + 1;
                float f12 = (fArr[i5] * f) + (fArr[i6] * f2) + (fArr[i5 + 2] * f3) + (fArr[i5 + 3] * f4) + (fArr[i5 + 4] * f5) + (fArr[i5 + 5] * f6) + (fArr[i5 + 6] * f7) + (fArr[i5 + 7] * f8) + (fArr[i5 + 8] * f9);
                fArr2[i2] = f12 + (fArr[i5 + 9] * f10) + (fArr[i5 + 10] * f11);
                i2++;
                i5 = i6;
            }
            i++;
            grayF34 = grayF32;
            grayF35 = grayF33;
        }
    }

    public static void vertical3(Kernel1D_F32 kernel1D_F32, GrayF32 grayF32, GrayF32 grayF33) {
        float[] fArr = grayF32.data;
        float[] fArr2 = grayF33.data;
        float[] fArr3 = kernel1D_F32.data;
        float f = fArr3[0];
        float f2 = fArr3[1];
        float f3 = fArr3[2];
        int radius = kernel1D_F32.getRadius();
        int width = grayF33.getWidth();
        int height = grayF33.getHeight() - radius;
        for (int i = radius; i < height; i++) {
            int i2 = grayF33.startIndex + (grayF33.stride * i);
            int i3 = grayF32.startIndex + ((i - radius) * grayF32.stride);
            int i4 = i3 + width;
            while (i3 < i4) {
                float f4 = fArr[i3] * f;
                int i5 = grayF32.stride;
                int i6 = i3 + i5;
                fArr2[i2] = f4 + (fArr[i6] * f2) + (fArr[i6 + i5] * f3);
                i3++;
                i2++;
            }
        }
    }

    public static void vertical5(Kernel1D_F32 kernel1D_F32, GrayF32 grayF32, GrayF32 grayF33) {
        GrayF32 grayF34 = grayF33;
        float[] fArr = grayF32.data;
        float[] fArr2 = grayF34.data;
        float[] fArr3 = kernel1D_F32.data;
        float f = fArr3[0];
        float f2 = fArr3[1];
        float f3 = fArr3[2];
        float f4 = fArr3[3];
        float f5 = fArr3[4];
        int radius = kernel1D_F32.getRadius();
        int width = grayF34.getWidth();
        int height = grayF34.getHeight() - radius;
        int i = radius;
        while (i < height) {
            int i2 = grayF34.startIndex + (grayF34.stride * i);
            int i3 = grayF32.startIndex + ((i - radius) * grayF32.stride);
            int i4 = i3 + width;
            while (i3 < i4) {
                float f6 = fArr[i3] * f;
                int i5 = i4;
                int i6 = grayF32.stride;
                int i7 = i3 + i6;
                float f7 = f6 + (fArr[i7] * f2);
                int i8 = i7 + i6;
                float f8 = f7 + (fArr[i8] * f3);
                int i9 = i8 + i6;
                fArr2[i2] = f8 + (fArr[i9] * f4) + (fArr[i9 + i6] * f5);
                i3++;
                i2++;
                i4 = i5;
            }
            i++;
            grayF34 = grayF33;
        }
    }

    public static void vertical7(Kernel1D_F32 kernel1D_F32, GrayF32 grayF32, GrayF32 grayF33) {
        GrayF32 grayF34 = grayF33;
        float[] fArr = grayF32.data;
        float[] fArr2 = grayF34.data;
        float[] fArr3 = kernel1D_F32.data;
        float f = fArr3[0];
        float f2 = fArr3[1];
        float f3 = fArr3[2];
        float f4 = fArr3[3];
        float f5 = fArr3[4];
        float f6 = fArr3[5];
        float f7 = fArr3[6];
        int radius = kernel1D_F32.getRadius();
        int width = grayF34.getWidth();
        int height = grayF34.getHeight() - radius;
        int i = radius;
        while (i < height) {
            float[] fArr4 = fArr;
            int i2 = grayF34.startIndex + (grayF34.stride * i);
            int i3 = grayF32.startIndex + ((i - radius) * grayF32.stride);
            int i4 = i3 + width;
            while (i3 < i4) {
                float f8 = fArr4[i3] * f;
                int i5 = i4;
                int i6 = grayF32.stride;
                int i7 = i3 + i6;
                float f9 = f8 + (fArr4[i7] * f2);
                int i8 = i7 + i6;
                float f10 = f9 + (fArr4[i8] * f3);
                int i9 = i8 + i6;
                float f11 = f10 + (fArr4[i9] * f4);
                int i10 = i9 + i6;
                float f12 = f11 + (fArr4[i10] * f5);
                int i11 = i10 + i6;
                fArr2[i2] = f12 + (fArr4[i11] * f6) + (fArr4[i11 + i6] * f7);
                i3++;
                i2++;
                i4 = i5;
            }
            i++;
            grayF34 = grayF33;
            fArr = fArr4;
        }
    }

    public static void vertical9(Kernel1D_F32 kernel1D_F32, GrayF32 grayF32, GrayF32 grayF33) {
        GrayF32 grayF34 = grayF33;
        float[] fArr = grayF32.data;
        float[] fArr2 = grayF34.data;
        float[] fArr3 = kernel1D_F32.data;
        float f = fArr3[0];
        float f2 = fArr3[1];
        float f3 = fArr3[2];
        float f4 = fArr3[3];
        float f5 = fArr3[4];
        float f6 = fArr3[5];
        float f7 = fArr3[6];
        float f8 = fArr3[7];
        float f9 = fArr3[8];
        int radius = kernel1D_F32.getRadius();
        int width = grayF34.getWidth();
        int height = grayF34.getHeight() - radius;
        int i = radius;
        while (i < height) {
            int i2 = i;
            int i3 = grayF34.startIndex + (grayF34.stride * i2);
            int i4 = grayF32.startIndex + ((i2 - radius) * grayF32.stride);
            int i5 = i4 + width;
            int i6 = i3;
            int i7 = i4;
            while (i7 < i5) {
                float f10 = fArr[i7] * f;
                int i8 = i5;
                int i9 = grayF32.stride;
                int i10 = i7 + i9;
                float f11 = f10 + (fArr[i10] * f2);
                int i11 = i10 + i9;
                float f12 = f11 + (fArr[i11] * f3);
                int i12 = i11 + i9;
                float f13 = f12 + (fArr[i12] * f4);
                int i13 = i12 + i9;
                float f14 = f13 + (fArr[i13] * f5);
                int i14 = i13 + i9;
                float f15 = f14 + (fArr[i14] * f6);
                int i15 = i14 + i9;
                float f16 = f15 + (fArr[i15] * f7);
                int i16 = i15 + i9;
                fArr2[i6] = f16 + (fArr[i16] * f8) + (fArr[i16 + i9] * f9);
                i7++;
                i6++;
                i5 = i8;
            }
            i = i2 + 1;
            grayF34 = grayF33;
        }
    }

    public static void vertical11(Kernel1D_F32 kernel1D_F32, GrayF32 grayF32, GrayF32 grayF33) {
        GrayF32 grayF34 = grayF33;
        float[] fArr = grayF32.data;
        float[] fArr2 = grayF34.data;
        float[] fArr3 = kernel1D_F32.data;
        float f = fArr3[0];
        float f2 = fArr3[1];
        float f3 = fArr3[2];
        float f4 = fArr3[3];
        float f5 = fArr3[4];
        float f6 = fArr3[5];
        float f7 = fArr3[6];
        float f8 = fArr3[7];
        float f9 = fArr3[8];
        float f10 = fArr3[9];
        float f11 = fArr3[10];
        int radius = kernel1D_F32.getRadius();
        int width = grayF34.getWidth();
        int height = grayF34.getHeight() - radius;
        int i = radius;
        while (i < height) {
            int i2 = height;
            int i3 = grayF34.startIndex + (grayF34.stride * i);
            int i4 = grayF32.startIndex + ((i - radius) * grayF32.stride);
            int i5 = i4 + width;
            int i6 = i3;
            int i7 = i4;
            while (i7 < i5) {
                float f12 = fArr[i7] * f;
                int i8 = i5;
                int i9 = grayF32.stride;
                int i10 = i7 + i9;
                float f13 = f12 + (fArr[i10] * f2);
                int i11 = i10 + i9;
                float f14 = f13 + (fArr[i11] * f3);
                int i12 = i11 + i9;
                float f15 = f14 + (fArr[i12] * f4);
                int i13 = i12 + i9;
                float f16 = f15 + (fArr[i13] * f5);
                int i14 = i13 + i9;
                float f17 = f16 + (fArr[i14] * f6);
                int i15 = i14 + i9;
                float f18 = f17 + (fArr[i15] * f7);
                int i16 = i15 + i9;
                float f19 = f18 + (fArr[i16] * f8);
                int i17 = i16 + i9;
                float f20 = f19 + (fArr[i17] * f9);
                int i18 = i17 + i9;
                fArr2[i6] = f20 + (fArr[i18] * f10) + (fArr[i18 + i9] * f11);
                i7++;
                i6++;
                i5 = i8;
            }
            i++;
            height = i2;
            grayF34 = grayF33;
        }
    }
}
