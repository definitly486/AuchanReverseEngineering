package com.scanflow.datacapture.barinternal.org.ejml.dense.row.decomposition.qr;

import com.scanflow.datacapture.barinternal.org.ejml.UtilEjml;
import com.scanflow.datacapture.barinternal.org.ejml.data.DMatrixRMaj;
import com.scanflow.datacapture.barinternal.org.ejml.dense.row.CommonOps_DDRM;
import com.scanflow.datacapture.barinternal.org.ejml.dense.row.decomposition.UtilDecompositons_DDRM;
import com.scanflow.datacapture.barinternal.org.ejml.interfaces.decomposition.QRPDecomposition_F64;

/* JADX INFO: loaded from: classes3.dex */
public class QRColPivDecompositionHouseholderColumn_DDRM extends QRDecompositionHouseholderColumn_DDRM implements QRPDecomposition_F64 {
    double maxValueAbs;
    protected double[] normsCol;
    protected int[] pivots;
    protected int rank;
    protected double singularThreshold = UtilEjml.EPS;

    @Override // com.scanflow.datacapture.barinternal.org.ejml.dense.row.decomposition.qr.QRDecompositionHouseholderColumn_DDRM
    public void setExpectedMaxSize(int i, int i2) {
        super.setExpectedMaxSize(i, i2);
        int[] iArr = this.pivots;
        if (iArr == null || iArr.length < i2) {
            this.pivots = new int[i2];
            this.normsCol = new double[i2];
        }
    }

    @Override // com.scanflow.datacapture.barinternal.org.ejml.interfaces.decomposition.QRDecomposition
    public DMatrixRMaj getQ(DMatrixRMaj dMatrixRMaj, boolean z) {
        DMatrixRMaj dMatrixRMajEnsureIdentity;
        if (z) {
            dMatrixRMajEnsureIdentity = UtilDecompositons_DDRM.ensureIdentity(dMatrixRMaj, this.numRows, this.minLength);
        } else {
            int i = this.numRows;
            dMatrixRMajEnsureIdentity = UtilDecompositons_DDRM.ensureIdentity(dMatrixRMaj, i, i);
        }
        DMatrixRMaj dMatrixRMaj2 = dMatrixRMajEnsureIdentity;
        for (int i2 = this.rank - 1; i2 >= 0; i2--) {
            double[] dArr = this.dataQR[i2];
            double d = dArr[i2];
            dArr[i2] = 1.0d;
            QrHelperFunctions_DDRM.rank1UpdateMultR(dMatrixRMaj2, dArr, this.gammas[i2], i2, i2, this.numRows, this.v);
            dArr[i2] = d;
        }
        return dMatrixRMaj2;
    }

    @Override // com.scanflow.datacapture.barinternal.org.ejml.interfaces.decomposition.DecompositionInterface
    public boolean decompose(DMatrixRMaj dMatrixRMaj) {
        setExpectedMaxSize(dMatrixRMaj.numRows, dMatrixRMaj.numCols);
        this.maxValueAbs = CommonOps_DDRM.elementMaxAbs(dMatrixRMaj);
        convertToColumnMajor(dMatrixRMaj);
        setupPivotInfo();
        int i = 0;
        while (i < this.minLength) {
            if (i > 0) {
                updateNorms(i);
            }
            swapColumns(i);
            if (!householderPivot(i)) {
                return true;
            }
            updateA(i);
            i++;
            this.rank = i;
        }
        return true;
    }

    protected void setupPivotInfo() {
        for (int i = 0; i < this.numCols; i++) {
            this.pivots[i] = i;
            double[] dArr = this.dataQR[i];
            double d = 0.0d;
            for (int i2 = 0; i2 < this.numRows; i2++) {
                double d2 = dArr[i2];
                d += d2 * d2;
            }
            this.normsCol[i] = d;
        }
    }

    protected void updateNorms(int i) {
        for (int i2 = i; i2 < this.numCols; i2++) {
            double d = this.dataQR[i2][i - 1];
            double[] dArr = this.normsCol;
            double d2 = dArr[i2] - (d * d);
            dArr[i2] = d2;
            if (d2 < 0.0d) {
                for (int i3 = i; i3 < this.numCols; i3++) {
                    double[] dArr2 = this.dataQR[i3];
                    double d3 = 0.0d;
                    for (int i4 = i; i4 < this.numRows; i4++) {
                        double d4 = dArr2[i4];
                        d3 += d4 * d4;
                    }
                    this.normsCol[i3] = d3;
                }
                return;
            }
        }
    }

    protected void swapColumns(int i) {
        double d = this.normsCol[i];
        int i2 = i;
        for (int i3 = i + 1; i3 < this.numCols; i3++) {
            double d2 = this.normsCol[i3];
            if (d2 > d) {
                i2 = i3;
                d = d2;
            }
        }
        double[][] dArr = this.dataQR;
        double[] dArr2 = dArr[i];
        dArr[i] = dArr[i2];
        dArr[i2] = dArr2;
        double[] dArr3 = this.normsCol;
        double d3 = dArr3[i];
        dArr3[i] = dArr3[i2];
        dArr3[i2] = d3;
        int[] iArr = this.pivots;
        int i4 = iArr[i];
        iArr[i] = iArr[i2];
        iArr[i2] = i4;
    }

    protected boolean householderPivot(int i) {
        double[] dArr = this.dataQR[i];
        double dFindMax = QrHelperFunctions_DDRM.findMax(dArr, i, this.numRows - i);
        if (dFindMax <= this.singularThreshold * this.maxValueAbs) {
            return false;
        }
        double dComputeTauAndDivide = QrHelperFunctions_DDRM.computeTauAndDivide(i, this.numRows, dArr, dFindMax);
        this.tau = dComputeTauAndDivide;
        double d = dArr[i] + dComputeTauAndDivide;
        QrHelperFunctions_DDRM.divideElements(i + 1, this.numRows, dArr, d);
        double d2 = this.tau;
        double d3 = d / d2;
        this.gamma = d3;
        double d4 = d2 * dFindMax;
        this.tau = d4;
        dArr[i] = -d4;
        this.gammas[i] = d3;
        return true;
    }

    @Override // com.scanflow.datacapture.barinternal.org.ejml.interfaces.decomposition.QRPDecomposition
    public DMatrixRMaj getColPivotMatrix(DMatrixRMaj dMatrixRMaj) {
        if (dMatrixRMaj == null) {
            int i = this.numCols;
            dMatrixRMaj = new DMatrixRMaj(i, i);
        } else {
            int i2 = dMatrixRMaj.numRows;
            int i3 = this.numCols;
            if (i2 != i3) {
                throw new IllegalArgumentException("Number of rows must be " + this.numCols);
            }
            if (dMatrixRMaj.numCols != i3) {
                throw new IllegalArgumentException("Number of columns must be " + this.numCols);
            }
            dMatrixRMaj.zero();
        }
        for (int i4 = 0; i4 < this.numCols; i4++) {
            dMatrixRMaj.set(this.pivots[i4], i4, 1.0d);
        }
        return dMatrixRMaj;
    }
}
