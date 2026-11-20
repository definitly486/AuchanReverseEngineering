package com.scanflow.datacapture.barinternal.org.ejml.dense.row;

import com.scanflow.datacapture.barinternal.org.ejml.EjmlParameters;
import com.scanflow.datacapture.barinternal.org.ejml.UtilEjml;
import com.scanflow.datacapture.barinternal.org.ejml.data.FMatrix1Row;
import com.scanflow.datacapture.barinternal.org.ejml.data.FMatrixD1;
import com.scanflow.datacapture.barinternal.org.ejml.dense.row.mult.MatrixMatrixMult_FDRM;
import com.scanflow.datacapture.barinternal.org.ejml.dense.row.mult.MatrixVectorMult_FDRM;
import java.util.Arrays;

/* JADX INFO: loaded from: classes3.dex */
public abstract class CommonOps_FDRM {
    public static FMatrix1Row mult(FMatrix1Row fMatrix1Row, FMatrix1Row fMatrix1Row2, FMatrix1Row fMatrix1Row3) {
        FMatrix1Row fMatrix1Row4 = (FMatrix1Row) UtilEjml.reshapeOrDeclare(fMatrix1Row3, fMatrix1Row, fMatrix1Row.numRows, fMatrix1Row2.numCols);
        UtilEjml.checkSameInstance(fMatrix1Row, fMatrix1Row4);
        UtilEjml.checkSameInstance(fMatrix1Row2, fMatrix1Row4);
        int i = fMatrix1Row2.numCols;
        if (i == 1) {
            MatrixVectorMult_FDRM.mult(fMatrix1Row, fMatrix1Row2, fMatrix1Row4);
            return fMatrix1Row4;
        }
        if (i >= EjmlParameters.MULT_COLUMN_SWITCH) {
            MatrixMatrixMult_FDRM.mult_reorder(fMatrix1Row, fMatrix1Row2, fMatrix1Row4);
            return fMatrix1Row4;
        }
        MatrixMatrixMult_FDRM.mult_small(fMatrix1Row, fMatrix1Row2, fMatrix1Row4);
        return fMatrix1Row4;
    }

    public static void fill(FMatrixD1 fMatrixD1, float f) {
        Arrays.fill(fMatrixD1.data, 0, fMatrixD1.getNumElements(), f);
    }
}
