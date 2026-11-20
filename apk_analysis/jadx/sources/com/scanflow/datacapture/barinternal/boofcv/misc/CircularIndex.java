package com.scanflow.datacapture.barinternal.boofcv.misc;

/* JADX INFO: loaded from: classes.dex */
public abstract class CircularIndex {
    public static int plusPOffset(int i, int i2, int i3) {
        return (i + i2) % i3;
    }

    public static int minusPOffset(int i, int i2, int i3) {
        int i4 = i - i2;
        return i4 < 0 ? i3 + i4 : i4;
    }

    public static int addOffset(int i, int i2, int i3) {
        int i4 = i + i2;
        return i4 < 0 ? i3 + i4 : i4 % i3;
    }

    public static int distanceP(int i, int i2, int i3) {
        int i4 = i2 - i;
        return i4 < 0 ? i3 + i4 : i4;
    }
}
