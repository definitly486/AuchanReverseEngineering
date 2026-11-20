package com.scanflow.datacapture.barinternal.boofcv.alg.misc.impl;

import com.google.common.primitives.UnsignedBytes;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayF32;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayF64;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayS16;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayS32;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayS64;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayS8;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayU16;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayU8;
import com.scanflow.datacapture.barinternal.pabeles.concurrency.ConcurrencyOps;
import com.scanflow.datacapture.barinternal.pabeles.concurrency.IntProducerNumber;
import com.scanflow.datacapture.barinternal.pabeles.concurrency.IntRangeConsumer;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

/* JADX INFO: loaded from: classes.dex */
public abstract class ImplImageStatistics_MT {
    public static void histogram(final GrayU8 grayU8, final int i, final int[] iArr) {
        Arrays.fill(iArr, 0);
        final ArrayList arrayList = new ArrayList();
        ConcurrencyOps.loopBlocks(0, grayU8.height, new IntRangeConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.misc.impl.ImplImageStatistics_MT$$ExternalSyntheticLambda5
            @Override // com.scanflow.datacapture.barinternal.pabeles.concurrency.IntRangeConsumer
            public final void accept(int i2, int i3) {
                ImplImageStatistics_MT.m660$r8$lambda$iVURLV8Z4H1yb530Lg0lTfIzJ8(iArr, grayU8, i, arrayList, i2, i3);
            }
        });
        for (int i2 = 0; i2 < arrayList.size(); i2++) {
            int[] iArr2 = (int[]) arrayList.get(i2);
            for (int i3 = 0; i3 < iArr.length; i3++) {
                iArr[i3] = iArr[i3] + iArr2[i3];
            }
        }
    }

    /* JADX INFO: renamed from: $r8$lambda$-iVURLV8Z4H1yb530Lg0lTfIzJ8, reason: not valid java name */
    public static /* synthetic */ void m660$r8$lambda$iVURLV8Z4H1yb530Lg0lTfIzJ8(int[] iArr, GrayU8 grayU8, int i, List list, int i2, int i3) {
        int[] iArr2 = new int[iArr.length];
        while (i2 < i3) {
            int i4 = grayU8.startIndex + (grayU8.stride * i2);
            int i5 = grayU8.width + i4;
            while (i4 < i5) {
                int i6 = i4 + 1;
                int i7 = (grayU8.data[i4] & UnsignedBytes.MAX_VALUE) - i;
                iArr2[i7] = iArr2[i7] + 1;
                i4 = i6;
            }
            i2++;
        }
        synchronized (list) {
            list.add(iArr2);
        }
    }

    public static void histogram(final GrayS8 grayS8, final int i, final int[] iArr) {
        Arrays.fill(iArr, 0);
        final ArrayList arrayList = new ArrayList();
        ConcurrencyOps.loopBlocks(0, grayS8.height, new IntRangeConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.misc.impl.ImplImageStatistics_MT$$ExternalSyntheticLambda0
            @Override // com.scanflow.datacapture.barinternal.pabeles.concurrency.IntRangeConsumer
            public final void accept(int i2, int i3) {
                ImplImageStatistics_MT.$r8$lambda$NE3z2Mmek2Gc6lBVnF4UAyqTLOA(iArr, grayS8, i, arrayList, i2, i3);
            }
        });
        for (int i2 = 0; i2 < arrayList.size(); i2++) {
            int[] iArr2 = (int[]) arrayList.get(i2);
            for (int i3 = 0; i3 < iArr.length; i3++) {
                iArr[i3] = iArr[i3] + iArr2[i3];
            }
        }
    }

    public static /* synthetic */ void $r8$lambda$NE3z2Mmek2Gc6lBVnF4UAyqTLOA(int[] iArr, GrayS8 grayS8, int i, List list, int i2, int i3) {
        int[] iArr2 = new int[iArr.length];
        while (i2 < i3) {
            int i4 = grayS8.startIndex + (grayS8.stride * i2);
            int i5 = grayS8.width + i4;
            while (i4 < i5) {
                int i6 = i4 + 1;
                int i7 = grayS8.data[i4] - i;
                iArr2[i7] = iArr2[i7] + 1;
                i4 = i6;
            }
            i2++;
        }
        synchronized (list) {
            list.add(iArr2);
        }
    }

    public static void histogram(final GrayU16 grayU16, final int i, final int[] iArr) {
        Arrays.fill(iArr, 0);
        final ArrayList arrayList = new ArrayList();
        ConcurrencyOps.loopBlocks(0, grayU16.height, new IntRangeConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.misc.impl.ImplImageStatistics_MT$$ExternalSyntheticLambda6
            @Override // com.scanflow.datacapture.barinternal.pabeles.concurrency.IntRangeConsumer
            public final void accept(int i2, int i3) {
                ImplImageStatistics_MT.m661$r8$lambda$2JuCKKLRen0CqBCzEB5MRIvo3Q(iArr, grayU16, i, arrayList, i2, i3);
            }
        });
        for (int i2 = 0; i2 < arrayList.size(); i2++) {
            int[] iArr2 = (int[]) arrayList.get(i2);
            for (int i3 = 0; i3 < iArr.length; i3++) {
                iArr[i3] = iArr[i3] + iArr2[i3];
            }
        }
    }

    /* JADX INFO: renamed from: $r8$lambda$2JuCKKLRen0CqBCzEB5-MRIvo3Q, reason: not valid java name */
    public static /* synthetic */ void m661$r8$lambda$2JuCKKLRen0CqBCzEB5MRIvo3Q(int[] iArr, GrayU16 grayU16, int i, List list, int i2, int i3) {
        int[] iArr2 = new int[iArr.length];
        while (i2 < i3) {
            int i4 = grayU16.startIndex + (grayU16.stride * i2);
            int i5 = grayU16.width + i4;
            while (i4 < i5) {
                int i6 = i4 + 1;
                int i7 = (grayU16.data[i4] & 65535) - i;
                iArr2[i7] = iArr2[i7] + 1;
                i4 = i6;
            }
            i2++;
        }
        synchronized (list) {
            list.add(iArr2);
        }
    }

    public static void histogram(final GrayS16 grayS16, final int i, final int[] iArr) {
        Arrays.fill(iArr, 0);
        final ArrayList arrayList = new ArrayList();
        ConcurrencyOps.loopBlocks(0, grayS16.height, new IntRangeConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.misc.impl.ImplImageStatistics_MT$$ExternalSyntheticLambda8
            @Override // com.scanflow.datacapture.barinternal.pabeles.concurrency.IntRangeConsumer
            public final void accept(int i2, int i3) {
                ImplImageStatistics_MT.$r8$lambda$dOZHSPvt4OfgkPo1xU_o5P9l6lw(iArr, grayS16, i, arrayList, i2, i3);
            }
        });
        for (int i2 = 0; i2 < arrayList.size(); i2++) {
            int[] iArr2 = (int[]) arrayList.get(i2);
            for (int i3 = 0; i3 < iArr.length; i3++) {
                iArr[i3] = iArr[i3] + iArr2[i3];
            }
        }
    }

    public static /* synthetic */ void $r8$lambda$dOZHSPvt4OfgkPo1xU_o5P9l6lw(int[] iArr, GrayS16 grayS16, int i, List list, int i2, int i3) {
        int[] iArr2 = new int[iArr.length];
        while (i2 < i3) {
            int i4 = grayS16.startIndex + (grayS16.stride * i2);
            int i5 = grayS16.width + i4;
            while (i4 < i5) {
                int i6 = i4 + 1;
                int i7 = grayS16.data[i4] - i;
                iArr2[i7] = iArr2[i7] + 1;
                i4 = i6;
            }
            i2++;
        }
        synchronized (list) {
            list.add(iArr2);
        }
    }

    public static void histogram(final GrayS32 grayS32, final int i, final int[] iArr) {
        Arrays.fill(iArr, 0);
        final ArrayList arrayList = new ArrayList();
        ConcurrencyOps.loopBlocks(0, grayS32.height, new IntRangeConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.misc.impl.ImplImageStatistics_MT$$ExternalSyntheticLambda9
            @Override // com.scanflow.datacapture.barinternal.pabeles.concurrency.IntRangeConsumer
            public final void accept(int i2, int i3) {
                ImplImageStatistics_MT.$r8$lambda$n_GBbAl50qfnKR1JUvf7kq1pJV0(iArr, grayS32, i, arrayList, i2, i3);
            }
        });
        for (int i2 = 0; i2 < arrayList.size(); i2++) {
            int[] iArr2 = (int[]) arrayList.get(i2);
            for (int i3 = 0; i3 < iArr.length; i3++) {
                iArr[i3] = iArr[i3] + iArr2[i3];
            }
        }
    }

    public static /* synthetic */ void $r8$lambda$n_GBbAl50qfnKR1JUvf7kq1pJV0(int[] iArr, GrayS32 grayS32, int i, List list, int i2, int i3) {
        int[] iArr2 = new int[iArr.length];
        while (i2 < i3) {
            int i4 = grayS32.startIndex + (grayS32.stride * i2);
            int i5 = grayS32.width + i4;
            while (i4 < i5) {
                int i6 = i4 + 1;
                int i7 = grayS32.data[i4] - i;
                iArr2[i7] = iArr2[i7] + 1;
                i4 = i6;
            }
            i2++;
        }
        synchronized (list) {
            list.add(iArr2);
        }
    }

    public static void histogram(final GrayS64 grayS64, final long j, final int[] iArr) {
        Arrays.fill(iArr, 0);
        final ArrayList arrayList = new ArrayList();
        ConcurrencyOps.loopBlocks(0, grayS64.height, new IntRangeConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.misc.impl.ImplImageStatistics_MT$$ExternalSyntheticLambda1
            @Override // com.scanflow.datacapture.barinternal.pabeles.concurrency.IntRangeConsumer
            public final void accept(int i, int i2) {
                ImplImageStatistics_MT.$r8$lambda$SxfqGrwqUIDCikjjzYkyxGoUVzs(iArr, grayS64, j, arrayList, i, i2);
            }
        });
        for (int i = 0; i < arrayList.size(); i++) {
            int[] iArr2 = (int[]) arrayList.get(i);
            for (int i2 = 0; i2 < iArr.length; i2++) {
                iArr[i2] = iArr[i2] + iArr2[i2];
            }
        }
    }

    public static /* synthetic */ void $r8$lambda$SxfqGrwqUIDCikjjzYkyxGoUVzs(int[] iArr, GrayS64 grayS64, long j, List list, int i, int i2) {
        int[] iArr2 = new int[iArr.length];
        while (i < i2) {
            int i3 = grayS64.startIndex + (grayS64.stride * i);
            int i4 = grayS64.width + i3;
            while (i3 < i4) {
                int i5 = i3 + 1;
                int i6 = (int) (grayS64.data[i3] - j);
                iArr2[i6] = iArr2[i6] + 1;
                i3 = i5;
            }
            i++;
        }
        synchronized (list) {
            list.add(iArr2);
        }
    }

    public static float min(final float[] fArr, final int i, int i2, final int i3, final int i4) {
        final float f = fArr[i];
        return ConcurrencyOps.min(0, i2, Float.TYPE, new IntProducerNumber() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.misc.impl.ImplImageStatistics_MT$$ExternalSyntheticLambda7
            @Override // com.scanflow.datacapture.barinternal.pabeles.concurrency.IntProducerNumber
            public final Number accept(int i5) {
                return ImplImageStatistics_MT.$r8$lambda$qPA5jK21VYOYfHMMxm2UAt6wLBY(f, i, i4, i3, fArr, i5);
            }
        }).floatValue();
    }

    public static /* synthetic */ Number $r8$lambda$qPA5jK21VYOYfHMMxm2UAt6wLBY(float f, int i, int i2, int i3, float[] fArr, int i4) {
        int i5 = i + (i4 * i2);
        int i6 = i3 + i5;
        while (i5 < i6) {
            float f2 = fArr[i5];
            if (f2 < f) {
                f = f2;
            }
            i5++;
        }
        return Float.valueOf(f);
    }

    public static float max(final float[] fArr, final int i, int i2, final int i3, final int i4) {
        final float f = fArr[i];
        return ConcurrencyOps.max(0, i2, Float.TYPE, new IntProducerNumber() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.misc.impl.ImplImageStatistics_MT$$ExternalSyntheticLambda4
            @Override // com.scanflow.datacapture.barinternal.pabeles.concurrency.IntProducerNumber
            public final Number accept(int i5) {
                return ImplImageStatistics_MT.$r8$lambda$Ifo38Oyzb6vYr3Dy4hYaGFtkW0k(f, i, i4, i3, fArr, i5);
            }
        }).floatValue();
    }

    public static /* synthetic */ Number $r8$lambda$Ifo38Oyzb6vYr3Dy4hYaGFtkW0k(float f, int i, int i2, int i3, float[] fArr, int i4) {
        int i5 = i + (i4 * i2);
        int i6 = i3 + i5;
        while (i5 < i6) {
            float f2 = fArr[i5];
            if (f2 > f) {
                f = f2;
            }
            i5++;
        }
        return Float.valueOf(f);
    }

    public static void histogram(final GrayF32 grayF32, final float f, final int[] iArr) {
        Arrays.fill(iArr, 0);
        final ArrayList arrayList = new ArrayList();
        ConcurrencyOps.loopBlocks(0, grayF32.height, new IntRangeConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.misc.impl.ImplImageStatistics_MT$$ExternalSyntheticLambda2
            @Override // com.scanflow.datacapture.barinternal.pabeles.concurrency.IntRangeConsumer
            public final void accept(int i, int i2) {
                ImplImageStatistics_MT.m662$r8$lambda$seFM4OZH0Rxb_glzen62pFmbQg(iArr, grayF32, f, arrayList, i, i2);
            }
        });
        for (int i = 0; i < arrayList.size(); i++) {
            int[] iArr2 = (int[]) arrayList.get(i);
            for (int i2 = 0; i2 < iArr.length; i2++) {
                iArr[i2] = iArr[i2] + iArr2[i2];
            }
        }
    }

    /* JADX INFO: renamed from: $r8$lambda$se-FM4OZH0Rxb_glzen62pFmbQg, reason: not valid java name */
    public static /* synthetic */ void m662$r8$lambda$seFM4OZH0Rxb_glzen62pFmbQg(int[] iArr, GrayF32 grayF32, float f, List list, int i, int i2) {
        int[] iArr2 = new int[iArr.length];
        while (i < i2) {
            int i3 = grayF32.startIndex + (grayF32.stride * i);
            int i4 = grayF32.width + i3;
            while (i3 < i4) {
                int i5 = i3 + 1;
                int i6 = (int) (grayF32.data[i3] - f);
                iArr2[i6] = iArr2[i6] + 1;
                i3 = i5;
            }
            i++;
        }
        synchronized (list) {
            list.add(iArr2);
        }
    }

    public static void histogram(final GrayF64 grayF64, final double d, final int[] iArr) {
        Arrays.fill(iArr, 0);
        final ArrayList arrayList = new ArrayList();
        ConcurrencyOps.loopBlocks(0, grayF64.height, new IntRangeConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.misc.impl.ImplImageStatistics_MT$$ExternalSyntheticLambda3
            @Override // com.scanflow.datacapture.barinternal.pabeles.concurrency.IntRangeConsumer
            public final void accept(int i, int i2) {
                ImplImageStatistics_MT.$r8$lambda$zBY4b7_WFRxGm_wUPUzQ9a9PVY8(iArr, grayF64, d, arrayList, i, i2);
            }
        });
        for (int i = 0; i < arrayList.size(); i++) {
            int[] iArr2 = (int[]) arrayList.get(i);
            for (int i2 = 0; i2 < iArr.length; i2++) {
                iArr[i2] = iArr[i2] + iArr2[i2];
            }
        }
    }

    public static /* synthetic */ void $r8$lambda$zBY4b7_WFRxGm_wUPUzQ9a9PVY8(int[] iArr, GrayF64 grayF64, double d, List list, int i, int i2) {
        int[] iArr2 = new int[iArr.length];
        while (i < i2) {
            int i3 = grayF64.startIndex + (grayF64.stride * i);
            int i4 = grayF64.width + i3;
            while (i3 < i4) {
                int i5 = i3 + 1;
                int i6 = (int) (grayF64.data[i3] - d);
                iArr2[i6] = iArr2[i6] + 1;
                i3 = i5;
            }
            i++;
        }
        synchronized (list) {
            list.add(iArr2);
        }
    }
}
