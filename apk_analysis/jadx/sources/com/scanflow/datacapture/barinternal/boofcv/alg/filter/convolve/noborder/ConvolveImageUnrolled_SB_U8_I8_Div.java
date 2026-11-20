package com.scanflow.datacapture.barinternal.boofcv.alg.filter.convolve.noborder;

import com.google.common.primitives.UnsignedBytes;
import com.scanflow.datacapture.barinternal.boofcv.struct.convolve.Kernel1D_S32;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayI8;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayU8;
import com.scanflow.datacapture.barinternal.pabeles.concurrency.GrowArray;

/* JADX INFO: loaded from: classes.dex */
public abstract class ConvolveImageUnrolled_SB_U8_I8_Div {
    public static boolean horizontal(Kernel1D_S32 kernel1D_S32, GrayU8 grayU8, GrayI8 grayI8, int i) {
        int i2 = kernel1D_S32.offset;
        int i3 = kernel1D_S32.width;
        if (i2 != i3 / 2 || i3 % 2 == 0) {
            return false;
        }
        if (i3 == 3) {
            horizontal3(kernel1D_S32, grayU8, grayI8, i);
            return true;
        }
        if (i3 == 5) {
            horizontal5(kernel1D_S32, grayU8, grayI8, i);
            return true;
        }
        if (i3 == 7) {
            horizontal7(kernel1D_S32, grayU8, grayI8, i);
            return true;
        }
        if (i3 == 9) {
            horizontal9(kernel1D_S32, grayU8, grayI8, i);
            return true;
        }
        if (i3 != 11) {
            return false;
        }
        horizontal11(kernel1D_S32, grayU8, grayI8, i);
        return true;
    }

    public static boolean vertical(Kernel1D_S32 kernel1D_S32, GrayU8 grayU8, GrayI8 grayI8, int i, GrowArray growArray) {
        int i2 = kernel1D_S32.offset;
        int i3 = kernel1D_S32.width;
        if (i2 != i3 / 2 || i3 % 2 == 0) {
            return false;
        }
        if (i3 == 3) {
            vertical3(kernel1D_S32, grayU8, grayI8, i, growArray);
            return true;
        }
        if (i3 == 5) {
            vertical5(kernel1D_S32, grayU8, grayI8, i, growArray);
            return true;
        }
        if (i3 == 7) {
            vertical7(kernel1D_S32, grayU8, grayI8, i, growArray);
            return true;
        }
        if (i3 == 9) {
            vertical9(kernel1D_S32, grayU8, grayI8, i, growArray);
            return true;
        }
        if (i3 != 11) {
            return false;
        }
        vertical11(kernel1D_S32, grayU8, grayI8, i, growArray);
        return true;
    }

    public static void horizontal3(Kernel1D_S32 kernel1D_S32, GrayU8 grayU8, GrayI8 grayI8, int i) {
        GrayU8 grayU9 = grayU8;
        byte[] bArr = grayU9.data;
        byte[] bArr2 = grayI8.data;
        int[] iArr = kernel1D_S32.data;
        int i2 = 0;
        int i3 = iArr[0];
        int i4 = iArr[1];
        int i5 = iArr[2];
        int radius = kernel1D_S32.getRadius();
        int width = grayU9.getWidth();
        int i6 = i / 2;
        while (i2 < grayU9.height) {
            int i7 = grayI8.startIndex + (grayI8.stride * i2) + radius;
            int i8 = (grayU9.startIndex + (grayU9.stride * i2)) - radius;
            int i9 = (i8 + width) - radius;
            int i10 = i8 + radius;
            while (i10 < i9) {
                int i11 = i10 + 1;
                bArr2[i7] = (byte) ((((((bArr[i10] & UnsignedBytes.MAX_VALUE) * i3) + ((bArr[i11] & UnsignedBytes.MAX_VALUE) * i4)) + ((bArr[i10 + 2] & UnsignedBytes.MAX_VALUE) * i5)) + i6) / i);
                i7++;
                i10 = i11;
            }
            i2++;
            grayU9 = grayU8;
        }
    }

