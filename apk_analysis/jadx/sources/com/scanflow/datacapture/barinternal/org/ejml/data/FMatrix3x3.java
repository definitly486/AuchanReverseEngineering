package com.scanflow.datacapture.barinternal.org.ejml.data;

/* JADX INFO: loaded from: classes3.dex */
public abstract class FMatrix3x3 implements FMatrix {
    public float a11;
    public float a12;
    public float a13;
    public float a21;
    public float a22;
    public float a23;
    public float a31;
    public float a32;
    public float a33;

    @Override // com.scanflow.datacapture.barinternal.org.ejml.data.FMatrix
    public float get(int i, int i2) {
        return unsafe_get(i, i2);
    }

    @Override // com.scanflow.datacapture.barinternal.org.ejml.data.FMatrix
    public float unsafe_get(int i, int i2) {
        if (i == 0) {
            if (i2 == 0) {
                return this.a11;
            }
            if (i2 == 1) {
                return this.a12;
            }
            if (i2 == 2) {
                return this.a13;
            }
        } else if (i == 1) {
            if (i2 == 0) {
                return this.a21;
            }
            if (i2 == 1) {
                return this.a22;
            }
            if (i2 == 2) {
                return this.a23;
            }
        } else if (i == 2) {
            if (i2 == 0) {
                return this.a31;
            }
            if (i2 == 1) {
                return this.a32;
            }
            if (i2 == 2) {
                return this.a33;
            }
        }
        throw new IllegalArgumentException("Row and/or column out of range. " + i + " " + i2);
    }

    @Override // com.scanflow.datacapture.barinternal.org.ejml.data.FMatrix
    public void unsafe_set(int i, int i2, float f) {
        if (i == 0) {
            if (i2 == 0) {
                this.a11 = f;
                return;
            } else if (i2 == 1) {
                this.a12 = f;
                return;
            } else if (i2 == 2) {
                this.a13 = f;
                return;
            }
        } else if (i == 1) {
            if (i2 == 0) {
                this.a21 = f;
                return;
            } else if (i2 == 1) {
                this.a22 = f;
                return;
            } else if (i2 == 2) {
                this.a23 = f;
                return;
            }
        } else if (i == 2) {
            if (i2 == 0) {
                this.a31 = f;
                return;
            } else if (i2 == 1) {
                this.a32 = f;
                return;
            } else if (i2 == 2) {
                this.a33 = f;
                return;
            }
        }
        throw new IllegalArgumentException("Row and/or column out of range. " + i + " " + i2);
    }

    @Override // com.scanflow.datacapture.barinternal.org.ejml.data.Matrix
    public int getNumRows() {
        return 3;
    }

    @Override // com.scanflow.datacapture.barinternal.org.ejml.data.Matrix
    public int getNumCols() {
        return 3;
    }

    @Override // com.scanflow.datacapture.barinternal.org.ejml.data.Matrix
    public MatrixType getType() {
        return MatrixType.UNSPECIFIED;
    }
}
