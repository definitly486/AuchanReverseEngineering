package com.scanflow.datacapture.barinternal.org.ejml.sparse.csc;

import com.scanflow.datacapture.barinternal.org.ejml.MatrixDimensionException;
import com.scanflow.datacapture.barinternal.org.ejml.UtilEjml;
import com.scanflow.datacapture.barinternal.org.ejml.data.DMatrixSparseCSC;
import com.scanflow.datacapture.barinternal.org.ejml.simple.ops.SimpleOperations_DSCC$$ExternalSyntheticLambda0;
import com.scanflow.datacapture.barinternal.org.ejml.sparse.csc.mult.ImplMultiplication_MT_DSCC;
import com.scanflow.datacapture.barinternal.pabeles.concurrency.GrowArray;

/* JADX INFO: loaded from: classes3.dex */
public abstract class CommonOps_MT_DSCC {
    public static DMatrixSparseCSC mult(DMatrixSparseCSC dMatrixSparseCSC, DMatrixSparseCSC dMatrixSparseCSC2, DMatrixSparseCSC dMatrixSparseCSC3, GrowArray growArray) {
        if (dMatrixSparseCSC.numCols != dMatrixSparseCSC2.numRows) {
            throw new MatrixDimensionException("Inconsistent matrix shapes. " + UtilEjml.stringShapes(dMatrixSparseCSC, dMatrixSparseCSC2));
        }
        DMatrixSparseCSC dMatrixSparseCSC4 = (DMatrixSparseCSC) UtilEjml.reshapeOrDeclare(dMatrixSparseCSC3, dMatrixSparseCSC, dMatrixSparseCSC.numRows, dMatrixSparseCSC2.numCols);
        if (growArray == null) {
            growArray = new GrowArray(new SimpleOperations_DSCC$$ExternalSyntheticLambda0());
        }
        ImplMultiplication_MT_DSCC.mult(dMatrixSparseCSC, dMatrixSparseCSC2, dMatrixSparseCSC4, growArray);
        return dMatrixSparseCSC4;
    }
}
