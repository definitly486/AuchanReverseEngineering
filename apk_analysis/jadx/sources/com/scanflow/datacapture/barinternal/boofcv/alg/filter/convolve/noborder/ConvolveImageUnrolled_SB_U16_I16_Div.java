package com.scanflow.datacapture.barinternal.boofcv.alg.filter.convolve.noborder;

import com.scanflow.datacapture.barinternal.boofcv.struct.convolve.Kernel1D_S32;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayI16;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayU16;
import com.scanflow.datacapture.barinternal.pabeles.concurrency.GrowArray;

/* JADX INFO: loaded from: classes.dex */
public abstract class ConvolveImageUnrolled_SB_U16_I16_Div {
    public static boolean horizontal(Kernel1D_S32 kernel1D_S32, GrayU16 grayU16, GrayI16 grayI16, int i) {
        int i2 = kernel1D_S32.offset;
        int i3 = kernel1D_S32.width;
        if (i2 != i3 / 2 || i3 % 2 == 0) {
            return false;
        }
        if (i3 == 3) {
            horizontal3(kernel1D_S32, grayU16, grayI16, i);
            return true;
        }
        if (i3 == 5) {
            horizontal5(kernel1D_S32, grayU16, grayI16, i);
            return true;
        }
        if (i3 == 7) {
            horizontal7(kernel1D_S32, grayU16, grayI16, i);
            return true;
        }
        if (i3 == 9) {
            horizontal9(kernel1D_S32, grayU16, grayI16, i);
            return true;
        }
        if (i3 != 11) {
            return false;
        }
        horizontal11(kernel1D_S32, grayU16, grayI16, i);
        return true;
    }

    public static boolean vertical(Kernel1D_S32 kernel1D_S32, GrayU16 grayU16, GrayI16 grayI16, int i, GrowArray growArray) {
        int i2 = kernel1D_S32.offset;
        int i3 = kernel1D_S32.width;
        if (i2 != i3 / 2 || i3 % 2 == 0) {
            return false;
        }
        if (i3 == 3) {
            vertical3(kernel1D_S32, grayU16, grayI16, i, growArray);
            return true;
        }
        if (i3 == 5) {
            vertical5(kernel1D_S32, grayU16, grayI16, i, growArray);
            return true;
        }
        if (i3 == 7) {
            vertical7(kernel1D_S32, grayU16, grayI16, i, growArray);
            return true;
        }
        if (i3 == 9) {
            vertical9(kernel1D_S32, grayU16, grayI16, i, growArray);
            return true;
        }
        if (i3 != 11) {
            return false;
        }
        vertical11(kernel1D_S32, grayU16, grayI16, i, growArray);
        return true;
    }

    public static void horizontal3(Kernel1D_S32 kernel1D_S32, GrayU16 grayU16, GrayI16 grayI16, int i) {
        short[] sArr = grayU16.data;
        short[] sArr2 = grayI16.data;
        int[] iArr = kernel1D_S32.data;
        int i2 = iArr[0];
        int i3 = iArr[1];
        int i4 = iArr[2];
        int radius = kernel1D_S32.getRadius();
        int width = grayU16.getWidth();
        int i5 = i / 2;
        for (int i6 = 0; i6 < grayU16.height; i6++) {
            int i7 = grayI16.startIndex + (grayI16.stride * i6) + radius;
            int i8 = (grayU16.startIndex + (grayU16.stride * i6)) - radius;
            int i9 = (i8 + width) - radius;
            int i10 = i8 + radius;
            while (i10 < i9) {
                int i11 = i10 + 1;
                sArr2[i7] = (short) ((((((sArr[i10] & 65535) * i2) + ((sArr[i11] & 65535) * i3)) + ((sArr[i10 + 2] & 65535) * i4)) + i5) / i);
                i7++;
                i10 = i11;
            }
        }
    }

    public static void horizontal5(Kernel1D_S32 kernel1D_S32, GrayU16 grayU16, GrayI16 grayI16, int i) {
        GrayU16 grayU17 = grayU16;
        short[] sArr = grayU17.data;
        short[] sArr2 = grayI16.data;
        int[] iArr = kernel1D_S32.data;
        int i2 = 0;
        int i3 = iArr[0];
        int i4 = iArr[1];
        int i5 = iArr[2];
        int i6 = iArr[3];
        int i7 = iArr[4];
        int radius = kernel1D_S32.getRadius();
        int width = grayU17.getWidth();
        int i8 = i / 2;
        while (i2 < grayU17.height) {
            int i9 = grayI16.startIndex + (grayI16.stride * i2) + radius;
            int i10 = (grayU17.startIndex + (grayU17.stride * i2)) - radius;
            int i11 = (i10 + width) - radius;
            int i12 = i10 + radius;
            while (i12 < i11) {
                int i13 = i12 + 1;
                int i14 = ((sArr[i12] & 65535) * i3) + ((sArr[i13] & 65535) * i4) + ((sArr[i12 + 2] & 65535) * i5);
                sArr2[i9] = (short) ((((i14 + ((sArr[i12 + 3] & 65535) * i6)) + ((sArr[i12 + 4] & 65535) * i7)) + i8) / i);
                i9++;
                i12 = i13;
            }
            i2++;
            grayU17 = grayU16;
        }
    }

