package com.scanflow.datacapture.barinternal.org.ejml.sparse.csc;

import com.scanflow.datacapture.barinternal.org.ejml.MatrixDimensionException;
import com.scanflow.datacapture.barinternal.org.ejml.UtilEjml;
import com.scanflow.datacapture.barinternal.org.ejml.data.FMatrixSparseCSC;
import com.scanflow.datacapture.barinternal.org.ejml.simple.ops.SimpleOperations_FSCC$$ExternalSyntheticLambda0;
import com.scanflow.datacapture.barinternal.org.ejml.sparse.csc.mult.ImplMultiplication_MT_FSCC;
import com.scanflow.datacapture.barinternal.pabeles.concurrency.GrowArray;

/* JADX INFO: loaded from: classes3.dex */
public abstract class CommonOps_MT_FSCC {
    public static FMatrixSparseCSC mult(FMatrixSparseCSC fMatrixSparseCSC, FMatrixSparseCSC fMatrixSparseCSC2, FMatrixSparseCSC fMatrixSparseCSC3, GrowArray growArray) {
        if (fMatrixSparseCSC.numCols != fMatrixSparseCSC2.numRows) {
            throw new MatrixDimensionException("Inconsistent matrix shapes. " + UtilEjml.stringShapes(fMatrixSparseCSC, fMatrixSparseCSC2));
        }
        FMatrixSparseCSC fMatrixSparseCSC4 = (FMatrixSparseCSC) UtilEjml.reshapeOrDeclare(fMatrixSparseCSC3, fMatrixSparseCSC, fMatrixSparseCSC.numRows, fMatrixSparseCSC2.numCols);
        if (growArray == null) {
            growArray = new GrowArray(new SimpleOperations_FSCC$$ExternalSyntheticLambda0());
        }
        ImplMultiplication_MT_FSCC.mult(fMatrixSparseCSC, fMatrixSparseCSC2, fMatrixSparseCSC4, growArray);
        return fMatrixSparseCSC4;
    }
}
