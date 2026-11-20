package com.scanflow.datacapture.barinternal.org.ejml.dense.row.mult;

import com.scanflow.datacapture.barinternal.org.ejml.MatrixDimensionException;
import com.scanflow.datacapture.barinternal.org.ejml.data.ZMatrixRMaj;
import com.scanflow.datacapture.barinternal.org.ejml.dense.row.CommonOps_ZDRM;

/* JADX INFO: loaded from: classes3.dex */
public abstract class MatrixMatrixMult_ZDRM {
    public static void mult_reorder(ZMatrixRMaj zMatrixRMaj, ZMatrixRMaj zMatrixRMaj2, ZMatrixRMaj zMatrixRMaj3) {
        if (zMatrixRMaj == zMatrixRMaj3 || zMatrixRMaj2 == zMatrixRMaj3) {
            throw new IllegalArgumentException("Neither 'a' or 'b' can be the same matrix as 'c'");
        }
        int i = zMatrixRMaj.numCols;
        if (i != zMatrixRMaj2.numRows) {
            throw new MatrixDimensionException("The 'a' and 'b' matrices do not have compatible dimensions");
        }
        int i2 = zMatrixRMaj.numRows;
        if (i2 != zMatrixRMaj3.numRows || zMatrixRMaj2.numCols != zMatrixRMaj3.numCols) {
            throw new MatrixDimensionException("The results matrix does not have the desired dimensions");
        }
        if (i == 0 || i2 == 0) {
            CommonOps_ZDRM.fill(zMatrixRMaj3, 0.0d, 0.0d);
            return;
        }
        int rowStride = zMatrixRMaj.getRowStride();
        int rowStride2 = zMatrixRMaj2.getRowStride();
        int rowStride3 = zMatrixRMaj3.getRowStride();
        int i3 = zMatrixRMaj2.numRows * rowStride2;
        for (int i4 = 0; i4 < zMatrixRMaj.numRows; i4++) {
            int i5 = i4 * rowStride3;
            int i6 = i4 * rowStride;
            double[] dArr = zMatrixRMaj.data;
            int i7 = i6 + 1;
            double d = dArr[i6];
            int i8 = i6 + 2;
            double d2 = dArr[i7];
            int i9 = i5;
            int i10 = 0;
            while (i10 < rowStride2) {
                double[] dArr2 = zMatrixRMaj2.data;
                int i11 = i10 + 1;
                double d3 = dArr2[i10];
                i10 += 2;
                double d4 = dArr2[i11];
                double[] dArr3 = zMatrixRMaj3.data;
                int i12 = i9 + 1;
                dArr3[i9] = (d * d3) - (d2 * d4);
                i9 += 2;
                dArr3[i12] = (d4 * d) + (d3 * d2);
            }
            while (i10 != i3) {
                int i13 = i10 + rowStride2;
                double[] dArr4 = zMatrixRMaj.data;
                int i14 = i8 + 1;
                double d5 = dArr4[i8];
                i8 += 2;
                double d6 = dArr4[i14];
                int i15 = i5;
                while (i10 < i13) {
                    double[] dArr5 = zMatrixRMaj2.data;
                    int i16 = i10 + 1;
                    double d7 = dArr5[i10];
                    i10 += 2;
                    double d8 = dArr5[i16];
                    double[] dArr6 = zMatrixRMaj3.data;
                    int i17 = i15 + 1;
                    dArr6[i15] = dArr6[i15] + ((d5 * d7) - (d6 * d8));
                    i15 += 2;
                    dArr6[i17] = dArr6[i17] + (d8 * d5) + (d7 * d6);
                }
            }
        }
    }

    public static void mult_small(ZMatrixRMaj zMatrixRMaj, ZMatrixRMaj zMatrixRMaj2, ZMatrixRMaj zMatrixRMaj3) {
        if (zMatrixRMaj == zMatrixRMaj3 || zMatrixRMaj2 == zMatrixRMaj3) {
            throw new IllegalArgumentException("Neither 'a' or 'b' can be the same matrix as 'c'");
        }
        if (zMatrixRMaj.numCols != zMatrixRMaj2.numRows) {
            throw new MatrixDimensionException("The 'a' and 'b' matrices do not have compatible dimensions");
        }
        if (zMatrixRMaj.numRows != zMatrixRMaj3.numRows || zMatrixRMaj2.numCols != zMatrixRMaj3.numCols) {
            throw new MatrixDimensionException("The results matrix does not have the desired dimensions");
        }
        int rowStride = zMatrixRMaj.getRowStride();
        int rowStride2 = zMatrixRMaj2.getRowStride();
        for (int i = 0; i < zMatrixRMaj.numRows; i++) {
            int i2 = i * rowStride;
            int i3 = i * rowStride2;
            int i4 = 0;
            while (i4 < zMatrixRMaj2.numCols) {
                int i5 = i4 * 2;
                int i6 = i2 + rowStride;
                double d = 0.0d;
                int i7 = i2;
                double d2 = 0.0d;
                while (i7 < i6) {
                    int i8 = rowStride;
                    double[] dArr = zMatrixRMaj.data;
                    int i9 = i7 + 1;
                    double d3 = dArr[i7];
                    i7 += 2;
                    double d4 = dArr[i9];
                    double[] dArr2 = zMatrixRMaj2.data;
                    double d5 = dArr2[i5];
                    double d6 = dArr2[i5 + 1];
                    d += (d3 * d5) - (d4 * d6);
                    d2 += (d3 * d6) + (d4 * d5);
                    i5 += rowStride2;
                    rowStride = i8;
                }
                int i10 = rowStride;
                double[] dArr3 = zMatrixRMaj3.data;
                int i11 = i3 + 1;
                dArr3[i3] = d;
                i3 += 2;
                dArr3[i11] = d2;
                i4++;
                rowStride = i10;
            }
        }
    }
}
