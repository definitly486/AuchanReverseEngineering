package com.scanflow.datacapture.barinternal.org.ejml.ops;

import com.scanflow.datacapture.barinternal.org.ejml.data.FMatrix;
import com.scanflow.datacapture.barinternal.org.ejml.data.FMatrixRMaj;
import com.scanflow.datacapture.barinternal.org.ejml.data.FMatrixSparseCSC;
import com.scanflow.datacapture.barinternal.org.ejml.data.ReshapeMatrix;

/* JADX INFO: loaded from: classes3.dex */
public abstract class FConvertMatrixStruct {
    public static void convert(FMatrix fMatrix, FMatrix fMatrix2) {
        if (fMatrix2 instanceof ReshapeMatrix) {
            ((ReshapeMatrix) fMatrix2).reshape(fMatrix.getNumRows(), fMatrix.getNumCols());
        } else {
            if (fMatrix.getNumRows() != fMatrix2.getNumRows()) {
                throw new IllegalArgumentException("Number of rows do not match");
            }
            if (fMatrix.getNumCols() != fMatrix2.getNumCols()) {
                throw new IllegalArgumentException("Number of columns do not match");
            }
        }
        for (int i = 0; i < fMatrix.getNumRows(); i++) {
            for (int i2 = 0; i2 < fMatrix.getNumCols(); i2++) {
                fMatrix2.unsafe_set(i, i2, fMatrix.unsafe_get(i, i2));
            }
        }
    }

    public static FMatrixRMaj convert(FMatrixSparseCSC fMatrixSparseCSC, FMatrixRMaj fMatrixRMaj) {
        if (fMatrixRMaj == null) {
            fMatrixRMaj = new FMatrixRMaj(fMatrixSparseCSC.numRows, fMatrixSparseCSC.numCols);
        } else {
            fMatrixRMaj.reshape(fMatrixSparseCSC.numRows, fMatrixSparseCSC.numCols);
            fMatrixRMaj.zero();
        }
        int i = fMatrixSparseCSC.col_idx[0];
        int i2 = 1;
        while (i2 <= fMatrixSparseCSC.numCols) {
            int i3 = fMatrixSparseCSC.col_idx[i2];
            while (i < i3) {
                fMatrixRMaj.unsafe_set(fMatrixSparseCSC.nz_rows[i], i2 - 1, fMatrixSparseCSC.nz_values[i]);
                i++;
            }
            i2++;
            i = i3;
        }
        return fMatrixRMaj;
    }
}
