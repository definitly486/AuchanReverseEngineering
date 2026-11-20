package com.scanflow.datacapture.barinternal.org.ejml.dense.row.mult;

import com.scanflow.datacapture.barinternal.org.ejml.UtilEjml;
import com.scanflow.datacapture.barinternal.org.ejml.data.DMatrix1Row;
import com.scanflow.datacapture.barinternal.org.ejml.dense.row.CommonOps_DDRM;
import com.scanflow.datacapture.barinternal.pabeles.concurrency.ConcurrencyOps;
import java.util.function.IntConsumer;

/* JADX INFO: loaded from: classes3.dex */
public abstract class MatrixMatrixMult_MT_DDRM {
    public static void mult_reorder(final DMatrix1Row dMatrix1Row, final DMatrix1Row dMatrix1Row2, final DMatrix1Row dMatrix1Row3) {
        int i;
        UtilEjml.assertTrue((dMatrix1Row == dMatrix1Row3 || dMatrix1Row2 == dMatrix1Row3) ? false : true, "Neither 'A' or 'B' can be the same matrix as 'C'");
        UtilEjml.assertShape(dMatrix1Row.numCols, dMatrix1Row2.numRows, "The 'A' and 'B' matrices do not have compatible dimensions");
        dMatrix1Row3.reshape(dMatrix1Row.numRows, dMatrix1Row2.numCols);
        if (dMatrix1Row.numCols == 0 || (i = dMatrix1Row.numRows) == 0) {
            CommonOps_DDRM.fill(dMatrix1Row3, 0.0d);
        } else {
            final int i2 = dMatrix1Row2.numRows * dMatrix1Row2.numCols;
            ConcurrencyOps.loopFor(0, i, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.org.ejml.dense.row.mult.MatrixMatrixMult_MT_DDRM$$ExternalSyntheticLambda0
                @Override // java.util.function.IntConsumer
                public final void accept(int i3) {
                    MatrixMatrixMult_MT_DDRM.m908$r8$lambda$LYUuLw1rMTAlPmjyjOrARa8xw(dMatrix1Row3, dMatrix1Row, dMatrix1Row2, i2, i3);
                }
            });
        }
    }

    /* JADX INFO: renamed from: $r8$lambda$LYUuLw1-rM-TAlPmjyjOrARa8xw, reason: not valid java name */
    public static /* synthetic */ void m908$r8$lambda$LYUuLw1rMTAlPmjyjOrARa8xw(DMatrix1Row dMatrix1Row, DMatrix1Row dMatrix1Row2, DMatrix1Row dMatrix1Row3, int i, int i2) {
        int i3 = dMatrix1Row.numCols * i2;
        int i4 = dMatrix1Row2.numCols * i2;
        int i5 = dMatrix1Row3.numCols;
        int i6 = i4 + 1;
        double d = dMatrix1Row2.data[i4];
        int i7 = 0;
        int i8 = i3;
        while (i7 < i5) {
            dMatrix1Row.set(i8, dMatrix1Row3.data[i7] * d);
            i8++;
            i7++;
        }
        while (i7 != i) {
            int i9 = dMatrix1Row3.numCols + i7;
            int i10 = i6 + 1;
            double d2 = dMatrix1Row2.data[i6];
            int i11 = i3;
            while (i7 < i9) {
                double[] dArr = dMatrix1Row.data;
                dArr[i11] = dArr[i11] + (dMatrix1Row3.data[i7] * d2);
                i11++;
                i7++;
            }
            i6 = i10;
        }
    }
}