    public static void horizontal5(Kernel1D_S32 kernel1D_S32, GrayU8 grayU8, GrayI8 grayI8, int i) {
        GrayU8 grayU9 = grayU8;
        byte[] bArr = grayU9.data;
        byte[] bArr2 = grayI8.data;
        int[] iArr = kernel1D_S32.data;
        int i2 = 0;
        int i3 = iArr[0];
        int i4 = iArr[1];
        int i5 = iArr[2];
        int i6 = iArr[3];
        int i7 = iArr[4];
        int radius = kernel1D_S32.getRadius();
        int width = grayU9.getWidth();
        int i8 = i / 2;
        while (i2 < grayU9.height) {
            int i9 = grayI8.startIndex + (grayI8.stride * i2) + radius;
            int i10 = (grayU9.startIndex + (grayU9.stride * i2)) - radius;
            int i11 = (i10 + width) - radius;
            int i12 = i10 + radius;
            while (i12 < i11) {
                int i13 = i12 + 1;
                int i14 = ((bArr[i12] & UnsignedBytes.MAX_VALUE) * i3) + ((bArr[i13] & UnsignedBytes.MAX_VALUE) * i4) + ((bArr[i12 + 2] & UnsignedBytes.MAX_VALUE) * i5);
                bArr2[i9] = (byte) ((((i14 + ((bArr[i12 + 3] & UnsignedBytes.MAX_VALUE) * i6)) + ((bArr[i12 + 4] & UnsignedBytes.MAX_VALUE) * i7)) + i8) / i);
                i9++;
                i12 = i13;
            }
            i2++;
            grayU9 = grayU8;
        }
    }

    public static void horizontal7(Kernel1D_S32 kernel1D_S32, GrayU8 grayU8, GrayI8 grayI8, int i) {
        GrayU8 grayU9 = grayU8;
        GrayI8 grayI9 = grayI8;
        byte[] bArr = grayU9.data;
        byte[] bArr2 = grayI9.data;
        int[] iArr = kernel1D_S32.data;
        int i2 = 0;
        int i3 = iArr[0];
        int i4 = iArr[1];
        int i5 = iArr[2];
        int i6 = iArr[3];
        int i7 = iArr[4];
        int i8 = iArr[5];
        int i9 = iArr[6];
        int radius = kernel1D_S32.getRadius();
        int width = grayU9.getWidth();
        int i10 = i / 2;
        while (i2 < grayU9.height) {
            byte[] bArr3 = bArr;
            int i11 = grayI9.startIndex + (grayI9.stride * i2) + radius;
            int i12 = (grayU9.startIndex + (grayU9.stride * i2)) - radius;
            int i13 = (i12 + width) - radius;
            int i14 = i12 + radius;
            while (i14 < i13) {
                int i15 = i14 + 1;
                int i16 = ((bArr3[i14] & UnsignedBytes.MAX_VALUE) * i3) + ((bArr3[i15] & UnsignedBytes.MAX_VALUE) * i4) + ((bArr3[i14 + 2] & UnsignedBytes.MAX_VALUE) * i5) + ((bArr3[i14 + 3] & UnsignedBytes.MAX_VALUE) * i6) + ((bArr3[i14 + 4] & UnsignedBytes.MAX_VALUE) * i7);
                bArr2[i11] = (byte) ((((i16 + ((bArr3[i14 + 5] & UnsignedBytes.MAX_VALUE) * i8)) + ((bArr3[i14 + 6] & UnsignedBytes.MAX_VALUE) * i9)) + i10) / i);
                i11++;
                i14 = i15;
            }
            i2++;
            grayU9 = grayU8;
            grayI9 = grayI8;
            bArr = bArr3;
        }
    }

