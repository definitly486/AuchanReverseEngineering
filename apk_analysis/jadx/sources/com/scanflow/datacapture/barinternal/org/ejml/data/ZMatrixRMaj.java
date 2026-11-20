package com.scanflow.datacapture.barinternal.org.ejml.data;

/* JADX INFO: loaded from: classes3.dex */
public class ZMatrixRMaj extends ZMatrixD1 {
    public ZMatrixRMaj(ZMatrixRMaj zMatrixRMaj) {
        this(zMatrixRMaj.numRows, zMatrixRMaj.numCols);
        setTo(zMatrixRMaj);
    }

    public ZMatrixRMaj(int i, int i2) {
        assignShape(i, i2);
        this.data = new double[i * i2 * 2];
    }

    @Override // com.scanflow.datacapture.barinternal.org.ejml.data.ReshapeMatrix
    public void reshape(int i, int i2) {
        assignShape(i, i2);
        int i3 = i * i2 * 2;
        if (i3 > this.data.length) {
            this.data = new double[i3];
        }
    }

    @Override // com.scanflow.datacapture.barinternal.org.ejml.data.ZMatrix
    public void get(int i, int i2, Complex_F64 complex_F64) {
        int i3 = (i * this.numCols * 2) + (i2 * 2);
        double[] dArr = this.data;
        complex_F64.real = dArr[i3];
        complex_F64.imaginary = dArr[i3 + 1];
    }

    @Override // com.scanflow.datacapture.barinternal.org.ejml.data.ZMatrix
    public void set(int i, int i2, double d, double d2) {
        int i3 = (i * this.numCols * 2) + (i2 * 2);
        double[] dArr = this.data;
        dArr[i3] = d;
        dArr[i3 + 1] = d2;
    }

    @Override // com.scanflow.datacapture.barinternal.org.ejml.data.ZMatrix
    public double getReal(int i, int i2) {
        return this.data[((i * this.numCols) + i2) * 2];
    }

    @Override // com.scanflow.datacapture.barinternal.org.ejml.data.ZMatrix
    public double getImag(int i, int i2) {
        return this.data[(((i * this.numCols) + i2) * 2) + 1];
    }

    @Override // com.scanflow.datacapture.barinternal.org.ejml.data.ZMatrix
    public int getDataLength() {
        return this.numRows * this.numCols * 2;
    }

    public void setTo(ZMatrixRMaj zMatrixRMaj) {
        reshape(zMatrixRMaj.numRows, zMatrixRMaj.numCols);
        int i = this.numCols * 2;
        for (int i2 = 0; i2 < this.numRows; i2++) {
            int i3 = this.numCols * i2 * 2;
            System.arraycopy(zMatrixRMaj.data, i3, this.data, i3, i);
        }
    }

    @Override // com.scanflow.datacapture.barinternal.org.ejml.data.Matrix
    public ZMatrixRMaj copy() {
        return new ZMatrixRMaj(this);
    }

    public int getRowStride() {
        return this.numCols * 2;
    }

    @Override // com.scanflow.datacapture.barinternal.org.ejml.data.Matrix
    public ZMatrixRMaj create(int i, int i2) {
        return new ZMatrixRMaj(i, i2);
    }

    @Override // com.scanflow.datacapture.barinternal.org.ejml.data.Matrix
    public MatrixType getType() {
        return MatrixType.ZDRM;
    }
}
