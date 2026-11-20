package com.scanflow.datacapture.barinternal.org.ejml.sparse.csc;

import com.scanflow.datacapture.barinternal.org.ejml.MatrixDimensionException;
import com.scanflow.datacapture.barinternal.org.ejml.UtilEjml;
import com.scanflow.datacapture.barinternal.org.ejml.data.DGrowArray;
import com.scanflow.datacapture.barinternal.org.ejml.data.DMatrixSparseCSC;
import com.scanflow.datacapture.barinternal.org.ejml.data.IGrowArray;
import com.scanflow.datacapture.barinternal.org.ejml.sparse.csc.mult.ImplMultiplication_DSCC;

/* JADX INFO: loaded from: classes3.dex */
public abstract class CommonOps_DSCC {
    public static DMatrixSparseCSC mult(DMatrixSparseCSC dMatrixSparseCSC, DMatrixSparseCSC dMatrixSparseCSC2, DMatrixSparseCSC dMatrixSparseCSC3) {
        return mult(dMatrixSparseCSC, dMatrixSparseCSC2, dMatrixSparseCSC3, null, null);
    }

    public static DMatrixSparseCSC mult(DMatrixSparseCSC dMatrixSparseCSC, DMatrixSparseCSC dMatrixSparseCSC2, DMatrixSparseCSC dMatrixSparseCSC3, IGrowArray iGrowArray, DGrowArray dGrowArray) {
        if (dMatrixSparseCSC.numCols != dMatrixSparseCSC2.numRows) {
            throw new MatrixDimensionException("Inconsistent matrix shapes. " + UtilEjml.stringShapes(dMatrixSparseCSC, dMatrixSparseCSC2));
        }
        DMatrixSparseCSC dMatrixSparseCSC4 = (DMatrixSparseCSC) UtilEjml.reshapeOrDeclare(dMatrixSparseCSC3, dMatrixSparseCSC, dMatrixSparseCSC.numRows, dMatrixSparseCSC2.numCols);
        ImplMultiplication_DSCC.mult(dMatrixSparseCSC, dMatrixSparseCSC2, dMatrixSparseCSC4, iGrowArray, dGrowArray);
        return dMatrixSparseCSC4;
    }
}
