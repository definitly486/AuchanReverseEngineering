package com.scanflow.datacapture.barinternal.org.ejml.data;

/* JADX INFO: loaded from: classes3.dex */
public class BMatrixRMaj implements ReshapeMatrix {
    public boolean[] data;
    public int numCols;
    public int numRows;

    public BMatrixRMaj(int i, int i2) {
        this.data = new boolean[i * i2];
        this.numRows = i;
        this.numCols = i2;
    }

    public int getNumElements() {
        return this.numRows * this.numCols;
    }

    public boolean get(int i, int i2) {
        if (!isInBounds(i, i2)) {
            throw new IllegalArgumentException("Out of matrix bounds. " + i + " " + i2);
        }
        return this.data[(i * this.numCols) + i2];
    }

    public void set(int i, int i2, boolean z) {
        if (!isInBounds(i, i2)) {
            throw new IllegalArgumentException("Out of matrix bounds. " + i + " " + i2);
        }
        this.data[(i * this.numCols) + i2] = z;
    }

    public boolean isInBounds(int i, int i2) {
        return i2 >= 0 && i2 < this.numCols && i >= 0 && i < this.numRows;
    }

    @Override // com.scanflow.datacapture.barinternal.org.ejml.data.ReshapeMatrix
    public void reshape(int i, int i2) {
        int i3 = i * i2;
        if (this.data.length < i3) {
            this.data = new boolean[i3];
        }
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

    @Override // com.scanflow.datacapture.barinternal.org.ejml.data.Matrix
    public Matrix copy() {
        BMatrixRMaj bMatrixRMaj = new BMatrixRMaj(this.numRows, this.numCols);
        bMatrixRMaj.setTo(this);
        return bMatrixRMaj;
    }

    public void setTo(Matrix matrix) {
        BMatrixRMaj bMatrixRMaj = (BMatrixRMaj) matrix;
        reshape(matrix.getNumRows(), matrix.getNumCols());
        System.arraycopy(bMatrixRMaj.data, 0, this.data, 0, bMatrixRMaj.getNumElements());
    }

    @Override // com.scanflow.datacapture.barinternal.org.ejml.data.Matrix
    public BMatrixRMaj create(int i, int i2) {
        return new BMatrixRMaj(i, i2);
    }

    @Override // com.scanflow.datacapture.barinternal.org.ejml.data.Matrix
    public MatrixType getType() {
        return MatrixType.UNSPECIFIED;
    }
}
