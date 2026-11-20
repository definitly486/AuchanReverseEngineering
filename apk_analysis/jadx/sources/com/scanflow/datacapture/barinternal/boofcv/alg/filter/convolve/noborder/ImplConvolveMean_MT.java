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
import com.scanflow.datacapture.barinternal.pabeles.concurrency.ConcurrencyOps;
import com.scanflow.datacapture.barinternal.pabeles.concurrency.GrowArray;
import com.scanflow.datacapture.barinternal.pabeles.concurrency.IntRangeObjectConsumer;
import java.util.function.IntConsumer;

/* JADX INFO: loaded from: classes.dex */
public abstract class ImplConvolveMean_MT {
    public static void horizontal(final GrayU8 grayU8, final GrayI8 grayI8, final int i, final int i2) {
        final int i3 = i2 / 2;
        ConcurrencyOps.loopFor(0, grayU8.height, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.filter.convolve.noborder.ImplConvolveMean_MT$$ExternalSyntheticLambda4
            @Override // java.util.function.IntConsumer
            public final void accept(int i4) {
                ImplConvolveMean_MT.$r8$lambda$0nPwRzCUBJO8YZmLar1pHlIjqNA(grayU8, grayI8, i, i2, i3, i2, i4);
            }
        });
    }

    public static /* synthetic */ void $r8$lambda$0nPwRzCUBJO8YZmLar1pHlIjqNA(GrayU8 grayU8, GrayI8 grayI8, int i, int i2, int i3, int i4, int i5) {
        int i6 = grayU8.startIndex + (grayU8.stride * i5);
        int i7 = grayI8.startIndex + (grayI8.stride * i5) + i;
        int i8 = i6 + i2;
        int i9 = 0;
        while (i6 < i8) {
            i9 += grayU8.data[i6] & UnsignedBytes.MAX_VALUE;
            i6++;
        }
        int i10 = i7 + 1;
        grayI8.data[i7] = (byte) ((i9 + i3) / i4);
        int i11 = (grayU8.width + i6) - i2;
        while (i6 < i11) {
            byte[] bArr = grayU8.data;
            i9 = (i9 - (bArr[i6 - i2] & UnsignedBytes.MAX_VALUE)) + (bArr[i6] & UnsignedBytes.MAX_VALUE);
            grayI8.data[i10] = (byte) ((i9 + i3) / i4);
            i6++;
            i10++;
        }
    }

    public static void vertical(final GrayU8 grayU8, final GrayI8 grayI8, final int i, final int i2, GrowArray growArray) {
        GrowArray growArrayCheckDeclare = BoofMiscOps.checkDeclare(growArray, new ConvolveImageStandard_SB$$ExternalSyntheticLambda0());
        final int i3 = i2 * grayU8.stride;
        final int i4 = (i2 - i) - 1;
        final int i5 = i2 / 2;
        ConcurrencyOps.loopBlocks(i, grayI8.height - i4, i2, growArrayCheckDeclare, new IntRangeObjectConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.filter.convolve.noborder.ImplConvolveMean_MT$$ExternalSyntheticLambda3
            @Override // com.scanflow.datacapture.barinternal.pabeles.concurrency.IntRangeObjectConsumer
            public final void accept(Object obj, int i6, int i7) {
                ImplConvolveMean_MT.m653$r8$lambda$GnenvZeXEla1uxOavuDJbCQX7E(grayU8, i, grayI8, i2, i5, i2, i4, i3, (DogArray_I32) obj, i6, i7);
            }
        });
    }

    /* JADX INFO: renamed from: $r8$lambda$Gne-nvZeXEla1uxOavuDJbCQX7E, reason: not valid java name */
    public static /* synthetic */ void m653$r8$lambda$GnenvZeXEla1uxOavuDJbCQX7E(GrayU8 grayU8, int i, GrayI8 grayI8, int i2, int i3, int i4, int i5, int i6, DogArray_I32 dogArray_I32, int i7, int i8) {
        int[] iArrCheckDeclare = BoofMiscOps.checkDeclare(dogArray_I32, grayU8.width, false);
        for (int i9 = 0; i9 < grayU8.width; i9++) {
            int i10 = grayU8.startIndex;
            int i11 = grayU8.stride;
            int i12 = i10 + ((i7 - i) * i11) + i9;
            int i13 = grayI8.startIndex + (grayI8.stride * i7) + i9;
            int i14 = (i11 * i2) + i12;
            int i15 = 0;
            while (i12 < i14) {
                i15 += grayU8.data[i12] & UnsignedBytes.MAX_VALUE;
                i12 += grayU8.stride;
            }
            iArrCheckDeclare[i9] = i15;
            grayI8.data[i13] = (byte) ((i15 + i3) / i4);
        }
        for (int i16 = i7 + 1; i16 < i8; i16++) {
            int i17 = grayU8.startIndex + ((i16 + i5) * grayU8.stride);
            int i18 = grayI8.startIndex + (grayI8.stride * i16);
            int i19 = 0;
            while (i19 < grayU8.width) {
                int i20 = iArrCheckDeclare[i19];
                byte[] bArr = grayU8.data;
                int i21 = (i20 - (bArr[i17 - i6] & UnsignedBytes.MAX_VALUE)) + (bArr[i17] & UnsignedBytes.MAX_VALUE);
                iArrCheckDeclare[i19] = i21;
                grayI8.data[i18] = (byte) ((i21 + i3) / i4);
                i19++;
                i17++;
                i18++;
            }
        }
    }

    public static void horizontal(final GrayU16 grayU16, final GrayI16 grayI16, final int i, final int i2) {
        final int i3 = i2 / 2;
        ConcurrencyOps.loopFor(0, grayU16.height, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.filter.convolve.noborder.ImplConvolveMean_MT$$ExternalSyntheticLambda2
            @Override // java.util.function.IntConsumer
            public final void accept(int i4) {
                ImplConvolveMean_MT.$r8$lambda$uc2xa_q44mJLRSJ5VABaB5f55sY(grayU16, grayI16, i, i2, i3, i2, i4);
            }
        });
    }

    public static /* synthetic */ void $r8$lambda$uc2xa_q44mJLRSJ5VABaB5f55sY(GrayU16 grayU16, GrayI16 grayI16, int i, int i2, int i3, int i4, int i5) {
        int i6 = grayU16.startIndex + (grayU16.stride * i5);
        int i7 = grayI16.startIndex + (grayI16.stride * i5) + i;
        int i8 = i6 + i2;
        int i9 = 0;
        while (i6 < i8) {
            i9 += 65535 & grayU16.data[i6];
            i6++;
        }
        int i10 = i7 + 1;
        grayI16.data[i7] = (short) ((i9 + i3) / i4);
        int i11 = (grayU16.width + i6) - i2;
        while (i6 < i11) {
            short[] sArr = grayU16.data;
            i9 = (i9 - (sArr[i6 - i2] & 65535)) + (sArr[i6] & 65535);
            grayI16.data[i10] = (short) ((i9 + i3) / i4);
            i6++;
            i10++;
        }
    }

    public static void vertical(final GrayU16 grayU16, final GrayI16 grayI16, final int i, final int i2, GrowArray growArray) {
        GrowArray growArrayCheckDeclare = BoofMiscOps.checkDeclare(growArray, new ConvolveImageStandard_SB$$ExternalSyntheticLambda0());
        final int i3 = i2 * grayU16.stride;
        final int i4 = (i2 - i) - 1;
        final int i5 = i2 / 2;
        ConcurrencyOps.loopBlocks(i, grayI16.height - i4, i2, growArrayCheckDeclare, new IntRangeObjectConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.filter.convolve.noborder.ImplConvolveMean_MT$$ExternalSyntheticLambda5
            @Override // com.scanflow.datacapture.barinternal.pabeles.concurrency.IntRangeObjectConsumer
            public final void accept(Object obj, int i6, int i7) {
                ImplConvolveMean_MT.m655$r8$lambda$_Xg89SiGt0uRugWER9D5wwEMA(grayU16, i, grayI16, i2, i5, i2, i4, i3, (DogArray_I32) obj, i6, i7);
            }
        });
    }

    /* JADX INFO: renamed from: $r8$lambda$_-Xg89S-iGt0uRugWER9D5wwEMA, reason: not valid java name */
    public static /* synthetic */ void m655$r8$lambda$_Xg89SiGt0uRugWER9D5wwEMA(GrayU16 grayU16, int i, GrayI16 grayI16, int i2, int i3, int i4, int i5, int i6, DogArray_I32 dogArray_I32, int i7, int i8) {
        int[] iArrCheckDeclare = BoofMiscOps.checkDeclare(dogArray_I32, grayU16.width, false);
        for (int i9 = 0; i9 < grayU16.width; i9++) {
            int i10 = grayU16.startIndex;
            int i11 = grayU16.stride;
            int i12 = i10 + ((i7 - i) * i11) + i9;
            int i13 = grayI16.startIndex + (grayI16.stride * i7) + i9;
            int i14 = (i11 * i2) + i12;
            int i15 = 0;
            while (i12 < i14) {
                i15 += grayU16.data[i12] & 65535;
                i12 += grayU16.stride;
            }
            iArrCheckDeclare[i9] = i15;
            grayI16.data[i13] = (short) ((i15 + i3) / i4);
        }
        for (int i16 = i7 + 1; i16 < i8; i16++) {
            int i17 = grayU16.startIndex + ((i16 + i5) * grayU16.stride);
            int i18 = grayI16.startIndex + (grayI16.stride * i16);
            int i19 = 0;
            while (i19 < grayU16.width) {
                int i20 = iArrCheckDeclare[i19];
                short[] sArr = grayU16.data;
                int i21 = (i20 - (sArr[i17 - i6] & 65535)) + (sArr[i17] & 65535);
                iArrCheckDeclare[i19] = i21;
                grayI16.data[i18] = (short) ((i21 + i3) / i4);
                i19++;
                i17++;
                i18++;
            }
        }
    }

    public static void horizontal(final GrayF32 grayF32, final GrayF32 grayF33, final int i, final int i2) {
        final float f = i2;
        ConcurrencyOps.loopFor(0, grayF32.height, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.filter.convolve.noborder.ImplConvolveMean_MT$$ExternalSyntheticLambda1
            @Override // java.util.function.IntConsumer
            public final void accept(int i3) {
                ImplConvolveMean_MT.m654$r8$lambda$HsJRtBlBTyrGjeIrXsVP6FDqQo(grayF32, grayF33, i, i2, f, i3);
            }
        });
    }

    /* JADX INFO: renamed from: $r8$lambda$HsJRtBlB-TyrGjeIrXsVP6FDqQo, reason: not valid java name */
    public static /* synthetic */ void m654$r8$lambda$HsJRtBlBTyrGjeIrXsVP6FDqQo(GrayF32 grayF32, GrayF32 grayF33, int i, int i2, float f, int i3) {
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

    public static void vertical(final GrayF32 grayF32, final GrayF32 grayF33, final int i, final int i2, GrowArray growArray) {
        GrowArray growArrayCheckDeclare = BoofMiscOps.checkDeclare(growArray, new ThresholdNiblackFamily$$ExternalSyntheticLambda0());
        final int i3 = i2 * grayF32.stride;
        final int i4 = (i2 - i) - 1;
        final float f = i2;
        ConcurrencyOps.loopBlocks(i, grayF33.height - i4, i2, growArrayCheckDeclare, new IntRangeObjectConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.filter.convolve.noborder.ImplConvolveMean_MT$$ExternalSyntheticLambda0
            @Override // com.scanflow.datacapture.barinternal.pabeles.concurrency.IntRangeObjectConsumer
            public final void accept(Object obj, int i5, int i6) {
                ImplConvolveMean_MT.$r8$lambda$5gPOZPpNtaszvlAdLShrvocKzq0(grayF32, i, grayF33, i2, f, i4, i3, (DogArray_F32) obj, i5, i6);
            }
        });
    }

    public static /* synthetic */ void $r8$lambda$5gPOZPpNtaszvlAdLShrvocKzq0(GrayF32 grayF32, int i, GrayF32 grayF33, int i2, float f, int i3, int i4, DogArray_F32 dogArray_F32, int i5, int i6) {
        float[] fArrCheckDeclare = BoofMiscOps.checkDeclare(dogArray_F32, grayF32.width, false);
        for (int i7 = 0; i7 < grayF32.width; i7++) {
            int i8 = grayF32.startIndex;
            int i9 = grayF32.stride;
            int i10 = i8 + ((i5 - i) * i9) + i7;
            int i11 = grayF33.startIndex + (grayF33.stride * i5) + i7;
            int i12 = (i9 * i2) + i10;
            float f2 = 0.0f;
            while (i10 < i12) {
                f2 += grayF32.data[i10];
                i10 += grayF32.stride;
            }
            fArrCheckDeclare[i7] = f2;
            grayF33.data[i11] = f2 / f;
        }
        for (int i13 = i5 + 1; i13 < i6; i13++) {
            int i14 = grayF32.startIndex + ((i13 + i3) * grayF32.stride);
            int i15 = grayF33.startIndex + (grayF33.stride * i13);
            int i16 = 0;
            while (i16 < grayF32.width) {
                float f3 = fArrCheckDeclare[i16];
                float[] fArr = grayF32.data;
                float f4 = (f3 - fArr[i14 - i4]) + fArr[i14];
                fArrCheckDeclare[i16] = f4;
                grayF33.data[i15] = f4 / f;
                i16++;
                i14++;
                i15++;
            }
        }
    }
}
