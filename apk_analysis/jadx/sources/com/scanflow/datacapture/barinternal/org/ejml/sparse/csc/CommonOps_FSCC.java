package com.scanflow.datacapture.barinternal.org.ejml.sparse.csc;

import com.scanflow.datacapture.barinternal.org.ejml.MatrixDimensionException;
import com.scanflow.datacapture.barinternal.org.ejml.UtilEjml;
import com.scanflow.datacapture.barinternal.org.ejml.data.FGrowArray;
import com.scanflow.datacapture.barinternal.org.ejml.data.FMatrixSparseCSC;
import com.scanflow.datacapture.barinternal.org.ejml.data.IGrowArray;
import com.scanflow.datacapture.barinternal.org.ejml.sparse.csc.mult.ImplMultiplication_FSCC;

/* JADX INFO: loaded from: classes3.dex */
public abstract class CommonOps_FSCC {
    public static FMatrixSparseCSC mult(FMatrixSparseCSC fMatrixSparseCSC, FMatrixSparseCSC fMatrixSparseCSC2, FMatrixSparseCSC fMatrixSparseCSC3) {
        return mult(fMatrixSparseCSC, fMatrixSparseCSC2, fMatrixSparseCSC3, null, null);
    }

    public static FMatrixSparseCSC mult(FMatrixSparseCSC fMatrixSparseCSC, FMatrixSparseCSC fMatrixSparseCSC2, FMatrixSparseCSC fMatrixSparseCSC3, IGrowArray iGrowArray, FGrowArray fGrowArray) {
        if (fMatrixSparseCSC.numCols != fMatrixSparseCSC2.numRows) {
            throw new MatrixDimensionException("Inconsistent matrix shapes. " + UtilEjml.stringShapes(fMatrixSparseCSC, fMatrixSparseCSC2));
        }
        FMatrixSparseCSC fMatrixSparseCSC4 = (FMatrixSparseCSC) UtilEjml.reshapeOrDeclare(fMatrixSparseCSC3, fMatrixSparseCSC, fMatrixSparseCSC.numRows, fMatrixSparseCSC2.numCols);
        ImplMultiplication_FSCC.mult(fMatrixSparseCSC, fMatrixSparseCSC2, fMatrixSparseCSC4, iGrowArray, fGrowArray);
        return fMatrixSparseCSC4;
    }
}
