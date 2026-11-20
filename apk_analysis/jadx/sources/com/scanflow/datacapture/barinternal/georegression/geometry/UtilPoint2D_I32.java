package com.scanflow.datacapture.barinternal.georegression.geometry;

/* JADX INFO: loaded from: classes3.dex */
public abstract class UtilPoint2D_I32 {
    public static int distanceSq(int i, int i2, int i3, int i4) {
        int i5 = i3 - i;
        int i6 = i4 - i2;
        return (i5 * i5) + (i6 * i6);
    }
}
