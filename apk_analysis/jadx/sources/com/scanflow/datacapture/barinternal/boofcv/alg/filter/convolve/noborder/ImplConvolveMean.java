package com.scanflow.datacapture.barinternal.boofcv.alg.filter.convolve.noborder;

import com.google.common.primitives.UnsignedBytes;
import com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.ThresholdNiblackFamily$$ExternalSyntheticLambda0;
import com.scanflow.datacapture.barinternal.boofcv.misc.BoofMiscOps;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayF32;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayI16;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayI8;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayU16;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayU8;
import com.scanflow.datacapture.barinternal.org.ddogleg.struct.DogArray_F32;
import com.scanflow.datacapture.barinternal.org.ddogleg.struct.DogArray_I32;
import com.scanflow.datacapture.barinternal.pabeles.concurrency.GrowArray;

/* JADX INFO: loaded from: classes.dex */
public abstract class ImplConvolveMean {
    public static void horizontal(GrayU8 grayU8, GrayI8 grayI8, int i, int i2) {
        int i3 = i2 / 2;
        for (int i4 = 0; i4 < grayU8.height; i4++) {
            int i5 = grayU8.startIndex + (grayU8.stride * i4);
            int i6 = grayI8.startIndex + (grayI8.stride * i4) + i;
            int i7 = i5 + i2;
            int i8 = 0;
            while (i5 < i7) {
                i8 += grayU8.data[i5] & UnsignedBytes.MAX_VALUE;
                i5++;
            }
            int i9 = i6 + 1;
            grayI8.data[i6] = (byte) ((i8 + i3) / i2);
            int i10 = (grayU8.width + i5) - i2;
            while (i5 < i10) {
                byte[] bArr = grayU8.data;
                i8 = (i8 - (bArr[i5 - i2] & UnsignedBytes.MAX_VALUE)) + (bArr[i5] & UnsignedBytes.MAX_VALUE);
                grayI8.data[i9] = (byte) ((i8 + i3) / i2);
                i5++;
                i9++;
            }
        }
    }

    public static void vertical(GrayU8 grayU8, GrayI8 grayI8, int i, int i2, GrowArray growArray) {
        DogArray_I32 dogArray_I32 = (DogArray_I32) BoofMiscOps.checkDeclare(growArray, new ConvolveImageStandard_SB$$ExternalSyntheticLambda0()).grow();
        int i3 = grayU8.stride * i2;
        int i4 = (i2 - i) - 1;
        int i5 = i2 / 2;
        int i6 = grayI8.height - i4;
        int[] iArrCheckDeclare = BoofMiscOps.checkDeclare(dogArray_I32, grayU8.width, false);
        for (int i7 = 0; i7 < grayU8.width; i7++) {
            int i8 = grayU8.startIndex;
            int i9 = grayU8.stride;
            int i10 = i8 + i7;
            int i11 = grayI8.startIndex + (grayI8.stride * i) + i7;
            int i12 = (i9 * i2) + i10;
            int i13 = 0;
            while (i10 < i12) {
                i13 += grayU8.data[i10] & UnsignedBytes.MAX_VALUE;
                i10 += grayU8.stride;
            }
            iArrCheckDeclare[i7] = i13;
            grayI8.data[i11] = (byte) ((i13 + i5) / i2);
        }
        while (true) {
            i++;
            if (i >= i6) {
                return;
            }
            int i14 = grayU8.startIndex + ((i + i4) * grayU8.stride);
            int i15 = grayI8.startIndex + (grayI8.stride * i);
            int i16 = 0;
            while (i16 < grayU8.width) {
                int i17 = iArrCheckDeclare[i16];
                byte[] bArr = grayU8.data;
                int i18 = (i17 - (bArr[i14 - i3] & UnsignedBytes.MAX_VALUE)) + (bArr[i14] & UnsignedBytes.MAX_VALUE);
                iArrCheckDeclare[i16] = i18;
                grayI8.data[i15] = (byte) ((i18 + i5) / i2);
                i16++;
                i14++;
                i15++;
            }
        }
    }

    public static void horizontal(GrayU16 grayU16, GrayI16 grayI16, int i, int i2) {
        int i3 = i2 / 2;
        for (int i4 = 0; i4 < grayU16.height; i4++) {
            int i5 = grayU16.startIndex + (grayU16.stride * i4);
            int i6 = grayI16.startIndex + (grayI16.stride * i4) + i;
            int i7 = i5 + i2;
            int i8 = 0;
            while (i5 < i7) {
                i8 += 65535 & grayU16.data[i5];
                i5++;
            }
            int i9 = i6 + 1;
            grayI16.data[i6] = (short) ((i8 + i3) / i2);
            int i10 = (grayU16.width + i5) - i2;
            while (i5 < i10) {
                short[] sArr = grayU16.data;
                i8 = (i8 - (sArr[i5 - i2] & 65535)) + (sArr[i5] & 65535);
                grayI16.data[i9] = (short) ((i8 + i3) / i2);
                i5++;
                i9++;
            }
        }
    }

