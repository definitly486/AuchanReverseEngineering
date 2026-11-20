package com.scanflow.datacapture.barinternal.boofcv.alg.filter.convolve.noborder;

import com.scanflow.datacapture.barinternal.boofcv.struct.convolve.Kernel1D_S32;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayI16;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayU16;
import com.scanflow.datacapture.barinternal.pabeles.concurrency.ConcurrencyOps;
import com.scanflow.datacapture.barinternal.pabeles.concurrency.GrowArray;
import java.util.function.IntConsumer;

/* JADX INFO: loaded from: classes.dex */
public abstract class ConvolveImageUnrolled_SB_MT_U16_I16_Div {
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

    public static void horizontal3(Kernel1D_S32 kernel1D_S32, final GrayU16 grayU16, final GrayI16 grayI16, final int i) {
        final short[] sArr = grayU16.data;
        final short[] sArr2 = grayI16.data;
        int[] iArr = kernel1D_S32.data;
        final int i2 = iArr[0];
        final int i3 = iArr[1];
        final int i4 = iArr[2];
        final int radius = kernel1D_S32.getRadius();
        final int width = grayU16.getWidth();
        final int i5 = i / 2;
        ConcurrencyOps.loopFor(0, grayU16.height, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.filter.convolve.noborder.ConvolveImageUnrolled_SB_MT_U16_I16_Div$$ExternalSyntheticLambda8
            @Override // java.util.function.IntConsumer
            public final void accept(int i6) {
                ConvolveImageUnrolled_SB_MT_U16_I16_Div.$r8$lambda$VLKMLMzirolHVV7EjoEhRy2_9zI(grayI16, radius, grayU16, width, sArr, i2, i3, i4, sArr2, i5, i, i6);
            }
        });
    }

    public static /* synthetic */ void $r8$lambda$VLKMLMzirolHVV7EjoEhRy2_9zI(GrayI16 grayI16, int i, GrayU16 grayU16, int i2, short[] sArr, int i3, int i4, int i5, short[] sArr2, int i6, int i7, int i8) {
        int i9 = grayI16.startIndex + (grayI16.stride * i8) + i;
        int i10 = (grayU16.startIndex + (i8 * grayU16.stride)) - i;
        int i11 = (i2 + i10) - i;
        int i12 = i10 + i;
        while (i12 < i11) {
            int i13 = i12 + 1;
            sArr2[i9] = (short) ((((((sArr[i12] & 65535) * i3) + ((sArr[i13] & 65535) * i4)) + ((sArr[i12 + 2] & 65535) * i5)) + i6) / i7);
            i9++;
            i12 = i13;
        }
    }

    public static void horizontal5(Kernel1D_S32 kernel1D_S32, final GrayU16 grayU16, final GrayI16 grayI16, final int i) {
        final short[] sArr = grayU16.data;
        final short[] sArr2 = grayI16.data;
        int[] iArr = kernel1D_S32.data;
        final int i2 = iArr[0];
        final int i3 = iArr[1];
        final int i4 = iArr[2];
        final int i5 = iArr[3];
        final int i6 = iArr[4];
        final int radius = kernel1D_S32.getRadius();
        final int width = grayU16.getWidth();
        final int i7 = i / 2;
        ConcurrencyOps.loopFor(0, grayU16.height, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.filter.convolve.noborder.ConvolveImageUnrolled_SB_MT_U16_I16_Div$$ExternalSyntheticLambda4
            @Override // java.util.function.IntConsumer
            public final void accept(int i8) {
                ConvolveImageUnrolled_SB_MT_U16_I16_Div.$r8$lambda$4YIDOJ_6L7Ocgo4sGYuHYHG0WNw(grayI16, radius, grayU16, width, sArr, i2, i3, i4, i5, i6, sArr2, i7, i, i8);
            }
        });
    }

    public static /* synthetic */ void $r8$lambda$4YIDOJ_6L7Ocgo4sGYuHYHG0WNw(GrayI16 grayI16, int i, GrayU16 grayU16, int i2, short[] sArr, int i3, int i4, int i5, int i6, int i7, short[] sArr2, int i8, int i9, int i10) {
        int i11 = grayI16.startIndex + (grayI16.stride * i10) + i;
        int i12 = (grayU16.startIndex + (grayU16.stride * i10)) - i;
        int i13 = (i2 + i12) - i;
        int i14 = i12 + i;
        while (i14 < i13) {
            int i15 = i14 + 1;
            int i16 = ((sArr[i14] & 65535) * i3) + ((sArr[i15] & 65535) * i4) + ((sArr[i14 + 2] & 65535) * i5);
            sArr2[i11] = (short) ((((i16 + ((sArr[i14 + 3] & 65535) * i6)) + ((sArr[i14 + 4] & 65535) * i7)) + i8) / i9);
            i11++;
            i14 = i15;
        }
    }

    public static void horizontal7(Kernel1D_S32 kernel1D_S32, final GrayU16 grayU16, final GrayI16 grayI16, final int i) {
        final short[] sArr = grayU16.data;
        final short[] sArr2 = grayI16.data;
        int[] iArr = kernel1D_S32.data;
        final int i2 = iArr[0];
        final int i3 = iArr[1];
        final int i4 = iArr[2];
        final int i5 = iArr[3];
        final int i6 = iArr[4];
        final int i7 = iArr[5];
        final int i8 = iArr[6];
        final int radius = kernel1D_S32.getRadius();
        final int width = grayU16.getWidth();
        final int i9 = i / 2;
        ConcurrencyOps.loopFor(0, grayU16.height, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.filter.convolve.noborder.ConvolveImageUnrolled_SB_MT_U16_I16_Div$$ExternalSyntheticLambda5
            @Override // java.util.function.IntConsumer
            public final void accept(int i10) {
                ConvolveImageUnrolled_SB_MT_U16_I16_Div.$r8$lambda$1bQNOuvq_9gD1euore9d_2YN7Tg(grayI16, radius, grayU16, width, sArr, i2, i3, i4, i5, i6, i7, i8, sArr2, i9, i, i10);
            }
        });
    }

    public static /* synthetic */ void $r8$lambda$1bQNOuvq_9gD1euore9d_2YN7Tg(GrayI16 grayI16, int i, GrayU16 grayU16, int i2, short[] sArr, int i3, int i4, int i5, int i6, int i7, int i8, int i9, short[] sArr2, int i10, int i11, int i12) {
        int i13 = grayI16.startIndex + (grayI16.stride * i12) + i;
        int i14 = (grayU16.startIndex + (grayU16.stride * i12)) - i;
        int i15 = (i2 + i14) - i;
        int i16 = i14 + i;
        while (i16 < i15) {
            int i17 = i16 + 1;
            int i18 = ((sArr[i16] & 65535) * i3) + ((sArr[i17] & 65535) * i4) + ((sArr[i16 + 2] & 65535) * i5) + ((sArr[i16 + 3] & 65535) * i6) + ((sArr[i16 + 4] & 65535) * i7);
            sArr2[i13] = (short) ((((i18 + ((sArr[i16 + 5] & 65535) * i8)) + ((sArr[i16 + 6] & 65535) * i9)) + i10) / i11);
            i13++;
            i16 = i17;
        }
    }

    public static void horizontal9(Kernel1D_S32 kernel1D_S32, final GrayU16 grayU16, final GrayI16 grayI16, final int i) {
        final short[] sArr = grayU16.data;
        final short[] sArr2 = grayI16.data;
        int[] iArr = kernel1D_S32.data;
        final int i2 = iArr[0];
        final int i3 = iArr[1];
        final int i4 = iArr[2];
        final int i5 = iArr[3];
        final int i6 = iArr[4];
        final int i7 = iArr[5];
        final int i8 = iArr[6];
        final int i9 = iArr[7];
        final int i10 = iArr[8];
        final int radius = kernel1D_S32.getRadius();
        final int width = grayU16.getWidth();
        final int i11 = i / 2;
        ConcurrencyOps.loopFor(0, grayU16.height, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.filter.convolve.noborder.ConvolveImageUnrolled_SB_MT_U16_I16_Div$$ExternalSyntheticLambda6
            @Override // java.util.function.IntConsumer
            public final void accept(int i12) {
                ConvolveImageUnrolled_SB_MT_U16_I16_Div.m649$r8$lambda$B01Odqnq9yPBdwL9C11QijP2n4(grayI16, radius, grayU16, width, sArr, i2, i3, i4, i5, i6, i7, i8, i9, i10, sArr2, i11, i, i12);
            }
        });
    }

    /* JADX INFO: renamed from: $r8$lambda$B01Odqnq9yPBdwL9-C11QijP2n4, reason: not valid java name */
    public static /* synthetic */ void m649$r8$lambda$B01Odqnq9yPBdwL9C11QijP2n4(GrayI16 grayI16, int i, GrayU16 grayU16, int i2, short[] sArr, int i3, int i4, int i5, int i6, int i7, int i8, int i9, int i10, int i11, short[] sArr2, int i12, int i13, int i14) {
        int i15 = grayI16.startIndex + (grayI16.stride * i14) + i;
        int i16 = (grayU16.startIndex + (grayU16.stride * i14)) - i;
        int i17 = (i2 + i16) - i;
        int i18 = i16 + i;
        while (i18 < i17) {
            int i19 = i18 + 1;
            int i20 = ((sArr[i18] & 65535) * i3) + ((sArr[i19] & 65535) * i4) + ((sArr[i18 + 2] & 65535) * i5) + ((sArr[i18 + 3] & 65535) * i6) + ((sArr[i18 + 4] & 65535) * i7) + ((sArr[i18 + 5] & 65535) * i8) + ((sArr[i18 + 6] & 65535) * i9);
            sArr2[i15] = (short) ((((i20 + ((sArr[i18 + 7] & 65535) * i10)) + ((sArr[i18 + 8] & 65535) * i11)) + i12) / i13);
            i15++;
            i18 = i19;
        }
    }

    public static void horizontal11(Kernel1D_S32 kernel1D_S32, final GrayU16 grayU16, final GrayI16 grayI16, final int i) {
        final short[] sArr = grayU16.data;
        final short[] sArr2 = grayI16.data;
        int[] iArr = kernel1D_S32.data;
        final int i2 = iArr[0];
        final int i3 = iArr[1];
        final int i4 = iArr[2];
        final int i5 = iArr[3];
        final int i6 = iArr[4];
        final int i7 = iArr[5];
        final int i8 = iArr[6];
        final int i9 = iArr[7];
        final int i10 = iArr[8];
        final int i11 = iArr[9];
        final int i12 = iArr[10];
        final int radius = kernel1D_S32.getRadius();
        final int width = grayU16.getWidth();
        final int i13 = i / 2;
        ConcurrencyOps.loopFor(0, grayU16.height, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.filter.convolve.noborder.ConvolveImageUnrolled_SB_MT_U16_I16_Div$$ExternalSyntheticLambda3
            @Override // java.util.function.IntConsumer
            public final void accept(int i14) {
                ConvolveImageUnrolled_SB_MT_U16_I16_Div.$r8$lambda$Copfpi4pqFEHlN3zVnFb7aPBbDc(grayI16, radius, grayU16, width, sArr, i2, i3, i4, i5, i6, i7, i8, i9, i10, i11, i12, sArr2, i13, i, i14);
            }
        });
    }

    public static /* synthetic */ void $r8$lambda$Copfpi4pqFEHlN3zVnFb7aPBbDc(GrayI16 grayI16, int i, GrayU16 grayU16, int i2, short[] sArr, int i3, int i4, int i5, int i6, int i7, int i8, int i9, int i10, int i11, int i12, int i13, short[] sArr2, int i14, int i15, int i16) {
        int i17 = grayI16.startIndex + (grayI16.stride * i16) + i;
        int i18 = (grayU16.startIndex + (grayU16.stride * i16)) - i;
        int i19 = (i2 + i18) - i;
        int i20 = i18 + i;
        while (i20 < i19) {
            int i21 = i20 + 1;
            int i22 = ((sArr[i20] & 65535) * i3) + ((sArr[i21] & 65535) * i4) + ((sArr[i20 + 2] & 65535) * i5) + ((sArr[i20 + 3] & 65535) * i6) + ((sArr[i20 + 4] & 65535) * i7) + ((sArr[i20 + 5] & 65535) * i8) + ((sArr[i20 + 6] & 65535) * i9) + ((sArr[i20 + 7] & 65535) * i10) + ((sArr[i20 + 8] & 65535) * i11);
            sArr2[i17] = (short) ((((i22 + ((sArr[i20 + 9] & 65535) * i12)) + ((sArr[i20 + 10] & 65535) * i13)) + i14) / i15);
            i17++;
            i20 = i21;
        }
    }

    public static void vertical3(Kernel1D_S32 kernel1D_S32, final GrayU16 grayU16, final GrayI16 grayI16, final int i, GrowArray growArray) {
        final short[] sArr = grayU16.data;
        final short[] sArr2 = grayI16.data;
        int[] iArr = kernel1D_S32.data;
        final int i2 = iArr[0];
        final int i3 = iArr[1];
        final int i4 = iArr[2];
        final int radius = kernel1D_S32.getRadius();
        final int width = grayI16.getWidth();
        final int i5 = i / 2;
        ConcurrencyOps.loopFor(radius, grayI16.getHeight() - radius, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.filter.convolve.noborder.ConvolveImageUnrolled_SB_MT_U16_I16_Div$$ExternalSyntheticLambda7
            @Override // java.util.function.IntConsumer
            public final void accept(int i6) {
                ConvolveImageUnrolled_SB_MT_U16_I16_Div.m650$r8$lambda$NkZy6T0ZGoAYOnIMmonci_qrw(grayI16, grayU16, radius, width, sArr, i2, i3, i4, sArr2, i5, i, i6);
            }
        });
    }

    /* JADX INFO: renamed from: $r8$lambda$NkZy6T--0ZGoAYOnIMmonci_qrw, reason: not valid java name */
    public static /* synthetic */ void m650$r8$lambda$NkZy6T0ZGoAYOnIMmonci_qrw(GrayI16 grayI16, GrayU16 grayU16, int i, int i2, short[] sArr, int i3, int i4, int i5, short[] sArr2, int i6, int i7, int i8) {
        int i9 = grayI16.startIndex + (grayI16.stride * i8);
        int i10 = grayU16.startIndex + ((i8 - i) * grayU16.stride);
        int i11 = i2 + i10;
        while (i10 < i11) {
            int i12 = (sArr[i10] & 65535) * i3;
            int i13 = grayU16.stride;
            int i14 = i10 + i13;
            sArr2[i9] = (short) ((((i12 + ((sArr[i14] & 65535) * i4)) + ((65535 & sArr[i14 + i13]) * i5)) + i6) / i7);
            i10++;
            i9++;
        }
    }

    public static void vertical5(Kernel1D_S32 kernel1D_S32, final GrayU16 grayU16, final GrayI16 grayI16, final int i, GrowArray growArray) {
        final short[] sArr = grayU16.data;
        final short[] sArr2 = grayI16.data;
        int[] iArr = kernel1D_S32.data;
        final int i2 = iArr[0];
        final int i3 = iArr[1];
        final int i4 = iArr[2];
        final int i5 = iArr[3];
        final int i6 = iArr[4];
        final int radius = kernel1D_S32.getRadius();
        final int width = grayI16.getWidth();
        final int i7 = i / 2;
        ConcurrencyOps.loopFor(radius, grayI16.getHeight() - radius, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.filter.convolve.noborder.ConvolveImageUnrolled_SB_MT_U16_I16_Div$$ExternalSyntheticLambda0
            @Override // java.util.function.IntConsumer
            public final void accept(int i8) {
                ConvolveImageUnrolled_SB_MT_U16_I16_Div.$r8$lambda$ktpLg4R6e5UEgn_ahvPnQK3glsg(grayI16, grayU16, radius, width, sArr, i2, i3, i4, i5, i6, sArr2, i7, i, i8);
            }
        });
    }

    public static /* synthetic */ void $r8$lambda$ktpLg4R6e5UEgn_ahvPnQK3glsg(GrayI16 grayI16, GrayU16 grayU16, int i, int i2, short[] sArr, int i3, int i4, int i5, int i6, int i7, short[] sArr2, int i8, int i9, int i10) {
        int i11 = grayI16.startIndex + (grayI16.stride * i10);
        int i12 = grayU16.startIndex + ((i10 - i) * grayU16.stride);
        int i13 = i2 + i12;
        while (i12 < i13) {
            int i14 = (sArr[i12] & 65535) * i3;
            int i15 = grayU16.stride;
            int i16 = i12 + i15;
            int i17 = i14 + ((sArr[i16] & 65535) * i4);
            int i18 = i16 + i15;
            int i19 = i17 + ((sArr[i18] & 65535) * i5);
            int i20 = i18 + i15;
            sArr2[i11] = (short) ((((i19 + ((sArr[i20] & 65535) * i6)) + ((65535 & sArr[i20 + i15]) * i7)) + i8) / i9);
            i12++;
            i11++;
        }
    }

    public static void vertical7(Kernel1D_S32 kernel1D_S32, final GrayU16 grayU16, final GrayI16 grayI16, final int i, GrowArray growArray) {
        final short[] sArr = grayU16.data;
        final short[] sArr2 = grayI16.data;
        int[] iArr = kernel1D_S32.data;
        final int i2 = iArr[0];
        final int i3 = iArr[1];
        final int i4 = iArr[2];
        final int i5 = iArr[3];
        final int i6 = iArr[4];
        final int i7 = iArr[5];
        final int i8 = iArr[6];
        final int radius = kernel1D_S32.getRadius();
        final int width = grayI16.getWidth();
        final int i9 = i / 2;
        ConcurrencyOps.loopFor(radius, grayI16.getHeight() - radius, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.filter.convolve.noborder.ConvolveImageUnrolled_SB_MT_U16_I16_Div$$ExternalSyntheticLambda1
            @Override // java.util.function.IntConsumer
            public final void accept(int i10) {
                ConvolveImageUnrolled_SB_MT_U16_I16_Div.$r8$lambda$tei7nc8TuQIIgAvLq6UAMHvo2hg(grayI16, grayU16, radius, width, sArr, i2, i3, i4, i5, i6, i7, i8, sArr2, i9, i, i10);
            }
        });
    }

    public static /* synthetic */ void $r8$lambda$tei7nc8TuQIIgAvLq6UAMHvo2hg(GrayI16 grayI16, GrayU16 grayU16, int i, int i2, short[] sArr, int i3, int i4, int i5, int i6, int i7, int i8, int i9, short[] sArr2, int i10, int i11, int i12) {
        int i13 = grayI16.startIndex + (grayI16.stride * i12);
        int i14 = grayU16.startIndex + ((i12 - i) * grayU16.stride);
        int i15 = i2 + i14;
        while (i14 < i15) {
            int i16 = (sArr[i14] & 65535) * i3;
            int i17 = grayU16.stride;
            int i18 = i14 + i17;
            int i19 = i16 + ((sArr[i18] & 65535) * i4);
            int i20 = i18 + i17;
            int i21 = i19 + ((sArr[i20] & 65535) * i5);
            int i22 = i20 + i17;
            int i23 = i21 + ((sArr[i22] & 65535) * i6);
            int i24 = i22 + i17;
            int i25 = i23 + ((sArr[i24] & 65535) * i7);
            int i26 = i24 + i17;
            sArr2[i13] = (short) ((((i25 + ((sArr[i26] & 65535) * i8)) + ((65535 & sArr[i26 + i17]) * i9)) + i10) / i11);
            i14++;
            i13++;
        }
    }

    public static void vertical9(Kernel1D_S32 kernel1D_S32, final GrayU16 grayU16, final GrayI16 grayI16, final int i, GrowArray growArray) {
        final short[] sArr = grayU16.data;
        final short[] sArr2 = grayI16.data;
        int[] iArr = kernel1D_S32.data;
        final int i2 = iArr[0];
        final int i3 = iArr[1];
        final int i4 = iArr[2];
        final int i5 = iArr[3];
        final int i6 = iArr[4];
        final int i7 = iArr[5];
        final int i8 = iArr[6];
        final int i9 = iArr[7];
        final int i10 = iArr[8];
        final int radius = kernel1D_S32.getRadius();
        final int width = grayI16.getWidth();
        final int i11 = i / 2;
        ConcurrencyOps.loopFor(radius, grayI16.getHeight() - radius, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.filter.convolve.noborder.ConvolveImageUnrolled_SB_MT_U16_I16_Div$$ExternalSyntheticLambda2
            @Override // java.util.function.IntConsumer
            public final void accept(int i12) {
                ConvolveImageUnrolled_SB_MT_U16_I16_Div.$r8$lambda$tzoD3mLiVbOfPo7AGskcjaNMY9g(grayI16, grayU16, radius, width, sArr, i2, i3, i4, i5, i6, i7, i8, i9, i10, sArr2, i11, i, i12);
            }
        });
    }

    public static /* synthetic */ void $r8$lambda$tzoD3mLiVbOfPo7AGskcjaNMY9g(GrayI16 grayI16, GrayU16 grayU16, int i, int i2, short[] sArr, int i3, int i4, int i5, int i6, int i7, int i8, int i9, int i10, int i11, short[] sArr2, int i12, int i13, int i14) {
        int i15 = grayI16.startIndex + (grayI16.stride * i14);
        int i16 = grayU16.startIndex + ((i14 - i) * grayU16.stride);
        int i17 = i2 + i16;
        while (i16 < i17) {
            int i18 = (sArr[i16] & 65535) * i3;
            int i19 = grayU16.stride;
            int i20 = i16 + i19;
            int i21 = i18 + ((sArr[i20] & 65535) * i4);
            int i22 = i20 + i19;
            int i23 = i21 + ((sArr[i22] & 65535) * i5);
            int i24 = i22 + i19;
            int i25 = i23 + ((sArr[i24] & 65535) * i6);
            int i26 = i24 + i19;
            int i27 = i25 + ((sArr[i26] & 65535) * i7);
            int i28 = i26 + i19;
            int i29 = i27 + ((sArr[i28] & 65535) * i8);
            int i30 = i28 + i19;
            int i31 = i29 + ((sArr[i30] & 65535) * i9);
            int i32 = i30 + i19;
            sArr2[i15] = (short) ((((i31 + ((sArr[i32] & 65535) * i10)) + ((65535 & sArr[i32 + i19]) * i11)) + i12) / i13);
            i16++;
            i15++;
        }
    }

    public static void vertical11(Kernel1D_S32 kernel1D_S32, final GrayU16 grayU16, final GrayI16 grayI16, final int i, GrowArray growArray) {
        final short[] sArr = grayU16.data;
        final short[] sArr2 = grayI16.data;
        int[] iArr = kernel1D_S32.data;
        final int i2 = iArr[0];
        final int i3 = iArr[1];
        final int i4 = iArr[2];
        final int i5 = iArr[3];
        final int i6 = iArr[4];
        final int i7 = iArr[5];
        final int i8 = iArr[6];
        final int i9 = iArr[7];
        final int i10 = iArr[8];
        final int i11 = iArr[9];
        final int i12 = iArr[10];
        final int radius = kernel1D_S32.getRadius();
        final int width = grayI16.getWidth();
        final int i13 = i / 2;
        ConcurrencyOps.loopFor(radius, grayI16.getHeight() - radius, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.filter.convolve.noborder.ConvolveImageUnrolled_SB_MT_U16_I16_Div$$ExternalSyntheticLambda9
            @Override // java.util.function.IntConsumer
            public final void accept(int i14) {
                ConvolveImageUnrolled_SB_MT_U16_I16_Div.$r8$lambda$Bh5fg0Dx9z4s3l1l7Qav8Er55Ig(grayI16, grayU16, radius, width, sArr, i2, i3, i4, i5, i6, i7, i8, i9, i10, i11, i12, sArr2, i13, i, i14);
            }
        });
    }

    public static /* synthetic */ void $r8$lambda$Bh5fg0Dx9z4s3l1l7Qav8Er55Ig(GrayI16 grayI16, GrayU16 grayU16, int i, int i2, short[] sArr, int i3, int i4, int i5, int i6, int i7, int i8, int i9, int i10, int i11, int i12, int i13, short[] sArr2, int i14, int i15, int i16) {
        int i17 = grayI16.startIndex + (grayI16.stride * i16);
        int i18 = grayU16.startIndex + ((i16 - i) * grayU16.stride);
        int i19 = i2 + i18;
        while (i18 < i19) {
            int i20 = (sArr[i18] & 65535) * i3;
            int i21 = grayU16.stride;
            int i22 = i18 + i21;
            int i23 = i20 + ((sArr[i22] & 65535) * i4);
            int i24 = i22 + i21;
            int i25 = i23 + ((sArr[i24] & 65535) * i5);
            int i26 = i24 + i21;
            int i27 = i25 + ((sArr[i26] & 65535) * i6);
            int i28 = i26 + i21;
            int i29 = i27 + ((sArr[i28] & 65535) * i7);
            int i30 = i28 + i21;
            int i31 = i29 + ((sArr[i30] & 65535) * i8);
            int i32 = i30 + i21;
            int i33 = i31 + ((sArr[i32] & 65535) * i9);
            int i34 = i32 + i21;
            int i35 = i33 + ((sArr[i34] & 65535) * i10);
            int i36 = i34 + i21;
            int i37 = i35 + ((sArr[i36] & 65535) * i11);
            int i38 = i36 + i21;
            sArr2[i17] = (short) ((((i37 + ((sArr[i38] & 65535) * i12)) + ((65535 & sArr[i38 + i21]) * i13)) + i14) / i15);
            i18++;
            i17++;
        }
    }
}
