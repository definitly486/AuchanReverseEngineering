package com.scanflow.datacapture.barinternal.boofcv.alg.filter.convolve.noborder;

import com.scanflow.datacapture.barinternal.boofcv.misc.BoofMiscOps;
import com.scanflow.datacapture.barinternal.boofcv.struct.convolve.Kernel1D_F32;
import com.scanflow.datacapture.barinternal.boofcv.struct.convolve.Kernel1D_S32;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayF32;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayI16;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayI8;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayU16;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayU8;
import com.scanflow.datacapture.barinternal.org.ddogleg.struct.DogArray_I32;
import com.scanflow.datacapture.barinternal.pabeles.concurrency.ConcurrencyOps;
import com.scanflow.datacapture.barinternal.pabeles.concurrency.GrowArray;
import com.scanflow.datacapture.barinternal.pabeles.concurrency.IntRangeObjectConsumer;
import java.util.Arrays;
import java.util.function.IntConsumer;

/* JADX INFO: loaded from: classes.dex */
public abstract class ConvolveImageStandard_SB_MT {
    public static void horizontal(Kernel1D_F32 kernel1D_F32, final GrayF32 grayF32, final GrayF32 grayF33) {
        final float[] fArr = grayF32.data;
        final float[] fArr2 = grayF33.data;
        final float[] fArr3 = kernel1D_F32.data;
        final int offset = kernel1D_F32.getOffset();
        final int width = kernel1D_F32.getWidth();
        final int width2 = grayF32.getWidth();
        ConcurrencyOps.loopFor(0, grayF32.height, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.filter.convolve.noborder.ConvolveImageStandard_SB_MT$$ExternalSyntheticLambda1
            @Override // java.util.function.IntConsumer
            public final void accept(int i) {
                ConvolveImageStandard_SB_MT.$r8$lambda$zoYq367_MTEaE3PKsPZz1py4LDY(grayF33, offset, grayF32, width2, width, fArr, fArr3, fArr2, i);
            }
        });
    }

    public static /* synthetic */ void $r8$lambda$zoYq367_MTEaE3PKsPZz1py4LDY(GrayF32 grayF32, int i, GrayF32 grayF33, int i2, int i3, float[] fArr, float[] fArr2, float[] fArr3, int i4) {
        int i5 = grayF32.startIndex + (grayF32.stride * i4) + i;
        int i6 = grayF33.startIndex + (i4 * grayF33.stride);
        int i7 = (i2 + i6) - (i3 - 1);
        while (i6 < i7) {
            float f = 0.0f;
            int i8 = 0;
            int i9 = i6;
            while (i8 < i3) {
                f += fArr[i9] * fArr2[i8];
                i8++;
                i9++;
            }
            fArr3[i5] = f;
            i6++;
            i5++;
        }
    }

    public static void vertical(Kernel1D_F32 kernel1D_F32, final GrayF32 grayF32, final GrayF32 grayF33) {
        final float[] fArr = grayF32.data;
        final float[] fArr2 = grayF33.data;
        final float[] fArr3 = kernel1D_F32.data;
        final int offset = kernel1D_F32.getOffset();
        final int width = kernel1D_F32.getWidth();
        final int width2 = grayF33.getWidth();
        ConcurrencyOps.loopFor(offset, grayF33.getHeight() - ((width - offset) - 1), new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.filter.convolve.noborder.ConvolveImageStandard_SB_MT$$ExternalSyntheticLambda0
            @Override // java.util.function.IntConsumer
            public final void accept(int i) {
                ConvolveImageStandard_SB_MT.$r8$lambda$scxwqx4jadWC5F8urfRkdFBhJbE(grayF33, fArr2, width2, width, grayF32, offset, fArr3, fArr, i);
            }
        });
    }

    public static /* synthetic */ void $r8$lambda$scxwqx4jadWC5F8urfRkdFBhJbE(GrayF32 grayF32, float[] fArr, int i, int i2, GrayF32 grayF33, int i3, float[] fArr2, float[] fArr3, int i4) {
        int i5 = grayF32.startIndex + (grayF32.stride * i4);
        Arrays.fill(fArr, i5, i5 + i, 0.0f);
        for (int i6 = 0; i6 < i2; i6++) {
            int i7 = grayF33.startIndex + (((i4 - i3) + i6) * grayF33.stride);
            int i8 = i7 + i;
            float f = fArr2[i6];
            int i9 = i5;
            while (i7 < i8) {
                fArr[i9] = fArr[i9] + (fArr3[i7] * f);
                i7++;
                i9++;
            }
        }
    }

    public static void horizontal(Kernel1D_S32 kernel1D_S32, final GrayU8 grayU8, final GrayI8 grayI8, final int i) {
        final byte[] bArr = grayU8.data;
        final byte[] bArr2 = grayI8.data;
        final int[] iArr = kernel1D_S32.data;
        final int offset = kernel1D_S32.getOffset();
        final int width = kernel1D_S32.getWidth();
        final int i2 = i / 2;
        final int width2 = grayU8.getWidth();
        ConcurrencyOps.loopFor(0, grayU8.height, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.filter.convolve.noborder.ConvolveImageStandard_SB_MT$$ExternalSyntheticLambda4
            @Override // java.util.function.IntConsumer
            public final void accept(int i3) {
                ConvolveImageStandard_SB_MT.$r8$lambda$CHLItFel9YWGPsJHIyOP6OGzNPo(grayI8, offset, grayU8, width2, width, bArr, iArr, bArr2, i2, i, i3);
            }
        });
    }

    public static /* synthetic */ void $r8$lambda$CHLItFel9YWGPsJHIyOP6OGzNPo(GrayI8 grayI8, int i, GrayU8 grayU8, int i2, int i3, byte[] bArr, int[] iArr, byte[] bArr2, int i4, int i5, int i6) {
        int i7 = grayI8.startIndex + (grayI8.stride * i6) + i;
        int i8 = grayU8.startIndex + (i6 * grayU8.stride);
        int i9 = (i2 + i8) - (i3 - 1);
        while (i8 < i9) {
            int i10 = 0;
            int i11 = i8;
            int i12 = 0;
            while (i10 < i3) {
                i12 += (bArr[i11] & 255) * iArr[i10];
                i10++;
                i11++;
            }
            bArr2[i7] = (byte) ((i12 + i4) / i5);
            i8++;
            i7++;
        }
    }

    public static void vertical(Kernel1D_S32 kernel1D_S32, final GrayU8 grayU8, final GrayI8 grayI8, int i, GrowArray growArray) {
        GrowArray growArrayCheckDeclare = BoofMiscOps.checkDeclare(growArray, new ConvolveImageStandard_SB$$ExternalSyntheticLambda0());
        final byte[] bArr = grayU8.data;
        final byte[] bArr2 = grayI8.data;
        final int[] iArr = kernel1D_S32.data;
        final int offset = kernel1D_S32.getOffset();
        final int width = kernel1D_S32.getWidth();
        final int i2 = i / 2;
        final double d = 1.0d / ((double) i);
        final int width2 = grayI8.getWidth();
        ConcurrencyOps.loopBlocks(offset, grayI8.getHeight() - ((width - offset) - 1), growArrayCheckDeclare, new IntRangeObjectConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.filter.convolve.noborder.ConvolveImageStandard_SB_MT$$ExternalSyntheticLambda3
            @Override // com.scanflow.datacapture.barinternal.pabeles.concurrency.IntRangeObjectConsumer
            public final void accept(Object obj, int i3, int i4) {
                ConvolveImageStandard_SB_MT.m644$r8$lambda$QnlXEX3Ijy56wcd0ebmQ31SfkQ(width2, width, iArr, grayU8, offset, bArr, grayI8, bArr2, i2, d, (DogArray_I32) obj, i3, i4);
            }
        });
    }

    /* JADX INFO: renamed from: $r8$lambda$Qnl-XEX3Ijy56wcd0ebmQ31SfkQ, reason: not valid java name */
    public static /* synthetic */ void m644$r8$lambda$QnlXEX3Ijy56wcd0ebmQ31SfkQ(int i, int i2, int[] iArr, GrayU8 grayU8, int i3, byte[] bArr, GrayI8 grayI8, byte[] bArr2, int i4, double d, DogArray_I32 dogArray_I32, int i5, int i6) {
        int[] iArrCheckDeclare = BoofMiscOps.checkDeclare(dogArray_I32, i, true);
        for (int i7 = i5; i7 < i6; i7++) {
            for (int i8 = 0; i8 < i2; i8++) {
                int i9 = iArr[i8];
                int i10 = grayU8.startIndex + (((i7 - i3) + i8) * grayU8.stride);
                int i11 = 0;
                while (i11 < i) {
                    iArrCheckDeclare[i11] = iArrCheckDeclare[i11] + ((bArr[i10] & 255) * i9);
                    i11++;
                    i10++;
                }
            }
            int i12 = grayI8.startIndex + (grayI8.stride * i7);
            int i13 = 0;
            while (i13 < i) {
                bArr2[i12] = (byte) (((double) (iArrCheckDeclare[i13] + i4)) * d);
                i13++;
                i12++;
            }
            Arrays.fill(iArrCheckDeclare, 0, i, 0);
        }
    }

    public static void horizontal(Kernel1D_S32 kernel1D_S32, final GrayU16 grayU16, final GrayI16 grayI16, final int i) {
        final short[] sArr = grayU16.data;
        final short[] sArr2 = grayI16.data;
        final int[] iArr = kernel1D_S32.data;
        final int offset = kernel1D_S32.getOffset();
        final int width = kernel1D_S32.getWidth();
        final int i2 = i / 2;
        final int width2 = grayU16.getWidth();
        ConcurrencyOps.loopFor(0, grayU16.height, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.filter.convolve.noborder.ConvolveImageStandard_SB_MT$$ExternalSyntheticLambda5
            @Override // java.util.function.IntConsumer
            public final void accept(int i3) {
                ConvolveImageStandard_SB_MT.m645$r8$lambda$e4rDyyEbyojipb3SYDz09JSCsU(grayI16, offset, grayU16, width2, width, sArr, iArr, sArr2, i2, i, i3);
            }
        });
    }

    /* JADX INFO: renamed from: $r8$lambda$e4rDyyEbyojip-b3SYDz09JSCsU, reason: not valid java name */
    public static /* synthetic */ void m645$r8$lambda$e4rDyyEbyojipb3SYDz09JSCsU(GrayI16 grayI16, int i, GrayU16 grayU16, int i2, int i3, short[] sArr, int[] iArr, short[] sArr2, int i4, int i5, int i6) {
        int i7 = grayI16.startIndex + (grayI16.stride * i6) + i;
        int i8 = grayU16.startIndex + (i6 * grayU16.stride);
        int i9 = (i2 + i8) - (i3 - 1);
        while (i8 < i9) {
            int i10 = 0;
            int i11 = i8;
            int i12 = 0;
            while (i10 < i3) {
                i12 += (sArr[i11] & 65535) * iArr[i10];
                i10++;
                i11++;
            }
            sArr2[i7] = (short) ((i12 + i4) / i5);
            i8++;
            i7++;
        }
    }

    public static void vertical(Kernel1D_S32 kernel1D_S32, final GrayU16 grayU16, final GrayI16 grayI16, int i, GrowArray growArray) {
        GrowArray growArrayCheckDeclare = BoofMiscOps.checkDeclare(growArray, new ConvolveImageStandard_SB$$ExternalSyntheticLambda0());
        final short[] sArr = grayU16.data;
        final short[] sArr2 = grayI16.data;
        final int[] iArr = kernel1D_S32.data;
        final int offset = kernel1D_S32.getOffset();
        final int width = kernel1D_S32.getWidth();
        final int i2 = i / 2;
        final double d = 1.0d / ((double) i);
        final int width2 = grayI16.getWidth();
        ConcurrencyOps.loopBlocks(offset, grayI16.getHeight() - ((width - offset) - 1), growArrayCheckDeclare, new IntRangeObjectConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.filter.convolve.noborder.ConvolveImageStandard_SB_MT$$ExternalSyntheticLambda2
            @Override // com.scanflow.datacapture.barinternal.pabeles.concurrency.IntRangeObjectConsumer
            public final void accept(Object obj, int i3, int i4) {
                ConvolveImageStandard_SB_MT.m643$r8$lambda$J8J23TtHnWcwZK07ug78yK1ZXA(width2, width, iArr, grayU16, offset, sArr, grayI16, sArr2, i2, d, (DogArray_I32) obj, i3, i4);
            }
        });
    }

    /* JADX INFO: renamed from: $r8$lambda$J8J23T-tHnWcwZK07ug78yK1ZXA, reason: not valid java name */
    public static /* synthetic */ void m643$r8$lambda$J8J23TtHnWcwZK07ug78yK1ZXA(int i, int i2, int[] iArr, GrayU16 grayU16, int i3, short[] sArr, GrayI16 grayI16, short[] sArr2, int i4, double d, DogArray_I32 dogArray_I32, int i5, int i6) {
        int[] iArrCheckDeclare = BoofMiscOps.checkDeclare(dogArray_I32, i, true);
        for (int i7 = i5; i7 < i6; i7++) {
            for (int i8 = 0; i8 < i2; i8++) {
                int i9 = iArr[i8];
                int i10 = grayU16.startIndex + (((i7 - i3) + i8) * grayU16.stride);
                int i11 = 0;
                while (i11 < i) {
                    iArrCheckDeclare[i11] = iArrCheckDeclare[i11] + ((sArr[i10] & 65535) * i9);
                    i11++;
                    i10++;
                }
            }
            int i12 = grayI16.startIndex + (grayI16.stride * i7);
            int i13 = 0;
            while (i13 < i) {
                sArr2[i12] = (short) (((double) (iArrCheckDeclare[i13] + i4)) * d);
                i13++;
                i12++;
            }
            Arrays.fill(iArrCheckDeclare, 0, i, 0);
        }
    }
}
