package com.scanflow.datacapture.barinternal.org.ejml.dense.row;

import com.scanflow.datacapture.barinternal.org.ejml.UtilEjml;
import com.scanflow.datacapture.barinternal.org.ejml.data.DMatrix1Row;
import com.scanflow.datacapture.barinternal.org.ejml.dense.row.mult.MatrixMatrixMult_MT_DDRM;

/* JADX INFO: loaded from: classes3.dex */
public abstract class CommonOps_MT_DDRM {
    public static DMatrix1Row mult(DMatrix1Row dMatrix1Row, DMatrix1Row dMatrix1Row2, DMatrix1Row dMatrix1Row3) {
        DMatrix1Row dMatrix1Row4 = (DMatrix1Row) UtilEjml.reshapeOrDeclare(dMatrix1Row3, dMatrix1Row, dMatrix1Row.numRows, dMatrix1Row2.numCols);
        UtilEjml.checkSameInstance(dMatrix1Row, dMatrix1Row4);
        UtilEjml.checkSameInstance(dMatrix1Row2, dMatrix1Row4);
        MatrixMatrixMult_MT_DDRM.mult_reorder(dMatrix1Row, dMatrix1Row2, dMatrix1Row4);
        return dMatrix1Row4;
    }
}
