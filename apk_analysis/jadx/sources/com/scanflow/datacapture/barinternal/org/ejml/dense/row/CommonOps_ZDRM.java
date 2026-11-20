package com.scanflow.datacapture.barinternal.org.ejml.dense.row;

import com.scanflow.datacapture.barinternal.org.ejml.EjmlParameters;
import com.scanflow.datacapture.barinternal.org.ejml.data.ZMatrixD1;
import com.scanflow.datacapture.barinternal.org.ejml.data.ZMatrixRMaj;
import com.scanflow.datacapture.barinternal.org.ejml.dense.row.mult.MatrixMatrixMult_ZDRM;

/* JADX INFO: loaded from: classes3.dex */
public abstract class CommonOps_ZDRM {
    public static void fill(ZMatrixD1 zMatrixD1, double d, double d2) {
        int dataLength = zMatrixD1.getDataLength();
        for (int i = 0; i < dataLength; i += 2) {
            double[] dArr = zMatrixD1.data;
            dArr[i] = d;
            dArr[i + 1] = d2;
        }
    }

    public static void mult(ZMatrixRMaj zMatrixRMaj, ZMatrixRMaj zMatrixRMaj2, ZMatrixRMaj zMatrixRMaj3) {
        if (zMatrixRMaj2.numCols >= EjmlParameters.CMULT_COLUMN_SWITCH) {
            MatrixMatrixMult_ZDRM.mult_reorder(zMatrixRMaj, zMatrixRMaj2, zMatrixRMaj3);
        } else {
            MatrixMatrixMult_ZDRM.mult_small(zMatrixRMaj, zMatrixRMaj2, zMatrixRMaj3);
        }
    }
}
