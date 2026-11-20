package com.scanflow.datacapture.barinternal.boofcv.alg.misc.impl;

import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayF32;
import com.scanflow.datacapture.barinternal.pabeles.concurrency.ConcurrencyOps;
import java.util.function.IntConsumer;

/* JADX INFO: loaded from: classes.dex */
public abstract class ImplPixelMath_MT {
    public static void subtract(final GrayF32 grayF32, final GrayF32 grayF33, final GrayF32 grayF34) {
        int height = grayF32.getHeight();
        final int width = grayF32.getWidth();
        ConcurrencyOps.loopFor(0, height, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.misc.impl.ImplPixelMath_MT$$ExternalSyntheticLambda0
            @Override // java.util.function.IntConsumer
            public final void accept(int i) {
                ImplPixelMath_MT.$r8$lambda$VfgOxs0KC1cevgNzA6l06kr6Fsw(grayF32, grayF33, grayF34, width, i);
            }
        });
    }

    public static /* synthetic */ void $r8$lambda$VfgOxs0KC1cevgNzA6l06kr6Fsw(GrayF32 grayF32, GrayF32 grayF33, GrayF32 grayF34, int i, int i2) {
        int startIndex = grayF32.getStartIndex() + (grayF32.getStride() * i2);
        int startIndex2 = grayF33.getStartIndex() + (grayF33.getStride() * i2);
        int startIndex3 = grayF34.getStartIndex() + (i2 * grayF34.getStride());
        int i3 = i + startIndex;
        while (startIndex < i3) {
            grayF34.data[startIndex3] = grayF32.data[startIndex] - grayF33.data[startIndex2];
            startIndex++;
            startIndex2++;
            startIndex3++;
        }
    }

    public static void sqrt(final float[] fArr, final int i, final int i2, final float[] fArr2, final int i3, final int i4, int i5, final int i6) {
        ConcurrencyOps.loopFor(0, i5, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.misc.impl.ImplPixelMath_MT$$ExternalSyntheticLambda2
            @Override // java.util.function.IntConsumer
            public final void accept(int i7) {
                ImplPixelMath_MT.$r8$lambda$naEPRi3qP48j3KNkWiVMqlxZ42A(i, i2, i3, i4, i6, fArr2, fArr, i7);
            }
        });
    }

    public static /* synthetic */ void $r8$lambda$naEPRi3qP48j3KNkWiVMqlxZ42A(int i, int i2, int i3, int i4, int i5, float[] fArr, float[] fArr2, int i6) {
        int i7 = i + (i2 * i6);
        int i8 = i3 + (i6 * i4);
        int i9 = i5 + i7;
        while (i7 < i9) {
            fArr[i8] = (float) Math.sqrt(fArr2[i7]);
            i7++;
            i8++;
        }
    }

    public static void pow2(final float[] fArr, final int i, final int i2, final float[] fArr2, final int i3, final int i4, int i5, final int i6) {
        ConcurrencyOps.loopFor(0, i5, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.misc.impl.ImplPixelMath_MT$$ExternalSyntheticLambda1
            @Override // java.util.function.IntConsumer
            public final void accept(int i7) {
                ImplPixelMath_MT.m663$r8$lambda$PXEFFHqskfW2hyw1M_u__JBw(i, i2, i3, i4, i6, fArr, fArr2, i7);
            }
        });
    }

    /* JADX INFO: renamed from: $r8$lambda$P-XEF-FHqskfW2hyw-1M_u__JBw, reason: not valid java name */
    public static /* synthetic */ void m663$r8$lambda$PXEFFHqskfW2hyw1M_u__JBw(int i, int i2, int i3, int i4, int i5, float[] fArr, float[] fArr2, int i6) {
        int i7 = i + (i2 * i6);
        int i8 = i3 + (i6 * i4);
        int i9 = i5 + i7;
        while (i7 < i9) {
            float f = fArr[i7];
            fArr2[i8] = f * f;
            i7++;
            i8++;
        }
    }
}