    public static void horizontal9(Kernel1D_S32 kernel1D_S32, GrayU8 grayU8, GrayI8 grayI8, int i) {
        GrayU8 grayU9 = grayU8;
        GrayI8 grayI9 = grayI8;
        byte[] bArr = grayU9.data;
        byte[] bArr2 = grayI9.data;
        int[] iArr = kernel1D_S32.data;
        int i2 = 0;
        int i3 = iArr[0];
        int i4 = iArr[1];
        int i5 = iArr[2];
        int i6 = iArr[3];
        int i7 = iArr[4];
        int i8 = iArr[5];
        int i9 = iArr[6];
        int i10 = iArr[7];
        int i11 = iArr[8];
        int radius = kernel1D_S32.getRadius();
        int width = grayU9.getWidth();
        int i12 = i / 2;
        while (i2 < grayU9.height) {
            int i13 = grayI9.startIndex + (grayI9.stride * i2) + radius;
            int i14 = (grayU9.startIndex + (grayU9.stride * i2)) - radius;
            int i15 = (i14 + width) - radius;
            int i16 = i14 + radius;
            while (i16 < i15) {
                int i17 = i16 + 1;
                int i18 = i15;
                int i19 = ((bArr[i16] & UnsignedBytes.MAX_VALUE) * i3) + ((bArr[i17] & UnsignedBytes.MAX_VALUE) * i4) + ((bArr[i16 + 2] & UnsignedBytes.MAX_VALUE) * i5) + ((bArr[i16 + 3] & UnsignedBytes.MAX_VALUE) * i6) + ((bArr[i16 + 4] & UnsignedBytes.MAX_VALUE) * i7) + ((bArr[i16 + 5] & UnsignedBytes.MAX_VALUE) * i8) + ((bArr[i16 + 6] & UnsignedBytes.MAX_VALUE) * i9);
                bArr2[i13] = (byte) ((((i19 + ((bArr[i16 + 7] & UnsignedBytes.MAX_VALUE) * i10)) + ((bArr[i16 + 8] & UnsignedBytes.MAX_VALUE) * i11)) + i12) / i);
                i15 = i18;
                i13++;
                i16 = i17;
            }
            i2++;
            grayU9 = grayU8;
            grayI9 = grayI8;
        }
    }

    public static void horizontal11(Kernel1D_S32 kernel1D_S32, GrayU8 grayU8, GrayI8 grayI8, int i) {
        GrayU8 grayU9 = grayU8;
        GrayI8 grayI9 = grayI8;
        byte[] bArr = grayU9.data;
        byte[] bArr2 = grayI9.data;
        int[] iArr = kernel1D_S32.data;
        int i2 = 0;
        int i3 = iArr[0];
        int i4 = iArr[1];
        int i5 = iArr[2];
        int i6 = iArr[3];
        int i7 = iArr[4];
        int i8 = iArr[5];
        int i9 = iArr[6];
        int i10 = iArr[7];
        int i11 = iArr[8];
        int i12 = iArr[9];
        int i13 = iArr[10];
        int radius = kernel1D_S32.getRadius();
        int width = grayU9.getWidth();
        int i14 = i / 2;
        while (i2 < grayU9.height) {
            int i15 = grayI9.startIndex + (grayI9.stride * i2) + radius;
            int i16 = (grayU9.startIndex + (grayU9.stride * i2)) - radius;
            int i17 = (i16 + width) - radius;
            int i18 = i16 + radius;
            while (i18 < i17) {
                int i19 = i18 + 1;
                int i20 = i17;
                int i21 = ((bArr[i18] & UnsignedBytes.MAX_VALUE) * i3) + ((bArr[i19] & UnsignedBytes.MAX_VALUE) * i4) + ((bArr[i18 + 2] & UnsignedBytes.MAX_VALUE) * i5) + ((bArr[i18 + 3] & UnsignedBytes.MAX_VALUE) * i6) + ((bArr[i18 + 4] & UnsignedBytes.MAX_VALUE) * i7) + ((bArr[i18 + 5] & UnsignedBytes.MAX_VALUE) * i8) + ((bArr[i18 + 6] & UnsignedBytes.MAX_VALUE) * i9) + ((bArr[i18 + 7] & UnsignedBytes.MAX_VALUE) * i10) + ((bArr[i18 + 8] & UnsignedBytes.MAX_VALUE) * i11);
                bArr2[i15] = (byte) ((((i21 + ((bArr[i18 + 9] & UnsignedBytes.MAX_VALUE) * i12)) + ((bArr[i18 + 10] & UnsignedBytes.MAX_VALUE) * i13)) + i14) / i);
                i17 = i20;
                i15++;
                i18 = i19;
            }
            i2++;
            grayU9 = grayU8;
            grayI9 = grayI8;
        }
    }

