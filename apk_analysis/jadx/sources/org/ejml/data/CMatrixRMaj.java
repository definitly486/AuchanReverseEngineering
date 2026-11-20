package org.ejml.data;

import com.scanflow.datacapture.barinternal.org.ejml.data.CMatrixD1;
import com.scanflow.datacapture.barinternal.org.ejml.data.Complex_F32;
import com.scanflow.datacapture.barinternal.org.ejml.data.MatrixType;

/* JADX INFO: loaded from: classes3.dex */
public class CMatrixRMaj extends CMatrixD1 {
    public CMatrixRMaj(CMatrixRMaj cMatrixRMaj) {
        this(cMatrixRMaj.numRows, cMatrixRMaj.numCols);
        setTo(cMatrixRMaj);
    }

    public CMatrixRMaj(int i, int i2) {
        assignShape(i, i2);
        this.data = new float[i * i2 * 2];
    }

    @Override // com.scanflow.datacapture.barinternal.org.ejml.data.ReshapeMatrix
    public void reshape(int i, int i2) {
        assignShape(i, i2);
        int i3 = i * i2 * 2;
        if (i3 > this.data.length) {
            this.data = new float[i3];
        }
    }

    @Override // com.scanflow.datacapture.barinternal.org.ejml.data.CMatrix
    public void get(int i, int i2, Complex_F32 complex_F32) {
        int i3 = (i * this.numCols * 2) + (i2 * 2);
        float[] fArr = this.data;
        complex_F32.real = fArr[i3];
        complex_F32.imaginary = fArr[i3 + 1];
    }

    @Override // com.scanflow.datacapture.barinternal.org.ejml.data.CMatrix
    public void set(int i, int i2, float f, float f2) {
        int i3 = (i * this.numCols * 2) + (i2 * 2);
        float[] fArr = this.data;
        fArr[i3] = f;
        fArr[i3 + 1] = f2;
    }

    @Override // com.scanflow.datacapture.barinternal.org.ejml.data.CMatrix
    public float getReal(int i, int i2) {
        return this.data[((i * this.numCols) + i2) * 2];
    }

    @Override // com.scanflow.datacapture.barinternal.org.ejml.data.CMatrix
    public float getImag(int i, int i2) {
        return this.data[(((i * this.numCols) + i2) * 2) + 1];
    }

    public void setTo(CMatrixRMaj cMatrixRMaj) {
        reshape(cMatrixRMaj.numRows, cMatrixRMaj.numCols);
        int i = this.numCols * 2;
        for (int i2 = 0; i2 < this.numRows; i2++) {
            int i3 = this.numCols * i2 * 2;
            System.arraycopy(cMatrixRMaj.data, i3, this.data, i3, i);
        }
    }

    @Override // com.scanflow.datacapture.barinternal.org.ejml.data.Matrix
    public CMatrixRMaj copy() {
        return new CMatrixRMaj(this);
    }

    @Override // com.scanflow.datacapture.barinternal.org.ejml.data.Matrix
    public CMatrixRMaj create(int i, int i2) {
        return new CMatrixRMaj(i, i2);
    }

    @Override // com.scanflow.datacapture.barinternal.org.ejml.data.Matrix
    public MatrixType getType() {
        return MatrixType.CDRM;
    }
}
