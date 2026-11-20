package com.scanflow.datacapture.barinternal.boofcv.alg.filter.convolve.noborder;

import com.scanflow.datacapture.barinternal.boofcv.struct.convolve.Kernel1D_F32;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayF32;
import com.scanflow.datacapture.barinternal.pabeles.concurrency.ConcurrencyOps;
import java.util.function.IntConsumer;

/* JADX INFO: loaded from: classes.dex */
public abstract class ConvolveImageUnrolled_SB_MT_F32_F32 {
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

    public static void horizontal3(Kernel1D_F32 kernel1D_F32, final GrayF32 grayF32, final GrayF32 grayF33) {
        final float[] fArr = grayF32.data;
        final float[] fArr2 = grayF33.data;
        float[] fArr3 = kernel1D_F32.data;
        final float f = fArr3[0];
        final float f2 = fArr3[1];
        final float f3 = fArr3[2];
        final int radius = kernel1D_F32.getRadius();
        final int width = grayF32.getWidth();
        ConcurrencyOps.loopFor(0, grayF32.height, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.filter.convolve.noborder.ConvolveImageUnrolled_SB_MT_F32_F32$$ExternalSyntheticLambda1
            @Override // java.util.function.IntConsumer
            public final void accept(int i) {
                ConvolveImageUnrolled_SB_MT_F32_F32.$r8$lambda$7JpHUCzKp7YkofpSyQPtKZ1lDa0(grayF33, radius, grayF32, width, fArr, f, f2, f3, fArr2, i);
            }
        });
    }

    public static /* synthetic */ void $r8$lambda$7JpHUCzKp7YkofpSyQPtKZ1lDa0(GrayF32 grayF32, int i, GrayF32 grayF33, int i2, float[] fArr, float f, float f2, float f3, float[] fArr2, int i3) {
        int i4 = grayF32.startIndex + (grayF32.stride * i3) + i;
        int i5 = (grayF33.startIndex + (i3 * grayF33.stride)) - i;
        int i6 = (i2 + i5) - i;
        int i7 = i5 + i;
        while (i7 < i6) {
            int i8 = i7 + 1;
            fArr2[i4] = (fArr[i7] * f) + (fArr[i8] * f2) + (fArr[i7 + 2] * f3);
            i4++;
            i7 = i8;
        }
    }

    public static void horizontal5(Kernel1D_F32 kernel1D_F32, final GrayF32 grayF32, final GrayF32 grayF33) {
        final float[] fArr = grayF32.data;
        final float[] fArr2 = grayF33.data;
        float[] fArr3 = kernel1D_F32.data;
        final float f = fArr3[0];
        final float f2 = fArr3[1];
        final float f3 = fArr3[2];
        final float f4 = fArr3[3];
        final float f5 = fArr3[4];
        final int radius = kernel1D_F32.getRadius();
        final int width = grayF32.getWidth();
        ConcurrencyOps.loopFor(0, grayF32.height, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.filter.convolve.noborder.ConvolveImageUnrolled_SB_MT_F32_F32$$ExternalSyntheticLambda4
            @Override // java.util.function.IntConsumer
            public final void accept(int i) {
                ConvolveImageUnrolled_SB_MT_F32_F32.m648$r8$lambda$vtrBrxEiBuEOdZHMQ1KKKTDE(grayF33, radius, grayF32, width, fArr, f, f2, f3, f4, f5, fArr2, i);
            }
        });
    }

    /* JADX INFO: renamed from: $r8$lambda$vt-rBrxEiB-uEOdZHM-Q1KKKTDE, reason: not valid java name */
    public static /* synthetic */ void m648$r8$lambda$vtrBrxEiBuEOdZHMQ1KKKTDE(GrayF32 grayF32, int i, GrayF32 grayF33, int i2, float[] fArr, float f, float f2, float f3, float f4, float f5, float[] fArr2, int i3) {
        int i4 = grayF32.startIndex + (grayF32.stride * i3) + i;
        int i5 = (grayF33.startIndex + (i3 * grayF33.stride)) - i;
        int i6 = (i2 + i5) - i;
        int i7 = i5 + i;
        while (i7 < i6) {
            int i8 = i7 + 1;
            float f6 = (fArr[i7] * f) + (fArr[i8] * f2) + (fArr[i7 + 2] * f3);
            fArr2[i4] = f6 + (fArr[i7 + 3] * f4) + (fArr[i7 + 4] * f5);
            i4++;
            i7 = i8;
        }
    }

    public static void horizontal7(Kernel1D_F32 kernel1D_F32, final GrayF32 grayF32, final GrayF32 grayF33) {
        final float[] fArr = grayF32.data;
        final float[] fArr2 = grayF33.data;
        float[] fArr3 = kernel1D_F32.data;
        final float f = fArr3[0];
        final float f2 = fArr3[1];
        final float f3 = fArr3[2];
        final float f4 = fArr3[3];
        final float f5 = fArr3[4];
        final float f6 = fArr3[5];
        final float f7 = fArr3[6];
        final int radius = kernel1D_F32.getRadius();
        final int width = grayF32.getWidth();
        ConcurrencyOps.loopFor(0, grayF32.height, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.filter.convolve.noborder.ConvolveImageUnrolled_SB_MT_F32_F32$$ExternalSyntheticLambda8
            @Override // java.util.function.IntConsumer
            public final void accept(int i) {
                ConvolveImageUnrolled_SB_MT_F32_F32.$r8$lambda$a0Q9zkzyELA7gxbyMdBKqs6YoMg(grayF33, radius, grayF32, width, fArr, f, f2, f3, f4, f5, f6, f7, fArr2, i);
            }
        });
    }

    public static /* synthetic */ void $r8$lambda$a0Q9zkzyELA7gxbyMdBKqs6YoMg(GrayF32 grayF32, int i, GrayF32 grayF33, int i2, float[] fArr, float f, float f2, float f3, float f4, float f5, float f6, float f7, float[] fArr2, int i3) {
        int i4 = grayF32.startIndex + (grayF32.stride * i3) + i;
        int i5 = (grayF33.startIndex + (i3 * grayF33.stride)) - i;
        int i6 = (i2 + i5) - i;
        int i7 = i5 + i;
        while (i7 < i6) {
            int i8 = i7 + 1;
            float f8 = (fArr[i7] * f) + (fArr[i8] * f2) + (fArr[i7 + 2] * f3) + (fArr[i7 + 3] * f4) + (fArr[i7 + 4] * f5);
            fArr2[i4] = f8 + (fArr[i7 + 5] * f6) + (fArr[i7 + 6] * f7);
            i4++;
            i7 = i8;
        }
    }

    public static void horizontal9(Kernel1D_F32 kernel1D_F32, final GrayF32 grayF32, final GrayF32 grayF33) {
        final float[] fArr = grayF32.data;
        final float[] fArr2 = grayF33.data;
        float[] fArr3 = kernel1D_F32.data;
        final float f = fArr3[0];
        final float f2 = fArr3[1];
        final float f3 = fArr3[2];
        final float f4 = fArr3[3];
        final float f5 = fArr3[4];
        final float f6 = fArr3[5];
        final float f7 = fArr3[6];
        final float f8 = fArr3[7];
        final float f9 = fArr3[8];
        final int radius = kernel1D_F32.getRadius();
        final int width = grayF32.getWidth();
        ConcurrencyOps.loopFor(0, grayF32.height, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.filter.convolve.noborder.ConvolveImageUnrolled_SB_MT_F32_F32$$ExternalSyntheticLambda6
            @Override // java.util.function.IntConsumer
            public final void accept(int i) {
                ConvolveImageUnrolled_SB_MT_F32_F32.$r8$lambda$QLr8atkEz95sTfymUgMqDlkX5E8(grayF33, radius, grayF32, width, fArr, f, f2, f3, f4, f5, f6, f7, f8, f9, fArr2, i);
            }
        });
    }

    public static /* synthetic */ void $r8$lambda$QLr8atkEz95sTfymUgMqDlkX5E8(GrayF32 grayF32, int i, GrayF32 grayF33, int i2, float[] fArr, float f, float f2, float f3, float f4, float f5, float f6, float f7, float f8, float f9, float[] fArr2, int i3) {
        int i4 = grayF32.startIndex + (grayF32.stride * i3) + i;
        int i5 = (grayF33.startIndex + (grayF33.stride * i3)) - i;
        int i6 = (i2 + i5) - i;
        int i7 = i5 + i;
        while (i7 < i6) {
            int i8 = i7 + 1;
            float f10 = (fArr[i7] * f) + (fArr[i8] * f2) + (fArr[i7 + 2] * f3) + (fArr[i7 + 3] * f4) + (fArr[i7 + 4] * f5) + (fArr[i7 + 5] * f6) + (fArr[i7 + 6] * f7);
            fArr2[i4] = f10 + (fArr[i7 + 7] * f8) + (fArr[i7 + 8] * f9);
            i4++;
            i7 = i8;
        }
    }

    public static void horizontal11(Kernel1D_F32 kernel1D_F32, final GrayF32 grayF32, final GrayF32 grayF33) {
        final float[] fArr = grayF32.data;
        final float[] fArr2 = grayF33.data;
        float[] fArr3 = kernel1D_F32.data;
        final float f = fArr3[0];
        final float f2 = fArr3[1];
        final float f3 = fArr3[2];
        final float f4 = fArr3[3];
        final float f5 = fArr3[4];
        final float f6 = fArr3[5];
        final float f7 = fArr3[6];
        final float f8 = fArr3[7];
        final float f9 = fArr3[8];
        final float f10 = fArr3[9];
        final float f11 = fArr3[10];
        final int radius = kernel1D_F32.getRadius();
        final int width = grayF32.getWidth();
        ConcurrencyOps.loopFor(0, grayF32.height, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.filter.convolve.noborder.ConvolveImageUnrolled_SB_MT_F32_F32$$ExternalSyntheticLambda3
            @Override // java.util.function.IntConsumer
            public final void accept(int i) {
                ConvolveImageUnrolled_SB_MT_F32_F32.$r8$lambda$iEbXn3Oz2NfvK94P5muRbmbu24U(grayF33, radius, grayF32, width, fArr, f, f2, f3, f4, f5, f6, f7, f8, f9, f10, f11, fArr2, i);
            }
        });
    }

    public static /* synthetic */ void $r8$lambda$iEbXn3Oz2NfvK94P5muRbmbu24U(GrayF32 grayF32, int i, GrayF32 grayF33, int i2, float[] fArr, float f, float f2, float f3, float f4, float f5, float f6, float f7, float f8, float f9, float f10, float f11, float[] fArr2, int i3) {
        int i4 = grayF32.startIndex + (grayF32.stride * i3) + i;
        int i5 = (grayF33.startIndex + (grayF33.stride * i3)) - i;
        int i6 = (i2 + i5) - i;
        int i7 = i5 + i;
        while (i7 < i6) {
            int i8 = i7 + 1;
            float f12 = (fArr[i7] * f) + (fArr[i8] * f2) + (fArr[i7 + 2] * f3) + (fArr[i7 + 3] * f4) + (fArr[i7 + 4] * f5) + (fArr[i7 + 5] * f6) + (fArr[i7 + 6] * f7) + (fArr[i7 + 7] * f8) + (fArr[i7 + 8] * f9);
            fArr2[i4] = f12 + (fArr[i7 + 9] * f10) + (fArr[i7 + 10] * f11);
            i4++;
            i7 = i8;
        }
    }

    public static void vertical3(Kernel1D_F32 kernel1D_F32, final GrayF32 grayF32, final GrayF32 grayF33) {
        final float[] fArr = grayF32.data;
        final float[] fArr2 = grayF33.data;
        float[] fArr3 = kernel1D_F32.data;
        final float f = fArr3[0];
        final float f2 = fArr3[1];
        final float f3 = fArr3[2];
        final int radius = kernel1D_F32.getRadius();
        final int width = grayF33.getWidth();
        ConcurrencyOps.loopFor(radius, grayF33.getHeight() - radius, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.filter.convolve.noborder.ConvolveImageUnrolled_SB_MT_F32_F32$$ExternalSyntheticLambda2
            @Override // java.util.function.IntConsumer
            public final void accept(int i) {
                ConvolveImageUnrolled_SB_MT_F32_F32.$r8$lambda$hqv83tTs6_GwgzZly0zQz8nKI8Y(grayF33, grayF32, radius, width, fArr, f, f2, f3, fArr2, i);
            }
        });
    }

    public static /* synthetic */ void $r8$lambda$hqv83tTs6_GwgzZly0zQz8nKI8Y(GrayF32 grayF32, GrayF32 grayF33, int i, int i2, float[] fArr, float f, float f2, float f3, float[] fArr2, int i3) {
        int i4 = grayF32.startIndex + (grayF32.stride * i3);
        int i5 = grayF33.startIndex + ((i3 - i) * grayF33.stride);
        int i6 = i2 + i5;
        while (i5 < i6) {
            float f4 = fArr[i5] * f;
            int i7 = grayF33.stride;
            int i8 = i5 + i7;
            fArr2[i4] = f4 + (fArr[i8] * f2) + (fArr[i8 + i7] * f3);
            i5++;
            i4++;
        }
    }

    public static void vertical5(Kernel1D_F32 kernel1D_F32, final GrayF32 grayF32, final GrayF32 grayF33) {
        final float[] fArr = grayF32.data;
        final float[] fArr2 = grayF33.data;
        float[] fArr3 = kernel1D_F32.data;
        final float f = fArr3[0];
        final float f2 = fArr3[1];
        final float f3 = fArr3[2];
        final float f4 = fArr3[3];
        final float f5 = fArr3[4];
        final int radius = kernel1D_F32.getRadius();
        final int width = grayF33.getWidth();
        ConcurrencyOps.loopFor(radius, grayF33.getHeight() - radius, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.filter.convolve.noborder.ConvolveImageUnrolled_SB_MT_F32_F32$$ExternalSyntheticLambda9
            @Override // java.util.function.IntConsumer
            public final void accept(int i) {
                ConvolveImageUnrolled_SB_MT_F32_F32.m647$r8$lambda$WcLprpi05aRbSuN8lgkehHUoNE(grayF33, grayF32, radius, width, fArr, f, f2, f3, f4, f5, fArr2, i);
            }
        });
    }

    /* JADX INFO: renamed from: $r8$lambda$WcLprpi05aRbSuN8lgkehHU-oNE, reason: not valid java name */
    public static /* synthetic */ void m647$r8$lambda$WcLprpi05aRbSuN8lgkehHUoNE(GrayF32 grayF32, GrayF32 grayF33, int i, int i2, float[] fArr, float f, float f2, float f3, float f4, float f5, float[] fArr2, int i3) {
        int i4 = grayF32.startIndex + (grayF32.stride * i3);
        int i5 = grayF33.startIndex + ((i3 - i) * grayF33.stride);
        int i6 = i2 + i5;
        while (i5 < i6) {
            float f6 = fArr[i5] * f;
            int i7 = grayF33.stride;
            int i8 = i5 + i7;
            float f7 = f6 + (fArr[i8] * f2);
            int i9 = i8 + i7;
            float f8 = f7 + (fArr[i9] * f3);
            int i10 = i9 + i7;
            fArr2[i4] = f8 + (fArr[i10] * f4) + (fArr[i10 + i7] * f5);
            i5++;
            i4++;
        }
    }

    public static void vertical7(Kernel1D_F32 kernel1D_F32, final GrayF32 grayF32, final GrayF32 grayF33) {
        final float[] fArr = grayF32.data;
        final float[] fArr2 = grayF33.data;
        float[] fArr3 = kernel1D_F32.data;
        final float f = fArr3[0];
        final float f2 = fArr3[1];
        final float f3 = fArr3[2];
        final float f4 = fArr3[3];
        final float f5 = fArr3[4];
        final float f6 = fArr3[5];
        final float f7 = fArr3[6];
        final int radius = kernel1D_F32.getRadius();
        final int width = grayF33.getWidth();
        ConcurrencyOps.loopFor(radius, grayF33.getHeight() - radius, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.filter.convolve.noborder.ConvolveImageUnrolled_SB_MT_F32_F32$$ExternalSyntheticLambda5
            @Override // java.util.function.IntConsumer
            public final void accept(int i) {
                ConvolveImageUnrolled_SB_MT_F32_F32.m646$r8$lambda$MpQFEUsSsJ8rSDcZMq_HlRHqTo(grayF33, grayF32, radius, width, fArr, f, f2, f3, f4, f5, f6, f7, fArr2, i);
            }
        });
    }

    /* JADX INFO: renamed from: $r8$lambda$MpQFEUsSsJ8rSDcZMq_Hl-RHqTo, reason: not valid java name */
    public static /* synthetic */ void m646$r8$lambda$MpQFEUsSsJ8rSDcZMq_HlRHqTo(GrayF32 grayF32, GrayF32 grayF33, int i, int i2, float[] fArr, float f, float f2, float f3, float f4, float f5, float f6, float f7, float[] fArr2, int i3) {
        int i4 = grayF32.startIndex + (grayF32.stride * i3);
        int i5 = grayF33.startIndex + ((i3 - i) * grayF33.stride);
        int i6 = i2 + i5;
        while (i5 < i6) {
            float f8 = fArr[i5] * f;
            int i7 = grayF33.stride;
            int i8 = i5 + i7;
            float f9 = f8 + (fArr[i8] * f2);
            int i9 = i8 + i7;
            float f10 = f9 + (fArr[i9] * f3);
            int i10 = i9 + i7;
            float f11 = f10 + (fArr[i10] * f4);
            int i11 = i10 + i7;
            float f12 = f11 + (fArr[i11] * f5);
            int i12 = i11 + i7;
            fArr2[i4] = f12 + (fArr[i12] * f6) + (fArr[i12 + i7] * f7);
            i5++;
            i4++;
        }
    }

    public static void vertical9(Kernel1D_F32 kernel1D_F32, final GrayF32 grayF32, final GrayF32 grayF33) {
        final float[] fArr = grayF32.data;
        final float[] fArr2 = grayF33.data;
        float[] fArr3 = kernel1D_F32.data;
        final float f = fArr3[0];
        final float f2 = fArr3[1];
        final float f3 = fArr3[2];
        final float f4 = fArr3[3];
        final float f5 = fArr3[4];
        final float f6 = fArr3[5];
        final float f7 = fArr3[6];
        final float f8 = fArr3[7];
        final float f9 = fArr3[8];
        final int radius = kernel1D_F32.getRadius();
        final int width = grayF33.getWidth();
        ConcurrencyOps.loopFor(radius, grayF33.getHeight() - radius, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.filter.convolve.noborder.ConvolveImageUnrolled_SB_MT_F32_F32$$ExternalSyntheticLambda0
            @Override // java.util.function.IntConsumer
            public final void accept(int i) {
                ConvolveImageUnrolled_SB_MT_F32_F32.$r8$lambda$CpC7dBhcFaaATRRq8rXopYigAIY(grayF33, grayF32, radius, width, fArr, f, f2, f3, f4, f5, f6, f7, f8, f9, fArr2, i);
            }
        });
    }

    public static /* synthetic */ void $r8$lambda$CpC7dBhcFaaATRRq8rXopYigAIY(GrayF32 grayF32, GrayF32 grayF33, int i, int i2, float[] fArr, float f, float f2, float f3, float f4, float f5, float f6, float f7, float f8, float f9, float[] fArr2, int i3) {
        int i4 = grayF32.startIndex + (grayF32.stride * i3);
        int i5 = grayF33.startIndex + ((i3 - i) * grayF33.stride);
        int i6 = i2 + i5;
        while (i5 < i6) {
            float f10 = fArr[i5] * f;
            int i7 = grayF33.stride;
            int i8 = i5 + i7;
            float f11 = f10 + (fArr[i8] * f2);
            int i9 = i8 + i7;
            float f12 = f11 + (fArr[i9] * f3);
            int i10 = i9 + i7;
            float f13 = f12 + (fArr[i10] * f4);
            int i11 = i10 + i7;
            float f14 = f13 + (fArr[i11] * f5);
            int i12 = i11 + i7;
            float f15 = f14 + (fArr[i12] * f6);
            int i13 = i12 + i7;
            float f16 = f15 + (fArr[i13] * f7);
            int i14 = i13 + i7;
            fArr2[i4] = f16 + (fArr[i14] * f8) + (fArr[i14 + i7] * f9);
            i5++;
            i4++;
        }
    }

    public static void vertical11(Kernel1D_F32 kernel1D_F32, final GrayF32 grayF32, final GrayF32 grayF33) {
        final float[] fArr = grayF32.data;
        final float[] fArr2 = grayF33.data;
        float[] fArr3 = kernel1D_F32.data;
        final float f = fArr3[0];
        final float f2 = fArr3[1];
        final float f3 = fArr3[2];
        final float f4 = fArr3[3];
        final float f5 = fArr3[4];
        final float f6 = fArr3[5];
        final float f7 = fArr3[6];
        final float f8 = fArr3[7];
        final float f9 = fArr3[8];
        final float f10 = fArr3[9];
        final float f11 = fArr3[10];
        final int radius = kernel1D_F32.getRadius();
        final int width = grayF33.getWidth();
        ConcurrencyOps.loopFor(radius, grayF33.getHeight() - radius, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.filter.convolve.noborder.ConvolveImageUnrolled_SB_MT_F32_F32$$ExternalSyntheticLambda7
            @Override // java.util.function.IntConsumer
            public final void accept(int i) {
                ConvolveImageUnrolled_SB_MT_F32_F32.$r8$lambda$1Me8OYqTdPI6FrNFMs4HDsGJO3Q(grayF33, grayF32, radius, width, fArr, f, f2, f3, f4, f5, f6, f7, f8, f9, f10, f11, fArr2, i);
            }
        });
    }

    public static /* synthetic */ void $r8$lambda$1Me8OYqTdPI6FrNFMs4HDsGJO3Q(GrayF32 grayF32, GrayF32 grayF33, int i, int i2, float[] fArr, float f, float f2, float f3, float f4, float f5, float f6, float f7, float f8, float f9, float f10, float f11, float[] fArr2, int i3) {
        int i4 = grayF32.startIndex + (grayF32.stride * i3);
        int i5 = grayF33.startIndex + ((i3 - i) * grayF33.stride);
        int i6 = i2 + i5;
        while (i5 < i6) {
            float f12 = fArr[i5] * f;
            int i7 = grayF33.stride;
            int i8 = i5 + i7;
            float f13 = f12 + (fArr[i8] * f2);
            int i9 = i8 + i7;
            float f14 = f13 + (fArr[i9] * f3);
            int i10 = i9 + i7;
            float f15 = f14 + (fArr[i10] * f4);
            int i11 = i10 + i7;
            float f16 = f15 + (fArr[i11] * f5);
            int i12 = i11 + i7;
            float f17 = f16 + (fArr[i12] * f6);
            int i13 = i12 + i7;
            float f18 = f17 + (fArr[i13] * f7);
            int i14 = i13 + i7;
            float f19 = f18 + (fArr[i14] * f8);
            int i15 = i14 + i7;
            float f20 = f19 + (fArr[i15] * f9);
            int i16 = i15 + i7;
            fArr2[i4] = f20 + (fArr[i16] * f10) + (fArr[i16 + i7] * f11);
            i5++;
            i4++;
        }
    }
}