    public static void vertical3(Kernel1D_S32 kernel1D_S32, GrayU8 grayU8, GrayI8 grayI8, int i, GrowArray growArray) {
        GrayU8 grayU9 = grayU8;
        GrayI8 grayI9 = grayI8;
        byte[] bArr = grayU9.data;
        byte[] bArr2 = grayI9.data;
        int[] iArr = kernel1D_S32.data;
        int i2 = iArr[0];
        int i3 = iArr[1];
        int i4 = iArr[2];
        int radius = kernel1D_S32.getRadius();
        int width = grayI9.getWidth();
        int i5 = i / 2;
        int height = grayI9.getHeight() - radius;
        int i6 = radius;
        while (i6 < height) {
            int i7 = grayI9.startIndex + (grayI9.stride * i6);
            int i8 = grayU9.startIndex + ((i6 - radius) * grayU9.stride);
            int i9 = i8 + width;
            while (i8 < i9) {
                int i10 = (bArr[i8] & UnsignedBytes.MAX_VALUE) * i2;
                int i11 = grayU9.stride;
                int i12 = i8 + i11;
                bArr2[i7] = (byte) ((((i10 + ((bArr[i12] & UnsignedBytes.MAX_VALUE) * i3)) + ((bArr[i12 + i11] & UnsignedBytes.MAX_VALUE) * i4)) + i5) / i);
                i8++;
                i7++;
                grayU9 = grayU8;
            }
            i6++;
            grayU9 = grayU8;
            grayI9 = grayI8;
        }
    }

    public static void vertical5(Kernel1D_S32 kernel1D_S32, GrayU8 grayU8, GrayI8 grayI8, int i, GrowArray growArray) {
        GrayU8 grayU9 = grayU8;
        GrayI8 grayI9 = grayI8;
        byte[] bArr = grayU9.data;
        byte[] bArr2 = grayI9.data;
        int[] iArr = kernel1D_S32.data;
        int i2 = iArr[0];
        int i3 = iArr[1];
        int i4 = iArr[2];
        int i5 = iArr[3];
        int i6 = iArr[4];
        int radius = kernel1D_S32.getRadius();
        int width = grayI9.getWidth();
        int i7 = i / 2;
        int height = grayI9.getHeight() - radius;
        int i8 = radius;
        while (i8 < height) {
            int i9 = grayI9.startIndex + (grayI9.stride * i8);
            int i10 = grayU9.startIndex + ((i8 - radius) * grayU9.stride);
            int i11 = i10 + width;
            while (i10 < i11) {
                int i12 = i11;
                int i13 = (bArr[i10] & UnsignedBytes.MAX_VALUE) * i2;
                int i14 = grayU9.stride;
                int i15 = i10 + i14;
                int i16 = i13 + ((bArr[i15] & UnsignedBytes.MAX_VALUE) * i3);
                int i17 = i15 + i14;
                int i18 = i16 + ((bArr[i17] & UnsignedBytes.MAX_VALUE) * i4);
                int i19 = i17 + i14;
                bArr2[i9] = (byte) ((((i18 + ((bArr[i19] & UnsignedBytes.MAX_VALUE) * i5)) + ((bArr[i19 + i14] & UnsignedBytes.MAX_VALUE) * i6)) + i7) / i);
                i10++;
                grayU9 = grayU8;
                i9++;
                i11 = i12;
            }
            i8++;
            grayU9 = grayU8;
            grayI9 = grayI8;
        }
    }

