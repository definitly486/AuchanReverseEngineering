package com.scanflow.datacapture.barinternal.boofcv.alg.filter.convolve.noborder;

import com.google.common.primitives.UnsignedBytes;
import com.scanflow.datacapture.barinternal.boofcv.misc.BoofMiscOps;
import com.scanflow.datacapture.barinternal.boofcv.struct.convolve.Kernel1D_F32;
import com.scanflow.datacapture.barinternal.boofcv.struct.convolve.Kernel1D_S32;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayF32;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayI16;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayI8;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayU16;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayU8;
import com.scanflow.datacapture.barinternal.org.ddogleg.struct.DogArray_I32;
import com.scanflow.datacapture.barinternal.pabeles.concurrency.GrowArray;
import java.util.Arrays;

/* JADX INFO: loaded from: classes.dex */
public abstract class ConvolveImageStandard_SB {
    public static void horizontal(Kernel1D_F32 kernel1D_F32, GrayF32 grayF32, GrayF32 grayF33) {
        float[] fArr = grayF32.data;
        float[] fArr2 = grayF33.data;
        float[] fArr3 = kernel1D_F32.data;
        int offset = kernel1D_F32.getOffset();
        int width = kernel1D_F32.getWidth();
        int width2 = grayF32.getWidth();
        for (int i = 0; i < grayF32.height; i++) {
            int i2 = grayF33.startIndex + (grayF33.stride * i) + offset;
            int i3 = grayF32.startIndex + (grayF32.stride * i);
            int i4 = (i3 + width2) - (width - 1);
            while (i3 < i4) {
                float f = 0.0f;
                int i5 = 0;
                int i6 = i3;
                while (i5 < width) {
                    f += fArr[i6] * fArr3[i5];
                    i5++;
                    i6++;
                }
                fArr2[i2] = f;
                i3++;
                i2++;
            }
        }
    }

    public static void vertical(Kernel1D_F32 kernel1D_F32, GrayF32 grayF32, GrayF32 grayF33) {
        float[] fArr = grayF32.data;
        float[] fArr2 = grayF33.data;
        float[] fArr3 = kernel1D_F32.data;
        int offset = kernel1D_F32.getOffset();
        int width = kernel1D_F32.getWidth();
        int width2 = grayF33.getWidth();
        int height = grayF33.getHeight() - ((width - offset) - 1);
        for (int i = offset; i < height; i++) {
            int i2 = grayF33.startIndex + (grayF33.stride * i);
            Arrays.fill(fArr2, i2, i2 + width2, 0.0f);
            for (int i3 = 0; i3 < width; i3++) {
                int i4 = grayF32.startIndex + (((i - offset) + i3) * grayF32.stride);
                int i5 = i4 + width2;
                float f = fArr3[i3];
                int i6 = i2;
                while (i4 < i5) {
                    fArr2[i6] = fArr2[i6] + (fArr[i4] * f);
                    i4++;
                    i6++;
                }
            }
        }
    }

    public static void horizontal(Kernel1D_S32 kernel1D_S32, GrayU8 grayU8, GrayI8 grayI8, int i) {
        byte[] bArr = grayU8.data;
        byte[] bArr2 = grayI8.data;
        int[] iArr = kernel1D_S32.data;
        int offset = kernel1D_S32.getOffset();
        int width = kernel1D_S32.getWidth();
        int i2 = i / 2;
        int width2 = grayU8.getWidth();
        for (int i3 = 0; i3 < grayU8.height; i3++) {
            int i4 = grayI8.startIndex + (grayI8.stride * i3) + offset;
            int i5 = grayU8.startIndex + (grayU8.stride * i3);
            int i6 = (i5 + width2) - (width - 1);
            while (i5 < i6) {
                int i7 = i5;
                int i8 = 0;
                int i9 = 0;
                while (i8 < width) {
                    i9 += (bArr[i7] & UnsignedBytes.MAX_VALUE) * iArr[i8];
                    i8++;
                    i7++;
                }
                bArr2[i4] = (byte) ((i9 + i2) / i);
                i5++;
                i4++;
            }
        }
    }

