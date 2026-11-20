package com.scanflow.datacapture.barinternal.org.ejml.data;

import com.scanflow.datacapture.barinternal.org.ejml.UtilEjml;

/* JADX INFO: loaded from: classes3.dex */
public abstract class DMatrixD1 implements ReshapeMatrix, DMatrix {
    public double[] data = UtilEjml.ZERO_LENGTH_F64;
    public int numCols;
    public int numRows;

    public abstract void reshape(int i, int i2, boolean z);

    protected void assignShape(int i, int i2) {
        UtilEjml.checkValidMatrixShape(i, i2);
        this.numRows = i;
        this.numCols = i2;
    }

    public void setTo(DMatrixD1 dMatrixD1) {
        reshape(dMatrixD1.numRows, dMatrixD1.numCols);
        System.arraycopy(dMatrixD1.data, 0, this.data, 0, dMatrixD1.getNumElements());
    }

    public double get(int i) {
        return this.data[i];
    }

    public double set(int i, double d) {
        this.data[i] = d;
        return d;
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