    public static void vertical7(Kernel1D_S32 kernel1D_S32, GrayU8 grayU8, GrayI8 grayI8, int i, GrowArray growArray) {
        GrayU8 grayU9 = grayU8;
        GrayI8 grayI9 = grayI8;
        byte[] bArr = grayU9.data;
        byte[] bArr2 = grayI9.data;
        int[] iArr = kernel1D_S32.data;
        int i2 = iArr[0];
        int i3 = iArr[1];
        int i4 = iArr[2];
        int i5 = iArr[3];
        int i6 = iArr[4];
        int i7 = iArr[5];
        int i8 = iArr[6];
        int radius = kernel1D_S32.getRadius();
        int width = grayI9.getWidth();
        int i9 = i / 2;
        int height = grayI9.getHeight() - radius;
        int i10 = radius;
        while (i10 < height) {
            byte[] bArr3 = bArr;
            int i11 = grayI9.startIndex + (grayI9.stride * i10);
            int i12 = grayU9.startIndex + ((i10 - radius) * grayU9.stride);
            int i13 = i12 + width;
            int i14 = i11;
            int i15 = i12;
            while (i15 < i13) {
                int i16 = i13;
                int i17 = (bArr3[i15] & UnsignedBytes.MAX_VALUE) * i2;
                int i18 = grayU9.stride;
                int i19 = i15 + i18;
                int i20 = i17 + ((bArr3[i19] & UnsignedBytes.MAX_VALUE) * i3);
                int i21 = i19 + i18;
                int i22 = i20 + ((bArr3[i21] & UnsignedBytes.MAX_VALUE) * i4);
                int i23 = i21 + i18;
                int i24 = i22 + ((bArr3[i23] & UnsignedBytes.MAX_VALUE) * i5);
                int i25 = i23 + i18;
                int i26 = i24 + ((bArr3[i25] & UnsignedBytes.MAX_VALUE) * i6);
                int i27 = i25 + i18;
                bArr2[i14] = (byte) ((((i26 + ((bArr3[i27] & UnsignedBytes.MAX_VALUE) * i7)) + ((bArr3[i27 + i18] & UnsignedBytes.MAX_VALUE) * i8)) + i9) / i);
                i15++;
                grayU9 = grayU8;
                i14++;
                i13 = i16;
            }
            i10++;
            grayU9 = grayU8;
            grayI9 = grayI8;
            bArr = bArr3;
        }
    }

    public static void vertical9(Kernel1D_S32 kernel1D_S32, GrayU8 grayU8, GrayI8 grayI8, int i, GrowArray growArray) {
        GrayU8 grayU9 = grayU8;
        GrayI8 grayI9 = grayI8;
        byte[] bArr = grayU9.data;
        byte[] bArr2 = grayI9.data;
        int[] iArr = kernel1D_S32.data;
        int i2 = iArr[0];
        int i3 = iArr[1];
        int i4 = iArr[2];
        int i5 = iArr[3];
        int i6 = iArr[4];
        int i7 = iArr[5];
        int i8 = iArr[6];
        int i9 = iArr[7];
        int i10 = iArr[8];
        int radius = kernel1D_S32.getRadius();
        int width = grayI9.getWidth();
        int i11 = i / 2;
        int height = grayI9.getHeight() - radius;
        int i12 = radius;
        while (i12 < height) {
            int i13 = i12;
            int i14 = grayI9.startIndex + (grayI9.stride * i13);
            int i15 = grayU9.startIndex + ((i13 - radius) * grayU9.stride);
            int i16 = i15 + width;
            int i17 = i14;
            int i18 = i15;
            while (i18 < i16) {
                int i19 = i16;
                int i20 = (bArr[i18] & UnsignedBytes.MAX_VALUE) * i2;
                int i21 = grayU9.stride;
                int i22 = i18 + i21;
                int i23 = i20 + ((bArr[i22] & UnsignedBytes.MAX_VALUE) * i3);
                int i24 = i22 + i21;
                int i25 = i23 + ((bArr[i24] & UnsignedBytes.MAX_VALUE) * i4);
                int i26 = i24 + i21;
                int i27 = i25 + ((bArr[i26] & UnsignedBytes.MAX_VALUE) * i5);
                int i28 = i26 + i21;
                int i29 = i27 + ((bArr[i28] & UnsignedBytes.MAX_VALUE) * i6);
                int i30 = i28 + i21;
                int i31 = i29 + ((bArr[i30] & UnsignedBytes.MAX_VALUE) * i7);
                int i32 = i30 + i21;
                int i33 = i31 + ((bArr[i32] & UnsignedBytes.MAX_VALUE) * i8);
                int i34 = i32 + i21;
                bArr2[i17] = (byte) ((((i33 + ((bArr[i34] & UnsignedBytes.MAX_VALUE) * i9)) + ((bArr[i34 + i21] & UnsignedBytes.MAX_VALUE) * i10)) + i11) / i);
                i18++;
                grayU9 = grayU8;
                i17++;
                i16 = i19;
            }
            i12 = i13 + 1;
            grayU9 = grayU8;
            grayI9 = grayI8;
        }
    }

