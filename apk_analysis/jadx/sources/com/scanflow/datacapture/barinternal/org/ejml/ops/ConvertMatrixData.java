package com.scanflow.datacapture.barinternal.org.ejml.ops;

import com.scanflow.datacapture.barinternal.org.ejml.data.CMatrix;
import com.scanflow.datacapture.barinternal.org.ejml.data.DMatrix;
import com.scanflow.datacapture.barinternal.org.ejml.data.DMatrix3x3;
import com.scanflow.datacapture.barinternal.org.ejml.data.DMatrixRMaj;
import com.scanflow.datacapture.barinternal.org.ejml.data.FMatrix;
import com.scanflow.datacapture.barinternal.org.ejml.data.FMatrix3x3;
import com.scanflow.datacapture.barinternal.org.ejml.data.FMatrixRMaj;
import com.scanflow.datacapture.barinternal.org.ejml.data.ZMatrix;
import com.scanflow.datacapture.barinternal.org.ejml.data.ZMatrixRMaj;
import org.ejml.data.CMatrixRMaj;

/* JADX INFO: loaded from: classes3.dex */
public abstract class ConvertMatrixData {
    public static void convert(DMatrix dMatrix, FMatrix fMatrix) {
        if (dMatrix.getNumRows() != fMatrix.getNumRows()) {
            throw new IllegalArgumentException("Number of rows do not match");
        }
        if (dMatrix.getNumCols() != fMatrix.getNumCols()) {
            throw new IllegalArgumentException("Number of columns do not match");
        }
        for (int i = 0; i < dMatrix.getNumRows(); i++) {
            for (int i2 = 0; i2 < dMatrix.getNumCols(); i2++) {
                fMatrix.unsafe_set(i, i2, (float) dMatrix.unsafe_get(i, i2));
            }
        }
    }

    public static void convert(DMatrix dMatrix, ZMatrix zMatrix) {
        if (dMatrix.getNumRows() != zMatrix.getNumRows()) {
            throw new IllegalArgumentException("Number of rows do not match");
        }
        if (dMatrix.getNumCols() != zMatrix.getNumCols()) {
            throw new IllegalArgumentException("Number of columns do not match");
        }
        for (int i = 0; i < dMatrix.getNumRows(); i++) {
            for (int i2 = 0; i2 < dMatrix.getNumCols(); i2++) {
                zMatrix.set(i, i2, dMatrix.unsafe_get(i, i2), 0.0d);
            }
        }
    }

    public static void convert(DMatrix dMatrix, CMatrix cMatrix) {
        if (dMatrix.getNumRows() != cMatrix.getNumRows()) {
            throw new IllegalArgumentException("Number of rows do not match");
        }
        if (dMatrix.getNumCols() != cMatrix.getNumCols()) {
            throw new IllegalArgumentException("Number of columns do not match");
        }
        for (int i = 0; i < dMatrix.getNumRows(); i++) {
            for (int i2 = 0; i2 < dMatrix.getNumCols(); i2++) {
                cMatrix.set(i, i2, (float) dMatrix.unsafe_get(i, i2), 0.0f);
            }
        }
    }

    public static void convert(FMatrix fMatrix, DMatrix dMatrix) {
        if (fMatrix.getNumRows() != dMatrix.getNumRows()) {
            throw new IllegalArgumentException("Number of rows do not match");
        }
        if (fMatrix.getNumCols() != dMatrix.getNumCols()) {
            throw new IllegalArgumentException("Number of columns do not match");
        }
        for (int i = 0; i < fMatrix.getNumRows(); i++) {
            for (int i2 = 0; i2 < fMatrix.getNumCols(); i2++) {
                dMatrix.unsafe_set(i, i2, fMatrix.unsafe_get(i, i2));
            }
        }
    }

    public static void convert(FMatrix fMatrix, ZMatrix zMatrix) {
        if (fMatrix.getNumRows() != zMatrix.getNumRows()) {
            throw new IllegalArgumentException("Number of rows do not match");
        }
        if (fMatrix.getNumCols() != zMatrix.getNumCols()) {
            throw new IllegalArgumentException("Number of columns do not match");
        }
        for (int i = 0; i < fMatrix.getNumRows(); i++) {
            for (int i2 = 0; i2 < fMatrix.getNumCols(); i2++) {
                zMatrix.set(i, i2, fMatrix.unsafe_get(i, i2), 0.0d);
            }
        }
    }

    public static void convert(FMatrix fMatrix, CMatrix cMatrix) {
        if (fMatrix.getNumRows() != cMatrix.getNumRows()) {
            throw new IllegalArgumentException("Number of rows do not match");
        }
        if (fMatrix.getNumCols() != cMatrix.getNumCols()) {
            throw new IllegalArgumentException("Number of columns do not match");
        }
        for (int i = 0; i < fMatrix.getNumRows(); i++) {
            for (int i2 = 0; i2 < fMatrix.getNumCols(); i2++) {
                cMatrix.set(i, i2, fMatrix.unsafe_get(i, i2), 0.0f);
            }
        }
    }

