package com.scanflow.datacapture.barinternal.boofcv.alg.filter.convolve.noborder;

import com.scanflow.datacapture.barinternal.boofcv.struct.convolve.Kernel1D_S32;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayI8;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayU8;
import com.scanflow.datacapture.barinternal.pabeles.concurrency.ConcurrencyOps;
import com.scanflow.datacapture.barinternal.pabeles.concurrency.GrowArray;
import java.util.function.IntConsumer;

/* JADX INFO: loaded from: classes.dex */
public abstract class ConvolveImageUnrolled_SB_MT_U8_I8_Div {
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

    public static void horizontal3(Kernel1D_S32 kernel1D_S32, final GrayU8 grayU8, final GrayI8 grayI8, final int i) {
        final byte[] bArr = grayU8.data;
        final byte[] bArr2 = grayI8.data;
        int[] iArr = kernel1D_S32.data;
        final int i2 = iArr[0];
        final int i3 = iArr[1];
        final int i4 = iArr[2];
        final int radius = kernel1D_S32.getRadius();
        final int width = grayU8.getWidth();
        final int i5 = i / 2;
        ConcurrencyOps.loopFor(0, grayU8.height, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.filter.convolve.noborder.ConvolveImageUnrolled_SB_MT_U8_I8_Div$$ExternalSyntheticLambda0
            @Override // java.util.function.IntConsumer
            public final void accept(int i6) {
                ConvolveImageUnrolled_SB_MT_U8_I8_Div.m652$r8$lambda$spRpiw8VmuRjZFAfmCn5cMjolo(grayI8, radius, grayU8, width, bArr, i2, i3, i4, bArr2, i5, i, i6);
            }
        });
    }

    /* JADX INFO: renamed from: $r8$lambda$spRpiw8VmuRjZ-FAfmCn5cMjolo, reason: not valid java name */
    public static /* synthetic */ void m652$r8$lambda$spRpiw8VmuRjZFAfmCn5cMjolo(GrayI8 grayI8, int i, GrayU8 grayU8, int i2, byte[] bArr, int i3, int i4, int i5, byte[] bArr2, int i6, int i7, int i8) {
        int i9 = grayI8.startIndex + (grayI8.stride * i8) + i;
        int i10 = (grayU8.startIndex + (i8 * grayU8.stride)) - i;
        int i11 = (i2 + i10) - i;
        int i12 = i10 + i;
        while (i12 < i11) {
            int i13 = i12 + 1;
            bArr2[i9] = (byte) ((((((bArr[i12] & 255) * i3) + ((bArr[i13] & 255) * i4)) + ((bArr[i12 + 2] & 255) * i5)) + i6) / i7);
            i9++;
            i12 = i13;
        }
    }

    public static void horizontal5(Kernel1D_S32 kernel1D_S32, final GrayU8 grayU8, final GrayI8 grayI8, final int i) {
        final byte[] bArr = grayU8.data;
        final byte[] bArr2 = grayI8.data;
        int[] iArr = kernel1D_S32.data;
        final int i2 = iArr[0];
        final int i3 = iArr[1];
        final int i4 = iArr[2];
        final int i5 = iArr[3];
        final int i6 = iArr[4];
        final int radius = kernel1D_S32.getRadius();
        final int width = grayU8.getWidth();
        final int i7 = i / 2;
        ConcurrencyOps.loopFor(0, grayU8.height, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.filter.convolve.noborder.ConvolveImageUnrolled_SB_MT_U8_I8_Div$$ExternalSyntheticLambda7
            @Override // java.util.function.IntConsumer
            public final void accept(int i8) {
                ConvolveImageUnrolled_SB_MT_U8_I8_Div.$r8$lambda$3ouIbBuS16mw2RJh3E_tZNJCjcg(grayI8, radius, grayU8, width, bArr, i2, i3, i4, i5, i6, bArr2, i7, i, i8);
            }
        });
    }

    public static /* synthetic */ void $r8$lambda$3ouIbBuS16mw2RJh3E_tZNJCjcg(GrayI8 grayI8, int i, GrayU8 grayU8, int i2, byte[] bArr, int i3, int i4, int i5, int i6, int i7, byte[] bArr2, int i8, int i9, int i10) {
        int i11 = grayI8.startIndex + (grayI8.stride * i10) + i;
        int i12 = (grayU8.startIndex + (i10 * grayU8.stride)) - i;
        int i13 = (i2 + i12) - i;
        int i14 = i12 + i;
        while (i14 < i13) {
            int i15 = i14 + 1;
            int i16 = ((bArr[i14] & 255) * i3) + ((bArr[i15] & 255) * i4) + ((bArr[i14 + 2] & 255) * i5);
            bArr2[i11] = (byte) ((((i16 + ((bArr[i14 + 3] & 255) * i6)) + ((bArr[i14 + 4] & 255) * i7)) + i8) / i9);
            i11++;
            i14 = i15;
        }
    }

    public static void horizontal7(Kernel1D_S32 kernel1D_S32, final GrayU8 grayU8, final GrayI8 grayI8, final int i) {
        final byte[] bArr = grayU8.data;
        final byte[] bArr2 = grayI8.data;
        int[] iArr = kernel1D_S32.data;
        final int i2 = iArr[0];
        final int i3 = iArr[1];
        final int i4 = iArr[2];
        final int i5 = iArr[3];
        final int i6 = iArr[4];
        final int i7 = iArr[5];
        final int i8 = iArr[6];
        final int radius = kernel1D_S32.getRadius();
        final int width = grayU8.getWidth();
        final int i9 = i / 2;
        ConcurrencyOps.loopFor(0, grayU8.height, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.filter.convolve.noborder.ConvolveImageUnrolled_SB_MT_U8_I8_Div$$ExternalSyntheticLambda9
            @Override // java.util.function.IntConsumer
            public final void accept(int i10) {
                ConvolveImageUnrolled_SB_MT_U8_I8_Div.$r8$lambda$hm15O1NSK9GTXSe3HPsuNCJ8EYQ(grayI8, radius, grayU8, width, bArr, i2, i3, i4, i5, i6, i7, i8, bArr2, i9, i, i10);
            }
        });
    }

    public static /* synthetic */ void $r8$lambda$hm15O1NSK9GTXSe3HPsuNCJ8EYQ(GrayI8 grayI8, int i, GrayU8 grayU8, int i2, byte[] bArr, int i3, int i4, int i5, int i6, int i7, int i8, int i9, byte[] bArr2, int i10, int i11, int i12) {
        int i13 = grayI8.startIndex + (grayI8.stride * i12) + i;
        int i14 = (grayU8.startIndex + (grayU8.stride * i12)) - i;
        int i15 = (i2 + i14) - i;
        int i16 = i14 + i;
        while (i16 < i15) {
            int i17 = i16 + 1;
            int i18 = ((bArr[i16] & 255) * i3) + ((bArr[i17] & 255) * i4) + ((bArr[i16 + 2] & 255) * i5) + ((bArr[i16 + 3] & 255) * i6) + ((bArr[i16 + 4] & 255) * i7);
            bArr2[i13] = (byte) ((((i18 + ((bArr[i16 + 5] & 255) * i8)) + ((bArr[i16 + 6] & 255) * i9)) + i10) / i11);
            i13++;
            i16 = i17;
        }
    }

    public static void horizontal9(Kernel1D_S32 kernel1D_S32, final GrayU8 grayU8, final GrayI8 grayI8, final int i) {
        final byte[] bArr = grayU8.data;
        final byte[] bArr2 = grayI8.data;
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
        final int width = grayU8.getWidth();
        final int i11 = i / 2;
        ConcurrencyOps.loopFor(0, grayU8.height, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.filter.convolve.noborder.ConvolveImageUnrolled_SB_MT_U8_I8_Div$$ExternalSyntheticLambda6
            @Override // java.util.function.IntConsumer
            public final void accept(int i12) {
                ConvolveImageUnrolled_SB_MT_U8_I8_Div.$r8$lambda$h_KEtEaO6oqE7Wvvsrz4gQlfnpE(grayI8, radius, grayU8, width, bArr, i2, i3, i4, i5, i6, i7, i8, i9, i10, bArr2, i11, i, i12);
            }
        });
    }

    public static /* synthetic */ void $r8$lambda$h_KEtEaO6oqE7Wvvsrz4gQlfnpE(GrayI8 grayI8, int i, GrayU8 grayU8, int i2, byte[] bArr, int i3, int i4, int i5, int i6, int i7, int i8, int i9, int i10, int i11, byte[] bArr2, int i12, int i13, int i14) {
        int i15 = grayI8.startIndex + (grayI8.stride * i14) + i;
        int i16 = (grayU8.startIndex + (grayU8.stride * i14)) - i;
        int i17 = (i2 + i16) - i;
        int i18 = i16 + i;
        while (i18 < i17) {
            int i19 = i18 + 1;
            int i20 = ((bArr[i18] & 255) * i3) + ((bArr[i19] & 255) * i4) + ((bArr[i18 + 2] & 255) * i5) + ((bArr[i18 + 3] & 255) * i6) + ((bArr[i18 + 4] & 255) * i7) + ((bArr[i18 + 5] & 255) * i8) + ((bArr[i18 + 6] & 255) * i9);
            bArr2[i15] = (byte) ((((i20 + ((bArr[i18 + 7] & 255) * i10)) + ((bArr[i18 + 8] & 255) * i11)) + i12) / i13);
            i15++;
            i18 = i19;
        }
    }

    public static void horizontal11(Kernel1D_S32 kernel1D_S32, final GrayU8 grayU8, final GrayI8 grayI8, final int i) {
        final byte[] bArr = grayU8.data;
        final byte[] bArr2 = grayI8.data;
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
        final int width = grayU8.getWidth();
        final int i13 = i / 2;
        ConcurrencyOps.loopFor(0, grayU8.height, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.filter.convolve.noborder.ConvolveImageUnrolled_SB_MT_U8_I8_Div$$ExternalSyntheticLambda1
            @Override // java.util.function.IntConsumer
            public final void accept(int i14) {
                ConvolveImageUnrolled_SB_MT_U8_I8_Div.$r8$lambda$tGAzS4VicsKYtP_hzIAJhXtA7IQ(grayI8, radius, grayU8, width, bArr, i2, i3, i4, i5, i6, i7, i8, i9, i10, i11, i12, bArr2, i13, i, i14);
            }
        });
    }

    public static /* synthetic */ void $r8$lambda$tGAzS4VicsKYtP_hzIAJhXtA7IQ(GrayI8 grayI8, int i, GrayU8 grayU8, int i2, byte[] bArr, int i3, int i4, int i5, int i6, int i7, int i8, int i9, int i10, int i11, int i12, int i13, byte[] bArr2, int i14, int i15, int i16) {
        int i17 = grayI8.startIndex + (grayI8.stride * i16) + i;
        int i18 = (grayU8.startIndex + (grayU8.stride * i16)) - i;
        int i19 = (i2 + i18) - i;
        int i20 = i18 + i;
        while (i20 < i19) {
            int i21 = i20 + 1;
            int i22 = ((bArr[i20] & 255) * i3) + ((bArr[i21] & 255) * i4) + ((bArr[i20 + 2] & 255) * i5) + ((bArr[i20 + 3] & 255) * i6) + ((bArr[i20 + 4] & 255) * i7) + ((bArr[i20 + 5] & 255) * i8) + ((bArr[i20 + 6] & 255) * i9) + ((bArr[i20 + 7] & 255) * i10) + ((bArr[i20 + 8] & 255) * i11);
            bArr2[i17] = (byte) ((((i22 + ((bArr[i20 + 9] & 255) * i12)) + ((bArr[i20 + 10] & 255) * i13)) + i14) / i15);
            i17++;
            i20 = i21;
        }
    }

    public static void vertical3(Kernel1D_S32 kernel1D_S32, final GrayU8 grayU8, final GrayI8 grayI8, final int i, GrowArray growArray) {
        final byte[] bArr = grayU8.data;
        final byte[] bArr2 = grayI8.data;
        int[] iArr = kernel1D_S32.data;
        final int i2 = iArr[0];
        final int i3 = iArr[1];
        final int i4 = iArr[2];
        final int radius = kernel1D_S32.getRadius();
        final int width = grayI8.getWidth();
        final int i5 = i / 2;
        ConcurrencyOps.loopFor(radius, grayI8.getHeight() - radius, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.filter.convolve.noborder.ConvolveImageUnrolled_SB_MT_U8_I8_Div$$ExternalSyntheticLambda4
            @Override // java.util.function.IntConsumer
            public final void accept(int i6) {
                ConvolveImageUnrolled_SB_MT_U8_I8_Div.$r8$lambda$Hhv9YV4cAMD8ZLFjfUjRhnw2Yt8(grayI8, grayU8, radius, width, bArr, i2, i3, i4, bArr2, i5, i, i6);
            }
        });
    }

    public static /* synthetic */ void $r8$lambda$Hhv9YV4cAMD8ZLFjfUjRhnw2Yt8(GrayI8 grayI8, GrayU8 grayU8, int i, int i2, byte[] bArr, int i3, int i4, int i5, byte[] bArr2, int i6, int i7, int i8) {
        int i9 = grayI8.startIndex + (grayI8.stride * i8);
        int i10 = grayU8.startIndex + ((i8 - i) * grayU8.stride);
        int i11 = i2 + i10;
        while (i10 < i11) {
            int i12 = (bArr[i10] & 255) * i3;
            int i13 = grayU8.stride;
            int i14 = i10 + i13;
            bArr2[i9] = (byte) ((((i12 + ((bArr[i14] & 255) * i4)) + ((bArr[i14 + i13] & 255) * i5)) + i6) / i7);
            i10++;
            i9++;
        }
    }

    public static void vertical5(Kernel1D_S32 kernel1D_S32, final GrayU8 grayU8, final GrayI8 grayI8, final int i, GrowArray growArray) {
        final byte[] bArr = grayU8.data;
        final byte[] bArr2 = grayI8.data;
        int[] iArr = kernel1D_S32.data;
        final int i2 = iArr[0];
        final int i3 = iArr[1];
        final int i4 = iArr[2];
        final int i5 = iArr[3];
        final int i6 = iArr[4];
        final int radius = kernel1D_S32.getRadius();
        final int width = grayI8.getWidth();
        final int i7 = i / 2;
        ConcurrencyOps.loopFor(radius, grayI8.getHeight() - radius, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.filter.convolve.noborder.ConvolveImageUnrolled_SB_MT_U8_I8_Div$$ExternalSyntheticLambda5
            @Override // java.util.function.IntConsumer
            public final void accept(int i8) {
                ConvolveImageUnrolled_SB_MT_U8_I8_Div.$r8$lambda$25RPMZ8erj4DTB3StAoBuzyxSRM(grayI8, grayU8, radius, width, bArr, i2, i3, i4, i5, i6, bArr2, i7, i, i8);
            }
        });
    }

    public static /* synthetic */ void $r8$lambda$25RPMZ8erj4DTB3StAoBuzyxSRM(GrayI8 grayI8, GrayU8 grayU8, int i, int i2, byte[] bArr, int i3, int i4, int i5, int i6, int i7, byte[] bArr2, int i8, int i9, int i10) {
        int i11 = grayI8.startIndex + (grayI8.stride * i10);
        int i12 = grayU8.startIndex + ((i10 - i) * grayU8.stride);
        int i13 = i2 + i12;
        while (i12 < i13) {
            int i14 = (bArr[i12] & 255) * i3;
            int i15 = grayU8.stride;
            int i16 = i12 + i15;
            int i17 = i14 + ((bArr[i16] & 255) * i4);
            int i18 = i16 + i15;
            int i19 = i17 + ((bArr[i18] & 255) * i5);
            int i20 = i18 + i15;
            bArr2[i11] = (byte) ((((i19 + ((bArr[i20] & 255) * i6)) + ((bArr[i20 + i15] & 255) * i7)) + i8) / i9);
            i12++;
            i11++;
        }
    }

    public static void vertical7(Kernel1D_S32 kernel1D_S32, final GrayU8 grayU8, final GrayI8 grayI8, final int i, GrowArray growArray) {
        final byte[] bArr = grayU8.data;
        final byte[] bArr2 = grayI8.data;
        int[] iArr = kernel1D_S32.data;
        final int i2 = iArr[0];
        final int i3 = iArr[1];
        final int i4 = iArr[2];
        final int i5 = iArr[3];
        final int i6 = iArr[4];
        final int i7 = iArr[5];
        final int i8 = iArr[6];
        final int radius = kernel1D_S32.getRadius();
        final int width = grayI8.getWidth();
        final int i9 = i / 2;
        ConcurrencyOps.loopFor(radius, grayI8.getHeight() - radius, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.filter.convolve.noborder.ConvolveImageUnrolled_SB_MT_U8_I8_Div$$ExternalSyntheticLambda3
            @Override // java.util.function.IntConsumer
            public final void accept(int i10) {
                ConvolveImageUnrolled_SB_MT_U8_I8_Div.m651$r8$lambda$7lkffpuYa1C_S9XkBoFsbO1kc(grayI8, grayU8, radius, width, bArr, i2, i3, i4, i5, i6, i7, i8, bArr2, i9, i, i10);
            }
        });
    }

    /* JADX INFO: renamed from: $r8$lambda$7lkffpuY-a1C_S9-XkBoFsbO1kc, reason: not valid java name */
    public static /* synthetic */ void m651$r8$lambda$7lkffpuYa1C_S9XkBoFsbO1kc(GrayI8 grayI8, GrayU8 grayU8, int i, int i2, byte[] bArr, int i3, int i4, int i5, int i6, int i7, int i8, int i9, byte[] bArr2, int i10, int i11, int i12) {
        int i13 = grayI8.startIndex + (grayI8.stride * i12);
        int i14 = grayU8.startIndex + ((i12 - i) * grayU8.stride);
        int i15 = i2 + i14;
        while (i14 < i15) {
            int i16 = (bArr[i14] & 255) * i3;
            int i17 = grayU8.stride;
            int i18 = i14 + i17;
            int i19 = i16 + ((bArr[i18] & 255) * i4);
            int i20 = i18 + i17;
            int i21 = i19 + ((bArr[i20] & 255) * i5);
            int i22 = i20 + i17;
            int i23 = i21 + ((bArr[i22] & 255) * i6);
            int i24 = i22 + i17;
            int i25 = i23 + ((bArr[i24] & 255) * i7);
            int i26 = i24 + i17;
            bArr2[i13] = (byte) ((((i25 + ((bArr[i26] & 255) * i8)) + ((bArr[i26 + i17] & 255) * i9)) + i10) / i11);
            i14++;
            i13++;
        }
    }

    public static void vertical9(Kernel1D_S32 kernel1D_S32, final GrayU8 grayU8, final GrayI8 grayI8, final int i, GrowArray growArray) {
        final byte[] bArr = grayU8.data;
        final byte[] bArr2 = grayI8.data;
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
        final int width = grayI8.getWidth();
        final int i11 = i / 2;
        ConcurrencyOps.loopFor(radius, grayI8.getHeight() - radius, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.filter.convolve.noborder.ConvolveImageUnrolled_SB_MT_U8_I8_Div$$ExternalSyntheticLambda8
            @Override // java.util.function.IntConsumer
            public final void accept(int i12) {
                ConvolveImageUnrolled_SB_MT_U8_I8_Div.$r8$lambda$5XdUXYmTzF14KhQONj29ANbrPNs(grayI8, grayU8, radius, width, bArr, i2, i3, i4, i5, i6, i7, i8, i9, i10, bArr2, i11, i, i12);
            }
        });
    }

    public static /* synthetic */ void $r8$lambda$5XdUXYmTzF14KhQONj29ANbrPNs(GrayI8 grayI8, GrayU8 grayU8, int i, int i2, byte[] bArr, int i3, int i4, int i5, int i6, int i7, int i8, int i9, int i10, int i11, byte[] bArr2, int i12, int i13, int i14) {
        int i15 = grayI8.startIndex + (grayI8.stride * i14);
        int i16 = grayU8.startIndex + ((i14 - i) * grayU8.stride);
        int i17 = i2 + i16;
        while (i16 < i17) {
            int i18 = (bArr[i16] & 255) * i3;
            int i19 = grayU8.stride;
            int i20 = i16 + i19;
            int i21 = i18 + ((bArr[i20] & 255) * i4);
            int i22 = i20 + i19;
            int i23 = i21 + ((bArr[i22] & 255) * i5);
            int i24 = i22 + i19;
            int i25 = i23 + ((bArr[i24] & 255) * i6);
            int i26 = i24 + i19;
            int i27 = i25 + ((bArr[i26] & 255) * i7);
            int i28 = i26 + i19;
            int i29 = i27 + ((bArr[i28] & 255) * i8);
            int i30 = i28 + i19;
            int i31 = i29 + ((bArr[i30] & 255) * i9);
            int i32 = i30 + i19;
            bArr2[i15] = (byte) ((((i31 + ((bArr[i32] & 255) * i10)) + ((bArr[i32 + i19] & 255) * i11)) + i12) / i13);
            i16++;
            i15++;
        }
    }

    public static void vertical11(Kernel1D_S32 kernel1D_S32, final GrayU8 grayU8, final GrayI8 grayI8, final int i, GrowArray growArray) {
        final byte[] bArr = grayU8.data;
        final byte[] bArr2 = grayI8.data;
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
        final int width = grayI8.getWidth();
        final int i13 = i / 2;
        ConcurrencyOps.loopFor(radius, grayI8.getHeight() - radius, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.filter.convolve.noborder.ConvolveImageUnrolled_SB_MT_U8_I8_Div$$ExternalSyntheticLambda2
            @Override // java.util.function.IntConsumer
            public final void accept(int i14) {
                ConvolveImageUnrolled_SB_MT_U8_I8_Div.$r8$lambda$KtcFaVQd_7KwOCRyxcnUft9MOas(grayI8, grayU8, radius, width, bArr, i2, i3, i4, i5, i6, i7, i8, i9, i10, i11, i12, bArr2, i13, i, i14);
            }
        });
    }

    public static /* synthetic */ void $r8$lambda$KtcFaVQd_7KwOCRyxcnUft9MOas(GrayI8 grayI8, GrayU8 grayU8, int i, int i2, byte[] bArr, int i3, int i4, int i5, int i6, int i7, int i8, int i9, int i10, int i11, int i12, int i13, byte[] bArr2, int i14, int i15, int i16) {
        int i17 = grayI8.startIndex + (grayI8.stride * i16);
        int i18 = grayU8.startIndex + ((i16 - i) * grayU8.stride);
        int i19 = i2 + i18;
        while (i18 < i19) {
            int i20 = (bArr[i18] & 255) * i3;
            int i21 = grayU8.stride;
            int i22 = i18 + i21;
            int i23 = i20 + ((bArr[i22] & 255) * i4);
            int i24 = i22 + i21;
            int i25 = i23 + ((bArr[i24] & 255) * i5);
            int i26 = i24 + i21;
            int i27 = i25 + ((bArr[i26] & 255) * i6);
            int i28 = i26 + i21;
            int i29 = i27 + ((bArr[i28] & 255) * i7);
            int i30 = i28 + i21;
            int i31 = i29 + ((bArr[i30] & 255) * i8);
            int i32 = i30 + i21;
            int i33 = i31 + ((bArr[i32] & 255) * i9);
            int i34 = i32 + i21;
            int i35 = i33 + ((bArr[i34] & 255) * i10);
            int i36 = i34 + i21;
            int i37 = i35 + ((bArr[i36] & 255) * i11);
            int i38 = i36 + i21;
            bArr2[i17] = (byte) ((((i37 + ((bArr[i38] & 255) * i12)) + ((bArr[i38 + i21] & 255) * i13)) + i14) / i15);
            i18++;
            i17++;
        }
    }
}
