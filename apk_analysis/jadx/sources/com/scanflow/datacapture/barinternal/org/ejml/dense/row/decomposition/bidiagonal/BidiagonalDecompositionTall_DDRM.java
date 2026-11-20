package com.scanflow.datacapture.barinternal.org.ejml.dense.row.decomposition.bidiagonal;

import com.scanflow.datacapture.barinternal.org.ejml.data.DMatrixRMaj;
import com.scanflow.datacapture.barinternal.org.ejml.dense.row.CommonOps_DDRM;
import com.scanflow.datacapture.barinternal.org.ejml.dense.row.factory.DecompositionFactory_DDRM;
import com.scanflow.datacapture.barinternal.org.ejml.interfaces.decomposition.BidiagonalDecomposition_F64;
import com.scanflow.datacapture.barinternal.org.ejml.interfaces.decomposition.QRPDecomposition_F64;

/* JADX INFO: loaded from: classes3.dex */
public class BidiagonalDecompositionTall_DDRM implements BidiagonalDecomposition_F64 {
    int m;
    int min;
    int n;
    QRPDecomposition_F64 decompQRP = DecompositionFactory_DDRM.qrp(500, 100);
    BidiagonalDecomposition_F64 decompBi = new BidiagonalDecompositionRow_DDRM();
    DMatrixRMaj B = new DMatrixRMaj(1, 1);

    @Override // com.scanflow.datacapture.barinternal.org.ejml.interfaces.decomposition.BidiagonalDecomposition_F64
    public void getDiagonal(double[] dArr, double[] dArr2) {
        dArr[0] = this.B.get(0);
        for (int i = 1; i < this.n; i++) {
            dArr[i] = this.B.unsafe_get(i, i);
            int i2 = i - 1;
            dArr2[i2] = this.B.unsafe_get(i2, i);
        }
    }

    @Override // com.scanflow.datacapture.barinternal.org.ejml.interfaces.decomposition.BidiagonalDecomposition
    public DMatrixRMaj getU(DMatrixRMaj dMatrixRMaj, boolean z, boolean z2) {
        DMatrixRMaj dMatrixRMajHandleU = BidiagonalDecompositionRow_DDRM.handleU(dMatrixRMaj, false, z2, this.m, this.n, this.min);
        if (z2) {
            CommonOps_DDRM.mult((DMatrixRMaj) this.decompQRP.getQ(null, true), (DMatrixRMaj) this.decompBi.getU(null, false, true), dMatrixRMajHandleU);
        } else {
            DMatrixRMaj dMatrixRMaj2 = (DMatrixRMaj) this.decompQRP.getQ(dMatrixRMajHandleU, false);
            DMatrixRMaj dMatrixRMaj3 = (DMatrixRMaj) this.decompBi.getU(null, false, true);
            DMatrixRMaj dMatrixRMajExtract = CommonOps_DDRM.extract(dMatrixRMaj2, 0, dMatrixRMaj2.numRows, 0, this.min);
            DMatrixRMaj dMatrixRMaj4 = new DMatrixRMaj(dMatrixRMajExtract.numRows, dMatrixRMaj3.numCols);
            CommonOps_DDRM.mult(dMatrixRMajExtract, dMatrixRMaj3, dMatrixRMaj4);
            CommonOps_DDRM.insert(dMatrixRMaj4, dMatrixRMaj2, 0, 0);
        }
        if (z) {
            CommonOps_DDRM.transpose(dMatrixRMajHandleU);
        }
        return dMatrixRMajHandleU;
    }

    @Override // com.scanflow.datacapture.barinternal.org.ejml.interfaces.decomposition.BidiagonalDecomposition
    public DMatrixRMaj getV(DMatrixRMaj dMatrixRMaj, boolean z, boolean z2) {
        return (DMatrixRMaj) this.decompBi.getV(dMatrixRMaj, z, z2);
    }

    @Override // com.scanflow.datacapture.barinternal.org.ejml.interfaces.decomposition.DecompositionInterface
    public boolean decompose(DMatrixRMaj dMatrixRMaj) {
        if (!this.decompQRP.decompose(dMatrixRMaj)) {
            return false;
        }
        int i = dMatrixRMaj.numRows;
        this.m = i;
        int i2 = dMatrixRMaj.numCols;
        this.n = i2;
        int iMin = Math.min(i, i2);
        this.min = iMin;
        this.B.reshape(iMin, this.n, false);
        this.decompQRP.getR(this.B, true);
        DMatrixRMaj dMatrixRMaj2 = new DMatrixRMaj(this.min, this.n);
        CommonOps_DDRM.multTransB(this.B, (DMatrixRMaj) this.decompQRP.getColPivotMatrix(null), dMatrixRMaj2);
        this.B.setTo(dMatrixRMaj2);
        return this.decompBi.decompose(this.B);
    }
}
