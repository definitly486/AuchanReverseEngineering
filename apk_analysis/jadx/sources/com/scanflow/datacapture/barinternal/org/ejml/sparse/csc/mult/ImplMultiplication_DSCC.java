package com.scanflow.datacapture.barinternal.org.ejml.sparse.csc.mult;

import com.scanflow.datacapture.barinternal.org.ejml.UtilEjml;
import com.scanflow.datacapture.barinternal.org.ejml.data.DGrowArray;
import com.scanflow.datacapture.barinternal.org.ejml.data.DMatrixSparseCSC;
import com.scanflow.datacapture.barinternal.org.ejml.data.IGrowArray;

/* JADX INFO: loaded from: classes3.dex */
public abstract class ImplMultiplication_DSCC {
    public static void mult(DMatrixSparseCSC dMatrixSparseCSC, DMatrixSparseCSC dMatrixSparseCSC2, DMatrixSparseCSC dMatrixSparseCSC3, IGrowArray iGrowArray, DGrowArray dGrowArray) {
        DMatrixSparseCSC dMatrixSparseCSC4;
        double[] dArrAdjust = UtilEjml.adjust(dGrowArray, dMatrixSparseCSC.numRows);
        int i = dMatrixSparseCSC.numRows;
        int[] iArrAdjust = UtilEjml.adjust(iGrowArray, i, i);
        dMatrixSparseCSC3.growMaxLength(dMatrixSparseCSC.nz_length + dMatrixSparseCSC2.nz_length, false);
        dMatrixSparseCSC3.indicesSorted = false;
        dMatrixSparseCSC3.nz_length = 0;
        int i2 = dMatrixSparseCSC2.col_idx[0];
        int i3 = 1;
        while (i3 <= dMatrixSparseCSC2.numCols) {
            int i4 = i3 - 1;
            int i5 = dMatrixSparseCSC2.col_idx[i3];
            dMatrixSparseCSC3.col_idx[i3] = dMatrixSparseCSC3.nz_length;
            if (i2 == i5) {
                dMatrixSparseCSC4 = dMatrixSparseCSC3;
            } else {
                while (i2 < i5) {
                    multAddColA(dMatrixSparseCSC, dMatrixSparseCSC2.nz_rows[i2], dMatrixSparseCSC2.nz_values[i2], dMatrixSparseCSC3, i3, dArrAdjust, iArrAdjust);
                    i2++;
                }
                dMatrixSparseCSC4 = dMatrixSparseCSC3;
                int[] iArr = dMatrixSparseCSC4.col_idx;
                int i6 = iArr[i3];
                for (int i7 = iArr[i4]; i7 < i6; i7++) {
                    dMatrixSparseCSC4.nz_values[i7] = dArrAdjust[dMatrixSparseCSC4.nz_rows[i7]];
                }
                i2 = i5;
            }
            i3++;
            dMatrixSparseCSC = dMatrixSparseCSC;
            dMatrixSparseCSC3 = dMatrixSparseCSC4;
        }
    }

    public static void multAddColA(DMatrixSparseCSC dMatrixSparseCSC, int i, double d, DMatrixSparseCSC dMatrixSparseCSC2, int i2, double[] dArr, int[] iArr) {
        int[] iArr2 = dMatrixSparseCSC.col_idx;
        int i3 = iArr2[i + 1];
        for (int i4 = iArr2[i]; i4 < i3; i4++) {
            int i5 = dMatrixSparseCSC.nz_rows[i4];
            if (iArr[i5] < i2) {
                int i6 = dMatrixSparseCSC2.nz_length;
                if (i6 >= dMatrixSparseCSC2.nz_rows.length) {
                    dMatrixSparseCSC2.growMaxLength((i6 * 2) + 1, true);
                }
                iArr[i5] = i2;
                int[] iArr3 = dMatrixSparseCSC2.nz_rows;
                int i7 = dMatrixSparseCSC2.nz_length;
                iArr3[i7] = i5;
                int[] iArr4 = dMatrixSparseCSC2.col_idx;
                int i8 = i7 + 1;
                dMatrixSparseCSC2.nz_length = i8;
                iArr4[i2] = i8;
                dArr[i5] = dMatrixSparseCSC.nz_values[i4] * d;
            } else {
                dArr[i5] = dArr[i5] + (dMatrixSparseCSC.nz_values[i4] * d);
            }
        }
    }
}
