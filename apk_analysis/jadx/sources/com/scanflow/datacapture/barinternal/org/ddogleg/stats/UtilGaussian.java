package com.scanflow.datacapture.barinternal.org.ddogleg.stats;

/* JADX INFO: loaded from: classes3.dex */
public abstract class UtilGaussian {
    public static double SQRT_2_PI = Math.sqrt(6.283185307179586d);

    public static double computePDF(double d, double d2, double d3) {
        double d4 = d3 - d;
        return Math.exp(((-d4) * d4) / ((2.0d * d2) * d2)) / (d2 * SQRT_2_PI);
    }
}