    public static void convert(ZMatrix zMatrix, CMatrix cMatrix) {
        if (zMatrix.getNumRows() != cMatrix.getNumRows()) {
            throw new IllegalArgumentException("Number of rows do not match");
        }
        if (zMatrix.getNumCols() != cMatrix.getNumCols()) {
            throw new IllegalArgumentException("Number of columns do not match");
        }
        for (int i = 0; i < zMatrix.getNumRows(); i++) {
            for (int i2 = 0; i2 < zMatrix.getNumCols(); i2++) {
                cMatrix.set(i, i2, (float) zMatrix.getReal(i, i2), (float) zMatrix.getImag(i, i2));
            }
        }
    }

    public static void convert(CMatrix cMatrix, ZMatrix zMatrix) {
        if (cMatrix.getNumRows() != zMatrix.getNumRows()) {
            throw new IllegalArgumentException("Number of rows do not match");
        }
        if (cMatrix.getNumCols() != zMatrix.getNumCols()) {
            throw new IllegalArgumentException("Number of columns do not match");
        }
        for (int i = 0; i < cMatrix.getNumRows(); i++) {
            for (int i2 = 0; i2 < cMatrix.getNumCols(); i2++) {
                zMatrix.set(i, i2, cMatrix.getReal(i, i2), cMatrix.getImag(i, i2));
            }
        }
    }

    public static void convert(DMatrixRMaj dMatrixRMaj, FMatrixRMaj fMatrixRMaj) {
        int numElements = dMatrixRMaj.getNumElements();
        for (int i = 0; i < numElements; i++) {
            fMatrixRMaj.data[i] = (float) dMatrixRMaj.data[i];
        }
    }

    public static void convert(FMatrixRMaj fMatrixRMaj, DMatrixRMaj dMatrixRMaj) {
        int numElements = fMatrixRMaj.getNumElements();
        for (int i = 0; i < numElements; i++) {
            dMatrixRMaj.data[i] = fMatrixRMaj.data[i];
        }
    }

    public static void convert(DMatrix3x3 dMatrix3x3, FMatrix3x3 fMatrix3x3) {
        fMatrix3x3.a11 = (float) dMatrix3x3.a11;
        fMatrix3x3.a12 = (float) dMatrix3x3.a12;
        fMatrix3x3.a13 = (float) dMatrix3x3.a13;
        fMatrix3x3.a21 = (float) dMatrix3x3.a21;
        fMatrix3x3.a22 = (float) dMatrix3x3.a22;
        fMatrix3x3.a23 = (float) dMatrix3x3.a23;
        fMatrix3x3.a31 = (float) dMatrix3x3.a31;
        fMatrix3x3.a32 = (float) dMatrix3x3.a32;
        fMatrix3x3.a33 = (float) dMatrix3x3.a33;
    }

    public static void convert(DMatrixRMaj dMatrixRMaj, ZMatrixRMaj zMatrixRMaj) {
        int numElements = dMatrixRMaj.getNumElements();
        int i = 0;
        for (int i2 = 0; i2 < numElements; i2++) {
            double[] dArr = zMatrixRMaj.data;
            int i3 = i + 1;
            dArr[i] = dMatrixRMaj.data[i2];
            i += 2;
            dArr[i3] = 0.0d;
        }
    }

    public static void convert(DMatrixRMaj dMatrixRMaj, CMatrixRMaj cMatrixRMaj) {
        int numElements = dMatrixRMaj.getNumElements();
        int i = 0;
        for (int i2 = 0; i2 < numElements; i2++) {
            float[] fArr = cMatrixRMaj.data;
            int i3 = i + 1;
            fArr[i] = (float) dMatrixRMaj.data[i2];
            i += 2;
            fArr[i3] = 0.0f;
        }
    }

    public static void convert(FMatrixRMaj fMatrixRMaj, ZMatrixRMaj zMatrixRMaj) {
        int numElements = fMatrixRMaj.getNumElements();
        int i = 0;
        for (int i2 = 0; i2 < numElements; i2++) {
            double[] dArr = zMatrixRMaj.data;
            int i3 = i + 1;
            dArr[i] = fMatrixRMaj.data[i2];
            i += 2;
            dArr[i3] = 0.0d;
        }
    }

    public static void convert(FMatrixRMaj fMatrixRMaj, CMatrixRMaj cMatrixRMaj) {
        int numElements = fMatrixRMaj.getNumElements();
        int i = 0;
        for (int i2 = 0; i2 < numElements; i2++) {
            float[] fArr = cMatrixRMaj.data;
            int i3 = i + 1;
            fArr[i] = fMatrixRMaj.data[i2];
            i += 2;
            fArr[i3] = 0.0f;
        }
    }
}
