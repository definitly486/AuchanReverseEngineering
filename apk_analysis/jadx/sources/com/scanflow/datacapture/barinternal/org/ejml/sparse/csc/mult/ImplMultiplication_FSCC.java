package com.scanflow.datacapture.barinternal.org.ejml.sparse.csc.mult;

import com.scanflow.datacapture.barinternal.org.ejml.UtilEjml;
import com.scanflow.datacapture.barinternal.org.ejml.data.FGrowArray;
import com.scanflow.datacapture.barinternal.org.ejml.data.FMatrixSparseCSC;
import com.scanflow.datacapture.barinternal.org.ejml.data.IGrowArray;

/* JADX INFO: loaded from: classes3.dex */
public abstract class ImplMultiplication_FSCC {
    public static void mult(FMatrixSparseCSC fMatrixSparseCSC, FMatrixSparseCSC fMatrixSparseCSC2, FMatrixSparseCSC fMatrixSparseCSC3, IGrowArray iGrowArray, FGrowArray fGrowArray) {
        FMatrixSparseCSC fMatrixSparseCSC4;
        float[] fArrAdjust = UtilEjml.adjust(fGrowArray, fMatrixSparseCSC.numRows);
        int i = fMatrixSparseCSC.numRows;
        int[] iArrAdjust = UtilEjml.adjust(iGrowArray, i, i);
        fMatrixSparseCSC3.growMaxLength(fMatrixSparseCSC.nz_length + fMatrixSparseCSC2.nz_length, false);
        fMatrixSparseCSC3.indicesSorted = false;
        fMatrixSparseCSC3.nz_length = 0;
        int i2 = fMatrixSparseCSC2.col_idx[0];
        int i3 = 1;
        while (i3 <= fMatrixSparseCSC2.numCols) {
            int i4 = i3 - 1;
            int i5 = fMatrixSparseCSC2.col_idx[i3];
            fMatrixSparseCSC3.col_idx[i3] = fMatrixSparseCSC3.nz_length;
            if (i2 == i5) {
                fMatrixSparseCSC4 = fMatrixSparseCSC3;
            } else {
                while (i2 < i5) {
                    multAddColA(fMatrixSparseCSC, fMatrixSparseCSC2.nz_rows[i2], fMatrixSparseCSC2.nz_values[i2], fMatrixSparseCSC3, i3, fArrAdjust, iArrAdjust);
                    i2++;
                }
                fMatrixSparseCSC4 = fMatrixSparseCSC3;
                int[] iArr = fMatrixSparseCSC4.col_idx;
                int i6 = iArr[i3];
                for (int i7 = iArr[i4]; i7 < i6; i7++) {
                    fMatrixSparseCSC4.nz_values[i7] = fArrAdjust[fMatrixSparseCSC4.nz_rows[i7]];
                }
                i2 = i5;
            }
            i3++;
            fMatrixSparseCSC = fMatrixSparseCSC;
            fMatrixSparseCSC3 = fMatrixSparseCSC4;
        }
    }

    public static void multAddColA(FMatrixSparseCSC fMatrixSparseCSC, int i, float f, FMatrixSparseCSC fMatrixSparseCSC2, int i2, float[] fArr, int[] iArr) {
        int[] iArr2 = fMatrixSparseCSC.col_idx;
        int i3 = iArr2[i + 1];
        for (int i4 = iArr2[i]; i4 < i3; i4++) {
            int i5 = fMatrixSparseCSC.nz_rows[i4];
            if (iArr[i5] < i2) {
                int i6 = fMatrixSparseCSC2.nz_length;
                if (i6 >= fMatrixSparseCSC2.nz_rows.length) {
                    fMatrixSparseCSC2.growMaxLength((i6 * 2) + 1, true);
                }
                iArr[i5] = i2;
                int[] iArr3 = fMatrixSparseCSC2.nz_rows;
                int i7 = fMatrixSparseCSC2.nz_length;
                iArr3[i7] = i5;
                int[] iArr4 = fMatrixSparseCSC2.col_idx;
                int i8 = i7 + 1;
                fMatrixSparseCSC2.nz_length = i8;
                iArr4[i2] = i8;
                fArr[i5] = fMatrixSparseCSC.nz_values[i4] * f;
            } else {
                fArr[i5] = fArr[i5] + (fMatrixSparseCSC.nz_values[i4] * f);
            }
        }
    }
}