    public static void vertical11(Kernel1D_S32 kernel1D_S32, GrayU8 grayU8, GrayI8 grayI8, int i, GrowArray growArray) {
        GrayU8 grayU9 = grayU8;
        GrayI8 grayI9 = grayI8;
        byte[] bArr = grayU9.data;
        byte[] bArr2 = grayI9.data;
        int[] iArr = kernel1D_S32.data;
        int i2 = iArr[0];
        int i3 = iArr[1];
        int i4 = iArr[2];
        int i5 = iArr[3];
        int i6 = iArr[4];
        int i7 = iArr[5];
        int i8 = iArr[6];
        int i9 = iArr[7];
        int i10 = iArr[8];
        int i11 = iArr[9];
        int i12 = iArr[10];
        int radius = kernel1D_S32.getRadius();
        int width = grayI9.getWidth();
        int i13 = i / 2;
        int height = grayI9.getHeight() - radius;
        int i14 = radius;
        while (i14 < height) {
            int i15 = height;
            int i16 = grayI9.startIndex + (grayI9.stride * i14);
            int i17 = grayU9.startIndex + ((i14 - radius) * grayU9.stride);
            int i18 = i17 + width;
            int i19 = i16;
            int i20 = i17;
            while (i20 < i18) {
                int i21 = i18;
                int i22 = (bArr[i20] & UnsignedBytes.MAX_VALUE) * i2;
                int i23 = grayU9.stride;
                int i24 = i20 + i23;
                int i25 = i22 + ((bArr[i24] & UnsignedBytes.MAX_VALUE) * i3);
                int i26 = i24 + i23;
                int i27 = i25 + ((bArr[i26] & UnsignedBytes.MAX_VALUE) * i4);
                int i28 = i26 + i23;
                int i29 = i27 + ((bArr[i28] & UnsignedBytes.MAX_VALUE) * i5);
                int i30 = i28 + i23;
                int i31 = i29 + ((bArr[i30] & UnsignedBytes.MAX_VALUE) * i6);
                int i32 = i30 + i23;
                int i33 = i31 + ((bArr[i32] & UnsignedBytes.MAX_VALUE) * i7);
                int i34 = i32 + i23;
                int i35 = i33 + ((bArr[i34] & UnsignedBytes.MAX_VALUE) * i8);
                int i36 = i34 + i23;
                int i37 = i35 + ((bArr[i36] & UnsignedBytes.MAX_VALUE) * i9);
                int i38 = i36 + i23;
                int i39 = i37 + ((bArr[i38] & UnsignedBytes.MAX_VALUE) * i10);
                int i40 = i38 + i23;
                bArr2[i19] = (byte) ((((i39 + ((bArr[i40] & UnsignedBytes.MAX_VALUE) * i11)) + ((bArr[i40 + i23] & UnsignedBytes.MAX_VALUE) * i12)) + i13) / i);
                i20++;
                grayU9 = grayU8;
                i19++;
                i18 = i21;
            }
            i14++;
            height = i15;
            grayU9 = grayU8;
            grayI9 = grayI8;
        }
    }
}
