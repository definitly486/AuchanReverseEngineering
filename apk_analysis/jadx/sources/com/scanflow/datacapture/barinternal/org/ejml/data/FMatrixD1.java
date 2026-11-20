package com.scanflow.datacapture.barinternal.org.ejml.data;

import com.scanflow.datacapture.barinternal.org.ejml.UtilEjml;

/* JADX INFO: loaded from: classes3.dex */
public abstract class FMatrixD1 implements ReshapeMatrix, FMatrix {
    public float[] data = UtilEjml.ZERO_LENGTH_F32;
    public int numCols;
    public int numRows;

    public abstract void reshape(int i, int i2, boolean z);

    protected void assignShape(int i, int i2) {
        UtilEjml.checkValidMatrixShape(i, i2);
        this.numRows = i;
        this.numCols = i2;
    }

    public float get(int i) {
        return this.data[i];
    }

    public float set(int i, float f) {
        this.data[i] = f;
        return f;
    }

    @Override // com.scanflow.datacapture.barinternal.org.ejml.data.ReshapeMatrix
    public void reshape(int i, int i2) {
        reshape(i, i2, false);
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
