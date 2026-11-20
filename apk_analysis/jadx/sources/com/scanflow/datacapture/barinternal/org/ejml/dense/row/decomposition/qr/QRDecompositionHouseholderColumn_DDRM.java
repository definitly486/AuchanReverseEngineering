package com.scanflow.datacapture.barinternal.org.ejml.dense.row.decomposition.qr;

import com.scanflow.datacapture.barinternal.org.ejml.data.DMatrixRMaj;
import com.scanflow.datacapture.barinternal.org.ejml.dense.row.decomposition.UtilDecompositons_DDRM;
import com.scanflow.datacapture.barinternal.org.ejml.interfaces.decomposition.QRDecomposition;
import java.lang.reflect.Array;

/* JADX INFO: loaded from: classes3.dex */
public abstract class QRDecompositionHouseholderColumn_DDRM implements QRDecomposition {
    protected double[][] dataQR;
    protected double gamma;
    protected double[] gammas;
    protected int minLength;
    protected int numCols;
    protected int numRows;
    protected double tau;
    protected double[] v;

    public void setExpectedMaxSize(int i, int i2) {
        this.numCols = i2;
        this.numRows = i;
        this.minLength = Math.min(i2, i);
        int iMax = Math.max(i2, i);
        double[][] dArr = this.dataQR;
        if (dArr == null || dArr.length < i2 || dArr[0].length < i) {
            this.dataQR = (double[][]) Array.newInstance((Class<?>) Double.TYPE, i2, i);
            this.v = new double[iMax];
            this.gammas = new double[this.minLength];
        }
        if (this.v.length < iMax) {
            this.v = new double[iMax];
        }
        int length = this.gammas.length;
        int i3 = this.minLength;
        if (length < i3) {
            this.gammas = new double[i3];
        }
    }

    @Override // com.scanflow.datacapture.barinternal.org.ejml.interfaces.decomposition.QRDecomposition
    public DMatrixRMaj getR(DMatrixRMaj dMatrixRMaj, boolean z) {
        DMatrixRMaj dMatrixRMajCheckZerosLT;
        if (z) {
            dMatrixRMajCheckZerosLT = UtilDecompositons_DDRM.checkZerosLT(dMatrixRMaj, this.minLength, this.numCols);
        } else {
            dMatrixRMajCheckZerosLT = UtilDecompositons_DDRM.checkZerosLT(dMatrixRMaj, this.numRows, this.numCols);
        }
        for (int i = 0; i < this.numCols; i++) {
            double[] dArr = this.dataQR[i];
            int iMin = Math.min(i, this.numRows - 1);
            for (int i2 = 0; i2 <= iMin; i2++) {
                dMatrixRMajCheckZerosLT.set(i2, i, dArr[i2]);
            }
        }
        return dMatrixRMajCheckZerosLT;
    }

    protected void convertToColumnMajor(DMatrixRMaj dMatrixRMaj) {
        for (int i = 0; i < this.numCols; i++) {
            double[] dArr = this.dataQR[i];
            for (int i2 = 0; i2 < this.numRows; i2++) {
                dArr[i2] = dMatrixRMaj.data[(dMatrixRMaj.numCols * i2) + i];
            }
        }
    }

    protected void updateA(int i) {
        double[] dArr = this.dataQR[i];
        int i2 = i + 1;
        for (int i3 = i2; i3 < this.numCols; i3++) {
            double[] dArr2 = this.dataQR[i3];
            double d = dArr2[i];
            for (int i4 = i2; i4 < this.numRows; i4++) {
                d += dArr[i4] * dArr2[i4];
            }
            double d2 = d * this.gamma;
            dArr2[i] = dArr2[i] - d2;
            for (int i5 = i2; i5 < this.numRows; i5++) {
                dArr2[i5] = dArr2[i5] - (dArr[i5] * d2);
            }
        }
    }
}
