package com.scanflow.datacapture.barinternal.org.ejml.dense.row.linsol.svd;

import com.scanflow.datacapture.barinternal.org.ejml.data.DMatrixRMaj;
import com.scanflow.datacapture.barinternal.org.ejml.dense.row.CommonOps_DDRM;
import com.scanflow.datacapture.barinternal.org.ejml.dense.row.SingularOps_DDRM;
import com.scanflow.datacapture.barinternal.org.ejml.dense.row.factory.DecompositionFactory_DDRM;
import com.scanflow.datacapture.barinternal.org.ejml.interfaces.SolveNullSpace;
import com.scanflow.datacapture.barinternal.org.ejml.interfaces.decomposition.SingularValueDecomposition_F64;

/* JADX INFO: loaded from: classes3.dex */
public class SolveNullSpaceSvd_DDRM implements SolveNullSpace {
    DMatrixRMaj V;
    boolean compact = true;
    SingularValueDecomposition_F64 svd = DecompositionFactory_DDRM.svd(1, 1, false, true, true);

    @Override // com.scanflow.datacapture.barinternal.org.ejml.interfaces.SolveNullSpace
    public boolean process(DMatrixRMaj dMatrixRMaj, int i, DMatrixRMaj dMatrixRMaj2) {
        if (dMatrixRMaj.numCols > dMatrixRMaj.numRows) {
            if (this.compact) {
                this.svd = DecompositionFactory_DDRM.svd(1, 1, false, true, false);
                this.compact = false;
            }
        } else if (!this.compact) {
            this.svd = DecompositionFactory_DDRM.svd(1, 1, false, true, true);
            this.compact = true;
        }
        if (!this.svd.decompose(dMatrixRMaj)) {
            return false;
        }
        double[] singularValues = this.svd.getSingularValues();
        this.V = (DMatrixRMaj) this.svd.getV(this.V, false);
        SingularOps_DDRM.descendingOrder(null, false, singularValues, this.svd.numberOfSingularValues(), this.V, false);
        dMatrixRMaj2.reshape(this.V.numRows, i);
        DMatrixRMaj dMatrixRMaj3 = this.V;
        int i2 = dMatrixRMaj3.numRows;
        int i3 = dMatrixRMaj3.numCols;
        CommonOps_DDRM.extract(dMatrixRMaj3, 0, i2, i3 - i, i3, dMatrixRMaj2, 0, 0);
        return true;
    }
}
