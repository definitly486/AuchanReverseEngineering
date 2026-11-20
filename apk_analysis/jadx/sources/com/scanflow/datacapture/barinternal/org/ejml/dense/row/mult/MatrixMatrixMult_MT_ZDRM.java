package com.scanflow.datacapture.barinternal.org.ejml.dense.row.mult;

import com.scanflow.datacapture.barinternal.org.ejml.MatrixDimensionException;
import com.scanflow.datacapture.barinternal.org.ejml.data.ZMatrixRMaj;
import com.scanflow.datacapture.barinternal.org.ejml.dense.row.CommonOps_ZDRM;
import com.scanflow.datacapture.barinternal.pabeles.concurrency.ConcurrencyOps;
import java.util.function.IntConsumer;

/* JADX INFO: loaded from: classes3.dex */
public abstract class MatrixMatrixMult_MT_ZDRM {
    public static void mult_reorder(final ZMatrixRMaj zMatrixRMaj, final ZMatrixRMaj zMatrixRMaj2, final ZMatrixRMaj zMatrixRMaj3) {
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
        final int rowStride = zMatrixRMaj.getRowStride();
        final int rowStride2 = zMatrixRMaj2.getRowStride();
        final int rowStride3 = zMatrixRMaj3.getRowStride();
        final int i3 = zMatrixRMaj2.numRows * rowStride2;
        ConcurrencyOps.loopFor(0, zMatrixRMaj.numRows, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.org.ejml.dense.row.mult.MatrixMatrixMult_MT_ZDRM$$ExternalSyntheticLambda1
            @Override // java.util.function.IntConsumer
            public final void accept(int i4) {
                MatrixMatrixMult_MT_ZDRM.$r8$lambda$1YauJERjRxWy3_B7m63We9q4eq8(rowStride3, rowStride, rowStride2, zMatrixRMaj, zMatrixRMaj2, zMatrixRMaj3, i3, i4);
            }
        });
    }

    public static /* synthetic */ void $r8$lambda$1YauJERjRxWy3_B7m63We9q4eq8(int i, int i2, int i3, ZMatrixRMaj zMatrixRMaj, ZMatrixRMaj zMatrixRMaj2, ZMatrixRMaj zMatrixRMaj3, int i4, int i5) {
        int i6 = i5 * i;
        int i7 = i5 * i2;
        double[] dArr = zMatrixRMaj.data;
        int i8 = i7 + 1;
        double d = dArr[i7];
        int i9 = i7 + 2;
        double d2 = dArr[i8];
        int i10 = 0;
        int i11 = i6;
        while (i10 < i3) {
            double[] dArr2 = zMatrixRMaj2.data;
            int i12 = i10 + 1;
            double d3 = dArr2[i10];
            i10 += 2;
            double d4 = dArr2[i12];
            double[] dArr3 = zMatrixRMaj3.data;
            int i13 = i11 + 1;
            dArr3[i11] = (d * d3) - (d2 * d4);
            i11 += 2;
            dArr3[i13] = (d4 * d) + (d3 * d2);
        }
        while (i10 != i4) {
            int i14 = i10 + i3;
            double[] dArr4 = zMatrixRMaj.data;
            int i15 = i9 + 1;
            double d5 = dArr4[i9];
            i9 += 2;
            double d6 = dArr4[i15];
            int i16 = i6;
            while (i10 < i14) {
                double[] dArr5 = zMatrixRMaj2.data;
                int i17 = i10 + 1;
                double d7 = dArr5[i10];
                i10 += 2;
                double d8 = dArr5[i17];
                double[] dArr6 = zMatrixRMaj3.data;
                int i18 = i16 + 1;
                dArr6[i16] = dArr6[i16] + ((d5 * d7) - (d6 * d8));
                i16 += 2;
                dArr6[i18] = dArr6[i18] + (d8 * d5) + (d7 * d6);
            }
        }
    }

    public static void mult_small(final ZMatrixRMaj zMatrixRMaj, final ZMatrixRMaj zMatrixRMaj2, final ZMatrixRMaj zMatrixRMaj3) {
        if (zMatrixRMaj == zMatrixRMaj3 || zMatrixRMaj2 == zMatrixRMaj3) {
            throw new IllegalArgumentException("Neither 'a' or 'b' can be the same matrix as 'c'");
        }
        if (zMatrixRMaj.numCols != zMatrixRMaj2.numRows) {
            throw new MatrixDimensionException("The 'a' and 'b' matrices do not have compatible dimensions");
        }
        if (zMatrixRMaj.numRows != zMatrixRMaj3.numRows || zMatrixRMaj2.numCols != zMatrixRMaj3.numCols) {
            throw new MatrixDimensionException("The results matrix does not have the desired dimensions");
        }
        final int rowStride = zMatrixRMaj.getRowStride();
        final int rowStride2 = zMatrixRMaj2.getRowStride();
        ConcurrencyOps.loopFor(0, zMatrixRMaj.numRows, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.org.ejml.dense.row.mult.MatrixMatrixMult_MT_ZDRM$$ExternalSyntheticLambda0
            @Override // java.util.function.IntConsumer
            public final void accept(int i) {
                MatrixMatrixMult_MT_ZDRM.$r8$lambda$aa_0xnb2uPQKdVjb_e7EGSSZep0(rowStride, rowStride2, zMatrixRMaj2, zMatrixRMaj, zMatrixRMaj3, i);
            }
        });
    }

    public static /* synthetic */ void $r8$lambda$aa_0xnb2uPQKdVjb_e7EGSSZep0(int i, int i2, ZMatrixRMaj zMatrixRMaj, ZMatrixRMaj zMatrixRMaj2, ZMatrixRMaj zMatrixRMaj3, int i3) {
        int i4 = i3 * i;
        int i5 = i3 * i2;
        for (int i6 = 0; i6 < zMatrixRMaj.numCols; i6++) {
            int i7 = i6 * 2;
            int i8 = i4 + i;
            double d = 0.0d;
            int i9 = i4;
            double d2 = 0.0d;
            while (i9 < i8) {
                double[] dArr = zMatrixRMaj2.data;
                int i10 = i9 + 1;
                double d3 = dArr[i9];
                i9 += 2;
                double d4 = dArr[i10];
                double[] dArr2 = zMatrixRMaj.data;
                double d5 = dArr2[i7];
                double d6 = dArr2[i7 + 1];
                d += (d3 * d5) - (d4 * d6);
                d2 += (d3 * d6) + (d4 * d5);
                i7 += i2;
            }
            double[] dArr3 = zMatrixRMaj3.data;
            int i11 = i5 + 1;
            dArr3[i5] = d;
            i5 += 2;
            dArr3[i11] = d2;
        }
    }
}
