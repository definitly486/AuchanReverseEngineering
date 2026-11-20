package com.scanflow.datacapture.barinternal.org.ejml.data;

import com.scanflow.datacapture.barinternal.org.ejml.UtilEjml;

/* JADX INFO: loaded from: classes3.dex */
public abstract class ZMatrixD1 implements ZMatrix, ReshapeMatrix {
    public double[] data = UtilEjml.ZERO_LENGTH_F64;
    public int numCols;
    public int numRows;

    protected void assignShape(int i, int i2) {
        UtilEjml.checkValidMatrixShapeComplex(i, i2);
        this.numRows = i;
        this.numCols = i2;
    }

    @Override // com.scanflow.datacapture.barinternal.org.ejml.data.Matrix
    public int getNumRows() {
        return this.numRows;
    }

    @Override // com.scanflow.datacapture.barinternal.org.ejml.data.Matrix
    public int getNumCols() {
        return this.numCols;
    }
}
