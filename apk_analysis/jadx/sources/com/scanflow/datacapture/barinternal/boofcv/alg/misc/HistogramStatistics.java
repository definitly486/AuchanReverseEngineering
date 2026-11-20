package com.scanflow.datacapture.barinternal.boofcv.alg.misc;

/* JADX INFO: loaded from: classes.dex */
public abstract class HistogramStatistics {
    public static int count(int[] iArr, int i) {
        int i2 = 0;
        for (int i3 = 0; i3 < i; i3++) {
            i2 += iArr[i3];
        }
        return i2;
    }

    public static double mean(int[] iArr, int i) {
        return mean(iArr, count(iArr, i), i);
    }

    public static double mean(int[] iArr, int i, int i2) {
        double d = 0.0d;
        for (int i3 = 0; i3 < i2; i3++) {
            d += (double) (iArr[i3] * i3);
        }
        return d / ((double) i);
    }
}
