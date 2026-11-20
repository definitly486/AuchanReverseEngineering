package com.scanflow.datacapture.barinternal.org.ejml.ops;

import com.scanflow.datacapture.barinternal.org.ejml.data.DMatrix;
import com.scanflow.datacapture.barinternal.org.ejml.data.DMatrixRMaj;
import com.scanflow.datacapture.barinternal.org.ejml.data.DMatrixSparseCSC;
import com.scanflow.datacapture.barinternal.org.ejml.data.ReshapeMatrix;

/* JADX INFO: loaded from: classes3.dex */
public abstract class DConvertMatrixStruct {
    public static void convert(DMatrix dMatrix, DMatrix dMatrix2) {
        if (dMatrix2 instanceof ReshapeMatrix) {
            ((ReshapeMatrix) dMatrix2).reshape(dMatrix.getNumRows(), dMatrix.getNumCols());
        } else {
            if (dMatrix.getNumRows() != dMatrix2.getNumRows()) {
                throw new IllegalArgumentException("Number of rows do not match");
            }
            if (dMatrix.getNumCols() != dMatrix2.getNumCols()) {
                throw new IllegalArgumentException("Number of columns do not match");
            }
        }
        for (int i = 0; i < dMatrix.getNumRows(); i++) {
            for (int i2 = 0; i2 < dMatrix.getNumCols(); i2++) {
                dMatrix2.unsafe_set(i, i2, dMatrix.unsafe_get(i, i2));
            }
        }
    }

    public static DMatrixRMaj convert(DMatrixSparseCSC dMatrixSparseCSC, DMatrixRMaj dMatrixRMaj) {
        if (dMatrixRMaj == null) {
            dMatrixRMaj = new DMatrixRMaj(dMatrixSparseCSC.numRows, dMatrixSparseCSC.numCols);
        } else {
            dMatrixRMaj.reshape(dMatrixSparseCSC.numRows, dMatrixSparseCSC.numCols);
            dMatrixRMaj.zero();
        }
        int i = dMatrixSparseCSC.col_idx[0];
        int i2 = 1;
        while (i2 <= dMatrixSparseCSC.numCols) {
            int i3 = dMatrixSparseCSC.col_idx[i2];
            while (i < i3) {
                dMatrixRMaj.unsafe_set(dMatrixSparseCSC.nz_rows[i], i2 - 1, dMatrixSparseCSC.nz_values[i]);
                i++;
            }
            i2++;
            i = i3;
        }
        return dMatrixRMaj;
    }
}
