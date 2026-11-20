package com.scanflow.datacapture.barinternal.org.ejml.dense.row;

import com.scanflow.datacapture.barinternal.org.ejml.UtilEjml;
import com.scanflow.datacapture.barinternal.org.ejml.data.FMatrix1Row;
import com.scanflow.datacapture.barinternal.org.ejml.dense.row.mult.MatrixMatrixMult_MT_FDRM;

/* JADX INFO: loaded from: classes3.dex */
public abstract class CommonOps_MT_FDRM {
    public static FMatrix1Row mult(FMatrix1Row fMatrix1Row, FMatrix1Row fMatrix1Row2, FMatrix1Row fMatrix1Row3) {
        FMatrix1Row fMatrix1Row4 = (FMatrix1Row) UtilEjml.reshapeOrDeclare(fMatrix1Row3, fMatrix1Row, fMatrix1Row.numRows, fMatrix1Row2.numCols);
        UtilEjml.checkSameInstance(fMatrix1Row, fMatrix1Row4);
        UtilEjml.checkSameInstance(fMatrix1Row2, fMatrix1Row4);
        MatrixMatrixMult_MT_FDRM.mult_reorder(fMatrix1Row, fMatrix1Row2, fMatrix1Row4);
        return fMatrix1Row4;
    }
}
