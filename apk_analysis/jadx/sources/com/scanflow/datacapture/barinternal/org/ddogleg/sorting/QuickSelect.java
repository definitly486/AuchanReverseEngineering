package com.scanflow.datacapture.barinternal.org.ddogleg.sorting;

/* JADX INFO: loaded from: classes3.dex */
public abstract class QuickSelect {
    public static int selectIndex(double[] dArr, int i, int i2, int[] iArr) {
        int i3;
        int i4;
        int i5;
        int i6 = 0;
        for (int i7 = 0; i7 < i2; i7++) {
            iArr[i7] = i7;
        }
        int i8 = i2 - 1;
        while (true) {
            i3 = i6 + 1;
            if (i8 <= i3) {
                break;
            }
            int i9 = (i6 + i8) >> 1;
            int i10 = iArr[i9];
            iArr[i9] = iArr[i3];
            iArr[i3] = i10;
            int i11 = iArr[i6];
            double d = dArr[i11];
            int i12 = iArr[i8];
            if (d > dArr[i12]) {
                iArr[i6] = i12;
                iArr[i8] = i11;
            }
            int i13 = iArr[i3];
            double d2 = dArr[i13];
            int i14 = iArr[i8];
            if (d2 > dArr[i14]) {
                iArr[i3] = i14;
                iArr[i8] = i13;
            }
            int i15 = iArr[i6];
            double d3 = dArr[i15];
            int i16 = iArr[i3];
            if (d3 > dArr[i16]) {
                iArr[i3] = i15;
                iArr[i6] = i16;
            }
            int i17 = iArr[i3];
            int i18 = i8;
            int i19 = i3;
            while (true) {
                i19++;
                if (dArr[iArr[i19]] >= dArr[i17]) {
                    while (true) {
                        i4 = i18 - 1;
                        i5 = iArr[i4];
                        if (dArr[i5] <= dArr[i17]) {
                            break;
                        }
                        i18 = i4;
                    }
                    if (i4 < i19) {
                        break;
                    }
                    int i20 = iArr[i19];
                    iArr[i19] = i5;
                    iArr[i4] = i20;
                    i18 = i4;
                }
            }
            iArr[i3] = i5;
            iArr[i4] = i17;
            if (i4 >= i) {
                i8 = i18 - 2;
            }
            if (i4 <= i) {
                i6 = i19;
            }
        }
        if (i8 == i3) {
            int i21 = iArr[i8];
            double d4 = dArr[i21];
            int i22 = iArr[i6];
            if (d4 < dArr[i22]) {
                iArr[i6] = i21;
                iArr[i8] = i22;
            }
        }
        return iArr[i];
    }
}
