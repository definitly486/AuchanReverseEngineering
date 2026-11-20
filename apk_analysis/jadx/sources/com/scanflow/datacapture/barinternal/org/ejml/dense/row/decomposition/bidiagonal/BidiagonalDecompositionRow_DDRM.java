package com.scanflow.datacapture.barinternal.org.ejml.dense.row.decomposition.bidiagonal;

import com.scanflow.datacapture.barinternal.org.ejml.data.DMatrixRMaj;
import com.scanflow.datacapture.barinternal.org.ejml.dense.row.CommonOps_DDRM;
import com.scanflow.datacapture.barinternal.org.ejml.dense.row.decomposition.qr.QrHelperFunctions_DDRM;
import com.scanflow.datacapture.barinternal.org.ejml.interfaces.decomposition.BidiagonalDecomposition_F64;

/* JADX INFO: loaded from: classes3.dex */
public class BidiagonalDecompositionRow_DDRM implements BidiagonalDecomposition_F64 {
    private DMatrixRMaj UBV;
    protected double[] b;
    private double[] gammasU;
    private double[] gammasV;
    private int m;
    private int min;
    private int n;
    protected double[] u;

    public BidiagonalDecompositionRow_DDRM(int i) {
        this.UBV = new DMatrixRMaj(i);
        this.gammasU = new double[i];
        this.gammasV = new double[i];
        this.b = new double[i];
        this.u = new double[i];
    }

    public BidiagonalDecompositionRow_DDRM() {
        this(1);
    }

    @Override // com.scanflow.datacapture.barinternal.org.ejml.interfaces.decomposition.DecompositionInterface
    public boolean decompose(DMatrixRMaj dMatrixRMaj) {
        init(dMatrixRMaj);
        return _decompose();
    }

    protected void init(DMatrixRMaj dMatrixRMaj) {
        this.UBV = dMatrixRMaj;
        int i = dMatrixRMaj.numRows;
        this.m = i;
        int i2 = dMatrixRMaj.numCols;
        this.n = i2;
        this.min = Math.min(i, i2);
        int iMax = Math.max(this.m, this.n) + 1;
        if (this.b.length < iMax) {
            this.b = new double[iMax];
            this.u = new double[iMax];
        }
        int length = this.gammasU.length;
        int i3 = this.m;
        if (length < i3) {
            this.gammasU = new double[i3];
        }
        int length2 = this.gammasV.length;
        int i4 = this.n;
        if (length2 < i4) {
            this.gammasV = new double[i4];
        }
    }

    @Override // com.scanflow.datacapture.barinternal.org.ejml.interfaces.decomposition.BidiagonalDecomposition_F64
    public void getDiagonal(double[] dArr, double[] dArr2) {
        if (this.n <= 0) {
            return;
        }
        dArr[0] = this.UBV.get(0);
        for (int i = 1; i < this.n; i++) {
            dArr[i] = this.UBV.unsafe_get(i, i);
            int i2 = i - 1;
            dArr2[i2] = this.UBV.unsafe_get(i2, i);
        }
    }

    @Override // com.scanflow.datacapture.barinternal.org.ejml.interfaces.decomposition.BidiagonalDecomposition
    public DMatrixRMaj getU(DMatrixRMaj dMatrixRMaj, boolean z, boolean z2) {
        int i;
        DMatrixRMaj dMatrixRMajHandleU = handleU(dMatrixRMaj, z, z2, this.m, this.n, this.min);
        CommonOps_DDRM.setIdentity(dMatrixRMajHandleU);
        for (int i2 = 0; i2 < this.m; i2++) {
            this.u[i2] = 0.0d;
        }
        for (int i3 = this.min - 1; i3 >= 0; i3--) {
            this.u[i3] = 1.0d;
            int i4 = i3 + 1;
            while (true) {
                i = this.m;
                if (i4 >= i) {
                    break;
                }
                this.u[i4] = this.UBV.get(i4, i3);
                i4++;
            }
            if (z) {
                rank1UpdateMultL(dMatrixRMajHandleU, this.gammasU[i3], i3, i3, i);
            } else {
                rank1UpdateMultR(dMatrixRMajHandleU, this.gammasU[i3], i3, i3, i);
            }
        }
        return dMatrixRMajHandleU;
    }

    public static DMatrixRMaj handleU(DMatrixRMaj dMatrixRMaj, boolean z, boolean z2, int i, int i2, int i3) {
        if (!z2) {
            if (dMatrixRMaj == null) {
                return new DMatrixRMaj(i, i);
            }
            dMatrixRMaj.reshape(i, i, false);
            return dMatrixRMaj;
        }
        if (z) {
            if (dMatrixRMaj == null) {
                return new DMatrixRMaj(i3, i);
            }
            dMatrixRMaj.reshape(i3, i, false);
            return dMatrixRMaj;
        }
        if (dMatrixRMaj == null) {
            return new DMatrixRMaj(i, i3);
        }
        dMatrixRMaj.reshape(i, i3, false);
        return dMatrixRMaj;
    }

