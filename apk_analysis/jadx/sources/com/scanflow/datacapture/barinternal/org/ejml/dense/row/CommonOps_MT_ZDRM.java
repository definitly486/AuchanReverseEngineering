package com.scanflow.datacapture.barinternal.org.ejml.dense.row;

import com.scanflow.datacapture.barinternal.org.ejml.EjmlParameters;
import com.scanflow.datacapture.barinternal.org.ejml.data.ZMatrixRMaj;
import com.scanflow.datacapture.barinternal.org.ejml.dense.row.mult.MatrixMatrixMult_MT_ZDRM;

/* JADX INFO: loaded from: classes3.dex */
public abstract class CommonOps_MT_ZDRM {
    public static void mult(ZMatrixRMaj zMatrixRMaj, ZMatrixRMaj zMatrixRMaj2, ZMatrixRMaj zMatrixRMaj3) {
        if (zMatrixRMaj2.numCols >= EjmlParameters.CMULT_COLUMN_SWITCH) {
            MatrixMatrixMult_MT_ZDRM.mult_reorder(zMatrixRMaj, zMatrixRMaj2, zMatrixRMaj3);
        } else {
            MatrixMatrixMult_MT_ZDRM.mult_small(zMatrixRMaj, zMatrixRMaj2, zMatrixRMaj3);
        }
    }
}
