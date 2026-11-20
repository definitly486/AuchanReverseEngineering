package com.scanflow.datacapture.barinternal.org.ejml.data;

import com.scanflow.datacapture.barinternal.org.ejml.ops.MatrixIO;
import java.io.ByteArrayOutputStream;
import java.io.PrintStream;
import java.nio.charset.Charset;
import java.util.Arrays;

/* JADX INFO: loaded from: classes3.dex */
public class FMatrixRMaj extends FMatrix1Row {
    public FMatrixRMaj(int i, int i2) {
        assignShape(i, i2);
        this.data = new float[i * i2];
    }

    public FMatrixRMaj(FMatrixRMaj fMatrixRMaj) {
        this(fMatrixRMaj.numRows, fMatrixRMaj.numCols);
        System.arraycopy(fMatrixRMaj.data, 0, this.data, 0, fMatrixRMaj.getNumElements());
    }

    @Override // com.scanflow.datacapture.barinternal.org.ejml.data.FMatrixD1
    public void reshape(int i, int i2, boolean z) {
        int numElements = getNumElements();
        assignShape(i, i2);
        float[] fArr = this.data;
        int i3 = i * i2;
        if (fArr.length < i3) {
            float[] fArr2 = new float[i3];
            if (z) {
                System.arraycopy(fArr, 0, fArr2, 0, numElements);
            }
            this.data = fArr2;
        }
    }

    @Override // com.scanflow.datacapture.barinternal.org.ejml.data.FMatrix
    public void unsafe_set(int i, int i2, float f) {
        this.data[(i * this.numCols) + i2] = f;
    }

    @Override // com.scanflow.datacapture.barinternal.org.ejml.data.FMatrix
    public float get(int i, int i2) {
        int i3;
        if (i2 < 0 || i2 >= (i3 = this.numCols) || i < 0 || i >= this.numRows) {
            throw new IllegalArgumentException("Specified element is out of bounds: " + i + " " + i2);
        }
        return this.data[(i * i3) + i2];
    }

    @Override // com.scanflow.datacapture.barinternal.org.ejml.data.FMatrix
    public float unsafe_get(int i, int i2) {
        return this.data[(i * this.numCols) + i2];
    }

    public void zero() {
        Arrays.fill(this.data, 0, getNumElements(), 0.0f);
    }

    @Override // com.scanflow.datacapture.barinternal.org.ejml.data.Matrix
    public FMatrixRMaj copy() {
        return new FMatrixRMaj(this);
    }

    public String toString() {
        ByteArrayOutputStream byteArrayOutputStream = new ByteArrayOutputStream();
        MatrixIO.print(new PrintStream(byteArrayOutputStream), (FMatrix) this);
        return byteArrayOutputStream.toString(Charset.defaultCharset());
    }

    @Override // com.scanflow.datacapture.barinternal.org.ejml.data.Matrix
    public FMatrixRMaj create(int i, int i2) {
        return new FMatrixRMaj(i, i2);
    }

    @Override // com.scanflow.datacapture.barinternal.org.ejml.data.Matrix
    public MatrixType getType() {
        return MatrixType.FDRM;
    }
}