    public static void vertical(GrayU16 grayU16, GrayI16 grayI16, int i, int i2, GrowArray growArray) {
        DogArray_I32 dogArray_I32 = (DogArray_I32) BoofMiscOps.checkDeclare(growArray, new ConvolveImageStandard_SB$$ExternalSyntheticLambda0()).grow();
        int i3 = grayU16.stride * i2;
        int i4 = (i2 - i) - 1;
        int i5 = i2 / 2;
        int i6 = grayI16.height - i4;
        int[] iArrCheckDeclare = BoofMiscOps.checkDeclare(dogArray_I32, grayU16.width, false);
        for (int i7 = 0; i7 < grayU16.width; i7++) {
            int i8 = grayU16.startIndex;
            int i9 = grayU16.stride;
            int i10 = i8 + i7;
            int i11 = grayI16.startIndex + (grayI16.stride * i) + i7;
            int i12 = (i9 * i2) + i10;
            int i13 = 0;
            while (i10 < i12) {
                i13 += grayU16.data[i10] & 65535;
                i10 += grayU16.stride;
            }
            iArrCheckDeclare[i7] = i13;
            grayI16.data[i11] = (short) ((i13 + i5) / i2);
        }
        for (int i14 = i + 1; i14 < i6; i14++) {
            int i15 = grayU16.startIndex + ((i14 + i4) * grayU16.stride);
            int i16 = grayI16.startIndex + (grayI16.stride * i14);
            int i17 = 0;
            while (i17 < grayU16.width) {
                int i18 = iArrCheckDeclare[i17];
                short[] sArr = grayU16.data;
                int i19 = (i18 - (sArr[i15 - i3] & 65535)) + (sArr[i15] & 65535);
                iArrCheckDeclare[i17] = i19;
                grayI16.data[i16] = (short) ((i19 + i5) / i2);
                i17++;
                i15++;
                i16++;
            }
        }
    }

    public static void horizontal(GrayF32 grayF32, GrayF32 grayF33, int i, int i2) {
        float f = i2;
        for (int i3 = 0; i3 < grayF32.height; i3++) {
            int i4 = grayF32.startIndex + (grayF32.stride * i3);
            int i5 = grayF33.startIndex + (grayF33.stride * i3) + i;
            int i6 = i4 + i2;
            float f2 = 0.0f;
            while (i4 < i6) {
                f2 += grayF32.data[i4];
                i4++;
            }
            int i7 = i5 + 1;
            grayF33.data[i5] = f2 / f;
            int i8 = (grayF32.width + i4) - i2;
            while (i4 < i8) {
                float[] fArr = grayF32.data;
                f2 = (f2 - fArr[i4 - i2]) + fArr[i4];
                grayF33.data[i7] = f2 / f;
                i4++;
                i7++;
            }
        }
    }

    public static void vertical(GrayF32 grayF32, GrayF32 grayF33, int i, int i2, GrowArray growArray) {
        DogArray_F32 dogArray_F32 = (DogArray_F32) BoofMiscOps.checkDeclare(growArray, new ThresholdNiblackFamily$$ExternalSyntheticLambda0()).grow();
        int i3 = grayF32.stride * i2;
        int i4 = (i2 - i) - 1;
        float f = i2;
        int i5 = grayF33.height - i4;
        float[] fArrCheckDeclare = BoofMiscOps.checkDeclare(dogArray_F32, grayF32.width, false);
        for (int i6 = 0; i6 < grayF32.width; i6++) {
            int i7 = grayF32.startIndex;
            int i8 = grayF32.stride;
            int i9 = i7 + i6;
            int i10 = grayF33.startIndex + (grayF33.stride * i) + i6;
            int i11 = (i8 * i2) + i9;
            float f2 = 0.0f;
            while (i9 < i11) {
                f2 += grayF32.data[i9];
                i9 += grayF32.stride;
            }
            fArrCheckDeclare[i6] = f2;
            grayF33.data[i10] = f2 / f;
        }
        while (true) {
            i++;
            if (i >= i5) {
                return;
            }
            int i12 = grayF32.startIndex + ((i + i4) * grayF32.stride);
            int i13 = grayF33.startIndex + (grayF33.stride * i);
            int i14 = 0;
            while (i14 < grayF32.width) {
                float f3 = fArrCheckDeclare[i14];
                float[] fArr = grayF32.data;
                float f4 = (f3 - fArr[i12 - i3]) + fArr[i12];
                fArrCheckDeclare[i14] = f4;
                grayF33.data[i13] = f4 / f;
                i14++;
                i12++;
                i13++;
            }
        }
    }
}
