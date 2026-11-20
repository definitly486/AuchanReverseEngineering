package com.scanflow.datacapture.barinternal.org.ejml.dense.row.mult;

import com.scanflow.datacapture.barinternal.org.ejml.MatrixDimensionException;
import com.scanflow.datacapture.barinternal.org.ejml.data.DMatrix1Row;
import com.scanflow.datacapture.barinternal.org.ejml.data.DMatrixD1;
import com.scanflow.datacapture.barinternal.org.ejml.dense.row.CommonOps_DDRM;

/* JADX INFO: loaded from: classes3.dex */
public abstract class MatrixVectorMult_DDRM {
    public static void mult(DMatrix1Row dMatrix1Row, DMatrixD1 dMatrixD1, DMatrixD1 dMatrixD2) {
        int i = dMatrixD1.numRows;
        if (i == 1) {
            if (dMatrix1Row.numCols != dMatrixD1.numCols) {
                throw new MatrixDimensionException("A and B are not compatible");
            }
        } else if (dMatrixD1.numCols == 1) {
            if (dMatrix1Row.numCols != i) {
                throw new MatrixDimensionException("A and B are not compatible");
            }
        } else {
            throw new MatrixDimensionException("B is not a vector");
        }
        dMatrixD2.reshape(dMatrix1Row.numRows, 1);
        if (dMatrix1Row.numCols == 0) {
            CommonOps_DDRM.fill(dMatrixD2, 0.0d);
            return;
        }
        int i2 = 0;
        double d = dMatrixD1.get(0);
        int i3 = 0;
        int i4 = 0;
        while (i2 < dMatrix1Row.numRows) {
            double d2 = dMatrix1Row.get(i3) * d;
            i3++;
            int i5 = 1;
            while (i5 < dMatrix1Row.numCols) {
                d2 += dMatrix1Row.get(i3) * dMatrixD1.get(i5);
                i5++;
                i3++;
            }
            dMatrixD2.set(i4, d2);
            i2++;
            i4++;
        }
    }
}
