package com.scanflow.datacapture.barinternal.org.ejml.dense.row.decomposition.svd;

import com.scanflow.datacapture.barinternal.org.ejml.data.DMatrixRMaj;
import com.scanflow.datacapture.barinternal.org.ejml.interfaces.decomposition.SingularValueDecomposition_F64;

/* JADX INFO: loaded from: classes3.dex */
public class SafeSvd_DDRM implements SingularValueDecomposition_F64 {
    SingularValueDecomposition_F64 alg;
    DMatrixRMaj work = new DMatrixRMaj(1, 1);

    public SafeSvd_DDRM(SingularValueDecomposition_F64 singularValueDecomposition_F64) {
        this.alg = singularValueDecomposition_F64;
    }

    @Override // com.scanflow.datacapture.barinternal.org.ejml.interfaces.decomposition.SingularValueDecomposition_F64
    public double[] getSingularValues() {
        return this.alg.getSingularValues();
    }

    @Override // com.scanflow.datacapture.barinternal.org.ejml.interfaces.decomposition.SingularValueDecomposition
    public int numberOfSingularValues() {
        return this.alg.numberOfSingularValues();
    }

    @Override // com.scanflow.datacapture.barinternal.org.ejml.interfaces.decomposition.SingularValueDecomposition
    public DMatrixRMaj getV(DMatrixRMaj dMatrixRMaj, boolean z) {
        return (DMatrixRMaj) this.alg.getV(dMatrixRMaj, z);
    }

    @Override // com.scanflow.datacapture.barinternal.org.ejml.interfaces.decomposition.DecompositionInterface
    public boolean decompose(DMatrixRMaj dMatrixRMaj) {
        if (this.alg.inputModified()) {
            this.work.reshape(dMatrixRMaj.numRows, dMatrixRMaj.numCols);
            this.work.setTo(dMatrixRMaj);
            return this.alg.decompose(this.work);
        }
        return this.alg.decompose(dMatrixRMaj);
    }

    @Override // com.scanflow.datacapture.barinternal.org.ejml.interfaces.decomposition.DecompositionInterface
    public boolean inputModified() {
        return false;
    }
}