    public static void horizontal7(Kernel1D_S32 kernel1D_S32, GrayU16 grayU16, GrayI16 grayI16, int i) {
        GrayU16 grayU17 = grayU16;
        GrayI16 grayI17 = grayI16;
        short[] sArr = grayU17.data;
        short[] sArr2 = grayI17.data;
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
        int width = grayU17.getWidth();
        int i10 = i / 2;
        while (i2 < grayU17.height) {
            short[] sArr3 = sArr;
            int i11 = grayI17.startIndex + (grayI17.stride * i2) + radius;
            int i12 = (grayU17.startIndex + (grayU17.stride * i2)) - radius;
            int i13 = (i12 + width) - radius;
            int i14 = i12 + radius;
            while (i14 < i13) {
                int i15 = i14 + 1;
                int i16 = ((sArr3[i14] & 65535) * i3) + ((sArr3[i15] & 65535) * i4) + ((sArr3[i14 + 2] & 65535) * i5) + ((sArr3[i14 + 3] & 65535) * i6) + ((sArr3[i14 + 4] & 65535) * i7);
                sArr2[i11] = (short) ((((i16 + ((sArr3[i14 + 5] & 65535) * i8)) + ((sArr3[i14 + 6] & 65535) * i9)) + i10) / i);
                i11++;
                i14 = i15;
            }
            i2++;
            grayU17 = grayU16;
            grayI17 = grayI16;
            sArr = sArr3;
        }
    }

    public static void horizontal9(Kernel1D_S32 kernel1D_S32, GrayU16 grayU16, GrayI16 grayI16, int i) {
        GrayU16 grayU17 = grayU16;
        GrayI16 grayI17 = grayI16;
        short[] sArr = grayU17.data;
        short[] sArr2 = grayI17.data;
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
        int width = grayU17.getWidth();
        int i12 = i / 2;
        while (i2 < grayU17.height) {
            int i13 = grayI17.startIndex + (grayI17.stride * i2) + radius;
            int i14 = (grayU17.startIndex + (grayU17.stride * i2)) - radius;
            int i15 = (i14 + width) - radius;
            int i16 = i14 + radius;
            while (i16 < i15) {
                int i17 = i16 + 1;
                int i18 = ((sArr[i16] & 65535) * i3) + ((sArr[i17] & 65535) * i4) + ((sArr[i16 + 2] & 65535) * i5) + ((sArr[i16 + 3] & 65535) * i6) + ((sArr[i16 + 4] & 65535) * i7) + ((sArr[i16 + 5] & 65535) * i8) + ((sArr[i16 + 6] & 65535) * i9);
                sArr2[i13] = (short) ((((i18 + ((sArr[i16 + 7] & 65535) * i10)) + ((sArr[i16 + 8] & 65535) * i11)) + i12) / i);
                i15 = i15;
                i13++;
                i16 = i17;
            }
            i2++;
            grayU17 = grayU16;
            grayI17 = grayI16;
        }
    }

    public static void horizontal11(Kernel1D_S32 kernel1D_S32, GrayU16 grayU16, GrayI16 grayI16, int i) {
        GrayU16 grayU17 = grayU16;
        GrayI16 grayI17 = grayI16;
        short[] sArr = grayU17.data;
        short[] sArr2 = grayI17.data;
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
        int width = grayU17.getWidth();
        int i14 = i / 2;
        while (i2 < grayU17.height) {
            int i15 = grayI17.startIndex + (grayI17.stride * i2) + radius;
            int i16 = (grayU17.startIndex + (grayU17.stride * i2)) - radius;
            int i17 = (i16 + width) - radius;
            int i18 = i16 + radius;
            while (i18 < i17) {
                int i19 = i18 + 1;
                int i20 = ((sArr[i18] & 65535) * i3) + ((sArr[i19] & 65535) * i4) + ((sArr[i18 + 2] & 65535) * i5) + ((sArr[i18 + 3] & 65535) * i6) + ((sArr[i18 + 4] & 65535) * i7) + ((sArr[i18 + 5] & 65535) * i8) + ((sArr[i18 + 6] & 65535) * i9) + ((sArr[i18 + 7] & 65535) * i10) + ((sArr[i18 + 8] & 65535) * i11);
                sArr2[i15] = (short) ((((i20 + ((sArr[i18 + 9] & 65535) * i12)) + ((sArr[i18 + 10] & 65535) * i13)) + i14) / i);
                i17 = i17;
                i15++;
                i18 = i19;
            }
            i2++;
            grayU17 = grayU16;
            grayI17 = grayI16;
        }
    }

