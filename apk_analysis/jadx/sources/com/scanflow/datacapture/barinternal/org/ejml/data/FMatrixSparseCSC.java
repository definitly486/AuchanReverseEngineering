package com.scanflow.datacapture.barinternal.org.ejml.data;

import com.scanflow.datacapture.barinternal.org.ejml.UtilEjml;
import java.util.Arrays;

/* JADX INFO: loaded from: classes3.dex */
public class FMatrixSparseCSC implements FMatrix, MatrixSparse {
    public int[] col_idx;
    public boolean indicesSorted;
    public int numCols;
    public int numRows;
    public int nz_length;
    public int[] nz_rows;
    public float[] nz_values;

    public FMatrixSparseCSC(int i, int i2) {
        this(i, i2, 0);
    }

    public FMatrixSparseCSC(int i, int i2, int i3) {
        this.nz_values = UtilEjml.ZERO_LENGTH_F32;
        this.nz_rows = UtilEjml.ZERO_LENGTH_I32;
        this.indicesSorted = false;
        if (i < 0 || i2 < 0 || i3 < 0) {
            throw new IllegalArgumentException("Rows, columns, and arrayLength must be not be negative");
        }
        this.numRows = i;
        this.numCols = i2;
        this.nz_length = 0;
        this.col_idx = new int[i2 + 1];
        growMaxLength(i3, false);
    }

    public FMatrixSparseCSC(FMatrixSparseCSC fMatrixSparseCSC) {
        this(fMatrixSparseCSC.numRows, fMatrixSparseCSC.numCols, fMatrixSparseCSC.nz_length);
        setTo(fMatrixSparseCSC);
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
    public FMatrixSparseCSC copy() {
        return new FMatrixSparseCSC(this);
    }

    public void setTo(Matrix matrix) {
        FMatrixSparseCSC fMatrixSparseCSC = (FMatrixSparseCSC) matrix;
        reshape(fMatrixSparseCSC.numRows, fMatrixSparseCSC.numCols, fMatrixSparseCSC.nz_length);
        int i = fMatrixSparseCSC.nz_length;
        this.nz_length = i;
        System.arraycopy(fMatrixSparseCSC.nz_values, 0, this.nz_values, 0, i);
        System.arraycopy(fMatrixSparseCSC.nz_rows, 0, this.nz_rows, 0, this.nz_length);
        System.arraycopy(fMatrixSparseCSC.col_idx, 0, this.col_idx, 0, this.numCols + 1);
        this.indicesSorted = fMatrixSparseCSC.indicesSorted;
    }

    @Override // com.scanflow.datacapture.barinternal.org.ejml.data.FMatrix
    public float get(int i, int i2) {
        if (i < 0 || i >= this.numRows || i2 < 0 || i2 >= this.numCols) {
            throw new IllegalArgumentException("Outside of matrix bounds");
        }
        return unsafe_get(i, i2);
    }

    @Override // com.scanflow.datacapture.barinternal.org.ejml.data.FMatrix
    public float unsafe_get(int i, int i2) {
        int iNz_index = nz_index(i, i2);
        if (iNz_index >= 0) {
            return this.nz_values[iNz_index];
        }
        return 0.0f;
    }

    public int nz_index(int i, int i2) {
        int[] iArr = this.col_idx;
        int i3 = iArr[i2];
        int i4 = iArr[i2 + 1];
        if (this.indicesSorted) {
            return Arrays.binarySearch(this.nz_rows, i3, i4, i);
        }
        while (i3 < i4) {
            if (this.nz_rows[i3] == i) {
                return i3;
            }
            i3++;
        }
        return -1;
    }

    @Override // com.scanflow.datacapture.barinternal.org.ejml.data.FMatrix
    public void unsafe_set(int i, int i2, float f) {
        int iNz_index = nz_index(i, i2);
        if (iNz_index >= 0) {
            this.nz_values[iNz_index] = f;
            return;
        }
        int[] iArr = this.col_idx;
        int i3 = iArr[i2];
        int i4 = i2 + 1;
        int i5 = iArr[i4];
        while (i3 < i5 && i >= this.nz_rows[i3]) {
            i3++;
        }
        while (i4 <= this.numCols) {
            int[] iArr2 = this.col_idx;
            iArr2[i4] = iArr2[i4] + 1;
            i4++;
        }
        int i6 = this.nz_length;
        if (i6 >= this.nz_values.length) {
            growMaxLength((i6 * 2) + 1, true);
        }
        for (int i7 = this.nz_length; i7 > i3; i7--) {
            int[] iArr3 = this.nz_rows;
            int i8 = i7 - 1;
            iArr3[i7] = iArr3[i8];
            float[] fArr = this.nz_values;
            fArr[i7] = fArr[i8];
        }
        this.nz_rows[i3] = i;
        this.nz_values[i3] = f;
        this.nz_length++;
    }

    @Override // com.scanflow.datacapture.barinternal.org.ejml.data.Matrix
    public FMatrixSparseCSC create(int i, int i2) {
        return new FMatrixSparseCSC(i, i2);
    }

    @Override // com.scanflow.datacapture.barinternal.org.ejml.data.MatrixSparse
    public int getNonZeroLength() {
        return this.nz_length;
    }

    public void reshape(int i, int i2, int i3) {
        if (i < 0 || i2 < 0 || i3 < 0) {
            throw new IllegalArgumentException("Rows, columns, and arrayLength must be not be negative");
        }
        this.indicesSorted = false;
        this.numRows = i;
        this.numCols = i2;
        growMaxLength(i3, false);
        this.nz_length = 0;
        int i4 = i2 + 1;
        int[] iArr = this.col_idx;
        if (i4 > iArr.length) {
            this.col_idx = new int[i4];
        } else {
            Arrays.fill(iArr, 0, i4, 0);
        }
    }

    @Override // com.scanflow.datacapture.barinternal.org.ejml.data.ReshapeMatrix
    public void reshape(int i, int i2) {
        reshape(i, i2, 0);
    }

    public void growMaxLength(int i, boolean z) {
        if (i < 0) {
            throw new IllegalArgumentException("Negative array length. Overflow?");
        }
        float[] fArr = this.nz_values;
        if (i > fArr.length) {
            float[] fArr2 = new float[i];
            int[] iArr = new int[i];
            if (z) {
                System.arraycopy(fArr, 0, fArr2, 0, this.nz_length);
                System.arraycopy(this.nz_rows, 0, iArr, 0, this.nz_length);
            }
            this.nz_values = fArr2;
            this.nz_rows = iArr;
        }
    }

    @Override // com.scanflow.datacapture.barinternal.org.ejml.data.Matrix
    public MatrixType getType() {
        return MatrixType.FSCC;
    }
}