    public static void vertical(Kernel1D_S32 kernel1D_S32, GrayU8 grayU8, GrayI8 grayI8, int i, GrowArray growArray) {
        GrayU8 grayU9 = grayU8;
        GrayI8 grayI9 = grayI8;
        DogArray_I32 dogArray_I32 = (DogArray_I32) BoofMiscOps.checkDeclare(growArray, new ConvolveImageStandard_SB$$ExternalSyntheticLambda0()).grow();
        byte[] bArr = grayU9.data;
        byte[] bArr2 = grayI9.data;
        int[] iArr = kernel1D_S32.data;
        int offset = kernel1D_S32.getOffset();
        int width = kernel1D_S32.getWidth();
        int i2 = i / 2;
        double d = 1.0d / ((double) i);
        int width2 = grayI9.getWidth();
        int height = grayI9.getHeight() - ((width - offset) - 1);
        int[] iArrCheckDeclare = BoofMiscOps.checkDeclare(dogArray_I32, width2, true);
        int i3 = offset;
        while (i3 < height) {
            int i4 = 0;
            while (i4 < width) {
                int i5 = iArr[i4];
                byte[] bArr3 = bArr;
                int i6 = grayU9.startIndex + (((i3 - offset) + i4) * grayU9.stride);
                int i7 = 0;
                while (i7 < width2) {
                    iArrCheckDeclare[i7] = iArrCheckDeclare[i7] + ((bArr3[i6] & UnsignedBytes.MAX_VALUE) * i5);
                    i7++;
                    i6++;
                }
                i4++;
                bArr = bArr3;
            }
            byte[] bArr4 = bArr;
            int i8 = grayI9.startIndex + (grayI9.stride * i3);
            int i9 = 0;
            while (i9 < width2) {
                bArr2[i8] = (byte) (((double) (iArrCheckDeclare[i9] + i2)) * d);
                i9++;
                i8++;
            }
            Arrays.fill(iArrCheckDeclare, 0, width2, 0);
            i3++;
            grayU9 = grayU8;
            grayI9 = grayI8;
            bArr = bArr4;
        }
    }

    public static void horizontal(Kernel1D_S32 kernel1D_S32, GrayU16 grayU16, GrayI16 grayI16, int i) {
        short[] sArr = grayU16.data;
        short[] sArr2 = grayI16.data;
        int[] iArr = kernel1D_S32.data;
        int offset = kernel1D_S32.getOffset();
        int width = kernel1D_S32.getWidth();
        int i2 = i / 2;
        int width2 = grayU16.getWidth();
        for (int i3 = 0; i3 < grayU16.height; i3++) {
            int i4 = grayI16.startIndex + (grayI16.stride * i3) + offset;
            int i5 = grayU16.startIndex + (grayU16.stride * i3);
            int i6 = (i5 + width2) - (width - 1);
            while (i5 < i6) {
                int i7 = 0;
                int i8 = 0;
                int i9 = i5;
                while (i7 < width) {
                    i8 += (sArr[i9] & 65535) * iArr[i7];
                    i7++;
                    i9++;
                }
                sArr2[i4] = (short) ((i8 + i2) / i);
                i5++;
                i4++;
            }
        }
    }

    public static void vertical(Kernel1D_S32 kernel1D_S32, GrayU16 grayU16, GrayI16 grayI16, int i, GrowArray growArray) {
        GrayU16 grayU17 = grayU16;
        GrayI16 grayI17 = grayI16;
        DogArray_I32 dogArray_I32 = (DogArray_I32) BoofMiscOps.checkDeclare(growArray, new ConvolveImageStandard_SB$$ExternalSyntheticLambda0()).grow();
        short[] sArr = grayU17.data;
        short[] sArr2 = grayI17.data;
        int[] iArr = kernel1D_S32.data;
        int offset = kernel1D_S32.getOffset();
        int width = kernel1D_S32.getWidth();
        int i2 = i / 2;
        double d = 1.0d / ((double) i);
        int width2 = grayI17.getWidth();
        int height = grayI17.getHeight() - ((width - offset) - 1);
        int[] iArrCheckDeclare = BoofMiscOps.checkDeclare(dogArray_I32, width2, true);
        int i3 = offset;
        while (i3 < height) {
            int i4 = 0;
            while (i4 < width) {
                int i5 = iArr[i4];
                short[] sArr3 = sArr;
                int i6 = grayU17.startIndex + (((i3 - offset) + i4) * grayU17.stride);
                int i7 = 0;
                while (i7 < width2) {
                    iArrCheckDeclare[i7] = iArrCheckDeclare[i7] + ((sArr3[i6] & 65535) * i5);
                    i7++;
                    i6++;
                }
                i4++;
                sArr = sArr3;
            }
            short[] sArr4 = sArr;
            int i8 = grayI17.startIndex + (grayI17.stride * i3);
            int i9 = 0;
            while (i9 < width2) {
                sArr2[i8] = (short) (((double) (iArrCheckDeclare[i9] + i2)) * d);
                i9++;
                i8++;
            }
            Arrays.fill(iArrCheckDeclare, 0, width2, 0);
            i3++;
            grayU17 = grayU16;
            grayI17 = grayI16;
            sArr = sArr4;
        }
    }
}
