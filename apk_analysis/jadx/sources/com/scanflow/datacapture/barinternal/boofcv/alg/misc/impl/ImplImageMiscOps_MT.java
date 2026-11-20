package com.scanflow.datacapture.barinternal.boofcv.alg.misc.impl;

import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayF32;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayF64;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayI16;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayI8;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayS32;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayS64;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.InterleavedF32;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.InterleavedF64;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.InterleavedI16;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.InterleavedI8;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.InterleavedS32;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.InterleavedS64;
import com.scanflow.datacapture.barinternal.pabeles.concurrency.ConcurrencyOps;
import java.util.function.IntConsumer;

/* JADX INFO: loaded from: classes.dex */
public abstract class ImplImageMiscOps_MT {
    public static void insertBand(final GrayI8 grayI8, final int i, final InterleavedI8 interleavedI8) {
        final int i2 = interleavedI8.numBands;
        ConcurrencyOps.loopFor(0, grayI8.height, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.misc.impl.ImplImageMiscOps_MT$$ExternalSyntheticLambda5
            @Override // java.util.function.IntConsumer
            public final void accept(int i3) {
                ImplImageMiscOps_MT.m656$r8$lambda$1wFn_nIjGqZziFhE4NJIDQBZmo(grayI8, interleavedI8, i, i2, i3);
            }
        });
    }

    /* JADX INFO: renamed from: $r8$lambda$1wFn_nI-jGqZziFhE4NJIDQBZmo, reason: not valid java name */
    public static /* synthetic */ void m656$r8$lambda$1wFn_nIjGqZziFhE4NJIDQBZmo(GrayI8 grayI8, InterleavedI8 interleavedI8, int i, int i2, int i3) {
        int startIndex = grayI8.getStartIndex() + (grayI8.getStride() * i3);
        int startIndex2 = interleavedI8.getStartIndex() + (i3 * interleavedI8.getStride()) + i;
        int i4 = ((interleavedI8.width * i2) + startIndex2) - i;
        while (startIndex2 < i4) {
            interleavedI8.data[startIndex2] = grayI8.data[startIndex];
            startIndex2 += i2;
            startIndex++;
        }
    }

    public static void insertBand(final GrayI16 grayI16, final int i, final InterleavedI16 interleavedI16) {
        final int i2 = interleavedI16.numBands;
        ConcurrencyOps.loopFor(0, grayI16.height, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.misc.impl.ImplImageMiscOps_MT$$ExternalSyntheticLambda4
            @Override // java.util.function.IntConsumer
            public final void accept(int i3) {
                ImplImageMiscOps_MT.m658$r8$lambda$FsmiptJFZZ2lIxBG4IuwZfQFN8(grayI16, interleavedI16, i, i2, i3);
            }
        });
    }

    /* JADX INFO: renamed from: $r8$lambda$FsmiptJFZZ-2lIxBG4IuwZfQFN8, reason: not valid java name */
    public static /* synthetic */ void m658$r8$lambda$FsmiptJFZZ2lIxBG4IuwZfQFN8(GrayI16 grayI16, InterleavedI16 interleavedI16, int i, int i2, int i3) {
        int startIndex = grayI16.getStartIndex() + (grayI16.getStride() * i3);
        int startIndex2 = interleavedI16.getStartIndex() + (i3 * interleavedI16.getStride()) + i;
        int i4 = ((interleavedI16.width * i2) + startIndex2) - i;
        while (startIndex2 < i4) {
            interleavedI16.data[startIndex2] = grayI16.data[startIndex];
            startIndex2 += i2;
            startIndex++;
        }
    }

    public static void insertBand(final GrayS32 grayS32, final int i, final InterleavedS32 interleavedS32) {
        final int i2 = interleavedS32.numBands;
        ConcurrencyOps.loopFor(0, grayS32.height, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.misc.impl.ImplImageMiscOps_MT$$ExternalSyntheticLambda2
            @Override // java.util.function.IntConsumer
            public final void accept(int i3) {
                ImplImageMiscOps_MT.$r8$lambda$hnfeS48zOyjY2JZ04K5sVbr_U5E(grayS32, interleavedS32, i, i2, i3);
            }
        });
    }

    public static /* synthetic */ void $r8$lambda$hnfeS48zOyjY2JZ04K5sVbr_U5E(GrayS32 grayS32, InterleavedS32 interleavedS32, int i, int i2, int i3) {
        int startIndex = grayS32.getStartIndex() + (grayS32.getStride() * i3);
        int startIndex2 = interleavedS32.getStartIndex() + (i3 * interleavedS32.getStride()) + i;
        int i4 = ((interleavedS32.width * i2) + startIndex2) - i;
        while (startIndex2 < i4) {
            interleavedS32.data[startIndex2] = grayS32.data[startIndex];
            startIndex2 += i2;
            startIndex++;
        }
    }

    public static void insertBand(final GrayS64 grayS64, final int i, final InterleavedS64 interleavedS64) {
        final int i2 = interleavedS64.numBands;
        ConcurrencyOps.loopFor(0, grayS64.height, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.misc.impl.ImplImageMiscOps_MT$$ExternalSyntheticLambda3
            @Override // java.util.function.IntConsumer
            public final void accept(int i3) {
                ImplImageMiscOps_MT.$r8$lambda$M0sSOInO1HeQFf6VdHJbQ0tAXxg(grayS64, interleavedS64, i, i2, i3);
            }
        });
    }

    public static /* synthetic */ void $r8$lambda$M0sSOInO1HeQFf6VdHJbQ0tAXxg(GrayS64 grayS64, InterleavedS64 interleavedS64, int i, int i2, int i3) {
        int startIndex = grayS64.getStartIndex() + (grayS64.getStride() * i3);
        int startIndex2 = interleavedS64.getStartIndex() + (i3 * interleavedS64.getStride()) + i;
        int i4 = ((interleavedS64.width * i2) + startIndex2) - i;
        while (startIndex2 < i4) {
            interleavedS64.data[startIndex2] = grayS64.data[startIndex];
            startIndex2 += i2;
            startIndex++;
        }
    }

    public static void insertBand(final GrayF32 grayF32, final int i, final InterleavedF32 interleavedF32) {
        final int i2 = interleavedF32.numBands;
        ConcurrencyOps.loopFor(0, grayF32.height, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.misc.impl.ImplImageMiscOps_MT$$ExternalSyntheticLambda1
            @Override // java.util.function.IntConsumer
            public final void accept(int i3) {
                ImplImageMiscOps_MT.m657$r8$lambda$6qNwGIwwnaUxCd3prRxkzyJQ84(grayF32, interleavedF32, i, i2, i3);
            }
        });
    }

    /* JADX INFO: renamed from: $r8$lambda$6qNwGIwwnaUxCd3prRxkzyJQ-84, reason: not valid java name */
    public static /* synthetic */ void m657$r8$lambda$6qNwGIwwnaUxCd3prRxkzyJQ84(GrayF32 grayF32, InterleavedF32 interleavedF32, int i, int i2, int i3) {
        int startIndex = grayF32.getStartIndex() + (grayF32.getStride() * i3);
        int startIndex2 = interleavedF32.getStartIndex() + (i3 * interleavedF32.getStride()) + i;
        int i4 = ((interleavedF32.width * i2) + startIndex2) - i;
        while (startIndex2 < i4) {
            interleavedF32.data[startIndex2] = grayF32.data[startIndex];
            startIndex2 += i2;
            startIndex++;
        }
    }

    public static void insertBand(final GrayF64 grayF64, final int i, final InterleavedF64 interleavedF64) {
        final int i2 = interleavedF64.numBands;
        ConcurrencyOps.loopFor(0, grayF64.height, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.misc.impl.ImplImageMiscOps_MT$$ExternalSyntheticLambda0
            @Override // java.util.function.IntConsumer
            public final void accept(int i3) {
                ImplImageMiscOps_MT.m659$r8$lambda$Qewqezj9qOpZIIowgptnfax_4I(grayF64, interleavedF64, i, i2, i3);
            }
        });
    }

    /* JADX INFO: renamed from: $r8$lambda$Qewqezj9qOpZIIowgpt-nfax_4I, reason: not valid java name */
    public static /* synthetic */ void m659$r8$lambda$Qewqezj9qOpZIIowgptnfax_4I(GrayF64 grayF64, InterleavedF64 interleavedF64, int i, int i2, int i3) {
        int startIndex = grayF64.getStartIndex() + (grayF64.getStride() * i3);
        int startIndex2 = interleavedF64.getStartIndex() + (i3 * interleavedF64.getStride()) + i;
        int i4 = ((interleavedF64.width * i2) + startIndex2) - i;
        while (startIndex2 < i4) {
            interleavedF64.data[startIndex2] = grayF64.data[startIndex];
            startIndex2 += i2;
            startIndex++;
        }
    }
}