    public static void vertical3(Kernel1D_S32 kernel1D_S32, GrayU16 grayU16, GrayI16 grayI16, int i, GrowArray growArray) {
        GrayI16 grayI17 = grayI16;
        short[] sArr = grayU16.data;
        short[] sArr2 = grayI17.data;
        int[] iArr = kernel1D_S32.data;
        int i2 = iArr[0];
        int i3 = iArr[1];
        int i4 = iArr[2];
        int radius = kernel1D_S32.getRadius();
        int width = grayI17.getWidth();
        int i5 = i / 2;
        int height = grayI17.getHeight() - radius;
        int i6 = radius;
        while (i6 < height) {
            int i7 = grayI17.startIndex + (grayI17.stride * i6);
            int i8 = grayU16.startIndex + ((i6 - radius) * grayU16.stride);
            int i9 = i8 + width;
            while (i8 < i9) {
                int i10 = (sArr[i8] & 65535) * i2;
                int i11 = grayU16.stride;
                int i12 = i8 + i11;
                sArr2[i7] = (short) ((((i10 + ((sArr[i12] & 65535) * i3)) + ((sArr[i12 + i11] & 65535) * i4)) + i5) / i);
                i8++;
                i7++;
            }
            i6++;
            grayI17 = grayI16;
        }
    }

    public static void vertical5(Kernel1D_S32 kernel1D_S32, GrayU16 grayU16, GrayI16 grayI16, int i, GrowArray growArray) {
        GrayU16 grayU17 = grayU16;
        GrayI16 grayI17 = grayI16;
        short[] sArr = grayU17.data;
        short[] sArr2 = grayI17.data;
        int[] iArr = kernel1D_S32.data;
        int i2 = iArr[0];
        int i3 = iArr[1];
        int i4 = iArr[2];
        int i5 = iArr[3];
        int i6 = iArr[4];
        int radius = kernel1D_S32.getRadius();
        int width = grayI17.getWidth();
        int i7 = i / 2;
        int height = grayI17.getHeight() - radius;
        int i8 = radius;
        while (i8 < height) {
            int i9 = grayI17.startIndex + (grayI17.stride * i8);
            int i10 = grayU17.startIndex + ((i8 - radius) * grayU17.stride);
            int i11 = i10 + width;
            while (i10 < i11) {
                int i12 = (sArr[i10] & 65535) * i2;
                int i13 = i11;
                int i14 = grayU17.stride;
                int i15 = i10 + i14;
                int i16 = i12 + ((sArr[i15] & 65535) * i3);
                int i17 = i15 + i14;
                int i18 = i16 + ((sArr[i17] & 65535) * i4);
                int i19 = i17 + i14;
                sArr2[i9] = (short) ((((i18 + ((sArr[i19] & 65535) * i5)) + ((sArr[i19 + i14] & 65535) * i6)) + i7) / i);
                i10++;
                grayU17 = grayU16;
                i9++;
                i11 = i13;
            }
            i8++;
            grayU17 = grayU16;
            grayI17 = grayI16;
        }
    }

    public static void vertical7(Kernel1D_S32 kernel1D_S32, GrayU16 grayU16, GrayI16 grayI16, int i, GrowArray growArray) {
        GrayU16 grayU17 = grayU16;
        GrayI16 grayI17 = grayI16;
        short[] sArr = grayU17.data;
        short[] sArr2 = grayI17.data;
        int[] iArr = kernel1D_S32.data;
        int i2 = iArr[0];
        int i3 = iArr[1];
        int i4 = iArr[2];
        int i5 = iArr[3];
        int i6 = iArr[4];
        int i7 = iArr[5];
        int i8 = iArr[6];
        int radius = kernel1D_S32.getRadius();
        int width = grayI17.getWidth();
        int i9 = i / 2;
        int height = grayI17.getHeight() - radius;
        int i10 = radius;
        while (i10 < height) {
            short[] sArr3 = sArr;
            int i11 = grayI17.startIndex + (grayI17.stride * i10);
            int i12 = grayU17.startIndex + ((i10 - radius) * grayU17.stride);
            int i13 = i12 + width;
            int i14 = i11;
            int i15 = i12;
            while (i15 < i13) {
                int i16 = (sArr3[i15] & 65535) * i2;
                int i17 = i13;
                int i18 = grayU17.stride;
                int i19 = i15 + i18;
                int i20 = i16 + ((sArr3[i19] & 65535) * i3);
                int i21 = i19 + i18;
                int i22 = i20 + ((sArr3[i21] & 65535) * i4);
                int i23 = i21 + i18;
                int i24 = i22 + ((sArr3[i23] & 65535) * i5);
                int i25 = i23 + i18;
                int i26 = i24 + ((sArr3[i25] & 65535) * i6);
                int i27 = i25 + i18;
                sArr2[i14] = (short) ((((i26 + ((sArr3[i27] & 65535) * i7)) + ((sArr3[i27 + i18] & 65535) * i8)) + i9) / i);
                i15++;
                grayU17 = grayU16;
                i14++;
                i13 = i17;
            }
            i10++;
            grayU17 = grayU16;
            grayI17 = grayI16;
            sArr = sArr3;
        }
    }

