package com.scanflow.datacapture.barinternal.org.ejml.data;

import com.scanflow.datacapture.barinternal.org.ejml.ops.MatrixIO;
import java.io.ByteArrayOutputStream;
import java.io.PrintStream;
import java.nio.charset.Charset;
import java.util.Arrays;

/* JADX INFO: loaded from: classes3.dex */
public class DMatrixRMaj extends DMatrix1Row {
    public DMatrixRMaj(int i, int i2) {
        assignShape(i, i2);
        this.data = new double[i * i2];
    }

    public DMatrixRMaj(DMatrixRMaj dMatrixRMaj) {
        this(dMatrixRMaj.numRows, dMatrixRMaj.numCols);
        System.arraycopy(dMatrixRMaj.data, 0, this.data, 0, dMatrixRMaj.getNumElements());
    }

    public DMatrixRMaj(int i) {
        this.data = new double[i];
    }

    @Override // com.scanflow.datacapture.barinternal.org.ejml.data.DMatrixD1
    public void reshape(int i, int i2, boolean z) {
        int numElements = getNumElements();
        assignShape(i, i2);
        double[] dArr = this.data;
        int i3 = i * i2;
        if (dArr.length < i3) {
            double[] dArr2 = new double[i3];
            if (z) {
                System.arraycopy(dArr, 0, dArr2, 0, numElements);
            }
            this.data = dArr2;
        }
    }

    @Override // com.scanflow.datacapture.barinternal.org.ejml.data.DMatrix
    public void set(int i, int i2, double d) {
        int i3;
        if (i2 < 0 || i2 >= (i3 = this.numCols) || i < 0 || i >= this.numRows) {
            throw new IllegalArgumentException("Specified element is out of bounds: (" + i + " , " + i2 + ")");
        }
        this.data[(i * i3) + i2] = d;
    }

    @Override // com.scanflow.datacapture.barinternal.org.ejml.data.DMatrix
    public void unsafe_set(int i, int i2, double d) {
        this.data[(i * this.numCols) + i2] = d;
    }

    @Override // com.scanflow.datacapture.barinternal.org.ejml.data.DMatrix
    public double get(int i, int i2) {
        int i3;
        if (i2 < 0 || i2 >= (i3 = this.numCols) || i < 0 || i >= this.numRows) {
            throw new IllegalArgumentException("Specified element is out of bounds: " + i + " " + i2);
        }
        return this.data[(i * i3) + i2];
    }

    @Override // com.scanflow.datacapture.barinternal.org.ejml.data.DMatrix
    public double unsafe_get(int i, int i2) {
        return this.data[(i * this.numCols) + i2];
    }

    public int getIndex(int i, int i2) {
        return (i * this.numCols) + i2;
    }

    public void zero() {
        Arrays.fill(this.data, 0, getNumElements(), 0.0d);
    }

    @Override // com.scanflow.datacapture.barinternal.org.ejml.data.Matrix
    public DMatrixRMaj copy() {
        return new DMatrixRMaj(this);
    }

    public String toString() {
        ByteArrayOutputStream byteArrayOutputStream = new ByteArrayOutputStream();
        MatrixIO.print(new PrintStream(byteArrayOutputStream), (DMatrix) this);
        return byteArrayOutputStream.toString(Charset.defaultCharset());
    }

    @Override // com.scanflow.datacapture.barinternal.org.ejml.data.Matrix
    public DMatrixRMaj create(int i, int i2) {
        return new DMatrixRMaj(i, i2);
    }

    @Override // com.scanflow.datacapture.barinternal.org.ejml.data.Matrix
    public MatrixType getType() {
        return MatrixType.DDRM;
    }
}
