package com.scanflow.datacapture.barinternal.org.ejml.dense.row.mult;

import com.scanflow.datacapture.barinternal.org.ejml.MatrixDimensionException;
import com.scanflow.datacapture.barinternal.org.ejml.data.FMatrix1Row;
import com.scanflow.datacapture.barinternal.org.ejml.data.FMatrixD1;
import com.scanflow.datacapture.barinternal.org.ejml.dense.row.CommonOps_FDRM;

/* JADX INFO: loaded from: classes3.dex */
public abstract class MatrixVectorMult_FDRM {
    public static void mult(FMatrix1Row fMatrix1Row, FMatrixD1 fMatrixD1, FMatrixD1 fMatrixD2) {
        int i = fMatrixD1.numRows;
        if (i == 1) {
            if (fMatrix1Row.numCols != fMatrixD1.numCols) {
                throw new MatrixDimensionException("A and B are not compatible");
            }
        } else if (fMatrixD1.numCols == 1) {
            if (fMatrix1Row.numCols != i) {
                throw new MatrixDimensionException("A and B are not compatible");
            }
        } else {
            throw new MatrixDimensionException("B is not a vector");
        }
        fMatrixD2.reshape(fMatrix1Row.numRows, 1);
        if (fMatrix1Row.numCols == 0) {
            CommonOps_FDRM.fill(fMatrixD2, 0.0f);
            return;
        }
        int i2 = 0;
        float f = fMatrixD1.get(0);
        int i3 = 0;
        int i4 = 0;
        while (i2 < fMatrix1Row.numRows) {
            int i5 = i3 + 1;
            float f2 = fMatrix1Row.get(i3) * f;
            int i6 = 1;
            while (i6 < fMatrix1Row.numCols) {
                f2 += fMatrix1Row.get(i5) * fMatrixD1.get(i6);
                i6++;
                i5++;
            }
            fMatrixD2.set(i4, f2);
            i2++;
            i3 = i5;
            i4++;
        }
    }
}
