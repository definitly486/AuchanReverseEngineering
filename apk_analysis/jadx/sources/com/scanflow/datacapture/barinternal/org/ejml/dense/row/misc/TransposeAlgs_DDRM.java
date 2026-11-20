package com.scanflow.datacapture.barinternal.org.ejml.dense.row.misc;

import com.scanflow.datacapture.barinternal.org.ejml.data.DMatrix1Row;

/* JADX INFO: loaded from: classes3.dex */
public abstract class TransposeAlgs_DDRM {
    public static void square(DMatrix1Row dMatrix1Row) {
        int i = 0;
        while (i < dMatrix1Row.numRows) {
            int i2 = dMatrix1Row.numCols;
            int i3 = (i * i2) + i + 1;
            int i4 = i + 1;
            int i5 = i4 * i2;
            int i6 = i2 * i4;
            while (true) {
                i6 += i;
                if (i3 < i5) {
                    double[] dArr = dMatrix1Row.data;
                    double d = dArr[i3];
                    dArr[i3] = dArr[i6];
                    dArr[i6] = d;
                    i3++;
                    i = dMatrix1Row.numCols;
                }
            }
            i = i4;
        }
    }

    public static void block(DMatrix1Row dMatrix1Row, DMatrix1Row dMatrix1Row2, int i) {
        int i2 = 0;
        while (true) {
            int i3 = dMatrix1Row.numRows;
            if (i2 >= i3) {
                return;
            }
            int i4 = i2 + i;
            int iMin = Math.min(i3, i4) - i2;
            int i5 = dMatrix1Row.numCols * i2;
            int i6 = 0;
            while (true) {
                int i7 = dMatrix1Row.numCols;
                if (i6 < i7) {
                    int iMin2 = Math.min(i, i7 - i6) + i5;
                    while (i5 < iMin2) {
                        int i8 = i2 + iMin;
                        int i9 = i5;
                        for (int i10 = i2; i10 < i8; i10++) {
                            dMatrix1Row2.data[i10] = dMatrix1Row.data[i9];
                            i9 += dMatrix1Row.numCols;
                        }
                        i2 += dMatrix1Row2.numCols;
                        i5++;
                    }
                    i6 += i;
                }
            }
            i2 = i4;
        }
    }

    public static void standard(DMatrix1Row dMatrix1Row, DMatrix1Row dMatrix1Row2) {
        for (int i = 0; i < dMatrix1Row2.numRows; i++) {
            int i2 = dMatrix1Row2.numCols;
            int i3 = i * i2;
            int i4 = i2 + i3;
            int i5 = i;
            while (i3 < i4) {
                dMatrix1Row2.data[i3] = dMatrix1Row.data[i5];
                i5 += dMatrix1Row.numCols;
                i3++;
            }
        }
    }
}
