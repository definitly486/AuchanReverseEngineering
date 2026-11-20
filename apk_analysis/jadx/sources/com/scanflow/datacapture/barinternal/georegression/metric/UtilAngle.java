package com.scanflow.datacapture.barinternal.georegression.metric;

import com.scanflow.datacapture.barinternal.georegression.misc.GrlConstants;

/* JADX INFO: loaded from: classes3.dex */
public abstract class UtilAngle {
    public static float degreeToRadian(float f) {
        return (GrlConstants.F_PI * f) / 180.0f;
    }

    public static float radian(float f) {
        return degreeToRadian(f);
    }

    public static double distanceCCW(double d, double d2) {
        return d2 >= d ? d2 - d : GrlConstants.PI2 - (d - d2);
    }

    public static double distanceCW(double d, double d2) {
        return d >= d2 ? d - d2 : GrlConstants.PI2 - (d2 - d);
    }

    public static double minus(double d, double d2) {
        double dDistanceCCW = distanceCCW(d, d2);
        double dDistanceCW = distanceCW(d, d2);
        return dDistanceCCW < dDistanceCW ? -dDistanceCCW : dDistanceCW;
    }

    public static double dist(double d, double d2) {
        return Math.abs(minus(d, d2));
    }
}