    public static void vertical9(Kernel1D_S32 kernel1D_S32, GrayU16 grayU16, GrayI16 grayI16, int i, GrowArray growArray) {
        GrayU16 grayU17 = grayU16;
        GrayI16 grayI17 = grayI16;
        short[] sArr = grayU17.data;
        short[] sArr2 = grayI17.data;
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
        int width = grayI17.getWidth();
        int i11 = i / 2;
        int height = grayI17.getHeight() - radius;
        int i12 = radius;
        while (i12 < height) {
            int i13 = i12;
            int i14 = grayI17.startIndex + (grayI17.stride * i13);
            int i15 = grayU17.startIndex + ((i13 - radius) * grayU17.stride);
            int i16 = i15 + width;
            int i17 = i14;
            int i18 = i15;
            while (i18 < i16) {
                int i19 = (sArr[i18] & 65535) * i2;
                int i20 = i16;
                int i21 = grayU17.stride;
                int i22 = i18 + i21;
                int i23 = i19 + ((sArr[i22] & 65535) * i3);
                int i24 = i22 + i21;
                int i25 = i23 + ((sArr[i24] & 65535) * i4);
                int i26 = i24 + i21;
                int i27 = i25 + ((sArr[i26] & 65535) * i5);
                int i28 = i26 + i21;
                int i29 = i27 + ((sArr[i28] & 65535) * i6);
                int i30 = i28 + i21;
                int i31 = i29 + ((sArr[i30] & 65535) * i7);
                int i32 = i30 + i21;
                int i33 = i31 + ((sArr[i32] & 65535) * i8);
                int i34 = i32 + i21;
                sArr2[i17] = (short) ((((i33 + ((sArr[i34] & 65535) * i9)) + ((sArr[i34 + i21] & 65535) * i10)) + i11) / i);
                i18++;
                grayU17 = grayU16;
                i17++;
                i16 = i20;
            }
            i12 = i13 + 1;
            grayU17 = grayU16;
            grayI17 = grayI16;
        }
    }

    public static void vertical11(Kernel1D_S32 kernel1D_S32, GrayU16 grayU16, GrayI16 grayI16, int i, GrowArray growArray) {
        GrayU16 grayU17 = grayU16;
        GrayI16 grayI17 = grayI16;
        short[] sArr = grayU17.data;
        short[] sArr2 = grayI17.data;
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
        int width = grayI17.getWidth();
        int i13 = i / 2;
        int height = grayI17.getHeight() - radius;
        int i14 = radius;
        while (i14 < height) {
            int i15 = height;
            int i16 = grayI17.startIndex + (grayI17.stride * i14);
            int i17 = grayU17.startIndex + ((i14 - radius) * grayU17.stride);
            int i18 = i17 + width;
            int i19 = i16;
            int i20 = i17;
            while (i20 < i18) {
                int i21 = (sArr[i20] & 65535) * i2;
                int i22 = i18;
                int i23 = grayU17.stride;
                int i24 = i20 + i23;
                int i25 = i21 + ((sArr[i24] & 65535) * i3);
                int i26 = i24 + i23;
                int i27 = i25 + ((sArr[i26] & 65535) * i4);
                int i28 = i26 + i23;
                int i29 = i27 + ((sArr[i28] & 65535) * i5);
                int i30 = i28 + i23;
                int i31 = i29 + ((sArr[i30] & 65535) * i6);
                int i32 = i30 + i23;
                int i33 = i31 + ((sArr[i32] & 65535) * i7);
                int i34 = i32 + i23;
                int i35 = i33 + ((sArr[i34] & 65535) * i8);
                int i36 = i34 + i23;
                int i37 = i35 + ((sArr[i36] & 65535) * i9);
                int i38 = i36 + i23;
                int i39 = i37 + ((sArr[i38] & 65535) * i10);
                int i40 = i38 + i23;
                sArr2[i19] = (short) ((((i39 + ((sArr[i40] & 65535) * i11)) + ((sArr[i40 + i23] & 65535) * i12)) + i13) / i);
                i20++;
                grayU17 = grayU16;
                i19++;
                i18 = i22;
            }
            i14++;
            height = i15;
            grayU17 = grayU16;
            grayI17 = grayI16;
        }
    }
}