    @Override // com.scanflow.datacapture.barinternal.org.ejml.interfaces.decomposition.BidiagonalDecomposition
    public DMatrixRMaj getV(DMatrixRMaj dMatrixRMaj, boolean z, boolean z2) {
        int i;
        DMatrixRMaj dMatrixRMajHandleV = handleV(dMatrixRMaj, z, z2, this.m, this.n, this.min);
        CommonOps_DDRM.setIdentity(dMatrixRMajHandleV);
        for (int i2 = this.min - 1; i2 >= 0; i2--) {
            int i3 = i2 + 1;
            this.u[i3] = 1.0d;
            int i4 = i2 + 2;
            while (true) {
                i = this.n;
                if (i4 >= i) {
                    break;
                }
                this.u[i4] = this.UBV.get(i2, i4);
                i4++;
            }
            if (z) {
                rank1UpdateMultL(dMatrixRMajHandleV, this.gammasV[i2], i3, i3, i);
            } else {
                rank1UpdateMultR(dMatrixRMajHandleV, this.gammasV[i2], i3, i3, i);
            }
        }
        return dMatrixRMajHandleV;
    }

    public static DMatrixRMaj handleV(DMatrixRMaj dMatrixRMaj, boolean z, boolean z2, int i, int i2, int i3) {
        if (i2 > i) {
            i3++;
        }
        if (!z2) {
            if (dMatrixRMaj == null) {
                return new DMatrixRMaj(i2, i2);
            }
            dMatrixRMaj.reshape(i2, i2, false);
            return dMatrixRMaj;
        }
        if (z) {
            if (dMatrixRMaj == null) {
                return new DMatrixRMaj(i3, i2);
            }
            dMatrixRMaj.reshape(i3, i2, false);
            return dMatrixRMaj;
        }
        if (dMatrixRMaj == null) {
            return new DMatrixRMaj(i2, i3);
        }
        dMatrixRMaj.reshape(i2, i3, false);
        return dMatrixRMaj;
    }

    private boolean _decompose() {
        for (int i = 0; i < this.min; i++) {
            computeU(i);
            computeV(i);
        }
        return true;
    }

    protected void computeU(int i) {
        int i2;
        double[] dArr = this.UBV.data;
        int i3 = i;
        double d = 0.0d;
        while (true) {
            i2 = this.m;
            if (i3 >= i2) {
                break;
            }
            double[] dArr2 = this.u;
            double d2 = dArr[(this.n * i3) + i];
            dArr2[i3] = d2;
            double dAbs = Math.abs(d2);
            if (dAbs > d) {
                d = dAbs;
            }
            i3++;
        }
        if (d > 0.0d) {
            double dComputeTauAndDivide = QrHelperFunctions_DDRM.computeTauAndDivide(i, i2, this.u, d);
            double[] dArr3 = this.u;
            double d3 = dArr3[i] + dComputeTauAndDivide;
            int i4 = i + 1;
            QrHelperFunctions_DDRM.divideElements_Bcol(i4, this.m, this.n, dArr3, dArr, i, d3);
            this.u[i] = 1.0d;
            double d4 = d3 / dComputeTauAndDivide;
            this.gammasU[i] = d4;
            rank1UpdateMultR(this.UBV, d4, i4, i, this.m);
            dArr[(this.n * i) + i] = (-dComputeTauAndDivide) * d;
            return;
        }
        this.gammasU[i] = 0.0d;
    }

    protected void rank1UpdateMultL(DMatrixRMaj dMatrixRMaj, double d, int i, int i2, int i3) {
        QrHelperFunctions_DDRM.rank1UpdateMultL(dMatrixRMaj, this.u, d, i, i2, i3);
    }

    protected void rank1UpdateMultR(DMatrixRMaj dMatrixRMaj, double d, int i, int i2, int i3) {
        QrHelperFunctions_DDRM.rank1UpdateMultR(dMatrixRMaj, this.u, d, i, i2, i3, this.b);
    }

    protected void computeV(int i) {
        double[] dArr = this.UBV.data;
        int i2 = this.n;
        int i3 = i * i2;
        int i4 = i3 + i + 1;
        double dFindMax = QrHelperFunctions_DDRM.findMax(dArr, i4, (i2 - i) - 1);
        if (dFindMax > 0.0d) {
            int i5 = i + 1;
            double dComputeTauAndDivide = QrHelperFunctions_DDRM.computeTauAndDivide(i5, this.n, dArr, i3, dFindMax);
            double d = dArr[i4] + dComputeTauAndDivide;
            QrHelperFunctions_DDRM.divideElements_Brow(i + 2, this.n, this.u, dArr, i3, d);
            this.u[i5] = 1.0d;
            double d2 = d / dComputeTauAndDivide;
            this.gammasV[i] = d2;
            rank1UpdateMultL(this.UBV, d2, i5, i5, this.n);
            dArr[i4] = (-dComputeTauAndDivide) * dFindMax;
            return;
        }
        this.gammasV[i] = 0.0d;
    }
}
